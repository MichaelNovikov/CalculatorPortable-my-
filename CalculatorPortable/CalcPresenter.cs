using System;
using System.Linq;

namespace CalculatorPortable
{
    public class CalcPresenter
    {
        private IValidator _validator;
        private IFuncSelector _funcSelector;
        private static string[] operators = { "+", "-", "*", "/" };
        private static string buf = "";

        public CalcPresenter(IValidator validator, IFuncSelector funcSelector)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _funcSelector = funcSelector ?? throw new ArgumentNullException(nameof(funcSelector));
        }

        public void Present(ref string display, ref string oper, string symbl)
        {
            if (symbl == "C")
            {
                Clear(ref display, ref oper);
                return;
            }

            if (display.Length >= 1 && operators.Contains(symbl) && buf == "") //Set operator after first operand
            {
                buf = display;
                display = "";
                oper = symbl;
            }
            else if (display == "" && operators.Contains(symbl)) //When next symbol after set operator is operator
            {
                oper = symbl;
            }
            else if ((operators.Contains(symbl) || symbl == "=") && buf != "") //Get result
            {
                if (display == "")
                    display = buf; //Click "=" after choosen buf and operator with empty second operator

                display = _funcSelector.SelectionRunFunc(display, buf, oper);

                buf = oper = "";
                return;
            }
            else
            {
                display = _validator.Validation(display, symbl); //Enter symbol into operand
            }
        }

        private void Clear(ref string disp, ref string oper)
        {
            buf = "";
            disp = "";
            oper = "";
        }
    }
}
