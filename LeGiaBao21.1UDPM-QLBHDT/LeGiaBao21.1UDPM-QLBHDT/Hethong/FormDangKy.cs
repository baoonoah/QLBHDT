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
    public partial class FormDangKy : Form
    {
        QLBHDTDataContext db = new QLBHDTDataContext();
        public FormDangKy()
        {
            InitializeComponent();
        }
        private void ClearTxt()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtPassRecomfirm.Clear();
        }


        private void FormDangKy_Load(object sender, EventArgs e)
        {
            ClearTxt();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string recomfirmPass = txtPassRecomfirm.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(recomfirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if(recomfirmPass != password)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác!");
                return;
            }
            var existingUser = db.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                MessageBox.Show("Tên người dùng "+ username + " đã tồn tại!");
                return;
            }

            User user = new User();
            user.Username = txtUsername.Text;
            user.Email = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.ThoiGianTao = DateTime.Now;
            // Thêm người dùng mới vào cơ sở dữ liệu
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công người dùng " + txtUsername.Text + "!");
            ClearTxt();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
              this.Close();
        }
    }
}
