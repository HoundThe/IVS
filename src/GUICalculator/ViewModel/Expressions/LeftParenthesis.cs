using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUICalculator.View;

namespace GUICalculator.ViewModel.Expressions
{
    class LeftParenthesis : TerminalExpression
    {
        public LeftParenthesis() 
            : base("LeftParenthesisExpressionTemplate")
        {
            Height = 18;
        }

        protected override void OnParentExpressionSet(Expression parent)
        {
            Expression nextChild = parent.NextChild(this);
            if (nextChild == null)
                return;
            
            Height = nextChild.ActualHeight;
        }
    }
}
