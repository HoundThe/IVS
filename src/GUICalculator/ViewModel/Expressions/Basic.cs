using GUICalculator.ViewModel.Expressions.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUICalculator.View
{
    class Basic : SingleExpression
    {

        public Basic()
            : base("BasicExpressionTemplate")
        {
        }
        
        public override Expression MoveLeft(Expression child, bool jumpIn)
        {
            // Makes sure the caret remains inside the Base expression 
            // on the left side of the first child.
            if (Caret.Instance.ExpressionSide == ExpressionSide.Left)
            {
                if (child != null && PreviousChild(child) == null)
                    return FirstChild();
            }
            return base.MoveLeft(child, jumpIn);
        }

        public override Expression MoveRight(Expression child, bool jumpIn)
        {
            // Makes sure the caret remains inside the Base expression 
            // on the right side of the right child.
            if (Caret.Instance.ExpressionSide == ExpressionSide.Right)
            {
                if (child != null && NextChild(child) == null)
                    return LastChild();
            }
            return base.MoveRight(child, jumpIn);
        }

        public override string ConvertToString()
        {
            StringBuilder sb = new StringBuilder("(");
            foreach (Expression expression in Items)
                sb.Append(expression.ConvertToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}
