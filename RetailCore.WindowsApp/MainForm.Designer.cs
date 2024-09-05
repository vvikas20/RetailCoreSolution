﻿namespace RetailCore.WindowsApp
{
    partial class MainForm
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
			btnAddRole = new Button();
			dataGridViewRoles = new DataGridView();
			tabControl1 = new TabControl();
			tabPageUsers = new TabPage();
			tableLayoutPanel2 = new TableLayoutPanel();
			dataGridViewUsers = new DataGridView();
			panel1 = new Panel();
			btnAddUser = new Button();
			buttonAddDefaultUser = new Button();
			tabPageRoleLevels = new TabPage();
			tableLayoutPanel4 = new TableLayoutPanel();
			buttonAddRoleLevel = new Button();
			dataGridViewRoleLevels = new DataGridView();
			tabPageRoles = new TabPage();
			tabPageMyProfile = new TabPage();
			tableLayoutPanel5 = new TableLayoutPanel();
			checkBox2 = new CheckBox();
			checkBox1 = new CheckBox();
			textBoxUserId = new TextBox();
			textBoxModifiedDate = new TextBox();
			textBoxModifiedBy = new TextBox();
			textBoxCreatedDate = new TextBox();
			textBoxCreatedBy = new TextBox();
			textBoxEmail = new TextBox();
			textBoxLName = new TextBox();
			textBoxMName = new TextBox();
			textBoxFName = new TextBox();
			textBoxUsername = new TextBox();
			label1 = new Label();
			label12 = new Label();
			label11 = new Label();
			label10 = new Label();
			label9 = new Label();
			label8 = new Label();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			tableLayoutPanel3 = new TableLayoutPanel();
			button2 = new Button();
			tabPage4 = new TabPage();
			label13 = new Label();
			textBoxRole = new TextBox();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewRoles).BeginInit();
			tabControl1.SuspendLayout();
			tabPageUsers.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
			panel1.SuspendLayout();
			tabPageRoleLevels.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewRoleLevels).BeginInit();
			tabPageRoles.SuspendLayout();
			tabPageMyProfile.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(btnAddRole, 0, 0);
			tableLayoutPanel1.Controls.Add(dataGridViewRoles, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.93269253F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.06731F));
			tableLayoutPanel1.Size = new Size(786, 416);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// btnAddRole
			// 
			btnAddRole.Location = new Point(3, 3);
			btnAddRole.Name = "btnAddRole";
			btnAddRole.Size = new Size(75, 27);
			btnAddRole.TabIndex = 1;
			btnAddRole.Text = "Add Role";
			btnAddRole.UseVisualStyleBackColor = true;
			btnAddRole.Click += btnAddRole_Click;
			// 
			// dataGridViewRoles
			// 
			dataGridViewRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewRoles.Dock = DockStyle.Fill;
			dataGridViewRoles.Location = new Point(3, 36);
			dataGridViewRoles.Name = "dataGridViewRoles";
			dataGridViewRoles.Size = new Size(780, 377);
			dataGridViewRoles.TabIndex = 0;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPageUsers);
			tabControl1.Controls.Add(tabPageRoleLevels);
			tabControl1.Controls.Add(tabPageRoles);
			tabControl1.Controls.Add(tabPageMyProfile);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(800, 450);
			tabControl1.TabIndex = 1;
			// 
			// tabPageUsers
			// 
			tabPageUsers.Controls.Add(tableLayoutPanel2);
			tabPageUsers.Location = new Point(4, 24);
			tabPageUsers.Name = "tabPageUsers";
			tabPageUsers.Padding = new Padding(3);
			tabPageUsers.Size = new Size(792, 422);
			tabPageUsers.TabIndex = 1;
			tabPageUsers.Text = "Manage Users";
			tabPageUsers.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(dataGridViewUsers, 0, 1);
			tableLayoutPanel2.Controls.Add(panel1, 0, 0);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10.0961542F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 89.90385F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel2.Size = new Size(786, 416);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// dataGridViewUsers
			// 
			dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewUsers.Dock = DockStyle.Fill;
			dataGridViewUsers.Location = new Point(3, 45);
			dataGridViewUsers.Name = "dataGridViewUsers";
			dataGridViewUsers.Size = new Size(780, 368);
			dataGridViewUsers.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.Controls.Add(btnAddUser);
			panel1.Controls.Add(buttonAddDefaultUser);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(780, 36);
			panel1.TabIndex = 1;
			// 
			// btnAddUser
			// 
			btnAddUser.Location = new Point(144, 6);
			btnAddUser.Name = "btnAddUser";
			btnAddUser.Size = new Size(75, 27);
			btnAddUser.TabIndex = 3;
			btnAddUser.Text = "Add User";
			btnAddUser.UseVisualStyleBackColor = true;
			btnAddUser.Click += btnAddUser_Click;
			// 
			// buttonAddDefaultUser
			// 
			buttonAddDefaultUser.Location = new Point(3, 7);
			buttonAddDefaultUser.Name = "buttonAddDefaultUser";
			buttonAddDefaultUser.Size = new Size(135, 27);
			buttonAddDefaultUser.TabIndex = 2;
			buttonAddDefaultUser.Text = "Add Default User";
			buttonAddDefaultUser.UseVisualStyleBackColor = true;
			buttonAddDefaultUser.Click += buttonAddDefaultUser_Click;
			// 
			// tabPageRoleLevels
			// 
			tabPageRoleLevels.Controls.Add(tableLayoutPanel4);
			tabPageRoleLevels.Location = new Point(4, 24);
			tabPageRoleLevels.Name = "tabPageRoleLevels";
			tabPageRoleLevels.Padding = new Padding(3);
			tabPageRoleLevels.Size = new Size(792, 422);
			tabPageRoleLevels.TabIndex = 2;
			tabPageRoleLevels.Text = "Manage Role Levels";
			tabPageRoleLevels.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 1;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel4.Controls.Add(buttonAddRoleLevel, 0, 0);
			tableLayoutPanel4.Controls.Add(dataGridViewRoleLevels, 0, 1);
			tableLayoutPanel4.Dock = DockStyle.Fill;
			tableLayoutPanel4.Location = new Point(3, 3);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 2;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 7.93269253F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 92.06731F));
			tableLayoutPanel4.Size = new Size(786, 416);
			tableLayoutPanel4.TabIndex = 1;
			// 
			// buttonAddRoleLevel
			// 
			buttonAddRoleLevel.Location = new Point(3, 3);
			buttonAddRoleLevel.Name = "buttonAddRoleLevel";
			buttonAddRoleLevel.Size = new Size(158, 27);
			buttonAddRoleLevel.TabIndex = 1;
			buttonAddRoleLevel.Text = "Add Role Level";
			buttonAddRoleLevel.UseVisualStyleBackColor = true;
			buttonAddRoleLevel.Click += buttonAddRoleLevel_Click;
			// 
			// dataGridViewRoleLevels
			// 
			dataGridViewRoleLevels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewRoleLevels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewRoleLevels.Dock = DockStyle.Fill;
			dataGridViewRoleLevels.Location = new Point(3, 36);
			dataGridViewRoleLevels.Name = "dataGridViewRoleLevels";
			dataGridViewRoleLevels.Size = new Size(780, 377);
			dataGridViewRoleLevels.TabIndex = 0;
			// 
			// tabPageRoles
			// 
			tabPageRoles.Controls.Add(tableLayoutPanel1);
			tabPageRoles.Location = new Point(4, 24);
			tabPageRoles.Name = "tabPageRoles";
			tabPageRoles.Padding = new Padding(3);
			tabPageRoles.Size = new Size(792, 422);
			tabPageRoles.TabIndex = 0;
			tabPageRoles.Text = "Manage Roles";
			tabPageRoles.UseVisualStyleBackColor = true;
			// 
			// tabPageMyProfile
			// 
			tabPageMyProfile.Controls.Add(tableLayoutPanel5);
			tabPageMyProfile.Location = new Point(4, 24);
			tabPageMyProfile.Name = "tabPageMyProfile";
			tabPageMyProfile.Size = new Size(792, 422);
			tabPageMyProfile.TabIndex = 3;
			tabPageMyProfile.Text = "My Profile";
			tabPageMyProfile.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.BackColor = SystemColors.GradientInactiveCaption;
			tableLayoutPanel5.ColumnCount = 2;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8512F));
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.1487961F));
			tableLayoutPanel5.Controls.Add(textBoxRole, 1, 1);
			tableLayoutPanel5.Controls.Add(label13, 0, 1);
			tableLayoutPanel5.Controls.Add(checkBox2, 1, 7);
			tableLayoutPanel5.Controls.Add(checkBox1, 1, 6);
			tableLayoutPanel5.Controls.Add(textBoxUserId, 1, 12);
			tableLayoutPanel5.Controls.Add(textBoxModifiedDate, 1, 11);
			tableLayoutPanel5.Controls.Add(textBoxModifiedBy, 1, 10);
			tableLayoutPanel5.Controls.Add(textBoxCreatedDate, 1, 9);
			tableLayoutPanel5.Controls.Add(textBoxCreatedBy, 1, 8);
			tableLayoutPanel5.Controls.Add(textBoxEmail, 1, 5);
			tableLayoutPanel5.Controls.Add(textBoxLName, 1, 4);
			tableLayoutPanel5.Controls.Add(textBoxMName, 1, 3);
			tableLayoutPanel5.Controls.Add(textBoxFName, 1, 2);
			tableLayoutPanel5.Controls.Add(textBoxUsername, 1, 0);
			tableLayoutPanel5.Controls.Add(label1, 0, 0);
			tableLayoutPanel5.Controls.Add(label12, 0, 12);
			tableLayoutPanel5.Controls.Add(label11, 0, 11);
			tableLayoutPanel5.Controls.Add(label10, 0, 10);
			tableLayoutPanel5.Controls.Add(label9, 0, 9);
			tableLayoutPanel5.Controls.Add(label8, 0, 8);
			tableLayoutPanel5.Controls.Add(label7, 0, 7);
			tableLayoutPanel5.Controls.Add(label6, 0, 6);
			tableLayoutPanel5.Controls.Add(label5, 0, 5);
			tableLayoutPanel5.Controls.Add(label4, 0, 4);
			tableLayoutPanel5.Controls.Add(label3, 0, 3);
			tableLayoutPanel5.Controls.Add(label2, 0, 2);
			tableLayoutPanel5.Location = new Point(8, 3);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 13;
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.68946648F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69254351F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel5.Size = new Size(457, 411);
			tableLayoutPanel5.TabIndex = 0;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Enabled = false;
			checkBox2.Location = new Point(111, 220);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(15, 14);
			checkBox2.TabIndex = 25;
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Enabled = false;
			checkBox1.Location = new Point(111, 189);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(15, 14);
			checkBox1.TabIndex = 1;
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBoxUserId
			// 
			textBoxUserId.Location = new Point(111, 375);
			textBoxUserId.Name = "textBoxUserId";
			textBoxUserId.ReadOnly = true;
			textBoxUserId.Size = new Size(234, 23);
			textBoxUserId.TabIndex = 24;
			// 
			// textBoxModifiedDate
			// 
			textBoxModifiedDate.Location = new Point(111, 344);
			textBoxModifiedDate.Name = "textBoxModifiedDate";
			textBoxModifiedDate.ReadOnly = true;
			textBoxModifiedDate.Size = new Size(234, 23);
			textBoxModifiedDate.TabIndex = 23;
			// 
			// textBoxModifiedBy
			// 
			textBoxModifiedBy.Location = new Point(111, 313);
			textBoxModifiedBy.Name = "textBoxModifiedBy";
			textBoxModifiedBy.ReadOnly = true;
			textBoxModifiedBy.Size = new Size(234, 23);
			textBoxModifiedBy.TabIndex = 22;
			// 
			// textBoxCreatedDate
			// 
			textBoxCreatedDate.Location = new Point(111, 282);
			textBoxCreatedDate.Name = "textBoxCreatedDate";
			textBoxCreatedDate.ReadOnly = true;
			textBoxCreatedDate.Size = new Size(234, 23);
			textBoxCreatedDate.TabIndex = 21;
			// 
			// textBoxCreatedBy
			// 
			textBoxCreatedBy.Location = new Point(111, 251);
			textBoxCreatedBy.Name = "textBoxCreatedBy";
			textBoxCreatedBy.ReadOnly = true;
			textBoxCreatedBy.Size = new Size(234, 23);
			textBoxCreatedBy.TabIndex = 20;
			// 
			// textBoxEmail
			// 
			textBoxEmail.Location = new Point(111, 158);
			textBoxEmail.Name = "textBoxEmail";
			textBoxEmail.ReadOnly = true;
			textBoxEmail.Size = new Size(234, 23);
			textBoxEmail.TabIndex = 17;
			// 
			// textBoxLName
			// 
			textBoxLName.Location = new Point(111, 127);
			textBoxLName.Name = "textBoxLName";
			textBoxLName.ReadOnly = true;
			textBoxLName.Size = new Size(234, 23);
			textBoxLName.TabIndex = 16;
			// 
			// textBoxMName
			// 
			textBoxMName.Location = new Point(111, 96);
			textBoxMName.Name = "textBoxMName";
			textBoxMName.ReadOnly = true;
			textBoxMName.Size = new Size(234, 23);
			textBoxMName.TabIndex = 15;
			// 
			// textBoxFName
			// 
			textBoxFName.Location = new Point(111, 65);
			textBoxFName.Name = "textBoxFName";
			textBoxFName.ReadOnly = true;
			textBoxFName.Size = new Size(234, 23);
			textBoxFName.TabIndex = 14;
			// 
			// textBoxUsername
			// 
			textBoxUsername.Location = new Point(111, 3);
			textBoxUsername.Name = "textBoxUsername";
			textBoxUsername.ReadOnly = true;
			textBoxUsername.Size = new Size(234, 23);
			textBoxUsername.TabIndex = 13;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = DockStyle.Fill;
			label1.Location = new Point(3, 0);
			label1.Name = "label1";
			label1.Size = new Size(102, 31);
			label1.TabIndex = 1;
			label1.Text = "Username";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Dock = DockStyle.Fill;
			label12.Location = new Point(3, 372);
			label12.Name = "label12";
			label12.Size = new Size(102, 39);
			label12.TabIndex = 12;
			label12.Text = "User Id";
			label12.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Dock = DockStyle.Fill;
			label11.Location = new Point(3, 341);
			label11.Name = "label11";
			label11.Size = new Size(102, 31);
			label11.TabIndex = 11;
			label11.Text = "Modified Date";
			label11.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Dock = DockStyle.Fill;
			label10.Location = new Point(3, 310);
			label10.Name = "label10";
			label10.Size = new Size(102, 31);
			label10.TabIndex = 10;
			label10.Text = "Modified By";
			label10.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Dock = DockStyle.Fill;
			label9.Location = new Point(3, 279);
			label9.Name = "label9";
			label9.Size = new Size(102, 31);
			label9.TabIndex = 9;
			label9.Text = "Created Date";
			label9.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Dock = DockStyle.Fill;
			label8.Location = new Point(3, 248);
			label8.Name = "label8";
			label8.Size = new Size(102, 31);
			label8.TabIndex = 8;
			label8.Text = "Created By";
			label8.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Dock = DockStyle.Fill;
			label7.Location = new Point(3, 217);
			label7.Name = "label7";
			label7.Size = new Size(102, 31);
			label7.TabIndex = 7;
			label7.Text = "Is Active";
			label7.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Dock = DockStyle.Fill;
			label6.Location = new Point(3, 186);
			label6.Name = "label6";
			label6.Size = new Size(102, 31);
			label6.TabIndex = 6;
			label6.Text = "Verified";
			label6.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Dock = DockStyle.Fill;
			label5.Location = new Point(3, 155);
			label5.Name = "label5";
			label5.Size = new Size(102, 31);
			label5.TabIndex = 5;
			label5.Text = "Email";
			label5.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Dock = DockStyle.Fill;
			label4.Location = new Point(3, 124);
			label4.Name = "label4";
			label4.Size = new Size(102, 31);
			label4.TabIndex = 4;
			label4.Text = "Last Name";
			label4.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Dock = DockStyle.Fill;
			label3.Location = new Point(3, 93);
			label3.Name = "label3";
			label3.Size = new Size(102, 31);
			label3.TabIndex = 3;
			label3.Text = "Middle Name";
			label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.Location = new Point(3, 62);
			label2.Name = "label2";
			label2.Size = new Size(102, 31);
			label2.TabIndex = 2;
			label2.Text = "First Name";
			label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(button2, 0, 0);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(0, 0);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.Size = new Size(200, 100);
			tableLayoutPanel3.TabIndex = 0;
			// 
			// button2
			// 
			button2.Location = new Point(3, 3);
			button2.Name = "button2";
			button2.Size = new Size(75, 27);
			button2.TabIndex = 1;
			button2.Text = "Add Role";
			button2.UseVisualStyleBackColor = true;
			button2.Click += btnAddRole_Click;
			// 
			// tabPage4
			// 
			tabPage4.Location = new Point(0, 0);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new Size(200, 100);
			tabPage4.TabIndex = 0;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Dock = DockStyle.Fill;
			label13.Location = new Point(3, 31);
			label13.Name = "label13";
			label13.Size = new Size(102, 31);
			label13.TabIndex = 1;
			label13.Text = "Role";
			label13.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// textBoxRole
			// 
			textBoxRole.Location = new Point(111, 34);
			textBoxRole.Name = "textBoxRole";
			textBoxRole.ReadOnly = true;
			textBoxRole.Size = new Size(234, 23);
			textBoxRole.TabIndex = 1;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(tabControl1);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MainForm";
			Load += MainForm_Load;
			tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewRoles).EndInit();
			tabControl1.ResumeLayout(false);
			tabPageUsers.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
			panel1.ResumeLayout(false);
			tabPageRoleLevels.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewRoleLevels).EndInit();
			tabPageRoles.ResumeLayout(false);
			tabPageMyProfile.ResumeLayout(false);
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel5.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
        private Button btnAddRole;
        private DataGridView dataGridViewRoles;
		private TabControl tabControl1;
		private TabPage tabPageRoles;
		private TabPage tabPageUsers;
		private TableLayoutPanel tableLayoutPanel2;
		private DataGridView dataGridViewUsers;
		private Panel panel1;
		private Button buttonAddDefaultUser;
		private Button btnAddUser;
		private TabPage tabPageRoleLevels;
		private TableLayoutPanel tableLayoutPanel4;
		private Button buttonAddRoleLevel;
		private DataGridView dataGridViewRoleLevels;
		private TableLayoutPanel tableLayoutPanel3;
		private Button button2;
		private TabPage tabPage4;
		private TabPage tabPageMyProfile;
		private TableLayoutPanel tableLayoutPanel5;
		private TextBox textBoxUserId;
		private TextBox textBoxModifiedDate;
		private TextBox textBoxModifiedBy;
		private TextBox textBoxCreatedDate;
		private TextBox textBoxCreatedBy;
		private TextBox textBoxEmail;
		private TextBox textBoxLName;
		private TextBox textBoxMName;
		private TextBox textBoxFName;
		private TextBox textBoxUsername;
		private Label label1;
		private Label label12;
		private Label label11;
		private Label label10;
		private Label label9;
		private Label label8;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private CheckBox checkBox2;
		private CheckBox checkBox1;
		private TextBox textBoxRole;
		private Label label13;
	}
}