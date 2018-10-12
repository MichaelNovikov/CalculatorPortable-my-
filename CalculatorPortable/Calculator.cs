using System;

namespace CalculatorPortable
{
    public class Calculator : ICalculator 
    {
        public decimal Plus(decimal oper1, decimal oper2)
        {
            return oper1 + oper2;
        }

        public decimal Minus(decimal oper1, decimal oper2)
        {
            return oper1 - oper2;
        }

        public decimal Mul(decimal oper1, decimal oper2)
        {
            return oper1 * oper2;
        }

        public decimal Div(decimal oper1, decimal oper2)
        {
            if (oper2.Equals(0))
                throw new DivideByZeroException();
            return oper1 / oper2;
        }
    }
}
