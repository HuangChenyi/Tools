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

        LanguageLibary lib = new LanguageLibary();
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

            int bodySeq = 1;
            //表單Detail欄位
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("body"))
            {
                //空單身
                if (string.IsNullOrEmpty(node.Value))
                    break;
                if(node.Attribute("id") != null)
                { 
                 col = new ColumnsJsonObj();
                field = new FieldJsonObj() { FieldID = node.Attribute("id").Value, Width = "", Height = "" };
                col.Columns.Add(field);
                }
                else
                {
                    col = new ColumnsJsonObj();
                    field = new FieldJsonObj() { FieldID = "detail"+ bodySeq, Width = "", Height = "" };
                    col.Columns.Add(field);
                }
                bodySeq++;
                obj.Rows.Add(col);
            }

            //表單Detail欄位(附件)
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("attachment"))
            {
             
                    col = new ColumnsJsonObj();
                    field = new FieldJsonObj() { FieldID = "attach", Width = "", Height = "" };
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
            string dataGridLinkFieldStr = @"
      <DataGridItem fieldId=""link"" fieldName=""link"" fieldSeq=""0"" fieldType=""hyperLink"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData="""" wsUrl="""" wsMethod="""" wsAuth="""" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime="""" wsVariation="""" delFlag=""True"" fieldDefault="""" fieldModify=""no"" linkTarget=""_blank"" linkTip="""" DialogHeight=""0"" DialogWidth=""0"">
        <fieldControlData fieldControlFlag=""yes"" />
        <fieldModifyData Flag=""accede"" />
        <allowApplicentUser Flag=""False"" />
        <allowOtherUser Flag=""False"" />
        <visibleControl Flag=""NoLimit"" />
        <visibleUser Flag=""&lt;UserSet&gt;&lt;/UserSet&gt;&#xD;&#xA;"" Filler=""False"" />
      </DataGridItem>";

            string fileFieldStr = @"  <FieldItem fieldId=""A05"" fieldName=""檔案欄位"" fieldSeq=""4"" fieldType=""fileButton"" fieldRemark="""" DisplayLength=""0"" DecimalPoint=""0"" displayFieldName=""True"" externalData="""" wsUrl="""" wsMethod="""" wsAuth="""" wsAccount="""" wsPassword="""" wsSystemValueSend="""" wsFormValueSend="""" wsGetBeforeTime="""" wsVariation="""" delFlag=""True"" embedPDF=""False"" embedWidth=""0"" embedHeight=""0"" PDFWidthStyle="""">
    <fieldControlData fieldControlFlag=""yes"" />
    <fieldModifyData Flag=""accede"" />
    <allowApplicentUser Flag=""False"" />
    <allowOtherUser Flag=""False"" />
  </FieldItem>";


            //程式代號
            string programId = doc.Element("Request").Element("RequestContent").Element("Form").Element("ProgramID").Value;



            XElement xe = new XElement("VersionField");
            int fieldseq = 1;
            //表單Header欄位

            XElement formNumberField = XElement.Parse(formNumberFieldStr);
            formNumberField.Add(CreateCultureNode(programId, "NO"));
            xe.Add(formNumberField);
          
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Element("head").Elements())
            {
                XElement field = null;
                if (node.Attribute("type") != null)
                {
                    switch (node.Attribute("type").Value)
                    {
                        case "0":
                            field = XElement.Parse(singleLineFieldStr);
                            break;
                        case "1":
                            field = XElement.Parse(numberFieldStr);
                            break;
                    }
                }
                else
                {
                    //找不到屬性就用文字欄位
                    field = XElement.Parse(singleLineFieldStr);
                }
                field.Attribute("fieldId").Value = node.Name.LocalName;
                field.Attribute("fieldName").Value = node.Name.LocalName;
                field.Attribute("fieldSeq").Value = fieldseq.ToString();
                fieldseq++;

                XElement cultureNode = CreateCultureNode( programId, node.Name.LocalName);

                field.Add(cultureNode);

                xe.Add(field);
            }

            int bodySeq = 1;
            //表單明細欄位
            foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("body"))
            { //空單身
                if (string.IsNullOrEmpty(node.Value))
                    break;

                XElement field = XElement.Parse(dataGridFieldStr);

                if (node.Attribute("id") != null)
                {
                    field.Attribute("fieldId").Value = node.Attribute("id").Value;
                    field.Attribute("fieldName").Value = node.Attribute("id").Value;
                    field.Attribute("fieldSeq").Value = fieldseq.ToString();
                }
                else
                {
                    field.Attribute("fieldId").Value = "detail"+ bodySeq;
                    field.Attribute("fieldName").Value = "detail"+ bodySeq;
                    field.Attribute("fieldSeq").Value = fieldseq.ToString();
                }
                bodySeq++;
                fieldseq++;
                int detailfieldseq = 0;
                foreach (var detailNode in node.Element("record").Elements())
                {
                    XElement detailField = null;

                    if (node.Attribute("type") != null)
                    {
                        switch (detailNode.Attribute("type").Value)
                        {
                            case "0":
                                detailField = XElement.Parse(dataGridSingleLineFieldStr);
                                break;
                            case "1":
                                detailField = XElement.Parse(dataGridNumberFieldStr);
                                break;
                        }
                    }
                    else
                    {
                        //找不到屬性就用文字欄位
                        detailField = XElement.Parse(dataGridSingleLineFieldStr);
                    }
                    detailField.Attribute("fieldId").Value = detailNode.Name.LocalName;
                    detailField.Attribute("fieldName").Value = detailNode.Name.LocalName;
                    detailField.Attribute("fieldSeq").Value = detailfieldseq.ToString();
                    detailfieldseq++;

                    XElement cultureNode = CreateCultureNode(programId, detailNode.Name.LocalName);

                    detailField.Add(cultureNode);

                    field.Element("dataGrid").Add(detailField);
                }

                xe.Add(field);
            }

            //附件欄位

            //表單明細欄位

            if (!cbAttach.Checked)
            {
                foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("attachment"))
                {
                    XElement field = XElement.Parse(dataGridFieldStr);


                    field.Attribute("fieldId").Value = "attach";
                    field.Attribute("fieldName").Value = "attach";
                    field.Attribute("fieldSeq").Value = fieldseq.ToString();
                    fieldseq++;
                    int detailfieldseq = 0;

                    XElement detailField = null;


                    detailField = XElement.Parse(dataGridLinkFieldStr);

                    detailField.Attribute("fieldId").Value = "link";
                    detailField.Attribute("fieldName").Value = "link";
                    detailField.Attribute("fieldSeq").Value = detailfieldseq.ToString();
                    detailfieldseq++;

                    field.Element("dataGrid").Add(detailField);


                    xe.Add(field);
                }
            }
            else
            {
                foreach (var node in doc.Element("Request").Element("RequestContent").Element("Form").Element("ContentText").Elements("attachment"))
                {
                    XElement field = XElement.Parse(fileFieldStr);


                    field.Attribute("fieldId").Value = "attach";
                    field.Attribute("fieldName").Value = "attach";
                    field.Attribute("fieldSeq").Value = fieldseq.ToString();
                    fieldseq++;



                    xe.Add(field);
                }
            }
            //隱藏欄位
            XElement hiddenField = null;

            //PlantID
            hiddenField = XElement.Parse(hiddenFieldStr);
            hiddenField.Attribute("fieldId").Value = "PlantID";
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

            return xe.ToString();
        }

        private XElement CreateCultureNode(string programId, string fieldId)
        {
            //多國語系樣板
            //<Culture>
            //  <item id="en-US" fieldName="" fieldRemark="" enable="False" />
            //  <item id="ja-JP" fieldName="" fieldRemark="" enable="False" />
            //  <item id="zh-CN" fieldName="" fieldRemark="" enable="False" />
            //  <item id="zh-TW" fieldName="" fieldRemark="" enable="True" />
            //</Culture>

            XElement xe = new XElement("Culture");

            XElement usNode = CreateCultureItemNode("en-US", programId,  fieldId);
            XElement jpNode = CreateCultureItemNode("ja-JP", programId, fieldId);
            XElement cnNode = CreateCultureItemNode("zh-CN", programId, fieldId);
           XElement twNode = CreateCultureItemNode("zh-TW", programId, fieldId);
            XElement viNode = CreateCultureItemNode("vi", programId, fieldId);
            xe.Add(usNode);
            xe.Add(jpNode);
            xe.Add(cnNode);
            xe.Add(twNode);
            xe.Add(viNode);

            return xe;

        }

        private XElement CreateCultureItemNode(string culture, string programId, string fieldId)
        {
            XElement xe = new XElement("item", 
                                                new XAttribute("id", culture), 
                                                new XAttribute("fieldName",""), 
                                                new XAttribute("fieldRemark",""), 
                                                new XAttribute("enable","False"));

         


            string fieldName = lib.FindText(programId, fieldId, culture);
           
            if(fieldName != "")
            {
                xe.Attribute("fieldName").Value = fieldName;
                xe.Attribute("enable").Value = "True";
            }
            else
            {
                xe.Attribute("fieldName").Value = fieldId;
                xe.Attribute("enable").Value = "True";
            }

            if(fieldId == "NO")
            {
                xe.Attribute("fieldName").Value = "表單編號";
                xe.Attribute("enable").Value = "True";
            }

            return xe;
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
