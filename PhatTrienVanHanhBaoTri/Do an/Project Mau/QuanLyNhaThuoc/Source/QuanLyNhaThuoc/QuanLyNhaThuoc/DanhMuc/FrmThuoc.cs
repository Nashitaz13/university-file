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
    public partial class FrmThuoc : Form
    {
        BllThuoc bllThuoc;
        BllNhomThuoc bllNhomThuoc;
        DataTable dtThuoc;
        DataTable dtNhomThuoc;

        public FrmThuoc()
        {
            InitializeComponent();
            bllThuoc = new BllThuoc();
            DinhDangHienThiNut(false);
            dtThuoc = new DataTable();
            dtNhomThuoc = new DataTable();
            bllNhomThuoc = new BllNhomThuoc();
        }

        private void DocDuLieu()
        {
            bllThuoc.DocDanhMucThuoc(dtThuoc);
            dtNhomThuoc = bllNhomThuoc.DocDanhMucNhomThuoc();
        }

        private void HienThiDuLieu()
        {
            dgvcMaDonViTinh.DataSource = Constants.DanhMucDonViTinh();
            dgvcMaDonViTinh.DisplayMember = "TenDonViTinh";
            dgvcMaDonViTinh.ValueMember = "MaDonViTinh";
            dgvcMaDonViTinh.DataPropertyName = "MaDonViTinh";

            dgvcMaNhomThuoc.DataSource = dtNhomThuoc;
            dgvcMaNhomThuoc.DisplayMember = "TenNhomThuoc";
            dgvcMaNhomThuoc.ValueMember = "MaNhomThuoc";
            dgvcMaNhomThuoc.DataPropertyName = "MaNhomThuoc";

            dgvThuoc.DataSource = dtThuoc;           
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        private void FrmThuoc_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
            CommonFunction.DinhDangThaoTacLuoi(dgvThuoc, false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvThuoc, true);
            DinhDangHienThiNut(true);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvThuoc, false);
            DinhDangHienThiNut(false);
        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {           
            CommonFunction.DinhDangThaoTacLuoi(dgvThuoc, false);
            DinhDangHienThiNut(false);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
