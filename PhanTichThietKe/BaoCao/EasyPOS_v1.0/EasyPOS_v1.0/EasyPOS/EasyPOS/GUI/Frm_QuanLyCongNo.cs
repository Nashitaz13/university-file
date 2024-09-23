using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPOS.BLL;

namespace EasyPOS.GUI
{
    public partial class Frm_QuanLyCongNo : Form
    {
        CongNoBLL congNoBLL = new CongNoBLL();
        KhachHangBLL khachHangBLL = new KhachHangBLL();
        int MaCongNo = -1;

        DataTable dtHinhThucThanhToan = new DataTable();
        public Frm_QuanLyCongNo()
        {
            InitializeComponent();
            dtHinhThucThanhToan.Columns.Add("HinhThucThanhToan", typeof(int));
            dtHinhThucThanhToan.Columns.Add("TenHienThi", typeof(string));
        }

        private void DanhSachCongNo()
        {
            gridControl1.DataSource = new DataTable();
  //          gridControl1.DataSource = congNoBLL.LayDanhSachCongNo();
        }

        private void DanhSachKhachHang()
        {
   //         lkup_KhachHang.DataSource = khachHangBLL.LayDanhSachKhachHang();
            lkup_KhachHang.ValueMember = "MaKhachHang";
            lkup_KhachHang.DisplayMember = "TenKhachHang";
        }
        private void DanhSachLichSuGiaoDich()
        {
            gridControl2.DataSource = new DataTable();
            if (MaCongNo != -1)
            {
   //             gridControl2.DataSource = congNoBLL.LayDanhSachLichSuGiaoDich(MaCongNo);
            }
        }
        private void DanhSachHinhThucThanhToan()
        {
            lkup_HinhThucThanhToan.DataSource = dtHinhThucThanhToan;
            lkup_HinhThucThanhToan.DisplayMember = "TenHienThi";
            lkup_HinhThucThanhToan.ValueMember = "HinhThucThanhToan";
        }
        private void Frm_QuanLyCongNo_Load(object sender, EventArgs e)
        {
            DanhSachCongNo();
            DanhSachKhachHang();
            dt_NgayThanhToan.EditValue = DateTime.Now;
            btn_ThanhTNo.Enabled = false;
            DataRow dr = dtHinhThucThanhToan.NewRow();
            dr["HinhThucThanhToan"] = -1;
            dr["TenHienThi"] = "Ghi Nợ";
            dtHinhThucThanhToan.Rows.Add(dr);
            DataRow dr1 = dtHinhThucThanhToan.NewRow();
            dr1["HinhThucThanhToan"] = 1;
            dr1["TenHienThi"] = "Thanh Toán Nợ";
            dtHinhThucThanhToan.Rows.Add(dr1);
            DanhSachHinhThucThanhToan();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            DanhSachCongNo();
            DanhSachKhachHang();
           
            txt_CongNo.Text = "";
            txt_KhachHang.Text = "";
            txt_SoTienNo.Text = "";
            txt_SoTienThanhToan.Text = "";
            btn_ThanhTNo.Enabled = false;
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.RowHandle >= 0)
            {
                btn_ThanhTNo.Enabled = true;
                MaCongNo = int.Parse(gridView1.GetRowCellValue(e.RowHandle, "MaCongNo").ToString());
    //            txt_KhachHang.Text = khachHangBLL.LayKhachHang(int.Parse(gridView1.GetRowCellValue(e.RowHandle, "MaKhachHang").ToString()));
                txt_CongNo.Text = txt_SoTienNo.Text = gridView1.GetRowCellValue(e.RowHandle, "SoTienNo").ToString();
                DanhSachLichSuGiaoDich();
            }
            else
            {
                btn_ThanhTNo.Enabled = false;
            }
        }

        private void txt_SoTienThanhToan_EditValueChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txt_CongNo.Text))
            {
                float result = float.Parse(txt_CongNo.Text) - float.Parse(txt_SoTienThanhToan.Text);
                txt_SoTienNo.Text = result.ToString();
            }
        }

        private void btn_ThanhTNo_Click(object sender, EventArgs e)
        {
            // Hình thức
            // 1: Thanh Toán Nợ
            // 2: Ghi Nợ
            if (MaCongNo != -1)
            {
   //             congNoBLL.CapNhatCongNo(MaCongNo, float.Parse(txt_SoTienNo.Text));
   //             congNoBLL.ThemGiaoDich(MaCongNo, 1, dt_NgayThanhToan.DateTime, float.Parse(txt_SoTienThanhToan.Text), float.Parse(txt_SoTienNo.Text));
                Utils.Util.ShowAlert("Thanh toán nợ cho khách hàng " + txt_KhachHang.Text + " thành công", "THÔNG BÁO", this);
            }
            LamMoi();
        }
    }
}
