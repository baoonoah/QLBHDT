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
    public partial class FormBaoCaoDoanhThu : Form
    {
        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void FormBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.DoanhThuKhachHang' table. You can move, or remove it, as needed.
            this.doanhThuKhachHangTableAdapter.Fill(this.dataSet.DoanhThuKhachHang);
            // TODO: This line of code loads data into the 'dataSet.DoanhThuSP' table. You can move, or remove it, as needed.
            this.doanhThuSPTableAdapter.Fill(this.dataSet.DoanhThuSP);
            // TODO: This line of code loads data into the 'dataSet.DoanhThuTheoQui' table. You can move, or remove it, as needed.
            this.doanhThuTheoQuiTableAdapter.Fill(this.dataSet.DoanhThuTheoQui);
            // TODO: This line of code loads data into the 'dataSet.DoanhThuTheoNam' table. You can move, or remove it, as needed.
            this.doanhThuTheoNamTableAdapter.Fill(this.dataSet.DoanhThuTheoNam);
            // TODO: This line of code loads data into the 'dataSet.DoanhThuTheoThang' table. You can move, or remove it, as needed.
            this.doanhThuTheoThangTableAdapter.Fill(this.dataSet.DoanhThuTheoThang);
            // TODO: This line of code loads data into the 'dataSet.DoanhThuTheoNgay' table. You can move, or remove it, as needed.
            this.doanhThuTheoNgayTableAdapter.Fill(this.dataSet.DoanhThuTheoNgay);

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer6.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
