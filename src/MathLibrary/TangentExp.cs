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
    public class TangentExp : TrigonoValues, IExpression
    {

        private double result = 0;
        private IExpression argument;
        private double simplifiedArgument;
        private Difference dif1;
        private Difference dif2;
        private SimplifyArgument sim;
        private int iteration = 20;

        /// <summary>
        /// Constructor inicializin argument
        /// </summary>
        /// <param name="argument"></param>
        public TangentExp(IExpression argument)
        {
            this.argument = argument;
        }


        /// <summary>
        /// Computing the tan of the simplified argument using continued fraction
        /// </summary>
        private void Tan()
        {
            double argumentToTwo = simplifiedArgument * simplifiedArgument;
            for (int i = iteration; i > 0; i--)
            {
                result = (argumentToTwo / ((i * 2 + 1) - result));
            }
            result = simplifiedArgument / (1 - result);
            return;
        }

        /// <summary>
        /// Calculate tan of simplified argument using the continued fraction
        /// </summary>
        /// <returns>tan value of argument or throw exception if case of wrong argument</returns>
        public double Evaluate()
        {
            sim = new SimplifyArgument(argument.Evaluate());
            simplifiedArgument = sim.SimplifyOfTwoPi();
            if (!BaseValue()) 
            {
                Tan();
            }
            return result;
        }

        /// <summary>
        /// Method testing if argument is one of the base values
        /// </summary>
        /// <returns></returns>
        private bool BaseValue()
        {
            dif1 = new Difference(simplifiedArgument, -Pi);
            dif2 = new Difference(simplifiedArgument, Pi);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = 0; return true; }

            dif1 = new Difference(simplifiedArgument, -FivePiDivSix);
            dif2 = new Difference(simplifiedArgument, PiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = SqrtThreeDivThree; return true; }

            dif1 = new Difference(simplifiedArgument, -ThreePiDivFour);
            dif2 = new Difference(simplifiedArgument, PiDivFour);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = 1; return true; }

            dif1 = new Difference(simplifiedArgument, -FourPiDivSix);
            dif2 = new Difference(simplifiedArgument, TwoPiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = SqrtThree; return true; }

            dif1 = new Difference(simplifiedArgument, -TwoPiDivSix);
            dif2 = new Difference(simplifiedArgument, FourPiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -SqrtThree; return true; }

            dif2 = new Difference(simplifiedArgument, -PiDivFour);
            dif1 = new Difference(simplifiedArgument, ThreePiDivFour);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -1; return true; }

            dif1 = new Difference(simplifiedArgument, -PiDivSix);
            dif2 = new Difference(simplifiedArgument, FivePiDivSix);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -SqrtThreeDivThree; return true; }

            dif1 = new Difference(simplifiedArgument, 0);
            if (dif1.IsAlmostSame()) { result = 0; return true; }

            dif1 = new Difference(simplifiedArgument, -PiDivTwo);
            dif2 = new Difference(simplifiedArgument, PiDivTwo);
            if (dif1.IsAlmostSame() || dif2.IsAlmostSame()) { result = -One; throw new ArgumentException("Wrong argument of tan(x) function!"); }

            return false;

        }


    }
}
