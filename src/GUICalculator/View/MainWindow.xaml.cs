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
        private readonly Regex regex = new Regex("^[0123456789+\\-()!.]+$");
        private readonly MainWindowVM dataContext;

        public MainWindow()
        {
            InitializeComponent();
            dataContext = DataContext as MainWindowVM;

            CustomTextBoxContainer.Children.Add(Caret.Instance);
            PreviewKeyDown += WhenKeyDown;
            Loaded += WhenInitialized;
        }

        private void WhenKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                Direction direction = e.Key == Key.Left ? Direction.Left : Direction.Right;
                dataContext.MoveCaret(direction);
                e.Handled = true;
            }
            else if (e.Key == Key.Back)
            {
                dataContext.DeleteExpression(Direction.Left);
                e.Handled = true;
            }
            else if (e.Key == Key.Delete)
            {
                dataContext.DeleteExpression(Direction.Right);
                e.Handled = true;
            }
            else if (e.Key == Key.Multiply)
            {
                dataContext.AddMultiplicationExpression();
                e.Handled = true;
            }
        }
        
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            // Check if it an allowed character
            if (regex.IsMatch(e.Text))
            {
                Console.WriteLine("{0}", e.Text);
                if (e.Text.Length != 1)
                    throw new Exception("Input text should have length of 1 character.");
                dataContext.AddCharacterExpression(e.Text[0]);
            }
            e.Handled = true;
            base.OnPreviewTextInput(e);
        }

        private void WhenInitialized(object sender, EventArgs e)
        {
            // Make sure the Caret is displayed in the middle.
            // The Caret instance doesn't know where it should render itself
            // until the window is loaded and control's sizes are calculated.
            // At this moment, we can update the Caret's position.
            Caret.Instance.UpdateActiveExpression();
        }

    }
}
