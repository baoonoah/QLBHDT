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
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        //khoi tao mot doi tuong db moi
        QLBHDTDataContext db = new QLBHDTDataContext();

        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        private void LoadData()
        {
            dgvHoaDon.DataSource = from table in db.HoaDons
                                    select new
                                    {
                                        table.MaHD,
                                        table.MaNV,
                                        table.MaKH,
                                        table.NgayLapHD,
                                        table.NgayNhanHang                                };
            //load du lieu tu LoaiHang vao comboBox
            cbMaNV.DataSource = from nv in db.NhanViens select nv.MaNV;
            cbMaKH.DataSource = from kh in db.KhachHangs select kh.MaKH;
        }
        private void resetTxt()
        {
            txtMaHD.ResetText();
            dtpNgayLapHD.ResetText();
            dtpNgayNhanHang.ResetText();
            cbMaNV.SelectedIndex = -1;
            cbMaKH.SelectedIndex = -1;
        }
        
        
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            resetTxt();
        }

        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {
            resetTxt();
            checkMaHD.Checked = true;
            txtMaHD.Focus();


        }

        private void CheckMaHD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMaHD.Checked)
            {
                txtMaHD.Enabled = true;
            }
            else
            {
                txtMaHD.Enabled = false;
            }


        }

        private void BtnThem_Click(object sender, EventArgs e)
        {

            if (txtMaHD.Text.Length > 20)
            {
                MessageBox.Show("Mã hóa đơn không được vượt quá 20 ký tự!", "Thông báo");
                return;
            }
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo");
                return;
            }
            if (checknullcbb())
            {
                MessageBox.Show(checkcbb(), "Thông báo");
                return;
            }
            try
            {
                var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.MaHD == txtMaHD.Text);
                if (hoaDon != null)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo");
                    return;
                }
                HoaDon newHD = new HoaDon();
                newHD.MaHD = txtMaHD.Text;
                newHD.MaNV = cbMaNV.SelectedValue.ToString();
                newHD.MaKH = cbMaKH.SelectedValue.ToString();
                newHD.NgayLapHD = DateTime.Parse(dtpNgayLapHD.Text.ToString());
                newHD.NgayNhanHang = DateTime.Parse(dtpNgayNhanHang.Text.ToString());
                db.HoaDons.InsertOnSubmit(newHD);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công hóa đơn: " + txtMaHD.Text, "Thông báo");
                resetTxt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Thông báo");
            }
        }
        private bool checknullcbb()
        {
            return string.IsNullOrEmpty(cbMaNV.Text) || string.IsNullOrEmpty(cbMaNV.Text);
        }
        //hien thi thong bao
        private string checkcbb()
        {
            return string.IsNullOrEmpty(cbMaNV.Text) && string.IsNullOrEmpty(cbMaKH.Text) ? "Vui lòng chọn mã nhân viên và mã khách hàng!" :
                string.IsNullOrEmpty(cbMaNV.Text) && !string.IsNullOrEmpty(cbMaKH.Text) ? " Vui lòng chọn mã nhân viên!" : " Vui lòng chọn mã mã khách hàng!";

        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có thông tin rỗng
            if(string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo");
                return;
            }

            try
            {
                // Tìm sản phẩm cần sửa
                var hoaDon = db.HoaDons.FirstOrDefault(sp => sp.MaHD == txtMaHD.Text);
                // Kiểm tra nếu không tìm thấy sản phẩm
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã: " + txtMaHD.Text, "Thông báo");
                    return;
                }
                // Cập nhật thông tin sản phẩm
                hoaDon.MaNV = cbMaNV.SelectedValue.ToString();
                hoaDon.MaKH = cbMaKH.SelectedValue.ToString();
                hoaDon.NgayLapHD = DateTime.Parse(dtpNgayLapHD.Text.ToString());
                hoaDon.NgayNhanHang = DateTime.Parse(dtpNgayNhanHang.Text.ToString());
                // Lưu các thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                // Tải lại dữ liệu
                LoadData();
                MessageBox.Show("Đã sửa thành công hóa đơn: " + hoaDon.MaHD, "Thông báo");
                resetTxt();
                checkMaHD.Checked = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
                checkMaHD.Checked = true;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa!", "Thông báo");
                return;
            }

            try
            {
                var hoaDon = db.HoaDons.FirstOrDefault(hd => hd.MaHD == txtMaHD.Text);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã: " + txtMaHD.Text, "Thông báo");
                    return;
                }

                db.HoaDons.DeleteOnSubmit(hoaDon);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã xóa thành công hóa đơn: " + hoaDon.MaHD, "Thông báo");
                resetTxt();
                checkMaHD.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Thông báo");
            }
        }

        private void DgvHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells[0].Value.ToString();
                cbMaNV.Text = row.Cells[1].Value.ToString();
                cbMaKH.Text = row.Cells[2].Value.ToString();
                dtpNgayLapHD.Text = row.Cells[3].Value.ToString();
                dtpNgayNhanHang.Text = row.Cells[4].Value.ToString();
            }//end try
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 hóa đơn!");
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
