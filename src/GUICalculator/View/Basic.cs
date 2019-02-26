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


        //public override Expression MoveLeft(Expression child, bool jumpIn)
        //{
        //    if (jumpIn && child != null && child.LastChild() != null && 
        //        Caret.Instance.ExpressionSide == ExpressionSide.Right)
        //    {
        //        return child.LastChild();
        //    }

        //    // jump out, caret is on the left
        //    if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
        //    {

        //    }
            
        //    if (child != null && PreviousChild(child) != null)
        //    {
        //        Caret.Instance.ExpressionSide = ExpressionSide.Right;
        //        return PreviousChild(child);
        //    }
        //    else if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
        //    {
        //        Caret.Instance.ExpressionSide = ExpressionSide.Left;
        //        return this;
        //    }

        //    if (ParentExpression != null && ParentExpression.MoveLeft(this, false) != null)
        //        return ParentExpression.MoveLeft(this, false);
        //    return null;
        //}
    }
}
