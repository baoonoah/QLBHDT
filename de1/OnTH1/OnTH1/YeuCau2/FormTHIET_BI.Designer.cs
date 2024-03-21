namespace OnTH1.YeuCau2
{
    partial class FormTHIET_BI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMaTB = new System.Windows.Forms.TextBox();
            this.dgvThietBi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenThietBi = new System.Windows.Forms.TextBox();
            this.txtCodeThietBi = new System.Windows.Forms.TextBox();
            this.dtpNgayNhapTB = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThongTinTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTinhTrangTB = new System.Windows.Forms.TextBox();
            this.cbbViTriTruocTB = new System.Windows.Forms.ComboBox();
            this.cbbViTriHienTaiTB = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.Ma_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaynhap_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thongtin_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vitri_truoc_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vitri_hientai_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tinhtrang_TB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaTB
            // 
            this.txtMaTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTB.Location = new System.Drawing.Point(202, 321);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.Size = new System.Drawing.Size(200, 27);
            this.txtMaTB.TabIndex = 0;
            // 
            // dgvThietBi
            // 
            this.dgvThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThietBi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_TB,
            this.Ten_TB,
            this.Code_TB,
            this.Ngaynhap_TB,
            this.Thongtin_TB,
            this.Vitri_truoc_TB,
            this.Vitri_hientai_TB,
            this.Tinhtrang_TB});
            this.dgvThietBi.Location = new System.Drawing.Point(21, 36);
            this.dgvThietBi.Name = "dgvThietBi";
            this.dgvThietBi.RowHeadersWidth = 51;
            this.dgvThietBi.RowTemplate.Height = 24;
            this.dgvThietBi.Size = new System.Drawing.Size(968, 251);
            this.dgvThietBi.TabIndex = 1;
            this.dgvThietBi.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvThietBi_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ma Thiet Bi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Code Thiet Bi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngay Nhap Thiet Bi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ten Thiet Bi";
            // 
            // txtTenThietBi
            // 
            this.txtTenThietBi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThietBi.Location = new System.Drawing.Point(202, 380);
            this.txtTenThietBi.Name = "txtTenThietBi";
            this.txtTenThietBi.Size = new System.Drawing.Size(200, 27);
            this.txtTenThietBi.TabIndex = 6;
            // 
            // txtCodeThietBi
            // 
            this.txtCodeThietBi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeThietBi.Location = new System.Drawing.Point(202, 439);
            this.txtCodeThietBi.Name = "txtCodeThietBi";
            this.txtCodeThietBi.Size = new System.Drawing.Size(200, 27);
            this.txtCodeThietBi.TabIndex = 7;
            // 
            // dtpNgayNhapTB
            // 
            this.dtpNgayNhapTB.Location = new System.Drawing.Point(202, 498);
            this.dtpNgayNhapTB.Name = "dtpNgayNhapTB";
            this.dtpNgayNhapTB.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayNhapTB.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(586, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Thong Tin Thiet Bi";
            // 
            // txtThongTinTB
            // 
            this.txtThongTinTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinTB.Location = new System.Drawing.Point(789, 321);
            this.txtThongTinTB.Name = "txtThongTinTB";
            this.txtThongTinTB.Size = new System.Drawing.Size(200, 27);
            this.txtThongTinTB.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Thiet Bi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(586, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Vi tri truoc thiet Bi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(586, 441);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Vi tri hien tai Thiet Bi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(586, 498);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tinh trang Thiet Bi";
            // 
            // txtTinhTrangTB
            // 
            this.txtTinhTrangTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhTrangTB.Location = new System.Drawing.Point(789, 487);
            this.txtTinhTrangTB.Name = "txtTinhTrangTB";
            this.txtTinhTrangTB.Size = new System.Drawing.Size(200, 27);
            this.txtTinhTrangTB.TabIndex = 15;
            // 
            // cbbViTriTruocTB
            // 
            this.cbbViTriTruocTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cbbViTriTruocTB.FormattingEnabled = true;
            this.cbbViTriTruocTB.Location = new System.Drawing.Point(789, 376);
            this.cbbViTriTruocTB.Name = "cbbViTriTruocTB";
            this.cbbViTriTruocTB.Size = new System.Drawing.Size(200, 28);
            this.cbbViTriTruocTB.TabIndex = 16;
            // 
            // cbbViTriHienTaiTB
            // 
            this.cbbViTriHienTaiTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.cbbViTriHienTaiTB.FormattingEnabled = true;
            this.cbbViTriHienTaiTB.Location = new System.Drawing.Point(789, 429);
            this.cbbViTriHienTaiTB.Name = "cbbViTriHienTaiTB";
            this.cbbViTriHienTaiTB.Size = new System.Drawing.Size(200, 28);
            this.cbbViTriHienTaiTB.TabIndex = 17;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(163, 611);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(481, 611);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 19;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(789, 611);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Ma_TB
            // 
            this.Ma_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ma_TB.DataPropertyName = "Ma_TB";
            this.Ma_TB.HeaderText = "Mã Thiết Bị";
            this.Ma_TB.MinimumWidth = 6;
            this.Ma_TB.Name = "Ma_TB";
            // 
            // Ten_TB
            // 
            this.Ten_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ten_TB.DataPropertyName = "Ten_TB";
            this.Ten_TB.HeaderText = "Tên Thiết Bị";
            this.Ten_TB.MinimumWidth = 6;
            this.Ten_TB.Name = "Ten_TB";
            // 
            // Code_TB
            // 
            this.Code_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Code_TB.DataPropertyName = "Code_TB";
            this.Code_TB.HeaderText = "Code Thiết Bị";
            this.Code_TB.MinimumWidth = 6;
            this.Code_TB.Name = "Code_TB";
            // 
            // Ngaynhap_TB
            // 
            this.Ngaynhap_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ngaynhap_TB.DataPropertyName = "Ngaynhap_TB";
            this.Ngaynhap_TB.HeaderText = "Ngày Nhập Thiết Bị";
            this.Ngaynhap_TB.MinimumWidth = 6;
            this.Ngaynhap_TB.Name = "Ngaynhap_TB";
            // 
            // Thongtin_TB
            // 
            this.Thongtin_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Thongtin_TB.DataPropertyName = "Thongtin_TB";
            this.Thongtin_TB.HeaderText = "Thông Tin Thiết Bị";
            this.Thongtin_TB.MinimumWidth = 6;
            this.Thongtin_TB.Name = "Thongtin_TB";
            this.Thongtin_TB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Vitri_truoc_TB
            // 
            this.Vitri_truoc_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vitri_truoc_TB.DataPropertyName = "Vitri_truoc_TB";
            this.Vitri_truoc_TB.HeaderText = "Vị trí trước thiệt bị";
            this.Vitri_truoc_TB.MinimumWidth = 6;
            this.Vitri_truoc_TB.Name = "Vitri_truoc_TB";
            this.Vitri_truoc_TB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Vitri_hientai_TB
            // 
            this.Vitri_hientai_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vitri_hientai_TB.DataPropertyName = "Vitri_hientai_TB";
            this.Vitri_hientai_TB.HeaderText = "Vị trí hiện tại thiết bị";
            this.Vitri_hientai_TB.MinimumWidth = 6;
            this.Vitri_hientai_TB.Name = "Vitri_hientai_TB";
            this.Vitri_hientai_TB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Tinhtrang_TB
            // 
            this.Tinhtrang_TB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tinhtrang_TB.DataPropertyName = "Tinhtrang_TB";
            this.Tinhtrang_TB.HeaderText = "Tình trạng thiết bị";
            this.Tinhtrang_TB.MinimumWidth = 6;
            this.Tinhtrang_TB.Name = "Tinhtrang_TB";
            // 
            // FormTHIET_BI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 724);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbbViTriHienTaiTB);
            this.Controls.Add(this.cbbViTriTruocTB);
            this.Controls.Add(this.txtTinhTrangTB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThongTinTB);
            this.Controls.Add(this.dtpNgayNhapTB);
            this.Controls.Add(this.txtCodeThietBi);
            this.Controls.Add(this.txtTenThietBi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvThietBi);
            this.Controls.Add(this.txtMaTB);
            this.Name = "FormTHIET_BI";
            this.Text = "FormTHIET_BI";
            this.Load += new System.EventHandler(this.FormTHIET_BI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThietBi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaTB;
        private System.Windows.Forms.DataGridView dgvThietBi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenThietBi;
        private System.Windows.Forms.TextBox txtCodeThietBi;
        private System.Windows.Forms.DateTimePicker dtpNgayNhapTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThongTinTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTinhTrangTB;
        private System.Windows.Forms.ComboBox cbbViTriTruocTB;
        private System.Windows.Forms.ComboBox cbbViTriHienTaiTB;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaynhap_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thongtin_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitri_truoc_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitri_hientai_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tinhtrang_TB;
    }
}