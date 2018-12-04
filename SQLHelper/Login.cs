using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace SQLHelper
{
    public partial class Login : Form
    {

        public string ConnectString = "";
        public string DBName = "";
        public bool IsFirstLogin = true;

        public Login()
        {
            InitializeComponent();
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            if ( ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString != "")
            {
                //data source='{0}';initial catalog='{1}';User Id='{2}';Password='{3}'
                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                int leftIndex = conn.IndexOf("'");
                int rightIndex = conn.IndexOf("'", leftIndex +1);
                txtServer.Text = conn.Substring(leftIndex + 1, rightIndex-leftIndex-1);

                leftIndex = conn.IndexOf("'", rightIndex + 1);
                rightIndex = conn.IndexOf("'", leftIndex + 1);
                string catalog = conn.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

                leftIndex = conn.IndexOf("'", rightIndex + 1);
                rightIndex = conn.IndexOf("'", leftIndex + 1);
                txtSid.Text = conn.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

                leftIndex = conn.IndexOf("'", rightIndex + 1);
                rightIndex = conn.IndexOf("'", leftIndex + 1);
                txtPwd.Text = conn.Substring(leftIndex + 1, rightIndex - leftIndex - 1);

                GetAllDataBase();
                Query = false;

                cbxDB.SelectedText = catalog;
                cbxDB.SelectedValue = catalog;

            }

        }

        bool Query = true;

        /// <summary>
        /// 取得所有資料庫
        /// </summary>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/4/9 下午 05:22 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        private void GetAllDataBase()
        {
            Utitlty utitlty = new Utitlty();
            DataTable dt = utitlty.GetAllDB(txtServer.Text, txtSid.Text, txtPwd.Text);

            cbxDB.DataSource = dt;
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            Query = true;
        }

        private void txtSid_TextChanged(object sender, EventArgs e)
        {
            Query = true;
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            Query = true;
        }

        private void cbxDB_MouseDown(object sender, MouseEventArgs e)
        {
            if (Query)
            {
                GetAllDataBase();
                Query = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConnectString = string.Format("data source='{0}';initial catalog='{1}';User Id='{2}';Password='{3}';Max Pool Size=300", txtServer.Text, cbxDB.SelectedValue.ToString(), txtSid.Text, txtPwd.Text);
            DBName = cbxDB.SelectedValue.ToString();
            this.DialogResult = DialogResult.OK;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            config.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = ConnectString;
            config.Save();
        
            

            this.Close();
        }

        private void cbxDB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
