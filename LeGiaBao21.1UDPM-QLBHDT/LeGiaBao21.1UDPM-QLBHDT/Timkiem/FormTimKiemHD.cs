using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Timkiem
{
    public partial class FormTimKiemHD : Form
    {
        public FormTimKiemHD()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();
        private void FormTimKiemHD_Load(object sender, EventArgs e)
        {
            cbMaHD.DataSource = from hd in db.HoaDons select hd.MaHD;
            cbMaHD.SelectedIndex = -1;
            cbMaNV.DataSource = from nv in db.NhanViens select nv.MaNV;
            cbMaNV.SelectedIndex = -1;
            cbMaKH.DataSource = from kh in db.KhachHangs select kh.MaKH;
            cbMaKH.SelectedIndex = -1;
        }
        private void resetTxt()
        {
            cbMaHD.SelectedIndex = -1;
            cbMaNV.SelectedIndex = -1;
            cbMaKH.SelectedIndex = -1;
            dtpNgayLapHD.ResetText();
            cbMaHD.Enabled = true;
            cbMaNV.Enabled = true;
            cbMaKH.Enabled = true;
            dtpNgayLapHD.Enabled = true;
         
        }
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = from hd in db.HoaDons
                                   select new
                                   {
                                       hd.MaHD,
                                       hd.MaNV,
                                       hd.MaKH,
                                       hd.NgayLapHD,
                                       hd.NgayNhanHang
                                   };
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaHD())
            {
                string searchText = cbMaHD.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvHoaDon.DataSource = from hd in db.HoaDons
                                            where hd.MaHD == cbMaHD.SelectedItem.ToString()
                                            select new
                                            {
                                                hd.MaHD,
                                                hd.MaNV,
                                                hd.MaKH,
                                                hd.NgayLapHD,
                                                hd.NgayNhanHang
                                            };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvHoaDon.DataSource = null;
                }
            }
            //
            if (dkienTimMaNV())
            {
                string searchText = cbMaNV.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvHoaDon.DataSource = from hd in db.HoaDons
                                           where hd.MaNV == cbMaNV.SelectedItem.ToString()
                                           select new
                                           {
                                               hd.MaHD,
                                               hd.MaNV,
                                               hd.MaKH,
                                               hd.NgayLapHD,
                                               hd.NgayNhanHang
                                           };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvHoaDon.DataSource = null;
                }
            }
            //
            if (dkienTimMaKH())
            {
                string searchText = cbMaKH.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvHoaDon.DataSource = from hd in db.HoaDons
                                           where hd.MaKH == cbMaKH.SelectedItem.ToString()
                                           select new
                                           {
                                               hd.MaHD,
                                               hd.MaNV,
                                               hd.MaKH,
                                               hd.NgayLapHD,
                                               hd.NgayNhanHang
                                           };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvHoaDon.DataSource = null;
                }
            }
            //

            if (dkienTimNgayLapHD())
            {
                dgvHoaDon.DataSource = from hd in db.HoaDons
                                         where hd.NgayLapHD == DateTime.Parse(dtpNgayLapHD.Text.ToString())
                                         select new
                                        {
                                             hd.MaHD,
                                             hd.MaNV,
                                             hd.MaKH,
                                             hd.NgayLapHD,
                                             hd.NgayNhanHang
                                        };

            }
            //
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaHD())
            {
                cbMaNV.Enabled = false;
                cbMaKH.Enabled = false;
                dtpNgayLapHD.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                cbMaKH.Enabled = true;
                dtpNgayLapHD.Enabled = true;
            }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaNV())
            {
                cbMaHD.Enabled = false;
                cbMaKH.Enabled = false;
                dtpNgayLapHD.Enabled = false;
            }
            else
            {
                cbMaHD.Enabled = true;
                cbMaKH.Enabled = true;
                dtpNgayLapHD.Enabled = true;
            }
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaKH())
            {
                cbMaHD.Enabled = false;
                cbMaNV.Enabled = false;
                dtpNgayLapHD.Enabled = false;
            }
            else
            {
                cbMaHD.Enabled = true;
                cbMaNV.Enabled = true;
                dtpNgayLapHD.Enabled = true;
            }
        }

        private void dtpNgayLapHD_ValueChanged(object sender, EventArgs e)
        {
            if (dkienTimNgayLapHD())
            {
                cbMaHD.Enabled = false;
                cbMaNV.Enabled = false;
                cbMaKH.Enabled = false;
            }
            else
            {
                cbMaHD.Enabled = true;
                cbMaNV.Enabled = true;
                cbMaKH.Enabled = true;
            }
        }

        
        private bool dkienTimMaHD()
        {
            return !string.IsNullOrEmpty(cbMaHD.Text) &&
                string.IsNullOrEmpty(cbMaNV.Text) &&
                string.IsNullOrEmpty(cbMaKH.Text) ;
        }
        private bool dkienTimMaNV()
        {
            return string.IsNullOrEmpty(cbMaHD.Text) &&
                !string.IsNullOrEmpty(cbMaNV.Text) &&
                string.IsNullOrEmpty(cbMaKH.Text) ;
        }
        private bool dkienTimMaKH()
        {
            return string.IsNullOrEmpty(cbMaHD.Text) &&
                string.IsNullOrEmpty(cbMaNV.Text) &&
                !string.IsNullOrEmpty(cbMaKH.Text) ;
        }
        private bool dkienTimNgayLapHD()
        {
            return string.IsNullOrEmpty(cbMaHD.Text) &&
                string.IsNullOrEmpty(cbMaNV.Text) &&
                string.IsNullOrEmpty(cbMaKH.Text) &&
                !string.IsNullOrEmpty(dtpNgayLapHD.Value.ToShortDateString());
         
                
        }

    }
}
