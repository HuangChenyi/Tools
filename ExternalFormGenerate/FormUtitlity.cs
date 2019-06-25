using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ExternalFormGenerate
{
    public class FormUtitlity
    {
        XmlDocument xmlDoc = new XmlDocument();

        public string GetFormInfoXmlCode(string formversionId)
        {
            return string.Format(@"
            //申請者的帳號 USER_GUID 姓名  作為記錄填寫資訊用
            string account="""";
            string userGuid = """";
            string userName = """";


            //urgentLevel 緊急程度0:緊急 1:急 2:普通
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement formElement = xmlDoc.CreateElement(""Form"");
            formElement.SetAttribute(""formVersionId"", ""{0}"");
            formElement.SetAttribute(""urgentLevel"", ""2"");" , formversionId);

        }

        public string GetApplicantXmlCode()
        {
            return string.Format(@"

            XmlElement applicantElement = xmlDoc.CreateElement(""Applicant"");
            
            //<!--account:申請者UOF帳號 groupId部門代號(可不填) jobTitleId:職稱代號(可不填)-->
            applicantElement.SetAttribute(""account"", account);
            applicantElement.SetAttribute(""groupId"", """");
            applicantElement.SetAttribute(""jobTitleId"", """");
            
            //申請者意見
            XmlElement commentElement = xmlDoc.CreateElement(""Comment"");
            commentElement.InnerText = """";

            applicantElement.AppendChild(commentElement);

            /*如果想要夾帶申請附件請取消註解此段
            XmlElement appachElement = xmlDoc.CreateElement(""Attach"");
            appachElement.SetAttribute(""IsNeedTransfer"", ""true"");
            appachElement.SetAttribute(""IsDeleteTemp"", ""true"");

            //如果多個附件請加入多個AttachItem
            XmlElement attachItemElement = xmlDoc.CreateElement(""AttachItem"");
            //放置檔案路徑(appSettings/wkfFileTransferTemp)
            attachItemElement.SetAttribute(""filePath"","""");

            appachElement.AppendChild(attachItemElement);
            applicantElement.AppendChild(appachElement);
             */

            formElement.AppendChild(applicantElement);

");


        
        }

        /// <summary>
        /// 產生表單欄位結點XML
        /// </summary>
        /// <param name="versionField"></param>
        /// <returns></returns>
        internal string GetFieldXmlCode(XmlNode versionField)
        {

            FieldUtility fieldUtil = new FieldUtility();

            switch (versionField.Attributes["fieldType"].Value)
            {
                case "autoNumber":
                    return fieldUtil.GetAutoNumberField(versionField.Attributes["fieldId"].Value);
                  
                case "singleLineText":
                    return fieldUtil.GetSignleLineText(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);

                case "multiLineText":
                    return fieldUtil.GetMultiLineText(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "numberText":
                    return fieldUtil.GetNumberLineText(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "fileButton": //檔案欄位暫時從缺
                    return fieldUtil.GetFileFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "dateSelect":
                    return fieldUtil.GetDateSelectText(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "timeSelect":
                    return fieldUtil.GetTimeSelectText(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "checkBox":
                    return fieldUtil.GetCheckFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "radioButton":
                    return fieldUtil.GetRadioButtonFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "dropDownList":
                    return fieldUtil.GetDropDownListFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "htmlEditor":
                    return fieldUtil.GetHtmlEditorFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "dataGrid":
                    return fieldUtil.GetDataGridFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "hyperLink":
                    return fieldUtil.GetHyperLinkFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "calculateText":
                    return fieldUtil.GetCalculateTextFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
              
                case "aggregateText":
                    return fieldUtil.GetAggregateTextFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "userProposer":
                    return fieldUtil.GetUserProposerFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "userDept":
                    return fieldUtil.GetUserDeptFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "userRank":
                    return fieldUtil.GetUserRankFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "userAgent":
                    return fieldUtil.GetUserAgentFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "allDept":
                    return fieldUtil.GetAllDeptFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "allRank":
                    return fieldUtil.GetaAlRankFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "allFunction":
                    return fieldUtil.GetAllFunctionFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "allUser":
                    return fieldUtil.GetAllUserFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "displayField":
                    return fieldUtil.GetDisplayFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "hiddenField":
                    return fieldUtil.GetHiddenFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
                case "optionalField":
                    return fieldUtil.GetOptionalFieldXml(versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
            }
            return "";
        }

        internal string GetFormFieldValueXmlCode()
        {

            return @"

            XmlElement formFieldValueElement = xmlDoc.CreateElement(""FormFieldValue""); 
            formElement.AppendChild(formFieldValueElement);

            ";


        }

        internal string GetDLLInitCode()
        {
            return @"

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);

            ";
        }

        internal string GetFieldDLLCode(XmlNode versionField)
        {
            return string.Format(@"
            //{1}
            dr.{0} = xmlDoc.SelectSingleNode(""/Form/FormFieldValue/FieldItem[@fieldId='{0}']"").Attributes[""fieldValue""].Value;
", versionField.Attributes["fieldId"].Value, versionField.Attributes["fieldName"].Value);
        }

        internal string GetMessageContentCode()
        {
            return @"
            XmlElement MessageContentElement = xmlDoc.CreateElement(""MessageContent""); 
            XmlElement VersionFieldElement = xmlDoc.CreateElement(""VersionField""); 
            MessageContentElement.AppendChild(VersionFieldElement);
            formElement.AppendChild(MessageContentElement);
                ";
        }

        internal string GetFieldMessageContentCode(XmlNode versionField)
        {
            return string.Format(@"
            //欄位{0}的郵件様板的值,請把該欄位的郵件様板的值塞入FieldValue的InnerXML
            XmlElement MsgFieldItem_{1}Element = xmlDoc.CreateElement(""FieldItem""); 
            XmlElement MsgFieldValue_{1}Element = xmlDoc.CreateElement(""FieldValue""); 
            MsgFieldItem_{1}Element.SetAttribute(""fieldId"",""{1}"");
            MsgFieldItem_{1}Element.SetAttribute(""enableSearch"",""true"");
            MsgFieldValue_{1}Element.InnerXml="""";
            VersionFieldElement.AppendChild(MsgFieldItem_{1}Element);
            MsgFieldItem_{1}Element.AppendChild(MsgFieldValue_{1}Element);


", 
            versionField.Attributes["fieldName"].Value, 
            versionField.Attributes["fieldId"].Value);
            
        }
    }
}
