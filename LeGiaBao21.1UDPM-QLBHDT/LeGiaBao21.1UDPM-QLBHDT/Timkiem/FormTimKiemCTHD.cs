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
    public partial class FormTimKiemCTHD : Form
    {
        public FormTimKiemCTHD()
        {
            InitializeComponent();
        }

        QLBHDTDataContext db = new QLBHDTDataContext();
        private void FormTimKiemCTHD_Load(object sender, EventArgs e)
        {
            cbMaHD.DataSource = from cthd in db.ChiTietHoaDons select cthd.MaHD;
            cbMaHD.SelectedIndex = -1;

            cbMaSP.DataSource = from cthd in db.ChiTietHoaDons select cthd.MaSP;
            cbMaSP.SelectedIndex = -1;
        }
        private void resetTxt()
        {
            cbMaHD.SelectedIndex = -1;
            cbMaSP.SelectedIndex = -1;
            txtSoLuong.ResetText();
            cbMaHD.Enabled = true;
            cbMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaHD())
            {
                string searchText = cbMaHD.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvChiTietHoaDon.DataSource = from ct in db.ChiTietHoaDons
                                               where ct.MaHD == cbMaHD.SelectedItem.ToString()
                                               select new
                                               {
                                                   ct.MaHD,
                                                   ct.MaSP,
                                                   ct.SoLuong
                                               };
                }
                else
                {
                    dgvChiTietHoaDon.DataSource = null;
                }
            }
            //
            if (dkienTimMaSP())
            {
                string searchText = cbMaSP.Text;
             
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dgvChiTietHoaDon.DataSource = from ct in db.ChiTietHoaDons
                                                      where ct.MaSP == cbMaSP.SelectedItem.ToString()
                                                      select new
                                                      {
                                                          ct.MaHD,
                                                          ct.MaSP,
                                                          ct.SoLuong
                                                      };
                    }
                    else
                    {
                        dgvChiTietHoaDon.DataSource = null;
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
                        dgvChiTietHoaDon.DataSource = from ct in db.ChiTietHoaDons
                                                      where ct.SoLuong == decimal.Parse(txtSoLuong.Text.ToString())
                                                      select new
                                                      {
                                                          ct.MaHD,
                                                          ct.MaSP,
                                                          ct.SoLuong
                                                      };
                    }
                    else
                    {
                        dgvChiTietHoaDon.DataSource = null;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }

        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {

            dgvChiTietHoaDon.DataSource = from ct in db.ChiTietHoaDons
                                          select ct;
        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaHD())
            {
                cbMaSP.Enabled = false;
                txtSoLuong.Enabled = false;
            }
            else
            {
                cbMaSP.Enabled = true;
                txtSoLuong.Enabled = true;
            }
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaSP())
            {
                cbMaHD.Enabled = false;
                txtSoLuong.Enabled = false;
            }
            else
            {
                cbMaHD.Enabled = true;
                txtSoLuong.Enabled = true;
            }   
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimSoLuong())
            {
                cbMaHD.Enabled = false;
                cbMaSP.Enabled = false;
            }
            else
            {
                cbMaHD.Enabled = true;
                cbMaSP.Enabled = true;
            }

        }
        private bool dkienTimMaHD()
        {
            string mahd = cbMaHD.Text;
            string masp = cbMaSP.Text;
            string soluong = txtSoLuong.Text;
            return !string.IsNullOrEmpty(mahd) &&
                string.IsNullOrEmpty(masp) && string.IsNullOrEmpty(soluong);
        }
        private bool dkienTimMaSP()
        {
            string mahd = cbMaHD.Text;
            string masp = cbMaSP.Text;
            string soluong = txtSoLuong.Text;
            return string.IsNullOrEmpty(mahd) &&
                !string.IsNullOrEmpty(masp) && string.IsNullOrEmpty(soluong);
        }
        private bool dkienTimSoLuong()
        {
            string mahd = cbMaHD.Text;
            string masp = cbMaSP.Text;
            string soluong = txtSoLuong.Text;
            return string.IsNullOrEmpty(mahd) &&
                string.IsNullOrEmpty(masp) && !string.IsNullOrEmpty(soluong);
        }

       
    }
}
