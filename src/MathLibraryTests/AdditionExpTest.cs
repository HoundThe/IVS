using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
using System.Collections.Generic;

namespace MathLibraryTests
{
   

    /// <summary>
    /// Class containg values for input testing
    /// </summary>
    [TestClass]
    public class AdditionExpTest
    {
        private AdditionExp addExp;
        /// <summary>
        /// List of doubles, containg first random numbers set
        /// </summary>
        private List<double> input1 = new List<double> { -999.0, -256.0, -263.2, -235.5, -152.87, 2.0, 52.0, 13.0, 982.0, 1003.0 };

        /// <summary>
        /// List of doubles, containg second random numbers set
        /// </summary>
        private List<double> input2 = new List<double> { -2.4, 12.94, -25.99, 34.0, 255.0, 342.0, -3556.1, 394.35, 255.0, 25.0 };

        /// <summary>
        /// List of doubles, containg results for sum of number from number set(s) on same index, gonna be filled in method deppending on test need
        /// </summary>
        private List<double> results;
        
        /// <summary>
        /// Method testing the sum of two differen number from two numbers sets (input1, input2) on same index
        /// </summary>
        [TestMethod]
        public void TwoDifferentNumber()
        {
            results = new List<double> { -1001.4, -243.06, -289.19, -201.5, 102.13, 344.0, -3504.1, 407.35, 1237.0, 1028.0 };
            Assert.AreEqual(input1.Count, input2.Count);
            Assert.AreEqual(input1.Count, results.Count);

            for(int i = 0; i < results.Count; i++)
            {
                addExp = new AdditionExp(new Number(input1[i]), new Number(input2[i]));
                Assert.AreEqual(addExp.Evaluate(), results[i]);
            }

        }

        /// <summary>
        /// Method testing the sum of one number from one tesing numbers set (input 1, then input 2) and zero and sum of zeroes 
        /// </summary>
        [TestMethod]

        public void SumWithZero()
        {
            //---Testing two zeroes
            addExp = new AdditionExp(new Number(0.0), new Number(0.0));
            Assert.AreEqual(addExp.Evaluate(), 0.0);

            //---Testing zero as first argument
            for(int i = 0; i < input1.Count; i++)
            {
                addExp = new AdditionExp(new Number(0), new Number(input1[i]));
                Assert.AreEqual(addExp.Evaluate(), input1[i]);
            }

            //---Testing zero as second argument
            for (int i = 0; i < input2.Count; i++)
            {
                addExp = new AdditionExp(new Number(input2[i]), new Number(0));
                Assert.AreEqual(addExp.Evaluate(), input2[i]);
            }



        }

        /// <summary>
        /// Method testing the sum of two same number from one numbers set (input1) on same index
        /// </summary>
        [TestMethod]
        public void TwoSameNumber()
        {
            results = new List<double>() { -1998.0, -512.0, -526.4, -471.0, -305.74, 4.0, 104.0, 26.0, 1964.0, 2006.0 };
            Assert.AreEqual(results.Count, input1.Count);
            for (int i = 0; i < input1.Count; i++)
            {
                addExp = new AdditionExp(new Number(input1[i]), new Number(input1[i]));
                Assert.AreEqual(addExp.Evaluate(), (results[i]));
            }
        }
}
}
