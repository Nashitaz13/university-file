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
    public partial class FrmSoPhieuBanThuoc : Form
    {
        BllSoPhieuXuatThuoc bllSoPhieuXuatThuoc;
        DataTable dt;
        
        public FrmSoPhieuBanThuoc()
        {
            InitializeComponent();
            bllSoPhieuXuatThuoc = new BllSoPhieuXuatThuoc();
        }

        private void FrmSoPhieuBanThuoc_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
        }

        private void DocDuLieu()
        {
            dt = bllSoPhieuXuatThuoc.DocDanhSachPhieuXuatThuoc();
        }

        private void HienThiDuLieu()
        {
            dgvSoPhieuXuatThuoc.DataSource = dt;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            FrmPhieuBanThuoc frmPhieuBanThuoc = new FrmPhieuBanThuoc();
            frmPhieuBanThuoc.MdiParent = this.MdiParent;
            frmPhieuBanThuoc.MaPhieuXuatThuoc = int.Parse(dgvSoPhieuXuatThuoc.SelectedRows[0].Cells["dgvcMaHoaDonXuat"].Value.ToString());
            frmPhieuBanThuoc.Show();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FrmPhieuBanThuoc frmPhieuBanThuoc = new FrmPhieuBanThuoc();
            frmPhieuBanThuoc.MdiParent = this.MdiParent;
            frmPhieuBanThuoc.Show();
        }
    }
}
