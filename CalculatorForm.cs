using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Yuksel Karaimin
//F113794

namespace Calculator
{
    public partial class CalculatorForm : System.Windows.Forms.Form
    {
        private Calculator calculator; //логика на калкулатора
        public CalculatorForm()
        {
            InitializeComponent();

            calculator = new Calculator();
            txtDisplay.Text = calculator.Display;

            // общ обработчик за цифрите
            btn0.Click += Digit_Click;
            btn1.Click += Digit_Click;
            btn2.Click += Digit_Click;
            btn3.Click += Digit_Click;
            btn4.Click += Digit_Click;
            btn5.Click += Digit_Click;
            btn6.Click += Digit_Click;
            btn7.Click += Digit_Click;
            btn8.Click += Digit_Click;
            btn9.Click += Digit_Click;

            // оператори
            btnAdd.Click += (s, e) => Operator_Click(Operator.Add);
            btnSub.Click += (s, e) => Operator_Click(Operator.Subtract);
            btnMul.Click += (s, e) => Operator_Click(Operator.Multiply);
            btnDiv.Click += (s, e) => Operator_Click(Operator.Divide);

            // други бутони
            btnDecimal.Click += Decimal_Click;
            btnEquals.Click += Equals_Click;
            btnClear.Click += Clear_Click;
            btnClearEntry.Click += ClearEntry_Click;
            btnSign.Click += Sign_Click;
        }

        //цифри
        private void Digit_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            char digit = b.Text[0];
            calculator.EnterDigit(digit);
            txtDisplay.Text = calculator.Display;
        }

        //оператор
        private void Operator_Click(Operator op)
        {
            calculator.SetOperator(op);
            txtDisplay.Text = calculator.Display;
        }

        //десетичен реазделител
        private void Decimal_Click(object sender, EventArgs e)
        {
            calculator.EnterDecimalSeparator();
            txtDisplay.Text = calculator.Display;
        }

        // =
        private void Equals_Click(object sender, EventArgs e)
        {
            calculator.CalculateResult();
            txtDisplay.Text = calculator.Display;
        }

        // C
        private void Clear_Click(object sender, EventArgs e)
        {
            calculator.ClearAll();
            txtDisplay.Text = calculator.Display;
        }

        // CE
        private void ClearEntry_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
            txtDisplay.Text = calculator.Display;
        }

        // +/-
        private void Sign_Click(object sender, EventArgs e)
        {
            calculator.ToggleSign();
            txtDisplay.Text = calculator.Display;
        }
    }
}
