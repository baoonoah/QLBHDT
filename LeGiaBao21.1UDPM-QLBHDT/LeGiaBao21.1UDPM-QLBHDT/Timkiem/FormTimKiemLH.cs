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
    public partial class FormTimKiemLH : Form
    {
        public FormTimKiemLH()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();

        private void FormTimKiemLH_Load(object sender, EventArgs e)
        {
            cbMaLoaiHang.DataSource = from lh in db.LoaiHangs select lh.MaLoaiHang;
            cbMaLoaiHang.SelectedIndex = -1;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaLH())
            {
                string searchText = cbMaLoaiHang.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvLoaiHang.DataSource = from nv in db.LoaiHangs
                                             where nv.MaLoaiHang == cbMaLoaiHang.SelectedValue.ToString()
                                             select new
                                             {
                                                 nv.MaLoaiHang,
                                                 nv.TenLoaiHang
                                             };
                }
                else
                {
                    dgvLoaiHang.DataSource = null;
                }

            }

            //
            if (dkienTimTenLH())
            {
                string searchText = txtTenLoaiHang.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var loaihang = from ct in db.LoaiHangs
                               select ct;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        loaihang = loaihang.Where(lh => (lh.TenLoaiHang).Contains(key));
                    }

                    dgvLoaiHang.DataSource = loaihang.Select(lh => new
                    {
                        lh.MaLoaiHang,
                        lh.TenLoaiHang

                    }).ToList();
                }
                else
                {
                    dgvLoaiHang.DataSource = null;
                }

            }
        }
        private void resetTxt()
        {
            cbMaLoaiHang.SelectedIndex = -1;
            txtTenLoaiHang.ResetText();
            cbMaLoaiHang.Enabled = true;
            txtTenLoaiHang.Enabled = true;
        

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
            dgvLoaiHang.DataSource = from lh in db.LoaiHangs
                                     select lh;
        }

        private void cbMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaLH())
            {
                txtTenLoaiHang.Enabled = false;
            }
            else
            {
                txtTenLoaiHang.Enabled = true;
            }
        }

        private void txtTenLoaiHang_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimTenLH())
            {
                cbMaLoaiHang.Enabled = false;
            }
            else
            {
                cbMaLoaiHang.Enabled = true;
            }
        }
      private bool dkienTimMaLH()
        {
            return !string.IsNullOrEmpty(cbMaLoaiHang.Text) && string.IsNullOrEmpty(txtTenLoaiHang.Text);
        }
        private bool dkienTimTenLH()
        {
            return string.IsNullOrEmpty(cbMaLoaiHang.Text) && !string.IsNullOrEmpty(txtTenLoaiHang.Text);
        }

    }
}
