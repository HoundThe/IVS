using GUICalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private readonly Regex regex = new Regex("^[0123456789+\\-*/()!.]+$");

        public MainWindow()
        {
            InitializeComponent();

            CustomTextBoxContainer.Children.Add(Caret.Instance);
            PreviewKeyDown += WhenKeyDown;
        }

        private void WhenKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                MoveCaret(e);
                e.Handled = true;
            }
        }

        private void MoveCaret(KeyEventArgs e)
        {
            Caret caret = Caret.Instance;
            Expression exp = null;

            if (e.Key == Key.Left)
            {
                Expression tmp = caret.ActiveExpression.MoveLeft(null, true);
                if (tmp != null)
                    exp = tmp;
                //if (exp == null)
                //    exp = ((MainWindowVM)DataContext).Expression;
            }
            else if (e.Key == Key.Right)
            {
                Expression tmp = caret.ActiveExpression.MoveRight(null, true);
                if (tmp != null)
                    exp = tmp;
            }

            if (exp == null)
                return;

            caret.SetActiveExpression(exp);
            caret.RestartBlinking();
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (regex.IsMatch(e.Text))
            {
                Console.WriteLine("{0}", e.Text);
                if (e.Text.Length != 1)
                    throw new Exception("Input text should have length of 1 character.");
                AddNewExpression(e.Text[0]);
            }
            e.Handled = true;
            base.OnPreviewTextInput(e);
        }
        
        private void AddNewExpression(char character)
        {
            Expression activeExp = Caret.Instance.ActiveExpression;
            if (activeExp != null)
            {
                Expression parent = activeExp.ParentExpression;
                Expression newExpression = new Character(character, parent);
                parent.AddExpression(newExpression);
                parent.UpdateLayout();
                Caret.Instance.ExpressionSide = ExpressionSide.Right;
                Caret.Instance.SetActiveExpression(newExpression);
                //if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
                //    Caret.Instance.FlipSide();
            }
        }
    }
}
