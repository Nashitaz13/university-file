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
    public partial class FrmSoPhieuNhapThuoc : Form
    {
        BllSoPhieuNhapThuoc bllSoPhieuNhapThuoc;
        DataTable dt;

        public FrmSoPhieuNhapThuoc()
        {
            InitializeComponent();
            bllSoPhieuNhapThuoc = new BllSoPhieuNhapThuoc();
        }

        private void FrmSoPhieuNhapThuoc_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
        }

        private void DocDuLieu()
        {
            dt = bllSoPhieuNhapThuoc.DocDanhSachPhieuNhapThuoc();
        }

        private void HienThiDuLieu()
        {
            dgvSoPhieuNhapThuoc.DataSource = dt;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            FrmPhieuNhapThuoc frmPhieuNhapThuoc = new FrmPhieuNhapThuoc();
            frmPhieuNhapThuoc.MdiParent = this.MdiParent;
            frmPhieuNhapThuoc.MaPhieuNhapThuoc = int.Parse(dgvSoPhieuNhapThuoc.SelectedRows[0].Cells["dgvcMaHoaDonNhap"].Value.ToString());
            frmPhieuNhapThuoc.Show();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FrmPhieuNhapThuoc frmPhieuNhapThuoc = new FrmPhieuNhapThuoc();
            frmPhieuNhapThuoc.MdiParent = this.MdiParent;
            frmPhieuNhapThuoc.Show();
        }
    }
}
