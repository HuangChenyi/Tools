using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace BPMFieldCopyTool
{
    public partial class Form1 : Form
    {
        SqlConnection m_conn = new SqlConnection();
        FormJsonObj formObj = new FormJsonObj();
        XElement fieldXML;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FieldInfo fieldInfo = new FieldInfo();
            fieldInfo.Dock = DockStyle.Top;

            
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
            m_conn = new SqlConnection(ConnectString);
            DisableControl();
            BindFormInfo();
        }

        private void BindFormInfo()
        {
            BindFormCategroyDDL();
            BindFormListDDL();
            BindFormVersionDLL();
        }

        private void BindFormVersionDLL()
        {
            if (cbxFormList.SelectedIndex == -1)
            {
                return;
            }

            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT 
                                        VERSION,
                                        FORM_VERSION_ID
                                        FROM TB_WKF_FORM_VERSION 
                                    WHERE
                                        FORM_ID=@FORM_ID";

         
                    cmdTxt += " AND ISSUE_CTL=0 ";
                

                cmdTxt += " ORDER BY VERSION DESC ";

                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);
                comm.Parameters.AddWithValue("@FORM_ID", ((ItemList)cbxFormList.SelectedItem).Value);



                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                m_conn.Close();
                cbxFormVersion.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ItemList item = new ItemList(dr["VERSION"].ToString(), dr["FORM_VERSION_ID"].ToString());
                    cbxFormVersion.Items.Add(item);
                }

                if (cbxFormVersion.Items.Count > 0)
                {
                    cbxFormVersion.SelectedIndex = 0;
                }
               
               
              

            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單版本時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }
        }

        private void BindFormListDDL()
        {
            if (cbxFormCategory.SelectedIndex == -1)
            {
                return;
            }

            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT 
                                        FORM_ID,
                                        FORM_NAME
                                        FROM TB_WKF_FORM 
                                    WHERE
                                        CATEGORY_ID=@CATEGORY_ID";
                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);
                comm.Parameters.AddWithValue("@CATEGORY_ID", ((ItemList)cbxFormCategory.SelectedItem).Value);
                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                m_conn.Close();
                cbxFormList.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ItemList item = new ItemList(dr["FORM_NAME"].ToString(), dr["FORM_ID"].ToString());
                    cbxFormList.Items.Add(item);
                }

                if (cbxFormList.Items.Count > 0)
                {
                    cbxFormList.SelectedIndex = 0;
                }


            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單列表時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }

        }

        private void BindFormCategroyDDL()
        {
            m_conn.Open();

            try
            {
                string cmdTxt = @"SELECT CATEGORY_ID,CATEGORY_NAME FROM TB_WKF_FORM_CATEGORY
                                ORDER BY CATEGORY_NAME";
                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);

                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                m_conn.Close();
                cbxFormCategory.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    ItemList item = new ItemList(dr["CATEGORY_NAME"].ToString(), dr["CATEGORY_ID"].ToString());
                    cbxFormCategory.Items.Add(item);
                }

                if (cbxFormCategory.Items.Count > 0)
                {
                    cbxFormCategory.SelectedIndex = 0;
                }


            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單類別時發生錯誤:" + ce.Message);
                m_conn.Close();
            }
            finally
            {
                m_conn.Close();
            }


        }

        private void DisableControl()
        {
            grpConnectInfo.Enabled = false;
            grpFormIfno.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("請先設定連線字串");
            }

            m_conn = new SqlConnection(connectionString);

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

        private void cbxFormCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFormListDDL();
            BindFormVersionDLL();

         
         
        }

        private void cbxFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindFormVersionDLL();

            if (cbxFormVersion.Items.Count == 0)
            {
               // MessageBox.Show("該表單沒有未發佈的表單版本!");
            }
        }

        FieldInfo CreateField(XElement xe , string fieldId)
        {
            FieldInfo info = new FieldInfo();
            info.Dock = DockStyle.Fill;

            if (string.IsNullOrEmpty(fieldId))
            {
               
                info.SetFieldInfo("EmptyField");
           
                return info;
            }
            info.Name = fieldId;

            var field = (from f in xe.Elements("FieldItem")
                         where f.Attribute("fieldId").Value == fieldId
                         select f).FirstOrDefault();

            info.SetFieldInfo($"欄位代號:{field.Attribute("fieldId").Value}\r\n欄位名稱:{field.Attribute("fieldName").Value}\r\n欄位型態:{field.Attribute("fieldType").Value}");

            return info;
        }

       

        private void btnGenerateForm_Click(object sender, EventArgs e)
        {

            GenerateForm();
            
        }

        private void GenerateForm()
        {
            m_conn.Open();

            try
            {
                pnlFieldCollection.Controls.Clear();
                string cmdTxt = @"SELECT VERSION_FIELD,LAYOUT FROM TB_WKF_FORM_VERSION
                                        WHERE FORM_VERSION_ID=@FORM_VERSION_ID";
                SqlCommand comm = new SqlCommand(cmdTxt, m_conn);

                comm.Parameters.AddWithValue("FORM_VERSION_ID", ((ItemList)cbxFormVersion.SelectedItem).Value);

                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());


                string versionFieldXML = dt.Rows[0]["VERSION_FIELD"].ToString();
                string layJosn = dt.Rows[0]["LAYOUT"].ToString();

                formObj = Newtonsoft.Json.JsonConvert.DeserializeObject<FormJsonObj>(layJosn);

                fieldXML = XElement.Parse(versionFieldXML);

                for (int i = formObj.Rows.Count - 1; i >= 0; i--)
                {

                    var row = formObj.Rows[i];




                    switch (row.Columns.Count)
                    {
                        case 1:
                            FieldRow fr = new FieldRow();
                            fr.Dock = DockStyle.Top;
                            fr.RowIndex = i;


                            fr.SetFieldInfo(CreateField(fieldXML, row.Columns[0].FieldID));

                            pnlFieldCollection.Controls.Add(fr);
                            break;
                        case 2:
                            FieldRowTwo fr2 = new FieldRowTwo();
                            fr2.Dock = DockStyle.Top;
                            fr2.RowIndex = i;


                            fr2.SetFieldInfoLeft(CreateField(fieldXML, row.Columns[0].FieldID));


                            fr2.SetFieldInfoRight(CreateField(fieldXML, row.Columns[1].FieldID));


                            pnlFieldCollection.Controls.Add(fr2);
                            break;
                        case 3:
                            FieldRowThree fr3 = new FieldRowThree
                            {
                                AutoSize = false,
                                Dock = DockStyle.Top
                            };
                            fr3.RowIndex = i;
                            fr3.SetFieldInfoLeft(CreateField(fieldXML, row.Columns[0].FieldID));
                            fr3.SetFieldInfoCenter(CreateField(fieldXML, row.Columns[1].FieldID));
                            fr3.SetFieldInfoRight(CreateField(fieldXML, row.Columns[2].FieldID));

                            pnlFieldCollection.Controls.Add(fr3);
                            break;
                    }
                }



            }
            catch (Exception ce)
            {
                MessageBox.Show("建立表單欄位時發生錯誤:" + ce.Message);

            }
            finally
            {
                m_conn.Close();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要複製欄位嗎?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                foreach (var control in this.pnlFieldCollection.Controls)
                {
                    string fieldId = "";
                    // 
                    //一欄                  
                    if (control.GetType() == typeof(BPMFieldCopyTool.FieldRow))
                    {
                        BPMFieldCopyTool.FieldRow FieldRow = (BPMFieldCopyTool.FieldRow)control;
                        //找到Json物件
                        var row = NewFormRowObj(formObj.Rows[FieldRow.RowIndex]);

                        //複製整列
                        if (FieldRow.RowChecked)
                        {

                            AddNewField(row, row.Columns[0].FieldID,0);
                            formObj.Rows.Add(row);
                        }
                    }

                    //二欄
                    if (control.GetType() == typeof(BPMFieldCopyTool.FieldRowTwo))
                    {
                        BPMFieldCopyTool.FieldRowTwo FieldRowTwo = (BPMFieldCopyTool.FieldRowTwo)control;

                        //找到Json物件
                        var row = NewFormRowObj(formObj.Rows[FieldRowTwo.RowIndex]);

                        //複製整列
                        if (FieldRowTwo.RowChecked)
                        {


                            AddNewField(row, row.Columns[0].FieldID, 0);
                            AddNewField(row, row.Columns[1].FieldID, 1);
                            formObj.Rows.Add(row);
                        }
                    }

                    //三欄
                    if (control.GetType() == typeof(BPMFieldCopyTool.FieldRowThree))
                    {
                        BPMFieldCopyTool.FieldRowThree FieldRowThree = (BPMFieldCopyTool.FieldRowThree)control;

                        //找到Json物件
                        var row = NewFormRowObj(formObj.Rows[FieldRowThree.RowIndex]);

                        //複製整列
                        if (FieldRowThree.RowChecked)
                        {
                            AddNewField(row, row.Columns[0].FieldID, 0);
                            AddNewField(row, row.Columns[1].FieldID, 1);
                            AddNewField(row, row.Columns[2].FieldID, 2);
                            formObj.Rows.Add(row);
                        }
                    }
                }


                //回寫DB
                m_conn.Open();

                try
                {
                   
                    string cmdTxt = @"UPDATE TB_WKF_FORM_VERSION
                                            SET VERSION_FIELD=@VERSION_FIELD,
                                            LAYOUT=@LAYOUT
                                        WHERE FORM_VERSION_ID=@FORM_VERSION_ID";
                    SqlCommand comm = new SqlCommand(cmdTxt, m_conn);

                    comm.Parameters.AddWithValue("FORM_VERSION_ID", ((ItemList)cbxFormVersion.SelectedItem).Value);
                    comm.Parameters.AddWithValue("LAYOUT", JsonConvert.SerializeObject( formObj) );
                    comm.Parameters.AddWithValue("VERSION_FIELD",  fieldXML.ToString() );
                    DataTable dt = new DataTable();
                    dt.Load(comm.ExecuteReader());

                    MessageBox.Show("複製表單欄位成功");
                  
                }
                catch
                {
                    MessageBox.Show("複製表單欄位失敗");
                    
                }
                finally
                {
                    m_conn.Close();
                }

                GenerateForm();
            }
        }

        private void AddNewField(ColumnsJsonObj row, string fieldID , int columnIndex)
        {
            string newFieldId = GetNewFieldId(fieldID);
            row.Columns[columnIndex].FieldID = newFieldId;

            if (newFieldId == "")
                return;
            //找出欄位XML
            XElement field = GetNewField(fieldID);
            field.Attribute("fieldId").Value = newFieldId;
            fieldXML.Add(field);

          
           
        }

        private XElement GetNewField(string fieldID)
        {
            var field = (from f in fieldXML.Elements("FieldItem")
                         where f.Attribute("fieldId").Value == fieldID
                         select f).FirstOrDefault();

            return XElement.Parse(field.ToString())  ;
        }

        private ColumnsJsonObj NewFormRowObj(ColumnsJsonObj columnsJsonObj)
        {
            return JsonConvert.DeserializeObject<ColumnsJsonObj>(JsonConvert.SerializeObject(columnsJsonObj));
        }

        private string GetNewFieldId(string fieldID)
        {

            if(fieldID == "")
            {
                return "";
            }

           string newFieldId= fieldID + "_";

            var fields = (from f in fieldXML.Elements("FieldItem")
                         where f.Attribute("fieldId").Value == newFieldId
                         select f).Count();

            //欄位重覆判斷
            if(fields >0)
            {
                return GetNewFieldId(newFieldId);
            }

            return newFieldId;

        }
    }
}
