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
            txtHoTen.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            dtpNgaySinh.ResetText();
            dtpNgayVaoLam.ResetText();
            cbMaNV.Enabled = true;
            txtHoTen.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtLuongCB.Enabled = true;
            dtpNgayVaoLam.Enabled = true;
            checkNgaySinh.Checked = false;
            checkNgayVaoLam.Checked = false;

        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            //tim ma nv
            if (dkienTimMaNV())
            {
                string searchText = cbMaNV.Text;

                if (!string.IsNullOrEmpty(searchText))
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
                                                 nv.DienThoai,
                                                 nv.LuongCoBan,
                                                 nv.NgayVaoLam
                                             };
                }
                else
                {
                    dgvNhanVien.DataSource = null;
                }
            }
            //tim dia chi
            if (dkienTimDC())
            {
                string searchText = txtDiaChi.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keys = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var nhanvien = from nv in db.NhanViens
                                    select nv;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var key in keys)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        nhanvien = nhanvien.Where(kh => (kh.DiaChi).Contains(key));
                    }

                    dgvNhanVien.DataSource = nhanvien.Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoLot,
                        nv.Ten,
                        nv.NgaySinh,
                        nv.DiaChi,
                        nv.DienThoai,
                        nv.LuongCoBan,
                        nv.NgayVaoLam
                    }).ToList();
                }
                else
                {
                    dgvNhanVien.DataSource = null;
                }

            }
            //tim ho ten
            if (dkienTimHoTen())
            {

                string searchText = txtHoTen.Text.Trim(); //xoa khoang trang

                if (!string.IsNullOrEmpty(searchText))
                {
                    string[] keywords = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var tknv = from nv in db.NhanViens
                               select nv;

                    // kiem tra tung tu khoa tim kiem
                    foreach (var keyword in keywords)
                    {
                        //dkien tim kiem
                        // su dung contains kiem tra xem chuoi co chua tu khoa nao giong khong
                        tknv = tknv.Where(nv => (nv.HoLot + " " + nv.Ten).Contains(keyword));
                    }


                    dgvNhanVien.DataSource = tknv.Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoLot,
                        nv.Ten,
                        nv.NgaySinh,
                        nv.DiaChi,
                        nv.DienThoai,
                        nv.LuongCoBan,
                        nv.NgayVaoLam
                    }).ToList();
                }
                else
                {
                    dgvNhanVien.DataSource = null;
                }

            }
            //tim sdt
            if (dkienTimSDT())
            {
                string searchText = txtDienThoai.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvNhanVien.DataSource = from nv in db.NhanViens
                                             where nv.DienThoai == txtDienThoai.Text
                                             select new
                                             {
                                                 nv.MaNV,
                                                 nv.HoLot,
                                                 nv.Ten,
                                                 nv.NgaySinh,
                                                 nv.DiaChi,
                                                 nv.DienThoai,
                                                 nv.LuongCoBan,
                                                 nv.NgayVaoLam
                                             };
                }
                else
                {
                    dgvNhanVien.DataSource = null;
                }

            }

            //tim ngay sinh
            if (checkNgaySinh.Checked == true)
            {


                dgvNhanVien.DataSource = from nv in db.NhanViens
                                         where nv.NgaySinh == DateTime.Parse(dtpNgaySinh.Text.ToString())
                                         select new
                                         {
                                             nv.MaNV,
                                             nv.HoLot,
                                             nv.Ten,
                                             nv.NgaySinh,
                                             nv.DiaChi,
                                             nv.DienThoai,
                                             nv.LuongCoBan,
                                             nv.NgayVaoLam
                                         };
               
            }

            //
            if (dkienTimLuongCB())
            {
                
                string searchText = txtLuongCB.Text;

                if (!string.IsNullOrEmpty(searchText))
                {
                    dgvNhanVien.DataSource = from nv in db.NhanViens
                                             where nv.LuongCoBan == decimal.Parse(txtLuongCB.Text.ToString())
                                             select new
                                             {
                                                 nv.MaNV,
                                                 nv.HoLot,
                                                 nv.Ten,
                                                 nv.NgaySinh,
                                                 nv.DiaChi,
                                                 nv.DienThoai,
                                                 nv.LuongCoBan,
                                                 nv.NgayVaoLam
                                             };

                }
                else
                {
                    dgvNhanVien.DataSource = null;
                }
            }
            //
            if (checkNgayVaoLam.Checked == true)
            {


                dgvNhanVien.DataSource = from nv in db.NhanViens
                                         where nv.NgayVaoLam == DateTime.Parse(dtpNgayVaoLam.Text.ToString())
                                         select new
                                         {
                                             nv.MaNV,
                                             nv.HoLot,
                                             nv.Ten,
                                             nv.NgaySinh,
                                             nv.DiaChi,
                                             nv.DienThoai,
                                             nv.LuongCoBan,
                                             nv.NgayVaoLam
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
                txtHoTen.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtLuongCB.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
            }
            else
            {
                txtHoTen.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                dtpNgaySinh.Enabled = true;
                txtLuongCB.Enabled = true;
                dtpNgayVaoLam.Enabled = true;
            }
        }

        private void TxtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimDC())
            {
                cbMaNV.Enabled = false;
                txtHoTen.Enabled = false;
                txtDienThoai.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtLuongCB.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                txtHoTen.Enabled = true;
                txtDienThoai.Enabled = true;
                dtpNgaySinh.Enabled = true;
                txtLuongCB.Enabled = true;
                dtpNgayVaoLam.Enabled = true;
            }
        }
        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimHoTen())
            {
                cbMaNV.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtLuongCB.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                txtDienThoai.Enabled = true;
                txtDiaChi.Enabled = true;
                dtpNgaySinh.Enabled = true;
                txtLuongCB.Enabled = true;
                dtpNgayVaoLam.Enabled = true;
            }
        }
        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

            if (dkienTimSDT())
            {
                cbMaNV.Enabled = false;
                txtHoTen.Enabled = false;
                txtDiaChi.Enabled = false;
                dtpNgaySinh.Enabled = false;
                txtLuongCB.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                txtHoTen.Enabled = true;
                txtDiaChi.Enabled = true;
                dtpNgaySinh.Enabled = true;
                txtLuongCB.Enabled = true;
                dtpNgayVaoLam.Enabled = true;
            }
        }
        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        } 
