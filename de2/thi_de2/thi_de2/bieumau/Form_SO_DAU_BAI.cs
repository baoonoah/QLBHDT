using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thi_de2.bieumau
{
    public partial class Form_SO_DAU_BAI : Form
    {
        public Form_SO_DAU_BAI()
        {
            InitializeComponent();
        }
        de2DataContext db = new de2DataContext();
        private void LoadData()
        {
        
            dataGridView1.DataSource = from tb in db.SO_DAU_BAIs
                                       select new
                                       {
                                           tb.ID_BH,
                                           tb.Ma_GV,
                                           tb.Ma_HK,
                                           tb.Ma_MH,
                                           tb.Ma_LOP,
                                           tb.Thoigian_batdau,
                                           tb.Thoigian_ketthuc,
                                           tb.Soluong_vang,
                                           tb.Noidung_BH,
                                           tb.DG_Hoctap,
                                           tb.DG_Renluyen,
                                           tb.Sogio
                                       };
            cb_magv.DataSource = from tb in db.GIANG_VIENs select tb.Ma_GV;
            cb_mahk.DataSource = from tb in db.HOC_Kies select tb.Ma_HK;
            cb_mamh.DataSource = from tb in db.MON_HOCs select tb.Ma_MH;
            cb_malop.DataSource = from tb in db.LOPs select tb.Ma_LOP;
        }
        private void resetTxt()
        {
            txt_id.ResetText();
            cb_magv.SelectedIndex = -1;
            cb_mahk.SelectedIndex = -1;
            cb_mamh.SelectedIndex = -1;
            cb_malop.SelectedIndex = -1;
            dtp_tgbd.ResetText();   
            dtp_tgkt.ResetText();   
            txt_soluongvang.ResetText();   
            txt_noidung.ResetText();   
            txt_danhgiaht.ResetText();   
            txt_danhgiarenluyen.ResetText();   
            txt_sogio.ResetText();   
        }
        private void Form_SO_DAU_BAI_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            resetTxt();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

            SO_DAU_BAI sdb = new SO_DAU_BAI();
            if (string.IsNullOrEmpty(cb_magv.Text) ||
                string.IsNullOrEmpty(cb_mahk.Text) ||
                string.IsNullOrEmpty(cb_mamh.Text) ||
                string.IsNullOrEmpty(cb_malop.Text) ||
                string.IsNullOrEmpty(txt_soluongvang.Text) ||
                string.IsNullOrEmpty(txt_noidung.Text) ||
                string.IsNullOrEmpty(txt_danhgiaht.Text) ||
                string.IsNullOrEmpty(txt_danhgiarenluyen.Text) ||
                string.IsNullOrEmpty(txt_sogio.Text)
                )
            {
                MessageBox.Show("Vui lòng chọn và điền đầy đủ thông tin!", "Thông báo");
                return;

            }
                sdb.Ma_GV = cb_magv.SelectedValue.ToString();
                sdb.Ma_HK = cb_mahk.SelectedValue.ToString();
                sdb.Ma_MH = cb_mamh.SelectedValue.ToString();
                sdb.Ma_LOP= cb_malop.SelectedValue.ToString();
                sdb.Thoigian_batdau = DateTime.Parse(dtp_tgbd.Text.ToString());
                sdb.Thoigian_ketthuc = DateTime.Parse(dtp_tgkt.Text.ToString());
                int soluongvang;
                if (int.TryParse(txt_soluongvang.Text, out soluongvang))
                {
                    sdb.Soluong_vang= soluongvang;
                }
                else
                {
                    MessageBox.Show(" số lượng không hợp lệ!", "Thông báo");
                    return;
                }
                sdb.Noidung_BH = txt_noidung.Text;
                sdb.DG_Hoctap = txt_danhgiaht.Text;
                sdb.DG_Renluyen = txt_danhgiarenluyen.Text;
                int sogio;
                if (int.TryParse(txt_sogio.Text, out sogio))
                {
                    sdb.Sogio = sogio;
                }
                else
                {
                    MessageBox.Show(" số giờ không hợp lệ!", "Thông báo");
                    return;
                }
            db.SO_DAU_BAIs.InsertOnSubmit(sdb);
                db.SubmitChanges();
                LoadData();
                MessageBox.Show("Đã thêm thành công ", "Thông báo");
                resetTxt();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            SO_DAU_BAI sdb = new SO_DAU_BAI();
            if (string.IsNullOrEmpty(cb_magv.Text) ||
                string.IsNullOrEmpty(cb_mahk.Text) ||
                string.IsNullOrEmpty(cb_mamh.Text) ||
                string.IsNullOrEmpty(cb_malop.Text) ||
                string.IsNullOrEmpty(txt_soluongvang.Text) ||
                string.IsNullOrEmpty(txt_noidung.Text) ||
                string.IsNullOrEmpty(txt_danhgiaht.Text) ||
                string.IsNullOrEmpty(txt_danhgiarenluyen.Text) ||
                string.IsNullOrEmpty(txt_sogio.Text)
                )
            {
                MessageBox.Show("Vui lòng chọn và điền đầy đủ thông tin!", "Thông báo");
                return;

            }
            int selectedId;
            if (!int.TryParse(txt_id.Text, out selectedId))
            {
                MessageBox.Show("Chon id.");
                return;
            }
            SO_DAU_BAI IdToUpdate = db.SO_DAU_BAIs.FirstOrDefault(u => u.ID_BH == selectedId);

            IdToUpdate.Ma_GV = cb_magv.SelectedValue.ToString();
            IdToUpdate.Ma_HK = cb_mahk.SelectedValue.ToString();
            IdToUpdate.Ma_MH = cb_mamh.SelectedValue.ToString();
            IdToUpdate.Ma_LOP = cb_malop.SelectedValue.ToString();
            IdToUpdate.Thoigian_batdau = DateTime.Parse(dtp_tgbd.Text.ToString());
            IdToUpdate.Thoigian_ketthuc = DateTime.Parse(dtp_tgkt.Text.ToString());
            int soluongvang;
            if (int.TryParse(txt_soluongvang.Text, out soluongvang))
            {
                IdToUpdate.Soluong_vang = soluongvang;
            }
            else
            {
                MessageBox.Show(" số lượng không hợp lệ!", "Thông báo");
                return;
            }
            IdToUpdate.Noidung_BH = txt_noidung.Text;
            IdToUpdate.DG_Hoctap = txt_danhgiaht.Text;
            IdToUpdate.DG_Renluyen = txt_danhgiarenluyen.Text;
            int sogio;
            if (int.TryParse(txt_sogio.Text, out sogio))
            {
                IdToUpdate.Sogio = sogio;
            }
            else
            {
                MessageBox.Show(" số giờ không hợp lệ!", "Thông báo");
                return;
            }

            // Lưu các thay đổi vào cơ sở dữ liệu
            db.SubmitChanges();
            MessageBox.Show("Sửa thành công");
            // Refresh dữ liệu trên DataGridView
            LoadData();
            resetTxt();
            // Xóa nội dung các TextBox
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            de2DataContext db = new de2DataContext();
            int selectedId;
            if (!int.TryParse(txt_id.Text, out selectedId) )
            {
                MessageBox.Show("Chon id.");
                return;
            }
            try
            {

                SO_DAU_BAI IdToDelete = db.SO_DAU_BAIs.FirstOrDefault(u => u.ID_BH == selectedId);
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có muốn xóa không?", "Trả lời",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (traloi == DialogResult.OK)
                {
                    db.SO_DAU_BAIs.DeleteOnSubmit(IdToDelete);
                    db.SubmitChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");

                }
                resetTxt();

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi!"+ex.Message);

            }

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                txt_id.Text = row.Cells[0].Value.ToString();
                cb_magv.Text = row.Cells[1].Value.ToString();
                cb_mahk.Text = row.Cells[2].Value.ToString();
                cb_mamh.Text = row.Cells[3].Value.ToString();
                cb_malop.Text = row.Cells[4].Value.ToString();
                dtp_tgbd.Text = row.Cells[5].Value.ToString();
                dtp_tgkt.Text = row.Cells[6].Value.ToString();
                txt_soluongvang.Text = row.Cells[7].Value.ToString();
                txt_noidung.Text = row.Cells[8].Value.ToString();
                txt_danhgiaht.Text = row.Cells[9].Value.ToString();
                txt_danhgiarenluyen.Text = row.Cells[10].Value.ToString();
                txt_sogio.Text = row.Cells[11].Value.ToString();
             
            }
            catch (Exception)
            {
                MessageBox.Show("Chỉ được phép chọn 1 dòng!");
            }
        }

        private void txt_sogio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txt_danhgiarenluyen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
