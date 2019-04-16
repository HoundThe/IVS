using GUICalculator.ViewModel;
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
    internal class SquareRoot : SingleExpression
    {
        public SquareRoot()
            : base("SquareRootExpressionTemplate")
        {
        }
        
        public override string ConvertToString()
        {
            StringBuilder sb = new StringBuilder("(sqrt(");
            foreach (Expression expression in Items)
                sb.Append(expression.ConvertToString());
            sb.Append("))");
            return sb.ToString();
        }
    }
}
