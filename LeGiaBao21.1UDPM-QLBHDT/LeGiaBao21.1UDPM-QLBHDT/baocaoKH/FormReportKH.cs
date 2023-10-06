using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.baocaoKH
{
    public partial class FormReportKH : Form
    {
        public FormReportKH()
        {
            InitializeComponent();
        }

        private void FormReportKH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetKH.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.dataSetKH.KhachHang);

            this.reportViewer1.RefreshReport();
        }
    }
}
