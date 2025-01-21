using AventStack.ExtentReports;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace CommonComponents
{
    public static class ExcelHelper
    {
        public static void WriteToExcel(int rows, string path)
        {
            Application excelApp = new Application();
            Workbook wb;
            Worksheet ws;
            Range cellRange;
            string[] Headers = new[] { "FirstName", "LastName", "UniqueId" };
            try
            {

                wb = excelApp.Workbooks.Open(@path);
                ws = (Worksheet)wb.Worksheets[1];
                ws.Cells.ClearContents();
                for (int i = 1; i < rows; i++)
                {
                    if (i == 1)
                    {
                        cellRange = ws.Range["A" + i.ToString() + ":C" + i.ToString()];
                        cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, Headers);
                    }
                    else
                    {
                        List<string> list = new List<string>();
                        list.Add("RMFirst_" + DateTime.Now.ToString("MMddFFF"));
                        list.Add("RMLast_" + DateTime.Now.ToString("MMddFFF"));
                        list.Add(DateTime.Now.ToString("MMddFFF"));
                        string[] Values = list.ToArray();
                        cellRange = ws.Range["A" + i.ToString() + ":C" + i.ToString()];
                        cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, Values);
                        Array.Clear(Values, 0, Values.Length);
                        list.Clear();
                    }
                }
                excelApp.DisplayAlerts = false;
                excelApp.ActiveWorkbook.SaveAs(@path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                excelApp.ActiveWorkbook.Close();
                excelApp.Quit();
                Array.Clear(Headers, 0, Headers.Length);
            }
            catch (Exception)
            {
                excelApp.Quit();
            }

        }

        public static void AddToExcel(List<string> students, string path)
        {
            Application excelApp = new Application();
            Workbook wb;
            Worksheet ws;
            Range cellRange;
            string[] Headers = new[] { "Email" };
            try
            {

                wb = excelApp.Workbooks.Open(@path);
                ws = (Worksheet)wb.Worksheets[1];
                ws.Cells.ClearContents();
                for (int i = 1; i < students.Count; i++)
                {
                    if (i == 1)
                    {
                        cellRange = ws.Range["A" + i.ToString() + ":A" + i.ToString()];
                        cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, Headers);
                    }
                    else
                    {
                        cellRange = ws.Range["A" + i.ToString() + ":A" + i.ToString()];
                        cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, students[i]);
                    }
                }
                excelApp.DisplayAlerts = false;
                excelApp.ActiveWorkbook.SaveAs(@path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                excelApp.ActiveWorkbook.Close();
                excelApp.Quit();
                Array.Clear(Headers, 0, Headers.Length);
            }
            catch (Exception)
            {
                excelApp.ActiveWorkbook.Close();
                excelApp.Quit();
            }

        }

        public static void ReadExcel(string path)
        {
            Application excelApp = new Application();
            if (excelApp != null)
            {
                Workbook excelWorkbook = excelApp.Workbooks.Open(@path, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Worksheet excelWorksheet = (Worksheet)excelWorkbook.Sheets[1];

                Range excelRange = excelWorksheet.UsedRange;
                int rowCount = excelRange.Rows.Count;
                int colCount = excelRange.Columns.Count;
                using (StreamWriter writer = new StreamWriter(@"\\nraqaauto1\Automation\Reports\write.txt"))
                {
                    for (int i = 2; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            Range range = (excelWorksheet.Cells[i, j] as Range);
                            string cellValue = range.Value.ToString();
                            writer.WriteLine(cellValue);
                        }
                    }
                }

                excelWorkbook.Close();
                excelApp.Quit();
            }
        }

        public static string ExamFormsExcel(string path, string state, string language, string courseid, int examformcolum)
        {
            double examformno = 1;
            try
            {
                Application excelApp = new Application();
                if (excelApp != null)
                {
                    Workbook excelWorkbook = excelApp.Workbooks.Open(@path, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Worksheet excelWorksheet = (Worksheet)excelWorkbook.Sheets[1];

                    Range excelRange = excelWorksheet.UsedRange;
                    int rowCount = excelRange.Rows.Count;
                    int colCount = excelRange.Columns.Count;
                    for (int i = 2; i <= rowCount; i++)
                    {
                        try
                        {
                            if (((excelWorksheet.Cells[i, 2] as Range).Value).ToString().Trim().Equals(courseid) && ((excelWorksheet.Cells[i, 4] as Range).Value).ToString().Trim().Equals(state) && ((excelWorksheet.Cells[i, 5] as Range).Value).ToString().Trim().Equals(language) && ((excelWorksheet.Cells[i, 6] as Range).Value).ToString().Trim().Equals("Online"))
                            {
                                try
                                {
                                    examformno = (excelWorksheet.Cells[i, examformcolum] as Range).Value;
                                    break;

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("cell is null");
                        }
                    }
                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return examformno.ToString();
        }
    }
}
