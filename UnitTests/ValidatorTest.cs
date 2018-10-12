using System;
using CalculatorPortable;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class ValidatorTest
    {
        Validator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new Validator();
        }

        [TestCase("0123456789", "10")]
        public void ValidetionTest1(string str, string symbol)
        {
            var actually = validator.Validation(str, symbol);

            Assert.AreEqual(str, actually);
        }

        [TestCase("0", "9", "9")]
        [TestCase("", ".", "0.")]
        [TestCase("0", ".", "0.")]
        [TestCase("0.", ".", "0.")]
        [TestCase("1.123", ".", "1.123")]
        public void ValidetionTest2(string str, string symbol, string expected)
        {
            var actually = validator.Validation(str, symbol);

            Assert.AreEqual(expected, actually);
        }
    }
}
