using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace TTFormCreate
{
    public partial class TTFormCreate : Form
    {
        public TTFormCreate()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("請先設定連線字串");
            }


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

            BindTree();

        }

        private void BindTree()
        {
            DBHelper db = new DBHelper();
            treeFormList.Nodes.Clear();
            FormCategoryDataSet formCategoryDs = db.GetFormData();

            foreach (DataRow categoryDr in formCategoryDs.TB_WKF_FORM_CATEGORY.Rows)
            {
                TreeNode pNode = new TreeNode();
                pNode.Tag = categoryDr["CATEGORY_ID"].ToString();
                pNode.Text = categoryDr["CATEGORY_NAME"].ToString();


                //查出類別下所有的表單
                foreach (DataRow formDr in formCategoryDs.TB_WKF_FORM.Select("CATEGORY_ID = '" + categoryDr["CATEGORY_ID"].ToString() + "'", "FORM_NAME"))
                {
                    TreeNode cNode = new TreeNode();
                    cNode.Tag = formDr["FORM_ID"].ToString();
                    cNode.Text = formDr["FORM_NAME"].ToString();


                    pNode.Nodes.Add(cNode);

                    //查出表單下所有的版本
                    foreach (DataRow versionDr in formCategoryDs.TB_WKF_FORM_VERSION.Select("FORM_ID = '" + formDr["FORM_ID"].ToString() + "'", "VERSION"))
                    {
                        TreeNode vNode = new TreeNode();
                        vNode.Tag = versionDr["FORM_VERSION_ID"].ToString();
                        vNode.Text = $"{formDr["FORM_NAME"].ToString()}({versionDr["VERSION"].ToString()})";
                       

                        cNode.Nodes.Add(vNode);
                    }
                }
                this.treeFormList.Nodes.Add(pNode);
            }

            //展開全部
            this.treeFormList.ExpandAll();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string layout = GetLayOutJson(txtTTCode.Text);
            string versionFields = GetVersionXML(txtTTCode.Text);

            DBHelper db = new DBHelper();
            db.UpdateFormVersionXM(treeFormList.SelectedNode.Tag.ToString() , versionFields, layout);
            MessageBox.Show("執行成功!");
        }

        private string GetLayOutJson(string xml)
        {
            FormJsonObj obj = new FormJsonObj();

            XDocument doc = XDocument.Parse(xml);
            //隱藏欄位
            FieldJsonObj field = new FieldJsonObj() { FieldID = "PlantID", Width = "", Height = "" };
            obj.HiddenColumns.Add(field);
            field = new FieldJsonObj() { FieldID = "ProgramID", Width = "", Height = "" };
            obj.HiddenColumns.Add(field);
            field = new FieldJsonObj() { FieldID = "SourceFormID", Width = "", Height = "" };
            obj.HiddenColumns.Add(field);
            field = new FieldJsonObj() { FieldID = "SourceFormNum", Width = "", Height = "" };
            obj.HiddenColumns.Add(field);


            ColumnsJsonObj col = new ColumnsJsonObj();
            field = new FieldJsonObj() { FieldID ="NO", Width = "", Height = "" };
            col.Columns.Add(field);

            obj.Rows.Add(col);


            //表單Header欄位
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Element("head").Elements())
            {
                col = new ColumnsJsonObj();
                field = new FieldJsonObj() { FieldID = node.Name.LocalName, Width = "", Height = "" };
                col.Columns.Add(field);

                obj.Rows.Add(col);
            }

            //表單Detail欄位
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("body"))
            {
                 col = new ColumnsJsonObj();
                field = new FieldJsonObj() { FieldID = node.Attribute("id").Value, Width = "", Height = "" };
                col.Columns.Add(field);

                obj.Rows.Add(col);
            }

            //LAY OUT
            //  Console.WriteLine();

            return JsonConvert.SerializeObject(obj).ToString();
        }

        private  string GetVersionXML(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            string formNumberFieldStr = @"<FieldItem fieldId=""NO"" fieldName=""表單編號"" fieldSeq=""0"" fieldType=""autoNumber"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" externalData="""" wsUrl="""" wsMethod="""" wsAuth="""" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime="""" wsVariation="""" delFlag=""True"" fieldLength=""0"" fieldModify=""no"" fieldTrackID=""WKF"" FieldExternal=""False"" FieldFile="""" FieldFileType="""">
    <fieldControlData fieldControlFlag="""" />
  </FieldItem>";
            string hiddenFieldStr = "<FieldItem fieldId=\"A02\" fieldName=\"BB\" fieldSeq=\"6\" fieldType=\"hiddenField\" fieldRemark=\"\" DisplayLength=\"0\" DecimalPoint=\"0\" displayFieldName=\"True\" externalData=\"\" wsUrl=\"\" wsMethod=\"\" wsAuth=\"\" wsAccount=\"\" wsPassword=\"\" wsSystemValueSend=\"\" wsFormValueSend=\"\" wsGetBeforeTime=\"\" wsVariation=\"\" delFlag=\"True\" />";
            string singleLineFieldStr = @"
  <FieldItem fieldId=""A01"" fieldName=""AA"" fieldSeq=""4"" fieldType=""singleLineText"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData=""False"" wsUrl="""" wsMethod="""" wsAuth=""False"" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime=""False"" wsVariation=""False"" delFlag=""True"" fieldLength=""50"" fieldDefault="""" fieldModify=""yes"">
    <fieldControlData fieldControlFlag=""yes"" />
    <fieldModifyData Flag=""accede"" />
    <allowApplicentUser Flag=""False"" />
    <allowOtherUser Flag=""False"" />
    <visibleControl Flag=""NoLimit"" />
    <visibleUser Flag=""&lt;UserSet&gt;&lt;/UserSet&gt;"" Filler=""False"" />
  </FieldItem>";

            string numberFieldStr = @"
  <FieldItem fieldId=""amount"" fieldName=""金額"" fieldSeq=""3"" fieldType=""numberText"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData=""False"" wsUrl="""" wsMethod="""" wsAuth=""False"" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime=""False"" wsVariation=""False"" delFlag=""True"" fieldRangeMin=""0"" fieldRangeMax=""9999999"" fieldDefault="""" fieldModify=""yes"" EnabledDecimalPoint=""False"">
    <fieldControlData fieldControlFlag=""no"" />
    <fieldModifyData Flag=""accede"" />
    <allowApplicentUser Flag=""False"" />
    <allowOtherUser Flag=""False"" />
    <visibleControl Flag=""NoLimit"" />
    <visibleUser Flag=""&lt;UserSet&gt;&lt;/UserSet&gt;"" Filler=""False"" />
  </FieldItem>
";

            string dataGridFieldStr = @"
 <FieldItem fieldId=""A03"" fieldName=""CC"" fieldSeq=""5"" fieldType=""dataGrid"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData="""" wsUrl="""" wsMethod="""" wsAuth="""" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime="""" wsVariation="""" delFlag=""True"" DataGridWidth=""0"">
    <dataGrid>
    </dataGrid>
    <fieldModifyData Flag=""accede"" />
    <allowApplicentUser Flag=""False"" />
    <allowOtherUser Flag=""False"" />
    <fieldControlData fieldControlFlag=""yes"" />
    <visibleControl Flag=""NoLimit"" />
    <visibleUser Flag=""&lt;UserSet&gt;&lt;/UserSet&gt;"" Filler=""False"" />
  </FieldItem>
";

            string dataGridSingleLineFieldStr = @"
  <DataGridItem fieldId=""A031"" fieldName=""C1"" fieldSeq=""0"" fieldType=""singleLineText"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData=""False"" wsUrl="""" wsMethod="""" wsAuth=""False"" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime=""False"" wsVariation=""False"" delFlag=""True"" fieldLength=""50"" fieldDefault="""" fieldModify=""yes"">
        <fieldControlData fieldControlFlag=""yes"" />
        <fieldModifyData Flag=""accede"" />
        <allowApplicentUser Flag=""False"" />
        <allowOtherUser Flag=""False"" />
        <visibleControl Flag=""NoLimit"" />
        <visibleUser Flag=""&lt;UserSet&gt;&lt;/UserSet&gt;"" Filler=""False"" />
      </DataGridItem>
";

            string dataGridNumberFieldStr = @"
 <DataGridItem fieldId=""A032"" fieldName=""CCC"" fieldSeq=""1"" fieldType=""numberText"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData=""False"" wsUrl="""" wsMethod="""" wsAuth=""False"" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime=""False"" wsVariation=""False"" delFlag=""True"" fieldRangeMin=""0"" fieldRangeMax=""999999"" fieldDefault="""" fieldModify=""yes"" EnabledDecimalPoint=""False"">
        <fieldControlData fieldControlFlag=""yes"" />
        <fieldModifyData Flag=""accede"" />
        <allowApplicentUser Flag=""False"" />
        <allowOtherUser Flag=""False"" />
        <visibleControl Flag=""NoLimit"" />
        <visibleUser Flag=""&lt;UserSet&gt;&lt;/UserSet&gt;&#xD;&#xA;"" Filler=""False"" />
      </DataGridItem>
";


            XElement xe = new XElement("VersionField");
            int fieldseq = 1;
            //表單Header欄位

            xe.Add(XElement.Parse(formNumberFieldStr));

            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Element("head").Elements())
            {
                XElement field = null;
                switch (node.Attribute("type").Value)
                {
                    case "0":
                        field = XElement.Parse(singleLineFieldStr);
                        break;
                    case "1":
                        field = XElement.Parse(numberFieldStr);
                        break;
                }

                field.Attribute("fieldId").Value = node.Name.LocalName;
                field.Attribute("fieldName").Value = node.Name.LocalName;
                field.Attribute("fieldSeq").Value = fieldseq.ToString();
                fieldseq++;

                xe.Add(field);
            }

            //表單明細欄位
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("body"))
            {
                XElement field = XElement.Parse(dataGridFieldStr);

                field.Attribute("fieldId").Value = node.Attribute("id").Value;
                field.Attribute("fieldName").Value = node.Attribute("id").Value;
                int detailfieldseq = 0;
                foreach (var detailNode in node.Element("record").Elements())
                {
                    XElement detailField = null;
                    switch (detailNode.Attribute("type").Value)
                    {
                        case "0":
                            detailField = XElement.Parse(dataGridSingleLineFieldStr);
                            break;
                        case "1":
                            detailField = XElement.Parse(dataGridNumberFieldStr);
                            break;
                    }

                    detailField.Attribute("fieldId").Value = detailNode.Name.LocalName;
                    detailField.Attribute("fieldName").Value = detailNode.Name.LocalName;
                    detailField.Attribute("fieldSeq").Value = detailfieldseq.ToString();
                    detailfieldseq++;

                    field.Element("dataGrid").Add(detailField);
                }

                xe.Add(field);

                //隱藏欄位
                XElement hiddenField = null;

                //PlantID
                hiddenField = XElement.Parse(hiddenFieldStr);
                hiddenField.Attribute("fieldId").Value= "PlantID";
                hiddenField.Attribute("fieldName").Value = "PlantID";
                hiddenField.Attribute("fieldSeq").Value = fieldseq.ToString();
                xe.Add(hiddenField);
                fieldseq++;

                //ProgramID
                hiddenField = XElement.Parse(hiddenFieldStr);
                hiddenField.Attribute("fieldId").Value = "ProgramID";
                hiddenField.Attribute("fieldName").Value = "ProgramID";
                hiddenField.Attribute("fieldSeq").Value = fieldseq.ToString();
                xe.Add(hiddenField);
                fieldseq++;

                //SourceFormID
                hiddenField = XElement.Parse(hiddenFieldStr);
                hiddenField.Attribute("fieldId").Value = "SourceFormID";
                hiddenField.Attribute("fieldName").Value = "SourceFormID";
                hiddenField.Attribute("fieldSeq").Value = fieldseq.ToString();
                xe.Add(hiddenField);
                fieldseq++;

                //SourceFormNum
                hiddenField = XElement.Parse(hiddenFieldStr);
                hiddenField.Attribute("fieldId").Value = "SourceFormNum";
                hiddenField.Attribute("fieldName").Value = "SourceFormNum";
                hiddenField.Attribute("fieldSeq").Value = fieldseq.ToString();
                xe.Add(hiddenField);
                fieldseq++;

            }

            return xe.ToString();
        }

        private void treeFormList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level ==2)
            {
                btnRun.Enabled = true;
                txtTTCode.Enabled = true;
            }
            else
            {
                btnRun.Enabled = false;
                txtTTCode.Enabled = false;

            }
        }
    }
}
