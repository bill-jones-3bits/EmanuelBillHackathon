using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Hackathon_2017_Bill_Emanuel
{
    class XlsInput
    {
        Excel.Workbook wb;
        Excel.Application app = new Excel.Application();
        StreamWriter f;
        public string LoadFile(string path)
        {
            try
            {
                if (path == string.Empty) return "Path empty.";
                wb = app.Workbooks.Open(path);
                //var sheet = app.Worksheets[0];
                var sheet = (Excel.Worksheet) wb.Worksheets[1];
                //var cells = new List<List<string>>();
                string interimCsv = "C:\\tmp\\tmp {0}.csv";
                string outFile = "C:\\tmp\\file.txt";

                f = File.CreateText(outFile);

                wb.SaveAs(string.Format(interimCsv, "csv"), Excel.XlFileFormat.xlCSV, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.SaveAs(string.Format(interimCsv, "csvMac"), Excel.XlFileFormat.xlCSVMac, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.SaveAs(string.Format(interimCsv, "csvDOS"), Excel.XlFileFormat.xlCSVMSDOS, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.SaveAs(string.Format(interimCsv, "csvWin"), Excel.XlFileFormat.xlCSVWindows, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                
                /*
                int cols = sheet.UsedRange.Columns.Count;
                int rowCount = sheet.UsedRange.Rows.Count;
                string[] vals = new string[cols];
                Excel.Range cells;
                Excel.Range cell;

                for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
                {
                    cells = sheet.UsedRange.Rows[rowIndex].Cells;
                    for (int col = 0; col < cols; col++)
                    {
                        try
                        {
                            cell = cells[col + 1][1];
                            vals[col] = string.Format("\"{0}\"", cell.Text);
                        }
                        catch (Exception ex)
                        {
                            return string.Format("Cell error: {0}", ex.ToString());
                        }
                    }
                    f.WriteLine(string.Join(",", vals));
                }
                f.Flush();
                */
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (wb != null)
                {
                    wb.Close();
                    wb = null;
                }
                if (app != null)
                {
                app.Quit();
                    app = null;
                }
                if (f != null)
                {
                    f.Close();
                    f = null;
                }
            }

            return string.Empty;
        }

        public void DoStuff()
        {
        }
    }
}
