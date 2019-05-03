using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace ExternalFormGenerate
{
    public partial class ExternalFormGenerate : Form
    {
        public ExternalFormGenerate()
        {
            InitializeComponent();
        }

        SqlConnection m_conn = new SqlConnection();

        private void ExternalFormGenerate_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("請先設定連線字串");
            }

            m_conn = new SqlConnection(connectionString);

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

        private void btnConnect_Click(object sender, EventArgs e)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string  ConnectString = string.Format("data source='{0}';initial catalog='{1}';User Id='{2}';Password='{3}';Max Pool Size=300", txtServerName.Text, txtDataBase.Text, txtSid.Text, txtPwd.Text);
            //先儲存資訊
            config.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = ConnectString;
            config.Save();
            m_conn = new SqlConnection(ConnectString);
            DisableControl();
            BindFormInfo();
        }

        private void BindFormInfo()
        {
            BindFormCategroyDDL();
            BindFormListDDL();
            BindFormVersionDLL();
        }

        private void BindFormVersionDLL()
        {
            if (cbxFormList.SelectedIndex == -1)
            {
                return;
            }

            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT 
                                        VERSION,
                                        FORM_VERSION_ID
                                        FROM TB_WKF_FORM_VERSION 
                                    WHERE
                                        FORM_ID=@FORM_ID";

                if (!cbxNonIssueForm.Checked)
                {
                    cmdTxt += " AND ISSUE_CTL=1 ";
                }

                cmdTxt += " ORDER BY VERSION DESC ";

                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);
                comm.Parameters.AddWithValue("@FORM_ID",  ((ItemList)cbxFormList.SelectedItem).Value);



                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                m_conn.Close();
                cbxFormVersion.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ItemList item = new ItemList(dr["VERSION"].ToString(), dr["FORM_VERSION_ID"].ToString());
                    cbxFormVersion.Items.Add(item);
                }

                if (cbxFormVersion.Items.Count > 0)
                {
                    cbxFormVersion.SelectedIndex = 0;
                }

            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單版本時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }
        }

        private void BindFormListDDL()
        {
            if (cbxFormCategory.SelectedIndex == -1)
            {
                return;
            }

            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT 
                                        FORM_ID,
                                        FORM_NAME
                                        FROM TB_WKF_FORM 
                                    WHERE
                                        CATEGORY_ID=@CATEGORY_ID";
                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);
                comm.Parameters.AddWithValue("@CATEGORY_ID", ((ItemList)cbxFormCategory.SelectedItem).Value);
                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                m_conn.Close();
                cbxFormList.Items.Clear();
                
                foreach (DataRow dr in dt.Rows)
                {
                    ItemList item = new ItemList(dr["FORM_NAME"].ToString(), dr["FORM_ID"].ToString());
                    cbxFormList.Items.Add(item);
                }

                if (cbxFormList.Items.Count > 0)
                {
                    cbxFormList.SelectedIndex = 0;
                }


            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單列表時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }

        }

        private void BindFormCategroyDDL()
        {
            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT CATEGORY_ID,CATEGORY_NAME FROM TB_WKF_FORM_CATEGORY";
                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);

                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                m_conn.Close();
                cbxFormCategory.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ItemList item = new ItemList(dr["CATEGORY_NAME"].ToString(), dr["CATEGORY_ID"].ToString());
                    cbxFormCategory.Items.Add(item);
                }

                if (cbxFormCategory.Items.Count > 0)
                {
                    cbxFormCategory.SelectedIndex = 0;
                }


            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單類別時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }


        }

        private void DisableControl()
        {
            grpConnectInfo.Enabled = false;
            grpFormIfno.Enabled = true;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            FormUtitlity formUtil = new FormUtitlity();
            txtFormCode.Text = "";
            string versionFields = GetVersionFields();

            if (versionFields != "")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(versionFields);

                txtFormCode.Text += formUtil.GetFormInfoXmlCode(((ItemList)cbxFormVersion.SelectedItem).Value);
                txtFormCode.Text += formUtil.GetApplicantXmlCode();
                txtFormCode.Text += formUtil.GetFormFieldValueXmlCode();
                XmlNodeList versionFieldList = xmlDoc.SelectNodes("/VersionField/FieldItem");

                foreach (XmlNode versionField in versionFieldList)
                {
                    txtFormCode.Text += formUtil.GetFieldXmlCode(versionField);
                }


                txtFormCode.Text += "   // return formElement.OuterXML;";
            }

        }



        private string GetVersionFields()
        {
            m_conn.Open();


            try
            {
                string cmdTxt = @"SELECT VERSION_FIELD FROM TB_WKF_FORM_VERSION
                                WHERE FORM_VERSION_ID = @FORM_VERSION_ID";

                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);
                comm.Parameters.AddWithValue("@FORM_VERSION_ID", ((ItemList)cbxFormVersion.SelectedItem).Value);

                object obj = comm.ExecuteScalar();

                if (obj == null || obj == DBNull.Value)
                {
                    return "";
                }
                m_conn.Close();
                return obj.ToString();
            }
            catch(Exception ce)
            {
                MessageBox.Show("取得表單結構時發生錯誤:" + ce.Message);
                m_conn.Close();
            }

         

            return "";
        }

        private void cbxFormCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFormListDDL();
            BindFormVersionDLL();
        }

        private void cbxFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFormVersionDLL();
        }

        private void cbxNonIssueForm_CheckedChanged(object sender, EventArgs e)
        {
            BindFormVersionDLL();
        }

        private void btnDLL_Click(object sender, EventArgs e)
        {
            FormUtitlity formUtil = new FormUtitlity();
            txtFormCode.Text = "";
            string versionFields = GetVersionFields();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(versionFields);

            txtFormCode.Text += formUtil.GetDLLInitCode();
            XmlNodeList versionFieldList = xmlDoc.SelectNodes("/VersionField/FieldItem");

            foreach (XmlNode versionField in versionFieldList)
            {
                txtFormCode.Text += formUtil.GetFieldDLLCode(versionField);
            }

        }

        private void btnSchema_Click(object sender, EventArgs e)
        {
            TableName tb = new TableName();

            if (tb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string tableName = tb.TableNames;
                string tableDescription = tb.TableDescription;

                FormUtitlity formUtil = new FormUtitlity();
                txtFormCode.Text = "";
                string versionFields = GetVersionFields();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(versionFields);

                txtFormCode.Text += 
@"CREATE TABLE " +tableName +@"
(";
                XmlNodeList versionFieldList = xmlDoc.SelectNodes("/VersionField/FieldItem");

                for (int i = 0; i < versionFieldList.Count; i++)
                {
                    XmlNode versionField = versionFieldList[i];
                    if (i == versionFieldList.Count - 1)
                    {
                        txtFormCode.Text += versionField.Attributes["fieldId"].Value + " nvarchar(255)" + "" + "--" + versionField.Attributes["fieldName"].Value + "\r\n";
                    }
                    else
                    {
                        txtFormCode.Text += versionField.Attributes["fieldId"].Value + " nvarchar(255)" + "," + "--" + versionField.Attributes["fieldName"].Value + "\r\n";
                    }
                }


                

                txtFormCode.Text += ")";

                 txtFormCode.Text += string.Format(@"
        EXEC sys.sp_addextendedproperty 
        @name=N'MS_Description', 
        @value=N'{0}' ,
        @level0type=N'SCHEMA', 
        @level0name=N'dbo', 
        @level1type=N'TABLE', 
        @level1name=N'{1}',
        @level2type=default, 
        @level2name=default
" , tableDescription, tableName );
                
                foreach (XmlNode versionField in versionFieldList)
                {


                    txtFormCode.Text += string.Format(@"
        EXEC sys.sp_addextendedproperty 
        @name=N'MS_Description', 
        @value=N'{0}' ,
        @level0type=N'SCHEMA', 
        @level0name=N'dbo', 
        @level1type=N'TABLE', 
        @level1name=N'{1}',
        @level2type=N'COLUMN', 
        @level2name=N'{2}'
", versionField.Attributes["fieldName"].Value, tableName, versionField.Attributes["fieldId"].Value );
                }

            }
        }

        private void txtFormCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
