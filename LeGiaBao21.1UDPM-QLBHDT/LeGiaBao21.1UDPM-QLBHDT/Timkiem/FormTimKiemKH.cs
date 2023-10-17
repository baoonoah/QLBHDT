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
    public partial class FormTimKiemKH : Form
    {
        public FormTimKiemKH()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaKH())
            {
                string searchText = cbMaKH.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvKhachHang.DataSource = from kh in db.KhachHangs
                                              where kh.MaKH == cbMaKH.SelectedItem.ToString()
                                              select new
                                              {
                                                  kh.MaKH,
                                                  kh.TenKH,
                                                  kh.DiaChi,
                                                  kh.DienThoai,
                                                  kh.Email
                                              };
                }
                else
                {
                    dgvKhachHang.DataSource = null;
                }
            }
            //
            if (dkienTimTenKH())
            {
                string searchText = txtTenKH.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var khachhang = from kh in db.KhachHangs
                              select kh;

                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        khachhang = khachhang.Where(kh => (kh.TenKH).Contains(key));
                    }

                    dgvKhachHang.DataSource = khachhang.Select(kh => new
                    {
                        kh.MaKH,
                        kh.TenKH,
                        kh.DiaChi,
                        kh.DienThoai,
                        kh.Email
                    }).ToList();
                }
                else
                {
                    dgvKhachHang.DataSource = null;
                }
            }
            //
            /*      if (dkienTimDC())
                  {
                      string searchText = txtDiaChi.Text;
                      if (!string.IsNullOrEmpty(searchText))
                      {
                          dgvKhachHang.DataSource = from kh in db.KhachHangs
                                                    where kh.DiaChi == txtDiaChi.Text.ToString()
                                                    select new
                                                    {
                                                        kh.MaKH,
                                                        kh.TenKH,
                                                        kh.DiaChi,
                                                        kh.DienThoai,
                                                        kh.Email
                                                    };
                      }
                      else
                      {
                          // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                          dgvKhachHang.DataSource = null;
                      }

                  }*/
            if (dkienTimDC())
            {

                string searchText = txtDiaChi.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var tkkh = from kh in db.KhachHangs
                               select kh;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        tkkh = tkkh.Where(kh => (kh.DiaChi).Contains(key));
                    }

                    dgvKhachHang.DataSource = tkkh.Select(kh => new
                    {
                        kh.MaKH,
                        kh.TenKH,
                        kh.DiaChi,
                        kh.DienThoai,
                        kh.Email
                    }).ToList();
                }
                else
                {
                    dgvKhachHang.DataSource = null;
                }
            }
                //
                if (dkienTimSDT())
            {
                string searchText = txtDienThoai.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvKhachHang.DataSource = from kh in db.KhachHangs
                                              where kh.DienThoai == txtDienThoai.Text.ToString()
                                              select new
                                              {
                                                  kh.MaKH,
                                                  kh.TenKH,
                                                  kh.DiaChi,
                                                  kh.DienThoai,
                                                  kh.Email
                                              };
                }
                else
                {
                    dgvKhachHang.DataSource = null;
                }
            }
            //
            if (dkienTimEmail())
            {
                string searchText = txtEmail.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvKhachHang.DataSource = from kh in db.KhachHangs
                                              where kh.Email == txtEmail.Text.ToString()
                                              select new
                                              {
                                                  kh.MaKH,
                                                  kh.TenKH,
                                                  kh.DiaChi,
                                                  kh.DienThoai,
                                                  kh.Email
                                              };
                }
                else
                {
                    dgvKhachHang.DataSource = null;
                }
            }
        }
        private void resetTxt()
        {
            cbMaKH.SelectedIndex = -1;
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            txtEmail.ResetText();
            cbMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            txtEmail.Enabled = true;

        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void FormTimKiemKH_Load(object sender, EventArgs e)
        {
            cbMaKH.DataSource = from kh in db.KhachHangs select kh.MaKH;
            cbMaKH.SelectedIndex = -1;

        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaKH())
            {
                txtTenKH.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtEmail.Enabled = false;
            }
            else
            {
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimTenKH())
            {
                cbMaKH.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtEmail.Enabled = false;
            }
            else
            {
                cbMaKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimDC())
            {
                cbMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtDienThoai.Enabled = false;
                txtEmail.Enabled = false;
            }
            else
            {
                cbMaKH.Enabled = true;
                txtTenKH.Enabled = true;
                txtDienThoai.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimSDT())
            {
                cbMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtDiaChi.Enabled = false;
                txtEmail.Enabled = false;
            }
            else
            {
                cbMaKH.Enabled = true;
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtEmail.Enabled = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimEmail())
            {
                cbMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
            }
            else
            {
                cbMaKH.Enabled = true;
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
            }
        }
        private bool dkienTimMaKH()
        {
            string makh = cbMaKH.Text;
            string hoten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string email = txtEmail.Text;
            return !string.IsNullOrEmpty(makh) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(email);
        }
        private bool dkienTimTenKH()
        {
            string makh = cbMaKH.Text;
            string hoten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string email = txtEmail.Text;
            return string.IsNullOrEmpty(makh) &&
                !string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(email);
        }
        private bool dkienTimDC()
        {
            string makh = cbMaKH.Text;
            string hoten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string email = txtEmail.Text;
            return string.IsNullOrEmpty(makh) &&
                string.IsNullOrEmpty(hoten) && !string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(email);
        }
        private bool dkienTimSDT()
        {
            string makh = cbMaKH.Text;
            string hoten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string email = txtEmail.Text;
            return string.IsNullOrEmpty(makh) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && !string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(email);
        }
        private bool dkienTimEmail()
        {
            string makh = cbMaKH.Text;
            string hoten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string email = txtEmail.Text;
            return string.IsNullOrEmpty(makh) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && !string.IsNullOrEmpty(email);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = from kh in db.KhachHangs
                                     select kh;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
