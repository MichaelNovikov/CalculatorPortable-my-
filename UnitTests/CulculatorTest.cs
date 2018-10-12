using CalculatorPortable;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class CulculatorTest
    {
        Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [TestCase(1, 1, 2)]
        [TestCase(0.1, 0.2, 0.3)]
        public void PlusTest(decimal a, decimal b, decimal expected)
        {
           var actually = calculator.Plus(a, b);

            Assert.AreEqual(expected, actually);
        }

        [TestCase(2, 1, 1)] 
        public void MinusTest(decimal a, decimal b, decimal res)
        {
            var result = calculator.Minus(a, b);

            Assert.AreEqual(res, result);
        }

        [TestCase(2, 5, 10)] 
        public void MulTest(decimal a, decimal b, decimal res)
        {
            var result = calculator.Mul(a, b);

            Assert.AreEqual(res, result);
        }

        [TestCase(10, 5, 2)]
        public void DivTest(decimal a, decimal b, decimal res)
        {
            var result = calculator.Div(a, b);

            Assert.AreEqual(res, result);
        }

        [TestCase(10, 0)] //Div by zero
        public void Div_byZeroTest(decimal a, decimal b)
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Div(a, b));
        }
    }
}
