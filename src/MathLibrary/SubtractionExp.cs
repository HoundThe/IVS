using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    class SubtractionExp : IExpression
    {
        private IExpression minuend;
        private IExpression subtrahend;

        /// <summary>
        /// Takes two number and return their difference in order (Minuend - Subtrahend)
        /// </summary>
        /// <param name="a">Minuend</param>
        /// <param name="b">Subtrahend</param>
        public SubtractionExp(IExpression minuend, IExpression subtrahend)
        {
            this.minuend = minuend;
            this.subtrahend = minuend;
        }

        public double Evaluate()
        {
            return minuend.Evaluate() - subtrahend.Evaluate();
        }
    }
}
