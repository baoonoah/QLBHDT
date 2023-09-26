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
           

        }
        
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }

        private void FormNhanVien_Click(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {

            
            checkMaNV.Checked = true;
            resetTxt();
            txtMaNV.Focus();

        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            //dieu kien 
            if (dkienrong())
            {
                MessageBox.Show("Nhập thiếu thông tin!", "Thông báo");
                return;
            }
            if (txtMaNV.Text.Length > 20)
            {
                MessageBox.Show("Mã nhân viên không được vượt quá 20 ký tự!", "Thông báo");
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
                db.NhanViens.InsertOnSubmit(tb);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công nhân viên "+tb.MaNV, "Thông báo");
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
                MessageBox.Show("Nhập thiếu thông tin", "Thông báo");
                return;
            }
            try
            {
                var nhanVien = db.NhanViens.FirstOrDefault(kh => kh.MaNV == txtMaNV.Text);
                if (nhanVien == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã: " + txtMaNV.Text, "Thông báo");
                    return;
                }
                //khoi tao moi doi tuong tb moi
                NhanVien tb = new NhanVien();
            tb = (from table in db.NhanViens
                  where table.MaNV == txtMaNV.Text
                  select table).Single();
            tb.HoLot = txtHoLot.Text;
            tb.Ten = txtTen.Text;
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
                tb.NgaySinh = DateTime.Parse(dtpNgaySinh.Text.ToString());
            db.SubmitChanges();
            LoadData();
             MessageBox.Show("Đã sửa thành công nhân viên: " + tb.MaNV, "Thông báo");
             resetTxt();
             checkMaNV.Checked = true;
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
                checkMaNV.Checked = true;
            }
        }//end function sua

   
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            QLBHDTDataContext db = new QLBHDTDataContext();
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo");
                return;
            }

            try
            {
                //khoi tao moi doi tuong tb moi
                //    NhanVien tb = new NhanVien();
                //tb = (from table in db.NhanViens
                //      where table.MaNV == txtMaNV.Text
                //      select table).Single();
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == txtMaNV.Text);
                if (nhanVien == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên có mã: " + txtMaNV.Text, "Thông báo");
                    return;
                }

                db.NhanViens.DeleteOnSubmit(nhanVien);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã xóa thành công khách hàng: " + nhanVien.MaNV, "Thông báo");
                resetTxt();
                checkMaNV.Checked = true;
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo");
            }
        }//end function xoa
    

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
                checkMaNV.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 nhân viên!");
            }
        }
        //ham reset textbox
        private void resetTxt()
        {
            txtMaNV.ResetText();
            txtHoLot.ResetText();
            txtTen.ResetText();
            dtpNgaySinh.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();

        }
        /*cac ham dieu kien*/
        //lenh cmt ctrl k - ctrl c
        
        //ham kiem tra cac dieu kien rong
        private bool dkienrong()
        {
            return string.IsNullOrEmpty(txtMaNV.Text) ||
            string.IsNullOrEmpty(txtHoLot.Text) ||
            string.IsNullOrEmpty(txtTen.Text) ||
            string.IsNullOrEmpty(txtDiaChi.Text)||
            string.IsNullOrEmpty(txtDienThoai.Text);
        }
        //ham kiem tra cac dieu kien khac rong
        private bool dkienkhacrong()
        {
            return !string.IsNullOrEmpty(txtMaNV.Text) &&
             !string.IsNullOrEmpty(txtHoLot.Text) &&
             !string.IsNullOrEmpty(txtTen.Text) &&
             !string.IsNullOrEmpty(txtDiaChi.Text)&&
             !string.IsNullOrEmpty(txtDienThoai.Text);
        }
       


        private void checkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMaNV.Checked)
            {
                txtMaNV.Enabled = true;
            }
            else
            {
                txtMaNV.Enabled = false;
            }
        }
        private void DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

