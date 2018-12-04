using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ede.Uof.WKF.Design;

namespace ShangxianForm
{
    internal class DBHelper :Ede.Uof.Utility.Data.BasePersistentObject
    {

        internal int GetFormTaskConut(string formVersionId)
        {
            string cmdTxt = @"SELECT COUNT(1) FROM TB_WKF_TASK
                            WHERE FORM_VERSION_ID=@FORM_VERSION_ID";
       
            this.m_db.AddParameter("FORM_VERSION_ID", formVersionId);


            return Convert.ToInt32(m_db.ExecuteScalar(cmdTxt));
        }

        internal int GetFormScriptConut(string formVersionId)
        {
            string cmdTxt = @"SELECT COUNT(1) FROM TB_WKF_SCRIPT
                            WHERE FORM_VERSION_ID=@FORM_VERSION_ID";

            this.m_db.AddParameter("FORM_VERSION_ID", formVersionId);


            return Convert.ToInt32(m_db.ExecuteScalar(cmdTxt));
        }

        internal int DeleteFormScript(string formVersionId)
        {
            string cmdTxt = @"DELETE TB_WKF_SCRIPT
                            WHERE FORM_VERSION_ID=@FORM_VERSION_ID";

            this.m_db.AddParameter("FORM_VERSION_ID", formVersionId);

            return this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal int DeleteFormTask(string formVersionId)
        {
            string cmdTxt = @"DECLARE @tmpTASKTB TABLE
                                    (TASK_ID nvarchar(50))

                                    INSERT INTO @tmpTASKTB
                                    SELECT TASK_ID FROM TB_WKF_TASK
                                    WHERE FORM_VERSION_ID = @FORM_VERSION_ID

                                    DECLARE @tmpSITETB TABLE
                                    (SITE_ID nvarchar(50))

                                    INSERT INTO @tmpSITETB
                                    SELECT SITE_ID FROM TB_WKF_TASK_SITE
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_ALERT_NODE
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_CALLBACK_RECORD
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)


                                    DELETE TB_WKF_TASK_CC
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_CUST_RELATION
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_IQY
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)


                                    DELETE TB_WKF_TASK_NODE
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_SITE
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_PARENT_SITE
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)

                                    DELETE TB_WKF_TASK_TRIGGER_RECORD
                                    WHERE TASK_ID IN (SELECT TASK_ID FROM @tmpTASKTB)";

            this.m_db.AddParameter("FORM_VERSION_ID", formVersionId);

            return this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void DeleteFVRDll(string siteId)
        {
            string cmdTxt = @"DELETE FROM [TB_WKF_FVR_SITE_DLL] 
                              WHERE       [SITE_ID]=@siteId";
            m_db.AddParameter("siteId", siteId);
            m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void DeleteAlertSite(string siteId)
        {
            string cmdTxt = @"DELETE TB_WKF_SITE_ALERT
                            WHERE SITE_ID=@SITE_ID";

            this.m_db.AddParameter("@SITE_ID", siteId);

            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void DeleteFvrCustomWords(string siteId, string parentSiteID)
        {
            string sql = @"
            DELETE FROM 
	            [TB_WKF_FVR_SITE_CUSTOM_WORDS]
            WHERE 
	            SITE_ID = @SITE_ID AND
	            PARENT_SITE_ID = @PARENT_SITE_ID
";
            m_db.AddParameter("@SITE_ID", siteId);
            m_db.AddParameter("@PARENT_SITE_ID", parentSiteID);
            m_db.ExecuteNonQuery(sql);
        }

        internal void DeleteFVRDllByFlowSite(string siteId)
        {
            string cmdTxt = @"DELETE FROM [TB_WKF_FVR_SITE_DLL] 
                              WHERE       [PARENT_SITE_ID]=@siteId";
            m_db.AddParameter("siteId", siteId);
            m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void DeleteSiteNodifyByFormVersion(string formVersionId)
        {
            string cmdTxt = @"DELETE TB_WKF_SITE_CONDITION_NOTIFY WHERE
                            FORM_VERSION_ID = @FORM_VERSION_ID";
            this.m_db.AddParameter("@FORM_VERSION_ID", formVersionId);
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal string GetUsingVersionId(string formId)
        {
            string cmdTxt = @"SELECT USING_VERSION_ID
                                FROM TB_WKF_FORM
                            WHERE FORM_ID=@FORM_ID";

            this.m_db.AddParameter("FORM_ID", formId);

            object obj = this.m_db.ExecuteScalar(cmdTxt);

            if (obj != null && obj != DBNull.Value)
                return obj.ToString();
            else
                return "";

        }

  

        internal void UpdateFormVersion(string formVersionId)
        {
            string cmdTxt = @"UPDATE TB_WKF_FORM_VERSION
                                SET VERSION=1 
                                WHERE FORM_VERSION_ID=@FORM_VERSION_ID";

            this.m_db.AddParameter("FORM_VERSION_ID" , formVersionId);
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
    }
}