private bool dkienTimMaNV()
        {
            string manv = cbMaNV.Text;
            string hoten = txtHoTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string luongcoban = txtLuongCB.Text;
            return !string.IsNullOrEmpty(manv) &&
                string.IsNullOrEmpty(hoten)  && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(luongcoban) ;
        }
        private bool dkienTimDC()
        {
            string manv = cbMaNV.Text;
            string hoten = txtHoTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string luongcoban = txtLuongCB.Text;
            return string.IsNullOrEmpty(manv) &&
                string.IsNullOrEmpty(hoten)  && !string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(luongcoban) ;
        }
        private bool dkienTimHoTen()
        {
            string manv = cbMaNV.Text;
            string hoten = txtHoTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string luongcoban = txtLuongCB.Text;
            return string.IsNullOrEmpty(manv) &&
                !string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(luongcoban);
        }
        private bool dkienTimSDT()
        {
            string manv = cbMaNV.Text;
            string hoten = txtHoTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string luongcoban = txtLuongCB.Text;

            return string.IsNullOrEmpty(manv) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && !string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(luongcoban);
        }
  
        private bool dkienTimLuongCB()
        {
            string manv = cbMaNV.Text;
            string hoten = txtHoTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtDienThoai.Text;
            string luongcoban = txtLuongCB.Text;

            return string.IsNullOrEmpty(manv) &&
                string.IsNullOrEmpty(hoten) && string.IsNullOrEmpty(diachi) && string.IsNullOrEmpty(sdt) && !string.IsNullOrEmpty(luongcoban);
        }
      

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = from nv in db.NhanViens
                                     select nv;
        }

        private void txtLuongCB_TextChanged(object sender, EventArgs e)
        {
            if (dkienTimLuongCB())
            {
                txtHoTen.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                dtpNgaySinh.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
            }
            else
            {
                txtHoTen.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                dtpNgaySinh.Enabled = true;
                dtpNgayVaoLam.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void checkNgaySinh_CheckedChanged(object sender, EventArgs e)
        {
            if(checkNgaySinh.Checked == true)
            {
                checkNgayVaoLam.Checked = false;
                cbMaNV.Enabled = false;
                txtHoTen.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtLuongCB.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                txtHoTen.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtLuongCB.Enabled = true;
                dtpNgayVaoLam.Enabled = true;
            }

        }

        private void checkNgayVaoLam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNgayVaoLam.Checked == true)
            {
                checkNgaySinh.Checked = false;
                cbMaNV.Enabled = false;
                txtHoTen.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtLuongCB.Enabled = false;
                dtpNgaySinh.Enabled = false;
            }
            else
            {
                cbMaNV.Enabled = true;
                txtHoTen.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtLuongCB.Enabled = true;
                dtpNgaySinh.Enabled = true;
            }

        }
    }
}

