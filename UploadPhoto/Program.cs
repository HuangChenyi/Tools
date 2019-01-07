using Ede.Uof.EIP.Organization.Util;
using Ede.Uof.Utility.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadPhoto
{
    class Program
    {

        public static string txt = "";

        static void Main(string[] args)
        {
            try
            {
                
                Authentication auth = new Authentication();
                string account = System.Configuration.ConfigurationManager.AppSettings["account"]; ;
                string pwd = System.Configuration.ConfigurationManager.AppSettings["password"];
                string token = auth.GetToken("Photo", account, pwd);

                if(string.IsNullOrEmpty(token))
                {
                    Console.WriteLine(GetLog($@"取得Token失敗，請確認帳密或其他設定是否正確"));
                    return;
                }

                string filePath = System.Configuration.ConfigurationManager.AppSettings["filePath"];

                Console.WriteLine(GetLog($@"取得Token:{token}"));
                DirectoryInfo dirInfo = new DirectoryInfo(filePath);
                Console.WriteLine(GetLog($@"載入路徑:{filePath}"));
                var files = dirInfo.GetFiles().Where(s => s.Name.ToLower().EndsWith(".jpg") || s.Name.ToLower().EndsWith(".png")).ToList();

                foreach(FileInfo file in files)
                {
                    DatabaseHelper db = new DatabaseHelper();

                    string uofaccount = file.Name.Split('.')[0];
                    string userGuid = new UserUCO().GetGUID(uofaccount);

                    if (string.IsNullOrEmpty(userGuid))
                    {
                        Console.WriteLine(GetLog($@"帳號{uofaccount}不存在"));
                        continue;
                    }

                    string cmdTxt = @"SELECT COUNT(1) FROM TB_EB_EMPL
                                        WHERE ISNULL(PHOTO,'') ='' AND  USER_GUID=@USER_GUID";

                    db.AddParameter("USER_GUID", userGuid);
                    object obj = db.ExecuteScalar(cmdTxt);

                    if(Convert.ToInt32(obj) ==0)
                    {
                        Console.WriteLine(GetLog($@"帳號{uofaccount}己先維謢相片，不再上傳!"));
                        continue;
                    }

                    db = new DatabaseHelper();
                    FileSystem fs = new FileSystem(token);
                   string fileGroupId = fs.UploadFileToUOF(file.FullName, File.FileTarget.Personal);

                    cmdTxt = @"UPDATE TB_EB_EMPL
                                        SET PHOTO=@PHOTO
                                        WHERE USER_GUID=@USER_GUID";
                    
                    db.AddParameter("PHOTO" , fileGroupId);
                    db.AddParameter("USER_GUID", userGuid);
                    db.ExecuteNonQuery(cmdTxt);
                    Console.WriteLine(GetLog($@"帳號{uofaccount}上傳完成!"));
                }

               


                Console.WriteLine(GetLog($@"己執行完畢"));
            }
            catch (Exception ce)
            {
                Console.WriteLine(GetLog($@"執行時發生錯誤:
{ce.ToString()}"));
            }

            StreamWriter sw = new StreamWriter($"Log{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");
            sw.Write(txt);
            sw.Close();
        }


        private static string GetLog(string msg)
        {
            msg = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ":" + msg;
            txt += msg + "\r\n";
            return msg;
        }
    }
}
