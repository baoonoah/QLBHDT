using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thi_de2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void soDauBaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new bieumau.Form_SO_DAU_BAI();
            frm.Text = "So Dau Bai";
            frm.ShowDialog();
        }

        private void baoCaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Baocao.baocao();
            frm.Text = "Bao Cao";
            frm.ShowDialog();
        }
    }
}
