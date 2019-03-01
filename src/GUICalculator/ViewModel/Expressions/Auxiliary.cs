using GUICalculator.ViewModel.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GUICalculator.View
{
    internal class Auxiliary : TerminalExpression
    {
        public Auxiliary()
            : base("AuxiliaryExpressionTemplate")
        {
        }
        
    }
}
