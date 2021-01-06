namespace BPMFieldCopyTool
{
    partial class Form1
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
            this.grpFormIfno = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbxFormCategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerateForm = new System.Windows.Forms.Button();
            this.cbxFormVersion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFormList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFieldCollection = new System.Windows.Forms.Panel();
            this.gbFieldCollection = new System.Windows.Forms.GroupBox();
            this.grpConnectInfo.SuspendLayout();
            this.grpFormIfno.SuspendLayout();
            this.gbFieldCollection.SuspendLayout();
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
            this.grpConnectInfo.Size = new System.Drawing.Size(1030, 76);
            this.grpConnectInfo.TabIndex = 1;
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
            // grpFormIfno
            // 
            this.grpFormIfno.Controls.Add(this.btnCopy);
            this.grpFormIfno.Controls.Add(this.cbxFormCategory);
            this.grpFormIfno.Controls.Add(this.label7);
            this.grpFormIfno.Controls.Add(this.btnGenerateForm);
            this.grpFormIfno.Controls.Add(this.cbxFormVersion);
            this.grpFormIfno.Controls.Add(this.label6);
            this.grpFormIfno.Controls.Add(this.cbxFormList);
            this.grpFormIfno.Controls.Add(this.label5);
            this.grpFormIfno.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFormIfno.Enabled = false;
            this.grpFormIfno.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpFormIfno.Location = new System.Drawing.Point(0, 76);
            this.grpFormIfno.Name = "grpFormIfno";
            this.grpFormIfno.Size = new System.Drawing.Size(1030, 112);
            this.grpFormIfno.TabIndex = 3;
            this.grpFormIfno.TabStop = false;
            this.grpFormIfno.Text = "表單資訊";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(868, 78);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(140, 28);
            this.btnCopy.TabIndex = 24;
            this.btnCopy.Text = "複製欄位";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            // btnGenerateForm
            // 
            this.btnGenerateForm.Location = new System.Drawing.Point(868, 26);
            this.btnGenerateForm.Name = "btnGenerateForm";
            this.btnGenerateForm.Size = new System.Drawing.Size(140, 28);
            this.btnGenerateForm.TabIndex = 20;
            this.btnGenerateForm.Text = "建立表單";
            this.btnGenerateForm.UseVisualStyleBackColor = true;
            this.btnGenerateForm.Click += new System.EventHandler(this.btnGenerateForm_Click);
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
            // pnlFieldCollection
            // 
            this.pnlFieldCollection.AutoScroll = true;
            this.pnlFieldCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFieldCollection.Location = new System.Drawing.Point(3, 18);
            this.pnlFieldCollection.Name = "pnlFieldCollection";
            this.pnlFieldCollection.Size = new System.Drawing.Size(1024, 540);
            this.pnlFieldCollection.TabIndex = 5;
            // 
            // gbFieldCollection
            // 
            this.gbFieldCollection.Controls.Add(this.pnlFieldCollection);
            this.gbFieldCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFieldCollection.Location = new System.Drawing.Point(0, 188);
            this.gbFieldCollection.Name = "gbFieldCollection";
            this.gbFieldCollection.Size = new System.Drawing.Size(1030, 561);
            this.gbFieldCollection.TabIndex = 4;
            this.gbFieldCollection.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 749);
            this.Controls.Add(this.gbFieldCollection);
            this.Controls.Add(this.grpFormIfno);
            this.Controls.Add(this.grpConnectInfo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BPM表單欄位複製小工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpConnectInfo.ResumeLayout(false);
            this.grpConnectInfo.PerformLayout();
            this.grpFormIfno.ResumeLayout(false);
            this.grpFormIfno.PerformLayout();
            this.gbFieldCollection.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpFormIfno;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbxFormCategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenerateForm;
        private System.Windows.Forms.ComboBox cbxFormVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFormList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlFieldCollection;
        private System.Windows.Forms.GroupBox gbFieldCollection;
    }
}

