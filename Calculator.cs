using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Yuksel Karaimin
//F113794

namespace Calculator
{
    public enum Operator
    {
        None,
        Add,
        Subtract,
        Multiply,
        Divide
    }
    public class Calculator
    {
        private double storedValue;        // запомнена стойност
        private double currentValue;       // текущо въведено число
        private Operator currentOperator;  // избрана операция
        private bool isNewEntry = true;    // дали започваме ново число

        public string Display = "0";       // това се показва на дисплея

        // Въвеждане на цифра
        public void EnterDigit(char digit)
        {
            if (isNewEntry || Display == "0")
            {
                Display = digit.ToString();
                isNewEntry = false;
            }
            else
            {
                Display += digit;
            }
        }

        //въвеждане на десетична точка
        public void EnterDecimalSeparator()
        {
            if (isNewEntry)
            {
                Display = "0,";
                isNewEntry = false;
            }
            else if (!Display.Contains("."))
            {
                Display += ",";
            }
        }

        // Задаване на оператор (+ - * /)
        public void SetOperator(Operator op)
        {
            currentValue = double.Parse(Display);

            if (currentOperator == Operator.None)
            {
                storedValue = currentValue;
            }
            else
            {
                CalculateResult();
            }

            currentOperator = op;
            isNewEntry = true;
        }

        //изчисляване на резултата

        public void CalculateResult()
        {
            currentValue = double.Parse(Display);
            double result = storedValue;

            if (currentOperator == Operator.Add)
                result = storedValue + currentValue;
            else if (currentOperator == Operator.Subtract)
                result = storedValue - currentValue;
            else if (currentOperator == Operator.Multiply)
                result = storedValue * currentValue;
            else if (currentOperator == Operator.Divide)
            {
                if (currentValue == 0)
                {
                    Display = "Error";
                    currentOperator = Operator.None;
                    isNewEntry = true;
                    return;
                }
                result = storedValue / currentValue;
            }

            Display = result.ToString();
            storedValue = result;

            currentOperator = Operator.None;
            isNewEntry = true;
        }

        // CE - изчистване на текущото число
        public void ClearEntry()
        {
            Display = "0";
            isNewEntry = true;
        }

        // C - нулиране на всичко
        public void ClearAll()
        {
            Display = "0";
            storedValue = 0;
            currentValue = 0;
            currentOperator = Operator.None;
            isNewEntry = true;
        }

        // +/- - смяна на знака
        public void ToggleSign()
        {
            double value = double.Parse(Display);
            value = -value;
            Display = value.ToString();
        }

    }
}
