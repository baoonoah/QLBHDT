namespace LeGiaBao21._1UDPM_QLBHDT.baocaoKH
{
    partial class FormReportKH
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetKH = new LeGiaBao21._1UDPM_QLBHDT.baocaoKH.DataSetKH();
            this.dataSetKHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.khachHangTableAdapter = new LeGiaBao21._1UDPM_QLBHDT.baocaoKH.DataSetKHTableAdapters.KhachHangTableAdapter();
            this.khachHangBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetKHBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetKHBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKHBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKHBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LeGiaBao21._1UDPM_QLBHDT.baocaoKH.ReportKH.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(84, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(592, 321);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetKH
            // 
            this.dataSetKH.DataSetName = "DataSetKH";
            this.dataSetKH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetKHBindingSource
            // 
            this.dataSetKHBindingSource.DataSource = this.dataSetKH;
            this.dataSetKHBindingSource.Position = 0;
            // 
            // KhachHangBindingSource
            // 
            this.KhachHangBindingSource.DataMember = "KhachHang";
            this.KhachHangBindingSource.DataSource = this.dataSetKH;
            // 
            // khachHangBindingSource1
            // 
            this.khachHangBindingSource1.DataMember = "KhachHang";
            this.khachHangBindingSource1.DataSource = this.dataSetKHBindingSource;
            // 
            // khachHangTableAdapter
            // 
            this.khachHangTableAdapter.ClearBeforeFill = true;
            // 
            // khachHangBindingSource2
            // 
            this.khachHangBindingSource2.DataMember = "KhachHang";
            this.khachHangBindingSource2.DataSource = this.dataSetKHBindingSource;
            // 
            // dataSetKHBindingSource1
            // 
            this.dataSetKHBindingSource1.DataSource = this.dataSetKH;
            this.dataSetKHBindingSource1.Position = 0;
            // 
            // dataSetKHBindingSource2
            // 
            this.dataSetKHBindingSource2.DataSource = this.dataSetKH;
            this.dataSetKHBindingSource2.Position = 0;
            // 
            // FormReportKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReportKH";
            this.Text = "FormReportKH";
            this.Load += new System.EventHandler(this.FormReportKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachHangBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKHBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetKHBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetKHBindingSource;
        private DataSetKH dataSetKH;
        private System.Windows.Forms.BindingSource KhachHangBindingSource;
        private System.Windows.Forms.BindingSource khachHangBindingSource1;
        private DataSetKHTableAdapters.KhachHangTableAdapter khachHangTableAdapter;
        private System.Windows.Forms.BindingSource khachHangBindingSource2;
        private System.Windows.Forms.BindingSource dataSetKHBindingSource1;
        private System.Windows.Forms.BindingSource dataSetKHBindingSource2;
    }
}