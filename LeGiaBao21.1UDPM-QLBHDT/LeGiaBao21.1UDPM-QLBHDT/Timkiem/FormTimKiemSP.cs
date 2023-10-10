using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Timkiem
{
    public partial class FormTimKiemSP : Form
    {
        public FormTimKiemSP()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();
     
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaSP())
            {
                string searchText = cbMaSP.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvSanPham.DataSource = from sp in db.SanPhams
                                            where sp.MaSP == cbMaSP.SelectedItem.ToString()
                                            select new
                                            {
                                                sp.MaSP,
                                                sp.TenSP,
                                                sp.MaLoaiHang,
                                                sp.MaCongTy,
                                                sp.DonViTinh,
                                                sp.GiaNhap,
                                                sp.GiaBan,
                                                sp.SoLuong
                                            };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvSanPham.DataSource = null;
                }
            }
            //
            if (dkienTimMaCTY())
            {
                string searchText = cbMaCongTy.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvSanPham.DataSource = from sp in db.SanPhams
                                            where sp.MaCongTy == cbMaCongTy.SelectedItem.ToString()
                                            select new
                                            {
                                                sp.MaSP,
                                                sp.TenSP,
                                                sp.MaLoaiHang,
                                                sp.MaCongTy,
                                                sp.DonViTinh,
                                                sp.GiaNhap,
                                                sp.GiaBan,
                                                sp.SoLuong
                                            };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvSanPham.DataSource = null;
                }
            }
            //
            if (dkienTimMaLH())
            {
                string searchText = cbMaLoaiHang.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvSanPham.DataSource = from sp in db.SanPhams
                                            where sp.MaLoaiHang == cbMaLoaiHang.SelectedItem.ToString()
                                            select new
                                            {
                                                sp.MaSP,
                                                sp.TenSP,
                                                sp.MaLoaiHang,
                                                sp.MaCongTy,
                                                sp.DonViTinh,
                                                sp.GiaNhap,
                                                sp.GiaBan,
                                                sp.SoLuong
                                            };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvSanPham.DataSource = null;
                }
            }
            //
            if (dkienTimTenSP())
            {
                string searchText = txtTenSP.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var sps = from sp in db.SanPhams
                              select sp;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        sps = sps.Where(kh => (kh.TenSP).Contains(key));
                    }

                    dgvSanPham.DataSource = sps.Select(sp => new
                    {
                        sp.MaSP,
                        sp.TenSP,
                        sp.MaLoaiHang,
                        sp.MaCongTy,
                        sp.DonViTinh,
                        sp.GiaNhap,
                        sp.GiaBan,
                        sp.SoLuong
                    }).ToList();
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvSanPham.DataSource = null;
                }
            }
            //
            if (dkienTimDVT())
            {
                string searchText = txtDonViTinh.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvSanPham.DataSource = from sp in db.SanPhams
                                            where sp.DonViTinh == txtDonViTinh.Text.ToString()
                                            select new
                                            {
                                                sp.MaSP,
                                                sp.TenSP,
                                                sp.MaLoaiHang,
                                                sp.MaCongTy,
                                                sp.DonViTinh,
                                                sp.GiaNhap,
                                                sp.GiaBan,
                                                sp.SoLuong
                                            };
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                    dgvSanPham.DataSource = null;
                }
            }

            //
            if (dkienTimSoLuong())
            {
                string searchText = txtSoLuong.Text;

                try
                {

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvSanPham.DataSource = from sp in db.SanPhams
                                                where sp.SoLuong == decimal.Parse(txtSoLuong.Text.ToString())
                                                select new
                                                {
                                                    sp.MaSP,
                                                    sp.TenSP,
                                                    sp.MaLoaiHang,
                                                    sp.MaCongTy,
                                                    sp.DonViTinh,
                                                    sp.GiaNhap,
                                                    sp.GiaBan,
                                                    sp.SoLuong
                                                };
                    }
                    else
                    {
                        // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                        dgvSanPham.DataSource = null;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            //
            if (dkienTimGiaNhap())
            {
                string searchText = txtGiaNhap.Text;

                try
                {

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvSanPham.DataSource = from sp in db.SanPhams
                                                where sp.GiaNhap == decimal.Parse(txtGiaNhap.Text.ToString())
                                                select new
                                                {
                                                    sp.MaSP,
                                                    sp.TenSP,
                                                    sp.MaLoaiHang,
                                                    sp.MaCongTy,
                                                    sp.DonViTinh,
                                                    sp.GiaNhap,
                                                    sp.GiaBan,
                                                    sp.SoLuong
                                                };
                    }
                    else
                    {
                        // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                        dgvSanPham.DataSource = null;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            //
            if (dkienTimGiaBan())
            {
                string searchText = txtGiaBan.Text;

                try
                {

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvSanPham.DataSource = from sp in db.SanPhams
                                                where sp.GiaBan == decimal.Parse(txtGiaBan.Text.ToString())
                                                select new
                                                {
                                                    sp.MaSP,
                                                    sp.TenSP,
                                                    sp.MaLoaiHang,
                                                    sp.MaCongTy,
                                                    sp.DonViTinh,
                                                    sp.GiaNhap,
                                                    sp.GiaBan,
                                                    sp.SoLuong
                                                };
                    }
                    else
                    {
                        // Nếu không có từ khóa tìm kiếm, hiển thị tất cả nhân viên (hoặc không hiển thị gì cả)
                        dgvSanPham.DataSource = null;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }
        private void FormTimKiemSP_Load(object sender, EventArgs e)
        {
            cbMaSP.DataSource = from sp in db.SanPhams select sp.MaSP;
            cbMaSP.SelectedIndex = -1;
            cbMaCongTy.DataSource = from ct in db.NhaCungCaps select ct.MaCongTy;
            cbMaCongTy.SelectedIndex = -1;
            cbMaLoaiHang.DataSource = from lh in db.LoaiHangs select lh.MaLoaiHang;
            cbMaLoaiHang.SelectedIndex = -1;
     
        }
        private void resetTxt()
        {
            cbMaCongTy.SelectedIndex = -1;
            cbMaSP.SelectedIndex = -1;
            cbMaLoaiHang.SelectedIndex = -1;
            txtTenSP.Enabled = true;
            cbMaSP.Enabled = true;
            cbMaCongTy.Enabled = true;
            cbMaLoaiHang.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiaNhap.Enabled = true ;
            txtGiaBan.Enabled = true;
            txtDonViTinh.Enabled = true;
            txtTenSP.ResetText();
            txtDonViTinh.ResetText();
            txtGiaNhap.ResetText();
            txtGiaBan.ResetText();
            txtSoLuong.ResetText();
        }
        private bool dkienTimMaSP()
        {
            return !string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimMaLH()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                !string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimMaCTY()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
               !string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimTenSP()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                !string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimDVT()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                !string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimGiaBan()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                !string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimGiaNhap()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                !string.IsNullOrEmpty(txtGiaNhap.Text) &&
                string.IsNullOrEmpty(txtSoLuong.Text);
        }
        private bool dkienTimSoLuong()
        {
            return string.IsNullOrEmpty(cbMaSP.Text) &&
                string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
                string.IsNullOrEmpty(cbMaCongTy.Text) &&
                string.IsNullOrEmpty(txtTenSP.Text) &&
                string.IsNullOrEmpty(txtDonViTinh.Text) &&
                string.IsNullOrEmpty(txtGiaBan.Text) &&
                string.IsNullOrEmpty(txtGiaNhap.Text) &&
                !string.IsNullOrEmpty(txtSoLuong.Text);
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = from sp in db.SanPhams
                                    select new
                                    {
                                        sp.MaSP,
                                        sp.TenSP,
                                        sp.MaLoaiHang,
                                        sp.MaCongTy,
                                        sp.DonViTinh,
                                        sp.GiaNhap,
                                        sp.GiaBan,
                                        sp.SoLuong
                                    };
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dkienTimMaSP())
            {
                txtTenSP.Enabled = true;
                cbMaCongTy.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
                txtDonViTinh.Enabled = true;
            }
            else
            {
                txtTenSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtSoLuong.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
                txtDonViTinh.Enabled = false;
            }
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            if (!dkienTimTenSP())
            {
                cbMaSP.Enabled = true;
                cbMaCongTy.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
                txtDonViTinh.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtSoLuong.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
                txtDonViTinh.Enabled = false;
            }
        }

        private void cbMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dkienTimMaLH())
            {
                
                cbMaCongTy.Enabled = false;
                cbMaSP.Enabled = true;
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
                txtDonViTinh.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                txtTenSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                txtSoLuong.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
                txtDonViTinh.Enabled = false;
            }
        }

        private void cbMaCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dkienTimMaCTY())
            {
                cbMaSP.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
                txtDonViTinh.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtTenSP.Enabled = false;
                txtSoLuong.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
                txtDonViTinh.Enabled = false;
            }
        }

        private void txtDonViTinh_TextChanged(object sender, EventArgs e)
        {
            if (!dkienTimDVT())
            {
                cbMaSP.Enabled = true;
                cbMaCongTy.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtTenSP.Enabled = false;
                txtSoLuong.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
            }
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (!dkienTimGiaNhap())
            {
                cbMaSP.Enabled = true;
                cbMaCongTy.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonViTinh.Enabled = true;
                txtGiaBan.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtTenSP.Enabled = false;
                txtSoLuong.Enabled = false;
                txtDonViTinh.Enabled = false;
                txtGiaBan.Enabled = false;
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!dkienTimGiaBan())
            {
                cbMaSP.Enabled = true;
                cbMaCongTy.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtTenSP.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonViTinh.Enabled = true;
                txtGiaNhap.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtTenSP.Enabled = false;
                txtSoLuong.Enabled = false;
                txtDonViTinh.Enabled = false;
                txtGiaNhap.Enabled = false;
            }


        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!dkienTimSoLuong())
            {
                cbMaSP.Enabled = true;
                cbMaCongTy.Enabled = true;
                cbMaLoaiHang.Enabled = true;
                txtTenSP.Enabled = true;
                txtDonViTinh.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
            }
            else
            {
                cbMaSP.Enabled = false;
                cbMaCongTy.Enabled = false;
                cbMaLoaiHang.Enabled = false;
                txtTenSP.Enabled = false;
                txtDonViTinh.Enabled = false;
                txtGiaBan.Enabled = false;
                txtGiaNhap.Enabled = false;
            }
        }
    }
}
