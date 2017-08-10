namespace SQLHelper
{
    partial class SelectCondition
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridCondition = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuCondition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSelectCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectReverseCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridColumns = new System.Windows.Forms.DataGridView();
            this.columnColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuColumn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSelectColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectReverseColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCondition)).BeginInit();
            this.menuCondition.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).BeginInit();
            this.menuColumn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 505);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 426);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(580, 79);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(225, 36);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "確定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 426);
            this.panel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridCondition);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(259, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 426);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "選擇的條件";
            // 
            // gridCondition
            // 
            this.gridCondition.AllowUserToAddRows = false;
            this.gridCondition.AllowUserToDeleteRows = false;
            this.gridCondition.AllowUserToResizeColumns = false;
            this.gridCondition.AllowUserToResizeRows = false;
            this.gridCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCondition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.gridCondition.ContextMenuStrip = this.menuCondition;
            this.gridCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCondition.Location = new System.Drawing.Point(3, 18);
            this.gridCondition.Name = "gridCondition";
            this.gridCondition.RowTemplate.Height = 24;
            this.gridCondition.Size = new System.Drawing.Size(315, 405);
            this.gridCondition.TabIndex = 0;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "COLUMN_NAME";
            this.Column3.HeaderText = "欄位名稱";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DATA_TYPE";
            this.Column4.HeaderText = "欄位型態";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // menuCondition
            // 
            this.menuCondition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelectCondition,
            this.menuSelectReverseCondition});
            this.menuCondition.Name = "menuCondition";
            this.menuCondition.Size = new System.Drawing.Size(119, 48);
            // 
            // menuSelectCondition
            // 
            this.menuSelectCondition.Name = "menuSelectCondition";
            this.menuSelectCondition.Size = new System.Drawing.Size(118, 22);
            this.menuSelectCondition.Text = "全選";
            this.menuSelectCondition.Click += new System.EventHandler(this.menuSelectCondition_Click);
            // 
            // menuSelectReverseCondition
            // 
            this.menuSelectReverseCondition.Name = "menuSelectReverseCondition";
            this.menuSelectReverseCondition.Size = new System.Drawing.Size(118, 22);
            this.menuSelectReverseCondition.Text = "反向全選";
            this.menuSelectReverseCondition.Click += new System.EventHandler(this.menuSelectReverseCondition_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridColumns);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 426);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "選擇的欄位";
            // 
            // gridColumns
            // 
            this.gridColumns.AllowUserToAddRows = false;
            this.gridColumns.AllowUserToDeleteRows = false;
            this.gridColumns.AllowUserToResizeColumns = false;
            this.gridColumns.AllowUserToResizeRows = false;
            this.gridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnColumnName,
            this.columnColumnType});
            this.gridColumns.ContextMenuStrip = this.menuColumn;
            this.gridColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColumns.Location = new System.Drawing.Point(3, 18);
            this.gridColumns.Name = "gridColumns";
            this.gridColumns.ReadOnly = true;
            this.gridColumns.RowTemplate.Height = 24;
            this.gridColumns.Size = new System.Drawing.Size(253, 405);
            this.gridColumns.TabIndex = 0;
            // 
            // columnColumnName
            // 
            this.columnColumnName.DataPropertyName = "COLUMN_NAME";
            this.columnColumnName.HeaderText = "欄位名稱";
            this.columnColumnName.Name = "columnColumnName";
            this.columnColumnName.ReadOnly = true;
            this.columnColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnColumnType
            // 
            this.columnColumnType.DataPropertyName = "DATA_TYPE";
            this.columnColumnType.HeaderText = "欄位型態";
            this.columnColumnType.Name = "columnColumnType";
            this.columnColumnType.ReadOnly = true;
            this.columnColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnColumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuColumn
            // 
            this.menuColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelectColumn,
            this.menuSelectReverseColumn});
            this.menuColumn.Name = "contextMenuStrip1";
            this.menuColumn.Size = new System.Drawing.Size(119, 48);
            // 
            // menuSelectColumn
            // 
            this.menuSelectColumn.Name = "menuSelectColumn";
            this.menuSelectColumn.Size = new System.Drawing.Size(118, 22);
            this.menuSelectColumn.Text = "全選";
            this.menuSelectColumn.Click += new System.EventHandler(this.menuSelectColumn_Click);
            // 
            // menuSelectReverseColumn
            // 
            this.menuSelectReverseColumn.Name = "menuSelectReverseColumn";
            this.menuSelectReverseColumn.Size = new System.Drawing.Size(118, 22);
            this.menuSelectReverseColumn.Text = "反向全選";
            this.menuSelectReverseColumn.Click += new System.EventHandler(this.menuSelectReverseColumn_Click);
            // 
            // SelectCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 505);
            this.Controls.Add(this.panel1);
            this.Name = "SelectCondition";
            this.Text = "SelectCondition";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCondition)).EndInit();
            this.menuCondition.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColumns)).EndInit();
            this.menuColumn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridColumns;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridView gridCondition;
        private System.Windows.Forms.ContextMenuStrip menuColumn;
        private System.Windows.Forms.ToolStripMenuItem menuSelectColumn;
        private System.Windows.Forms.ToolStripMenuItem menuSelectReverseColumn;
        private System.Windows.Forms.ContextMenuStrip menuCondition;
        private System.Windows.Forms.ToolStripMenuItem menuSelectCondition;
        private System.Windows.Forms.ToolStripMenuItem menuSelectReverseCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnColumnType;
    }
}