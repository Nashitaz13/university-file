using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCHMT.GUI
{
    public partial class LapPhieuBaoHanh : UserControl
    {
        String SelectMaHang;
        String MaPhieu;
        String PhieuXuat;
        String MaMay;

        public LapPhieuBaoHanh()
        {
            InitializeComponent();
            txt_maphieu.ReadOnly = true;
            txt_phieuxuat.ReadOnly = true;
            txt_tenhang.ReadOnly = true;

        }

        private void gridView_phieuxuat_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView_phieuxuat_RowCellClick(sender, null);
        }

        private void gridView_phieuxuat_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            PhieuXuat = gridView_phieuxuat.GetFocusedRowCellDisplayText(colMaPhieuXuat);
            txt_phieuxuat.Text = PhieuXuat;
            SelectMaHang = gridView_phieuxuat.GetFocusedRowCellDisplayText(colMaPhieuXuat);
            cHITIETPHIEUXUATTableAdapter.FillByMa(qLCHDTdataset.CHITIETPHIEUXUAT,SelectMaHang);
        }

        private void gridView_chitiet_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView_chitiet_RowCellClick(sender, null);
        }

        private void gridView_chitiet_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            MaMay = gridView_chitiet.GetFocusedRowCellValue(colMaMatHang).ToString();
            txt_tenhang.Text = gridView_chitiet.GetFocusedRowCellDisplayText(colMaMatHang).ToString();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            if (txt_tenhang.Text.Length == 0)
            {
                MessageBox.Show("Chưa chọn mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_imei.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập mã IMEI/SN.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pHIEUBAOHANHTableAdapter.getCountIMEI(txt_imei.Text) != 0)
            {
                MessageBox.Show("Sản phẩm này đã được lập phiếu bảo hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pHIEUBAOHANHTableAdapter.Insert(MaPhieu, PhieuXuat, MaMay, txt_imei.Text);

            Report.XtraPhieuBaoHanh.MaPhieuBaoHanh = MaPhieu;
            Report.frmBaoCao.Choose = 8;
            Report.Report rp = new Report.Report();
            rp.Show();

            LapPhieuBaoHanh_Load(sender, e);

        }

        private void LapPhieuBaoHanh_Load(object sender, EventArgs e)
        {
            pHIEUXUATTableAdapter.FillByTT(qLCHDTdataset.PHIEUXUAT, "TTTT0002", "TTGH0001");
            mATHANGTableAdapter.Fill(qLCHDTdataset.MATHANG);
            String MaxID = pHIEUBAOHANHTableAdapter.getMax();
            if (MaxID == null) MaPhieu = "BH0001";
            else MaPhieu = QLCHMT.Funtion.Global.IncreateID(MaxID);
            txt_maphieu.Text = MaPhieu;

            txt_phieuxuat.Text = "";
            txt_tenhang.Text = "";
            txt_imei.Text = "";
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            LapPhieuBaoHanh_Load(sender,e);
        }

        bool isChange;
        private void txt_imei_EditValueChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void LapPhieuBaoHanh_Leave(object sender, EventArgs e)
        {
            //if (isChange)
            //{
            //    if (MessageBox.Show("Bạn chưa lưu chỉnh sửa.\nBạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        btn_luu_Click(sender, null);
            //    isChange = false;
            //}
        }
    }
}
