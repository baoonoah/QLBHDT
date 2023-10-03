using LeGiaBao21._1UDPM_QLBHDT.Hethong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LeGiaBao21._1UDPM_QLBHDT
{
    public partial class Form1 : Form
    {
        public string LoggedInUser { get; set; }
      
       
        public Form1()
        {
            InitializeComponent();
        }

        private void HệThôngsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hienthilable();
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (string.IsNullOrEmpty(LoggedInUser))
            {
                // Người dùng chưa đăng nhập

                cậpNhậtDữLiệuToolStripMenuItem.Enabled = false;
                đổiMậtKhẩuToolStripMenuItem.Enabled = false;
                tìmKiếmToolStripMenuItem.Enabled = false;
                thốngKêBáoCáoToolStripMenuItem.Enabled = false;
                thôngTinToolStripMenuItem.Enabled = false;

            }
            else
            {
                // Người dùng đã đăng nhập
                cậpNhậtDữLiệuToolStripMenuItem.Enabled = true;
                đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                tìmKiếmToolStripMenuItem.Enabled = true;
                thốngKêBáoCáoToolStripMenuItem.Enabled = true;
                thôngTinToolStripMenuItem.Enabled = true;
            }
        }

        private void ĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new Hethong.FormDangNhap();
            frm.Text = "Đăng Nhập";
            frm.ShowDialog();
            this.Hide();
            if (!string.IsNullOrEmpty(frm.LoggedInUser))
            {
                LoggedInUser = frm.LoggedInUser;
                
            }
        }
      
        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Hethong.FormDoiMatKhau();
            frm.Text = "Đổi Mật Khẩu";
            frm.ShowDialog();
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn Thoát phải không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Capnhatdulieu.FormNhaCungCap();
            frm.Text = "Nhà Cung Cấp";
            frm.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Capnhatdulieu.FormKhachHang();
            frm.Text = "Khách Hàng";
            frm.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Capnhatdulieu.FormNhanVien();
            frm.Text = "Nhân Viên";
            frm.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Capnhatdulieu.FormSanPham();
            frm.Text = "Sản Phẩm";
            frm.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Capnhatdulieu.FormHoaDon();
            frm.Text = "Hóa Đơn";
            frm.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Capnhatdulieu.FormChiTietHoaDon();
            frm.Text = "Chi Tiết Hóa Đơn";
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Capnhatdulieu.FormLoaiHang();
            frm.Text = "Loại Hàng";
            frm.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Hethong.FormDangKy();
            frm.Text = "Đăng Ký";
            frm.ShowDialog();
        }
  
        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoggedInUser) && LoggedInUser == "admin")
            {
                Form frm = new Hethong.FormQuanLyNguoiDung();
                frm.Text = "Quản Lý Người Dùng";
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn cần đăng nhập với tài khoản admin để truy cập chức năng này.");
            }
        }

        private void cậpNhậtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
        }
        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void hienthilable()
        {
            if (string.IsNullOrEmpty(LoggedInUser))
            {

                lbhienthi.Text = "Vui lòng đăng nhập!";
            }
            else
            {

                lbhienthi.Text = "Xin chào " + LoggedInUser + "!";
            }
        }
    }
}
