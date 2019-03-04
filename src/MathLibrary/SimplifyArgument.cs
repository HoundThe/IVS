using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// Due to the periodic behavior of trigonometric function, you can convert high argument to lower one by subtracting the k*period
    /// where 'k' is natural number or zero
    /// </summary>
    class SimplifyArgument
    {
        private double periodPi = 3.141592653589793238462643383279;
        private double periodTwoPi = 6.283185307179586476925286766558;
        private double argument;
        private double argumentSimplified;

        public SimplifyArgument(double argument)
        {
            this.argument = argument;
        }

        public double SimplifyOfPi()
        {
            //TODO
            return argumentSimplified;
        }

        public double SimplifyOfTwoPi()
        {
            //TODO
            return argumentSimplified;

        }



    }
}
