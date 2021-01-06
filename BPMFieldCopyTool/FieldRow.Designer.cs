namespace BPMFieldCopyTool
{
    partial class FieldRow
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlFieldInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRow = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlFieldInfo);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pnlFieldInfo
            // 
            this.pnlFieldInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFieldInfo.Location = new System.Drawing.Point(58, 23);
            this.pnlFieldInfo.Name = "pnlFieldInfo";
            this.pnlFieldInfo.Size = new System.Drawing.Size(623, 124);
            this.pnlFieldInfo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbRow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 124);
            this.panel1.TabIndex = 0;
            // 
            // cbRow
            // 
            this.cbRow.AutoSize = true;
            this.cbRow.Location = new System.Drawing.Point(21, 54);
            this.cbRow.Name = "cbRow";
            this.cbRow.Size = new System.Drawing.Size(15, 14);
            this.cbRow.TabIndex = 0;
            this.cbRow.UseVisualStyleBackColor = true;
            this.cbRow.CheckedChanged += new System.EventHandler(this.cbRow_CheckedChanged);
            // 
            // FieldRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FieldRow";
            this.Size = new System.Drawing.Size(684, 150);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlFieldInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbRow;
    }
}
