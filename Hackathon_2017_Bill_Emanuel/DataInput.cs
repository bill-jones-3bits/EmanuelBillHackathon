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
        string separator;

        List<List<string>> lines;
        public string LoadFile(string path, string separator)
        {
            try
            {
                string outFile = "C:\\tmp\\file.txt";
                this.separator = separator;

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

        private string ToCsvLine(string line)
        {
            return string.Format("\"{0}\"", line.Replace("\t", string.Format("\"{0}\"", this.separator)));
        }

        private string ToCsvLine(IEnumerable<string> line)
        {
            return string.Format("\"{0}\"", string.Join(string.Concat("\"", this.separator, "\""), line));
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

        List<Column> _columns;
        public List<Column> Columns
        {
            get
            {
                if (lines.Count > 0)
                {
                    if (_columns == null)
                    {
                        _columns = new List<Column>();
                        var headers = Headers;
                        var ex1 = this.lines.Count > 1 ? this.lines[1] : throw new InvalidDataException("Too few rows!");
                        var ex2 = this.lines.Count > 2 ? this.lines[2] : throw new InvalidDataException("Too few rows!");
                        var ex3 = this.lines.Count > 3 ? this.lines[3] : throw new InvalidDataException("Too few rows!");
                        for (int i = 0; i < Headers.Count; i++)
                        {
                            _columns.Add(new Column()
                            {
                                Id = i,
                                Header = headers[i],
                                Example1 = ex1[i],
                                Example2 = ex2[i],
                                Example3= ex3[i]
                            });
                        }
                    }
                    return _columns;
                }
                return null;
            }
        }

        public string RemoveColumn(Column column)
        {
            int id = Columns.FirstOrDefault(c => c.Header == column.Header).Id;
            foreach (var line in this.lines)
            {
                line.RemoveAt(id);
            }
            string name = column.Header;
            this.ResetColumns();
            return string.Format("Removed column {0}", name);
        }

        public string ReplaceColumnValue(Column column, string replaceText, string withText)
        {
            foreach (var line in this.lines)
            {
                line[column.Id] = line[column.Id].Replace(replaceText, withText);
            }
            string name = column.Header;
            this.ResetColumns();
            return string.Format("Replaced value {0} in column {1} with {2}", replaceText, name, withText);
        }

        public string ReplaceEmptyOrNonEmpty(Column column, string withText, bool empty)
        {
            foreach (var line in this.lines)
            {
                bool replace = empty ? string.IsNullOrEmpty(line[column.Id]) : !string.IsNullOrEmpty(line[column.Id]);
                if (replace)
                {
                    line[column.Id] = withText;
                }
            }
            string name = column.Header;
            this.ResetColumns();
            return string.Format("Set non empty values in {0} to {1}", name, withText);
        }

        public string SplitDateColumn(Column column)
        {
            int id = Columns.FirstOrDefault(c => c.Header == column.Header).Id;
            bool header = true;
            foreach (var line in this.lines)
            {
                string d = line[id];
                DateTime date;
                if (header)
                {
                    line[id] = string.Concat(d, "_year");
                    line.Insert(id + 1, string.Concat(d, "_month"));
                    line.Insert(id + 2, string.Concat(d, "_day"));
                    header = false;
                }
                else
                {
                    if (!string.IsNullOrEmpty(d))
                    {
                        date = DateTime.Parse(d);
                        line[id] = date.Year.ToString();
                        line.Insert(id + 1, date.Month.ToString());
                        line.Insert(id + 2, date.Day.ToString());
                    }
                    else
                    {
                        line.Insert(id + 1, d);
                        line.Insert(id + 2, d);
                    }
                }
            }
            string name = column.Header;
            this.ResetColumns();
            return string.Format("Split date column {0}", name);
        }

        public void ResetColumns()
        {
            this._columns = null;
        }

    }
}
