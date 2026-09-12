using System;
using System.Windows.Forms;

namespace SimpleCalc
{
    public partial class SimpleCalc2 : Form
    {
        public SimpleCalc2()
        {
            InitializeComponent();

            this.AcceptButton = btnCalculate;
            this.CancelButton = btnExit;

            txtOperand1.TextChanged += TextBox_TextChanged;
            txtOperator.TextChanged += TextBox_TextChanged;
            txtOperand2.TextChanged += TextBox_TextChanged;
        }

        private decimal Calculate(decimal operand1, string operator1, decimal operand2)
        {
            switch (operator1)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                default:
                    return 0;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                string operator1 = txtOperator.Text;
                decimal operand2 = Convert.ToDecimal(txtOperand2.Text);

                decimal result = Calculate(operand1, operator1, operand2);

                txtResult.Text = result.ToString("F4");

                txtOperand1.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter numeric values for the operands.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "The number entered is too large or too small.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show(
                    "You cannot divide by zero.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error message: " + ex.Message,
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimpleCalc2_Load(object sender, EventArgs e)
        {

        }

    }
}
