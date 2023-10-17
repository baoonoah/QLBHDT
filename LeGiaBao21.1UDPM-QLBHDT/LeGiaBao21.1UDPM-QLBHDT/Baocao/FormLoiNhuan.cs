using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Baocao
{
    public partial class FormLoiNhuan : Form
    {
        public FormLoiNhuan()
        {
            InitializeComponent();
        }

        private void FormLoiNhuan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.LoiNhuanSP' table. You can move, or remove it, as needed.
            this.loiNhuanSPTableAdapter.Fill(this.dataSet1.LoiNhuanSP);
            // TODO: This line of code loads data into the 'dataSet1.LoiNhuanThang' table. You can move, or remove it, as needed.
            this.loiNhuanThangTableAdapter.Fill(this.dataSet1.LoiNhuanThang);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}
