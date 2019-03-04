using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{

    public class PowerExp : IExpression
    {
        private IExpression mantis;
        private IExpression exponent;

        public PowerExp(IExpression mantis, IExpression exponent)
        {
            this.mantis = mantis;
            this.exponent = exponent;
        }

        public double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}
