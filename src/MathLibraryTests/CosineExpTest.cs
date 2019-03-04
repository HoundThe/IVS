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
        private SineExp sineExp;
        private Difference dif;

        [TestMethod]
        public void InputEightPiDivSix()
        {
            sineExp = new SineExp(new Number(EightPiDivSix));
            dif = new Difference((-OneDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputElevenPiDivSix()
        {
            sineExp = new SineExp(new Number(ElevenPiDivSix));
            dif = new Difference((SqrtThreeDivTwo), sineExp.Evaluate());
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
            sineExp = new SineExp(new Number(FivePiDivFour));
            dif = new Difference((-SqrtThreeDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputFourPiDivSix()
        {
            sineExp = new SineExp(new Number(FourPiDivSix));
            dif = new Difference((-OneDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPi()
        {
            sineExp = new SineExp(new Number(Pi));
            dif = new Difference((-Zero), sineExp.Evaluate());
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
            dif = new Difference((SqrtThreeDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputPiDivTwo()
        {
            sineExp = new SineExp(new Number(PiDivTwo));
            dif = new Difference((Zero), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivFour()
        {
            sineExp = new SineExp(new Number(SevenPiDivFour));
            dif = new Difference(((SqrtTwoDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputSevenPiDivSix()
        {
            sineExp = new SineExp(new Number(SevenPiDivSix));
            dif = new Difference(((SqrtThreeDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTenPiDivSix()
        {
            sineExp = new SineExp(new Number(TenPiDivSix));
            dif = new Difference(((OneDivTwo)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivFour()
        {
            sineExp = new SineExp(new Number(ThreePiDivFour));
            dif = new Difference((-SqrtTwoDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputThreePiDivTwo()
        {
            sineExp = new SineExp(new Number(ThreePiDivTwo));
            dif = new Difference(((Zero)), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputTwoPiDivSix()
        {
            sineExp = new SineExp(new Number(TwoPiDivSix));
            dif = new Difference((OneDivTwo), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void InputZero()
        {
            sineExp = new SineExp(new Number(Zero));
            dif = new Difference((One), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }

        [TestMethod]
        public void RandomValues()
        {
            sineExp = new SineExp(new Number(-98525.254));
            dif = new Difference((0.19474203566574637949), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(0.25234));
            dif = new Difference((0.96833084428709851447), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(1.6374323));
            dif = new Difference((-0.06658666961288881538), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(7.26461));
            dif = new Difference((0.55583877821731371201), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());

            sineExp = new SineExp(new Number(65436.5543565));
            dif = new Difference((-0.94892830297897895851), sineExp.Evaluate());
            Assert.IsTrue(dif.IsAlmostSame());
        }
    }
}
