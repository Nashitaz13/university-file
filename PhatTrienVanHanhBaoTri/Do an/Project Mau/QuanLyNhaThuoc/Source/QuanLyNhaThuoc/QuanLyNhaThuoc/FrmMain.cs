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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tsmiThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void tsmiLapPhieuMuaThuoc_Click(object sender, EventArgs e)
        {
            FrmPhieuNhapThuoc frmPhieuNhapThuoc = new FrmPhieuNhapThuoc();
            frmPhieuNhapThuoc.MdiParent = this;
            frmPhieuNhapThuoc.Show();
        }

        private void tsmiSoPhieuMuaThuoc_Click(object sender, EventArgs e)
        {
            FrmSoPhieuNhapThuoc frmSoPhieuNhapThuoc = new FrmSoPhieuNhapThuoc();
            frmSoPhieuNhapThuoc.MdiParent = this;
            frmSoPhieuNhapThuoc.Show();
        }

        private void tsmiLapPhieuBanThuoc_Click(object sender, EventArgs e)
        {
            FrmPhieuBanThuoc frmPhieuBanThuoc = new FrmPhieuBanThuoc();
            frmPhieuBanThuoc.MdiParent = this;
            frmPhieuBanThuoc.Show();
        }

        private void tsmiSoPhieuBanThuoc_Click(object sender, EventArgs e)
        {
            FrmSoPhieuBanThuoc frmSoPhieuBanThuoc = new FrmSoPhieuBanThuoc();
            frmSoPhieuBanThuoc.MdiParent = this;
            frmSoPhieuBanThuoc.Show();
        }

        private void tsmiThuoc_Click(object sender, EventArgs e)
        {
            FrmThuoc frmThuoc = new FrmThuoc();
            frmThuoc.MdiParent = this;
            frmThuoc.Show();
        }

        private void tsmiNhomThuoc_Click(object sender, EventArgs e)
        {
            FrmNhomThuoc frmNhomThuoc = new FrmNhomThuoc();
            frmNhomThuoc.MdiParent = this;
            frmNhomThuoc.Show();
        }

        private void tsmiNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien frmNhanVien = new FrmNhanVien();
            frmNhanVien.MdiParent = this;
            frmNhanVien.Show();
        }

        private void tsmiNhaCungCap_Click(object sender, EventArgs e)
        {
            FrmNhaCungCap frmNhaCungCap = new FrmNhaCungCap();
            frmNhaCungCap.MdiParent = this;
            frmNhaCungCap.Show();
        }

        private void tsmiLapPhieuTraThuoc_Click(object sender, EventArgs e)
        {
            FrmPhieuTraThuoc frmPhieuTraThuoc = new FrmPhieuTraThuoc();
            frmPhieuTraThuoc.MdiParent = this;
            frmPhieuTraThuoc.Show();
        }

        private void tsmiSoPhieuTraThuoc_Click(object sender, EventArgs e)
        {
            FrmSoPhieuTraThuoc frmSoPhieuTraThuoc = new FrmSoPhieuTraThuoc();
            frmSoPhieuTraThuoc.MdiParent = this;
            frmSoPhieuTraThuoc.Show();
        }

        private void tsmiThuocTonKho_Click(object sender, EventArgs e)
        {
            FrmThuocTonKho frmThuocTonKho = new FrmThuocTonKho();
            frmThuocTonKho.MdiParent = this;
            frmThuocTonKho.Show();
        }

        private void tsmiTonKho_Click(object sender, EventArgs e)
        {
            FrmBaoCaoTonKho frmBaoCaoTonKho = new FrmBaoCaoTonKho();
            frmBaoCaoTonKho.MdiParent = this;
            frmBaoCaoTonKho.Show();
        }

        private void tsmiDoanhThu_Click(object sender, EventArgs e)
        {
            FrmBaoCaoDoanhThu frmBaoCaoDoanhThu= new FrmBaoCaoDoanhThu();
            frmBaoCaoDoanhThu.MdiParent = this;
            frmBaoCaoDoanhThu.Show();
        }
        
        private void tsmiThongTinTacGia_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.MdiParent = this;
            ab.Show();
        }

       
    }
}
