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
    public partial class FrmBaoCaoDoanhThu : Form
    {
        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            //this.rvBaoCaoDoanhThu.LocalReport.ReportEmbeddedResource = "QuanLyNhaThuoc.BaoCao.rpBaoCaoDoanhThu.rdlc";
            //rvBaoCaoDoanhThu.RefreshReport();   
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
