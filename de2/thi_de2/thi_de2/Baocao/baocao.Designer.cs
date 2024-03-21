namespace thi_de2.Baocao
{
    partial class baocao
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.soBuoiVangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new thi_de2.Baocao.DataSet1();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.soBuoiVangBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.so_Buoi_VangTableAdapter = new thi_de2.Baocao.DataSet1TableAdapters.So_Buoi_VangTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.So_Gio_Con_LaiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.soGioConLaiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.so_Gio_Con_LaiTableAdapter = new thi_de2.Baocao.DataSet1TableAdapters.So_Gio_Con_LaiTableAdapter();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MH_KetThucBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mHKetThucBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mH_KetThucTableAdapter = new thi_de2.Baocao.DataSet1TableAdapters.MH_KetThucTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.soBuoiVangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soBuoiVangBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.So_Gio_Con_LaiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soGioConLaiBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MH_KetThucBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mHKetThucBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // soBuoiVangBindingSource
            // 
            this.soBuoiVangBindingSource.DataMember = "So_Buoi_Vang";
            this.soBuoiVangBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(29, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(630, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource8.Name = "sobuoivang";
            reportDataSource8.Value = this.soBuoiVangBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "thi_de2.Baocao.sobuoivang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(624, 333);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(630, 339);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // soBuoiVangBindingSource1
            // 
            this.soBuoiVangBindingSource1.DataMember = "So_Buoi_Vang";
            this.soBuoiVangBindingSource1.DataSource = this.dataSet1;
            // 
            // so_Buoi_VangTableAdapter
            // 
            this.so_Buoi_VangTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource9.Name = "sogioconlai";
            reportDataSource9.Value = this.soGioConLaiBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "thi_de2.Baocao.sogioconlai.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 3);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(624, 333);
            this.reportViewer2.TabIndex = 0;
            // 
            // So_Gio_Con_LaiBindingSource
            // 
            this.So_Gio_Con_LaiBindingSource.DataMember = "So_Gio_Con_Lai";
            this.So_Gio_Con_LaiBindingSource.DataSource = this.dataSet1;
            // 
            // soGioConLaiBindingSource
            // 
            this.soGioConLaiBindingSource.DataMember = "So_Gio_Con_Lai";
            this.soGioConLaiBindingSource.DataSource = this.dataSet1;
            // 
            // so_Gio_Con_LaiTableAdapter
            // 
            this.so_Gio_Con_LaiTableAdapter.ClearBeforeFill = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.reportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(630, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource7.Name = "monhocketthuc";
            reportDataSource7.Value = this.mHKetThucBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "thi_de2.Baocao.monhocketthuc.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(3, 3);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(624, 333);
            this.reportViewer3.TabIndex = 0;
            // 
            // MH_KetThucBindingSource
            // 
            this.MH_KetThucBindingSource.DataMember = "MH_KetThuc";
            this.MH_KetThucBindingSource.DataSource = this.dataSet1;
            // 
            // mHKetThucBindingSource
            // 
            this.mHKetThucBindingSource.DataMember = "MH_KetThuc";
            this.mHKetThucBindingSource.DataSource = this.dataSet1;
            // 
            // mH_KetThucTableAdapter
            // 
            this.mH_KetThucTableAdapter.ClearBeforeFill = true;
            // 
            // baocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "baocao";
            this.Text = "baocao";
            this.Load += new System.EventHandler(this.baocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soBuoiVangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soBuoiVangBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.So_Gio_Con_LaiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soGioConLaiBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MH_KetThucBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mHKetThucBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource soBuoiVangBindingSource;
        private System.Windows.Forms.BindingSource soBuoiVangBindingSource1;
        private DataSet1TableAdapters.So_Buoi_VangTableAdapter so_Buoi_VangTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource So_Gio_Con_LaiBindingSource;
        private System.Windows.Forms.BindingSource soGioConLaiBindingSource;
        private DataSet1TableAdapters.So_Gio_Con_LaiTableAdapter so_Gio_Con_LaiTableAdapter;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource MH_KetThucBindingSource;
        private System.Windows.Forms.BindingSource mHKetThucBindingSource;
        private DataSet1TableAdapters.MH_KetThucTableAdapter mH_KetThucTableAdapter;
    }
}