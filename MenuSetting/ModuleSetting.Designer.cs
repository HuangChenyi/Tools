namespace MenuSetting
{
    partial class ModuleSetting
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnMenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpConnectInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpConnectInfo
            // 
            this.grpConnectInfo.Controls.Add(this.btnFolder);
            this.grpConnectInfo.Controls.Add(this.txtPath);
            this.grpConnectInfo.Controls.Add(this.label5);
            this.grpConnectInfo.Controls.Add(this.btnConnect);
            this.grpConnectInfo.Controls.Add(this.txtPwd);
            this.grpConnectInfo.Controls.Add(this.label4);
            this.grpConnectInfo.Controls.Add(this.txtSid);
            this.grpConnectInfo.Controls.Add(this.label2);
            this.grpConnectInfo.Controls.Add(this.txtServerName);
            this.grpConnectInfo.Controls.Add(this.label1);
            this.grpConnectInfo.Controls.Add(this.txtDataBase);
            this.grpConnectInfo.Controls.Add(this.label3);
            this.grpConnectInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpConnectInfo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpConnectInfo.Location = new System.Drawing.Point(0, 0);
            this.grpConnectInfo.Name = "grpConnectInfo";
            this.grpConnectInfo.Size = new System.Drawing.Size(353, 345);
            this.grpConnectInfo.TabIndex = 6;
            this.grpConnectInfo.TabStop = false;
            this.grpConnectInfo.Text = "連線資訊";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(238, 290);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(49, 28);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "連線";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(109, 177);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(178, 27);
            this.txtPwd.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "密碼:";
            // 
            // txtSid
            // 
            this.txtSid.Location = new System.Drawing.Point(109, 124);
            this.txtSid.Name = "txtSid";
            this.txtSid.Size = new System.Drawing.Size(178, 27);
            this.txtSid.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "帳號:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(109, 28);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(178, 27);
            this.txtServerName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "主機名稱:";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(109, 75);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(178, 27);
            this.txtDataBase.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "資料庫名稱:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(353, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 345);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPath.Location = new System.Drawing.Point(109, 229);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(178, 21);
            this.txtPath.TabIndex = 16;
            this.txtPath.Text = "C:\\POC\\UOF_Training\\UOF13.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "站台路徑:";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(297, 231);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(40, 23);
            this.btnFolder.TabIndex = 17;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
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
            this.dataGridView1.Size = new System.Drawing.Size(500, 319);
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
            // ModuleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 345);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpConnectInfo);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModuleSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModuleSetting";
            this.Load += new System.EventHandler(this.ModuleSetting_Load);
            this.grpConnectInfo.ResumeLayout(false);
            this.grpConnectInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnectInfo;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMenuId;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEnable;
    }
}

