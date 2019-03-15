using GUICalculator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel.Expressions
{
    class Power : Expression
    {
        public Power() 
            : base("PowerExpressionTemplate")
        {
        }

        public override Expression AddAuxiliary()
        {
            throw new NotImplementedException();
        }

        public override void AddExpression(Expression activeExpression, Expression expressionToBeAdded)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteChild(Expression child)
        {
            throw new NotImplementedException();
        }

        public override Expression FirstChild()
        {
            throw new NotImplementedException();
        }

        public override Expression LastChild()
        {
            throw new NotImplementedException();
        }

        public override Expression NextChild(Expression currentChild)
        {
            throw new NotImplementedException();
        }

        public override Expression PreviousChild(Expression currentChild)
        {
            throw new NotImplementedException();
        }
    }
}
