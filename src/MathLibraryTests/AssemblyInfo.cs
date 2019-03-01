using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary.Tests
{
    [TestClass()]
    public class AssemblyInfo
    {
        private AdditionExp additionExp;
        [TestMethod()]
        public void AdditionExpTest()
        {
            number1 = new Number(3);
            number1 = new Number(6);
            additionExp = new AdditionExp(number1, number2);
            Assert.AreEqual(additionExp.Evaluate(), 9);
            Assert.Fail();
        }
    }
}