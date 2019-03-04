using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

namespace MathLibraryTests
{
    /// <summary>
    /// Class containing methods for SineExp class' Evaulate method testing
    /// Each method name is function input. No exception excepted.
    /// </summary>
    [TestClass]
    public class SineExpTest : TrigonoValues, ITestTrigono
    {
        private SineExp sineExp;
        private Difference dif;

        [TestMethod]
        public void InputEightPiDivSix()
        {
            sineExp = new SineExp(new Number(EightPiDivSix));
            dif = new Difference((-SqrtThreeDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputElevenPiDivSix()
        {
            sineExp = new SineExp(new Number(ElevenPiDivSix));
            dif = new Difference(((-OneDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFivePiDivFour()
        {
            sineExp = new SineExp(new Number(FivePiDivFour));
            dif = new Difference((-SqrtTwoDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFivePiDivSix()
        {
            sineExp = new SineExp(new Number(FivePiDivSix));
            dif = new Difference((OneDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFourPiDivSix()
        {
            sineExp = new SineExp(new Number(FourPiDivSix));
            dif = new Difference((SqrtThreeDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPi()
        {
            sineExp = new SineExp(new Number(Pi));
            dif = new Difference((Zero), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivFour()
        {
            sineExp = new SineExp(new Number(PiDivFour));
            dif = new Difference((SqrtTwoDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivSix()
        {
            sineExp = new SineExp(new Number(PiDivSix));
            dif = new Difference((OneDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivTwo()
        {
            sineExp = new SineExp(new Number(PiDivTwo));
            dif = new Difference((One), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivFour()
        {
            sineExp = new SineExp(new Number(SevenPiDivFour));
            dif = new Difference(((-SqrtTwoDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivSix()
        {
            sineExp = new SineExp(new Number(SevenPiDivSix));
            dif = new Difference(((-OneDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTenPiDivSix()
        {
            sineExp = new SineExp(new Number(TenPiDivSix));
            dif = new Difference(((-SqrtThreeDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivFour()
        {
            sineExp = new SineExp(new Number(ThreePiDivFour));
            dif = new Difference((SqrtTwoDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivTwo()
        {
            sineExp = new SineExp(new Number(ThreePiDivTwo));
            dif = new Difference(((-One)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTwoPiDivSix()
        {
            sineExp = new SineExp(new Number(TwoPiDivSix));
            dif = new Difference((SqrtThreeDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputZero()
        {
            sineExp = new SineExp(new Number(Zero));
            dif = new Difference((Zero), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void RandomValues()
        {
            sineExp = new SineExp(new Number(-363.25334));
            dif = new Difference((0.92129894706128631927), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(1.235));
            dif = new Difference((0.94414820251856255790), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(1.7));
            dif = new Difference((0.99166481045246861534), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(3.0));
            dif = new Difference((0.14112000805986722210), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(25455.35221));
            dif = new Difference((0.82661281223969933138), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }
    }
}
