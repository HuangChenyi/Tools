using System;
using System.Collections.Generic;
using System.Text;

namespace SQLHelper
{
    public static class SQLCommand
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
            string cmdTxt = "";
            switch (commandType)
            { 
                case "SELECT":
                    cmdTxt = GetSelectCommand(tableName, Columns);
                    break;
                case "INSERT":
                    cmdTxt = GetInsertCommand(tableName, Columns);
                    break;
                case "UPDATE" :
                    cmdTxt = GetUpdateCommand(tableName, Columns);
                    break;
                case "DELETE":
                    cmdTxt = GetDeleteCommand(tableName);
                    break;

            }
            return cmdTxt;
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
            return string.Format(" DELETE [dbo].[{0}] " , tableName);
        }

        /// <summary>
        /// 取得更新語法
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="Columns"> 欄位集合 </param>>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/6/15 下午 03:35 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        private static string GetUpdateCommand(string tableName, List<string> Columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("  UPDATE [dbo].[{0}]  \r\n SET \r\n", tableName));

            foreach (string column in Columns)
            {
                sb.Append(string.Format("\t [{0}] = @{0} , \r\n", column));
            }

            sb = sb.Remove(sb.ToString().LastIndexOf(','), 1);

            return sb.ToString(); 
        }

        /// <summary>
        /// 取得新增語法
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="Columns"> 欄位集合 </param>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/6/15 下午 03:14 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        private static string GetInsertCommand(string tableName, List<string> Columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("  INSERT INTO [dbo].[{0}]  \r\n(", tableName));

            foreach (string column in Columns)
            {
                sb.Append(string.Format("\t [{0}] , \r\n", column));
            }

            sb.Append(") \r\n VALUES \r\n (");
            sb = sb.Remove(sb.ToString().LastIndexOf(','), 1);

            foreach (string column in Columns)
            {
                sb.Append(string.Format("\t @{0} , \r\n", column));
            }

            sb.Append(")");
            sb = sb.Remove(sb.ToString().LastIndexOf(','), 1);

            return sb.ToString(); 
        }

        /// <summary>
        /// 取得查詢語法
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="Columns"> 欄位集合 </param>
        /// <returns> 請說明此回傳值的定義 </returns>
        /// <remarks>
        ///  * 新 增 者： chinyi(2010/6/15 下午 03:14 )
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        ///  * 修 改 者： 
        /// </remarks>
        private static string GetSelectCommand(string tableName, List<string> Columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT \r\n");

            foreach (string column in Columns)
            {
                sb.Append(string.Format("\t [{0}] , \r\n", column));
            }

            sb.Append(string.Format(" FROM [dbo].[{0}] ", tableName));

            return sb.Remove(sb.ToString().LastIndexOf(','), 1).ToString();
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
        internal static string GetCommandText(string TableName, string CommandType, List<string> columnList, List<string> conditionList )
        {
            string cmdTxt = "";
            switch (CommandType)
            {
                case "SELECT":
                    cmdTxt = GetSelectCommand(TableName, columnList);
                    break;
                case "INSERT":
                    cmdTxt = GetInsertCommand(TableName, columnList);
                    break;
                case "UPDATE":
                    cmdTxt = GetUpdateCommand(TableName, columnList);
                    break;
                case "DELETE":
                    cmdTxt = GetDeleteCommand(TableName);
                    break;

            }


            for (int i = 0; i < conditionList.Count; i++)
            {
                if (i == 0)
                {
                    cmdTxt += "\r\nWHERE \r\n";
                }

                cmdTxt += string.Format("\t[{0}] = @{0}" , conditionList[i] );

                if (i < conditionList.Count -1)
                {
                    cmdTxt += "\r\nAND \r\n";
                }
            }


                return cmdTxt;
        }
    }
}
