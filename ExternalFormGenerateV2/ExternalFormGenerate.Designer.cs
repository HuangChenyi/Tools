namespace ExternalFormGenerateV2
{
    partial class ExternalFormGenerate
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.grpConnectInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpFormIfno = new System.Windows.Forms.GroupBox();
            this.btnGenerateSchema = new System.Windows.Forms.Button();
            this.cbxFormCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerateSetting = new System.Windows.Forms.Button();
            this.cbxNonIssueForm = new System.Windows.Forms.CheckBox();
            this.cbxFormVersion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFormList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpTableName = new System.Windows.Forms.GroupBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpDataGrid = new System.Windows.Forms.GroupBox();
            this.gridTableName = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFieldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpConnectInfo.SuspendLayout();
            this.grpFormIfno.SuspendLayout();
            this.grpTableName.SuspendLayout();
            this.grpDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTableName)).BeginInit();
            this.SuspendLayout();
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
            this.grpConnectInfo.Size = new System.Drawing.Size(1027, 112);
            this.grpConnectInfo.TabIndex = 3;
            this.grpConnectInfo.TabStop = false;
            this.grpConnectInfo.Text = "連線資訊";
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
            // grpFormIfno
            // 
            this.grpFormIfno.Controls.Add(this.btnGenerateSchema);
            this.grpFormIfno.Controls.Add(this.cbxFormCategory);
            this.grpFormIfno.Controls.Add(this.label7);
            this.grpFormIfno.Controls.Add(this.btnGenerateSetting);
            this.grpFormIfno.Controls.Add(this.cbxNonIssueForm);
            this.grpFormIfno.Controls.Add(this.cbxFormVersion);
            this.grpFormIfno.Controls.Add(this.label6);
            this.grpFormIfno.Controls.Add(this.cbxFormList);
            this.grpFormIfno.Controls.Add(this.label5);
            this.grpFormIfno.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFormIfno.Enabled = false;
            this.grpFormIfno.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpFormIfno.Location = new System.Drawing.Point(0, 112);
            this.grpFormIfno.Name = "grpFormIfno";
            this.grpFormIfno.Size = new System.Drawing.Size(1027, 112);
            this.grpFormIfno.TabIndex = 6;
            this.grpFormIfno.TabStop = false;
            this.grpFormIfno.Text = "表單資訊";
            // 
            // btnGenerateSchema
            // 
            this.btnGenerateSchema.Location = new System.Drawing.Point(879, 46);
            this.btnGenerateSchema.Name = "btnGenerateSchema";
            this.btnGenerateSchema.Size = new System.Drawing.Size(129, 28);
            this.btnGenerateSchema.TabIndex = 23;
            this.btnGenerateSchema.Text = "產生對應資料表";
            this.btnGenerateSchema.UseVisualStyleBackColor = true;
            this.btnGenerateSchema.Click += new System.EventHandler(this.btnGenerateSchema_Click);
            // 
            // cbxFormCategory
            // 
            this.cbxFormCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormCategory.FormattingEnabled = true;
            this.cbxFormCategory.Location = new System.Drawing.Point(90, 42);
            this.cbxFormCategory.Name = "cbxFormCategory";
            this.cbxFormCategory.Size = new System.Drawing.Size(180, 24);
            this.cbxFormCategory.TabIndex = 22;
            this.cbxFormCategory.SelectedIndexChanged += new System.EventHandler(this.cbxFormCategory_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "表單類別:";
            // 
            // btnGenerateSetting
            // 
            this.btnGenerateSetting.Location = new System.Drawing.Point(879, 13);
            this.btnGenerateSetting.Name = "btnGenerateSetting";
            this.btnGenerateSetting.Size = new System.Drawing.Size(129, 28);
            this.btnGenerateSetting.TabIndex = 20;
            this.btnGenerateSetting.Text = "產生設定資訊";
            this.btnGenerateSetting.UseVisualStyleBackColor = true;
            this.btnGenerateSetting.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // cbxNonIssueForm
            // 
            this.cbxNonIssueForm.AutoSize = true;
            this.cbxNonIssueForm.Location = new System.Drawing.Point(743, 46);
            this.cbxNonIssueForm.Name = "cbxNonIssueForm";
            this.cbxNonIssueForm.Size = new System.Drawing.Size(139, 20);
            this.cbxNonIssueForm.TabIndex = 19;
            this.cbxNonIssueForm.Text = "包含未發佈版本";
            this.cbxNonIssueForm.UseVisualStyleBackColor = true;
            this.cbxNonIssueForm.Visible = false;
            // 
            // cbxFormVersion
            // 
            this.cbxFormVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormVersion.FormattingEnabled = true;
            this.cbxFormVersion.Location = new System.Drawing.Point(628, 42);
            this.cbxFormVersion.Name = "cbxFormVersion";
            this.cbxFormVersion.Size = new System.Drawing.Size(96, 24);
            this.cbxFormVersion.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "表單版本:";
            // 
            // cbxFormList
            // 
            this.cbxFormList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormList.FormattingEnabled = true;
            this.cbxFormList.Location = new System.Drawing.Point(358, 42);
            this.cbxFormList.Name = "cbxFormList";
            this.cbxFormList.Size = new System.Drawing.Size(180, 24);
            this.cbxFormList.TabIndex = 16;
            this.cbxFormList.SelectedIndexChanged += new System.EventHandler(this.cbxFormList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "表單名稱:";
            // 
            // grpTableName
            // 
            this.grpTableName.Controls.Add(this.txtTableName);
            this.grpTableName.Controls.Add(this.label8);
            this.grpTableName.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTableName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpTableName.Location = new System.Drawing.Point(0, 224);
            this.grpTableName.Name = "grpTableName";
            this.grpTableName.Size = new System.Drawing.Size(302, 269);
            this.grpTableName.TabIndex = 7;
            this.grpTableName.TabStop = false;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(93, 46);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(178, 27);
            this.txtTableName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "資料表名稱:";
            // 
            // grpDataGrid
            // 
            this.grpDataGrid.Controls.Add(this.gridTableName);
            this.grpDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpDataGrid.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpDataGrid.Location = new System.Drawing.Point(302, 224);
            this.grpDataGrid.Name = "grpDataGrid";
            this.grpDataGrid.Size = new System.Drawing.Size(489, 269);
            this.grpDataGrid.TabIndex = 8;
            this.grpDataGrid.TabStop = false;
            this.grpDataGrid.Text = "明細欄位列表";
            // 
            // gridTableName
            // 
            this.gridTableName.AllowUserToAddRows = false;
            this.gridTableName.AllowUserToDeleteRows = false;
            this.gridTableName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTableName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColumnFieldId,
            this.ColumnTableName});
            this.gridTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTableName.Location = new System.Drawing.Point(3, 23);
            this.gridTableName.Name = "gridTableName";
            this.gridTableName.RowTemplate.Height = 24;
            this.gridTableName.Size = new System.Drawing.Size(483, 243);
            this.gridTableName.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(791, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 269);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FIELD_NAME";
            this.Column1.HeaderText = "明細欄位名稱";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 140;
            // 
            // ColumnFieldId
            // 
            this.ColumnFieldId.DataPropertyName = "FIELD_ID";
            this.ColumnFieldId.HeaderText = "fieldId";
            this.ColumnFieldId.Name = "ColumnFieldId";
            this.ColumnFieldId.Visible = false;
            // 
            // ColumnTableName
            // 
            this.ColumnTableName.HeaderText = "對應資料表名稱";
            this.ColumnTableName.Name = "ColumnTableName";
            this.ColumnTableName.Width = 300;
            // 
            // ExternalFormGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 493);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpDataGrid);
            this.Controls.Add(this.grpTableName);
            this.Controls.Add(this.grpFormIfno);
            this.Controls.Add(this.grpConnectInfo);
            this.Name = "ExternalFormGenerate";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExternalFormGenerate_Load);
            this.grpConnectInfo.ResumeLayout(false);
            this.grpConnectInfo.PerformLayout();
            this.grpFormIfno.ResumeLayout(false);
            this.grpFormIfno.PerformLayout();
            this.grpTableName.ResumeLayout(false);
            this.grpTableName.PerformLayout();
            this.grpDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTableName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.GroupBox grpConnectInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpFormIfno;
        private System.Windows.Forms.Button btnGenerateSchema;
        private System.Windows.Forms.ComboBox cbxFormCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenerateSetting;
        private System.Windows.Forms.CheckBox cbxNonIssueForm;
        private System.Windows.Forms.ComboBox cbxFormVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFormList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpTableName;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpDataGrid;
        private System.Windows.Forms.DataGridView gridTableName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFieldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableName;
    }
}

