namespace ShangxianForm
{
    partial class ShangxianForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpConnectInfo = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeFormList = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridForm = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnScript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFormVersionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbOption = new System.Windows.Forms.ComboBox();
            this.grpConnectInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridForm)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnectInfo
            // 
            this.grpConnectInfo.Controls.Add(this.btnConnect);
            this.grpConnectInfo.Controls.Add(this.txtPwd);
            this.grpConnectInfo.Controls.Add(this.label4);
            this.grpConnectInfo.Controls.Add(this.txtSid);
            this.grpConnectInfo.Controls.Add(this.label2);
            this.grpConnectInfo.Controls.Add(this.txtServerName);
            this.grpConnectInfo.Controls.Add(this.label1);
            this.grpConnectInfo.Controls.Add(this.txtDataBase);
            this.grpConnectInfo.Controls.Add(this.label3);
            this.grpConnectInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConnectInfo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpConnectInfo.Location = new System.Drawing.Point(0, 0);
            this.grpConnectInfo.Name = "grpConnectInfo";
            this.grpConnectInfo.Size = new System.Drawing.Size(1036, 112);
            this.grpConnectInfo.TabIndex = 4;
            this.grpConnectInfo.TabStop = false;
            this.grpConnectInfo.Text = "連線資訊";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(911, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(49, 28);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "連線";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(774, 28);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(120, 27);
            this.txtPwd.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(724, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "密碼:";
            // 
            // txtSid
            // 
            this.txtSid.Location = new System.Drawing.Point(630, 28);
            this.txtSid.Name = "txtSid";
            this.txtSid.Size = new System.Drawing.Size(88, 27);
            this.txtSid.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "帳號:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(93, 28);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(178, 27);
            this.txtServerName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "主機名稱:";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(379, 28);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(195, 27);
            this.txtDataBase.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "資料庫名稱:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeFormList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 420);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // treeFormList
            // 
            this.treeFormList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFormList.Location = new System.Drawing.Point(3, 23);
            this.treeFormList.Name = "treeFormList";
            this.treeFormList.Size = new System.Drawing.Size(245, 394);
            this.treeFormList.TabIndex = 0;
            this.treeFormList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFormList_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(251, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 420);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridForm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 316);
            this.panel2.TabIndex = 1;
            // 
            // gridForm
            // 
            this.gridForm.AllowUserToAddRows = false;
            this.gridForm.AllowUserToDeleteRows = false;
            this.gridForm.AllowUserToResizeColumns = false;
            this.gridForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.ColumnScript,
            this.ColumnTask,
            this.ColumnFormVersionId});
            this.gridForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridForm.Location = new System.Drawing.Point(0, 0);
            this.gridForm.MultiSelect = false;
            this.gridForm.Name = "gridForm";
            this.gridForm.RowTemplate.Height = 24;
            this.gridForm.Size = new System.Drawing.Size(779, 316);
            this.gridForm.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "VERSION";
            this.Column2.HeaderText = "表單版本";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ISSUE_TIME";
            this.Column3.HeaderText = "發佈時間";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // ColumnScript
            // 
            this.ColumnScript.HeaderText = "草稿筆數";
            this.ColumnScript.Name = "ColumnScript";
            this.ColumnScript.ReadOnly = true;
            // 
            // ColumnTask
            // 
            this.ColumnTask.HeaderText = "申請筆數";
            this.ColumnTask.Name = "ColumnTask";
            this.ColumnTask.ReadOnly = true;
            // 
            // ColumnFormVersionId
            // 
            this.ColumnFormVersionId.DataPropertyName = "FORM_VERSION_ID";
            this.ColumnFormVersionId.HeaderText = "FormVersionId";
            this.ColumnFormVersionId.Name = "ColumnFormVersionId";
            this.ColumnFormVersionId.ReadOnly = true;
            this.ColumnFormVersionId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 78);
            this.panel1.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(596, 17);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(161, 51);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "執行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "操作方式:";
            // 
            // cbOption
            // 
            this.cbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOption.FormattingEnabled = true;
            this.cbOption.Items.AddRange(new object[] {
            "刪除全系統所有表單版本/申請資料(僅保留最新發佈版本)",
            "刪除選取表單版本/申請資料(無法刪除最新發佈版本)",
            "刪除選取表單版本的所有申請資料"});
            this.cbOption.Location = new System.Drawing.Point(103, 31);
            this.cbOption.Name = "cbOption";
            this.cbOption.Size = new System.Drawing.Size(487, 24);
            this.cbOption.TabIndex = 0;
            this.cbOption.SelectedIndexChanged += new System.EventHandler(this.cbOption_SelectedIndexChanged);
            // 
            // ShangxianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpConnectInfo);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShangxianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表單版本初始小工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpConnectInfo.ResumeLayout(false);
            this.grpConnectInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridForm)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnectInfo;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeFormList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOption;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnScript;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFormVersionId;
    }
}

