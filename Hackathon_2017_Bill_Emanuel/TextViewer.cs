using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackathon_2017_Bill_Emanuel
{
    public partial class TextViewer : Form
    {
        public string Title { get => Text; set { Text = value; } }
        public string TextBlock { get => txtMain.Text; set { txtMain.Text = value; } }
        public TextViewer()
        {
            InitializeComponent();
        }
    }
}
