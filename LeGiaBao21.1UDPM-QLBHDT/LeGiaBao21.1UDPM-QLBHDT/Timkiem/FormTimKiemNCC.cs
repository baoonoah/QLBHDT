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
    public partial class FormTimKiemNCC : Form
    {
        public FormTimKiemNCC()
        {
            InitializeComponent();
        }

    QLBHDTDataContext db = new QLBHDTDataContext();

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaCTY())
            {
                string searchText = cbMaCongTy.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvNhaCungCap.DataSource = from ct in db.NhaCungCaps
                                               where ct.MaCongTy == cbMaCongTy.SelectedItem.ToString()
                                              select new
                                              {
                                                  ct.MaCongTy,
                                                  ct.TenCongTy,
                                                  ct.DiaChi,
                                                  ct.DienThoai,
                                              };
                }
                else
                {
                    dgvNhaCungCap.DataSource = null;
                }
            }
            //
            if (dkienTimTenCTY())
            {
                string searchText = txtTenCongTy.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var nhacungcap = from ncc in db.NhaCungCaps
                                   select ncc;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        nhacungcap = nhacungcap.Where(ncc => (ncc.TenCongTy).Contains(key));
                    }

                    dgvNhaCungCap.DataSource = nhacungcap.Select(ncc => new
                    {
                        ncc.MaCongTy,
                        ncc.TenCongTy,
                        ncc.DiaChi,
                        ncc.DienThoai,
                    }).ToList();
                }
                else
                {
                    dgvNhaCungCap.DataSource = null;
                }
            }
            //
            
          if (dkienTimDC())
            {

                string searchText = txtDiaChi.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var tkct = from ct in db.NhaCungCaps
                               select ct;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        tkct = tkct.Where(ct => (ct.DiaChi).Contains(key));
                    }

                    dgvNhaCungCap.DataSource = tkct.Select(ct => new
                    {
                        ct.MaCongTy,
                        ct.TenCongTy,
                        ct.DiaChi,
                        ct.DienThoai,
                        
                    }).ToList();
                }
                else
                {
                    dgvNhaCungCap.DataSource = null;
                }
            }
            //
            if (dkienTimSDT())
            {
                string searchText = txtDienThoai.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvNhaCungCap.DataSource = from ct in db.NhaCungCaps
                                              where ct.DienThoai == txtDienThoai.Text.ToString()
                                              select new
                                              {
                                                  ct.MaCongTy,
                                                  ct.TenCongTy,
                                                  ct.DiaChi,
                                                  ct.DienThoai,
                                                  
                                              };
                }
                else
                {
                    dgvNhaCungCap.DataSource = null;
                }
            }
         
        }
        private void resetTxt()
        {
            cbMaCongTy.SelectedIndex = -1;
            txtTenCongTy.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
        
            cbMaCongTy.Enabled = true;
            txtTenCongTy.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
           

        }
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvNhaCungCap.DataSource = from kh in db.NhaCungCaps
                                       select kh;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbMaCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaCTY())
            {
                txtTenCongTy.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
            }
            else
            {
                txtTenCongTy.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
            }
        }
        private void txtTenCongTy_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimTenCTY())
            {
                cbMaCongTy.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
            }
            else
            {
                cbMaCongTy.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
            }
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimSDT())
            {
                cbMaCongTy.Enabled = false;
                txtTenCongTy.Enabled = false;
                txtDiaChi.Enabled = false;
            }
            else
            {
                cbMaCongTy.Enabled = true;
                txtTenCongTy.Enabled = true;
                txtDiaChi.Enabled = true;
            }

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimDC())
            {
                cbMaCongTy.Enabled = false;
                txtTenCongTy.Enabled = false;
                txtDienThoai.Enabled = false;
            }
            else
            {
                cbMaCongTy.Enabled = true;
                txtTenCongTy.Enabled = true;
                txtDienThoai.Enabled = true;
            }
        }

        private void FormTimKiemNCC_Load(object sender, EventArgs e)
        {
            cbMaCongTy.DataSource = from ct in db.NhaCungCaps select ct.MaCongTy;
            cbMaCongTy.SelectedIndex = -1;
        }
        private bool dkienTimMaCTY()
        {
            string macty = cbMaCongTy.Text;
            string hoten = txtTenCongTy.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            return !string.IsNullOrEmpty(macty) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt);
        }
        private bool dkienTimTenCTY()
        {
            string macty = cbMaCongTy.Text;
            string hoten = txtTenCongTy.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
          
            return string.IsNullOrEmpty(macty) &&
                !string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt);
        }
        private bool dkienTimDC()
        {
            string macty = cbMaCongTy.Text;
            string hoten = txtTenCongTy.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
          
            return string.IsNullOrEmpty(macty) &&
                string.IsNullOrEmpty(hoten) && !string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt);
        }
        private bool dkienTimSDT()
        {
            string macty = cbMaCongTy.Text;
            string hoten = txtTenCongTy.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
          
            return string.IsNullOrEmpty(macty) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && !string.IsNullOrEmpty(sdt);
        }
    }
}
