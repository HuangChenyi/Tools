using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ExternalFormGenerate
{
    public class FieldUtility
    {

        XmlDocument xmlDoc = new XmlDocument();

        string commonFieldXmlStr = "";
      

        public FieldUtility()
        { 
            //通用欄位的XML字串
            commonFieldXmlStr = @"
            //欄位名稱{1}節點 {2}
            //該欄位的欄位值若預期為空白，則fillerName、fillerUserGuid、fillerAccount屬性值保持空白
            //若有值保持原內容記錄填寫資訊
            XmlElement {0}Element = xmlDoc.CreateElement(""FieldItem"");
            {0}Element.SetAttribute(""fieldId"" , ""{0}"");
            {0}Element.SetAttribute(""fieldValue"", """");
            {0}Element.SetAttribute(""realValue"", """");
            {0}Element.SetAttribute(""fillerName"" , userName);
            {0}Element.SetAttribute(""fillerUserGuid"", userGuid);
            {0}Element.SetAttribute(""fillerAccount"", account);
            {0}Element.SetAttribute(""fillSiteId"", """");

            formFieldValueElement.AppendChild({0}Element);

";
        }



        internal string GetAutoNumberField(string fieldId)
        {

            return string.Format(@"
            
            //表單編號節點
            //如果要用UOF系統的表單流水號
            //isNeedAutoNbr 給 false，fieldValue 保持空白
            //如果要用UOF系統的表單流水號
            //isNeedAutoNbr 給 true，fieldValue 給對應的表單編號
            XmlElement {0}Element = xmlDoc.CreateElement(""FieldItem"");
            {0}Element.SetAttribute(""fieldId"" , ""{0}"");
            {0}Element.SetAttribute(""fieldValue"", """");
            {0}Element.SetAttribute(""realValue"", """");
            {0}Element.SetAttribute(""isNeedAutoNbr"", ""false""); 

             formFieldValueElement.AppendChild({0}Element);
", fieldId);


        }

        internal string GetSignleLineText(string fieldId,string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName,"");
        }

        internal string GetMultiLineText(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, "");
        }

        internal string GetNumberLineText(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, "，此為數值欄位，注意fileValue對應的值也是數值格式的字串");
        }

        internal string GetDateSelectText(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, "，此為日期欄位，注意fileValue對應的值也是日期格式的字串(yyyy/MM/dd)");
           
        }

        internal string GetTimeSelectText(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, "，此為時間欄位，注意fileValue對應的值也是時間格式的字串(HH:mm)");
        }

        internal string GetCheckFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為核選方塊欄位，選有三個選項項次1 2 3注意fileValue對應的值應為
            //核選項次1和3 fieldValue為項次1@項次3
            //核選項次2為 fieldValue為項次2");
        }

        internal string GetDropDownListFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為下拉欄位，選有三個選項項次1 2 3注意fileValue對應的值應為
            //選擇項次1 fieldValue為項次1@項次1
            //選擇項次3 fieldValue為項次3@項次3");
        }

        internal string GetRadioButtonFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為單選欄位，選有三個選項項次1 2 3注意fileValue對應的值應為
            //選擇項次1 fieldValue為項次1
            //選擇項次3 fieldValue為項次3");
        }

        internal string GetHtmlEditorFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName,"");
        }


        internal string GetDataGridFieldXml(string fieldId, string fieldName)
        {
            return "//暫無支援產生明細欄位";//string.Format(commonFieldXmlStr, fieldId, fieldName, "");
        }

        internal string GetFileFieldXml(string fieldId, string fieldName)
        {
             return string.Format(@"
            //欄位名稱{1}節點  此為檔案欄位，
            
            //該欄位的欄位值若預期為空白，則fillerName、fillerUserGuid、fillerAccount屬性值保持空白
            //若起單成功後要刪除暫存檔案IsDeleteTemp設false
            //若附件已先是UOF轉檔後的檔案格式IsNeedTransfer設false，一般會是 true
            //若有值保持原內容記錄填寫資訊
            XmlElement {0}Element = xmlDoc.CreateElement(""FieldItem"");
            {0}Element.SetAttribute(""fieldId"" , ""{0}"");
            {0}Element.SetAttribute(""IsNeedTransfer"" , ""true"");
            {0}Element.SetAttribute(""IsDeleteTemp"" , ""true"");
            {0}Element.SetAttribute(""realValue"", """");
            {0}Element.SetAttribute(""fieldValue"", """");
            {0}Element.SetAttribute(""fillerName"" , userName);
            {0}Element.SetAttribute(""fillerUserGuid"", userGuid);
            {0}Element.SetAttribute(""fillerAccount"", account);
            {0}Element.SetAttribute(""fillSiteId"", """");

           //如果多個附件請加入多個AttachItem，如果沒附件可不加入
            XmlElement {0}attachItemElement = xmlDoc.CreateElement(""AttachItem"");
            //放置檔案路徑(appSettings/wkfFileTransferTemp)
            {0}attachItemElement.SetAttribute(""filePath"","""");
            {0}Element.AppendChild({0}attachItemElement);
            formFieldValueElement.AppendChild({0}Element);
", fieldId, fieldName);

        }

        internal string GetHyperLinkFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為超連結欄位，fieldValue值的對應方式為連結名稱@連結網址");
        }

        internal string GetCalculateTextFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, "，此為計算欄位，注意fileValue對應的值也是數值格式的字串");
        }

        internal string GetAggregateTextFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, "，此為加總平均欄位，注意fileValue對應的值也是數值格式的字串");
        }

        internal string GetUserDeptFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為申請者部門欄位，注意fileValue對應的值是部門的名稱
            //realValue對應的值為部門GUID,部門名稱,False");
        }

        internal string GetUserProposerFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為申請者欄位，注意fileValue對應的值是申請者姓名(帳號)
            //realValue對應的值為申請者的UserSet");
        }

        internal string GetUserRankFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為申請者職級欄位，注意fileValue對應的值是申請者職級");
        }

        internal string GetUserAgentFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為代理人欄位，注意fileValue對應的值是代理人GUID@代理人部門 姓名
            //realValue對應的值為代理人的UserSet");
        }

        internal string GetAllDeptFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為所有部門欄位，注意fileValue對應的值是所選的部門
            //(EX:選擇產品部和研發部則顯示產品部、研發部)
            //realValue對應的值為所選的部門的UserSet");
        }

        internal string GetaAlRankFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為所有職級欄位，注意fileValue對應的值是所選的職級
            //(EX:選擇經理和副理則顯示經理、副理)
            //realValue對應的值為所選的職級的UserSet");
        }

        internal string GetAllFunctionFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為所有職務欄位，注意fileValue對應的值是所選的職務
            //(EX:選擇茶水小妹和送報小弟則顯示茶水小妹、送報小弟)
            //realValue對應的值為所選的職務的UserSet");
        }

        internal string GetAllUserFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為所有人員欄位，注意fileValue對應的值是所選的人員
            //(EX:選擇員工A和員工B則顯示員工A(員工A的帳號)、員工B(員工B的帳號))
            //realValue對應的值為所所選的人員的UserSet");
        }

        internal string GetDisplayFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為純顯示欄位");
        }

        internal string GetHiddenFieldXml(string fieldId, string fieldName)
        {
            return string.Format(commonFieldXmlStr, fieldId, fieldName, @"，此為隱蔵欄位");
        }

        internal string GetOptionalFieldXml(string fieldId, string fieldName)
        {
            return string.Format(@"
            //欄位名稱{1}節點  此為外掛欄位，
            //若外掛欄位有條件請放到ConditionValue
            //有配合組織站點請將UserSet指定到realValue
            //外掛欄位的值是放在InnerXml，不是fieldValue
            //該欄位的欄位值若預期為空白，則fillerName、fillerUserGuid、fillerAccount屬性值保持空白
            //若有值保持原內容記錄填寫資訊
            XmlElement {0}Element = xmlDoc.CreateElement(""FieldItem"");
            {0}Element.SetAttribute(""fieldId"" , ""{0}"");
            {0}Element.InnerXml="""";
            {0}Element.SetAttribute(""realValue"", """");
            {0}Element.SetAttribute(""ConditionValue"", """");
            {0}Element.SetAttribute(""fillerName"" , userName);
            {0}Element.SetAttribute(""fillerUserGuid"", userGuid);
            {0}Element.SetAttribute(""fillerAccount"", account);
            {0}Element.SetAttribute(""fillSiteId"", """");
            formFieldValueElement.AppendChild({0}Element);
", fieldId, fieldName);




        }
    }
}
