using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MenuSetting
{
    public partial class GroupSetting : Form
    {
        private string menuId;
        private string path;

        public GroupSetting()
        {
            InitializeComponent();
        }

        public GroupSetting(string menuId, string path)
        {
            InitializeComponent();
            this.menuId = menuId;
            this.path = path;
            
        }

        private void GroupSetting_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {

            string fileName = path + "/App_data/menu.xml";

            XmlDocument xd = new XmlDocument();
            xd.Load(fileName);

            DBHelper db = new DBHelper();
            MenuDataSet ds= db.GetMenuData(menuId);

            DataTable dt = new DataTable();
            dt.Columns.Add("MENU_ID");
            dt.Columns.Add("MENU_NAME");
            dt.Columns.Add("STATUS");
            foreach (var dr in ds.TB_EB_MENU.OrderBy(p => p.MENU_ID))
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
                catch
                {
                    menuName = menuId;
                }
                dt.Rows.Add(menuId, menuName, status);
            }

            dt.DefaultView.Sort = "MENU_ID ASC";
            dataGridView1.DataSource = dt;

        }

       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string menuId = dataGridView1.Rows[e.RowIndex].Cells["ColumnMenuId"].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells["ColumnStatus"].Value.ToString();

                DBHelper db = new DBHelper();

                if (status == "不啟用")
                {
                    db.UpdateMenuStatus(menuId, "_" + menuId);
                }
                else
                {
                    db.UpdateMenuStatus("_" + menuId, menuId);
                }

                BindGrid();
            }
        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                string menuId = dataGridView1.Rows[e.RowIndex].Cells["ColumnMenuId"].Value.ToString();

                GroupSetting gs = new GroupSetting(menuId, path);

                gs.ShowDialog();



            }
        }
    }
}
