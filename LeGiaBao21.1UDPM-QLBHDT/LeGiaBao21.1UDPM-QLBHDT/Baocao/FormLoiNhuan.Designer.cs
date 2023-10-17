namespace LeGiaBao21._1UDPM_QLBHDT.Baocao
{
    partial class FormLoiNhuan
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataSet1 = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.loiNhuanThangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loiNhuanThangTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.LoiNhuanThangTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.loiNhuanSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loiNhuanSPTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.Baocao.DataSetTableAdapters.LoiNhuanSPTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loiNhuanThangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loiNhuanSPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(63, 84);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 306);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(532, 277);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lợi Nhuận Theo Tháng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(532, 277);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lợi Nhuận Sản Phẩm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSetLoiNhuanTheoThang";
            reportDataSource4.Value = this.loiNhuanThangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportLoiNhuanTheoThang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(526, 271);
            this.reportViewer1.TabIndex = 0;
            // 
            // loiNhuanThangBindingSource
            // 
            this.loiNhuanThangBindingSource.DataMember = "LoiNhuanThang";
            this.loiNhuanThangBindingSource.DataSource = this.dataSet1;
            // 
            // loiNhuanThangTableAdapter
            // 
            this.loiNhuanThangTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetLoiNhuanSP";
            reportDataSource3.Value = this.loiNhuanSPBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.Baocao.ReportLoiNhuanSP.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(526, 271);
            this.reportViewer2.TabIndex = 0;
            // 
            // loiNhuanSPBindingSource
            // 
            this.loiNhuanSPBindingSource.DataMember = "LoiNhuanSP";
            this.loiNhuanSPBindingSource.DataSource = this.dataSet1;
            // 
            // loiNhuanSPTableAdapter
            // 
            this.loiNhuanSPTableAdapter.ClearBeforeFill = true;
            // 
            // FormLoiNhuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormLoiNhuan";
            this.Text = "FormLoiNhuan";
            this.Load += new System.EventHandler(this.FormLoiNhuan_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loiNhuanThangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loiNhuanSPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DataSet dataSet1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource loiNhuanThangBindingSource;
        private DataSetTableAdapters.LoiNhuanThangTableAdapter loiNhuanThangTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource loiNhuanSPBindingSource;
        private DataSetTableAdapters.LoiNhuanSPTableAdapter loiNhuanSPTableAdapter;
    }
}