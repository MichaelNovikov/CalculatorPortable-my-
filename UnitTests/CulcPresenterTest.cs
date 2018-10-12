using CalculatorPortable;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    public class CulcPresenterTest
    {
        private CalcPresenter _calcPresenter;
        private Mock<IValidator> _validatorMock;
        private Mock<IFuncSelector> _funcSelectorMock;

        [SetUp]
        public void SetUp()
        {
            _validatorMock = new Mock<IValidator>(MockBehavior.Strict);
            _funcSelectorMock = new Mock<IFuncSelector>(MockBehavior.Strict);
            _calcPresenter = new CalcPresenter(_validatorMock.Object, _funcSelectorMock.Object);
        }

        [Test]
        public void CtorTest()
        {
            //When
            var fieldInfo1 = typeof(CalcPresenter)
                .GetField("_validator", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual1 = fieldInfo1.GetValue(_calcPresenter);

            var fieldInfo2 = typeof(CalcPresenter)
                .GetField("_funcSelector", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual2 = fieldInfo2.GetValue(_calcPresenter);

            //Then
            Assert.AreEqual(_validatorMock.Object, actual1);
            Assert.AreEqual(_funcSelectorMock.Object, actual2);
        }

        [Test]
        public void CtorNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => new CalcPresenter(null, null));
        }

        [TestCase("10", "10", "+", "C")]
        public void PresentClear_Test(string buf, string disp, string oper, string sign)
        {
            FieldInfo fieldInfo = typeof(CalcPresenter)
                     .GetField("buf", BindingFlags.NonPublic | BindingFlags.Static);
            fieldInfo.SetValue(_calcPresenter, buf);

            _calcPresenter.Present(ref disp, ref oper, sign);

            Assert.AreEqual("", disp);
            Assert.AreEqual("", fieldInfo.GetValue(_calcPresenter));
            Assert.AreEqual("", oper);
        }

        [TestCase("", "10", "", "+")]
        public void PresentIf_SetOperator_Test(string buf, string disp, string oper, string sign)
        {
            FieldInfo fieldInfo = typeof(CalcPresenter)
                     .GetField("buf", BindingFlags.NonPublic | BindingFlags.Static);
            fieldInfo.SetValue(_calcPresenter, buf);

            _calcPresenter.Present(ref disp, ref oper, sign);

            Assert.AreEqual("+", oper);
            Assert.AreEqual("", disp);
            Assert.AreEqual("10", fieldInfo.GetValue(_calcPresenter));
        }

        [TestCase("10", "", "+", "-")]
        public void PresentIf_enterOperAfterSetOperator_Test(string buf, string disp, string oper, string sign)
        {
            FieldInfo fieldInfo = typeof(CalcPresenter)
                     .GetField("buf", BindingFlags.NonPublic | BindingFlags.Static);
            fieldInfo.SetValue(_calcPresenter, buf);

            _calcPresenter.Present(ref disp, ref oper, sign);

            Assert.AreEqual("-", oper);
        }

        [TestCase("10", "", "+", "=", "20")]
        public void PresentIf_equalAfterSetOperatorWithEmptyDisplay_Test(string buf, string disp, string oper, string sign, string res)
        {
            FieldInfo fieldInfo = typeof(CalcPresenter)
                     .GetField("buf", BindingFlags.NonPublic | BindingFlags.Static);
            fieldInfo.SetValue(_calcPresenter, buf);

            _funcSelectorMock.Setup(f => f.SelectionRunFunc(buf, buf, oper)).Returns(res);

            _calcPresenter.Present(ref disp, ref oper, sign);

            Assert.AreEqual("20", disp);

            _funcSelectorMock.Verify(f => f.SelectionRunFunc("10", "10", "+"), Times.Once);
        }

        [TestCase("10", "5", "+", "=", "15")]
        public void PresentIf_equal_Test(string buf, string disp, string oper, string sign, string res)
        {
            FieldInfo fieldInfo = typeof(CalcPresenter)
                     .GetField("buf", BindingFlags.NonPublic | BindingFlags.Static);
            fieldInfo.SetValue(_calcPresenter, buf);

            _funcSelectorMock.Setup(f => f.SelectionRunFunc(disp, buf, oper)).Returns(res);

            _calcPresenter.Present(ref disp, ref oper, sign);

            Assert.AreEqual("15", disp);
            Assert.AreEqual("", fieldInfo.GetValue(_calcPresenter));
            Assert.AreEqual("", oper);

            _funcSelectorMock.Verify(f => f.SelectionRunFunc("5", "10", "+"), Times.Once);
        }

        [TestCase("", ".", "0.")]
        [TestCase("0123456789", "1", "0123456789")]
        [TestCase("0", ".", "0.")]
        [TestCase("0.1", ".", "0.1")]
        public void PresenterElseValidation_Test(string displ, string sign, string result)
        {
            string display = displ, oper = "";
            string aValid = displ;
            string bVAlid = sign;

            _validatorMock.Setup(v => v.Validation(aValid, bVAlid))
                          .Returns(result);

            _calcPresenter.Present(ref display, ref oper, sign);

            Assert.AreEqual(result, display);
            _validatorMock.Verify(v => v.Validation(aValid, bVAlid), Times.Once);
        }
    }
}
