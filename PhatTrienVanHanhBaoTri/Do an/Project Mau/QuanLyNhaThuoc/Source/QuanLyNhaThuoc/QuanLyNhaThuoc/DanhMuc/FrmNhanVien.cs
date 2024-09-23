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
    public partial class FrmNhanVien : Form
    {
        BllNhanVien bllNhanVien;
        DataTable dtNhanVien;

        public FrmNhanVien()
        {
            InitializeComponent();
            bllNhanVien = new BllNhanVien();
            dtNhanVien = new DataTable();
            ///DinhDangHienThiNut(false);
        }

        private void DocDuLieu()
        {
            dgvcMaChucVu.DataSource = Constants.DanhMucChucVu();
            dgvcMaChucVu.DisplayMember = "TenChucVu";
            dgvcMaChucVu.ValueMember = "MaChucVu";
            dgvcMaChucVu.DataPropertyName = "MaChucVu";

            bllNhanVien.DocDanhSachNhanVien(dtNhanVien);
        }

        private void HienThiDuLieu()
        {
            dgvNhanVien.DataSource = dtNhanVien;
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
            CommonFunction.DinhDangThaoTacLuoi(dgvNhanVien, false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvNhanVien, true);
            DinhDangHienThiNut(true);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {            
            CommonFunction.DinhDangThaoTacLuoi(dgvNhanVien, false);
            DinhDangHienThiNut(false);
        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {
            //dtNhanVien.RejectChanges();
            CommonFunction.DinhDangThaoTacLuoi(dgvNhanVien, false);
            DinhDangHienThiNut(false);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
