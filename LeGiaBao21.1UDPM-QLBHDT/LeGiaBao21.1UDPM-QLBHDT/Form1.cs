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
        public Form1()
        {
            InitializeComponent();
        }

        private void HệThôngsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new FormDangNhap();
            frm.Text = "Đăng Nhập";
            frm.ShowDialog();
      
        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Hethong.FormDoiMatKhau();
            frm.Text = "Đổi Mật Khẩu";
            frm.ShowDialog();
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
