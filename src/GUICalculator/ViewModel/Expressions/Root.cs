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
    internal class Root : TwoExpression
    {
        public Root()
            : base("RootExpressionTemplate")
        {
        }

        public override string ConvertToString()
        {
            StringBuilder sb = new StringBuilder("(");
            foreach (Expression expression in FirstExpression)
                sb.Append(expression.ConvertToString());
            sb.Append(")rt(");
            foreach (Expression expression in SecondExpression)
                sb.Append(expression.ConvertToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}
