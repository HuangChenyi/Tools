using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPMFieldCopyTool
{
    public partial class Form1 : Form
    {
        SqlConnection m_conn = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FieldInfo fieldInfo = new FieldInfo();
            fieldInfo.Dock = DockStyle.Top;

            
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

         
                    cmdTxt += " AND ISSUE_CTL=0 ";
                

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

        private void Form1_Load(object sender, EventArgs e)
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

        private void cbxFormCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFormListDDL();
            BindFormVersionDLL();

         
         
        }

        private void cbxFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFormVersionDLL();

            if (cbxFormVersion.Items.Count == 0)
            {
               // MessageBox.Show("該表單沒有未發佈的表單版本!");
            }
        }

        private void btnGenerateForm_Click(object sender, EventArgs e)
        {
            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT VERSION_FIELD,LAYOUT FROM TB_WKF_FORM_VERSION
                                        WHERE FORM_VERSION_ID=@FORM_VERSION_ID";
                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);

                comm.Parameters.AddWithValue("FORM_VERSION_ID", ((ItemList)cbxFormVersion.SelectedItem).Value);

                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());


                string versionFieldXML = dt.Rows[0]["VERSION_FIELD"].ToString();
                string layJosn = dt.Rows[0]["LAYOUT"].ToString();

                FormJsonObj formObj = Newtonsoft.Json.JsonConvert.DeserializeObject<FormJsonObj>(layJosn);




            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單欄位時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }
        }
    }
}
