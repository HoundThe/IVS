using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTests
{
    /// <summary>
    /// Auxiliary class which control the aprox equality of two numbers
    /// </summary>
    public class Difference
    {

        private double value1;
        private double value2;
        private double precission = 1e-15;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public Difference(double value1, double value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        /// <summary>
        /// Check the absoilut value of difference between 'value1' and 'value2'
        /// </summary>
        /// <returns>true if difference is \< preccision</returns>
        public bool IsAlmostSame()
        {
            double difference = value1 - value2;
            difference = (difference < 0 ? -difference : difference);
            if (difference < precission)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
