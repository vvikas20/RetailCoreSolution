namespace RetailCore.WindowsApp
{
    partial class AddProductCategoryForm
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
            textBoxCategoryDisplay = new TextBox();
            label3 = new Label();
            btnSave = new Button();
            textBoxCategoryName = new TextBox();
            label2 = new Label();
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
            tableLayoutPanel1.Controls.Add(textBoxCategoryDisplay, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 3);
            tableLayoutPanel1.Controls.Add(textBoxCategoryName, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(372, 126);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tbxRoleID
            // 
            tbxRoleID.Dock = DockStyle.Fill;
            tbxRoleID.Location = new Point(123, 3);
            tbxRoleID.Name = "tbxRoleID";
            tbxRoleID.ReadOnly = true;
            tbxRoleID.Size = new Size(246, 23);
            tbxRoleID.TabIndex = 7;
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
            label4.Text = "Category ID";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCategoryDisplay
            // 
            textBoxCategoryDisplay.Dock = DockStyle.Fill;
            textBoxCategoryDisplay.Location = new Point(123, 63);
            textBoxCategoryDisplay.Name = "textBoxCategoryDisplay";
            textBoxCategoryDisplay.Size = new Size(246, 23);
            textBoxCategoryDisplay.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Lavender;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(114, 30);
            label3.TabIndex = 3;
            label3.Text = "Display Name";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(123, 93);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(246, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // textBoxCategoryName
            // 
            textBoxCategoryName.Dock = DockStyle.Fill;
            textBoxCategoryName.Location = new Point(123, 33);
            textBoxCategoryName.Name = "textBoxCategoryName";
            textBoxCategoryName.Size = new Size(246, 23);
            textBoxCategoryName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Lavender;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(114, 30);
            label2.TabIndex = 2;
            label2.Text = "Category Name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddProductCategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 126);
            Controls.Add(tableLayoutPanel1);
            Name = "AddProductCategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product Category";
            FormClosing += AddRoleForm_FormClosing;
            Load += AddProductCategoryForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private TextBox tbxRoleID;
        private Label label4;
        private TextBox textBoxCategoryDisplay;
        private Button btnSave;
        private TextBox textBoxCategoryName;
    }
}