﻿using GUICalculator.View;
using GUICalculator.ViewModel.Expressions.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    class Fraction : TwoExpression
    {
        public Fraction() 
            : base("FractionExpressionTemplate")
        {
        }

        public override string ConvertToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("((");
            foreach (Expression expression in FirstExpression)
                sb.Append(expression.ConvertToString());
            sb.Append(")/(");
            foreach (Expression expresssion in SecondExpression)
                sb.Append(expresssion.ConvertToString());
            sb.Append("))");
            return sb.ToString();
        }
    }
}
