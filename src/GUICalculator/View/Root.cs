using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace GUICalculator.View
{
    class Root : Expression
    {
        public Root(Expression parent)
            : base(parent)
        {
            this.Template = Application.Current.FindResource("RootExpressionTemplate") as ControlTemplate;
            this.DataContext = this;
        }

        public ObservableCollection<Expression> OuterExpression { get; set; } = new ObservableCollection<Expression>();
        public ObservableCollection<Expression> InnerExpression { get; set; } = new ObservableCollection<Expression>();

        public override Expression NextChild(Expression currentChild)
        {
            for (int i = 0; i < InnerExpression.Count; i++)
            {
                if (currentChild == InnerExpression[i])
                {
                    if (i + 1 == InnerExpression.Count)
                        return null;
                    return InnerExpression[i + 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            for (int i = 0; i < InnerExpression.Count; i++)
            {
                if (currentChild == InnerExpression[i])
                {
                    if (i == 0)
                        return null;
                    return InnerExpression[i - 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }


        public override Expression LastChild()
        {
            if (InnerExpression.Count > 0)
                return InnerExpression[InnerExpression.Count - 1];
            return null;
        }

        public override Expression FirstChild()
        {
            if (InnerExpression.Count > 0)
                return InnerExpression[0];
            return null;
        }

        public override Expression MoveLeft(Expression child, bool jumpIn)
        {
            if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
            {
                if (child != null && PreviousChild(child) != null)
                {
                    Expression lastChild = PreviousChild(child).LastChild();
                    if (lastChild != null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Right;
                        return lastChild;
                    }
                    return PreviousChild(child); // leave Left
                }
                else
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    if (ParentExpression != null && ParentExpression.MoveLeft(this, false) != null)
                        return ParentExpression.MoveLeft(this, false);
                }
            }
            else // Right
            {
                // jump in from right
                if (jumpIn && LastChild() != null)
                {
                    return LastChild(); // leave right
                }

                if (child != null && PreviousChild(child) != null)
                {
                    return PreviousChild(child); // leave right
                }
                else
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Left;
                    return child;
                }
            }
            return null;
        }
    }
}
