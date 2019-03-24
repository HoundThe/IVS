﻿using GUICalculator.ViewModel.Expressions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    class MultiplicationSign : TerminalExpression
    {
        public MultiplicationSign()
            : base("MultiplicationSignExpressionTemplate")
        {
        }

        public override string ConvertToString()
        {
            return "*";
        }
    }
}
