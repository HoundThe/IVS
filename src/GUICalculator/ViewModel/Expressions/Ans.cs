using GUICalculator.ViewModel.Expressions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    internal class Ans : TerminalExpression
    {
        private Result result;

        public Ans(Result result)
            : base("AnsExpressionTemplate")
        {
            this.result = result;
        }

        public override string ConvertToString()
        {
            return result.Value.ToString();
        }
    }
}
