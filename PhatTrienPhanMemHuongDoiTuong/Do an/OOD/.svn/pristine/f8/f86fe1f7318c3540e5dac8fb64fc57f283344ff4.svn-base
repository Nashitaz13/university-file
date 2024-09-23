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
    public partial class LoaiHang : UserControl
    {
        public LoaiHang()
        {
            InitializeComponent();
        }

        private void LoaiHang_Load(object sender, EventArgs e)
        {
            lOAIHANGTableAdapter.Fill(qLCHDTdataset.LOAIHANG);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            gridView_loaihang.ClearSorting();
            gridView_loaihang.AddNewRow();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_loaihang.RowCount == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lOAIHANGBindingSource.RemoveCurrent();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            gridView_loaihang.ShowEditor();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            lOAIHANGBindingSource.EndEdit();
            lOAIHANGTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isChange = false;
            lOAIHANGTableAdapter.Fill(qLCHDTdataset.LOAIHANG);
        }

        private void gridView_loaihang_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView_loaihang.ClearSorting();
            string strMaLoaiHangMoi;
            if (gridView_loaihang.RowCount == 1)
                strMaLoaiHangMoi = "LH0001";
            else
                strMaLoaiHangMoi = QLCHMT.Funtion.Global.IncreateID(gridView_loaihang.GetRowCellValue(gridView_loaihang.RowCount - 2, "MaLoai").ToString());
            gridView_loaihang.SetRowCellValue(e.RowHandle, "MaLoai", strMaLoaiHangMoi);
        }

        private void gridView_loaihang_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //Validate ten loai hang
            if (gridView_loaihang.FocusedColumn.FieldName == "TenLoai")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Tên loại hàng không được để trống";
                }
                else
                {
                    //Valide ki tu dac biet
                    string tenLoaiHang = e.Value as String;
                    foreach (Char c in tenLoaiHang)
                    {
                        if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên loại hàng không được có số hoặc kí tự đặc biệt";
                        }
                    }

                    //validate da ton tai
                    for (int i = 0; i < gridView_loaihang.RowCount-1; i++)
                    {
                        string str = gridView_loaihang.GetDataRow(i)[1].ToString().Trim().ToLower();
                        if (e.Value.ToString().Trim().ToLower() == str)
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên loại hàng đã tồn tại";
                        }
                    }
                }
            }
        }

        private void gridView_loaihang_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            
        }

        private void LoaiHang_Leave(object sender, EventArgs e)
        {
            if (isChange)
            {
                if (MessageBox.Show("Bạn chưa lưu chỉnh sửa.\nBạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                isChange = false;
            }
        }
        bool isChange;
        private void gridView_loaihang_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChange = true;
        }

       
    }
}
