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
    class Basic : Expression
    {

        public Basic(Expression parent)
            : base(parent)
        {
            this.Template = Application.Current.FindResource("BasicExpressionTemplate") as ControlTemplate;
            this.DataContext = this;
        }

        public ObservableCollection<Expression> Items { get; set; } = new ObservableCollection<Expression>();

        public override Expression NextChild(Expression currentChild)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (currentChild == Items[i])
                {
                    if (i + 1 == Items.Count)
                        return null;
                    return Items[i + 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (currentChild == Items[i])
                {
                    if (i == 0)
                        return null;
                    return Items[i - 1];
                }
            }
            throw new KeyNotFoundException("Expression not found.");
        }

        public override Expression LastChild()
        {
            if (Items.Count > 0)
                return Items[Items.Count - 1];
            return null;
        }

        public override Expression FirstChild()
        {
            if (Items.Count > 0)
                return Items[0];
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
                    //Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveLeft(this, false)) != null)
                        return tmp;
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
            return FirstChild();
        }

        public override Expression MoveRight(Expression child, bool jumpIn)
        {
            if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
            {
                if (child != null && NextChild(child) != null)
                {
                    Expression lastChild = NextChild(child).FirstChild();
                    if (lastChild != null)
                    {
                        Caret.Instance.ExpressionSide = ExpressionSide.Left;
                        return lastChild;
                    }
                    return NextChild(child); // leave Left
                }
                else
                {
                    //Caret.Instance.ExpressionSide = ExpressionSide.Left;
                    Expression tmp;
                    if (ParentExpression != null && (tmp = ParentExpression.MoveRight(this, false)) != null)
                        return tmp;
                }
            }
            else // Right
            {
                // jump in from right
                if (jumpIn && FirstChild() != null)
                {
                    return FirstChild(); // leave right
                }

                if (child != null && NextChild(child) != null)
                {
                    return NextChild(child); // leave right
                }
                else
                {
                    Caret.Instance.ExpressionSide = ExpressionSide.Right;
                    return child;
                }
            }
            return LastChild();
        }
        
    }
}
