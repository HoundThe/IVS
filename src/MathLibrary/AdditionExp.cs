using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    class AdditionExp : IExpression
    {
        private IExpression addend1;
        private IExpression addend2;

        public AdditionExp(IExpression addend1, IExpression addend2)
        {
            this.addend1 = addend1;
            this.addend2 = addend2;
        }

        public double Evaluate()
        {
            return addend1.Evaluate() + addend2.Evaluate();
        }
    }
}
