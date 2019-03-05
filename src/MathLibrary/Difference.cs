﻿using System;
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
        private double difference;                      //actual differecne (abs) bewtween value1 and value2
        private double precission = 0.0000000001;       //setting the procentual tolerance for differnce between value1 and value2 (10^-8%)
        private double tolerance;                       //tolerate-able difference bewtween value1 and value2


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public Difference(double value1, double value2)
        {
            this.value1 = value1;
            this.value2 = value2;
            difference = (value1 > value2 ? (value1 - value2) : (value2 - value1)); //abs(value1 - value2)
            tolerance = precission * value1;
            tolerance = (tolerance < 0 ? -tolerance : tolerance);                   //abs(tolerance)
        }

        /// <summary>
        /// Check the absolut value of difference between 'value1' and 'value2'
        /// </summary>
        /// <returns>true if difference is \< preccision</returns>
        public bool IsAlmostSame()
        {
            if (difference <= tolerance)
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
