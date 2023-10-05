using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Hethong
{
    public partial class FormDangNhap : Form
    {
        private string connectionString = "Data Source=LAPTOP-O9SMJSLO\\SQLEXPRESS;Initial Catalog=QLBHDT;User ID=sa;Password=123;";
        //private string connectionString = "Data Source=MAY18;Initial Catalog=QLBHDT; Integrated Security =true";
        public string LoggedInUser { get; set; }
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Lấy tên đăng nhập và mật khẩu từ hộp văn bản
            string username = txtUser.Text;
            string password = txtPass.Text;
           

            // Kiểm tra xem có trường nào để trống không
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show(dkien());
                return;
            }

            // Tạo kết nối với cơ sở dữ liệu
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            conn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            conn.Close();

            // Kiểm tra
            int count = ds.Tables[0].Rows.Count;
            if (count == 1)
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công " + username + "!");
                LoggedInUser = username;
                this.Hide();
                Form1 fm = new Form1();
                fm.LoggedInUser = LoggedInUser;
                fm.Show();
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác!");
            }
          
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn Thoát phải không?", "Trả lời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Hide();
        }
        private string dkien()
        {
            return string.IsNullOrEmpty(txtUser.Text) && string.IsNullOrEmpty(txtPass.Text) ? "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu" :
                string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPass.Text) ? "Vui lòng nhập tên đăng nhập!" : "Vui lòng nhập mật khẩu!";
        }

    }
}
