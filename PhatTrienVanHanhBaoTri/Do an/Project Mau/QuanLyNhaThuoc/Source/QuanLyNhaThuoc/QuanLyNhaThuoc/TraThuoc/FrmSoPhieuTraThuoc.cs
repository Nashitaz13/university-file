using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNT.DataTransferObject;
using QLNT.BusinessLogicLayer;
using System.Data.SqlClient;
using QLNT.CommonLayer;

namespace QuanLyNhaThuoc
{
    public partial class FrmSoPhieuTraThuoc : Form
    {
        BllSoPhieuTraThuoc bllSoPhieuTraThuoc;
        DataTable dt;

        public FrmSoPhieuTraThuoc()
        {
            InitializeComponent();
            bllSoPhieuTraThuoc = new BllSoPhieuTraThuoc();
        }

        private void FrmSoPhieuTraThuoc_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
        }

        private void DocDuLieu()
        {
            dt = bllSoPhieuTraThuoc.DocDanhSachPhieuTraThuoc();
        }

        private void HienThiDuLieu()
        {
            dgvSoPhieuTraThuoc.DataSource = dt;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FrmPhieuTraThuoc frmPhieuTraThuoc = new FrmPhieuTraThuoc();
            frmPhieuTraThuoc.MdiParent = this.MdiParent;
            frmPhieuTraThuoc.Show();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            FrmPhieuTraThuoc frmPhieuTraThuoc = new FrmPhieuTraThuoc();
            frmPhieuTraThuoc.MdiParent = this.MdiParent;
            frmPhieuTraThuoc.MaPhieuTraThuoc = int.Parse(dgvSoPhieuTraThuoc.SelectedRows[0].Cells["dgvcMaPhieuTraThuoc"].Value.ToString());
            frmPhieuTraThuoc.Show();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
