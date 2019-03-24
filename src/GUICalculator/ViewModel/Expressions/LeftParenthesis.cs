using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUICalculator.ViewModel.Expressions.Base;

namespace GUICalculator.ViewModel.Expressions
{
    class LeftParenthesis : TerminalExpression
    {
        public LeftParenthesis() 
            : base("LeftParenthesisExpressionTemplate")
        {
            MinHeight = 18;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }
        
        protected override void OnParentExpressionSet(Expression parent)
        {
            //Expression nextChild = parent.NextChild(this);
            //if (nextChild == null)
            //    return;

            //Height = nextChild.ActualHeight;
        }

        public override string ConvertToString()
        {
            return "(";
        }
    }
}
