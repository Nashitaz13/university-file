using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using DateCalculator;

namespace QLCHMT.GUI
{
    public partial class TiepNhanBaoHanh : UserControl
    {
        String MaPhieuTiepNhanBaoHanh;
        String MaPhieuBaoHanh;
        DateTime timeStart;
        DateTime timeNow;
        int ThoiGianBaoHanh;
        public TiepNhanBaoHanh()
        {
            InitializeComponent();
            txt_imei.ReadOnly = true;
            //txt_khachhang.ReadOnly = true;
            txt_maphieu.ReadOnly = true;
            txt_tenhang.ReadOnly = true;

            iNPHIEUBAOHANHTableAdapter.Fill(qLCHDTdataset.INPHIEUBAOHANH);
        }

        private void gridView_baohanh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView_baohanh_RowCellClick(sender, null);
        }

        private void gridView_baohanh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            MaPhieuBaoHanh = gridView_baohanh.GetFocusedRowCellValue(colMaPhieuBaoHanh).ToString();
            txt_khachhang.Text = gridView_baohanh.GetFocusedRowCellValue(colTenKhachHang).ToString();
            txt_tenhang.Text = gridView_baohanh.GetFocusedRowCellValue(colTenMatHang).ToString();
            txt_imei.Text = gridView_baohanh.GetFocusedRowCellValue(colMaMay).ToString();
            txt_sdt.Text = gridView_baohanh.GetFocusedRowCellValue(colSDTKhachHang).ToString();
            timeStart = (DateTime)gridView_baohanh.GetFocusedRowCellValue(colNgayHoaDon);
            ThoiGianBaoHanh = (int)gridView_baohanh.GetFocusedRowCellValue(colThoiGianBaoHanh);
            if (!ConBaoHanh())
                MessageBox.Show("Sản phẩm đã hết hạn bảo hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Kiem tra het han bao hanh
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_tenhang.Text.Length == 0)
            {
                MessageBox.Show("Chưa chọn phiếu bảo hành nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (memoEdit.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập tình trạng sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ConBaoHanh())
            {
                MessageBox.Show("Sản phẩm đã hết hạn bảo hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_sdt.Text.Length > 11 || txt_sdt.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải từ 10 đến 11 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pHIEUTIEPNHANBAOHANHTableAdapter.Insert(MaPhieuBaoHanh, memoEdit.Text, "", "TTTH0001",txt_khachhang.Text,txt_sdt.Text,MaPhieuTiepNhanBaoHanh,"TTSC0001");

            Report.XtraInphieuTiepNhanBaoHanh.MaPhieuTiepNhanBaoHanh = MaPhieuTiepNhanBaoHanh;
            Report.frmBaoCao.Choose = 9;
            Report.Report rp = new Report.Report();
            rp.Show();

            TiepNhanBaoHanh_Load(sender, e);

        }

        private void TiepNhanBaoHanh_Load(object sender, EventArgs e)
        {
            if (pHIEUTIEPNHANBAOHANHTableAdapter.getMax() == null)
                MaPhieuTiepNhanBaoHanh = "NBH0001";
            else 
                MaPhieuTiepNhanBaoHanh= QLCHMT.Funtion.Global.IncreateID(pHIEUTIEPNHANBAOHANHTableAdapter.getMax());

            txt_maphieu.Text = MaPhieuTiepNhanBaoHanh;
            txt_khachhang.Text = "";
            txt_tenhang.Text = "";
            txt_imei.Text = "";
            txt_sdt.Text = "";
            memoEdit.Text = "";
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            TiepNhanBaoHanh_Load(sender, e);
        }
        private bool ConBaoHanh()
        {
            TimeSpan diff;
            timeNow = DateTime.Now;
            diff = timeNow.Subtract(timeStart);
            if (diff.Days / 30 <= ThoiGianBaoHanh)
                return true;
            else return false;
        }

        private void txt_khachhang_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
             {
                 MessageBox.Show("Tên khách hàng không được có số hoặc kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 e.Handled = true;
             }
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
             {
                 MessageBox.Show("Số điện thoại không được có chữ hoặc kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 e.Handled = true;
             }             
        }
        
    }
}
