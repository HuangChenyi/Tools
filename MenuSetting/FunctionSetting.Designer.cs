namespace MenuSetting
{
    partial class FunctionSetting
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnMenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnMenuName,
            this.ColumnStatus,
            this.ColumnMenuId,
            this.ColumnEnable});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(420, 322);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // columnMenuName
            // 
            this.columnMenuName.DataPropertyName = "MENU_NAME";
            this.columnMenuName.Frozen = true;
            this.columnMenuName.HeaderText = "選單名稱";
            this.columnMenuName.Name = "columnMenuName";
            this.columnMenuName.ReadOnly = true;
            this.columnMenuName.Width = 97;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "STATUS";
            this.ColumnStatus.Frozen = true;
            this.ColumnStatus.HeaderText = "狀態";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Width = 65;
            // 
            // ColumnMenuId
            // 
            this.ColumnMenuId.DataPropertyName = "MENU_ID";
            this.ColumnMenuId.Frozen = true;
            this.ColumnMenuId.HeaderText = "MENU_ID";
            this.ColumnMenuId.Name = "ColumnMenuId";
            this.ColumnMenuId.ReadOnly = true;
            this.ColumnMenuId.Visible = false;
            this.ColumnMenuId.Width = 101;
            // 
            // ColumnEnable
            // 
            this.ColumnEnable.Frozen = true;
            this.ColumnEnable.HeaderText = "操作";
            this.ColumnEnable.Name = "ColumnEnable";
            this.ColumnEnable.ReadOnly = true;
            this.ColumnEnable.Text = "變更狀態";
            this.ColumnEnable.UseColumnTextForButtonValue = true;
            this.ColumnEnable.Width = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 348);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // FunctionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 348);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FunctionSetting";
            this.Text = "FunctionSetting";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMenuId;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEnable;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}