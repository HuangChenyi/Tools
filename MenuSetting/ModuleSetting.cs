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
using System.Xml;
using System.Xml.Linq;

namespace MenuSetting
{
    public partial class ModuleSetting : Form
    {
        public ModuleSetting()
        {
            InitializeComponent();
        }

        private void ModuleSetting_Load(object sender, EventArgs e)
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

            if(txtPath.Text == "")
            {
                MessageBox.Show("請先設定UOF站台路徑");
                return;
            }

            BindGrid();

        }

        private void BindGrid()
        {
            string fileName = txtPath.Text + "/App_data/menu.xml";

            XmlDocument xd = new XmlDocument();
            xd.Load(fileName);
            DBHelper db = new DBHelper();
            MenuDataSet ds = db.GetMenuData();

            DataTable dt = new DataTable();
            dt.Columns.Add("MENU_ID");
            dt.Columns.Add("MENU_NAME");
            dt.Columns.Add("STATUS");
            foreach (var dr in ds.TB_EB_MENU.Where(p=>p.TYPE =="Module").OrderBy(p=>p.MENU_ID))
            {
                string status = "";
                string menuId = "";
                if (dr.MENU_ID.IndexOf('_') == 0)
                {
                    status = "不啟用";
                    menuId = dr.MENU_ID.Substring(1);
                }
                else
                {
                    status = "啟用";
                    menuId = dr.MENU_ID;
                }

                string menuName = "";

                try
                {
                    menuName = xd.SelectSingleNode($"./Menus/menu[@id='{menuId}']/culture[@name='zh-tw']").InnerText;
                }
                catch {
                    menuName = menuId;
                }
                dt.Rows.Add(menuId,menuName,status);
            }

            dt.DefaultView.Sort = "MENU_ID ASC";
            dataGridView1.DataSource = dt;

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
           if( folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //     MessageBox.Show($"{ dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()}");
            //Button的INDEX為0
            if (e.ColumnIndex == 0)
            {
                string menuId = dataGridView1.Rows[e.RowIndex].Cells["ColumnMenuId"].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells["ColumnStatus"].Value.ToString();

                DBHelper db = new DBHelper();

                if (status == "不啟用")
                {
                    db.UpdateMenuStatus(menuId,"_"+menuId);
                }
                else
                {
                    db.UpdateMenuStatus("_" + menuId, menuId);
                }

                BindGrid();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                string menuId = dataGridView1.Rows[e.RowIndex].Cells["ColumnMenuId"].Value.ToString();

                GroupSetting gs = new GroupSetting(menuId, txtPath.Text);
             
                gs.ShowDialog();

             
              
            }
        }
    }
}
