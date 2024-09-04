namespace RetailCore.EntityGenerator
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanelHeader = new TableLayoutPanel();
            tbxOutputDirectory = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tbxConnectionString = new TextBox();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBoxTables = new GroupBox();
            checkedListBox = new CheckedListBox();
            groupBox3 = new GroupBox();
            btnSelectAll = new Button();
            btnReset = new Button();
            btnGenerateEntities = new Button();
            btnSelectDirectory = new Button();
            btnLoadTables = new Button();
            groupBox1 = new GroupBox();
            richTextBox = new RichTextBox();
            cbxDeleteContext = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBoxTables.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanelHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(916, 472);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelHeader
            // 
            tableLayoutPanelHeader.BackColor = SystemColors.ControlLight;
            tableLayoutPanelHeader.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelHeader.ColumnCount = 2;
            tableLayoutPanelHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tableLayoutPanelHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelHeader.Controls.Add(tbxOutputDirectory, 1, 1);
            tableLayoutPanelHeader.Controls.Add(label2, 0, 1);
            tableLayoutPanelHeader.Controls.Add(label1, 0, 0);
            tableLayoutPanelHeader.Controls.Add(tbxConnectionString, 1, 0);
            tableLayoutPanelHeader.Dock = DockStyle.Fill;
            tableLayoutPanelHeader.Location = new Point(3, 3);
            tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            tableLayoutPanelHeader.RowCount = 2;
            tableLayoutPanelHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelHeader.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelHeader.Size = new Size(910, 64);
            tableLayoutPanelHeader.TabIndex = 0;
            // 
            // tbxOutputDirectory
            // 
            tbxOutputDirectory.Dock = DockStyle.Fill;
            tbxOutputDirectory.Location = new Point(115, 35);
            tbxOutputDirectory.Name = "tbxOutputDirectory";
            tbxOutputDirectory.ReadOnly = true;
            tbxOutputDirectory.Size = new Size(791, 23);
            tbxOutputDirectory.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(4, 32);
            label2.Name = "label2";
            label2.Size = new Size(104, 31);
            label2.TabIndex = 4;
            label2.Text = "Entities Directory";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(104, 30);
            label1.TabIndex = 0;
            label1.Text = "Connection String";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbxConnectionString
            // 
            tbxConnectionString.Dock = DockStyle.Fill;
            tbxConnectionString.Location = new Point(115, 4);
            tbxConnectionString.Name = "tbxConnectionString";
            tbxConnectionString.Size = new Size(791, 23);
            tbxConnectionString.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 73);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(910, 396);
            splitContainer1.SplitterDistance = 549;
            splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tableLayoutPanel2.Controls.Add(groupBoxTables, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox3, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(549, 396);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBoxTables
            // 
            groupBoxTables.Controls.Add(checkedListBox);
            groupBoxTables.Dock = DockStyle.Fill;
            groupBoxTables.Location = new Point(3, 3);
            groupBoxTables.Name = "groupBoxTables";
            groupBoxTables.Size = new Size(368, 390);
            groupBoxTables.TabIndex = 0;
            groupBoxTables.TabStop = false;
            groupBoxTables.Text = "Tables";
            // 
            // checkedListBox
            // 
            checkedListBox.Dock = DockStyle.Fill;
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(3, 19);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(362, 368);
            checkedListBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbxDeleteContext);
            groupBox3.Controls.Add(btnSelectAll);
            groupBox3.Controls.Add(btnReset);
            groupBox3.Controls.Add(btnGenerateEntities);
            groupBox3.Controls.Add(btnSelectDirectory);
            groupBox3.Controls.Add(btnLoadTables);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(377, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(169, 390);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Controls";
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(6, 49);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(157, 23);
            btnSelectAll.TabIndex = 4;
            btnSelectAll.Text = "Select/Deselect All";
            btnSelectAll.UseVisualStyleBackColor = true;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(8, 158);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(157, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnGenerateEntities
            // 
            btnGenerateEntities.Location = new Point(6, 103);
            btnGenerateEntities.Name = "btnGenerateEntities";
            btnGenerateEntities.Size = new Size(157, 23);
            btnGenerateEntities.TabIndex = 2;
            btnGenerateEntities.Text = "Generate Entities";
            btnGenerateEntities.UseVisualStyleBackColor = true;
            btnGenerateEntities.Click += btnGenerateEntities_Click;
            // 
            // btnSelectDirectory
            // 
            btnSelectDirectory.Location = new Point(6, 76);
            btnSelectDirectory.Name = "btnSelectDirectory";
            btnSelectDirectory.Size = new Size(157, 23);
            btnSelectDirectory.TabIndex = 1;
            btnSelectDirectory.Text = "Select Entity Directory";
            btnSelectDirectory.UseVisualStyleBackColor = true;
            btnSelectDirectory.Click += btnSelectDirectory_Click;
            // 
            // btnLoadTables
            // 
            btnLoadTables.Location = new Point(6, 22);
            btnLoadTables.Name = "btnLoadTables";
            btnLoadTables.Size = new Size(157, 23);
            btnLoadTables.TabIndex = 0;
            btnLoadTables.Text = "Load Tables";
            btnLoadTables.UseVisualStyleBackColor = true;
            btnLoadTables.Click += btnLoadTables_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 396);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Console";
            // 
            // richTextBox
            // 
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Location = new Point(3, 19);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(351, 374);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // cbxDeleteContext
            // 
            cbxDeleteContext.AutoSize = true;
            cbxDeleteContext.Location = new Point(8, 133);
            cbxDeleteContext.Name = "cbxDeleteContext";
            cbxDeleteContext.Size = new Size(125, 19);
            cbxDeleteContext.TabIndex = 5;
            cbxDeleteContext.Text = "Delete Context File";
            cbxDeleteContext.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 472);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Entity Model Generator";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanelHeader.ResumeLayout(false);
            tableLayoutPanelHeader.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBoxTables.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanelHeader;
		private Label label1;
		private TextBox tbxConnectionString;
		private Label label2;
		private TextBox tbxOutputDirectory;
		private SplitContainer splitContainer1;
		private RichTextBox richTextBox;
		private GroupBox groupBox1;
		private TableLayoutPanel tableLayoutPanel2;
		private GroupBox groupBoxTables;
		private CheckedListBox checkedListBox;
		private GroupBox groupBox3;
		private Button btnReset;
		private Button btnGenerateEntities;
		private Button btnSelectDirectory;
		private Button btnLoadTables;
        private Button btnSelectAll;
        private CheckBox cbxDeleteContext;
    }
}
