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
    /// Class containing methods for TangentExp class' Evaulate method testing
    /// Each method name is function input.
    /// </summary>
    [TestClass]
    public class TangentExpTest : TrigonoValues, ITestTrigono
    {
        private TangentExp tanExp;
        private Difference dif;

        [TestMethod]
        public void InputEightPiDivSix()
        {
            tanExp = new TangentExp(new Number(EightPiDivSix));
            dif = new Difference((SqrtThree), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputElevenPiDivSix()
        {
            tanExp = new TangentExp(new Number(ElevenPiDivSix));
            dif = new Difference((-SqrtThreeDivThree), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFivePiDivFour()
        {
            tanExp = new TangentExp(new Number(FivePiDivFour));
            dif = new Difference((One), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFivePiDivSix()
        {
            tanExp = new TangentExp(new Number(FivePiDivSix));
            dif = new Difference((-SqrtThreeDivThree), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFourPiDivSix()
        {
            tanExp = new TangentExp(new Number(FourPiDivSix));
            dif = new Difference((-SqrtThree), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPi()
        {
            tanExp = new TangentExp(new Number(Pi));
            dif = new Difference((Zero), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivFour()
        {
            tanExp = new TangentExp(new Number(PiDivFour));
            dif = new Difference((One), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivSix()
        {
            tanExp = new TangentExp(new Number(PiDivSix));
            dif = new Difference((SqrtThreeDivThree), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputPiDivTwo()
        {
            tanExp = new TangentExp(new Number(PiDivTwo));
            tanExp.Evaluate();
        }

        [TestMethod]
        public void InputSevenPiDivFour()
        {
            tanExp = new TangentExp(new Number(SevenPiDivFour));
            dif = new Difference(((-One)), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivSix()
        {
            tanExp = new TangentExp(new Number(SevenPiDivSix));
            dif = new Difference(((SqrtThreeDivThree)), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTenPiDivSix()
        {
            tanExp = new TangentExp(new Number(TenPiDivSix));
            dif = new Difference(((-SqrtThree)), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivFour()
        {
            tanExp = new TangentExp(new Number(ThreePiDivFour));
            dif = new Difference((-One), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputThreePiDivTwo()
        {
            tanExp = new TangentExp(new Number(ThreePiDivTwo));
            tanExp.Evaluate();
        }

        [TestMethod]
        public void InputTwoPiDivSix()
        {
            tanExp = new TangentExp(new Number(TwoPiDivSix));
            dif = new Difference((SqrtThree), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputZero()
        {
            tanExp = new TangentExp(new Number(Zero));
            dif = new Difference((Zero), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void RandomValues()
        {
            tanExp = new TangentExp(new Number(-54352.35334));
            dif = new Difference((0.35504229132005616478), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            tanExp = new TangentExp(new Number(-542.543245222));
            dif = new Difference((1.40515408328025900405), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            tanExp = new TangentExp(new Number(0.654356));
            dif = new Difference((0.76710065850574480764), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            tanExp = new TangentExp(new Number(2.68432));
            dif = new Difference((-0.49205651780050223079), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            tanExp = new TangentExp(new Number(76543.765432123));
            dif = new Difference((-2.17342646776547600425), tanExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }
    }
}
