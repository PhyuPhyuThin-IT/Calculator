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
        private string num1 = "";
        private string num2 = "";
        private string operation = "";
        private Boolean isFirstNum = true;

        public string Num1
        {
            get { return num1; }
            set
            {
                num1 = AddComma(value);
            }
        }

        public Calculator()
        {
            InitializeComponent();
        }

        //Comma Button
        private string AddComma(string number)
        {
            if (long.TryParse(number, out long num))
            {
                return num.ToString("N0");
            }
            else
            {
                return number;
            }
        }

        //Numbers Button
        public void btnNumbers_Click(object sender, EventArgs e)
        {
            string numbers = (sender as Button).Text;
            if (isFirstNum)
            {
                Num1 += numbers;
                txtBoxResult.Text = Num1;
            }
            else
            {
                num2 += numbers;
                txtBoxResult.Text = Num1 + operation + AddComma(num2);
            }
        }

        //Decimal(.) Button
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (isFirstNum)
            {
                if (!Num1.Contains("."))
                {
                    if (string.IsNullOrEmpty(Num1)) Num1 = "0";
                    Num1 += ".";
                    txtBoxResult.Text = Num1;
                }
            }
            else
            {
                if (!num2.Contains("."))
                {
                    if (string.IsNullOrEmpty(num2)) num2 = "0";
                    num2 += ".";
                    txtBoxResult.Text = Num1 + operation + AddComma(num2);
                }
            }
        }

        //Operators Button
        public void btnOperators_Click(object sender, EventArgs e)
        {
            operation = (sender as Button).Text;
            txtBoxResult.Text = Num1 + operation;
            isFirstNum = false;
        }

        //Equal Button
        private void btnEqualSign_Click(object sender, EventArgs e)
        {
            double result = 0;

            if (string.IsNullOrEmpty(Num1) && string.IsNullOrEmpty(num2))
            {
                txtBoxResult.Text = "Invalid input\nClick C to restart";
            }

            else if (string.IsNullOrEmpty(Num1))
            {
                txtBoxResult.Text = "Need Num1\nClick C to restart";
            }

            else if (string.IsNullOrEmpty(operation) || string.IsNullOrEmpty(num2))
            {
                txtBoxResult.Text = Num1;
            }


            else
            {
                try
                {
                    double firstNum = double.Parse(Num1);
                    double secondNum = double.Parse(AddComma(num2));


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
                                txtBoxResult.Text = AddComma(txtBoxResult.Text);
                            }
                            break;
                        case "%":
                            result = firstNum % secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = AddComma(txtBoxResult.Text);
                            break;
                        case "x":
                            result = firstNum * secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = AddComma(txtBoxResult.Text);
                            break;
                        case "-":
                            result = firstNum - secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = AddComma(txtBoxResult.Text);
                            break;
                        case "+":
                            result = firstNum + secondNum;
                            txtBoxResult.Text = result.ToString();
                            txtBoxResult.Text = AddComma(txtBoxResult.Text);
                            break;
                    }
                    Num1 = result.ToString();
                    num2 = "";
                    operation = "";
                    txtBoxResult.Text = Num1;
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
            Num1 = "";
            operation = "";
            num2 = "";
            isFirstNum = true;
        }
    }
}
