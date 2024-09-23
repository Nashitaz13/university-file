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
    public partial class NhaSanXuat : UserControl
    {
        public NhaSanXuat()
        {
            InitializeComponent();
        }

        private void NhaSanXuat_Load(object sender, EventArgs e)
        {
            nHASANXUATTableAdapter.Fill(qLCHDTdataset.NHASANXUAT);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            gridView_nhasanxuat.ClearSorting();
            gridView_nhasanxuat.AddNewRow();
        }

        private void gridView_nhasanxuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView_nhasanxuat.ClearSorting();
            gridView_nhasanxuat.SetRowCellValue(e.RowHandle, "MaNhaSanXuat", QLCHMT.Funtion.Global.IncreateID(gridView_nhasanxuat.GetRowCellValue(gridView_nhasanxuat.RowCount - 2, "MaNhaSanXuat").ToString()));
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            nHASANXUATBindingSource.RemoveCurrent();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            gridView_nhasanxuat.ShowEditor();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            nHASANXUATBindingSource.EndEdit();
            nHASANXUATTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isChange = false;
            nHASANXUATTableAdapter.Fill(qLCHDTdataset.NHASANXUAT);
        }

        private void gridView_nhasanxuat_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            //if (e.Button.ButtonType == NavigatorButtonType.Remove)
            if (MessageBox.Show("Bạn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.No)
                e.Cancel = true;
        }

        bool isChange;
        private void gridView_nhasanxuat_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChange = true;
        }

        private void NhaSanXuat_Leave(object sender, EventArgs e)
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
