using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Hethong
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();
        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            ClearTxt();
        }
        private void ClearTxt()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtPassNew.Clear();
            txtPassReNew.Clear();
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (dkienrong())
            {
                
            }
            else
            {
                return;
            }


        }

        private void BtnXoaTK_Click(object sender, EventArgs e)
        {

        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {

        }
        private bool dkienrong()
        {
            if (string.IsNullOrEmpty(txtUsername.Text)) {
                MessageBox.Show("Vui lòng nhập tên người dùng!");
                return false;
            }

            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassNew.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassReNew.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu xác nhận!");
                return false;
            }
            return true;
        }
    }
}
