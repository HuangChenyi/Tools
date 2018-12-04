using System;
using System.Collections.Generic;
using System.Text;

namespace SQLHelper
{
    public static class CSharpCommand
    {
        /// <summary>
        /// 取得SQL指令
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="commandType">命名型態</param>
        /// <param name="Columns"> 欄位集合 </param>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/6/14 下午 03:13 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        public static string GetCommandText(string tableName, string commandType, List<string> Columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( " string cmdTxt = @\"");
            sb.Append(SQLCommand.GetCommandText(tableName, commandType, Columns));
            sb.Append("\";\r\n\r\n");

            switch (commandType)
            {
                case "SELECT":
                    sb.Append("DataTable dt = new DataTable();\r\n");
                    sb.Append("dt.Load(this.m_db.ExecuteReader(cmdTxt) , LoadOption.OverwriteChanges);\r\n");
                    sb.Append("return dt;\r\n");

                    break;
                case "INSERT":
                    sb.Append(GetPramaString(Columns , new List<string>()));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    break;
                case "UPDATE":
                    sb.Append(GetPramaString(Columns, new List<string>()));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    break;
                case "DELETE":
                   // sb.Append(GetPramaString(Columns, new List<string>()));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    break;

            }

            return sb.ToString();
        }


        private static string GetPramaString(List<string> Columns, List<string> Conditions)
        { 
            StringBuilder sb = new StringBuilder();

            foreach (string column in Columns)
            {
                sb.Append(string.Format("this.m_db.AddParameter(\"@{0}\", dr.{0} );\r\n", column));
            }

            foreach (string condition in Conditions)
            {
                if (!Columns.Contains(condition))
                {
                    sb.Append(string.Format("this.m_db.AddParameter(\"@{0}\", dr.{0} );\r\n", condition));
                }
            }
            

            return sb.ToString();
        }

        /// <summary>
        /// 取得刪除語法
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/6/15 下午 03:41 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        private static string GetDeleteCommand(string tableName)
        {
            return string.Format(" DELETE [dbo].[{0}] ", tableName);
        }


        /// <summary>
        /// 取得SQL指令
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="CommandType">命名型態</param>
        /// <param name="columnList"> 欄位集合 </param>
        /// <param name="conditionList"> 條件集合 </param>
        /// <returns>請說明此回傳值的定義</returns>
        /// <remarks>
        /// * 新 增 者： chinyi(2010/6/28 下午 03:01 )
        /// * 修 改 者：
        /// * 修 改 者：
        /// * 修 改 者：
        /// </remarks>
        internal static string GetCommandText(string TableName, string CommandType, List<string> columnList, List<string> conditionList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" string cmdTxt = @\"");
            sb.Append(SQLCommand.GetCommandText(TableName, CommandType, columnList, conditionList));
            sb.Append("\";\r\n\r\n");

            switch (CommandType)
            {
                case "SELECT":
                    sb.Append(GetPramaString(new List<string>(), conditionList));
                    sb.Append("\r\nDataTable dt = new DataTable();\r\n");
                    sb.Append("dt.Load(this.m_db.ExecuteReader(cmdTxt) , LoadOption.OverwriteChanges);\r\n");
                    sb.Append("return dt;\r\n");

                    break;
                case "INSERT":
                    sb.Append(GetPramaString(columnList, new List<string>()));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    break;
                case "UPDATE":
                    sb.Append(GetPramaString(columnList, conditionList));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    break;
                case "DELETE":
                    sb.Append(GetPramaString(new List<string>(), conditionList));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    break;

            }

