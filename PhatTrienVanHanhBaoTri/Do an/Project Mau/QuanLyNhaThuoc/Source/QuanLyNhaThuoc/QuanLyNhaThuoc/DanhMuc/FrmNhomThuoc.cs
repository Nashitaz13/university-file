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
    public partial class FrmNhomThuoc : Form
    {
        #region Object Initialization

        BllNhomThuoc bllNhomThuoc;
        DataTable dt;

        #endregion Object Initialization

        #region Constructors

        public FrmNhomThuoc()
        {
            InitializeComponent();
            bllNhomThuoc = new BllNhomThuoc();
            dt = new DataTable();
            DinhDangHienThiNut(false);
        }
        
        #endregion Constructors

        #region Methods

        private void DocDuLieu()
        {
            dt = bllNhomThuoc.DocDanhMucNhomThuoc();
        }

        private void HienThiDuLieu()
        {
            dgvNhomThuoc.DataSource = dt;
        }

        private void DinhDangHienThiNut(bool duocPhepSua)
        {
            btSua.Enabled = !duocPhepSua;
            btLuu.Enabled = duocPhepSua;
            btKhongLuu.Enabled = duocPhepSua;
            btThoat.Enabled = true;
        }

        #endregion Methods


        #region Events

        private void FrmNhomThuoc_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiDuLieu();
            CommonFunction.DinhDangThaoTacLuoi(dgvNhomThuoc, false);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            CommonFunction.DinhDangThaoTacLuoi(dgvNhomThuoc, true);
            DinhDangHienThiNut(true);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            bllNhomThuoc.LuuDanhMucNhomThuoc(dt);
            CommonFunction.DinhDangThaoTacLuoi(dgvNhomThuoc, false);
            DinhDangHienThiNut(false);
        }

        private void btKhongLuu_Click(object sender, EventArgs e)
        {
            dt.RejectChanges();
            CommonFunction.DinhDangThaoTacLuoi(dgvNhomThuoc, false);
            DinhDangHienThiNut(false);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Events
    }
}
