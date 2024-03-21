using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTH1.YeuCau2
{
    public partial class FormTHIET_BI : Form
    {
        public FormTHIET_BI()
        {
            InitializeComponent();
        }

        
        private void LoadData()
        {

            try
            {
                OnTH1DataContext db = new OnTH1DataContext();

                dgvThietBi.DataSource = from table in db.THIET_BIs
                                              select new
                                              {
                                                  table.Ma_TB,
                                                  table.Ten_TB,
                                                  table.Code_TB,
                                                  table.Ngaynhap_TB,
                                                  table.Thongtin_TB,
                                                  table.Vitri_truoc_TB,
                                                  table.Vitri_hientai_TB,
                                                  table.Tinhtrang_TB
                                              };
                cbbViTriHienTaiTB.DataSource = from h in db.PHONGs select h.Ma_phong;
                cbbViTriHienTaiTB.SelectedIndex = 0;

                cbbViTriTruocTB.DataSource = from s in db.PHONGs select s.Ma_phong;
                cbbViTriTruocTB.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được dữ liệu từ tables", "Thông báo");

            }


            txtCodeThietBi.ResetText();
            txtMaTB.ResetText();
            txtTenThietBi.ResetText();
            txtThongTinTB.ResetText();
            txtTinhTrangTB.ResetText();

        }
        private void FormTHIET_BI_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            OnTH1DataContext db = new OnTH1DataContext();
            try
            {

                //Khoi tao mot doi tuong tb moi
                THIET_BI tb = new THIET_BI();
                tb = (from table in db.THIET_BIs
                      where table.Ma_TB == txtMaTB.Text
                      select table).Single();


                tb.Ten_TB = txtTenThietBi.Text;
                tb.Code_TB = txtCodeThietBi.Text;
                tb.Ngaynhap_TB = DateTime.Parse(dtpNgayNhapTB.Text.ToString()); //doi kieu
                tb.Thongtin_TB = txtThongTinTB.Text;
                tb.Vitri_truoc_TB = cbbViTriTruocTB.Text;
                tb.Vitri_hientai_TB = cbbViTriHienTaiTB.Text;
                tb.Tinhtrang_TB = txtTinhTrangTB.Text;


                db.SubmitChanges(); //xac nhan co thay duoc duoc hay khong
                LoadData();
                MessageBox.Show("Đã Sửa xong!", "Thông báo");

            }
            catch (Exception)
            {

                MessageBox.Show("Không sửa được lỗi rồi!", "Thông báo");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaTB.Focus();
            OnTH1DataContext db = new OnTH1DataContext();


            try
            {

                //Khoi tao mot doi tuong tb moi
                THIET_BI tb = new THIET_BI();
                //tb = cai text minh nhap vo
                tb.Ma_TB = txtMaTB.Text;
                tb.Ten_TB = txtTenThietBi.Text;
                tb.Code_TB = txtCodeThietBi.Text;
                tb.Ngaynhap_TB = DateTime.Parse(dtpNgayNhapTB.Text.ToString()); //doi kieu
                tb.Thongtin_TB = txtThongTinTB.Text;
                tb.Vitri_truoc_TB = cbbViTriTruocTB.Text;
                tb.Vitri_hientai_TB = cbbViTriHienTaiTB.Text;
                tb.Tinhtrang_TB = txtTinhTrangTB.Text;
                db.THIET_BIs.InsertOnSubmit(tb); //inserto 
                db.SubmitChanges(); //xac nhan co thay duoc duoc hay khong
                LoadData();
                MessageBox.Show("Đã Thêm xong!", "Thông báo");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Không thêm được lỗi rồi!", "Thông báo");
            }


        }

        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            OnTH1DataContext db = new OnTH1DataContext();

            try
            {

                //Khoi tao mot doi tuong tb moi
                THIET_BI tb = new THIET_BI();
                tb = (from table in db.THIET_BIs
                      where table.Ma_TB == txtMaTB.Text
                      select table).Single();




                db.THIET_BIs.DeleteOnSubmit(tb); // xoa du lieu cua tb
                db.SubmitChanges(); //xac nhan co thay duoc duoc hay khong
                LoadData();
                MessageBox.Show("Đã Xóa xong!", "Thông báo");


            }
            catch (Exception ex)
            {

                MessageBox.Show("Không xóa được lỗi rồi!", "Thông báo");
            }
        }

        private void dgvThietBi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex >= 0)
            {
                row = dgvThietBi.Rows[e.RowIndex];
                txtMaTB.Text = row.Cells[0].Value.ToString();
                txtTenThietBi.Text = row.Cells[1].Value.ToString();
                txtCodeThietBi.Text = row.Cells[2].Value.ToString();
                dtpNgayNhapTB.Text = row.Cells[3].Value.ToString();
                txtThongTinTB.Text = row.Cells[4].Value.ToString();
                cbbViTriTruocTB.Text = row.Cells[5].Value.ToString();
                cbbViTriHienTaiTB.Text = row.Cells[6].Value.ToString();
                txtTinhTrangTB.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