            return sb.ToString();
        }


        /// <summary>
        /// 取得SQL指令
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="CommandType">命名型態</param>
        /// <param name="columnList"> 欄位集合 </param>
        /// <param name="conditionList"> 條件集合 </param>
        /// <returns>請說明此回傳值的定義</returns>
        /// <remarks>
        /// * 新 增 者： chinyi(2010/6/28 下午 03:01 )
        /// * 修 改 者：
        /// * 修 改 者：
        /// * 修 改 者：
        /// </remarks>
        internal static string GetCommandTextByCSharp(string TableName, string CommandType, List<string> columnList, List<string> conditionList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SqlConnection connect = new SqlConnection(\"連線字串\"); \r\n");            
            sb.Append("string cmdTxt = @\"");
            sb.Append(SQLCommand.GetCommandText(TableName, CommandType, columnList, conditionList));
            sb.Append("\";\r\n\r\n");
            sb.Append("try{\r\n");
            sb.Append("\tconnect.Open(); \r\n");
            sb.Append("\tSqlCommand command = new SqlCommand(cmdTxt, connect); \r\n");

            switch (CommandType)
            {
                case "SELECT":
                    sb.Append(GetPramaStringByCSharp(new List<string>(), conditionList));
                    sb.Append("\r\n\tDataTable dt = new DataTable();\r\n");
                    sb.Append("\tdt.Load(command.ExecuteReader() , LoadOption.OverwriteChanges);\r\n");
                    sb.Append("}\r\n");
                    sb.Append(" catch{\r\n");
                    sb.Append("\t throw;\r\n");
                    sb.Append("}\r\n");
                    sb.Append(" finally{\r\n");
                    sb.Append("\tconnect.Close();\r\n");
                    sb.Append("\tconnect.Dispose();\r\n");
                    sb.Append("\tconnect = null;\r\n");
                    sb.Append("}\r\n");
                    sb.Append("return dt;\r\n");
                    break;
                case "INSERT":
                    sb.Append(GetPramaStringByCSharp(columnList, new List<string>()));
                    sb.Append("\r\n\tcommand.ExecuteNonQuery();\r\n");
                    sb.Append("}\r\n");
                    sb.Append("catch{\r\n");
                    sb.Append("\tthrow;\r\n");
                    sb.Append("}\r\n");
                    sb.Append("finally{\r\n");
                    sb.Append("\tconnect.Close();\r\n");
                    sb.Append("\tconnect.Dispose();\r\n");
                    sb.Append("\tconnect = null;\r\n");
                    sb.Append("}\r\n");
                    break;
                case "UPDATE":
                    sb.Append(GetPramaStringByCSharp(columnList, conditionList));
                    sb.Append("\r\n\tcommand.ExecuteNonQuery();\r\n");
                    sb.Append("}\r\n");
                    sb.Append("catch{\r\n");
                    sb.Append("\tthrow;\r\n");
                    sb.Append("}\r\n");
                    sb.Append("finally{\r\n");
                    sb.Append("\tconnect.Close();\r\n");
                    sb.Append("\tconnect.Dispose();\r\n");
                    sb.Append("\tconnect = null;\r\n");
                    sb.Append("}\r\n");
                    break;
                case "DELETE":
                    sb.Append(GetPramaStringByCSharp(new List<string>(), conditionList));
                    sb.Append("\r\nthis.m_db.ExecuteNonQuery(cmdTxt);\r\n");
                    sb.Append("}\r\n");
                    sb.Append("catch{\r\n");
                    sb.Append("\tthrow;\r\n");
                    sb.Append("}\r\n");
                    sb.Append("finally{\r\n");
                    sb.Append("\tconnect.Close();\r\n");
                    sb.Append("\tconnect.Dispose();\r\n");
                    sb.Append("\tconnect = null;\r\n");
                    sb.Append("}\r\n");
                    break;

            }

            return sb.ToString();
        }

        private static string GetPramaStringByCSharp(List<string> Columns, List<string> Conditions)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string column in Columns)
            {
                sb.Append(string.Format("\tcommand.Parameters.AddWithValue(\"@{0}\", dr.{0} );\r\n", column));
            }

            foreach (string condition in Conditions)
            {
                if (!Columns.Contains(condition))
                {
                    sb.Append(string.Format("\tcommand.Parameters.AddWithValue(\"@{0}\", dr.{0} );\r\n", condition));
                }
            }


            return sb.ToString();
        }
    }
}
