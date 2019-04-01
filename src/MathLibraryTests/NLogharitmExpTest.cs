/************************************************************
 *      ROZSIVAL MICHAL                                     *
 *      IVS - project 2                                     *
 *      MAR/APR 2019                                        *
 *      Testing class for MathLibrary                       *
 *      Version 1.0                                         *
 ************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

/// <summary>
/// Class containing methods for NLogharitm class' Evaulate method testing
/// </summary>
namespace MathLibraryTests
{
    [TestClass]
    public class NLogharitmExpTest
    {
        private NLogharitmExp  lnExp;
        private Difference dif;

        /// <summary>
        /// Domain range of any logharitm is > 0
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ForbiddenInput()
        {
            lnExp = new NLogharitmExp(new Number(-10334.234));
            lnExp = new NLogharitmExp(new Number(-1266.0));
            lnExp = new NLogharitmExp(new Number(-52));
            lnExp = new NLogharitmExp(new Number(-1.34));
            lnExp = new NLogharitmExp(new Number(-0.0000000012));
            lnExp = new NLogharitmExp(new Number(0.0));
        }

        /// <summary>
        /// Testing the log on valid input
        /// </summary>
        [TestMethod]
        public void ValidInput()
        {
            lnExp = new NLogharitmExp(new Number(1.0));
            dif = new Difference(0.0, lnExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());


            lnExp = new NLogharitmExp(new Number(Constants.E));
            dif = new Difference(1.0, lnExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());


            lnExp = new NLogharitmExp(new Number(11.0));
            dif = new Difference(2.39789527279837054406, lnExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            lnExp = new NLogharitmExp(new Number(21.24));
            dif = new Difference(3.05588619637373808420, lnExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            lnExp = new NLogharitmExp(new Number(0.00000012));
            dif = new Difference(-15.93577409416436516191, lnExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            lnExp = new NLogharitmExp(new Number(654324.1622));
            dif = new Difference(13.39135816849633883161, lnExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }




    }
}
