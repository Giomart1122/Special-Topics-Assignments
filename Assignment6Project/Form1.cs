using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Assignment6Project
{
    public partial class Form1 : Form
    {
    private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            textBoxInput.Text = GenerateStrongPassword();
        }

    private string GenerateStrongPassword()
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            Random random = new Random();
            char[] password = new char[12];
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            return new string(password);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInput.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            EvaluatePasswordStrength(textBoxInput.Text);
        }

        private void buttonCheckPassword_Click(object sender, EventArgs e)
        {
            string password = textBoxInput.Text;
            EvaluatePasswordStrength(password);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EvaluatePasswordStrength(string password)
        {
            if (password.Length >= 6)
                listBoxCriteria.Items[0] = "✔️ At least 6 characters";
            else
                listBoxCriteria.Items[0] = "• At least 6 characters";

            if (Regex.IsMatch(password, @"\d"))
                listBoxCriteria.Items[1] = "✔️ Includes numbers";
            else
                listBoxCriteria.Items[1] = "• Includes numbers";

            if (Regex.IsMatch(password, @"[\W_]"))
                listBoxCriteria.Items[2] = "✔️ Includes symbols";
            else
                listBoxCriteria.Items[2] = "• Includes symbols";

            // Color feedback on strength
            if (string.IsNullOrWhiteSpace(password))
            {
                statusLabel.Text = "Please enter a password.";
                statusLabel.ForeColor = System.Drawing.Color.Black;
            }
            else if (password.Length < 6)
            {
                statusLabel.Text = "Weak Password: Too short!";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$"))
            {
                statusLabel.Text = "Moderate Password: Letters and numbers.";
                statusLabel.ForeColor = System.Drawing.Color.Goldenrod;
            }
            else if (Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[\W_]).+$"))
            {
                statusLabel.Text = "Strong Password: Letters, numbers, and symbols!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Password strength unclear.";
                statusLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

    }
}
