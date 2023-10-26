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
    public partial class FormKhachHang : Form
    {

        public FormKhachHang()
        {
            InitializeComponent();
        }
        //khoi tao mot doi tuong db moi
        QLBHDTDataContext db = new QLBHDTDataContext();

        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        private void LoadData()
        {
            dgvKhachHang.DataSource = from table in db.KhachHangs
                                      select new
                                      {
                                          table.MaKH,
                                          table.TenKH,
                                          table.DiaChi,
                                          table.DienThoai,
                                          table.Email
                                      };

        }
        private void resetTxt()
        {
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            txtEmail.ResetText();
            txtMaKH.Focus();

        }
        private void FormKhachHang_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            //
            if (txtMaKH.Text.Length > 10)
            {
                MessageBox.Show("Mã khách hàng không được vượt quá 10 ký tự!", "Thông báo");
                return;
            }
            if (dkienrong())
            {
                MessageBox.Show(dkienthieutt(), "Thông báo"); ;
                return;
            }

            try
            {
                var existingKhachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKH == txtMaKH.Text);
                if (existingKhachHang != null)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!", "Thông báo");
                    return;
                }
                KhachHang tb = new KhachHang();
                tb.MaKH = txtMaKH.Text;
                tb.TenKH = txtTenKH.Text;
                tb.DiaChi = txtDiaChi.Text;
                long dienThoai;

                if (long.TryParse(txtDienThoai.Text, out dienThoai) && txtDienThoai.Text.Length == 10)
                {
                    tb.DienThoai = dienThoai.ToString();
                }
                else
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo");
                    return;
                }
                tb.Email = txtEmail.Text;
                db.KhachHangs.InsertOnSubmit(tb);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công khách hàng: " + txtMaKH.Text, "Thông báo");
                resetTxt();
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
               
            }
        }//end function them
        private void BtnSua_Click(object sender, EventArgs e)
        {

            if (dkienrong())
            {
                MessageBox.Show(dkienthieutt(), "Thông báo");
                return;
            }
            try
            {
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKH == txtMaKH.Text);
                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã: " + txtMaKH.Text, "Thông báo");
                    return;
                }
                //khoi tao moi doi tuong tb moi
                KhachHang tb = new KhachHang();
                tb = (from table in db.KhachHangs
                      where table.MaKH == txtMaKH.Text
                      select table).Single();
                tb.TenKH = txtTenKH.Text;
                tb.DiaChi = txtDiaChi.Text;
                long dienThoai;
                if (long.TryParse(txtDienThoai.Text, out dienThoai) && txtDienThoai.Text.Length == 10)
                {
                    tb.DienThoai = dienThoai.ToString();
                }
                else
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo");
                    return;
                }
                tb.Email = txtEmail.Text;
                txtMaKH.Enabled = true;
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã sửa thành công khách hàng: " + tb.MaKH, "Thông báo");
                resetTxt();
                checkMaKH.Checked = true;
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
                checkMaKH.Checked = true;
            }
        }//end function sua
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            QLBHDTDataContext db = new QLBHDTDataContext();
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo");
                return;
            }

            try
            {
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKH == txtMaKH.Text);
                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã: " + txtMaKH.Text, "Thông báo");
                    return;
                }
                db.KhachHangs.DeleteOnSubmit(khachHang);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã xóa thành công khách hàng: " + khachHang.MaKH, "Thông báo");
                resetTxt();
                checkMaKH.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo");
            }
        }//end function xoa

        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
            checkMaKH.Checked = true;
            txtMaKH.Focus();
        }//end nhap moi
        private void DgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtDienThoai.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
                checkMaKH.Checked = false;
            }//end try
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 khách hàng!");
            }

        }//end function

        //checkedbox de nhap makh thu cong
        private void checkMaKH_CheckedChanged(object sender, EventArgs e)
        {

            if (checkMaKH.Checked)
            {
                txtMaKH.Enabled = true;
            }
            else
            {
                txtMaKH.Enabled = false;
            }
        }
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ham reset textbox
     
        /*cac ham dieu kien*/
        //lenh cmt ctrl k - ctrl c
        private string dkienthieutt()
        {

            return !string.IsNullOrEmpty(txtMaKH.Text) &&
              !string.IsNullOrEmpty(txtTenKH.Text) &&
              !string.IsNullOrEmpty(txtDiaChi.Text) &&
               string.IsNullOrEmpty(txtDienThoai.Text) ? "Thiếu điện thoại!" :
              //
              !string.IsNullOrEmpty(txtMaKH.Text) &&
              !string.IsNullOrEmpty(txtTenKH.Text) &&
              !string.IsNullOrEmpty(txtDienThoai.Text) &&
               string.IsNullOrEmpty(txtDiaChi.Text) ? "Thiếu địa chỉ!" :
              //
              !string.IsNullOrEmpty(txtMaKH.Text) &&
              !string.IsNullOrEmpty(txtDiaChi.Text) &&
              !string.IsNullOrEmpty(txtDienThoai.Text) &&
               string.IsNullOrEmpty(txtTenKH.Text) ? "Thiếu tên khách hàng!" :
              //
              !string.IsNullOrEmpty(txtTenKH.Text) &&
              !string.IsNullOrEmpty(txtDiaChi.Text) &&
              !string.IsNullOrEmpty(txtDienThoai.Text) &&
               string.IsNullOrEmpty(txtMaKH.Text) ? "Thiếu mã khách hàng!" : "Nhập thiếu thông tin!"; ;
        }
        //ham kiem tra cac dieu kien rong
        private bool dkienrong()
        {
            return string.IsNullOrEmpty(txtMaKH.Text) ||
                string.IsNullOrEmpty(txtTenKH.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text);
        }
    }

}