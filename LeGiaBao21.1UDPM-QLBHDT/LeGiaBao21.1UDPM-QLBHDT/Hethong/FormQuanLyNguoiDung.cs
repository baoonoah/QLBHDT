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
    public partial class FormQuanLyNguoiDung : Form
    {
        public FormQuanLyNguoiDung()
        {
            InitializeComponent();
        }
        QLBHDTDataContext db = new QLBHDTDataContext();
        private void LoadData()
        {
            dgvQuanLy.DataSource = from table in db.Users
                                     select new
                                     {
                                         table.Id,
                                         table.Username,
                                         table.Email,
                                         table.Password,
                                         table.ThoiGianTao
                                     };


            
        }
        private void ClearTxt()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
        
            // Kiểm tra nếu thông tin không hợp lệ
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin người dùng.");
                return;
            }
            var existingUser = db.Users.FirstOrDefault(u => u.Username == txtUsername.Text);
            if (existingUser != null)
            {
                MessageBox.Show("Tên người dùng đã tồn tại.");
                return;
            }
            // Tạo một đối tượng User mới
            User user = new User();
                user.Username = txtUsername.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                user.ThoiGianTao = DateTime.Now;


                // Thêm người dùng mới vào cơ sở dữ liệu
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                MessageBox.Show("Thêm thành công người dùng "+ txtUsername.Text+"!");
                // Refresh dữ liệu trên DataGridView
                LoadData();
                // Xóa nội dung các TextBox
                ClearTxt();
          
        }

        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearTxt();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            // Kiểm tra nếu không có hàng nào được chọn trên DataGridView
            if (dgvQuanLy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để sửa.");
                return;
            }

            // Lấy thông tin người dùng từ các TextBox
            int selectedUserId = Convert.ToInt32(dgvQuanLy.SelectedRows[0].Cells["Id"].Value);
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            // Tìm người dùng trong cơ sở dữ liệu
            User userToUpdate = db.Users.FirstOrDefault(u => u.Id == selectedUserId);
            if (userToUpdate == null)
            {
                MessageBox.Show("Không tìm thấy người dùng trong cơ sở dữ liệu.");
                return;
            }

            // Cập nhật thông tin người dùng
            userToUpdate.Username = username;
            userToUpdate.Password = password;
            userToUpdate.Email = email;
            userToUpdate.ThoiGianTao = DateTime.Now;

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SubmitChanges();

            // Refresh dữ liệu trên DataGridView
            LoadData();

            // Xóa nội dung các TextBox
            ClearTxt();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có hàng nào được chọn trên DataGridView
            if (dgvQuanLy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.");
                return;
            }

            // Lấy ID của người dùng được chọn
            int selectedUserId = Convert.ToInt32(dgvQuanLy.SelectedRows[0].Cells["Id"].Value);

            // Tìm người dùng trong cơ sở dữ liệu 
            User userToDelete = db.Users.FirstOrDefault(u => u.Id == selectedUserId);
            if (userToDelete == null)
            {
                MessageBox.Show("Không tìm thấy người dùng trong cơ sở dữ liệu.");
                return;
            }

            // Xóa người dùng khỏi cơ sở dữ liệu
              
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn xóa người dùng "+ userToDelete.Username+" không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                db.Users.DeleteOnSubmit(userToDelete);
                db.SubmitChanges();
            }
            // Refresh dữ liệu trên DataGridView
            LoadData();

            // Xóa nội dung các TextBox
            ClearTxt();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvQuanLy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvQuanLy.Rows[e.RowIndex];
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[2].Value.ToString();
                txtPassword.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 nhân viên!");
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ClearTxt();
        }
    }
}
