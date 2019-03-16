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
        private Expression _parentExpression;

        public Expression(string templateName)
        {
            this.Template = Application.Current.FindResource(templateName) as ControlTemplate;
            this.DataContext = this;

            VerticalAlignment = VerticalAlignment.Center;
            MouseLeftButtonUp += OnMouseClick;
        }

        public Expression ParentExpression
        {
            get => _parentExpression;
            set
            {
                _parentExpression = value;
                OnParentExpressionSet(_parentExpression);
            }
        }

        protected virtual void OnParentExpressionSet(Expression parent)
        {

        }

        protected virtual void OnMouseClick(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("Type of sender: {0}", sender.GetType());
            ContentControl control = sender as ContentControl;

            Point relativePoint = e.GetPosition(Application.Current.MainWindow);
            //Console.WriteLine("{0}", relativePoint);

            Point locationFromWindow = control.LeftPositionOf();
            double distFromLeft = relativePoint.X - locationFromWindow.X;
            double distFromRight = locationFromWindow.X + control.ActualWidth - relativePoint.X;
            //Console.WriteLine("From left: {0}, from right: {1}", distFromLeft, distFromRight);

            if (distFromLeft <= distFromRight)
            {
                //Console.WriteLine("Caret X location: {0}, height: {1}", locationFromWindow.X, control.ActualHeight);
                locationFromWindow = control.LeftPositionOf();
                caret.ExpressionSide = ExpressionSide.Left;
            }
            else
            {
                //Console.WriteLine("Caret X location: {0}, height: {1}", locationFromWindow.X + control.ActualWidth, control.ActualHeight);
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
        public abstract bool DeleteChild(Expression child);

        public virtual Expression MoveLeft(Expression child, bool jumpIn)
        {
            if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
            {
                Expression previousChild = null;
                if (child != null && (previousChild = PreviousChild(child)) != null)
                {
                    Expression lastChild = previousChild.LastChild();
                    if (lastChild != null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Right;
                        return lastChild;
                    }
                    return previousChild; // leave Left
                }
                else if (child != null && previousChild == null)
                {
                    return this;
                }
                else
                {
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveLeft(this, false)) != null)
                        return tmp;
                }
            }
            else // ExpressionSide.Right
            {
                Expression previousChild = null;
                // jump in from right
                if (jumpIn && LastChild() != null)
                {
                    return LastChild();
                }
                else if (child != null && (previousChild = PreviousChild(child)) != null)
                {
                    return previousChild;
                }
                else if (child != null && previousChild == null)
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Left;
                    return child;
                }
                else
                {
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveLeft(this, false)) != null)
                        return tmp;
                }
            }
            return FirstChild();
        }

        public virtual Expression MoveRight(Expression child, bool jumpIn)
        {
            if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
            {
                Expression nextChild = null;
                if (child != null && (nextChild = NextChild(child)) != null)
                {
                    Expression firstChild = nextChild.FirstChild();
                    if (firstChild != null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Left;
                        return firstChild;
                    }
                    return nextChild;
                }
                else if (child != null && nextChild == null)
                {
                    return this;
                }
                else
                {
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveRight(this, false)) != null)
                        return tmp;
                }
            }
            else // ExpressionSide.Left
            {
                Expression nextChild = null;
                // jump in from left
                if (jumpIn && FirstChild() != null)
                {
                    return FirstChild(); 
                }
                else if (child != null && (nextChild = NextChild(child)) != null)
                {
                    return nextChild ; 
                }
                else if (child != null && nextChild == null)
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    return child;
                }
                else {
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveRight(this, false)) != null)
                        return tmp;
                }
            }
            return LastChild();
        }

    }
}
