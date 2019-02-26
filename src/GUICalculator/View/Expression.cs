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
    //internal enum ExpressionType
    //{
    //    Basic, // 5 + 4 + 3
    //    Root, // 
    //    Power, // 
    //    Number, // 4
    //    Operator, // +
    //    Parenthesis // (
    //}
    public abstract class Expression : ContentControl
    {
        private static Caret caret = Caret.Instance;
        
        public Expression(Expression parent)
        {
            ParentExpression = parent;
            VerticalAlignment = VerticalAlignment.Center;
            MouseLeftButtonUp += OnMouseClick;
            //PreviewKeyDown += WhenKeyDown;
        }

        public Expression ParentExpression { get; }

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
            //caret.ActiveExpression = this;
            //caret.Left = locationFromWindow.X;
            //caret.Top = locationFromWindow.Y;
            //caret.CaretHeight = control.ActualHeight;
            caret.RestartBlinking();
            e.Handled = true;
        }

        public abstract void AddExpression(Expression expression);
        public abstract Expression PreviousChild(Expression currentChild);
        public abstract Expression NextChild(Expression currentChild);
        public abstract Expression LastChild();
        public abstract Expression FirstChild();
        public abstract Expression MoveLeft(Expression child, bool jumpIn);
        public abstract Expression MoveRight(Expression child, bool jumpIn);
    }
}
