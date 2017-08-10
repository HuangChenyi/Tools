using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Reflection;

namespace SQLHelper
{
    public  class RichTextBoxColorful
    {
        public  void ColorfulText(RichTextBox richTxtBox, LanguageType languageType)
        {
           // Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SQLHelper.KeyWordList.xml");
            XmlDocument document = new XmlDocument();
            document.LoadXml(Resource1.KeyWordList);
            switch (languageType)
            {
                case LanguageType.SQL:
                    foreach (XmlNode node in document.SelectNodes("//keyword[@language='SQL']/kw"))
                    {
                        SetTextColorful(richTxtBox, node.InnerText, Color.Blue);
                    }
                    SetTextColorfulByStr(richTxtBox, LanguageType.SQL, Color.Red);
                    SetTextColorfulByComment(richTxtBox, LanguageType.SQL, Color.Green);
                    break;

                case LanguageType.CSharp:
                    foreach (XmlNode node in document.SelectNodes("//keyword[@language='CSharp']/kw"))
                    {
                        SetTextColorful(richTxtBox, node.InnerText, Color.Blue);
                    }
                    SetTextColorfulByStr(richTxtBox, LanguageType.CSharp, Color.Red);
                    SetTextColorfulByComment(richTxtBox, LanguageType.CSharp, Color.Green);
                    SetTextColorfulByComment(richTxtBox, LanguageType.CSharpXml, Color.Gray);
                    break;
            }
        }

        private  void SetTextColorful(RichTextBox richTxtBox, string keyword, Color settingColor)
        {
            string text = richTxtBox.Text;
            for (int i = 0; text.IndexOf(keyword, i) != -1; i += keyword.Length)
            {
                i = text.IndexOf(keyword, i);

                char ch = text[i - 1];
                char ch2 = text[i + keyword.Length];
                if ((((ch == '(') || (ch == ' ')) || ((ch == '\n') || (ch == '\t'))) && ((((ch2 == ' ') || (ch2 == '\n')) || (ch2 == '.')) || (ch2 == '(')))
                {
                    richTxtBox.Select(i, keyword.Length);
                    richTxtBox.SelectionColor = settingColor;
                }
            }
            richTxtBox.Select(0, 0);
        }


        private  void SetTextColorfulByComment(RichTextBox richTxtBox, LanguageType languateType, Color settingColor)
        {
            string text = richTxtBox.Text;
            int startIndex = 0;
            int length = 0;
            string str2 = "";
            switch (languateType)
            {
                case LanguageType.SQL:
                    str2 = "--";
                    break;

                case LanguageType.CSharp:
                    str2 = "//";
                    break;

                case LanguageType.CSharpXml:
                    str2 = "///";
                    break;
            }
            while (text.IndexOf(str2, startIndex) != -1)
            {
                startIndex = text.IndexOf(str2, startIndex);
                length = text.IndexOf('\n', startIndex) - startIndex;
                richTxtBox.Select(startIndex, length);
                richTxtBox.SelectionColor = settingColor;
                startIndex += length;
            }
            richTxtBox.Select(0, 0);
        }

        private  void SetTextColorfulByStr(RichTextBox richTxtBox, LanguageType languateType, Color settingColor)
        {
            string text = richTxtBox.Text;
            int startIndex = 0;
            int length = 0;
            string str2 = "";
            switch (languateType)
            {
                case LanguageType.SQL:
                    str2 = "'";
                    break;

                case LanguageType.CSharp:
                    str2 = "\"";
                    break;
            }
            while (text.IndexOf(str2, startIndex) != -1)
            {
                startIndex = text.IndexOf(str2, startIndex);
                length = (text.IndexOf(str2, startIndex + 1) - startIndex) + 1;
                richTxtBox.Select(startIndex, length);
                richTxtBox.SelectionColor = settingColor;
                startIndex += length + 1;
            }
            richTxtBox.Select(0, 0);
        }

 



 

 


 

    }
}
