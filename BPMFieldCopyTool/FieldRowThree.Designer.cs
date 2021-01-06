namespace BPMFieldCopyTool
{
    partial class FieldRowThree
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
            this.gbRow = new System.Windows.Forms.GroupBox();
            this.pnlFieldInfoCenter = new System.Windows.Forms.Panel();
            this.pnlFieldInfoRight = new System.Windows.Forms.Panel();
            this.pnlFieldInfoLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRow = new System.Windows.Forms.CheckBox();
            this.gbRow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRow
            // 
            this.gbRow.Controls.Add(this.pnlFieldInfoCenter);
            this.gbRow.Controls.Add(this.pnlFieldInfoRight);
            this.gbRow.Controls.Add(this.pnlFieldInfoLeft);
            this.gbRow.Controls.Add(this.panel1);
            this.gbRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRow.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbRow.Location = new System.Drawing.Point(0, 0);
            this.gbRow.Margin = new System.Windows.Forms.Padding(4);
            this.gbRow.Name = "gbRow";
            this.gbRow.Padding = new System.Windows.Forms.Padding(4);
            this.gbRow.Size = new System.Drawing.Size(1000, 150);
            this.gbRow.TabIndex = 2;
            this.gbRow.TabStop = false;
            // 
            // pnlFieldInfoCenter
            // 
            this.pnlFieldInfoCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFieldInfoCenter.Location = new System.Drawing.Point(419, 24);
            this.pnlFieldInfoCenter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFieldInfoCenter.Name = "pnlFieldInfoCenter";
            this.pnlFieldInfoCenter.Size = new System.Drawing.Size(244, 122);
            this.pnlFieldInfoCenter.TabIndex = 3;
            // 
            // pnlFieldInfoRight
            // 
            this.pnlFieldInfoRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFieldInfoRight.Location = new System.Drawing.Point(663, 24);
            this.pnlFieldInfoRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFieldInfoRight.Name = "pnlFieldInfoRight";
            this.pnlFieldInfoRight.Size = new System.Drawing.Size(333, 122);
            this.pnlFieldInfoRight.TabIndex = 2;
            // 
            // pnlFieldInfoLeft
            // 
            this.pnlFieldInfoLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFieldInfoLeft.Location = new System.Drawing.Point(86, 24);
            this.pnlFieldInfoLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFieldInfoLeft.Name = "pnlFieldInfoLeft";
            this.pnlFieldInfoLeft.Size = new System.Drawing.Size(333, 122);
            this.pnlFieldInfoLeft.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbRow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 122);
            this.panel1.TabIndex = 0;
            // 
            // cbRow
            // 
            this.cbRow.AutoSize = true;
            this.cbRow.Location = new System.Drawing.Point(32, 53);
            this.cbRow.Margin = new System.Windows.Forms.Padding(4);
            this.cbRow.Name = "cbRow";
            this.cbRow.Size = new System.Drawing.Size(15, 14);
            this.cbRow.TabIndex = 0;
            this.cbRow.UseVisualStyleBackColor = true;
            this.cbRow.CheckedChanged += new System.EventHandler(this.cbRow_CheckedChanged);
            // 
            // FieldRowThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbRow);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FieldRowThree";
            this.Size = new System.Drawing.Size(1000, 150);
            this.Load += new System.EventHandler(this.FieldRowThree_Load);
            this.gbRow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRow;
        private System.Windows.Forms.Panel pnlFieldInfoRight;
        private System.Windows.Forms.Panel pnlFieldInfoLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbRow;
        private System.Windows.Forms.Panel pnlFieldInfoCenter;
    }
}
