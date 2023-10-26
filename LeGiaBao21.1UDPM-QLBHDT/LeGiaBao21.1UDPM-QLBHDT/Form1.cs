using LeGiaBao21._1UDPM_QLBHDT.Hethong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                cậpNhậtDữLiệuToolStripMenuItem.Visible = false;
                tìmKiếmToolStripMenuItem.Visible = false;
                thốngKêBáoCáoToolStripMenuItem.Visible = false;

            }
            else
            {
                cậpNhậtDữLiệuToolStripMenuItem.Visible = true;
                tìmKiếmToolStripMenuItem.Visible = true;
                thốngKêBáoCáoToolStripMenuItem.Visible = true;
            }
        }

        private void ĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new Hethong.FormDangNhap();
            frm.Text = "Đăng Nhập";
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.LoggedInUser))
            {
                LoggedInUser = frm.LoggedInUser;
                
            }
            this.Hide();
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

        private void TìmKiếmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Timkiem.FormTimKiemNV();
            frm.Text = "Tìm Kiếm Nhân Viên";
            frm.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //đường dẫn file báo cáo
            DirectoryInfo dir = new DirectoryInfo(".");
            string dir2 = dir.FullName + "\\LeGiaBao-21.1UDPM-BaoCao.docx";

            try
            {
                System.Diagnostics.Process.Start(dir2);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể mở tệp tin Word." );
            }
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "https:///github.com/baoonoah/About";
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception )
            {
                MessageBox.Show("Liên kết bị lỗi!");
            }
        }

        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Timkiem.FormTimKiemKH();
            frm.Text = "Tìm Kiếm Khách Hàng";
            frm.ShowDialog();
        }

        private void tìmKiếmNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Timkiem.FormTimKiemNCC();
            frm.Text = "Tìm Kiếm Nhà Cung Cấp";
            frm.ShowDialog();
        }

        private void tìmKiếmLoạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Timkiem.FormTimKiemLH();
            frm.Text = "Tìm Kiếm Loại Hàng";
            frm.ShowDialog();
        }

        private void tìmKiếmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Timkiem.FormTimKiemSP();
            frm.Text = "Tìm Kiếm Sản Phẩm";
            frm.ShowDialog();
        }

        private void tìmKiếmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Timkiem.FormTimKiemHD();
            frm.Text = "Tìm Kiếm Hóa Đơn";
            frm.ShowDialog();
        }

        private void tìmKiếmCTHDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new Timkiem.FormTimKiemCTHD();
            frm.Text = "Tìm Kiếm Chi Tiết Hóa Đơn";
            frm.ShowDialog();
        }



   
        private void doanhThuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frm = new Baocao.FormBaoCaoDoanhThu();
            frm.Text = "Doanh Thu";
            frm.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Baocao.FormBaoCaoSanPham();
            frm.Text = "Sản Phẩm";
            frm.ShowDialog();
        }

        private void kỷLụcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Form frm = new Baocao.FormKyLuc();
            frm.Text = "Kỷ Lục";
            frm.ShowDialog();
        }

        private void lợiNhuậnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Form frm = new Baocao.FormLoiNhuan();
            frm.Text = "Lợi Nhuận";
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Hethong.FormDangNhap();
            frm.Text = "Đăng Nhập";
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn đăng xuất phải không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}

