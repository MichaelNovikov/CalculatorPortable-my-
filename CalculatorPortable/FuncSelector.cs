using System;

namespace CalculatorPortable
{
    public class FuncSelector : IFuncSelector
    {
        private ICalculator _calculator;
        private static decimal op1, op2;

        public FuncSelector(ICalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public string SelectionRunFunc( string display, string buf, string oper)
        {
            op1 = Convert.ToDecimal(buf);
            op2 = Convert.ToDecimal(display);

            switch (oper)
            {
                case "+":
                    display = _calculator.Plus(op1, op2).ToString();
                    break;

                case "-":
                    display = _calculator.Minus(op1, op2).ToString();
                    break;

                case "*":
                    display = _calculator.Mul(op1, op2).ToString();
                    break;

                case "/":
                    {
                        try
                        {
                            display = _calculator.Div(op1, op2).ToString();
                        }
                        catch (Exception ex)
                        {
                            display = ex.Message;
                        }
                    }
                    break;
            }
            return display;
        }
    }
}
