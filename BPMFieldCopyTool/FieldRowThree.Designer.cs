﻿namespace BPMFieldCopyTool
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
            this.pnlFieldInfoRight = new System.Windows.Forms.Panel();
            this.pnlFieldInfoLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRow = new System.Windows.Forms.CheckBox();
            this.pnlFieldInfoCenter = new System.Windows.Forms.Panel();
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
            this.gbRow.Name = "gbRow";
            this.gbRow.Size = new System.Drawing.Size(684, 150);
            this.gbRow.TabIndex = 2;
            this.gbRow.TabStop = false;
            // 
            // pnlFieldInfoRight
            // 
            this.pnlFieldInfoRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFieldInfoRight.Location = new System.Drawing.Point(427, 23);
            this.pnlFieldInfoRight.Name = "pnlFieldInfoRight";
            this.pnlFieldInfoRight.Size = new System.Drawing.Size(254, 124);
            this.pnlFieldInfoRight.TabIndex = 2;
            // 
            // pnlFieldInfoLeft
            // 
            this.pnlFieldInfoLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFieldInfoLeft.Location = new System.Drawing.Point(58, 23);
            this.pnlFieldInfoLeft.Name = "pnlFieldInfoLeft";
            this.pnlFieldInfoLeft.Size = new System.Drawing.Size(200, 124);
            this.pnlFieldInfoLeft.TabIndex = 1;
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
            // 
            // pnlFieldInfoCenter
            // 
            this.pnlFieldInfoCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFieldInfoCenter.Location = new System.Drawing.Point(258, 23);
            this.pnlFieldInfoCenter.Name = "pnlFieldInfoCenter";
            this.pnlFieldInfoCenter.Size = new System.Drawing.Size(169, 124);
            this.pnlFieldInfoCenter.TabIndex = 3;
            // 
            // FieldRowThree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbRow);
            this.Name = "FieldRowThree";
            this.Size = new System.Drawing.Size(684, 150);
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
