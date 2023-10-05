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
    public partial class FormTimKiemNV : Form
    {
        public FormTimKiemNV()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();

        private void FormTimKiemNV_Load(object sender, EventArgs e)
        {

            cbMaNV.DataSource = from nv in db.NhanViens select nv.MaNV;
            cbMaNV.SelectedIndex = -1;
        }
        private void resetTxt()
        {
            cbMaNV.SelectedIndex = -1;
            txtHoLot.ResetText();
            txtTen.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            cbMaNV.Enabled = true;
            txtTen.Enabled = true;
            txtHoLot.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
        }
     
        private void BtnTim_Click(object sender, EventArgs e)
        {
            if (dkienTimMaNV())
            {
               
                dgvNhanVien.DataSource = from nv in db.NhanViens
                                         where nv.MaNV == cbMaNV.SelectedItem.ToString()
                                         select new
                                         {
                                             nv.MaNV,
                                             nv.HoLot,
                                             nv.Ten,
                                             nv.NgaySinh,
                                             nv.DiaChi,
                                             nv.DienThoai
                                         };
            }
            if (dkienTimDC())
            {
                dgvNhanVien.DataSource = from nv in db.NhanViens
                                         where nv.DiaChi == txtDiaChi.Text
                                         select new
                                         {
                                             nv.MaNV,
                                             nv.HoLot,
                                             nv.Ten,
                                             nv.NgaySinh,
                                             nv.DiaChi,
                                             nv.DienThoai
                                         };
            }
            
        }
        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dkienTimMaNV())
            {
                txtTen.Enabled = false;
                txtHoLot.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
            }
            else
            {
                txtTen.Enabled =true;
                txtHoLot.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
            }
        }

        private void TxtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimDC())
            {
                cbMaNV.Enabled = false;
                txtTen.Enabled = false;
                txtHoLot.Enabled = false;
                txtDienThoai.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                txtTen.Enabled = true;
                txtHoLot.Enabled = true;
                txtDienThoai.Enabled = true;
            }
        }
        private bool dkienTimMaNV()
        {
            string manv = cbMaNV.Text;
            string ho = txtHoLot.Text;
            string ten = txtTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;

            return !string.IsNullOrEmpty(manv) &&
                string.IsNullOrEmpty(ho) && string.IsNullOrEmpty(ten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt);
        }
        private bool dkienTimDC()
        {
            string manv = cbMaNV.Text;
            string ho = txtHoLot.Text;
            string ten = txtTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;

            return string.IsNullOrEmpty(manv) &&
                string.IsNullOrEmpty(ho) && string.IsNullOrEmpty(ten) && !string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt);
        }
    }
}
