/************************************************************
 *      ROZSIVAL MICHAL                                     *
 *      IVS - project 2                                     *
 *      FEB/MAR 2019                                        *
 *      Testing class for MathLibrary                       *
 *      Version 1.0                                         *
 ************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

namespace MathLibraryTests
{
    /// <summary>
    /// Class containing methods for CosineExp class' Evaulate method testing
    /// Each method name is function input. No exception excepted.
    /// </summary>
    [TestClass]
    public class CosineExpTest : TrigonoValues, ITestTrigono
    {
        private CosineExp cosineExp;
        private Difference dif;

        [TestMethod]
        public void InputEightPiDivSix()
        {
            cosineExp = new CosineExp(new Number(EightPiDivSix));
            dif = new Difference((-OneDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputElevenPiDivSix()
        {
            cosineExp = new CosineExp(new Number(ElevenPiDivSix));
            dif = new Difference((SqrtThreeDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFivePiDivFour()
        {
            cosineExp = new CosineExp(new Number(FivePiDivFour));
            dif = new Difference((-SqrtTwoDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFivePiDivSix()
        {
            cosineExp = new CosineExp(new Number(FivePiDivSix));
            dif = new Difference((-SqrtThreeDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFourPiDivSix()
        {
            cosineExp = new CosineExp(new Number(FourPiDivSix));
            dif = new Difference((-OneDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPi()
        {
            cosineExp = new CosineExp(new Number(Pi));
            dif = new Difference((-Zero), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivFour()
        {
            cosineExp = new CosineExp(new Number(PiDivFour));
            dif = new Difference((SqrtTwoDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivSix()
        {
            cosineExp = new CosineExp(new Number(PiDivSix));
            dif = new Difference((SqrtThreeDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivTwo()
        {
            cosineExp = new CosineExp(new Number(PiDivTwo));
            dif = new Difference((Zero), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivFour()
        {
            cosineExp = new CosineExp(new Number(SevenPiDivFour));
            dif = new Difference(((SqrtTwoDivTwo)), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivSix()
        {
            cosineExp = new CosineExp(new Number(SevenPiDivSix));
            dif = new Difference(((SqrtThreeDivTwo)), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTenPiDivSix()
        {
            cosineExp = new CosineExp(new Number(TenPiDivSix));
            dif = new Difference(((OneDivTwo)), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivFour()
        {
            cosineExp = new CosineExp(new Number(ThreePiDivFour));
            dif = new Difference((-SqrtTwoDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivTwo()
        {
            cosineExp = new CosineExp(new Number(ThreePiDivTwo));
            dif = new Difference(((Zero)), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTwoPiDivSix()
        {
            cosineExp = new CosineExp(new Number(TwoPiDivSix));
            dif = new Difference((OneDivTwo), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputZero()
        {
            cosineExp = new CosineExp(new Number(Zero));
            dif = new Difference((One), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void RandomValues()
        {
            cosineExp = new CosineExp(new Number(-98525.254));
            dif = new Difference((0.19474203566574637949), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            cosineExp = new CosineExp(new Number(0.25234));
            dif = new Difference((0.96833084428709851447), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            cosineExp = new CosineExp(new Number(1.6374323));
            dif = new Difference((-0.06658666961288881538), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            cosineExp = new CosineExp(new Number(7.26461));
            dif = new Difference((0.55583877821731371201), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            cosineExp = new CosineExp(new Number(65436.5543565));
            dif = new Difference((-0.94892830297897895851), cosineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }
    }
}
