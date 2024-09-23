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
    public partial class Quyen : UserControl
    {
        public Quyen()
        {
            InitializeComponent();
            qUYENTableAdapter.Fill(qLCHDTdataset.QUYEN);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            gridView_quyen.ClearSorting();
            gridView_quyen.AddNewRow();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_quyen.RowCount == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            qUYENBindingSource.RemoveCurrent();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            gridView_quyen.ShowEditor();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            qUYENBindingSource.EndEdit();
            qUYENTableAdapter.Update(qLCHDTdataset);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            qUYENTableAdapter.Fill(qLCHDTdataset.QUYEN);
        }

        private void gridView_quyen_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView_quyen.ClearSorting();
            string strMaQuyenMoi;
            if (gridView_quyen.RowCount == 1)
                strMaQuyenMoi = "Q0001";
            else
                strMaQuyenMoi = QLCHMT.Funtion.Global.IncreateID(gridView_quyen.GetRowCellValue(gridView_quyen.RowCount - 2, "MaQuyen").ToString());
            gridView_quyen.SetRowCellValue(e.RowHandle, "MaQuyen", strMaQuyenMoi);
        }
    }
}
