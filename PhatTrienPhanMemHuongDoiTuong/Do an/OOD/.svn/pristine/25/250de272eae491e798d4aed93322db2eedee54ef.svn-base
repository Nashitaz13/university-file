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
    public partial class PhanQuyen : UserControl
    {
        String selectMaPhongBan;
        public PhanQuyen()
        {
            InitializeComponent();
            pHONGBANTableAdapter.Fill(qLCHDTdataset.PHONGBAN);
            qUYENTableAdapter.Fill(qLCHDTdataset.QUYEN);
        }

        int f = 0;
        private void gridView_phongban_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            selectMaPhongBan = gridView_phongban.GetFocusedRowCellDisplayText(colMaPhongBan);
            cHITIETQUYENTableAdapter.FillByMaPhongBan(qLCHDTdataset.CHITIETQUYEN, selectMaPhongBan);

            for (int i = 0; i < gridView_quyen.RowCount; i++)
            {
                for (int j = 0; j < qLCHDTdataset.CHITIETQUYEN.Count; j++)
                {
                    f = 1;
                    if (qLCHDTdataset.CHITIETQUYEN[j][0].ToString().Equals(gridView_quyen.GetRowCellValue(i, "MaQuyen").ToString()))
                    {
                        gridView_quyen.SelectRow(i);
                        f = 0;
                        break;
                    }
                    else gridView_quyen.UnselectRow(i);
                    f = 0;
                }
            }
        }

        int ff = 0;
        private void gridView_quyen_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (f == 0)
                ff = 1;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int[] QuyenSelect = gridView_quyen.GetSelectedRows();
            if (QuyenSelect.Length == 0)
            {
                MessageBox.Show("Chưa chọn phòng ban cho nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cHITIETQUYENTableAdapter.ScalarQuerySoLuong(selectMaPhongBan) != 0)
                cHITIETQUYENTableAdapter.DeleteQueryByMaPhongBan(selectMaPhongBan);
            for (int i = 0; i < QuyenSelect.Length; i++)
            {
                cHITIETQUYENTableAdapter.Insert(gridView_quyen.GetRowCellValue(QuyenSelect[i], "MaQuyen").ToString(), selectMaPhongBan);
            }
            f = ff = 0;
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView_phongban_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView_phongban_RowCellClick(sender, null);
        }

        private void gridView_phongban_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            if (ff == 1)
            {
                if (MessageBox.Show("Bạn có muốn lưu không?", "Bạn chưa lưu?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                ff = 0;
            }
        }
    }
}
