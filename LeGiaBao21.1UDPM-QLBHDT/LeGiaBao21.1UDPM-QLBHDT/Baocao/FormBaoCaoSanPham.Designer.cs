namespace LeGiaBao21._1UDPM_QLBHDT.Baocao
{
    partial class FormBaoCaoSanPham
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSet();
            this.sanPhamTonKhoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sanPhamTonKhoTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.SanPhamTonKhoTableAdapter();
            this.sanPhamBanRaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sanPhamBanRaTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.SanPhamBanRaTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamTonKhoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBanRaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bán Ra";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(565, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tồn Kho";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetSanPhamBanRa";
            reportDataSource1.Value = this.sanPhamBanRaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportSanPhamBanRa.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(559, 285);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetSanPhamTonKho";
            reportDataSource2.Value = this.sanPhamTonKhoBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportSanPhamTonKho.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(559, 285);
            this.reportViewer2.TabIndex = 0;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamTonKhoBindingSource
            // 
            this.sanPhamTonKhoBindingSource.DataMember = "SanPhamTonKho";
            this.sanPhamTonKhoBindingSource.DataSource = this.dataSet;
            // 
            // sanPhamTonKhoTableAdapter
            // 
            this.sanPhamTonKhoTableAdapter.ClearBeforeFill = true;
            // 
            // sanPhamBanRaBindingSource
            // 
            this.sanPhamBanRaBindingSource.DataMember = "SanPhamBanRa";
            this.sanPhamBanRaBindingSource.DataSource = this.dataSet;
            // 
            // sanPhamBanRaTableAdapter
            // 
            this.sanPhamBanRaTableAdapter.ClearBeforeFill = true;
            // 
            // FormBaoCaoSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormBaoCaoSanPham";
            this.Text = "FormBaoCaoSanPham";
            this.Load += new System.EventHandler(this.FormBaoCaoSanPham_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamTonKhoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBanRaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource sanPhamTonKhoBindingSource;
        private DataSetTableAdapters.SanPhamTonKhoTableAdapter sanPhamTonKhoTableAdapter;
        private System.Windows.Forms.BindingSource sanPhamBanRaBindingSource;
        private DataSetTableAdapters.SanPhamBanRaTableAdapter sanPhamBanRaTableAdapter;
    }
}