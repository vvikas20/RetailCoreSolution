namespace RetailCore.WindowsApp
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
            buttonInitializeSystem = new Button();
            tabPageRoleLevels = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            buttonAddRoleLevel = new Button();
            dataGridViewRoleLevels = new DataGridView();
            tabPageRoles = new TabPage();
            tabPageManageCategory = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            buttonAddProdCategory = new Button();
            dataGridViewProductCategory = new DataGridView();
            tabPageManageProduct = new TabPage();
            tableLayoutPanel7 = new TableLayoutPanel();
            button3 = new Button();
            dataGridViewProducts = new DataGridView();
            tabPageMyProfile = new TabPage();
            panel2 = new Panel();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel5 = new TableLayoutPanel();
            textBoxRole = new TextBox();
            label13 = new Label();
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
            groupBox1 = new GroupBox();
            dataGridViewPermissions = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            button2 = new Button();
            tabPage4 = new TabPage();
            tabPageManageOrders = new TabPage();
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
            tabPageManageCategory.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductCategory).BeginInit();
            tabPageManageProduct.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            tabPageMyProfile.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPermissions).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnAddRole, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridViewRoles, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            dataGridViewRoles.Location = new Point(3, 38);
            dataGridViewRoles.Name = "dataGridViewRoles";
            dataGridViewRoles.Size = new Size(780, 375);
            dataGridViewRoles.TabIndex = 0;
            dataGridViewRoles.CellDoubleClick += dataGridViewRoles_CellDoubleClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageUsers);
            tabControl1.Controls.Add(tabPageRoleLevels);
            tabControl1.Controls.Add(tabPageRoles);
            tabControl1.Controls.Add(tabPageManageCategory);
            tabControl1.Controls.Add(tabPageManageProduct);
            tabControl1.Controls.Add(tabPageManageOrders);
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
            tabPageUsers.BackColor = Color.Transparent;
            tabPageUsers.Controls.Add(tableLayoutPanel2);
            tabPageUsers.Location = new Point(4, 24);
            tabPageUsers.Name = "tabPageUsers";
            tabPageUsers.Padding = new Padding(3);
            tabPageUsers.Size = new Size(792, 422);
            tabPageUsers.TabIndex = 1;
            tabPageUsers.Text = "Manage Users";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(dataGridViewUsers, 0, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(786, 416);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(3, 43);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.Size = new Size(780, 370);
            dataGridViewUsers.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddUser);
            panel1.Controls.Add(buttonInitializeSystem);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 34);
            panel1.TabIndex = 1;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(138, 4);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 27);
            btnAddUser.TabIndex = 3;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // buttonInitializeSystem
            // 
            buttonInitializeSystem.Location = new Point(3, 4);
            buttonInitializeSystem.Name = "buttonInitializeSystem";
            buttonInitializeSystem.Size = new Size(135, 27);
            buttonInitializeSystem.TabIndex = 2;
            buttonInitializeSystem.Text = "Initialize System";
            buttonInitializeSystem.UseVisualStyleBackColor = true;
            buttonInitializeSystem.Click += buttonInitializeSystem_Click;
            // 
            // tabPageRoleLevels
            // 
            tabPageRoleLevels.BackColor = Color.MistyRose;
            tabPageRoleLevels.Controls.Add(tableLayoutPanel4);
            tabPageRoleLevels.Location = new Point(4, 24);
            tabPageRoleLevels.Name = "tabPageRoleLevels";
            tabPageRoleLevels.Padding = new Padding(3);
            tabPageRoleLevels.Size = new Size(792, 422);
            tabPageRoleLevels.TabIndex = 2;
            tabPageRoleLevels.Text = "Manage Role Levels";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(buttonAddRoleLevel, 0, 0);
            tableLayoutPanel4.Controls.Add(dataGridViewRoleLevels, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            dataGridViewRoleLevels.Location = new Point(3, 38);
            dataGridViewRoleLevels.Name = "dataGridViewRoleLevels";
            dataGridViewRoleLevels.Size = new Size(780, 375);
            dataGridViewRoleLevels.TabIndex = 0;
            // 
            // tabPageRoles
            // 
            tabPageRoles.BackColor = Color.MistyRose;
            tabPageRoles.Controls.Add(tableLayoutPanel1);
            tabPageRoles.Location = new Point(4, 24);
            tabPageRoles.Name = "tabPageRoles";
            tabPageRoles.Padding = new Padding(3);
            tabPageRoles.Size = new Size(792, 422);
            tabPageRoles.TabIndex = 0;
            tabPageRoles.Text = "Manage Roles";
            // 
            // tabPageManageCategory
            // 
            tabPageManageCategory.BackColor = Color.Transparent;
            tabPageManageCategory.Controls.Add(tableLayoutPanel6);
            tabPageManageCategory.Location = new Point(4, 24);
            tabPageManageCategory.Name = "tabPageManageCategory";
            tabPageManageCategory.Size = new Size(792, 422);
            tabPageManageCategory.TabIndex = 4;
            tabPageManageCategory.Text = "Manage Product Category";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(buttonAddProdCategory, 0, 0);
            tableLayoutPanel6.Controls.Add(dataGridViewProductCategory, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(792, 422);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // buttonAddProdCategory
            // 
            buttonAddProdCategory.Location = new Point(3, 3);
            buttonAddProdCategory.Name = "buttonAddProdCategory";
            buttonAddProdCategory.Size = new Size(141, 27);
            buttonAddProdCategory.TabIndex = 1;
            buttonAddProdCategory.Text = "Add Product Category";
            buttonAddProdCategory.UseVisualStyleBackColor = true;
            buttonAddProdCategory.Click += buttonAddProdCategory_Click;
            // 
            // dataGridViewProductCategory
            // 
            dataGridViewProductCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductCategory.Dock = DockStyle.Fill;
            dataGridViewProductCategory.Location = new Point(3, 38);
            dataGridViewProductCategory.Name = "dataGridViewProductCategory";
            dataGridViewProductCategory.Size = new Size(786, 381);
            dataGridViewProductCategory.TabIndex = 0;
            // 
            // tabPageManageProduct
            // 
            tabPageManageProduct.BackColor = Color.Transparent;
            tabPageManageProduct.Controls.Add(tableLayoutPanel7);
            tabPageManageProduct.Location = new Point(4, 24);
            tabPageManageProduct.Name = "tabPageManageProduct";
            tabPageManageProduct.Padding = new Padding(3);
            tabPageManageProduct.Size = new Size(792, 422);
            tabPageManageProduct.TabIndex = 5;
            tabPageManageProduct.Text = "Manage Product";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(button3, 0, 0);
            tableLayoutPanel7.Controls.Add(dataGridViewProducts, 0, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(786, 416);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // button3
            // 
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(108, 27);
            button3.TabIndex = 1;
            button3.Text = "Add Product";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonAddProduct_Click;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Dock = DockStyle.Fill;
            dataGridViewProducts.Location = new Point(3, 38);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.Size = new Size(780, 375);
            dataGridViewProducts.TabIndex = 0;
            // 
            // tabPageMyProfile
            // 
            tabPageMyProfile.BackColor = Color.Transparent;
            tabPageMyProfile.Controls.Add(panel2);
            tabPageMyProfile.Location = new Point(4, 24);
            tabPageMyProfile.Name = "tabPageMyProfile";
            tabPageMyProfile.Size = new Size(792, 422);
            tabPageMyProfile.TabIndex = 3;
            tabPageMyProfile.Text = "My Profile";
            // 
            // panel2
            // 
            panel2.Controls.Add(splitContainer1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(792, 422);
            panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.GradientInactiveCaption;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel5);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(792, 422);
            splitContainer1.SplitterDistance = 352;
            splitContainer1.TabIndex = 0;
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
            tableLayoutPanel5.Dock = DockStyle.Top;
            tableLayoutPanel5.Location = new Point(0, 0);
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
            tableLayoutPanel5.Size = new Size(352, 422);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // textBoxRole
            // 
            textBoxRole.Location = new Point(86, 35);
            textBoxRole.Name = "textBoxRole";
            textBoxRole.ReadOnly = true;
            textBoxRole.Size = new Size(234, 23);
            textBoxRole.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Location = new Point(3, 32);
            label13.Name = "label13";
            label13.Size = new Size(77, 32);
            label13.TabIndex = 1;
            label13.Text = "Role";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.Location = new Point(86, 227);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 25;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(86, 195);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 1;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBoxUserId
            // 
            textBoxUserId.Location = new Point(86, 387);
            textBoxUserId.Name = "textBoxUserId";
            textBoxUserId.ReadOnly = true;
            textBoxUserId.Size = new Size(234, 23);
            textBoxUserId.TabIndex = 24;
            // 
            // textBoxModifiedDate
            // 
            textBoxModifiedDate.Location = new Point(86, 355);
            textBoxModifiedDate.Name = "textBoxModifiedDate";
            textBoxModifiedDate.ReadOnly = true;
            textBoxModifiedDate.Size = new Size(234, 23);
            textBoxModifiedDate.TabIndex = 23;
            // 
            // textBoxModifiedBy
            // 
            textBoxModifiedBy.Location = new Point(86, 323);
            textBoxModifiedBy.Name = "textBoxModifiedBy";
            textBoxModifiedBy.ReadOnly = true;
            textBoxModifiedBy.Size = new Size(234, 23);
            textBoxModifiedBy.TabIndex = 22;
            // 
            // textBoxCreatedDate
            // 
            textBoxCreatedDate.Location = new Point(86, 291);
            textBoxCreatedDate.Name = "textBoxCreatedDate";
            textBoxCreatedDate.ReadOnly = true;
            textBoxCreatedDate.Size = new Size(234, 23);
            textBoxCreatedDate.TabIndex = 21;
            // 
            // textBoxCreatedBy
            // 
            textBoxCreatedBy.Location = new Point(86, 259);
            textBoxCreatedBy.Name = "textBoxCreatedBy";
            textBoxCreatedBy.ReadOnly = true;
            textBoxCreatedBy.Size = new Size(234, 23);
            textBoxCreatedBy.TabIndex = 20;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(86, 163);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(234, 23);
            textBoxEmail.TabIndex = 17;
            // 
            // textBoxLName
            // 
            textBoxLName.Location = new Point(86, 131);
            textBoxLName.Name = "textBoxLName";
            textBoxLName.ReadOnly = true;
            textBoxLName.Size = new Size(234, 23);
            textBoxLName.TabIndex = 16;
            // 
            // textBoxMName
            // 
            textBoxMName.Location = new Point(86, 99);
            textBoxMName.Name = "textBoxMName";
            textBoxMName.ReadOnly = true;
            textBoxMName.Size = new Size(234, 23);
            textBoxMName.TabIndex = 15;
            // 
            // textBoxFName
            // 
            textBoxFName.Location = new Point(86, 67);
            textBoxFName.Name = "textBoxFName";
            textBoxFName.ReadOnly = true;
            textBoxFName.Size = new Size(234, 23);
            textBoxFName.TabIndex = 14;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(86, 3);
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
            label1.Size = new Size(77, 32);
            label1.TabIndex = 1;
            label1.Text = "Username";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(3, 384);
            label12.Name = "label12";
            label12.Size = new Size(77, 38);
            label12.TabIndex = 12;
            label12.Text = "User Id";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(3, 352);
            label11.Name = "label11";
            label11.Size = new Size(77, 32);
            label11.TabIndex = 11;
            label11.Text = "Modified Date";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 320);
            label10.Name = "label10";
            label10.Size = new Size(77, 32);
            label10.TabIndex = 10;
            label10.Text = "Modified By";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 288);
            label9.Name = "label9";
            label9.Size = new Size(77, 32);
            label9.TabIndex = 9;
            label9.Text = "Created Date";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(3, 256);
            label8.Name = "label8";
            label8.Size = new Size(77, 32);
            label8.TabIndex = 8;
            label8.Text = "Created By";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 224);
            label7.Name = "label7";
            label7.Size = new Size(77, 32);
            label7.TabIndex = 7;
            label7.Text = "Is Active";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 192);
            label6.Name = "label6";
            label6.Size = new Size(77, 32);
            label6.TabIndex = 6;
            label6.Text = "Verified";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 160);
            label5.Name = "label5";
            label5.Size = new Size(77, 32);
            label5.TabIndex = 5;
            label5.Text = "Email";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 128);
            label4.Name = "label4";
            label4.Size = new Size(77, 32);
            label4.TabIndex = 4;
            label4.Text = "Last Name";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 96);
            label3.Name = "label3";
            label3.Size = new Size(77, 32);
            label3.TabIndex = 3;
            label3.Text = "Middle Name";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 64);
            label2.Name = "label2";
            label2.Size = new Size(77, 32);
            label2.TabIndex = 2;
            label2.Text = "First Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewPermissions);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(436, 422);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permissions";
            // 
            // dataGridViewPermissions
            // 
            dataGridViewPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPermissions.Dock = DockStyle.Fill;
            dataGridViewPermissions.Location = new Point(3, 19);
            dataGridViewPermissions.Name = "dataGridViewPermissions";
            dataGridViewPermissions.Size = new Size(430, 400);
            dataGridViewPermissions.TabIndex = 0;
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
            // tabPageManageOrder
            // 
            tabPageManageOrders.Location = new Point(4, 24);
            tabPageManageOrders.Name = "tabPageManageOrders";
            tabPageManageOrders.Padding = new Padding(3);
            tabPageManageOrders.Size = new Size(792, 422);
            tabPageManageOrders.TabIndex = 6;
            tabPageManageOrders.Text = "Manage Orders";
            tabPageManageOrders.UseVisualStyleBackColor = true;
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
            tabPageManageCategory.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductCategory).EndInit();
            tabPageManageProduct.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            tabPageMyProfile.ResumeLayout(false);
            panel2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPermissions).EndInit();
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
		private Button buttonInitializeSystem;
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
        private Panel panel2;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private DataGridView dataGridViewPermissions;
        private TabPage tabPageManageCategory;
        private TabPage tabPageManageProduct;
        private TableLayoutPanel tableLayoutPanel6;
        private Button buttonAddProdCategory;
        private DataGridView dataGridViewProductCategory;
        private TableLayoutPanel tableLayoutPanel7;
        private Button button3;
        private DataGridView dataGridViewProducts;
        private TabPage tabPageManageOrders;
    }
}