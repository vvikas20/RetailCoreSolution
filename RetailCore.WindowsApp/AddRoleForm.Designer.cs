namespace RetailCore.WindowsApp
{
    partial class AddRoleForm
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
            tbxRoleID = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            cbxRoleLevel = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            btnSave = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label5 = new Label();
            checkedListBoxPermission = new CheckedListBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tbxRoleID, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 3);
            tableLayoutPanel1.Controls.Add(cbxRoleLevel, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 5);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(checkedListBoxPermission, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(372, 442);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tbxRoleID
            // 
            tbxRoleID.Dock = DockStyle.Fill;
            tbxRoleID.Location = new Point(123, 3);
            tbxRoleID.Name = "tbxRoleID";
            tbxRoleID.ReadOnly = true;
            tbxRoleID.Size = new Size(246, 23);
            tbxRoleID.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Lavender;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
            label4.TabIndex = 2;
            label4.Text = "Role ID";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(123, 93);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(246, 23);
            textBox2.TabIndex = 3;
            // 
            // cbxRoleLevel
            // 
            cbxRoleLevel.Dock = DockStyle.Fill;
            cbxRoleLevel.FormattingEnabled = true;
            cbxRoleLevel.Location = new Point(123, 33);
            cbxRoleLevel.Name = "cbxRoleLevel";
            cbxRoleLevel.Size = new Size(246, 23);
            cbxRoleLevel.TabIndex = 1;
            cbxRoleLevel.SelectedIndexChanged += cbxRoleLevel_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Lavender;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 90);
            label3.Name = "label3";
            label3.Size = new Size(114, 30);
            label3.TabIndex = 3;
            label3.Text = "Role Display Name";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Lavender;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 30);
            label1.Name = "label1";
            label1.Size = new Size(114, 30);
            label1.TabIndex = 1;
            label1.Text = "Role Level";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(123, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(246, 24);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(123, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(246, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Lavender;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 60);
            label2.Name = "label2";
            label2.Size = new Size(114, 30);
            label2.TabIndex = 2;
            label2.Text = "Role Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Lavender;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 120);
            label5.Name = "label5";
            label5.Size = new Size(114, 292);
            label5.TabIndex = 8;
            label5.Text = "Role Permissions";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkedListBoxPermission
            // 
            checkedListBoxPermission.Dock = DockStyle.Fill;
            checkedListBoxPermission.FormattingEnabled = true;
            checkedListBoxPermission.Location = new Point(123, 123);
            checkedListBoxPermission.Name = "checkedListBoxPermission";
            checkedListBoxPermission.Size = new Size(246, 286);
            checkedListBoxPermission.TabIndex = 4;
            // 
            // AddRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 442);
            Controls.Add(tableLayoutPanel1);
            Name = "AddRoleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Role ";
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
        private TextBox textBox1;
        private Label label5;
        private CheckedListBox checkedListBoxPermission;
    }
}