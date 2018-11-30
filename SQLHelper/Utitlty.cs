using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SQLHelper
{
    public class Utitlty
    {

        private string m_ConnectString = "";

        public Utitlty()
        {
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            m_ConnectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        }


        /// <summary>
        /// 取得所有資料庫
        /// </summary>
        /// <param name="serverName">伺服器名稱</param>
        /// <param name="sid"> 帳號 </param>
        /// <param name="pwd"> 密碼 </param>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/4/9 下午 05:27 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        internal DataTable GetAllDB(string serverName, string sid, string pwd)
        {
            SqlConnection conn = new SqlConnection(string.Format("data source='{0}';User Id='{1}';Password='{2}';Max Pool Size=300" , serverName , sid , pwd));
            DataTable dt = new DataTable();

            string cmdTxt = @"       SELECT  DB_NAME(dbid)AS DATABASE_NAME
FROM sysdatabases
ORDER BY dbid";

//            SELECT dbid, DB_NAME(dbid)AS DB_NAME
//FROM sysdatabases
//ORDER BY dbid


            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(cmdTxt , conn);
                dt.Load(command.ExecuteReader(), LoadOption.OverwriteChanges);
            }
            catch {  }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            return dt;

        }


        /// <summary>
        /// 取得所有資料表
        /// </summary>
        /// <returns>請說明此回傳值的定義</returns>
        /// <remarks>
        /// * 新 增 者： chinyi(2010/6/14 上午 11:00 )
        /// * 修 改 者：
        /// * 修 改 者：
        /// * 修 改 者：
        /// </remarks>
        internal DataTable GetALLTable()
        {
            string cmdTxt = @"exec sys.sp_tables null , 'dbo'  ,null , null , 1";
            SqlConnection conn = new SqlConnection(m_ConnectString);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(cmdTxt, conn);
                dt.Load(command.ExecuteReader(), LoadOption.OverwriteChanges);
            }
            catch(Exception ce) { }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            return dt;


        }

        /// <summary>
        /// 取得所有資料行
        /// </summary>
        /// <param name="tableName">資料行名稱</param>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/6/14 下午 01:29 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        internal DataTable GetALLColumns(string tableName)
        {
            string cmdTxt = @"
        SELECT  TABLE_NAME,
				COLUMN_NAME,
				DATA_TYPE,
				CASE DATA_TYPE
					WHEN 'image' THEN 0
					WHEN 'text' THEN 0
					WHEN 'ntext' THEN 0
					WHEN 'datetime' THEN 0
					ELSE ISNULL( CHARACTER_MAXIMUM_LENGTH, 0 ) 
					END AS LENGTH,
				IS_NULLABLE AS IS_NULL,
				CASE ( SELECT count(*)
								FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
								INNER JOIN  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
								      ON c.TABLE_NAME = pk.TABLE_NAME 
									AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
								WHERE pk.TABLE_NAME = @TableName  
	 								AND c.COLUMN_NAME =  a.COLUMN_NAME
	 								AND CONSTRAINT_TYPE = 'PRIMARY KEY' )
					WHEN 0 THEN 'NO'
					 ELSE   'YES'
					 END AS IS_PK,
				(SELECT top 1 [value]
				  FROM sys.extended_properties e  
				  INNER JOIN sysobjects  t   ON e.major_id = t.id
				  INNER JOIN syscolumns c ON e.minor_id = c.colid  AND c.id = t.id
					WHERE e.name = 'MS_Description'
					AND  t.name = @TableName
					AND  c.name =  a.COLUMN_NAME) AS SUMMARY,
					CASE DATA_TYPE
						 WHEN 'char'		THEN 'string'
						 WHEN 'varchar'     THEN 'string'
						 WHEN 'nchar'		THEN 'string'
						 WHEN 'nvarchar'    THEN 'string'
						 WHEN 'text'	    THEN 'string'
						 WHEN 'ntext'		THEN 'string'
						 WHEN 'xml'		    THEN 'string'
						 WHEN 'datetime'    THEN 'DateTime'
						 WHEN 'int'			THEN 'int'
						 WHEN 'float'		THEN 'double'
						 WHEN 'numeric'	    THEN 'double'
						 WHEN 'money'	    THEN 'double'
						 ELSE '' 
						 END CsType						
                FROM INFORMATION_SCHEMA.COLUMNS  a						
                WHERE TABLE_NAME = @TableName
                ORDER BY ORDINAL_POSITION
        ";
            SqlConnection conn = new SqlConnection(m_ConnectString);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(cmdTxt, conn);
                command.Parameters.AddWithValue("@TableName", tableName);
                dt.Load(command.ExecuteReader(), LoadOption.OverwriteChanges);
            }
            catch(Exception ce) { }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            return dt;
        }
    }
}
