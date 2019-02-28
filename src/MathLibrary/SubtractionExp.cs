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
        /// Inicializing the minuend and subtrahend
        /// </summary>
        /// <param name="a">Minuend</param>
        /// <param name="b">Subtrahend</param>
        public SubtractionExp(IExpression minuend, IExpression subtrahend)
        {
            this.minuend = minuend;
            this.subtrahend = minuend;
        }

        /// <summary>
        /// Subtract two number inicialized by Constructor
        /// </summary>
        /// <returns>Difference of Minuend and Subtrahend (in order)</returns>
        public double Evaluate()
        {
            return minuend.Evaluate() - subtrahend.Evaluate();
        }
    }
}
