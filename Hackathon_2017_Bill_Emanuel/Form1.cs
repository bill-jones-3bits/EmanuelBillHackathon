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

        XlsInput x = new XlsInput();

        private void btnImport_Click(object sender, EventArgs e)
        {
            var d = new OpenFileDialog() { Filter = "*.xlsx|*.xlsx" };
            var r = d.ShowDialog();
            if (r == DialogResult.OK)
            {
                string err = x.LoadFile(d.FileName);
                if (!string.IsNullOrEmpty(err))
                    txtResult.Text = err;
            }
        }
    }
}
