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
using System.Xml;

namespace FormViewGenerate
{
    public partial class FormViewGenerate : Form
    {
        SqlConnection m_conn = new SqlConnection();
        public FormViewGenerate()
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
            m_conn = new SqlConnection(ConnectString);


            BindFormInfo();
            DisableControl();
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
                FormUtitlity formUtil = new FormUtitlity();
                DataTable dt = formUtil.GetFormVersionDt(((ItemList)cbxFormList.SelectedItem).Value, m_conn);

                
              
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
                FormUtitlity formUtitlity = new FormUtitlity();
                DataTable dt = formUtitlity.GetFormListDt(((ItemList)cbxFormCategory.SelectedItem).Value, m_conn);
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

                FormUtitlity formUtil = new FormUtitlity();
                DataTable dt= formUtil.GetFormCategoryDt(m_conn);

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

        private void FormViewGenerate_Load(object sender, EventArgs e)
        {
            if(DateTime.Today > DateTime.Parse("2020/04/01"))
            {
                MessageBox.Show("試用已過期");
                this.Close();
            }
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

        private void btnGenerateView_Click(object sender, EventArgs e)
        {
            FormUtitlity formUtil = new FormUtitlity();
            txtFormCode.Text = formUtil.GetViewSql(((ItemList)cbxFormVersion.SelectedItem).Value, cbxFormList.SelectedItem.ToString(), m_conn);
           
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
    }
}
