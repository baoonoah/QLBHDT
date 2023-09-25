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
    public partial class FormNhaCungCap : Form
    {
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        //khoi tao mot doi tuong db moi
        QLBHDTDataContext db = new QLBHDTDataContext();

        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        private void LoadData()
        {
            dgvNhaCungCap.DataSource = from table in db.NhaCungCaps
                                      select new
                                      {
                                          table.MaCongTy,
                                          table.TenCongTy,
                                          table.DiaChi,
                                          table.DienThoai
                                      };

        }

        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }
        private void FormNhaCungCap_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
            LoadData();
            checkMaCongTy.Checked = true;
            txtMaCongTy.Focus();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //
            if (txtMaCongTy.Text.Length > 20)
            {
                MessageBox.Show("Mã công ty không được vượt quá 20 ký tự!", "Thông báo");
                return;
            }
            if (dkienrong())
            {
                MessageBox.Show(dkienthieutt(), "Thông báo"); ;
                return;
            }

            try
            {
                var existingncc = db.NhaCungCaps.FirstOrDefault(kh => kh.MaCongTy == txtMaCongTy.Text);
                if (existingncc != null)
                {
                    MessageBox.Show("Mã công ty đã tồn tại!", "Thông báo");
                    return;
                }
                NhaCungCap tb = new NhaCungCap();
                tb.MaCongTy = txtMaCongTy.Text;
                tb.TenCongTy = txtTenCongTy.Text;
                tb.DiaChi = txtDiaChi.Text;
                tb.DienThoai = txtDienThoai.Text;
                db.NhaCungCaps.InsertOnSubmit(tb);

                /* cach 2
                 var khachHang = new KhachHang
                  {
                      MaKH = txtMaKH.Text,
                      TenKH = txtTenKH.Text,
                      DiaChi = txtDiaChi.Text,
                      DienThoai = txtDienThoai.Text,
                      Email = txtEmail.Text
                  };
                  db.KhachHangs.InsertOnSubmit(khachHang);*/
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công nhà cung cấp: " + txtMaCongTy.Text, "Thông báo");
                resetTxt();
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }//end them

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dkienrong())
            {
                MessageBox.Show(dkienthieutt(), "Thông báo");
                return;
            }
            try
            {
                var nhacungCap = db.NhaCungCaps.FirstOrDefault(ncc => ncc.MaCongTy == txtMaCongTy.Text);
                if (nhacungCap == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp có mã công ty: " + txtMaCongTy.Text, "Thông báo");
                    return;
                }
                //khoi tao moi doi tuong tb moi
                NhaCungCap tb = new NhaCungCap();
                tb = (from table in db.NhaCungCaps
                      where table.MaCongTy == txtMaCongTy.Text
                      select table).Single();
                tb.TenCongTy = txtTenCongTy.Text;
                tb.DiaChi = txtDiaChi.Text;
                tb.DienThoai = txtDienThoai.Text;
                txtMaCongTy.Enabled = true;
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã sửa thành công nhà cung cấp: " + tb.MaCongTy, "Thông báo");
                resetTxt();
                checkMaCongTy.Checked = true;
            
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
                checkMaCongTy.Checked = true;
            }
        }//end sua

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCongTy.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!", "Thông báo");
                return;
            }

            try
            {
                //khoi tao moi doi tuong tb moi

                //            KhachHang tb = new KhachHang();
                //            tb = (from table in db.KhachHangs
                //                  where table.MaKH == txtMaKH.Text
                //                  select table).Single();
                var nhacungCap = db.NhaCungCaps.FirstOrDefault(ncc => ncc.MaCongTy == txtMaCongTy.Text);
                if (nhacungCap == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp có mã: " + txtMaCongTy.Text, "Thông báo");
                    return;
                }

                db.NhaCungCaps.DeleteOnSubmit(nhacungCap);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã xóa thành công nhà cung cấp: " + nhacungCap.MaCongTy, "Thông báo");
                resetTxt();
                checkMaCongTy.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo");
            }
        }//end xoa

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void dgvNhaCungCap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNhaCungCap.Rows[e.RowIndex];
                txtMaCongTy.Text = row.Cells[0].Value.ToString();
                txtTenCongTy.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtDienThoai.Text = row.Cells[3].Value.ToString();
                checkMaCongTy.Checked = false;
            }//end try
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 nhà cung cấp!");
            }

        }

        //ham reset textbox
        private void resetTxt()
        {
            txtMaCongTy.ResetText();
            txtTenCongTy.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
        }
        /*cac ham dieu kien*/
        //lenh cmt ctrl k - ctrl c
        private string dkienthieutt()
        {

            return !string.IsNullOrEmpty(txtMaCongTy.Text) &&
              !string.IsNullOrEmpty(txtTenCongTy.Text) &&
              !string.IsNullOrEmpty(txtDiaChi.Text) &&
               string.IsNullOrEmpty(txtDienThoai.Text) ? "Thiếu điện thoại!" :
              //
              !string.IsNullOrEmpty(txtMaCongTy.Text) &&
              !string.IsNullOrEmpty(txtTenCongTy.Text) &&
              !string.IsNullOrEmpty(txtDienThoai.Text) &&
               string.IsNullOrEmpty(txtDiaChi.Text) ? "Thiếu địa chỉ!" :
              //
              !string.IsNullOrEmpty(txtMaCongTy.Text) &&
              !string.IsNullOrEmpty(txtDiaChi.Text) &&
              !string.IsNullOrEmpty(txtDienThoai.Text) &&
               string.IsNullOrEmpty(txtTenCongTy.Text) ? "Thiếu tên công ty!" :
              //
              !string.IsNullOrEmpty(txtTenCongTy.Text) &&
              !string.IsNullOrEmpty(txtDiaChi.Text) &&
              !string.IsNullOrEmpty(txtDienThoai.Text) &&
               string.IsNullOrEmpty(txtMaCongTy.Text) ? "Thiếu mã công ty!" : "Nhập thiếu thông tin!"; ;
        }
        //ham kiem tra cac dieu kien rong
        private bool dkienrong()
        {
            return string.IsNullOrEmpty(txtMaCongTy.Text) ||
                string.IsNullOrEmpty(txtTenCongTy.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text);
        }
        //ham kiem tra cac dieu kien khac rong
        private bool dkienkhacrong()
        {
            return !string.IsNullOrEmpty(txtMaCongTy.Text) &&
            !string.IsNullOrEmpty(txtTenCongTy.Text) &&
            !string.IsNullOrEmpty(txtDiaChi.Text) &&
            !string.IsNullOrEmpty(txtDienThoai.Text);
        }

        private void checkMaCongTy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMaCongTy.Checked)
            {
                txtMaCongTy.Enabled = true;
            }
            else
            {
                txtMaCongTy.Enabled = false;
            }
        }
    }
}
