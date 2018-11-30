using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenTableSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            //ExcelWorksheet sheet2 = ep.Workbook.Worksheets.Add("Index");

            //ExcelWorksheet sheet = ep.Workbook.Worksheets.Add("123");

            //sheet.Cells[1, 1].Value = "123";

            ////建立檔案
            //using (FileStream createStream = new FileStream(@"output.xlsx", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            //{
            //    ep.SaveAs(createStream);//存檔
            //}

           
           // return;

            Data data = new Data();

            SchemaDataSet ds = new SchemaDataSet();
            ds = data.GetAllTables();


            using (FileStream fs = new FileStream(@"temp.xlsx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //載入Excel檔案
                using (ExcelPackage ep = new ExcelPackage(fs))
                {

                    ep.Workbook.Worksheets[1].Cells[1, 2].Value = "資料表名稱";
                    ep.Workbook.Worksheets[1].Cells[1, 3].Value = "資料表名稱說明";
                    ep.Workbook.Worksheets[1].Cells[1, 1,1,3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ep.Workbook.Worksheets[1].Cells[1, 1,1,3].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                    ep.Workbook.Worksheets[1].Cells[1, 1, 1, 3].Style.Font.Bold = true;

                    int tableSheetIndex = 1;
                    int columnSheetIndex = 1;
                    foreach (SchemaDataSet.TableSchemaRow tDr in ds.TableSchema.Rows)
                    {

                        string tableName = tDr.TABLE_NAME;
                        string tableSummary = "";
                        if(!tDr.IsSUMMARYNull())
                            tableSummary=tDr.SUMMARY;
                        ep.Workbook.Worksheets[1].Cells[tableSheetIndex + 1, 1].Value = tableSheetIndex.ToString();
                        ep.Workbook.Worksheets[1].Cells[tableSheetIndex + 1, 2].Value = tableName;

                        ep.Workbook.Worksheets[1].Cells[tableSheetIndex + 1, 3].Value = tableSummary;

                        if ( tableSheetIndex!= 1 && tableSheetIndex% 2 == 1)
                        {
                            ep.Workbook.Worksheets[1].Cells[tableSheetIndex, 1, tableSheetIndex, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ep.Workbook.Worksheets[1].Cells[tableSheetIndex, 1, tableSheetIndex, 3].Style.Fill.BackgroundColor.SetColor(Color.Moccasin);
                        }

                        EnumerableRowCollection<SchemaDataSet.ColumnSchemaRow> list = ds.ColumnSchema.Where(p => p.TABLE_NAME == tableName);

                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1].Value = string.Format("{0}({1})", tableName, tableSummary);
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1].Style.Fill.BackgroundColor.SetColor(Color.Orange );
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1].Style.Font.Bold = true;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1,columnSheetIndex,9].Merge = true;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1, columnSheetIndex, 9].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1, columnSheetIndex, 9].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1, columnSheetIndex, 9].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1, columnSheetIndex, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                   

                        ep.Workbook.Worksheets[1].Cells[tableSheetIndex + 1, 2].Hyperlink = new ExcelHyperLink("'欄位說明'!A" + columnSheetIndex.ToString(), tableName);
                        ep.Workbook.Worksheets[1].Cells[tableSheetIndex + 1, 3].Hyperlink = new ExcelHyperLink("'欄位說明'!A" + columnSheetIndex.ToString(), tableSummary);
                        columnSheetIndex++;
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1] , "PK",true);

                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 2], "Name", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 3], "Type", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 4], "Allow Null", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 5], "Len", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 6], "Prec", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 7], "Scale", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 8], "Init", true);
                        SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 9], "Notes", true);

                        ep.Workbook.Worksheets[2].Column(9).Width = 50;
                        columnSheetIndex++;
                        foreach (SchemaDataSet.ColumnSchemaRow cDr in list)
                        {
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1] , cDr.IS_PK);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 1] , cDr.IS_PK);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 2] , cDr.COLUMN_NAME);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 3] , cDr.DATA_TYPE);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 4] , cDr.IS_NULLABLE);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 5] , cDr.CHARACTER_MAXIMUM_LENGTH);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 6] , cDr.NUMERIC_PRECISION);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 7] , cDr.NUMERIC_SCALE);
                            SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 8] , cDr.COLUMN_DEFAULT);
                            if (!cDr.IsSUMMARYNull())
                            {
                                SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 9] ,cDr.SUMMARY); 
                            }
                            else
                            {
                                SetCell(ep.Workbook.Worksheets[2].Cells[columnSheetIndex, 9] , "");
                            }
                            columnSheetIndex++;
                        }


                        columnSheetIndex++;
                        columnSheetIndex++;
                        columnSheetIndex++;

                        Console.WriteLine(string.Format("GenTable:{0} Done!" , tableName));

                        tableSheetIndex++;
                    }




                    ep.Workbook.Worksheets[1].Column(2).AutoFit();
                    ep.Workbook.Worksheets[1].Column(3).AutoFit();
                   // ep.Workbook.Worksheets[2].Column(1).AutoFit();
                    ep.Workbook.Worksheets[2].Column(2).AutoFit();
                    ep.Workbook.Worksheets[2].Column(3).AutoFit();
                    ep.Workbook.Worksheets[2].Column(4).AutoFit();
                    ep.Workbook.Worksheets[2].Column(5).AutoFit();
                    ep.Workbook.Worksheets[2].Column(6).AutoFit();
                    ep.Workbook.Worksheets[2].Column(7).AutoFit();
                    ep.Workbook.Worksheets[2].Column(8).AutoFit();
//                    ep.Workbook.Worksheets[2].Column(9).AutoFit();

                    using (FileStream createStream = new FileStream(@"TableSchema.xlsx", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                    {
                        ep.SaveAs(createStream);//存檔
                    }//end using



                }
            }




        }

        private static void SetCell(ExcelRange excelRange, object val)
        {
            SetCell(excelRange, val, false);
        }

        private static void SetCell(ExcelRange excelRange, object val , bool isHeader)
        {

            excelRange.Value = val;
            excelRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            excelRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            excelRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            excelRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            if (isHeader)
            {
                excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                excelRange.Style.Fill.BackgroundColor.SetColor(Color.Moccasin);
            }
        }
    }
}
