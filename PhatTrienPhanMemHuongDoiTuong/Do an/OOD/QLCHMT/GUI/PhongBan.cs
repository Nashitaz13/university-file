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
    public partial class PhongBan : UserControl
    {
        public PhongBan()
        {
            InitializeComponent();
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            pHONGBANTableAdapter.Fill(qLCHDTdataset.PHONGBAN);
        }

        private void gridView_phongban_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView_phongban.ClearSorting();
            string strMaPhongBanMoi;
            if (gridView_phongban.RowCount == 1)
                strMaPhongBanMoi = "PB0001";
            else
                strMaPhongBanMoi = QLCHMT.Funtion.Global.IncreateID(gridView_phongban.GetRowCellValue(gridView_phongban.RowCount - 2, "MaPhongBan").ToString());
            gridView_phongban.SetRowCellValue(e.RowHandle, "MaPhongBan",strMaPhongBanMoi);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            gridView_phongban.ClearSorting();
            gridView_phongban.AddNewRow();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            pHONGBANBindingSource.EndEdit();
            pHONGBANTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView_phongban_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            MessageBox.Show("deleting");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_phongban.RowCount == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pHONGBANBindingSource.RemoveCurrent();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isChange = false;
            pHONGBANTableAdapter.Fill(qLCHDTdataset.PHONGBAN);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            gridView_phongban.ShowEditor();
        }

        private void gridView_phongban_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //Validate ten nhan vien
            if (gridView_phongban.FocusedColumn.FieldName == "TenPhongBan")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Tên phòng ban không được để trống";
                }
                else
                {
                    //Valide ki tu dac biet
                    string tenPhongBan = e.Value as String;
                    foreach (Char c in tenPhongBan)
                    {
                        if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên phòng ban không được có số hoặc kí tự đặc biệt";
                        }
                    }

                    //validate da ton tai
                    for (int i = 0; i < gridView_phongban.RowCount-1; i++)
                    {
                        string str = gridView_phongban.GetDataRow(i)[1].ToString().Trim().ToLower();
                        if (e.Value.ToString().Trim().ToLower() == str)
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên phòng ban đã tồn tại";
                        }
                    }

                }
            }
        }

        private void gridView_phongban_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            
        }

        bool isChange;
        private void gridView_phongban_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChange = true;
        }

        private void PhongBan_Leave(object sender, EventArgs e)
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
