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
    public partial class FrmThuocTonKho : Form
    {
        BllTraCuuThuoc bllTraCuuThuoc;
        BllNhomThuoc bllNhomThuoc;
        DataTable dtNhomThuoc;
        DataTable dtTraCuuThuoc;

        public FrmThuocTonKho()
        {
            InitializeComponent();
            bllTraCuuThuoc = new BllTraCuuThuoc();
            bllNhomThuoc = new BllNhomThuoc();
            dtNhomThuoc = new DataTable();
            dtTraCuuThuoc = new DataTable();
        }

        private void DocDuLieu()
        {           
            dtNhomThuoc = bllNhomThuoc.DocDanhMucNhomThuoc();
        }

        private void GanDoiTuongDuLieuVaoCacDieuKhien()
        {
            //Hien thi du lieu cua chi tiet phieu Xuat thuoc tren tung cot cua luoi.
            dgvcMaThuoc.DataPropertyName = "MaThuoc";
            dgvcTenNhomThuoc.DataPropertyName = "TenNhomThuoc";
            dgvcTenThuoc.DataPropertyName = "TenThuoc";
            dgvcTongSoLuongNhap.DataPropertyName = "TongSoLuongNhap";
            dgvcTongSoLuongXuat.DataPropertyName = "TongSoLuongXuat";
            dgvcTongSoLuongTon.DataPropertyName = "TongSoLuongTon";            
        }

        private void HienThiDuLieu()
        {
            cboNhomThuoc.DataSource = dtNhomThuoc;
            cboNhomThuoc.DisplayMember = "TenNhomThuoc";
            cboNhomThuoc.ValueMember = "MaNhomThuoc";            
        }

        private void ckbTatCaThuoc_CheckedChanged(object sender, EventArgs e)
        {
            bool chonTatCa = ckbTatCaThuoc.Checked;
            cboNhomThuoc.Enabled = !chonTatCa;
            txtThuocCanTim.Enabled = !chonTatCa;

            if (chonTatCa)
            {
                cboNhomThuoc.SelectedIndex = -1;
                txtThuocCanTim.Text = String.Empty;
            }
        }

        private void btTraCuu_Click(object sender, EventArgs e)
        {
            DocDuLieuCanTraCuu();
            HienThiDuLieuTimDuoc();
        }

        private void DocDuLieuCanTraCuu()
        {
            bool tatCaThuoc = false;
            int maNhomThuoc = 0;
            string tenThuoc = String.Empty;
            dtTraCuuThuoc.Clear();

            tatCaThuoc = ckbTatCaThuoc.Checked;
            maNhomThuoc = (cboNhomThuoc.SelectedValue == null)?-1:(int)cboNhomThuoc.SelectedValue;
            tenThuoc = txtThuocCanTim.Text;
            
            bllTraCuuThuoc.TraCuuThuocTonKho(dtTraCuuThuoc, tatCaThuoc, maNhomThuoc, tenThuoc);
        }

        private void HienThiDuLieuTimDuoc()
        {            
            dgvKetQua.DataSource = dtTraCuuThuoc;
        }

        private void FrmThuocTonKho_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            GanDoiTuongDuLieuVaoCacDieuKhien();
            HienThiDuLieu();
        }
    }
}
