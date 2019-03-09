/************************************************************
 *      ROZSIVAL MICHAL                                     *
 *      IVS - project 2                                     *
 *      FEB/MAR 2019                                        *
 *      Class of the MathLibary                             *
 *      Version 1.0                                         *
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class CosineExp : TrigonoValues, IExpression
    {
        private IExpression argument;

        /// <summary>
        /// Inicializing the argument
        /// </summary>
        /// <param name="value"></param>
        public CosineExp(IExpression argument)
        {
            this.argument = argument;
        }

        /// <summary>
        /// Calculate cosine of inputed value in radians using sin function
        /// cos(x) = sin(x+pi/2)
        /// </summary>
        /// <returns>Cosine of value</returns>
        public double Evaluate()
        {
            SineExp sin = new SineExp(new Number(argument.Evaluate() + PiDivTwo));
            return sin.Evaluate();
        }
    }
}
