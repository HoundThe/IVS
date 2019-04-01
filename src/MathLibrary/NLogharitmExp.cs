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
    /// <summary>
    /// Class implementing logharitm computing algorithm
    /// </summary>
    public class NLogharitmExp :IExpression
    {
        private IExpression argument;

        /// <summary>
        /// Initializing the argument of logharitm
        /// </summary>
        /// <param name="argument"></param>
        public NLogharitmExp(IExpression argument)
        {
            this.argument = argument;
        }

        /// <summary>
        /// Evaulate natural logharitm of argument
        /// </summary>
        /// <returns>Natural logharitm of argument or throw error in case of wrong argument</returns>
        public double Evaluate()
        {
            if (argument.Evaluate() <= 0)
            {
                throw new ArgumentException("Argument of logharitm has to be greater than zero!");
            }

            return -1;

        }
    }
}
