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
    public partial class FrmNhaCungCap : Form
    {
        BllNhaCungCap bllNhaCungCap;
        DataTable dtNhaCungCap;

        public FrmNhaCungCap()
        {
            InitializeComponent();
            bllNhaCungCap = new BllNhaCungCap();
            dtNhaCungCap = new DataTable();
            ///DinhDangHienThiNut(false);
        }

        private void DocDuLieu()
        {
            bllNhaCungCap.DocDanhSachNhaCungCap(dtNhaCungCap);
        }

        private void HienThiDuLieu()
        {
            dgvNhaCungCap.DataSource = dtNhaCungCap;
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
            CommonFunction.DinhDangThaoTacLuoi(dgvNhaCungCap, false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvNhaCungCap, true);
            DinhDangHienThiNut(true);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvNhaCungCap, false);
            DinhDangHienThiNut(false);
        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvNhaCungCap, false);
            DinhDangHienThiNut(false);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
