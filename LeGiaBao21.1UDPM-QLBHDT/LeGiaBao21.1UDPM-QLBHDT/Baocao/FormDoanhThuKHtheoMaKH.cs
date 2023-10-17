using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeGiaBao21._1UDPM_QLBHDT.Baocao
{
    public partial class FormDoanhThuKHtheoMaKH : Form
    {
        public FormDoanhThuKHtheoMaKH()
        {
            InitializeComponent();
        }

        private void FormDoanhThuKHtheoMaKH_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
