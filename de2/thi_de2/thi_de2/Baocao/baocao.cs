using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thi_de2.Baocao
{
    public partial class baocao : Form
    {
        public baocao()
        {
            InitializeComponent();
        }

        private void baocao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.MH_KetThuc' table. You can move, or remove it, as needed.
            this.mH_KetThucTableAdapter.Fill(this.dataSet1.MH_KetThuc);
            // TODO: This line of code loads data into the 'dataSet1.So_Gio_Con_Lai' table. You can move, or remove it, as needed.
            this.so_Gio_Con_LaiTableAdapter.Fill(this.dataSet1.So_Gio_Con_Lai);
            // TODO: This line of code loads data into the 'dataSet1.So_Buoi_Vang' table. You can move, or remove it, as needed.
            this.so_Buoi_VangTableAdapter.Fill(this.dataSet1.So_Buoi_Vang);
            // TODO: This line of code loads data into the 'dataSet1.So_Buoi_Vang' table. You can move, or remove it, as needed.

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }
    }
}
