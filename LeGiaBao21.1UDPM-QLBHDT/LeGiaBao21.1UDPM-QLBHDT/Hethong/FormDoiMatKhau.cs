using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeGiaBao21._1UDPM_QLBHDT.Hethong;
namespace LeGiaBao21._1UDPM_QLBHDT.Hethong
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        
        }
        QLBHDTDataContext db = new QLBHDTDataContext();
        public string LoggedInUser { get; set; }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            ClearTxt();
            LoadData();
        }

        private void ClearTxt()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtPassNew.Clear();
            txtPassReNew.Clear();
        }
        private void LoadData()
        {
        
            ClearTxt();
        }
            private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LoggedInUser);
         
        
            if (dkienrong())
            {
                txtUsername.Text = LoggedInUser;
                string username = txtUsername.Text; 
                string password = txtPass.Text;
                string newPassword = txtPassNew.Text;
                string confirmNewPassword = txtPassReNew.Text; 
             

                
                if (newPassword != confirmNewPassword)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp!");
                    return;
                }

                
                var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // Cập nhật mật khẩu cho người dùng
                    user.Password = newPassword;

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();

                    MessageBox.Show("Thay đổi mật khẩu thành công!");
                    ClearTxt(); // Xóa nội dung trong các ô văn bản
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không hợp lệ!");
                }
            }
            else
            {
                return;
            }
        }
        private void BtnXoaTK_Click(object sender, EventArgs e)
        {
           
            if (dkienrongxoa())
            {
                string txtUsername = LoggedInUser;
                string username = txtUsername; 
                string password = txtPass.Text; 

                // Tìm người dùng trong cơ sở dữ liệu dựa trên tên người dùng
                var user = db.Users.FirstOrDefault(u => u.Username == username && u.Username == password);

                if (user != null)
                {
                    // Xóa người dùng khỏi cơ sở dữ liệu
                    db.Users.DeleteOnSubmit(user);

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();

                    MessageBox.Show("Xóa tài khoản thành công!");
                    ClearTxt(); // Xóa nội dung trong các ô văn bản
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác!");
                }
            }
          
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {

        }
        private bool dkienrongxoa()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng muốn xóa!");
                return false;
            }

            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return false;
            }
            return true;
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
