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
    public partial class FormLoaiHang : Form
    {
        public FormLoaiHang()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();

        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        private void LoadData()
        {
            dgvLoaiHang.DataSource = from table in db.LoaiHangs
                                       select new
                                       {
                                           table.MaLoaiHang,
                                           table.TenLoaiHang
                                       };
        }
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
            checkMaLoaiHang.Checked = true;
            txtMaLoaiHang.Focus();
        }
        private void FormLoaiHang_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }
        private void FormLoaiHang_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //
            if (txtMaLoaiHang.Text.Length > 10)
            {
                MessageBox.Show("Mã loại hàng không được vượt quá 10 ký tự!", "Thông báo");
                return;
            }
            if (dkienrong())
            {
                MessageBox.Show(dkienthieutt(), "Thông báo"); ; 
                return;
            }
            try
            {
                var existingLoaiHang = db.LoaiHangs.FirstOrDefault(kh => kh.MaLoaiHang == txtMaLoaiHang.Text);
                if (existingLoaiHang != null)
                {
                    MessageBox.Show("Mã loại hàng đã tồn tại!", "Thông báo");
                    return;
                }
                LoaiHang tb = new LoaiHang();
                tb.MaLoaiHang = txtMaLoaiHang.Text;
                tb.TenLoaiHang = txtTenLoaiHang.Text;
                db.LoaiHangs.InsertOnSubmit(tb);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công loại hàng: " + txtMaLoaiHang.Text, "Thông báo");
                resetTxt();
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dkienrong())
            {
                MessageBox.Show(dkienthieutt(), "Thông báo");
                return;
            }
            try
            {
                var loaiHang = db.LoaiHangs.FirstOrDefault(lh => lh.MaLoaiHang == txtMaLoaiHang.Text);
                if (loaiHang == null)
                {
                    MessageBox.Show("Không tìm thấy loại hàng có mã: " + txtMaLoaiHang.Text, "Thông báo");
                    return;
                }
                //khoi tao moi doi tuong tb moi
                LoaiHang tb = new LoaiHang();
                tb = (from table in db.LoaiHangs
                      where table.MaLoaiHang == txtMaLoaiHang.Text
                      select table).Single();
                tb.TenLoaiHang = txtTenLoaiHang.Text;
                txtMaLoaiHang.Enabled = true;
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã sửa thành công loại hàng: " + tb.MaLoaiHang, "Thông báo");
                resetTxt();
                checkMaLoaiHang.Checked = true;
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
                checkMaLoaiHang.Checked = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            QLBHDTDataContext db = new QLBHDTDataContext();
            if (string.IsNullOrEmpty(txtMaLoaiHang.Text))
            {
                MessageBox.Show("Vui lòng chọn loại hàng để xóa!", "Thông báo");
                return;
            }

            try
            {
                var loaiHang = db.LoaiHangs.FirstOrDefault(lh => lh.MaLoaiHang == txtMaLoaiHang.Text);
                if (loaiHang == null)
                {
                    MessageBox.Show("Không tìm thấy loại hàng có mã: " + txtMaLoaiHang.Text, "Thông báo");
                    return;
                }

                db.LoaiHangs.DeleteOnSubmit(loaiHang);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã xóa thành công loại hàng: " + loaiHang.MaLoaiHang, "Thông báo");
                resetTxt();
                checkMaLoaiHang.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLoaiHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvLoaiHang.Rows[e.RowIndex];
                txtMaLoaiHang.Text = row.Cells[0].Value.ToString();
                txtTenLoaiHang.Text = row.Cells[1].Value.ToString();
                checkMaLoaiHang.Checked = false;
            }//end try
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 loại hàng!");
            }
        }

       
        //ham reset textbox
        private void resetTxt()
        {
            txtMaLoaiHang.ResetText();
            txtTenLoaiHang.ResetText();
        }
        /*cac ham dieu kien*/
        //lenh cmt ctrl k - ctrl c
        private string dkienthieutt()
        {

            return !string.IsNullOrEmpty(txtMaLoaiHang.Text) &&
              string.IsNullOrEmpty(txtTenLoaiHang.Text)? "Thiếu Tên loại Hàng!" :
              //
              !string.IsNullOrEmpty(txtTenLoaiHang.Text) &&
               string.IsNullOrEmpty(txtMaLoaiHang.Text) ? "Thiếu mã loại hàng!" : "Thiếu thông tin!"; 
        }
        //ham kiem tra cac dieu kien rong
        private bool dkienrong()
        {
            return string.IsNullOrEmpty(txtMaLoaiHang.Text) ||
                string.IsNullOrEmpty(txtTenLoaiHang.Text);
        }
        //ham kiem tra cac dieu kien khac rong
        private bool dkienkhacrong()
        {
            return !string.IsNullOrEmpty(txtMaLoaiHang.Text) &&
            !string.IsNullOrEmpty(txtTenLoaiHang.Text);
        }

        private void checkMaLoaiHang_CheckedChanged(object sender, EventArgs e)
        {

            if (checkMaLoaiHang.Checked)
            {
                txtMaLoaiHang.Enabled = true;
            }
            else
            {
                txtMaLoaiHang.Enabled = false;
            }
        }
    
    }
}
