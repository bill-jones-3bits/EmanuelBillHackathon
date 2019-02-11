using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using emanuel.Extensions;

namespace Hackathon_2017_Bill_Emanuel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            x.HeadersReset += HeadersResetHandler;
            x.InputSeparatorIncorrect += X_InputSeparatorIncorrect;
        }

        private void X_InputSeparatorIncorrect(DataInput.InputSeparatorValidation validation, EventArgs e)
        {
            var r = MessageBox.Show($"Separator '{validation.Separator}' may be incorrect! Do you want to use '{validation.RecommendedNewSeparator}' instead?", validation.Path, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                validation.UseNewSeparator = true;
                txtInputSeparator.Text = validation.RecommendedNewSeparator;
            }
            if (r == DialogResult.Cancel)
                validation.CancelOpenFile = true;
        }

        DataInput x = new DataInput();

        void HeadersResetHandler(object o, EventArgs e)
        {
            lstHeaders.DataSource = x.Columns;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var d = new OpenFileDialog() { Filter = "*|*|*.txt|*.txt" };
            var r = d.ShowDialog();
            if (string.IsNullOrEmpty(this.txtSeparator.Text))
            {
                txtResult.Text = "Separator missing!";
                return;
            }
            if (r == DialogResult.OK)
            {
                LoadFile(d.FileName);
            }
        }

        private void LoadFile(string fileName)
        {
            string err = x.LoadFile(fileName, this.txtInputSeparator.Text, this.txtSeparator.Text);
            if (!string.IsNullOrEmpty(err))
            {
                txtResult.Text = err;
            }
            else
            {
                txtResult.Text = string.Format("File loaded with input csv separator '{0}', and will be saved with separator '{1}'!", this.txtInputSeparator.Text, this.txtSeparator.Text);
            }
            txtOutFile.Text = fileName.Replace(".csv_input.txt", ".csv").Replace(".txt", ".csv");

            this.lstHeaders.DataSource = x.Columns;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool comma = rdoComma.Checked;
            string res = x.SaveFile(this.txtOutFile.Text, this.txtSeparator.Text, commaDelimiter: comma);
            if (string.IsNullOrEmpty(res))
            {
                this.txtResult.Text = "Saved!";
                
            }
            else
            {
                this.txtResult.Text = res;
            }
        }

        private void btnSaveAsInput_Click(object sender, EventArgs e)
        {
            string dotTxt = this.txtOutFile.Text;
            if (!dotTxt.ToLower().EndsWith(".txt")) dotTxt += "_input.txt";
            string res = x.SaveFile(dotTxt, this.txtInputSeparator.Text, false, this.chkDoubleMeansQuotes.Checked);
            if (string.IsNullOrEmpty(res))
            {
                this.txtResult.Text = string.Format("Saved as {0}!", dotTxt);

            }
            else
            {
                this.txtResult.Text = res;
            }
        }

        private void btnColumnRemove_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedColumns();
            Foreach(sel, (x, col) => x.RemoveColumn(col));
        }

        private void btnColDateToYearMonth_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedColumns();
            Foreach(sel, (x, col) => x.SplitDateColumn(col));
        }

        private void btnReplaceEmpty_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedColumns();
            Foreach(sel, (x, col) => x.ReplaceEmptyOrNonEmpty(col, this.txtReplaceEmpty.Text, true));
        }

        private void btnReplaceNonEmpty_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedColumns();
            Foreach(sel, (x, col) => x.ReplaceEmptyOrNonEmpty(col, this.txtReplaceNonEmpty.Text, false));
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedColumns();
            Foreach(sel, (x, col) => x.ReplaceColumnValue(col, this.txtReplace.Text, this.txtReplaceWith.Text));
        }

        private void Foreach(List<Column> columns, Action<DataInput, Column> action)
        {
            foreach (Column column in lstHeaders.SelectedItems)
            {
                action(this.x, column);
            }
        }
        
        private List<Column> GetSelectedColumns()
        {
            var sel = new List<Column>();
            foreach (Column column in lstHeaders.SelectedItems)
            {
                sel.Add(column);
            }
            return sel;
        }

        private Column GetFirstSelectedColumn()
        {
            return (Column)lstHeaders.SelectedItems[0];
        }

        private void btnMoveColumnLast_Click(object sender, EventArgs e)
        {
            try
            {
                var sel = GetFirstSelectedColumn();
                string res = x.MoveColumnLast(sel);
                if (!string.IsNullOrEmpty(res))
                {
                    this.txtResult.Text = res;
                }
            }
            catch
            {
                this.txtResult.Text = "Unknown error!";
            }
        }

        private void btnSplitText_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSplitSeparator.Text))
                {
                    this.txtResult.Text = "Please write a separator in the box next to the split button.";
                    return;
                }
                var sel = GetSelectedColumns();
                this.txtResult.Text = x.SplitTextsInColumns(sel, this.txtSplitSeparator.Text);
            }
            catch (Exception ex)
            {

                this.txtResult.Text = ex.ToString();
            }
        }

        private void btnRenameHeader_Click(object sender, EventArgs e)
        {
            var sel = GetFirstSelectedColumn();
            this.txtResult.Text = x.RenameColumn(sel, txtRenameHeader.Text);
        }

        private void btnToInt_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedColumns();
            var res = new List<string>();
            Foreach(sel, (x, col) => res.Add(x.DoubleToInt(col)));
            x.ResetColumns();
            this.txtResult.Text = string.Join(Environment.NewLine, res);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var link = e.Data.GetData(DataFormats.FileDrop);

            try
            {
                if (link != null && link is string[])
                {
                    var files = ((string[])link);
                    if (files.Count() >= 1)
                    {
                        string file = files.First();
                        if (file.EndsWith(".txt") || file.EndsWith(".csv"))
                        {
                            LoadFile(file);
                        }
                        else
                        {
                            txtResult.Text = "I think we need .txt or .csv friend.";
                        }
                    }
                    else
                    {
                        txtResult.Text = "No file found";
                    }
                }
                else txtResult.Text = "Not a proper file! I think";
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.ToString();
            }
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            var ee = e;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else e.Effect = DragDropEffects.None;
        }

        private bool EnterPressed(KeyPressEventArgs e)
        => e.KeyChar == (char)13;

        private void txtDisplayTopX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                chkDisplayDistinctExamples_CheckedChanged(sender, e);
            }
        }

        private void chkDisplayDistinctExamples_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkDisplayDistinctExamples.Text = chkDisplayDistinctExamples.Checked ? "Distinct top" : "Top";
                if (int.TryParse(txtDisplayTopX.Text, out int top))
                {
                    x.UpdateExamples(top, chkDisplayDistinctExamples.Checked);
                }
                else
                {
                    txtResult.Text = string.Concat(txtDisplayTopX.Text, " is not an integer!");
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }

        private void btnShowDistinct_Click(object sender, EventArgs e)
        {
            GetSelectedColumns()
                .Do(cols =>
                {
                    if (cols.Count() == 1)
                    {
                        var c = cols.First();

                        new TextViewer()
                        {
                            Title = "View distinct ",
                            TextBlock = x.GetDistinct(c)
                                .AggregateToString(Environment.NewLine)
                        }
                        .ShowDialog();
                    }
                });
        }
    }
}
