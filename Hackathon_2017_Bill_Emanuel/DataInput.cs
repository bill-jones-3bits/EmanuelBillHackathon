using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Hackathon_2017_Bill_Emanuel
{
    class DataInput
    {
        Excel.Workbook wb;
        Excel.Application app = new Excel.Application();
        StreamWriter f;

        List<List<string>> lines;
        public string LoadFile(string path)
        {
            try
            {
                string outFile = "C:\\tmp\\file.txt";

                var lines = File.ReadAllLines(path);
                this.lines = new List<List<string>>();
                var res = new List<string>();
                foreach (string line in lines)
                {
                    res.Add(ToCsvLine(line));
                    this.lines.Add(line.Split("\t".ToCharArray()).ToList());
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (f != null)
                {
                    f.Close();
                    f = null;
                }
            }
            return string.Empty;
        }

        private static string ToCsvLine(string line)
        {
            return string.Format("\"{0}\"", line.Replace("\t", "\",\""));
        }

        private static string ToCsvLine(IEnumerable<string> line)
        {
            return string.Format("\"{0}\"", string.Join(",", line));
        }

        public string LoadExcelFile(string path)
        {
            throw new NotImplementedException(":c");
            string interimCsv = "C:\\tmp\\tmp.csv";
            string outFile = "C:\\tmp\\file.txt";
            try
            {
                try
                {
                    if (path == string.Empty) return "Path empty.";
                    wb = app.Workbooks.Open(path);
                    //var sheet = app.Worksheets[0];
                    var sheet = (Excel.Worksheet)wb.Worksheets[1];
                    //var cells = new List<List<string>>();

                    f = File.CreateText(outFile);

                    wb.SaveAs(interimCsv, Excel.XlFileFormat.xlCSVWindows, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    return string.Format("File open exception: {0}", ex.ToString());
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
                }
            }
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
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (f != null)
                {
                    f.Close();
                    f = null;
                }
            }

            return string.Empty;
        }

        public string SaveFile(string path)
        {
            try
            {
                File.WriteAllLines(path, this.lines.Select(lineArr => ToCsvLine(lineArr)));
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<string> Headers
        {
            get
            {
                if (lines.Count > 0)
                {
                    return lines[0];
                }
                return null;
            }
        }

        List<Column> columns;
        public List<Column> Columns
        {
            get
            {
                if (lines.Count > 0)
                {
                    if (columns == null)
                    {
                        columns = new List<Column>();
                        var headers = Headers;
                        var ex1 = this.lines.Count > 1 ? this.lines[1] : throw new InvalidDataException("Too few rows!");
                        var ex2 = this.lines.Count > 2 ? this.lines[2] : throw new InvalidDataException("Too few rows!");
                        var ex3 = this.lines.Count > 3 ? this.lines[3] : throw new InvalidDataException("Too few rows!");
                        for (int i = 0; i < Headers.Count; i++)
                        {
                            columns.Add(new Column()
                            {
                                Id = i,
                                Header = headers[i],
                                Example1 = ex1[i],
                                Example2 = ex2[i],
                                Example3= ex3[i]
                            });
                        }
                    }
                    return columns;
                }
                return null;
            }
        }

    }
}
