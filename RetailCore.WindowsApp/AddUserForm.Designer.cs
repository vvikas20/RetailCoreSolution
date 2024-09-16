namespace RetailCore.WindowsApp
{
    partial class AddUserForm
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
            checkBoxVerified = new CheckBox();
            tbxUsername = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            cbxRole = new ComboBox();
            label2 = new Label();
            tbxFirstName = new TextBox();
            label5 = new Label();
            label6 = new Label();
            tbxMName = new TextBox();
            tbxLName = new TextBox();
            tbxEmail = new TextBox();
            label7 = new Label();
            tbxPassword = new TextBox();
            btnSave = new Button();
            label8 = new Label();
            label9 = new Label();
            checkBoxActive = new CheckBox();
            label10 = new Label();
            textBoxUserId = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(checkBoxVerified, 1, 9);
            tableLayoutPanel1.Controls.Add(tbxUsername, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 6);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(cbxRole, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(tbxFirstName, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(tbxMName, 1, 4);
            tableLayoutPanel1.Controls.Add(tbxLName, 1, 5);
            tableLayoutPanel1.Controls.Add(tbxEmail, 1, 6);
            tableLayoutPanel1.Controls.Add(label7, 0, 7);
            tableLayoutPanel1.Controls.Add(tbxPassword, 1, 7);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 10);
            tableLayoutPanel1.Controls.Add(label8, 0, 8);
            tableLayoutPanel1.Controls.Add(label9, 0, 9);
            tableLayoutPanel1.Controls.Add(checkBoxActive, 1, 8);
            tableLayoutPanel1.Controls.Add(label10, 0, 0);
            tableLayoutPanel1.Controls.Add(textBoxUserId, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Size = new Size(329, 273);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxVerified
            // 
            checkBoxVerified.AutoSize = true;
            checkBoxVerified.Dock = DockStyle.Fill;
            checkBoxVerified.Location = new Point(123, 219);
            checkBoxVerified.Name = "checkBoxVerified";
            checkBoxVerified.Size = new Size(203, 18);
            checkBoxVerified.TabIndex = 9;
            checkBoxVerified.UseVisualStyleBackColor = true;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(123, 27);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(203, 23);
            tbxUsername.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Lavender;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 24);
            label4.Name = "label4";
            label4.Size = new Size(114, 24);
            label4.TabIndex = 2;
            label4.Text = "Username";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Lavender;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 144);
            label3.Name = "label3";
            label3.Size = new Size(114, 24);
            label3.TabIndex = 3;
            label3.Text = "Email";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Lavender;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 48);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 1;
            label1.Text = "Role";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbxRole
            // 
            cbxRole.Dock = DockStyle.Fill;
            cbxRole.FormattingEnabled = true;
            cbxRole.Location = new Point(123, 51);
            cbxRole.Name = "cbxRole";
            cbxRole.Size = new Size(203, 23);
            cbxRole.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Lavender;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 72);
            label2.Name = "label2";
            label2.Size = new Size(114, 24);
            label2.TabIndex = 2;
            label2.Text = "First Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxFirstName
            // 
            tbxFirstName.Dock = DockStyle.Fill;
            tbxFirstName.Location = new Point(123, 75);
            tbxFirstName.Name = "tbxFirstName";
            tbxFirstName.Size = new Size(203, 23);
            tbxFirstName.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Lavender;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 96);
            label5.Name = "label5";
            label5.Size = new Size(114, 24);
            label5.TabIndex = 8;
            label5.Text = "Middle Name";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Lavender;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 120);
            label6.Name = "label6";
            label6.Size = new Size(114, 24);
            label6.TabIndex = 9;
            label6.Text = "Last Name";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxMName
            // 
            tbxMName.Dock = DockStyle.Fill;
            tbxMName.Location = new Point(123, 99);
            tbxMName.Name = "tbxMName";
            tbxMName.Size = new Size(203, 23);
            tbxMName.TabIndex = 4;
            // 
            // tbxLName
            // 
            tbxLName.Dock = DockStyle.Fill;
            tbxLName.Location = new Point(123, 123);
            tbxLName.Name = "tbxLName";
            tbxLName.Size = new Size(203, 23);
            tbxLName.TabIndex = 5;
            // 
            // tbxEmail
            // 
            tbxEmail.Dock = DockStyle.Fill;
            tbxEmail.Location = new Point(123, 147);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.Size = new Size(203, 23);
            tbxEmail.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Lavender;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 168);
            label7.Name = "label7";
            label7.Size = new Size(114, 24);
            label7.TabIndex = 12;
            label7.Text = "Password";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxPassword
            // 
            tbxPassword.Dock = DockStyle.Fill;
            tbxPassword.Location = new Point(123, 171);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(203, 23);
            tbxPassword.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(123, 243);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Lavender;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(3, 192);
            label8.Name = "label8";
            label8.Size = new Size(114, 24);
            label8.TabIndex = 14;
            label8.Text = "Active";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Lavender;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 216);
            label9.Name = "label9";
            label9.Size = new Size(114, 24);
            label9.TabIndex = 15;
            label9.Text = "Verified";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxActive
            // 
            checkBoxActive.AutoSize = true;
            checkBoxActive.Dock = DockStyle.Fill;
            checkBoxActive.Location = new Point(123, 195);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(203, 18);
            checkBoxActive.TabIndex = 8;
            checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Lavender;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(114, 24);
            label10.TabIndex = 18;
            label10.Text = "UserId";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxUserId
            // 
            textBoxUserId.Dock = DockStyle.Fill;
            textBoxUserId.Location = new Point(123, 3);
            textBoxUserId.Name = "textBoxUserId";
            textBoxUserId.ReadOnly = true;
            textBoxUserId.Size = new Size(203, 23);
            textBoxUserId.TabIndex = 0;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 273);
            Controls.Add(tableLayoutPanel1);
            Name = "AddUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User";
            FormClosing += AddRoleForm_FormClosing;
            Load += AddRoleForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbxRole;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox tbxUsername;
        private Label label4;
        private TextBox tbxMName;
        private Button btnSave;
        private TextBox tbxFirstName;
		private Label label5;
		private Label label6;
		private CheckBox checkBoxVerified;
		private TextBox tbxLName;
		private TextBox tbxEmail;
		private Label label7;
		private TextBox tbxPassword;
		private Label label8;
		private Label label9;
		private CheckBox checkBoxActive;
		private Label label10;
		private TextBox textBoxUserId;
	}
}