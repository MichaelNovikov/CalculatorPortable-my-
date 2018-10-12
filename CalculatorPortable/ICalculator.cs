namespace CalculatorPortable
{
    public interface ICalculator
    {
        decimal Plus(decimal oper1, decimal oper2);
        decimal Minus(decimal oper1, decimal oper2);
        decimal Mul(decimal oper1, decimal oper2);
        decimal Div(decimal oper1, decimal oper2);
    }
}