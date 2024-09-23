using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaThuoc
{
    public partial class FrmBaoCaoTonKho : Form
    {
        public FrmBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            //this.rvBaoCaoTonKho.LocalReport.ReportEmbeddedResource = "QuanLyNhaThuoc.BaoCao.rpBaoCaoTonKho.rdlc";
            //rvBaoCaoTonKho.RefreshReport();            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
