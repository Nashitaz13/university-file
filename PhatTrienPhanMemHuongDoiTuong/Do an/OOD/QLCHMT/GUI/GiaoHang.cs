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
    public partial class GiaoHang : UserControl
    {
        String MaNhanVien = main.MaNhanVien;
        public GiaoHang()
        {
            InitializeComponent();
            pHIEUXUATTableAdapter.FillByTT(qLCHDTdataset.PHIEUXUAT, "TTTT0002","TTGH0001");
            tRANGTHAIGIAOHANGTableAdapter.Fill(qLCHDTdataset.TRANGTHAIGIAOHANG);
            nHANVIENTableAdapter.Fill(qLCHDTdataset.NHANVIEN);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            pHIEUXUATBindingSource.EndEdit();
            pHIEUXUATTableAdapter.Update(qLCHDTdataset);

            MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pHIEUXUATTableAdapter.FillByTT(qLCHDTdataset.PHIEUXUAT, "TTTT0002", "TTGH0001");
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isChange = false;
            pHIEUXUATTableAdapter.FillByTT(qLCHDTdataset.PHIEUXUAT, "TTTT0002", "TTGH0001");
        }
        bool isChange;
        private void gridView_giaohang_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colTrangThaiGiaoHang)
            {
                isChange = true;
                gridView_giaohang.SetRowCellValue(e.RowHandle, gridView_giaohang.Columns["NhanVienTraHang"], MaNhanVien);
            }
        }

        private void GiaoHang_Leave(object sender, EventArgs e)
        {
            if (isChange)
            {
                if (MessageBox.Show("Bạn chưa lưu chỉnh sửa.\nBạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                isChange = false;
            }
        }
    }
}
