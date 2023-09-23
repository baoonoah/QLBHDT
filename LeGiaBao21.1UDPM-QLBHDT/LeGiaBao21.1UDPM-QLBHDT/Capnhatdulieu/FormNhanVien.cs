using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Capnhatdulieu
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        //khoi tao mot doi tuong db moi
        QLBHDTDataContext db = new QLBHDTDataContext();
        private void LoadData()
        {
            dgvNhanVien.DataSource = from table in db.NhanViens
                                     select new
                                     {
                                         table.MaNV,
                                         table.HoLot,
                                         table.Ten,
                                         table.NgaySinh,
                                         table.DiaChi,
                                         table.DienThoai
                                     };
            txtMaNV.Text = " ";
            txtHoLot.Text = " ";
            txtTen.Text = " ";
            dtpNgaySinh.ResetText();
            txtDiaChi.Text = " ";
            txtDienThoai.Text = " ";
            txtMaNV.Focus();

        }

        
        private void DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormNhanVien_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {
        
            txtMaNV.Text = " ";
            txtHoLot.Text = " ";
            txtTen.Text = " ";
            dtpNgaySinh.ResetText();
            txtDiaChi.Text = " ";
            txtDienThoai.Text = " ";
            txtMaNV.Focus();

        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            //dieu kien 
            var dkienrong = string.IsNullOrEmpty(txtMaNV.Text) ||
                string.IsNullOrEmpty(txtHoLot.Text) ||
                string.IsNullOrEmpty(txtTen.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(dtpNgaySinh.Text.ToString()) ||
                string.IsNullOrEmpty(txtDienThoai.Text);
            if (dkienrong)
            {
                MessageBox.Show("Nhập thiếu thông tin!", "Thông báo");
                return;
            }
            try
            {
                var existingNhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == txtMaNV.Text);
                if (existingNhanVien != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo");
                    return;
                }
                //khoi tao moi doi tuong tb moi    

                NhanVien tb = new NhanVien();
                tb.MaNV = txtMaNV.Text;
                tb.HoLot = txtHoLot.Text;
                tb.Ten = txtTen.Text;
                tb.DiaChi = txtDiaChi.Text;
                tb.NgaySinh = DateTime.Parse(dtpNgaySinh.Text.ToString());
                tb.DienThoai = txtDienThoai.Text;
                db.NhanViens.InsertOnSubmit(tb);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công! ", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            //khoi tao moi doi tuong tb moi
            NhanVien tb = new NhanVien();
            tb = (from table in db.NhanViens
                  where table.MaNV == txtMaNV.Text
                  select table).Single();
            tb.HoLot = txtHoLot.Text;
            tb.Ten = txtTen.Text;
            tb.DiaChi = txtDiaChi.Text;
            tb.NgaySinh = DateTime.Parse(dtpNgaySinh.Text.ToString());
            tb.DienThoai = txtDienThoai.Text;
            db.SubmitChanges();
            LoadData();
            MessageBox.Show("Đã sửa xong!", "Thông báo");

        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            //khoi tao moi doi tuong tb moi
            NhanVien tb = new NhanVien();
            tb = (from table in db.NhanViens
                  where table.MaNV == txtMaNV.Text
                  select table).Single();
            db.NhanViens.DeleteOnSubmit(tb);//xoa du lieu cua tb
            db.SubmitChanges();//xac nhan thay doi du lieu
            LoadData();//load du lieu moi
            MessageBox.Show("Đã Xóa!", "Thông báo");
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoLot.Text = row.Cells[1].Value.ToString();
                txtTen.Text = row.Cells[2].Value.ToString();
                dtpNgaySinh.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtDienThoai.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 nhân viên!");
            }
        }
    }
}
