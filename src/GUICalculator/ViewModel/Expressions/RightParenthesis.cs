using GUICalculator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    class RightParenthesis : TerminalExpression
    {
        public RightParenthesis()
            : base("RightParenthesisExpressionTemplate")
        {
            Height = 18;
        }

        protected override void OnParentExpressionSet(Expression parent)
        {
            Expression previousChild = parent.PreviousChild(this);
            if (previousChild == null)
                return;

            Height = previousChild.ActualHeight;
        }
    }
}
