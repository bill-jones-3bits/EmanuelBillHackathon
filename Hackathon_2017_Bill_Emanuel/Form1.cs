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

namespace Hackathon_2017_Bill_Emanuel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataInput x = new DataInput();

        private void btnImport_Click(object sender, EventArgs e)
        {
            var d = new OpenFileDialog() { Filter = "*.txt|*.txt" };
            var r = d.ShowDialog();
            if (r == DialogResult.OK)
            {
                string err = x.LoadFile(d.FileName);
                if (!string.IsNullOrEmpty(err))
                    txtResult.Text = err;

                this.lstHeaders.DataSource = x.Columns;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string res = x.SaveFile(this.txtOutFile.Text);
            if (string.IsNullOrEmpty(res))
            {
                this.txtResult.Text = "Saved!";
                
            }
            else
            {
                this.txtResult.Text = res;
            }
        }
    }
}
