using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        //Public Declaration
        string num1 = "";
        string num2 = "";
        double firstNum;
        double secondNum;
        double result;
        string operation = "";
        Boolean isFirstNum = true;

        public void Operators(string operators)
        {
            operation = operators;
            txtBoxResult.Text = NumberWithCommas(num1) + operation;
            isFirstNum = false;
        }

        public Calculator()
        {
            InitializeComponent();
        }

        //Comma function
        private string NumberWithCommas(string number)
        {
            try
            {
                if (long.TryParse(number, out long num))
                    return num.ToString("N0");
            }
            catch
            {
                txtBoxResult.Text += "Error";
            }
            return number;
        }

        //Decimal(.)
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                if (!num1.Contains("."))
                {
                    if (string.IsNullOrEmpty(num1)) num1 = "0";
                    num1 += ".";
                    txtBoxResult.Text = NumberWithCommas(num1);
                }
            }
            else
            {
                if (!num2.Contains("."))
                {
                    if (string.IsNullOrEmpty(num2)) num2 = "0";
                    num2 += ".";
                    txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
                }
            }
        }

        //Numbers
        public void btnNo1_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo1.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo1.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        public void btnNo2_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo2.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo2.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo3_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo3.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo3.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo4.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo4.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo5_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo5.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo5.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo6_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo6.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo6.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo7_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo7.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo7.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo8_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo8.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo8.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo9_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo9.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo9.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        private void btnNo0_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                num1 += btnNo0.Text;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += btnNo0.Text;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        //Operators
        public void btnDivided_Click(object sender, EventArgs e)
        {
            Operators("/");
        }

        private void btnRemainder_Click(object sender, EventArgs e)
        {
            Operators("%");
        }

        public void btnMultiply_Click(object sender, EventArgs e)
        {
            Operators("x");
        }

        public void btnSubtract_Click(object sender, EventArgs e)
        {
            Operators("-");
        }

        public void btnAdding_Click(object sender, EventArgs e)
        {
            Operators("+");
        }

        //Equal Sign
        private void btnEqualSign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(num1) && string.IsNullOrEmpty(num2))
            {
                txtBoxResult.Text = "Invalid input\nClick C to restart";
            }

            else if (string.IsNullOrEmpty(num1))
            {
                txtBoxResult.Text = "Need Num1\nClick C to restart";
                return;
            }

            else if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(num2))
            {
                txtBoxResult.Text = NumberWithCommas(num1);
            }

            else
            {
                try
                {
                    firstNum = double.Parse(NumberWithCommas(num1));
                    secondNum = double.Parse(NumberWithCommas(num2));

                    switch (operation)
                    {
                        case "/":
                            if (secondNum == 0)
                            {
                                txtBoxResult.Text = "Cannot divide with Zero";
                            }
                            else
                            {
                                result = firstNum / secondNum;
                                txtBoxResult.Text = result.ToString();
                                txtBoxResult.Text = NumberWithCommas(txtBoxResult.Text);
                            }
                            break;
                        case "%":
                            result = firstNum % secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = NumberWithCommas(txtBoxResult.Text);
                            break;
                        case "x":
                            result = firstNum * secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = NumberWithCommas(txtBoxResult.Text);
                            break;
                        case "-":
                            result = firstNum - secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = NumberWithCommas(txtBoxResult.Text);
                            break;
                        case "+":
                            result = firstNum + secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = NumberWithCommas(txtBoxResult.Text);
                            break;
                    }
                    num1 = result.ToString();
                    num2 = "";
                    operation = "";
                    txtBoxResult.Text = NumberWithCommas(num1);
                }
                catch (OverflowException)
                {
                    txtBoxResult.Text = "Number is too large";
                }
            }
        }

        //Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxResult.Text = "";
            num1 = "";
            operation = "";
            num2 = "";
            isFirstNum = true;
        }
    }
}
