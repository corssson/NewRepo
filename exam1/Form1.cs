using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam1
{
    public partial class Form1 : Form
    {
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Единый обработчик для всех кнопок с цифрами
        private void Button_Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txtDisplay.Text == "0" || isOperationPerformed)
            {
                txtDisplay.Clear();
            }

            isOperationPerformed = false;
            txtDisplay.Text = txtDisplay.Text + button.Text;
        }

        // 2. Обработчик для запятой
        private void Button_Comma_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0" || isOperationPerformed)
            {
                txtDisplay.Text = "0,";
                isOperationPerformed = false;
            }
            else if (!txtDisplay.Text.Contains(","))
            {
                txtDisplay.Text = txtDisplay.Text + ",";
            }
        }

        // 3. Кнопки " +, -, *, / "
        private void Button_Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0 && !isOperationPerformed)
            {
                Button_Equal_Click(this, new EventArgs());
            }
            else
            {
                resultValue = double.Parse(txtDisplay.Text);
            }

            operationPerformed = button.Text;
            lblHistory.Text = resultValue + " " + operationPerformed;
            isOperationPerformed = true;
        }

        // 4. Кнопка " = "
        private void Button_Equal_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    if (txtDisplay.Text == "0")
                        MessageBox.Show("Деление на ноль невозможно!");
                    else
                        txtDisplay.Text = (resultValue / double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }

            resultValue = double.Parse(txtDisplay.Text);
            lblHistory.Text = "";
            operationPerformed = "";
            isOperationPerformed = true;
        }

        // 5. Кнопка " С "
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            lblHistory.Text = "";
        }

        // 6. Кнопка " ← "
        private void Button_Backspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0 && !isOperationPerformed)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }

        // 7. Перехват клавиатуры
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                Button_Number_Click(new Button { Text = (e.KeyCode - Keys.D0).ToString() }, e);
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                Button_Number_Click(new Button { Text = (e.KeyCode - Keys.NumPad0).ToString() }, e);
            else if (e.KeyCode == Keys.Add) Button_Operation_Click(new Button { Text = "+" }, e);
            else if (e.KeyCode == Keys.Subtract) Button_Operation_Click(new Button { Text = "-" }, e);
            else if (e.KeyCode == Keys.Multiply) Button_Operation_Click(new Button { Text = "*" }, e);
            else if (e.KeyCode == Keys.Divide) Button_Operation_Click(new Button { Text = "/" }, e);
            else if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal) Button_Comma_Click(this, e);
            else if (e.KeyCode == Keys.Enter) Button_Equal_Click(this, e);
            else if (e.KeyCode == Keys.Back) Button_Backspace_Click(this, e);
            else if (e.KeyCode == Keys.Escape) Button_Clear_Click(this, e);
        }
    }
}
