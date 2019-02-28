using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUICalculator.View
{
    public abstract class Expression : ContentControl
    {
        private static Caret caret = Caret.Instance;
        
        public Expression()
        {
            VerticalAlignment = VerticalAlignment.Center;
            MouseLeftButtonUp += OnMouseClick;
        }

        public Expression ParentExpression { get; set; }

        private void OnMouseClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Type of sender: {0}", sender.GetType());
            ContentControl control = sender as ContentControl;
            
            Point relativePoint = e.GetPosition(Application.Current.MainWindow);
            Console.WriteLine("{0}", relativePoint);

            Point locationFromWindow = control.LeftPositionOf();
            double distFromLeft = relativePoint.X - locationFromWindow.X;
            double distFromRight = locationFromWindow.X + control.ActualWidth - relativePoint.X;
            Console.WriteLine("From left: {0}, from right: {1}", distFromLeft, distFromRight);

            if (distFromLeft <= distFromRight)
            {
                Console.WriteLine("Caret X location: {0}, height: {1}", locationFromWindow.X, control.ActualHeight);
                locationFromWindow = control.LeftPositionOf();
                caret.ExpressionSide = ExpressionSide.Left;
            }
            else
            {
                Console.WriteLine("Caret X location: {0}, height: {1}", locationFromWindow.X + control.ActualWidth, control.ActualHeight);
                locationFromWindow = control.RightPositionOf();
                caret.ExpressionSide = ExpressionSide.Right;
            }

            caret.SetActiveExpression(this);
            caret.RestartBlinking();
            e.Handled = true;
        }

        public abstract void AddExpression(Expression activeExpression, Expression expressionToBeAdded);
        /// <summary>
        ///     Adds Auxiliary expression if the items count is 0.
        /// </summary>
        /// <returns>Returns the instance of Auxiliary expression class. 
        /// Returns null if no expression was added.</returns>
        public abstract Expression AddAuxiliary();
        public abstract Expression PreviousChild(Expression currentChild);
        public abstract Expression NextChild(Expression currentChild);
        public abstract Expression LastChild();
        public abstract Expression FirstChild();
        public abstract Expression MoveLeft(Expression child, bool jumpIn);
        public abstract Expression MoveRight(Expression child, bool jumpIn);
        public abstract bool DeleteChild(Expression child);

    }
}
