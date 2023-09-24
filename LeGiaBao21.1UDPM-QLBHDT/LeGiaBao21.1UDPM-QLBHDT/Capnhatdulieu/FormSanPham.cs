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
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }
        //khoi tao mot doi tuong db moi
        QLBHDTDataContext db = new QLBHDTDataContext();

        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        private void LoadData()
        {
            dgvSanPham.DataSource = from table in db.SanPhams
                                    select new
                                      {
                                          table.MaSP,
                                          table.TenSP,
                                          table.MaLoaiHang,
                                          table.MaCongTy,
                                          table.DonViTinh,
                                          table.GiaNhap,
                                          table.GiaBan,
                                        table.SoLuong
                                    };

            // Load data from the LoaiHang table into the MaLoaiHang ComboBox
            var loaiHangData = from lh in db.LoaiHangs
                               select new
                               {
                                   lh.MaLoaiHang,
                                   lh.TenLoaiHang
                               };
            cbMaLoaiHang.DataSource = loaiHangData.ToList();
            cbMaLoaiHang.DisplayMember = "MaLoaiHang";
            cbMaLoaiHang.ValueMember = "MaLoaiHang";

            // Load data from the NhaCungCap table into the MaCongTy ComboBox
            var nhaCungCapData = from ncc in db.NhaCungCaps
                                 select new
                                 {
                                     ncc.MaCongTy,
                                     ncc.TenCongTy
                                 };
            cbMaCongTy.DataSource = nhaCungCapData.ToList();
            cbMaCongTy.DisplayMember = "MaCongTy";
            cbMaCongTy.ValueMember = "MaCongTy";
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }

        private void FormSanPham_Click(object sender, EventArgs e)
        {
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Length > 20)
            {
                MessageBox.Show("Mã sản phẩm không được vượt quá 20 ký tự!", "Thông báo");
                return;
            }
            if (dkienrong())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm!", "Thông báo");
                return;
            }
            if (checknullcbb())
            {
                MessageBox.Show(checkcbb(), "Thông báo");
                return;
            }

            string selectedMaLoaiHang = cbMaLoaiHang.SelectedValue.ToString();
            string selectedMaCongTy = cbMaCongTy.SelectedValue.ToString();

            if (!checkMaLoaiHanghl(selectedMaLoaiHang) || !checkMaCongTyhl(selectedMaCongTy))
            {
                MessageBox.Show("Vui lòng chọn loại hàng hoặc công ty hợp lệ!", "Thông báo");
                return;
            }
            try
            {
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);

                if (sanPham != null)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo");
                    return;
                }
                SanPham newProduct = new SanPham();
                newProduct.MaSP = txtMaSP.Text;
                newProduct.TenSP = txtTenSP.Text;
                newProduct.MaLoaiHang = cbMaLoaiHang.SelectedValue.ToString();
                newProduct.MaCongTy = cbMaCongTy.SelectedValue.ToString();
                newProduct.DonViTinh = txtDonViTinh.Text;
                //newProduct.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                //newProduct.GiaBan = decimal.Parse(txtGiaBan.Text);
                //newProduct.SoLuong = int.Parse(txtSoLuong.Text);
                decimal giaNhap;
                if (decimal.TryParse(txtGiaNhap.Text, out giaNhap))
                {
                    newProduct.GiaNhap = giaNhap;
                }
                else
                {
                    MessageBox.Show("Giá nhập không hợp lệ!", "Thông báo");
                    return;
                }

                decimal giaBan;
                if (decimal.TryParse(txtGiaBan.Text, out giaBan))
                {
                    newProduct.GiaBan = giaBan;
                }
                else
                {
                    MessageBox.Show("Giá bán không hợp lệ!", "Thông báo");
                    return;
                }

                int soLuong;
                if (int.TryParse(txtSoLuong.Text, out soLuong))
                {
                    newProduct.SoLuong = soLuong;
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo");
                    return;
                }
                db.SanPhams.InsertOnSubmit(newProduct);
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Đã thêm thành công sản phẩm: " + txtMaSP.Text, "Thông báo");
                resetTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có trường thông tin rỗng
            if (dkienrong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            try
            {
                // Tìm sản phẩm cần sửa
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);

                // Kiểm tra nếu không tìm thấy sản phẩm
                if (sanPham == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã: " + txtMaSP.Text, "Thông báo");
                    return;
                }

                // Cập nhật thông tin sản phẩm
                sanPham.TenSP = txtTenSP.Text;
                sanPham.MaLoaiHang = cbMaLoaiHang.SelectedValue.ToString();
                sanPham.MaCongTy = cbMaCongTy.SelectedValue.ToString();
                sanPham.DonViTinh = txtDonViTinh.Text;
                //check cac dieu kien kieu number
                if (dkiennumber())
                {
                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();
                    // Tải lại dữ liệu
                    LoadData();
                    MessageBox.Show("Đã sửa thành công sản phẩm: " + sanPham.MaSP, "Thông báo");
                    resetTxt();
                    checkMaSP.Checked = true;
                }
                else
                {
                    return;
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
                checkMaSP.Checked = true;
            }
        }
        private void resetTxt()
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDonViTinh.ResetText();
            txtGiaNhap.ResetText();
            txtGiaBan.ResetText();
            txtSoLuong.ResetText();
            // Set the SelectedIndex to -1 to clear the selected value
            cbMaLoaiHang.SelectedIndex = -1;
            cbMaCongTy.SelectedIndex = -1;

        }
        /*cac ham dieu kien*/
        //lenh cmt ctrl k - ctrl c

        //ham kiem tra cac dieu kien rong
        private bool dkienrong()
        {
            return string.IsNullOrEmpty(txtMaSP.Text) ||
            string.IsNullOrEmpty(txtTenSP.Text) ||
            string.IsNullOrEmpty(txtDonViTinh.Text) ||
            string.IsNullOrEmpty(txtGiaNhap.Text) ||
            string.IsNullOrEmpty(txtGiaBan.Text) ||
            string.IsNullOrEmpty(txtSoLuong.Text);
        }
     

        private void cbMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMaCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
            checkMaSP.Checked = true;
            txtMaSP.Focus();
        }

        private void checMaSP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMaSP.Checked)
            {
                txtMaSP.Enabled = true;
            }
            else
            {
                txtMaSP.Enabled = false;
            }
        }

    

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //
        private bool checkMaLoaiHanghl(string maLoaiHang)
        {
            var existingMaLoaiHang = db.LoaiHangs.FirstOrDefault(lh => lh.MaLoaiHang == maLoaiHang);
            return existingMaLoaiHang != null;
        }

        private bool checkMaCongTyhl(string maCongTy)
        {
            var existingMaCongTy = db.NhaCungCaps.FirstOrDefault(ct => ct.MaCongTy == maCongTy);
            return existingMaCongTy != null;
        }
        //kiem tra comboBox null
        private bool checknullcbb()
        {
            return string.IsNullOrEmpty(cbMaLoaiHang.Text) || string.IsNullOrEmpty(cbMaCongTy.Text);
        }
        //hien thi thong bao
        private string checkcbb()
        {
            return string.IsNullOrEmpty(cbMaLoaiHang.Text) && string.IsNullOrEmpty(cbMaCongTy.Text) ? "Vui lòng chọn mã loại hàng và mã công ty!":
                !string.IsNullOrEmpty(cbMaLoaiHang.Text) && string.IsNullOrEmpty(cbMaCongTy.Text)? " Vui lòng chọn mã công ty!" : " Vui lòng chọn mã loại hàng!";
        }
       

        private void dgvSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells[0].Value.ToString();
                txtTenSP.Text = row.Cells[1].Value.ToString();
                cbMaLoaiHang.Text = row.Cells[2].Value.ToString();
                cbMaCongTy.Text = row.Cells[3].Value.ToString();
                txtDonViTinh.Text = row.Cells[4].Value.ToString();
                txtGiaNhap.Text = row.Cells[5].Value.ToString();
                txtGiaBan.Text = row.Cells[6].Value.ToString();
                txtSoLuong.Text = row.Cells[7].Value.ToString();
                checkMaSP.Checked = false;
            }//end try
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 sản phẩm!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbMaCongTy.Text))
            {
                MessageBox.Show("hehehe");
            }
        }
        //kiem tra dieu kien cac gia tien va so luong khong hop le
        private bool dkiennumber()
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);
            decimal giaNhap;
            if (decimal.TryParse(txtGiaNhap.Text, out giaNhap))
            {
                sanPham.GiaNhap = giaNhap;
            }
            else
            {
                MessageBox.Show("Giá nhập không hợp lệ!", "Thông báo");
                return false; 
            }

            decimal giaBan;
            if (decimal.TryParse(txtGiaBan.Text, out giaBan))
            {
                sanPham.GiaBan = giaBan;
            }
            else
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Thông báo");
                return false; 
            }

            int soLuong;
            if (int.TryParse(txtSoLuong.Text, out soLuong))
            {
                sanPham.SoLuong = soLuong;
            }
            else
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo");
                return false; 
            }

            return true; // Trả về giá trị true khi không có lỗi
        }
    }
}
