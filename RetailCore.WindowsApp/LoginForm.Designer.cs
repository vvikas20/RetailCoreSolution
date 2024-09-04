namespace RetailCore.WindowsApp
{
    partial class LoginForm
	{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tableLayoutPanel1 = new TableLayoutPanel();
			textBoxPassword = new TextBox();
			label3 = new Label();
			btnSave = new Button();
			textBoxUsername = new TextBox();
			label2 = new Label();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(textBoxPassword, 1, 1);
			tableLayoutPanel1.Controls.Add(label3, 0, 1);
			tableLayoutPanel1.Controls.Add(btnSave, 1, 2);
			tableLayoutPanel1.Controls.Add(textBoxUsername, 1, 0);
			tableLayoutPanel1.Controls.Add(label2, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(329, 88);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// textBoxPassword
			// 
			textBoxPassword.Dock = DockStyle.Fill;
			textBoxPassword.Location = new Point(123, 32);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(203, 23);
			textBoxPassword.TabIndex = 5;
			textBoxPassword.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.Lavender;
			label3.Dock = DockStyle.Fill;
			label3.Location = new Point(3, 29);
			label3.Name = "label3";
			label3.Size = new Size(114, 29);
			label3.TabIndex = 3;
			label3.Text = "Password";
			label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(123, 61);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "Login";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnLogin_Click;
			// 
			// textBoxUsername
			// 
			textBoxUsername.Dock = DockStyle.Fill;
			textBoxUsername.Location = new Point(123, 3);
			textBoxUsername.Name = "textBoxUsername";
			textBoxUsername.Size = new Size(203, 23);
			textBoxUsername.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.Lavender;
			label2.Dock = DockStyle.Fill;
			label2.Location = new Point(3, 0);
			label2.Name = "label2";
			label2.Size = new Size(114, 29);
			label2.TabIndex = 2;
			label2.Text = "Username";
			label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(329, 88);
			Controls.Add(tableLayoutPanel1);
			Name = "LoginForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Login";
			FormClosing += AddRoleForm_FormClosing;
			Load += AddRoleForm_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbxRoleLevel;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox tbxRoleID;
        private Label label4;
        private TextBox textBox2;
        private Button btnSave;
        private TextBox textBoxUsername;
		private TextBox textBoxPassword;

	}
}