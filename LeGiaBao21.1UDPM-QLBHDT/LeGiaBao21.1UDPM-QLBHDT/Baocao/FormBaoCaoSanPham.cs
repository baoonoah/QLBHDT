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
    public partial class FormBaoCaoSanPham : Form
    {
        public FormBaoCaoSanPham()
        {
            InitializeComponent();
        }

        private void FormBaoCaoSanPham_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.SanPhamBanRa' table. You can move, or remove it, as needed.
            this.sanPhamBanRaTableAdapter.Fill(this.dataSet.SanPhamBanRa);
            // TODO: This line of code loads data into the 'dataSet.SanPhamTonKho' table. You can move, or remove it, as needed.
            this.sanPhamTonKhoTableAdapter.Fill(this.dataSet.SanPhamTonKho);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}
