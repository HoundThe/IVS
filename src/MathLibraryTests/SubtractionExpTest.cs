using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MathLibrary;

namespace MathLibraryTests
{
    /// <summary>
    /// Class containing methods for DivisionExp class' Evaulate method testing
    /// </summary>
    [TestClass]
    public class SubtractionExpTest : Values
    {
        protected SubtractionExp subExp;

        /// <summary>
        /// List of doubles, containg results for difference (in order) of number from number set(s) on same index, gonna be filled in method deppending on test need
        /// </summary>
        protected List<double> results;


        /// <summary>
        /// Method testing the difference of two differen number from two numbers sets (input1, input2 - in this order) on same index
        /// </summary>
        [TestMethod]
        public void TwoDifferentNumbers()
        {
            Assert.AreEqual(input1.Count, input2.Count);
            results = new List<double>() { -996.60, -268.94, -237.21, -269.50, -407.87, -340.00, 3608.10, -381.35, 727.00, 978.00 };
            Assert.AreEqual(input1.Count, results.Count);
            for(int i = 0; i < results.Count; i++)
            {
                subExp = new SubtractionExp(new Number(input1[i]), new Number(input2[i]));
                Assert.AreEqual(subExp.Evaluate(), results[i]);
            };
        }

        /// <summary>
        /// Method testing the differnce of two same number from one numbers set (input1) on same index
        /// </summary>
        [TestMethod]
        public void TwoSameNumbers()
        {
            for (int i = 0; i < input1.Count; i++)
            {
                subExp = new SubtractionExp(new Number(input1[i]), new Number(input1[i]));
                Assert.AreEqual(subExp.Evaluate(), 0.0);
            }
        }

        [TestMethod]
        public void TwoOppositeNumbers()
        {
            results = new List<double>() { -1998.00, -512.00, -526.40, -471.00, -305.74, 4.00, 104.00, 26.00, 1964.00, 2006.00 };
            Assert.AreEqual(input1.Count, results.Count);
           for(int i = 0; i < results.Count; i++)
            {
                subExp = new SubtractionExp(new Number(input1[i]), new Number(-(input1[i])));
                Assert.AreEqual(subExp.Evaluate(), results[i]);
            }
        }

        /// <summary>
        /// Method testing the differce of one number from one testing numbers set (input 1, then input 2) and zero and differce of zeroes 
        /// </summary>
        [TestMethod]
        public void DifferenceWithZero()
        {
            //---Testing two zeroes
            subExp = new SubtractionExp(new Number(0.0), new Number(0.0));
            Assert.AreEqual(subExp.Evaluate(), 0);

            //---Testing zero as first argument
            for(int i = 0; i < input1.Count; i++)
            {
                subExp = new SubtractionExp(new Number(0.0), new Number(input1[i]));
                Assert.AreEqual(subExp.Evaluate(), (-input1[i]));
            }

            //---Testing zero as second argument
            for(int i = 0; i < input2.Count; i++)
            {
                subExp = new SubtractionExp(new Number(input2[i]), new Number(0.0));
                Assert.AreEqual(subExp.Evaluate(), input2[i]);
            }

        }
    }
}
