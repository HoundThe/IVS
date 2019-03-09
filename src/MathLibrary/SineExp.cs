/************************************************************
 *      ROZSIVAL MICHAL                                     *
 *      IVS - project 2                                     *
 *      FEB/MAR 2019                                        *
 *      Testing class for MathLibrary                       *
 *      Version 1.0                                         *
 ************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class SineExp : TrigonoValues, IExpression
    {
        private SimplifyArgument sim;
        private IExpression argument;
        private double simplifiedArgument;
        private const int iteration = 20; //number of iteration to compute sin value.
        private double result = 0;
        private Difference dif1;
        private Difference dif2;


        /// <summary>
        /// Constructor inicializing argument
        /// </summary>
        /// <param name="argument"></param>
        public SineExp(IExpression argument)
        {
            this.argument = argument;
        }

        /// <summary>
        /// Computing the value of sin(argument) using continued fraction
        /// </summary>
        private void Sin()
        {
            if (BaseValue())
            {
                return;
            }
            double argumentToTwo = simplifiedArgument * simplifiedArgument;

            for (int i = iteration - 1; i > 1; i--)
            {
                result = ((2 * i - 2) * (2 * i - 1) * argumentToTwo) / ((2 * i) * (2 * i + 1) - argumentToTwo + result);
            }
            result = 1 + (argumentToTwo) / (2 * 3 - argumentToTwo + result);
            result = simplifiedArgument / result;
            return;
        }

        /// <summary>
        /// Method calculating sin value of simplified argument
        /// </summary>
        /// <returns>Sin value of argument</returns>
        public double Evaluate()
        {
            sim = new SimplifyArgument(argument.Evaluate());
            simplifiedArgument = sim.SimplifyOfTwoPi();
            Sin();
            return result;
        }

        /// <summary>
        /// Method testing if argument is one of the base values
        /// </summary>
        public bool BaseValue()
        {
            dif1 = new Difference(simplifiedArgument, -Pi);
            dif2 = new Difference(simplifiedArgument, Pi);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = 0; return true; }

            dif1 = new Difference(simplifiedArgument, -FivePiDivSix);
            dif2 = new Difference(simplifiedArgument, -PiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -OneDivTwo; return true; }

            dif1 = new Difference(simplifiedArgument, -ThreePiDivFour);
            dif2 = new Difference(simplifiedArgument, -PiDivFour);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -SqrtTwoDivTwo; return true; }

            dif1 = new Difference(simplifiedArgument, -FourPiDivSix);
            dif2 = new Difference(simplifiedArgument, -TwoPiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -SqrtThreeDivTwo; return true; }

            dif1 = new Difference(simplifiedArgument, PiDivSix);
            dif2 = new Difference(simplifiedArgument, FivePiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = OneDivTwo; return true; }

            dif2 = new Difference(simplifiedArgument, PiDivFour);
            dif1 = new Difference(simplifiedArgument, ThreePiDivFour);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = SqrtTwoDivTwo; return true; }

            dif1 = new Difference(simplifiedArgument, TwoPiDivSix);
            dif2 = new Difference(simplifiedArgument, FourPiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = SqrtThreeDivTwo; return true; }

            dif1 = new Difference(simplifiedArgument, -PiDivTwo);
            if (dif1.IsAlmostSame()) { result = -One; return true; }

            dif1 = new Difference(simplifiedArgument, 0);
            if (dif1.IsAlmostSame()) { result = 0; return true; }

            dif1 = new Difference(simplifiedArgument, PiDivTwo);
            if (dif1.IsAlmostSame()) { result = One; return true; }

            return false;
        }
    }
}
