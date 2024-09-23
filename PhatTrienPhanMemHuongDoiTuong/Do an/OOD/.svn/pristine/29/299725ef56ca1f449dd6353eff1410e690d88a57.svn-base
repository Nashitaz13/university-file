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
    public partial class PhanPhongBan : UserControl
    {
        String selectMaNhanVien;
        public PhanPhongBan()
        {
            InitializeComponent();
            nHANVIENTableAdapter.Fill(qLCHDTdataset.NHANVIEN);
            pHONGBANTableAdapter.Fill(qLCHDTdataset.PHONGBAN);
        }

        int f = 0;
        private void gridView_nhanvien_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //MessageBox.Show(e.RowHandle.ToString());
            selectMaNhanVien = gridView_nhanvien.GetFocusedRowCellDisplayText(colMaNhanVien);
            cHITIETPHONGBANTableAdapter.FillByMaNhanVien(qLCHDTdataset.CHITIETPHONGBAN, selectMaNhanVien);
            
            for (int i = 0; i < gridView_phongban.RowCount; i++)
            {
                for (int j = 0; j < qLCHDTdataset.CHITIETPHONGBAN.Count; j++)
                {
                    f = 1;
                    if (qLCHDTdataset.CHITIETPHONGBAN[j][0].ToString().Equals(gridView_phongban.GetRowCellValue(i, "MaPhongBan").ToString())){
                        gridView_phongban.SelectRow(i);
                        f = 0;
                        break;
                    }
                    else gridView_phongban.UnselectRow(i);
                    f = 0;
                }
            }

        }

        int ff = 0;
        private void gridView_phongban_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (f == 0)
                ff = 1;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int[] PhongBanSelect = gridView_phongban.GetSelectedRows();
            if (PhongBanSelect.Length == 0)
            {
                MessageBox.Show("Chưa chọn phòng ban cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cHITIETPHONGBANTableAdapter.QuerySoLuongByNhanVien(selectMaNhanVien) != 0)
                cHITIETPHONGBANTableAdapter.DeleteQueryByMaNhanVien(selectMaNhanVien);
            for (int i = 0; i < PhongBanSelect.Length; i++)
            {
                cHITIETPHONGBANTableAdapter.Insert(gridView_phongban.GetRowCellValue(PhongBanSelect[i], "MaPhongBan").ToString(), selectMaNhanVien);
            }
            f = ff = 0;
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView_nhanvien_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView_nhanvien_RowCellClick(sender, null);
        }

        private void gridView_nhanvien_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (ff == 1)
            {
                if (MessageBox.Show("Bạn có muốn lưu không?", "Bạn chưa lưu?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                ff = 0;
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {

        }

    }
}
