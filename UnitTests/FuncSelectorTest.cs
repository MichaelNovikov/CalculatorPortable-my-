using CalculatorPortable;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    class FuncSelectorTest
    {
        private FuncSelector _funcSelector;
        private Mock<ICalculator> _calculatorMock;

        [SetUp]
        public void SetUp()
        {
            _calculatorMock = new Mock<ICalculator>(MockBehavior.Strict);
            _funcSelector = new FuncSelector(_calculatorMock.Object);
        }

        [Test]
        public void CtorTest()
        {
            //When
            var fieldInfo1 = typeof(FuncSelector)
                .GetField("_calculator", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual1 = fieldInfo1.GetValue(_funcSelector);

            //Then
            Assert.AreEqual(_calculatorMock.Object, actual1);
        }

        [Test]
        public void CtorNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => new CalcPresenter(null, null));
        }

        [TestCase("2", "2", "+", "4")]
        public void FuncSelectorPlus_Test(string buf, string disp, string op, string res)
        {
            string display = disp, oper = op;

            _calculatorMock.Setup(c => c.Plus(Convert.ToDecimal(buf), Convert.ToDecimal(disp)))
                           .Returns(Convert.ToDecimal(res));

           var actual = _funcSelector.SelectionRunFunc(disp, buf, op);

            Assert.AreEqual(res, actual);
            _calculatorMock.Verify(c => c.Plus(Convert.ToDecimal(buf), Convert.ToDecimal(disp)), Times.Once);
        }

        [TestCase("5", "1", "-", "4")]
        public void FuncSelectorMinus_Test(string buf, string disp, string op, string res)
        {
            string display = disp, oper = op;

            _calculatorMock.Setup(c => c.Minus(Convert.ToDecimal(buf), Convert.ToDecimal(disp)))
                           .Returns(Convert.ToDecimal(res));

            var actual = _funcSelector.SelectionRunFunc(disp, buf, op);

            Assert.AreEqual(res, actual);
            _calculatorMock.Verify(c => c.Minus(Convert.ToDecimal(buf), Convert.ToDecimal(disp)), Times.Once);
        }

        [TestCase("2", "3", "*", "6")]
        public void FuncSelectorMul_Test(string buf, string disp, string op, string res)
        {
            string display = disp, oper = op;

            _calculatorMock.Setup(c => c.Mul(Convert.ToDecimal(buf), Convert.ToDecimal(disp)))
                           .Returns(Convert.ToDecimal(res));

            var actual = _funcSelector.SelectionRunFunc(disp, buf, op);

            Assert.AreEqual(res, actual);
            _calculatorMock.Verify(c => c.Mul(Convert.ToDecimal(buf), Convert.ToDecimal(disp)), Times.Once);
        }

        [TestCase("6", "3", "/", "2")]
        public void FuncSelectorDiv_Test(string buf, string disp, string op, string res)
        {
            string display = disp, oper = op;

            _calculatorMock.Setup(c => c.Div(Convert.ToDecimal(buf), Convert.ToDecimal(disp)))
                           .Returns(Convert.ToDecimal(res));

            var actual = _funcSelector.SelectionRunFunc(disp, buf, op);

            Assert.AreEqual(res, actual);
            _calculatorMock.Verify(c => c.Div(Convert.ToDecimal(buf), Convert.ToDecimal(disp)), Times.Once);
        }
    }
}
