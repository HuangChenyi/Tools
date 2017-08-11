using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ExternalFormGenerateV2
{
    public partial class ExternalFormGenerate : Form
    {
        SqlConnection m_conn = new SqlConnection();

        string versionFields= "";
        public ExternalFormGenerate()
        {
            InitializeComponent();
        }

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
            string ConnectString = string.Format("data source='{0}';initial catalog='{1}';User Id='{2}';Password='{3}';Max Pool Size=300", txtServerName.Text, txtDataBase.Text, txtSid.Text, txtPwd.Text);
            //先儲存資訊
            config.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = ConnectString;
            config.Save();
            m_conn = new SqlConnection(ConnectString);
            DisableControl();
            BindFormInfo();

            InitData();

        }

        private void InitData()
        {
            // throw new NotImplementedException();

            m_conn.Open();

            try
            {
                string cmdTxt = @"if not exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TB_CDS_EXTERNAL_FORM_MAPPING]') AND type in (N'U'))
                                begin
	                                CREATE TABLE TB_CDS_EXTERNAL_FORM_MAPPING
	                                (
FORM_ID nvarchar(50),
	                                FORM_VERSION_ID nvarchar(50),
                                EXTERNAL_TABLE_NAME nvarchar(max),
                                EXTERNAL_GRID_TABLES_NAME nvarchar(max),
ENABLED bit
	                                )
                                end
                                ";


                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);

                comm.ExecuteNonQuery();
            }
            catch (Exception ce)
            {
                MessageBox.Show("建立初始表單時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }


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
                comm.Parameters.AddWithValue("@FORM_ID", ((ItemList)cbxFormList.SelectedItem).Value);



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
            txtTableName.Text = "";
            BindGridFieldData();

            MessageBox.Show("請設定對應的資料表名稱");
        }

        private void BindGridFieldData()
        {
            versionFields = GetVersionFields();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(versionFields);

            XmlNodeList nodeList = xmlDoc.SelectNodes("./VersionField/FieldItem[@fieldType='dataGrid']");

            DataTable dt = new DataTable();
            dt.Columns.Add("FIELD_ID");
            dt.Columns.Add("FIELD_NAME");

            foreach (XmlNode node in nodeList)
            {
                DataRow dr = dt.NewRow();
                dr["FIELD_ID"] = node.Attributes["fieldId"].Value;
                dr["FIELD_NAME"] = node.Attributes["fieldName"].Value;

                dt.Rows.Add(dr);
            }

            gridTableName.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                grpDataGrid.Visible = false;
            }
            else
            {
                grpDataGrid.Visible = true;
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
            catch (Exception ce)
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

        private void btnGenerateSchema_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text == "")
            {
                MessageBox.Show("資料表名稱不可空白");
                return;
            }

            if (CheckTableNameIsExist(txtTableName.Text))
            {
                return;
            }


            DataGridFields grids = new DataGridFields();
            string json = "";

            if (gridTableName.Rows.Count>0)
            {
                
                foreach (DataGridViewRow row in gridTableName.Rows)
                {
                    DataGridList list = new DataGridList();
                    if (row.Cells["ColumnTableName"].Value == null)
                    {
                        MessageBox.Show("對應明細資料表名稱不可空白");
                        return;
                    }

                   string tableName = row.Cells["ColumnTableName"].Value.ToString().Trim();

                    if (tableName == "")
                    {
                        MessageBox.Show("對應明細資料表名稱不可空白");
                        return;
                    }

                    if (CheckTableNameIsExist(tableName))
                    {
                        return;
                    }
                    list.TableName = tableName;
                    list.FieldId = row.Cells["ColumnFieldId"].Value.ToString().Trim();
                    grids.DataGridList.Add(list);

                }

                json = JsonConvert.SerializeObject(grids);
            }


            //新增主表
            InsertFormMapping(((ItemList)cbxFormList.SelectedItem).Value,((ItemList)cbxFormVersion.SelectedItem).Value, txtTableName.Text, json, true);
            //新增表頭
            CreateFormFieldTable(txtTableName.Text, versionFields);
            //新增明細
            CreateGridFieldTable(grids,versionFields);

            MessageBox.Show("資料初始完成");

        }

        private void CreateGridFieldTable(DataGridFields grids, string versionFields)
        {
            foreach (DataGridList list in grids.DataGridList)
            {
                string cmdTxt = string.Format(@"CREATE TABLE [{0}]
(
EXTERNAL_TASK_ID	nvarchar(50),
GRID_SEQ	int
", list.TableName);


                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(versionFields);
                //明細欄位
                XmlNodeList nodeList = xmlDoc.SelectNodes(string.Format("./VersionField/FieldItem[@fieldId='{0}']/dataGrid/DataGridItem" , list.FieldId));

                foreach (XmlNode node in nodeList)
                {
                    cmdTxt += string.Format(@"  , [{0}] nvarchar(max)
                    ", node.Attributes["fieldId"].Value);

                }


                cmdTxt += " ) ";

                try
                {
                    m_conn.Open();
                    SqlCommand command = new SqlCommand(cmdTxt, m_conn);

                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    m_conn.Close();

                }
            }
        }

        private void CreateFormFieldTable(string tableName, string versionFields)
        {
            string cmdTxt = string.Format(@"CREATE TABLE [{0}]
(
EXTERNAL_TASK_ID	nvarchar(50),
URGENT_LEVEL	int,
APPLICANT	nvarchar(50),
GROUP_PATH	nvarchar(50),
JOB_TITLE_ID	nvarchar(50),
EXCEPTION_MSG	nvarchar(max),
ATTACH_PATH	nvarchar(max),
FORM_NUMBER	nvarchar(max),
TASK_ID	nvarchar(50),
STATUS	int ,
FORM_RESULT	int,
CREATE_TIME	datetime,
MODIFY_TIME	datetime
", tableName);
        

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(versionFields);
            //排除掉明細欄位
            XmlNodeList nodeList = xmlDoc.SelectNodes("./VersionField/FieldItem[@fieldType!='dataGrid']");

            foreach (XmlNode node in nodeList)
            {

                cmdTxt += string.Format(@"  , [{0}] nvarchar(max)
                    " , node.Attributes["fieldId"].Value);

            }


            cmdTxt += " ) ";

            try
            {
                m_conn.Open();
                SqlCommand command = new SqlCommand(cmdTxt, m_conn);
             
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                m_conn.Close();
   
            }
        }

        private void InsertFormMapping(string formId,string formVersionId, string tableName, string gridTables,bool enabled)
        {
            string cmdTxt = @"UPDATE TB_CDS_EXTERNAL_FORM_MAPPING
                              SET ENABLED=0
                            WHERE FORM_ID=@FORM_ID";
            SqlCommand command = null;
            try
            {
                m_conn.Open();
                command = new SqlCommand(cmdTxt, m_conn);
     
                command.Parameters.AddWithValue("@FORM_ID", formId);
       

                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                m_conn.Close();
            }

            cmdTxt = @"  INSERT INTO [dbo].[TB_CDS_EXTERNAL_FORM_MAPPING]  
(	
    [FORM_ID],
    [FORM_VERSION_ID] , 
	 [EXTERNAL_TABLE_NAME] , 
	 [EXTERNAL_GRID_TABLES_NAME]  ,
[ENABLED]
) 
 VALUES 
 (	 @FORM_ID,@FORM_VERSION_ID , 
	 @EXTERNAL_TABLE_NAME , 
	 @EXTERNAL_GRID_TABLES_NAME  ,@ENABLED
)";

            try
            {
                m_conn.Open();
                command = new SqlCommand(cmdTxt, m_conn);
                command.Parameters.AddWithValue("@FORM_VERSION_ID", formVersionId);
                command.Parameters.AddWithValue("@FORM_ID", formId);
                command.Parameters.AddWithValue("@EXTERNAL_GRID_TABLES_NAME", gridTables);
                command.Parameters.AddWithValue("@EXTERNAL_TABLE_NAME", tableName);
                command.Parameters.AddWithValue("@ENABLED", enabled);

                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                m_conn.Close();
            }
        }

        private bool CheckTableNameIsExist(string tableName)
        {

            m_conn.Open();


            try
            {
                string cmdTxt = @"(SELECT COUNT(1) FROM sys.objects WHERE object_id = OBJECT_ID(@TABLE_NAME) AND type in (N'U'))";

                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);
                comm.Parameters.AddWithValue("@TABLE_NAME", tableName);

                object obj = comm.ExecuteScalar();

                if (obj == null || obj == DBNull.Value)
                {
                    return false;
                }
                m_conn.Close();

                if (Convert.ToInt32(obj) > 0)
                {
                    MessageBox.Show( string.Format( "表單名稱重覆:{0}", tableName));
                    return true;
                }
                return false;
            }
            catch (Exception ce)
            {
                MessageBox.Show("判斷表單是否重覆時發生錯誤:" + ce.Message);
                m_conn.Close();
            }

            return false;
        }
    }
}
