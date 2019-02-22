using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTFormCreate
{
   public class DBHelper
    {
        private string connStr = "";

        public DBHelper()
        {
            connStr= System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }


        public FormCategoryDataSet GetFormData()
        {
            FormCategoryDataSet ds = new FormCategoryDataSet();

            SqlConnection connect = new SqlConnection(connStr);
            string cmdTxt = @" SELECT 
	 [CATEGORY_ID] , 
	 [CATEGORY_NAME] , 
	 [IS_DISPLAY] , 
	 [CATEGORY_NAME_CULTURE]  
 FROM [dbo].[TB_WKF_FORM_CATEGORY] 
ORDER BY CATEGORY_NAME";

            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);

               
                ds.Load(command.ExecuteReader(), LoadOption.OverwriteChanges , ds.TB_WKF_FORM_CATEGORY);
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

            
             cmdTxt = @" SELECT 
	 [FORM_ID] , 
	 [FORM_NAME] , 
	 [CATEGORY_ID] , 
	 [USING_VERSION_ID] , 
	 [DELAY_HOUR] , 
	 [FORM_RM_ID] , 
	 [ARCHIVE_RM_ID] , 
	 [FORM_CTL] , 
	 [REJECT_TO_ARCHIVE] , 
	 [MODIFIER] , 
	 [MODIFY_DATE] , 
	 [CALLBACK_FLAG] , 
	 [CALLBACK_WEBSERVICE] , 
	 [CALLBACK_WEBSERVICE_METHOD] , 
	 [CALLBACK_CONTENT_FLAG] , 
	 [CALLBACK_COMMNET_FLAG] , 
	 [MODULE_ID] , 
	 [CALLBACK_ID] , 
	 [IS_EXTERNAL_FORM] , 
	 [IS_ONLINE_RA] , 
	 [ALLOWMODIFY] , 
	 [ALLOWAPPLICENTMODIFY] , 
	 [ALLOWOTHERMODIFY] , 
	 [ALLOWMODIFYUSERSET] , 
	 [RA_CALLWS_FLAG] , 
	 [RA_CALLWS_ID] , 
	 [RA_CONTENT_FLAG] , 
	 [RA_COMMENT_FLAG] , 
	 [START_FORM_TRIGGER_GUID] , 
	 [END_FORM_TRIGGER_GUID] , 
	 [CHANGE_FORM_RESULT_GUID] , 
	 [RESPONSIBLE_CONTROL] , 
	 [READER_RM_ID] , 
	 [RESPONSIBLE_RM_ID] , 
	 [DELETE_SCRIPT] , 
	 [BATCH_SIGN] , 
	 [IQY_FLAG] , 
	 [ALLOW_RETURN_SIGN] , 
	 [ALLOW_EXCEPTION_SEND] , 
	 [ALLOW_AGENT_APPLICANTION] , 
	 [SEND_SAME_DEPT] , 
	 [SAVE_SCRIPT] , 
	 [OR_FUNCTION_SET] , 
	 [SET_AGENT] , 
	 [SET_AGENT_USERSET] , 
	 [FORM_NAME_CULTURE] , 
	 [ALLOW_ADDITIONAL_SIGN] , 
	 [SIGN_FORM_TRIGGER_GUID] , 
	 [RETURN_FORM_VALIDATOR_TRIGGER] , 
	 [CHANGE_RESULT_VALIDATOR_TRIGGER] , 
	 [DISPLAY_MULTI_UNSIGN_USER] , 
	 [BACK_IMAGE_USE] , 
	 [BACK_IMAGE_FILEGROUP_ID] , 
	 [PRINT_AUTH] , 
	 [PRINT_USER_SET] , 
	 [WS_ENDFORM_VALIDATE_FLAG] , 
	 [WS_ENDFORM_VALIDATE_ID] , 
	 [WS_ENDFORM_VALIDATE_CONTENT] , 
	 [WS_ENDFORM_VALIDATE_COMMENT] , 
	 [FORM_INFO] , 
	 [CYCLE_HOURS] , 
	 [TIMEOUT_SEND_COUNT] , 
	 [BATCH_SIGN_RM_ID] , 
	 [BATCH_SIGN_TYPE] , 
	 [APPLICANT_CANCEL_FORM] , 
	 [FIELD_STYLE] , 
	 [TASK_PRIORITY] , 
	 [ELIMINATE_FILER] , 
	 [CUSTOM_FIELD_PRINT_RM_ID] , 
	 [CUSTOM_FIELD_PRINT]  
 FROM [dbo].[TB_WKF_FORM] 
order by FORM_NAME";

            try
            {
                connect = new SqlConnection(connStr);
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);

           
                ds.Load(command.ExecuteReader(), LoadOption.OverwriteChanges ,ds.TB_WKF_FORM);
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

            cmdTxt = @" SELECT 
	 [FORM_VERSION_ID] , 
	 [FORM_ID] , 
	 [VERSION] , 
	 [ENABLE_FLOW] , 
	 [FLOW_ID] , 
	 [ISSUE_CTL] , 
	 [ISSUE_TIME] , 
	 [MODIFIER] , 
	 [MODIFY_DATE] , 
	 [VERSION_FIELD] , 
	 [VERSION_NUM_TYPE] , 
	 [IS_ALLOW_ISSUE] , 
	 [IS_USE] , 
	 [DISPLAY_FIELD] , 
	 [DISPLAY_TITLE] , 
	 [VALIDATOR_WS_ID] , 
	 [NORMAL_WS_ID] , 
	 [WS_FIELDS] , 
	 [BATCHFIELDS] , 
	 [IS_DYNAMIC_ISSUE] , 
	 [DYNAMIC_EVENT_ID] , 
	 [LAYOUT]  
 FROM [dbo].[TB_WKF_FORM_VERSION] 
WHERE ISSUE_CTL=0
ORDER BY VERSION";

            try
            {
                connect = new SqlConnection(connStr);
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);

             
                ds.Load(command.ExecuteReader(), LoadOption.OverwriteChanges , ds.TB_WKF_FORM_VERSION);
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

        internal void UpdateFormVersionXM(string formversionId, string versionFields, string layout)
        {
            SqlConnection connect = new SqlConnection(connStr);
            string cmdTxt = @"  UPDATE [dbo].[TB_WKF_FORM_VERSION]  
 SET 
	 [VERSION_FIELD] = @VERSION_FIELD , 
	 [LAYOUT] = @LAYOUT  

WHERE 
	[FORM_VERSION_ID] = @FORM_VERSION_ID";

            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(cmdTxt, connect);
                command.Parameters.AddWithValue("@VERSION_FIELD", versionFields);
                command.Parameters.AddWithValue("@LAYOUT", layout);
                command.Parameters.AddWithValue("@FORM_VERSION_ID", formversionId);

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
