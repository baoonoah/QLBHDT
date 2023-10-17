namespace LeGiaBao21._1UDPM_QLBHDT.Baocao
{
    partial class FormKyLuc
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.nhanVien1DHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSet();
            this.nhanVien1DTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangvipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.nhanVien_1_DHTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.NhanVien_1_DHTableAdapter();
            this.NhanVien_1_DTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVien_1_DTTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.NhanVien_1_DTTableAdapter();
            this.KhachHang_vipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHang_vipTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.KhachHang_vipTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVien1DHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVien1DTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangvipBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien_1_DTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHang_vipBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nhanVien1DHBindingSource
            // 
            this.nhanVien1DHBindingSource.DataMember = "NhanVien_1_DH";
            this.nhanVien1DHBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nhanVien1DTBindingSource
            // 
            this.nhanVien1DTBindingSource.DataMember = "NhanVien_1_DT";
            this.nhanVien1DTBindingSource.DataSource = this.dataSet;
            // 
            // khachHangvipBindingSource
            // 
            this.khachHangvipBindingSource.DataMember = "KhachHang_vip";
            this.khachHangvipBindingSource.DataSource = this.dataSet;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(583, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhân Viên Kỷ Lục Hóa Đơn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetNhanVien_1_DH";
            reportDataSource1.Value = this.nhanVien1DHBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportNhanVien_1_DH.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(577, 264);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(583, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nhân Viên Kỷ Lục Doanh Thu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetNhanVien_1_DT";
            reportDataSource2.Value = this.nhanVien1DTBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportNhanVien_1_DT.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(577, 264);
            this.reportViewer2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(669, 359);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Khách Hàng Vip";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetKhachHang_vip";
            reportDataSource3.Value = this.khachHangvipBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportKhachHang_vip.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(669, 359);
            this.reportViewer3.TabIndex = 0;
            // 
            // nhanVien_1_DHTableAdapter
            // 
            this.nhanVien_1_DHTableAdapter.ClearBeforeFill = true;
            // 
            // NhanVien_1_DTBindingSource
            // 
            this.NhanVien_1_DTBindingSource.DataMember = "NhanVien_1_DT";
            this.NhanVien_1_DTBindingSource.DataSource = this.dataSet;
            // 
            // nhanVien_1_DTTableAdapter
            // 
            this.nhanVien_1_DTTableAdapter.ClearBeforeFill = true;
            // 
            // KhachHang_vipBindingSource
            // 
            this.KhachHang_vipBindingSource.DataMember = "KhachHang_vip";
            this.KhachHang_vipBindingSource.DataSource = this.dataSet;
            // 
            // khachHang_vipTableAdapter
            // 
            this.khachHang_vipTableAdapter.ClearBeforeFill = true;
            // 
            // FormKyLuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormKyLuc";
            this.Text = "FormKyLuc";
            this.Load += new System.EventHandler(this.FormKyLuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhanVien1DHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVien1DTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangvipBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NhanVien_1_DTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHang_vipBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource nhanVien1DHBindingSource;
        private DataSetTableAdapters.NhanVien_1_DHTableAdapter nhanVien_1_DHTableAdapter;
        private System.Windows.Forms.BindingSource NhanVien_1_DTBindingSource;
        private System.Windows.Forms.BindingSource nhanVien1DTBindingSource;
        private DataSetTableAdapters.NhanVien_1_DTTableAdapter nhanVien_1_DTTableAdapter;
        private System.Windows.Forms.BindingSource KhachHang_vipBindingSource;
        private System.Windows.Forms.BindingSource khachHangvipBindingSource;
        private DataSetTableAdapters.KhachHang_vipTableAdapter khachHang_vipTableAdapter;
    }
}