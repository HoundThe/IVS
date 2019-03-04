using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class DivisionExp : IExpression
    {
        private IExpression divident;
        private IExpression divisor;

        /// <summary>
        /// Initializing the divident and divisor
        /// </summary>
        /// <param name="divident"></param>
        /// <param name="divisor"></param>
        public DivisionExp(IExpression divident, IExpression divisor)
        {
            
            this.divident = divident;
            this.divisor = divisor;
        }

        /// <summary>
        /// Divide two numbers initialized by constructor
        /// </summary>
        /// <returns>Quotient of two numbers (in order) or throw exception if zero division is tried</returns>
        public double Evaluate()
        {
            if (divisor.Evaluate() == 0)
            {
                throw new ArgumentException("Can't devide by zero!");
            } 
            return (divident.Evaluate() / divisor.Evaluate());
        }
    }
}
