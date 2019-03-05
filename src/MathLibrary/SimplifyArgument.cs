using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// Taylor series best aproxymate in interval <-pi;pi> with less iterration
    /// Due to the periodic behavior of trigonometric function, you can convert high argument to lower one by subtracting the n*2PI
    /// where 'n' is natural number or zero
    /// </summary>
    public class SimplifyArgument
    {
        private double periodTwoPi = 6.283185307179586476925286766558;
        private double argument;
        private double argumentSimplified;

        public SimplifyArgument(double argument)
        {
            this.argument = argument;
        }

        public double SimplifyOfTwoPi()
        {
            //TODO
            return argumentSimplified;

        }



    }
}
