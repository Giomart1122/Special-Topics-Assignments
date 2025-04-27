namespace Assignment6Project
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label labelPrompt;
        private TextBox textBoxInput;
        private Button buttonCheckPassword;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private CheckBox checkBoxShowPassword;
        private ListBox listBoxCriteria;
        private Button buttonGeneratePassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.labelPrompt = new Label();
            this.textBoxInput = new TextBox();
            this.buttonCheckPassword = new Button();
            this.statusStrip = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();

            // MenuStrip
            this.menuStrip.Items.AddRange(new ToolStripItem[] { this.fileToolStripMenuItem });
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.exitToolStripMenuItem });
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);

            // Label
            this.labelPrompt.Text = "Enter password:";
            this.labelPrompt.Location = new System.Drawing.Point(30, 50);

            // TextBox
            this.textBoxInput.Location = new System.Drawing.Point(150, 50);
            this.textBoxInput.Width = 200;
            this.textBoxInput.TextChanged += new EventHandler(this.textBoxInput_TextChanged);

            // Check pass button
            //this.buttonCheckPassword.Text = "Check Password";
            //this.buttonCheckPassword.Location = new System.Drawing.Point(150, 100);
            //this.buttonCheckPassword.Click += new EventHandler(this.buttonCheckPassword_Click);

            // StatusStrip
            this.statusStrip.Items.Add(this.statusLabel);

            // Form1
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonCheckPassword);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "C# Password Checker and Generator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(400, 300); //size of the app
           
            // Checkbox for Show Password
            this.checkBoxShowPassword = new CheckBox();
            this.checkBoxShowPassword.Text = "Show Password";
            this.checkBoxShowPassword.Location = new System.Drawing.Point(150, 80);
            this.checkBoxShowPassword.CheckedChanged += new EventHandler(this.checkBoxShowPassword_CheckedChanged);

            // ListBox for Criteria
            this.listBoxCriteria = new ListBox();
            this.listBoxCriteria.Location = new System.Drawing.Point(150, 120);
            this.listBoxCriteria.Size = new System.Drawing.Size(200, 80);
            this.listBoxCriteria.Items.Add("• At least 6 characters");
            this.listBoxCriteria.Items.Add("• Includes numbers");
            this.listBoxCriteria.Items.Add("• Includes symbols");

            // Button to Generate Password
            this.buttonGeneratePassword = new Button();
            this.buttonGeneratePassword.Text = "Generate Strong Password";
            this.buttonGeneratePassword.Location = new System.Drawing.Point(150, 210);
            this.buttonGeneratePassword.Click += new EventHandler(this.buttonGeneratePassword_Click);

            // Update controls
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.listBoxCriteria);
            this.Controls.Add(this.buttonGeneratePassword);

        }
    }
}
