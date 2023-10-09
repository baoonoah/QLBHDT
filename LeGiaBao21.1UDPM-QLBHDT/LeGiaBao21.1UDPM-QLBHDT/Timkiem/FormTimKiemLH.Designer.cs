namespace LeGiaBao21._1UDPM_QLBHDT.Timkiem
{
    partial class FormTimKiemLH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTimKiemLH));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMaLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtTenLoaiHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLoaiHang = new System.Windows.Forms.DataGridView();
            this.MaLoaiHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.cbMaLoaiHang);
            this.panel1.Controls.Add(this.txtTenLoaiHang);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(81, 194);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 160);
            this.panel1.TabIndex = 46;
            // 
            // cbMaLoaiHang
            // 
            this.cbMaLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaLoaiHang.FormattingEnabled = true;
            this.cbMaLoaiHang.Location = new System.Drawing.Point(225, 33);
            this.cbMaLoaiHang.Name = "cbMaLoaiHang";
            this.cbMaLoaiHang.Size = new System.Drawing.Size(237, 24);
            this.cbMaLoaiHang.TabIndex = 16;
            this.cbMaLoaiHang.SelectedIndexChanged += new System.EventHandler(this.cbMaLoaiHang_SelectedIndexChanged);
            // 
            // txtTenLoaiHang
            // 
            this.txtTenLoaiHang.Location = new System.Drawing.Point(225, 92);
            this.txtTenLoaiHang.Name = "txtTenLoaiHang";
            this.txtTenLoaiHang.Size = new System.Drawing.Size(237, 22);
            this.txtTenLoaiHang.TabIndex = 15;
            this.txtTenLoaiHang.TextChanged += new System.EventHandler(this.txtTenLoaiHang_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(114, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tìm Tên LH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(114, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Mã LH";
            // 
            // dgvLoaiHang
            // 
            this.dgvLoaiHang.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvLoaiHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiHang,
            this.TenLoaiHang});
            this.dgvLoaiHang.Location = new System.Drawing.Point(81, 13);
            this.dgvLoaiHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLoaiHang.Name = "dgvLoaiHang";
            this.dgvLoaiHang.RowHeadersWidth = 51;
            this.dgvLoaiHang.Size = new System.Drawing.Size(587, 163);
            this.dgvLoaiHang.TabIndex = 47;
            // 
            // MaLoaiHang
            // 
            this.MaLoaiHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaLoaiHang.DataPropertyName = "MaLoaiHang";
            this.MaLoaiHang.HeaderText = "Mã Loại Hàng";
            this.MaLoaiHang.MinimumWidth = 6;
            this.MaLoaiHang.Name = "MaLoaiHang";
            // 
            // TenLoaiHang
            // 
            this.TenLoaiHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLoaiHang.DataPropertyName = "TenLoaiHang";
            this.TenLoaiHang.HeaderText = "Tên Loại Hàng";
            this.TenLoaiHang.MinimumWidth = 6;
            this.TenLoaiHang.Name = "TenLoaiHang";
            // 
            // btnHienThi
            // 
            this.btnHienThi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnHienThi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnHienThi.Location = new System.Drawing.Point(44, 375);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(155, 62);
            this.btnHienThi.TabIndex = 51;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = false;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(605, 375);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(155, 62);
            this.btnThoat.TabIndex = 50;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTim.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(418, 375);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(155, 62);
            this.btnTim.TabIndex = 49;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNhapMoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnNhapMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapMoi.Image")));
            this.btnNhapMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhapMoi.Location = new System.Drawing.Point(231, 375);
            this.btnNhapMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(155, 62);
            this.btnNhapMoi.TabIndex = 48;
            this.btnNhapMoi.Text = "Làm sạch";
            this.btnNhapMoi.UseVisualStyleBackColor = false;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // FormTimKiemLH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnNhapMoi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvLoaiHang);
            this.Name = "FormTimKiemLH";
            this.Text = "FormTimKiemLH";
            this.Load += new System.EventHandler(this.FormTimKiemLH_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTenLoaiHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLoaiHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiHang;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.ComboBox cbMaLoaiHang;
    }
}