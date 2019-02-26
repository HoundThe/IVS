using GUICalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUICalculator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CustomTextBoxContainer.Children.Add(Caret.Instance);
            PreviewKeyDown += WhenKeyDown;
        }


        private void WhenKeyDown(object sender, KeyEventArgs e)
        {
            Caret caret = Caret.Instance;
            Expression currentExpression = caret.ActiveExpression;
            Expression exp = null;
            Point position = default(Point);

            if (e.Key == Key.Left)
            {
                exp = currentExpression.MoveLeft(null, true);
                if (exp == null)
                    exp = ((MainWindowVM)DataContext).Expression;
            }
            else if (e.Key == Key.Right)
            {
                
            }
            
            caret.ActiveExpression = exp;

            if (exp == null)
                position = caret.DefaultPosition;
            else if (caret.ExpressionSide == ExpressionSide.Left)
                position = exp.LeftPositionOf();
            else
                position = exp.RightPositionOf();

            caret.Left = position.X;
            caret.Top = position.Y;

            if (exp == null)
                caret.CaretHeight = caret.DefaultHeight;
            else
                caret.CaretHeight = exp.ActualHeight;

            caret.RestartBlinking();
            e.Handled = true;
        }
        
    }
}
