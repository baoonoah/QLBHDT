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
    public partial class FormKhachHang : Form
    {

        public FormKhachHang()
        {
            InitializeComponent();
        }
        //khoi tao mot doi tuong db moi
        QLBHDTDataContext db = new QLBHDTDataContext();
        //Khai bao bien kiem tra viec Thenm hay sua du lieu
        bool xoa;
        private void LoadData()
        {
            dgvKhachHang.DataSource = from table in db.KhachHangs
                                      select new
                                      {
                                          table.MaKH,
                                          table.TenKH,
                                          table.DiaChi,
                                          table.DienThoai,
                                          table.Email
                                      };
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            txtEmail.ResetText();

        }



        private void FormKhachHang_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void BtnThem_Click(object sender, EventArgs e)
        {
          
                //khoi tao moi doi tuong tb moi
                KhachHang tb = new KhachHang();
                tb.MaKH = txtMaKH.Text;
                tb.TenKH = txtTenKH.Text;
                tb.DiaChi = txtDiaChi.Text;
                tb.DienThoai = txtDienThoai.Text;
                tb.Email = txtEmail.Text;
            try
            {
                if (!string.IsNullOrEmpty(txtMaKH.Text) &&
                    !string.IsNullOrEmpty(txtTenKH.Text) &&
                    !string.IsNullOrEmpty(txtDiaChi.Text) &&
                    !string.IsNullOrEmpty(txtDienThoai.Text))
                {
                    db.KhachHangs.InsertOnSubmit(tb);
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Đã thêm xong!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("nhập thiếu dữ liệu!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
            }
        }

        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            txtEmail.ResetText();
            txtMaKH.Focus();
           
        }

        private void DgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           xoa = true;
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtDienThoai.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn 1 khách hàng!");
            }

        }

        private void BtnSua_Click(object sender, EventArgs e)
        {

            try
            { 
                if (!string.IsNullOrEmpty(txtMaKH.Text))
                {
                    //khoi tao moi doi tuong tb moi
                    KhachHang tb = new KhachHang();
            tb = (from table in db.KhachHangs
                  where table.MaKH == txtMaKH.Text
                  select table).Single();
            tb.TenKH = txtTenKH.Text;
            tb.DiaChi = txtDiaChi.Text;
            tb.DienThoai = txtDienThoai.Text;
            tb.Email = txtEmail.Text;
            db.SubmitChanges();
            LoadData();
            MessageBox.Show("Đã sửa xong khách hàng "+tb.MaKH, "Thông báo");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để sửa", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
            }
        }
     //   hãy vô hiệu hóa không cho sửa textbox txtMaKH khi lấy dữ liệu từ cells đưa xuống
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKH.Text))
            {
                    //khoi tao moi doi tuong tb moi

                    KhachHang tb = new KhachHang();
                    tb = (from table in db.KhachHangs
                          where table.MaKH == txtMaKH.Text
                          select table).Single();
                    db.KhachHangs.DeleteOnSubmit(tb);//xoa du lieu cua tb
                    db.SubmitChanges();//xac nhan thay doi du lieu
                    LoadData();//load du lieu moi
                MessageBox.Show("Đã xóa thành công khách hàng " + tb.MaKH, "Thông báo");
            }
            else { 
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa " ,"Thông báo");
                }

        }

    
    private void BtnThoat_Click(object sender, EventArgs e)
    {
        this.Close();
    }


    private void DgvKhachHang_DoubleClick(object sender, EventArgs e)
    {

    }

    private void DgvKhachHang_MouseClick(object sender, MouseEventArgs e)
    {
    }
    private void DgvKhachHang_Click(object sender, EventArgs e)
    {

    }
    }
}

/*
private void DgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
{
    try
    {
        DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
        txtMaKH.Text = row.Cells[0].Value.ToString();
        txtTenKH.Text = row.Cells[1].Value.ToString();
        txtDiaChi.Text = row.Cells[2].Value.ToString();
        txtDienThoai.Text = row.Cells[3].Value.ToString();
        txtEmail.Text = row.Cells[4].Value.ToString();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Hãy chọn ít nhất 1 dòng.", "Thông báo");
    }
}

private void BtnSua_Click(object sender, EventArgs e)
{
    try
    {
        if (!string.IsNullOrEmpty(txtMaKH.Text))
        {
            KhachHang tb = (from table in db.KhachHangs
                            where table.MaKH == txtMaKH.Text
                            select table).Single();
            tb.TenKH = txtTenKH.Text;
            tb.DiaChi = txtDiaChi.Text;
            tb.DienThoai = txtDienThoai.Text;
            tb.Email = txtEmail.Text;
            db.SubmitChanges();
            LoadData();
            MessageBox.Show("Đã sửa xong!", "Thông báo");
        }
        else
        {
            MessageBox.Show("Hãy chọn ít nhất 1 dòng.", "Thông báo");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Thông báo");
    }
}
*/