using Ede.Uof.Utility.Data;
using Ede.Uof.WKF.Design;
using Ede.Uof.WKF.Design.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShangxianForm
{
    public partial class ShangxianForm : System.Windows.Forms.Form
    {
        ManageFormCategoryUCO m_manageFormCategoryUco = null;
        DesignFormVersionUCO designFromVersionUco = null;
        DBHelper db = new DBHelper();

        private bool m_IsReload = false;

        public bool IsReload {
            get { return m_IsReload; }
            set { m_IsReload = value; }
                }


        public ShangxianForm()
        {
            InitializeComponent();

            designFromVersionUco = new DesignFormVersionUCO();
            m_manageFormCategoryUco = new ManageFormCategoryUCO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("請先設定連線字串");
            }

  
            int leftIndex = connectionString.IndexOf("'");
            int rightIndex = connectionString.IndexOf("'", leftIndex + 1);
            txtServerName.Text = connectionString.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

            leftIndex = connectionString.IndexOf("'", rightIndex + 1);
            rightIndex = connectionString.IndexOf("'", leftIndex + 1);
            txtDataBase.Text = connectionString.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

            leftIndex = connectionString.IndexOf("'", rightIndex + 1);
            rightIndex = connectionString.IndexOf("'", leftIndex + 1);
            txtSid.Text = connectionString.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

            leftIndex = connectionString.IndexOf("'", rightIndex + 1);
            rightIndex = connectionString.IndexOf("'", leftIndex + 1);
            txtPwd.Text = connectionString.Substring(leftIndex + 1, rightIndex - leftIndex - 1);


            if(IsReload==true)
            {
                BindFormTree();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string ConnectString = string.Format("data source='{0}';initial catalog='{1}';User Id='{2}';Password='{3}';Max Pool Size=300", txtServerName.Text, txtDataBase.Text, txtSid.Text, txtPwd.Text);
            //先儲存資訊
            config.ConnectionStrings.ConnectionStrings["connectionstring"].ConnectionString = ConnectString;
         

            ConnectionStringSettings connStrSettings = new ConnectionStringSettings();
            connStrSettings.Name = "connectionstring";
            connStrSettings.ConnectionString = ConnectString;
            // connStrSettings.ProviderName = providerName;

         

            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
            

            designFromVersionUco = new DesignFormVersionUCO();
            m_manageFormCategoryUco = new ManageFormCategoryUCO();
            db = new DBHelper();

            //ShangxianForm form = new ShangxianForm();
            //form.IsReload = true;

           
            //form.Show( );

            //this.Hide();
            BindFormTree();


        }

        private void BindFormTree()
        {
            //之前所選擇的節點
         

            treeFormList.Nodes.Clear();
            FormCategoryDataSet formCategoryDs = this.m_manageFormCategoryUco.Query();

            foreach (DataRow categoryDr in formCategoryDs.FormCategory.Rows)
            {
                TreeNode pNode = new TreeNode();
                pNode.Tag = categoryDr["CATEGORY_ID"].ToString();
                pNode.Text = categoryDr["CATEGORY_NAME"].ToString();
           

                //查出類別下所有的表單
                foreach (DataRow formDr in formCategoryDs.Form.Select("CATEGORY_ID = '" + categoryDr["CATEGORY_ID"].ToString() + "'", "FORM_NAME"))
                {
                    TreeNode cNode = new TreeNode();
                    cNode.Tag = formDr["FORM_ID"].ToString();
                    cNode.Text = formDr["FORM_NAME"].ToString();
                   

                    pNode.Nodes.Add(cNode);
                }

                this.treeFormList.Nodes.Add(pNode);
            }

            //展開全部
            this.treeFormList.ExpandAll();

           
        }

        private void treeFormList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.treeFormList.SelectedNode != null)
            {
                BindGrid();

            }
        }

        private void BindGrid()
        {
            if (treeFormList.SelectedNode == null || treeFormList.SelectedNode.Tag.ToString() == "")
                return;
            string fromId = this.treeFormList.SelectedNode.Tag.ToString();
            FormVersionDataSet formVersionDs = this.designFromVersionUco.QueryFormAllVersion(fromId);
            gridForm.AutoGenerateColumns = false;
            gridForm.DataSource = formVersionDs.FormVersion;

            string usingVersionId = db.GetUsingVersionId(treeFormList.SelectedNode.Tag.ToString());

            foreach (DataGridViewRow row in gridForm.Rows)
            {
                string formVersionId = row.Cells["ColumnFormVersionId"].Value.ToString();

                row.Cells["ColumnScript"].Value = db.GetFormScriptConut(formVersionId);
                row.Cells["ColumnTask"].Value = db.GetFormTaskConut(formVersionId);

                if (formVersionId == usingVersionId && cbOption.SelectedIndex != 2)
                    row.Cells[0].ReadOnly = true;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {


            if (cbOption.SelectedIndex == -1)
                return;
           if( MessageBox.Show("此操作之不可逆之刪除行為\r\n請務必要備份好資料庫再進行!" ,  "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

               
             
                string usingVersionId = "";
                FormCategoryDataSet formCategoryDs = this.m_manageFormCategoryUco.Query();

                switch (cbOption.SelectedIndex)
                {
                    case 0:
                        //全砍只保留最新版本，且留第一版

                       
                        foreach (var formDr in formCategoryDs.Form)
                        {
                            FormVersionDataSet formVersionDs = this.designFromVersionUco.QueryFormAllVersion(formDr.FORM_ID);
                            usingVersionId = db.GetUsingVersionId(formDr.FORM_ID);
                           
                            foreach(var FormVersion in formVersionDs.FormVersion)
                            {

                                
                                if (FormVersion.VERSION < 1)
                                    //保留小於1版的表單
                                    //為了預防有從未發佈的表單被砍
                                    continue;

                                //DMS表單殺不得
                                switch(formDr.FORM_ID)
                                {
                                    case "DMSApprove":
                                    case "DMSLend":
                                    case "DMSVoid":
                                        db.DeleteFormScript(FormVersion.FORM_VERSION_ID);
                                        db.DeleteFormTask(FormVersion.FORM_VERSION_ID);
                                        continue;
                                       
                                }

                                db.DeleteFormScript(FormVersion.FORM_VERSION_ID);
                                db.DeleteFormTask(FormVersion.FORM_VERSION_ID);

                                //如果是發佈版本，只能砍申請資料
                                //並把版本切回1版
                                if (usingVersionId == FormVersion.FORM_VERSION_ID)
                                {
                                  

                                    
                                    db.UpdateFormVersion(FormVersion.FORM_VERSION_ID);
                                    continue;
                                }

                                WKF wkf = new WKF();
                                Ede.Uof.WKF.Design.SetupFlowUCO setFlowUco = new SetupFlowUCO();
                                wkf.DeleteFormVersion(FormVersion.FORM_VERSION_ID, setFlowUco, "admin");

                               
                            }
                        }

                            break;
                    case 1:
                        //砍選擇版本+申請表單
                    case 2:
                        //砍選擇版本表單

                        if (treeFormList.SelectedNode == null || treeFormList.SelectedNode.Tag.ToString() == "")
                            return;

                        usingVersionId = db.GetUsingVersionId(treeFormList.SelectedNode.Tag.ToString());
                        foreach (DataGridViewRow row in gridForm.Rows)
                        {
                            //打勾才作
                            if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                            {
                                string formVersionId = row.Cells["ColumnFormVersionId"].Value.ToString();
                                db.DeleteFormScript(formVersionId);
                                db.DeleteFormTask(formVersionId);
                                if (cbOption.SelectedIndex == 1)
                                {
                                    //WKF API有鎖未發佈表單
                                    WKF wkf = new WKF();
                                    Ede.Uof.WKF.Design.SetupFlowUCO setFlowUco = new SetupFlowUCO();
                                    wkf.DeleteFormVersion(formVersionId, setFlowUco, "admin");
                                }
                            }
                        }
                            break;
                }

                MessageBox.Show("處理結束，請立即登入系統確認");

                BindGrid();
            }
        }

        private void cbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
