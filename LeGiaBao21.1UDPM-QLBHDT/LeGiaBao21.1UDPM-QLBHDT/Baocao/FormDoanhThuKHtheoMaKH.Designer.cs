namespace LeGiaBao21._1UDPM_QLBHDT.Baocao
{
    partial class FormDoanhThuKHtheoMaKH
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dataSetDoanhThuKHtheoMaKH = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetDoanhThuKHtheoMaKH();
            this.doanhThuKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doanhThuKhachHangTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetDoanhThuKHtheoMaKHTableAdapters.DoanhThuKhachHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDoanhThuKHtheoMaKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doanhThuKhachHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetDoanhThuKHtheoMaKH";
            reportDataSource1.Value = this.doanhThuKhachHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportDoanhThuKHtheoMaKH.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(75, 155);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(603, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // cbMaKH
            // 
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(138, 59);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(227, 24);
            this.cbMaKH.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(420, 52);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(86, 37);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // dataSetDoanhThuKHtheoMaKH
            // 
            this.dataSetDoanhThuKHtheoMaKH.DataSetName = "DataSetDoanhThuKHtheoMaKH";
            this.dataSetDoanhThuKHtheoMaKH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // doanhThuKhachHangBindingSource
            // 
            this.doanhThuKhachHangBindingSource.DataMember = "DoanhThuKhachHang";
            this.doanhThuKhachHangBindingSource.DataSource = this.dataSetDoanhThuKHtheoMaKH;
            // 
            // doanhThuKhachHangTableAdapter
            // 
            this.doanhThuKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // FormDoanhThuKHtheoMaKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.cbMaKH);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormDoanhThuKHtheoMaKH";
            this.Text = "FormDoanhThuKHtheoMaKH";
            this.Load += new System.EventHandler(this.FormDoanhThuKHtheoMaKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDoanhThuKHtheoMaKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doanhThuKhachHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.BindingSource doanhThuKhachHangBindingSource;
        private DataSetDoanhThuKHtheoMaKH dataSetDoanhThuKHtheoMaKH;
        private DataSetDoanhThuKHtheoMaKHTableAdapters.DoanhThuKhachHangTableAdapter doanhThuKhachHangTableAdapter;
    }
}