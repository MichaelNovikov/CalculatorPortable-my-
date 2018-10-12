namespace CalculatorPortable
{
   public class Validator : IValidator
    {
        public string Validation(string str, string symbol)
        {
            if (str.Length >= 10 || symbol == "=")
            {
                return str;
            }

            if (str == "0" || str == "")
            {
                if (symbol == ".")
                {
                    str = "0.";
                }
                else if (symbol == "0")
                {
                    str = "0";
                }
                else
                {
                    str = symbol;
                }
            }
            else if (symbol == ".")
            {
                if (!str.Contains("."))
                    str += symbol;
            }
            else
            {
                str += symbol;
            }
            return str;
        }
    }
}
