using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using emanuel.Extensions;

namespace Hackathon_2017_Bill_Emanuel
{
    class DataInput
    {
        Excel.Workbook wb;
        Excel.Application app = new Excel.Application();
        StreamWriter f;
        string separator;
        string inputSeparator;

        int topXExamples = 3;
        bool distinctExamples = false;

        public event EventHandler HeadersReset;

        // lines[row][header]
        List<List<string>> lines;
        public string LoadFile(string path, string inputSeparator, string outputSeparator)
        {
            try
            {
                this.separator = outputSeparator;
                if (inputSeparator == "\\t") inputSeparator = @"    ";

                if (InputSeparatorIncorrect != null)
                {
                    CheckFirstLineSeparator(path, ref inputSeparator);
                }
                if (inputSeparator == string.Empty)
                    return "Cancelled because of empty input separator.";

                this.inputSeparator = inputSeparator;

                var lines = File.ReadAllLines(path);
                this.lines = new List<List<string>>();
                foreach (string line in lines)
                {
                    this.lines.Add(line.Split(inputSeparator.ToCharArray()).ToList());
                }
                this.ResetColumns();
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

        private void CheckFirstLineSeparator(string path, ref string inputSeparator)
        {
            string first = File.ReadLines(path)
                .First();

            if (first.Length - first.Replace(inputSeparator, string.Empty).Length < 3)
            {
                double i = 0.0;
                Func<string, double> FoundLenght = (s =>
               {
                   i = i - 0.1;
                   return first.Length - first.Replace(s, string.Empty).Length + i;                   
               });
                var suggestions = new[] { ";", ",", @"    ", "|" }
                    .Select(s => new { Separator = s, Found = FoundLenght(s) })
                    .OrderByDescending(s => s.Found)
                    .ToList();

                inputSeparator = new InputSeparatorValidation()
                {
                    Path = path,
                    Separator = inputSeparator,
                    UseNewSeparator = false,
                    CancelOpenFile = false,
                    RecommendedNewSeparator = suggestions.First().Separator,
                }.Forward(v => 
                {
                    InputSeparatorIncorrect(v, new EventArgs());
                    return v.UseNewSeparator ? v.RecommendedNewSeparator : v.CancelOpenFile ? string.Empty : v.Separator;
                });
            }
        }

        public delegate void InputSeparatorValidationHandler(InputSeparatorValidation validation, EventArgs e);
        public event InputSeparatorValidationHandler InputSeparatorIncorrect;
        public class InputSeparatorValidation
        {
            public string Path { get; set; }
            public string Separator { get; set; }
            public string RecommendedNewSeparator { get; set; }
            public bool UseNewSeparator { get; set; }
            public bool CancelOpenFile { get; set; }
        }

        private string ToCsvLine(string line)
        {
            return string.Format("\"{0}\"", line.Replace(this.inputSeparator, string.Format("\"{0}\"", this.separator)));
        }

        private string ToCsvLine(IEnumerable<string> line, bool header, string sep, bool skipQuotes = false, bool includeQuotesForDoubles = true, bool? commaDelimiter = null)
        {
            string quote = skipQuotes ? string.Empty : "\"";
            if (sep == string.Empty) sep = this.separator;
            if (skipQuotes)
            {
                return string.Format("{1}{0}{1}", string.Join(string.Concat(quote, this.separator, quote), line), quote);
            }

            if (line.Count() != this.Columns.Count()) { throw new Exception("Mismatch between line lenght and column count!"); }
            var newLine = new List<string>();
            string val = string.Empty;
            quote = "\"";
            Func<string, string> quoted = new Func<string, string>(x => string.Concat(quote, x, quote));
            for (int i = 0; i < line.Count(); i++)
            {
                val = line.ElementAt(i);
                var t = header ? ColumnType.String : Columns[i].Type;
                switch (t)
                {
                    case ColumnType.Double:
                        if (commaDelimiter.HasValue)
                            val = commaDelimiter.Value ? val.Replace(".", ",") : val.Replace(",", ".");
                        if (!includeQuotesForDoubles)
                            newLine.Add(val);
                        else
                            newLine.Add(quoted(val));
                        break;
                    case ColumnType.Int:
                        newLine.Add(val);
                        break;
                    case ColumnType.String:
                        newLine.Add(quoted(val));
                        break;
                }
            }
            return string.Format("{0}", string.Join(this.separator, newLine));
        }

        public string LoadExcelFile(string path)
        {
            // cheers
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

        public string SaveFile(string path, string separator, bool useQuotes = true, bool includeQuotesForDoubles = true, bool? commaDelimiter = null)
        {
            try
            {
                this.separator = separator;
                bool skipQuotes = !useQuotes;
                if (separator == "\t" || separator == @"   ") { skipQuotes = true; }
                RenameUniqueHeaders();
                UpdateTypes();
                var body = this.lines.Skip(1).Select(lineArr => ToCsvLine(lineArr, false, this.inputSeparator, skipQuotes: skipQuotes, includeQuotesForDoubles: includeQuotesForDoubles, commaDelimiter: commaDelimiter)).ToList();
                body.Insert(0, ToCsvLine(Headers, header: true, sep: separator, skipQuotes: skipQuotes));
                File.WriteAllLines(path, body);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private void RenameUniqueHeaders()
        {
            var names = new Dictionary<string, int>();
            foreach (var c in Columns)
            {
                if (names.ContainsKey(c.Header))
                {
                    int count = names[c.Header] + 1;
                    this.lines[0][c.Id] = string.Format("{0}_{1}", c.Header, count);
                    names[c.Header] = count;
                }
                else
                {
                    names.Add(c.Header, 1);
                }
            }
            ResetColumns();
        }

        private void UpdateTypes()
        {
            double d;
            Func<string, string> repl = new Func<string, string>(v => v.Replace("-", string.Empty).Replace(",", string.Empty).Replace(".", string.Empty));
            foreach (var col in this.Columns)
            {
                try
                {
                    var values = lines.Select(line => line[col.Id]).Skip(1);
                    if (values.Any(v => repl(v).Any(c => !char.IsNumber(c))))
                    {
                        col.Type = ColumnType.String;
                        col.StringExample = values.Skip(3).Any(v => repl(v).Any(c => !char.IsNumber(c))) ?
                            values.Skip(3).First(v => repl(v).Any(c => !char.IsNumber(c)))
                            : string.Empty;
                        continue;
                    }
                    else
                    {
                        if (!values.Any(v => v.Contains(",") || v.Contains(".")) && values.All(v => repl(v).All(c => char.IsNumber(c))))
                        {
                            col.Type = ColumnType.Int;
                            continue;
                        }
                        if (values.All(v => double.TryParse(v, out d)))
                        {
                            col.Type = ColumnType.Double;
                            var example = values.Skip(3).FirstOrDefault(v => v.Contains(",") || v.Contains("."));
                            if (string.IsNullOrEmpty(example)) example = values.Last();
                            col.DoubleExample = example;
                            continue;
                        }
                        col.Type = ColumnType.String;
                        col.StringExample = string.Concat(values.Skip(3).First(v => v.Any(c => !char.IsNumber(c))), "??");
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void UpdateExamples(int top = 3, bool distinct = false)
        {
            if (top != topXExamples || distinct != distinctExamples)
            {
                (topXExamples, distinctExamples) = (top, distinct);

                ResetColumns();
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

        internal List<string> GetDistinct(Column c)
            => lines
                .Skip(1)
                .Select(line => line[c.Id])
                .Distinct()
                .OrderBy(s => s)
                .ToList();

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

                        if (this.lines.Count < topXExamples)
                            throw new InvalidDataException("Too few rows!");
                        
                        for (int i = 0; i < Headers.Count; i++)
                        {
                            _columns.Add(new Column()
                            {
                                Id = i,
                                Header = Headers[i],
                                Examples = lines
                                    .Skip(1)
                                    .Select(line => line[i])
                                    .Forward(ls => distinctExamples ? ls.Distinct() : ls)
                                    .Take(Math.Max(topXExamples - 1, 0))
                                    .ToList()
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

        internal string DoubleToInt(Column column)
        {
            bool rounded = false;
            bool header = true;
            string fromExample = string.Empty;
            string toExample = string.Empty;
            string from = string.Empty;
            string value = string.Empty;
            double d;
            foreach (var line in this.lines)
            {
                if (header) { header = false; continue; }

                from = line[column.Id];
                value = line[column.Id];

                if (fromExample == string.Empty) { fromExample = from; toExample = value; }

                if (value.Count(c => c == '.') > 1) value = value.Replace(".", string.Empty);
                if (value.Count(c => c == '.') == 1) value = value.Replace(".", ",");
                if(double.TryParse(value, out d))
                {
                    value = ((int)Math.Round(d)).ToString();
                    fromExample = from;
                    toExample = value;
                }
                line[column.Id] = value;
            }
            string name = column.Header;
            this.ResetColumns();
            return string.Format("Changed column {0} to integers! For example {1} turned into {2}. {3}", name, fromExample, toExample, rounded ? "Had to round floats." : string.Empty);
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
            bool isHeader = true;
            foreach (var line in this.lines)
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }
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
            try
            {
                string problemFound = string.Empty;
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
                            if (DateTime.TryParse(d, out date))
                            {
                                line[id] = date.Year.ToString();
                                line.Insert(id + 1, date.Month.ToString());
                                line.Insert(id + 2, date.Day.ToString());
                            }
                            else
                            {
                                line[id] = d;
                                line.Insert(id + 1, d);
                                line.Insert(id + 2, d);
                                problemFound = "Please note some values were not dates, they have been spread across all three new columns.";
                            }
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
                return string.Format("Split date column {0}. {1}", name, problemFound);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        internal string SplitTextsInColumns(List<Column> sel, string separator)
        {
            try
            {
                char[] sep = separator.ToCharArray();
                var newTexts = new List<string[]>();
                int previousColId = -1;
                foreach (var col in sel) // Split one column at a time.
                {
                    var colId = Columns.FirstOrDefault(c => c.Header == col.Header).Id;
                    if (previousColId == colId)
                    {
                        return string.Format("Problem: Column {0} with id {1} would be split several times! Try only splitting one column at a time, or renaming them so they are unique first.", col.Header, col.Id);
                    }
                    int newColumns = 0;
                    foreach (var line in lines) // Save each line's split-result into the newTexts list:
                    {
                        newTexts.Add(line[colId].Split(sep));
                        newColumns = Math.Max(newColumns, newTexts.Last().Count());
                    }
                    // Insert the new values
                    bool isHeader = true;
                    for (int line = 0; line < lines.Count; line++)
                    {
                        lines[line][colId] = newTexts[line][0];
                        for (int i = 1; i < newColumns; i++)
                        {
                            string item = newTexts[line][i];
                            if (string.IsNullOrEmpty(item) && isHeader)
                            {
                                item = string.Format("{0}_splt_{1}", newTexts[line][0], i);
                            }
                            lines[line].Insert(colId + i, item);
                        }
                        isHeader = false;
                    }
                    previousColId = colId;
                    ResetColumns();
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            return "Split done!";
        }

        internal string RenameColumn(Column sel, string newHeader)
        {
            try
            {
                lines[0][sel.Id] = newHeader;
                ResetColumns();
                return string.Format("renamed ok, new header {0}", newHeader);
            }
            catch
            {
                return "Problem! :/";
            }
        }

        public string MoveColumnLast(Column c)
        {
            try
            {
                foreach (var line in lines)
                {
                    string move = line[c.Id];
                    line.RemoveAt(c.Id);
                    line.Add(move);
                }
                ResetColumns();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void ResetColumns()
        {
            this._columns = null;
            UpdateTypes();
            if (this.HeadersReset != null)
            {
                HeadersReset(this.Columns, new EventArgs());
            }
        }

    }
}
