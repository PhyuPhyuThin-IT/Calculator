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

        public Calculator()
        {
            InitializeComponent();
        }

        //Comma Button
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

        //Numbers Button
        private void Numbers(string num)
        {
            if (isFirstNum)
            {
                num1 += num;
                txtBoxResult.Text = NumberWithCommas(num1);
            }
            else
            {
                num2 += num;
                txtBoxResult.Text = NumberWithCommas(num1) + operation + NumberWithCommas(num2);
            }
        }

        public void btnNumbers_Click(object sender, EventArgs e) { 
            string numbers = (sender as Button).Text;
            Numbers(numbers);
        }

        //Decimal(.) Button
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

        //Operators Button
        public void btnOperators_Click(object sender, EventArgs e)
        {
            string operators = (sender as Button).Text;
            Operators(operators);
        }
        private void Operators(string operators)
        {
            operation = operators;
            txtBoxResult.Text = NumberWithCommas(num1) + operation;
            isFirstNum = false;
        }

        //Equal Button
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
