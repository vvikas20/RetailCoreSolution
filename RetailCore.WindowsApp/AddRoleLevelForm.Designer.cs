namespace RetailCore.WindowsApp
{
    partial class AddRoleLevelForm
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
			tbxRoleLevelID = new TextBox();
			label4 = new Label();
			tbxRoleLevelDName = new TextBox();
			label3 = new Label();
			btnSave = new Button();
			textBoxRoleLevelName = new TextBox();
			label2 = new Label();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 147F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tbxRoleLevelID, 1, 0);
			tableLayoutPanel1.Controls.Add(label4, 0, 0);
			tableLayoutPanel1.Controls.Add(tbxRoleLevelDName, 1, 2);
			tableLayoutPanel1.Controls.Add(label3, 0, 2);
			tableLayoutPanel1.Controls.Add(btnSave, 1, 3);
			tableLayoutPanel1.Controls.Add(textBoxRoleLevelName, 1, 1);
			tableLayoutPanel1.Controls.Add(label2, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 4;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel1.Size = new Size(377, 114);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tbxRoleLevelID
			// 
			tbxRoleLevelID.Dock = DockStyle.Fill;
			tbxRoleLevelID.Location = new Point(150, 3);
			tbxRoleLevelID.Name = "tbxRoleLevelID";
			tbxRoleLevelID.ReadOnly = true;
			tbxRoleLevelID.Size = new Size(224, 23);
			tbxRoleLevelID.TabIndex = 7;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.Lavender;
			label4.Dock = DockStyle.Fill;
			label4.Location = new Point(3, 0);
			label4.Name = "label4";
			label4.Size = new Size(141, 28);
			label4.TabIndex = 2;
			label4.Text = "Role Level";
			label4.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// tbxRoleLevelDName
			// 
			tbxRoleLevelDName.Dock = DockStyle.Fill;
			tbxRoleLevelDName.Location = new Point(150, 59);
			tbxRoleLevelDName.Name = "tbxRoleLevelDName";
			tbxRoleLevelDName.Size = new Size(224, 23);
			tbxRoleLevelDName.TabIndex = 5;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.BackColor = Color.Lavender;
			label3.Dock = DockStyle.Fill;
			label3.Location = new Point(3, 56);
			label3.Name = "label3";
			label3.Size = new Size(141, 28);
			label3.TabIndex = 3;
			label3.Text = "Role Level Display Name";
			label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(150, 87);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// textBoxRoleLevelName
			// 
			textBoxRoleLevelName.Dock = DockStyle.Fill;
			textBoxRoleLevelName.Location = new Point(150, 31);
			textBoxRoleLevelName.Name = "textBoxRoleLevelName";
			textBoxRoleLevelName.Size = new Size(224, 23);
			textBoxRoleLevelName.TabIndex = 4;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.Lavender;
			label2.Dock = DockStyle.Fill;
			label2.Location = new Point(3, 28);
			label2.Name = "label2";
			label2.Size = new Size(141, 28);
			label2.TabIndex = 2;
			label2.Text = "Role Level Name";
			label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// AddRoleLevelForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(377, 114);
			Controls.Add(tableLayoutPanel1);
			Name = "AddRoleLevelForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Role Level";
			FormClosing += AddRoleForm_FormClosing;
			Load += AddRoleForm_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private TextBox tbxRoleLevelID;
        private Label label4;
        private TextBox tbxRoleLevelDName;
        private Button btnSave;
        private TextBox textBoxRoleLevelName;
    }
}