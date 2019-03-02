using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
using System.Collections.Generic;

namespace MathLibraryTests
{

    /// <summary>
    /// Class containing methods for AdditionExp class' Evaulate method testing
    /// </summary>
    [TestClass]
    public class AdditionExpTest : Values
    {
        protected AdditionExp addExp;

        /// <summary>
        /// List of doubles, containg results for sum of number from number set(s) on same index, gonna be filled in method deppending on test need
        /// </summary>
        protected List<double> results;

        /// <summary>
        /// Method testing the sum of two differen number from two numbers sets (input1, input2) on same index
        /// </summary>
        [TestMethod]
        public void TwoDifferentNumbers()
        {
            Assert.AreEqual(input1.Count, input2.Count);
            results = new List<double> { -1001.40, -243.06, -289.19, -201.50, 102.13, 344.00, -3504.10, 407.35, 1237.00, 1028.00 };
            Assert.AreEqual(input1.Count, results.Count);

            for (int i = 0; i < results.Count; i++)
            {
                addExp = new AdditionExp(new Number(input1[i]), new Number(input2[i]));
                Assert.AreEqual(addExp.Evaluate(), results[i]);
            }

        }

        /// <summary>
        /// Method testing the sum of two same number from one numbers set (input1) on same index
        /// </summary>
        [TestMethod]
        public void TwoSameNumbers()
        {
            results = new List<double>() { -1998.0, -512.0, -526.4, -471.0, -305.74, 4.0, 104.0, 26.0, 1964.0, 2006.0 };
            Assert.AreEqual(results.Count, input1.Count);
            for (int i = 0; i < results.Count; i++)
            {
                addExp = new AdditionExp(new Number(input1[i]), new Number(input1[i]));
                Assert.AreEqual(addExp.Evaluate(), (results[i]));
            }
        }

        /// <summary>
        /// Method testing the sum of two opposite numbers
        /// </summary>
        [TestMethod]
        public void TwoOppositeNumbers()
        {
            for (int i = 0; i < input1.Count; i++)
            {
                addExp = new AdditionExp(new Number(input1[i]), new Number(-(input1[i])));
                Assert.AreEqual(addExp.Evaluate(), 0.0);
            }
        }

        /// <summary>
        /// Method testing the sum of one number from one testing numbers set (input 1, then input 2) and zero and sum of zeroes 
        /// </summary>
        [TestMethod]

        public void SumWithZero()
        {
            //---Testing two zeroes
            addExp = new AdditionExp(new Number(0.0), new Number(0.0));
            Assert.AreEqual(addExp.Evaluate(), 0.0);

            //---Testing zero as first argument
            for (int i = 0; i < input1.Count; i++)
            {
                addExp = new AdditionExp(new Number(0), new Number(input1[i]));
                Assert.AreEqual(addExp.Evaluate(), input1[i]);
            }

            //---Testing zero as second argument
            for (int i = 0; i < input1.Count; i++)
            {
                addExp = new AdditionExp(new Number(input2[i]), new Number(0));
                Assert.AreEqual(addExp.Evaluate(), input2[i]);
            }



        }
    }

}
