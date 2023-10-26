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
    public partial class FormChiTietHoaDon : Form
    {
        public FormChiTietHoaDon()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();

        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        private void LoadData()
        {
            dgvChiTietHoaDon.DataSource = from table in db.ChiTietHoaDons
                                   select new
                                   {
                                       table.MaHD,
                                       table.MaSP,
                                       table.SoLuong
                                   };
            //load du lieu tu LoaiHang vao comboBox
            cbMaHD.DataSource = from hd in db.HoaDons select hd.MaHD;
            cbMaSP.DataSource = from sp in db.SanPhams select sp.MaSP;
        }
        private void resetTxt()
        {
            txtSoLuong.ResetText();
            cbMaHD.SelectedIndex = -1;
            cbMaSP.SelectedIndex = -1;
       
        }
        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
            cbMaHD.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

                if (dkiennull())
                {
                MessageBox.Show(messnull(), "Thông báo");
                return;
                }
            var CTHD = db.ChiTietHoaDons.FirstOrDefault(hd => hd.MaHD == cbMaHD.Text && hd.MaSP == cbMaSP.Text);

            if (CTHD != null)
            {
                MessageBox.Show("Chi tiết hóa đơn này đã tồn tại!", "Thông báo");
                return;
            }
            try
            {
                ChiTietHoaDon newCTHD = new ChiTietHoaDon();
                newCTHD.MaHD = cbMaHD.SelectedValue.ToString();
                newCTHD.MaSP = cbMaSP.SelectedValue.ToString();
                long soluong;
                if (long.TryParse(txtSoLuong.Text, out soluong) && txtSoLuong.Text.Length <= 10)
                {
                    newCTHD.SoLuong = soluong;
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo");
                    return;
                }
                db.ChiTietHoaDons.InsertOnSubmit(newCTHD);
                db.SubmitChanges();
                MessageBox.Show("Đã thêm thành công CTHD: " + cbMaHD.Text, "Thông báo");  
                LoadData();
                resetTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có thông tin rỗng
            if (string.IsNullOrEmpty(cbMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 chi tiết hóa đơn để sửa!", "Thông báo");
                return;
            }
            if (string.IsNullOrEmpty(cbMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm!", "Thông báo");
                return;
            }
            try
            {
                // Tìm hoa don cần sửa
                var timMaHD = db.ChiTietHoaDons.FirstOrDefault(hd => hd.MaHD == cbMaHD.Text);
                var timMaSP = db.ChiTietHoaDons.FirstOrDefault(hd => hd.MaHD == cbMaHD.Text);
                // Kiểm tra nếu không tìm thấy ma hd
                if (timMaHD == null)
                {
                    MessageBox.Show("Không tìm thấy CTHD có mã hóa đơn: " + cbMaHD.Text, "Thông báo");
                    return;
                }
                if (timMaSP == null)
                {
                    MessageBox.Show("Không tìm thấy CTHD có mã sản phẩm: " + cbMaSP.Text, "Thông báo");
                    return;
                }
                long soluong;
                if (string.IsNullOrEmpty(txtSoLuong.Text.ToString())){
                    MessageBox.Show("Vui lòng nhập số lượng!", "Thông báo");
                    return;
                }
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd = (from table in db.ChiTietHoaDons
                        where table.MaHD == cbMaHD.Text && table.MaSP == cbMaSP.Text
                        select table).Single();
                if (long.TryParse(txtSoLuong.Text, out soluong) && txtSoLuong.Text.Length <= 10)
                {
                    cthd.SoLuong = soluong;
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo");
                    return;
                }
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã sửa thành công chi tiết hóa đơn có mã hóa đơn: " + cthd.MaHD, "Thông báo");
                resetTxt();
          
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
            
            }
        }//end sua

        private void btnXoa_Click(object sender, EventArgs e)
        {
            QLBHDTDataContext db = new QLBHDTDataContext();
            if (string.IsNullOrEmpty(cbMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để xóa!", "Thông báo");
                return;
            }
            try
            {
                //var CTHD = db.ChiTietHoaDons.FirstOrDefault(hd => hd.MaHD == cbMaHD.Text && hd.MaSP == cbMaHD.Text);
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd = (from table in db.ChiTietHoaDons
                        where table.MaHD == cbMaHD.Text && table.MaSP == cbMaSP.Text
                        select table).Single();
                db.ChiTietHoaDons.DeleteOnSubmit(cthd);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã xóa thành công chi tiết hóa đơn có mã hóa đơn " + cthd.MaHD+ " và mã sản phẩm: "+cthd.MaSP, "Thông báo");
                resetTxt();
                cbMaHD.Enabled = true;
                cbMaSP.Enabled = true;
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

        private void dgvChiTietHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvChiTietHoaDon.Rows[e.RowIndex];
                cbMaHD.Text = row.Cells[0].Value.ToString();
                cbMaSP.Text = row.Cells[1].Value.ToString();
                txtSoLuong.Text = row.Cells[2].Value.ToString();

            }//end try
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 chi tiết hóa đơn!");
            }
        }
        private bool dkiennull()
        {
            return string.IsNullOrEmpty(cbMaHD.Text) || string.IsNullOrEmpty(cbMaSP.Text)|| string.IsNullOrEmpty(txtSoLuong.Text);
        }
        //hien thi thong bao
        private string messnull()
        {
            return string.IsNullOrEmpty(cbMaHD.Text) && string.IsNullOrEmpty(cbMaSP.Text) && string.IsNullOrEmpty(txtSoLuong.Text) ? "Vui lòng chọn đầy đủ mã hóa đơn, mã sản phẩm và số lượng!" :
                string.IsNullOrEmpty(cbMaHD.Text) ? "Vui lòng chọn mã hóa đơn!" :
                string.IsNullOrEmpty(cbMaSP.Text) ? " Vui lòng chọn mã sản phẩm!": " Vui lòng nhập số lượng!";

        }
    }
}
