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
                exp = caret.ActiveExpression.MoveLeft(null, true);
            else if (e.Key == Key.Right)
                exp = caret.ActiveExpression.MoveRight(null, true);

            if (exp == null)
                return;

            caret.SetActiveExpression(exp);
            caret.RestartBlinking();
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            // Check if it an allowed character
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
                // create new expression and add it to the appropriate parent expression
                Expression parent = activeExp.ParentExpression;
                Expression newExpression = new Character(character, parent);
                parent.AddExpression(newExpression);

                // make sure the new expression is displayed and new position is calculated for this element
                parent.UpdateLayout(); 

                // change the location of caret
                Caret.Instance.ExpressionSide = ExpressionSide.Right;
                Caret.Instance.SetActiveExpression(newExpression);
            }
        }
    }
}
