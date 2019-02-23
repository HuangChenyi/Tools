using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSetting
{
    public  class DBHelper
    {
        private string connStr = "";

        public DBHelper()
        {
            connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public MenuDataSet GetMenuData()
        {

            SqlConnection connect = new SqlConnection(connStr);
            string cmdTxt = @" SELECT 
	 [MENU_ID] , 
	 [PARENT_MENU_ID] , 
	 [LINK_URL] , 
	 [IS_NEW_WINDOW] , 
	 [NORMAL_ICON_URL] , 
	 [MOUSE_OVER_ICON_URL] , 
	 [TYPE] , 
	 [DATA_KEY] , 
	 [ORDERS]  
 FROM [dbo].[TB_EB_MENU] ";
            MenuDataSet ds = new MenuDataSet();
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);

              
                ds.Load(command.ExecuteReader(), LoadOption.OverwriteChanges , ds.TB_EB_MENU);
            }
            catch
            {
                throw;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
            return ds;

        }

        internal MenuDataSet GetMenuData(string menuId)
        {
            SqlConnection connect = new SqlConnection(connStr);
            string cmdTxt = @" SELECT 
	 [MENU_ID] , 
	 [PARENT_MENU_ID] , 
	 [LINK_URL] , 
	 [IS_NEW_WINDOW] , 
	 [NORMAL_ICON_URL] , 
	 [MOUSE_OVER_ICON_URL] , 
	 [TYPE] , 
	 [DATA_KEY] , 
	 [ORDERS]  
 FROM [dbo].[TB_EB_MENU]
WHERE PARENT_MENU_ID = @PARENT_MENU_ID OR PARENT_MENU_ID= @PARENT_MENU_IDW";
            MenuDataSet ds = new MenuDataSet();
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);

                command.Parameters.AddWithValue("PARENT_MENU_ID", menuId);
                command.Parameters.AddWithValue("PARENT_MENU_IDW", "_"+menuId);
                ds.Load(command.ExecuteReader(), LoadOption.OverwriteChanges, ds.TB_EB_MENU);
            }
            catch
            {
                throw;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
            return ds;
        }

        internal void UpdateMenuStatus(string menuId, string menuIdW)
        {
            SqlConnection connect = new SqlConnection(connStr);
            string cmdTxt = @"  UPDATE [dbo].[TB_EB_MENU]  
 SET 
	 [MENU_ID] = @MENU_ID  

WHERE 
	[MENU_ID] = @MENU_IDW";

            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);
                command.Parameters.AddWithValue("@MENU_IDW", menuIdW);
                command.Parameters.AddWithValue("@MENU_ID", menuId);
                command.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }

        }
    }
}
