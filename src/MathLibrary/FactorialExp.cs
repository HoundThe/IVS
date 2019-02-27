using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    class FactorialExp : IExpression
    {
        private IExpression number;
        private double result;

        /// <summary>
        /// Takes number and calculate it's factorial
        /// </summary>
        /// <param name="number"></param>
        public FactorialExp(IExpression number)
        {
            this.number = number;
        }


        /// <summary>
        /// Calculate factorial
        /// </summary>
        /// <returns>Factorial of the inputed number</returns>
        public double Evaluate()
        {
            //ToDo
            return result;
        }



    }
}
