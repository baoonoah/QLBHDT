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
            //khoi tao moi doi tuong tb moi
            NhanVien tb = new NhanVien();
            tb.MaNV = txtMaNV.Text;
            tb.HoLot = txtHoLot.Text;
            tb.Ten = txtTen.Text;
            tb.DiaChi = txtDiaChi.Text;
            tb.NgaySinh = DateTime.Parse(dtpNgaySinh.Text.ToString());
            tb.DienThoai = txtTen.Text;
            db.NhanViens.InsertOnSubmit(tb);
            db.SubmitChanges();
            LoadData();
            MessageBox.Show("Đã thêm xong!", "Thông báo");
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
            MessageBox.Show("Đã xóa xong!", "Thông báo");
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
    }
}
