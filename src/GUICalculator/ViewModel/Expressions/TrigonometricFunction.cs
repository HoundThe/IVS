using GUICalculator.View;
using GUICalculator.ViewModel.Expressions.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    class TrigonometricFunction : SingleExpression
    {
        private TrigonometricFunctionType type;

        public TrigonometricFunction(TrigonometricFunctionType type) 
            : base("TrigonometricFunctionExpressionTemplate")
        {
            this.type = type;

            switch (type) {
                case TrigonometricFunctionType.Sine:
                    Value = "sin";
                    break;
                case TrigonometricFunctionType.Cosine:
                    Value = "cos";
                    break;
                case TrigonometricFunctionType.Tangent:
                    Value = "tg";
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
        
        public string Value { get; }

        public override string ConvertToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Value);
            sb.Append("(");
            foreach (Expression expression in Items)
                sb.Append(expression.ConvertToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}
