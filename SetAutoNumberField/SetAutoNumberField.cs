
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SetAutoNumberField
{
    public partial class SetAutoNumberField : Form
    {
        Ede.Uof.WKF.Design.ManageFormCategoryUCO m_manageFormCategoryUco = null;
        Ede.Uof.WKF.Design.DesignFormVersionUCO designFromVersionUco = null;
        DBHelper db = new DBHelper();

        public SetAutoNumberField()
        {
            InitializeComponent();
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


            designFromVersionUco = new Ede.Uof.WKF.Design.DesignFormVersionUCO();
            m_manageFormCategoryUco = new Ede.Uof.WKF.Design.ManageFormCategoryUCO();



            BindFormTree();
        }

        private void BindFormTree()
        {
            //之前所選擇的節點


            treeFormList.Nodes.Clear();
            Ede.Uof.WKF.Design.Data.FormCategoryDataSet formCategoryDs = this.m_manageFormCategoryUco.Query();

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

        private void SetAutoNumberField_Load(object sender, EventArgs e)
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
            Ede.Uof.WKF.Design.Data.FormVersionDataSet formVersionDs = this.designFromVersionUco.QueryFormAllVersion(fromId);
            gridForm.AutoGenerateColumns = false;
            gridForm.DataSource = formVersionDs.FormVersion;

            string usingVersionId = db.GetUsingVersionId(treeFormList.SelectedNode.Tag.ToString());

            foreach (DataGridViewRow row in gridForm.Rows)
            {
                string formVersionId = row.Cells["ColumnFormVersionId"].Value.ToString();

                XDocument xd = XDocument.Parse(row.Cells["ColumnVersionFields"].Value.ToString());

                var node = (from xl in xd.Elements("VersionField").Elements("FieldItem")
                            where xl.Attribute("fieldType").Value == "autoNumber"
                            select xl).FirstOrDefault();

                row.Cells["ColumnFile"].Value = node.Attribute("FieldFile").Value;
                row.Cells["ColumnType"].Value = node.Attribute("FieldFileType").Value;
                row.Cells["ColumnEnable"].Value = node.Attribute("FieldExternal").Value;

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridForm.Rows)
            {
                string formVersionId = row.Cells["ColumnFormVersionId"].Value.ToString();

                XDocument xd = XDocument.Parse(row.Cells["ColumnVersionFields"].Value.ToString());

                var node = (from xl in xd.Elements("VersionField").Elements("FieldItem")
                            where xl.Attribute("fieldType").Value == "autoNumber"
                            select xl).FirstOrDefault();

                node.Attribute("FieldFile").Value = row.Cells["ColumnFile"].Value.ToString();
                node.Attribute("FieldFileType").Value = row.Cells["ColumnType"].Value.ToString();
                node.Attribute("FieldExternal").Value = row.Cells["ColumnEnable"].Value.ToString();

                db.UpdateFormVersionField(formVersionId, xd.ToString());

            }

            MessageBox.Show("儲存成功!");
        }
    }
}
