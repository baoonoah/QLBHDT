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
            LoadData();
            resetTxt();
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
            string.IsNullOrEmpty(cbMaLoaiHang.Text) ||
            string.IsNullOrEmpty(cbMaCongTy.Text) ||
            string.IsNullOrEmpty(txtDonViTinh.Text) ||
            string.IsNullOrEmpty(txtGiaNhap.Text) ||
            string.IsNullOrEmpty(txtGiaBan.Text) ||
            string.IsNullOrEmpty(txtSoLuong.Text);
        }
        //ham kiem tra cac dieu kien khac rong
        private bool dkienkhacrong()
        {
            return !string.IsNullOrEmpty(txtMaSP.Text) &&
            !string.IsNullOrEmpty(txtTenSP.Text) &&
            !string.IsNullOrEmpty(cbMaLoaiHang.Text) &&
            !string.IsNullOrEmpty(cbMaCongTy.Text) &&
            !string.IsNullOrEmpty(txtDonViTinh.Text) &&
            !string.IsNullOrEmpty(txtGiaNhap.Text) &&
            !string.IsNullOrEmpty(txtGiaBan.Text) &&
            !string.IsNullOrEmpty(txtSoLuong.Text);
            
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Length > 20)
            {
                MessageBox.Show("Mã sản phẩm không được vượt quá 20 ký tự!", "Thông báo");
                return;
            }
            if (checknullcbb())
            {
                MessageBox.Show(checkcbb(), "Thông báo");
                return;
            }

            string selectedMaLoaiHang = cbMaLoaiHang.SelectedValue.ToString();
            string selectedMaCongTy = cbMaCongTy.SelectedValue.ToString();

            if (!IsMaLoaiHangValid(selectedMaLoaiHang) || !IsMaCongTyValid(selectedMaCongTy) )
            {
                MessageBox.Show("Vui lòng chọn loại hàng hoặc công ty hợp lệ!", "Thông báo");
                return;
            }
            try
            {
                var existingProduct = db.SanPhams.FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);
                if (existingProduct != null)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo");
                    return;
                }

                SanPham newProduct = new SanPham();
                newProduct.MaSP = txtMaSP.Text;
                newProduct.TenSP = txtTenSP.Text;
                newProduct.MaLoaiHang = cbMaLoaiHang.SelectedValue.ToString();
                //newProduct.MaLoaiHang = cbMaLoaiHang.Text;
                newProduct.MaCongTy = cbMaCongTy.SelectedValue.ToString();
                //newProduct.MaCongTy = cbMaCongTy.Text;
                newProduct.DonViTinh = txtDonViTinh.Text;
                newProduct.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                newProduct.GiaBan = decimal.Parse(txtGiaBan.Text);
                newProduct.SoLuong = int.Parse(txtSoLuong.Text);
                db.SanPhams.InsertOnSubmit(newProduct);
                db.SubmitChanges();
                LoadData();
                resetTxt();
                MessageBox.Show("Đã thêm thành công sản phẩm: " + txtMaSP.Text, "Thông báo");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //
        private bool IsMaLoaiHangValid(string maLoaiHang)
        {
            var existingMaLoaiHang = db.LoaiHangs.FirstOrDefault(lh => lh.MaLoaiHang == maLoaiHang);
            return existingMaLoaiHang != null;
        }

        private bool IsMaCongTyValid(string maCongTy)
        {
            var existingMaCongTy = db.NhaCungCaps.FirstOrDefault(ct => ct.MaCongTy == maCongTy);
            return existingMaCongTy != null;
        }

        private string checkcbb()
        {
            return string.IsNullOrEmpty(cbMaLoaiHang.Text) && string.IsNullOrEmpty(cbMaCongTy.Text) ? "Vui lòng chọn mã loại hàng và mã công ty!":
                !string.IsNullOrEmpty(cbMaLoaiHang.Text) && string.IsNullOrEmpty(cbMaCongTy.Text)? " Vui lòng chọn mã công ty!" : " Vui lòng chọn mã loại hàng!";
        }

        private bool checknullcbb()
        {
            return string.IsNullOrEmpty(cbMaLoaiHang.Text) || string.IsNullOrEmpty(cbMaCongTy.Text);
        }
    }
}
