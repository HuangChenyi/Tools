using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTFormCreate
{
    public  class LanguageLibary
    {
        ProgramList list = new ProgramList();
        public LanguageLibary()
        {
            LoadExcelFile();
        }

        public string FindText(string programId , string fieldId, string culture)
        {
            if(list.List.ContainsKey(programId))
            {
               if(list.List[programId].Fields.ContainsKey(fieldId))
                {
                    switch(culture)
                    {
                        case "vi":
                            return list.List[programId].Fields[fieldId].vi;
                            break;
                        case "zh-TW":
                            return list.List[programId].Fields[fieldId].zh_TW;
                            break;
                    }
                }
            }

            return "";
        }


        public void LoadExcelFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo file = new FileInfo("TIPTOP欄位名稱.xlsx");

           

            using (var excel = new ExcelPackage(file))
            {
                var ws = excel.Workbook.Worksheets[0];

                for(int row =1; row < ws.Dimension.Rows;row++)
                {
                    if (ws.Cells[row, 1].Value == null || ws.Cells[row, 1].Text == "")
                        break;

                  


                    ProgramLib lib = new ProgramLib();

                    Field field = new Field();
                    //如果程式代號不存在就新增
                    if (!list.List.ContainsKey(ws.Cells[row, 1].Text))
                    {
                        list.List.Add(ws.Cells[row, 1].Text, lib);
                    }
                    else
                    {
                        lib= list.List[ws.Cells[row, 1].Text];
                    }

                    //如果欄位不存在就新增

                    if(!lib.Fields.ContainsKey(ws.Cells[row, 2].Text))
                    {
                        lib.Fields.Add(ws.Cells[row, 2].Text, field);
                    }
                    else
                    {
                        field = lib.Fields[ws.Cells[row, 2].Text];
                    }


                    //語系
                    switch(ws.Cells[row, 3].Text)
                    {
                        case "4:Việt Nam":
                            field.vi = ws.Cells[row, 4].Text;
                            break;
                        case "0:繁體中文":
                            field.zh_TW = ws.Cells[row, 4].Text;
                            break;
                    }

                }


            }
        }
       

    }

    public class ProgramList
    {
        private SortedList<string, ProgramLib> m_ProgramList = new SortedList<string, ProgramLib>();

        public SortedList<string, ProgramLib> List
        {
            get { return m_ProgramList; }
            set { m_ProgramList = value; }
        }
    }

        public class ProgramLib
    {
        private SortedList<string, Field> m_Fields = new SortedList<string, Field>();

        public SortedList<string, Field> Fields {
            get { return m_Fields; }
            set { m_Fields=value; }
        }

       
    }

    public class Field
    {
        public string zh_TW { get; set; }
        public string zh_CN { get; set; }
        public string en_US { get; set; }
        public string vi { get; set; }

        public Field()
        {
            zh_TW = "";
            zh_CN = "";
            en_US = "";
            vi = "";
        }

    }
}
