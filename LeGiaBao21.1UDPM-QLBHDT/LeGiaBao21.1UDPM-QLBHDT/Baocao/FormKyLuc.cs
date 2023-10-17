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
    public partial class FormKyLuc : Form
    {
        public FormKyLuc()
        {
            InitializeComponent();
        }

        private void FormKyLuc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.KhachHang_vip' table. You can move, or remove it, as needed.
            this.khachHang_vipTableAdapter.Fill(this.dataSet.KhachHang_vip);
            // TODO: This line of code loads data into the 'dataSet.NhanVien_1_DT' table. You can move, or remove it, as needed.
            this.nhanVien_1_DTTableAdapter.Fill(this.dataSet.NhanVien_1_DT);
            // TODO: This line of code loads data into the 'dataSet.NhanVien_1_DH' table. You can move, or remove it, as needed.
            this.nhanVien_1_DHTableAdapter.Fill(this.dataSet.NhanVien_1_DH);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }
    }
}
