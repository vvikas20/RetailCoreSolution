namespace RetailCore.WindowsApp
{
    partial class AddProductForm
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
            tbxProductName = new TextBox();
            label4 = new Label();
            label1 = new Label();
            cbxProductCategory = new ComboBox();
            label2 = new Label();
            tbxPrice = new TextBox();
            label5 = new Label();
            tbxStock = new TextBox();
            btnSave = new Button();
            label10 = new Label();
            textBoxProductId = new TextBox();
            label3 = new Label();
            textBoxDescription = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tbxProductName, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 3);
            tableLayoutPanel1.Controls.Add(cbxProductCategory, 1, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 4);
            tableLayoutPanel1.Controls.Add(tbxPrice, 1, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 5);
            tableLayoutPanel1.Controls.Add(tbxStock, 1, 5);
            tableLayoutPanel1.Controls.Add(btnSave, 1, 11);
            tableLayoutPanel1.Controls.Add(label10, 0, 0);
            tableLayoutPanel1.Controls.Add(textBoxProductId, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(textBoxDescription, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 12;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(329, 366);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tbxProductName
            // 
            tbxProductName.Location = new Point(123, 33);
            tbxProductName.Name = "tbxProductName";
            tbxProductName.Size = new Size(203, 23);
            tbxProductName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Lavender;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 30);
            label4.Name = "label4";
            label4.Size = new Size(114, 30);
            label4.TabIndex = 2;
            label4.Text = "Name";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Lavender;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 90);
            label1.Name = "label1";
            label1.Size = new Size(114, 30);
            label1.TabIndex = 1;
            label1.Text = "Category";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbxProductCategory
            // 
            cbxProductCategory.Dock = DockStyle.Fill;
            cbxProductCategory.FormattingEnabled = true;
            cbxProductCategory.Location = new Point(123, 93);
            cbxProductCategory.Name = "cbxProductCategory";
            cbxProductCategory.Size = new Size(203, 23);
            cbxProductCategory.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Lavender;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 120);
            label2.Name = "label2";
            label2.Size = new Size(114, 30);
            label2.TabIndex = 2;
            label2.Text = "Price";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxPrice
            // 
            tbxPrice.Dock = DockStyle.Fill;
            tbxPrice.Location = new Point(123, 123);
            tbxPrice.Name = "tbxPrice";
            tbxPrice.Size = new Size(203, 23);
            tbxPrice.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Lavender;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 150);
            label5.Name = "label5";
            label5.Size = new Size(114, 30);
            label5.TabIndex = 8;
            label5.Text = "Stock";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxStock
            // 
            tbxStock.Dock = DockStyle.Fill;
            tbxStock.Location = new Point(123, 153);
            tbxStock.Name = "tbxStock";
            tbxStock.Size = new Size(203, 23);
            tbxStock.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(123, 333);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Lavender;
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(114, 30);
            label10.TabIndex = 18;
            label10.Text = "Product Id";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxProductId
            // 
            textBoxProductId.Dock = DockStyle.Fill;
            textBoxProductId.Location = new Point(123, 3);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.ReadOnly = true;
            textBoxProductId.Size = new Size(203, 23);
            textBoxProductId.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Lavender;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(114, 30);
            label3.TabIndex = 20;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(123, 63);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(203, 23);
            textBoxDescription.TabIndex = 2;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 366);
            Controls.Add(tableLayoutPanel1);
            Name = "AddProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";
            FormClosing += AddRoleForm_FormClosing;
            Load += AddProductForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbxProductCategory;
        private Label label2;
        private Label label1;
        private TextBox tbxProductName;
        private Label label4;
        private TextBox tbxStock;
        private Button btnSave;
        private TextBox tbxPrice;
		private Label label5;
		private Label label10;
		private TextBox textBoxProductId;
        private Label label3;
        private TextBox textBoxDescription;
    }
}