using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FormViewGenerate
{
    public class FormUtitlity
    {
        internal string GetVersionFields(string formVersionId, SqlConnection conn)
        {
            conn.Open();


            try
            {
                string cmdTxt = @"SELECT VERSION_FIELD FROM TB_WKF_FORM_VERSION
                                WHERE FORM_VERSION_ID = @FORM_VERSION_ID";

                SqlCommand comm = new SqlCommand(cmdTxt, conn);
                comm.Parameters.AddWithValue("@FORM_VERSION_ID",formVersionId);

                object obj = comm.ExecuteScalar();

                if (obj == null || obj == DBNull.Value)
                {
                    return "";
                }
                conn.Close();
                return obj.ToString();
            }
            catch (Exception ce)
            {
                MessageBox.Show("取得表單結構時發生錯誤:" + ce.Message);
                conn.Close();
            }



            return "";
        }

        internal string GetViewSql(string formVewsionId,string formName, SqlConnection m_conn)
        {
            string ViewSql = "";
            string versionFields = this.GetVersionFields(formVewsionId, m_conn);

            if (versionFields != "")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(versionFields);
                XmlNodeList versionFieldList = xmlDoc.SelectNodes("/VersionField/FieldItem");

                ViewSql = this.GetHeaderViewSql(formVewsionId, formName,versionFieldList);
                //處理明細的部份Detail
               ViewSql += this.GetDetailViewSql(formVewsionId, formName, versionFieldList);
                //      txtFormCode.Text =
               
              
            }

            return ViewSql;
        }

        private string GetDetailViewSql(string formVewsionId, string formName, XmlNodeList versionFieldList)
        {
            string sql = "";
            foreach (XmlNode versionField in versionFieldList)
            {
                switch (versionField.Attributes["fieldType"].Value)
                {

                    case "dataGrid":
                        sql += $@"

if exists (select * from sysobjects where id = object_id(N'[{formName}_{versionField.Attributes["fieldName"].Value}]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop VIEW [{formName}_{versionField.Attributes["fieldName"].Value}]
GO
CREATE VIEW [dbo].[{formName}_{versionField.Attributes["fieldName"].Value}]
AS
SELECT
    TASK_ID
    ,DOC_NBR AS [表單編號]
  ,[{versionField.Attributes["fieldId"].Value}].l.value('(@order)[1]','int') +1 AS [項次]";
                        foreach (XmlNode gridCellNode in versionField.SelectNodes("./dataGrid/DataGridItem"))
                        {
                            sql += $@"
    ,[{versionField.Attributes["fieldId"].Value}].l.value('(Cell[@fieldId=""{gridCellNode.Attributes["fieldId"].Value}""]/@fieldValue)[1]','nvarchar(max)') AS [{versionField.Attributes["fieldName"].Value}_{gridCellNode.Attributes["fieldId"].Value}]";
                        }
                        sql += $@"
FROM TB_WKF_TASK
CROSS APPLY CURRENT_DOC.nodes('Form/FormFieldValue/FieldItem[@fieldId=""{versionField.Attributes["fieldId"].Value}""]/DataGrid/Row') [{versionField.Attributes["fieldId"].Value}](l)
WHERE FORM_VERSION_ID='{formVewsionId}'
GO";
                        break;
                }
            }

            return sql;
        }

        /// <summary>
        /// 取得表頭建立VIEW SQL
        /// </summary>
        /// <param name="formVewsionId"></param>
        /// <param name="formName"></param>
        /// <param name="versionFieldList"></param>
        /// <returns></returns>
        private string GetHeaderViewSql(string formVewsionId, string formName ,XmlNodeList versionFieldList)
        {
           string sql= $@"if exists (select * from sysobjects where id = object_id(N'[{formName}]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop VIEW [{formName}]
GO
CREATE VIEW [dbo].[{formName}]
AS
SELECT
    TASK_ID
    ,DOC_NBR AS [表單編號]
    ,BEGIN_TIME AS [起單時間]
    ,END_TIME  AS [結案時間]
    ,TB_WKF_TASK.USER_GUID AS 申請人ID
    ,ISNULL(TB_EB_USER.ACCOUNT , 'UnKnowUser' ) AS 申請者帳號
    ,ISNULL(TB_EB_USER.NAME , 'UnKnowUser' ) AS 申請者姓名
    ,CASE TASK_RESULT
		WHEN 0 THEN '同意'
		WHEN 1 THEN '否決'
		WHEN 2 THEN '作廢'
		ELSE '未結案'
		END AS [審核結果]";

            foreach (XmlNode versionField in versionFieldList)
            {
                switch (versionField.Attributes["fieldType"].Value)
                {
                    
                    case "autoNumber":
                //表單單號用上面的就好了
                        break;
                    case "optionalField":
                        //外掛欄位架構關係，用MESSAGE
                        sql += $@"
    ,MESSAGE_CONTENT.value('(/VersionField/FieldItem[@fieldId=""{versionField.Attributes["fieldId"].Value}""]/FieldValue)[1]' , 'nvarchar(max)') as [{versionField.Attributes["fieldName"].Value}_{versionField.Attributes["fieldId"].Value}]";

                        break;
                    case "dataGrid":
                        //明細欄位是detail另外處理
                        break;
                    case "fileButton":
                        //檔案欄位暫無視
                        break;
                    default:
                        sql += $@"
    ,CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId=""{versionField.Attributes["fieldId"].Value}""]/@fieldValue)[1]' , 'nvarchar(max)') as [{versionField.Attributes["fieldName"].Value}_{versionField.Attributes["fieldId"].Value}]";
                        break;
                }

            }

            sql += $@"
FROM TB_WKF_TASK LEFT JOIN TB_EB_USER
ON TB_WKF_TASK.USER_GUID = TB_EB_USER.USER_GUID
WHERE FORM_VERSION_ID='{formVewsionId}'
GO";
            return sql;
        }

        internal DataTable GetFormCategoryDt(SqlConnection conn)
        {
            string cmdTxt = @"SELECT CATEGORY_ID,CATEGORY_NAME FROM TB_WKF_FORM_CATEGORY
                                ORDER BY CATEGORY_NAME";
            SqlCommand comm = new SqlCommand(cmdTxt, conn);

            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            conn.Close();

            return dt;
        }

        internal DataTable GetFormListDt(string categoryId, SqlConnection conn)
        {
            string cmdTxt = @"SELECT 
                                        FORM_ID,
                                        FORM_NAME
                                        FROM TB_WKF_FORM 
                                    WHERE
                                        CATEGORY_ID=@CATEGORY_ID
                            ORDER BY FORM_NAME";
            SqlCommand comm = new SqlCommand(cmdTxt, conn);
            comm.Parameters.AddWithValue("@CATEGORY_ID", categoryId);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            conn.Close();
           
            return dt;
        }

        internal DataTable GetFormVersionDt(string formId, SqlConnection conn)
        {
            string cmdTxt = @"SELECT 
                                        VERSION,
                                        FORM_VERSION_ID
                                        FROM TB_WKF_FORM_VERSION 
                                    WHERE
                                        FORM_ID=@FORM_ID
                                         AND ISSUE_CTL=1";

            
          
          

            cmdTxt += " ORDER BY VERSION DESC ";

            SqlCommand comm = new SqlCommand(cmdTxt, conn);
            comm.Parameters.AddWithValue("@FORM_ID", formId);



            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            conn.Close();

            return dt;
        }
    }
}
