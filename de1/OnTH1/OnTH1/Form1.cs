using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTH1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void thietBiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new YeuCau2.FormTHIET_BI();
            frm.Text = "Thiet Bi";
            frm.ShowDialog();
        }

        private void thongTInSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
    }
}
