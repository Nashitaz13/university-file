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
    public partial class ThanhToan : UserControl
    {
        String MaNhanVien = main.MaNhanVien;
        public ThanhToan()
        {
            InitializeComponent();
            pHIEUXUATTableAdapter.FillByTTTT(qLCHDTdataset.PHIEUXUAT, "TTTT0001"); 
            nHANVIENTableAdapter.Fill(qLCHDTdataset.NHANVIEN);
            tRANGTHAITHANHTOANTableAdapter.Fill(qLCHDTdataset.TRANGTHAITHANHTOAN);
        
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            pHIEUXUATBindingSource.EndEdit();
            pHIEUXUATTableAdapter.Update(qLCHDTdataset);

            MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pHIEUXUATTableAdapter.FillByTTTT(qLCHDTdataset.PHIEUXUAT, "TTTT0001"); 
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            pHIEUXUATTableAdapter.Fill(qLCHDTdataset.PHIEUXUAT);
        }
        private void gridView_thanhtoan_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colTrangThaiThanhToan)
            {
                gridView_thanhtoan.SetRowCellValue(e.RowHandle, gridView_thanhtoan.Columns["NhanVienThanhToan"], MaNhanVien);
            }
        }
    }
}
