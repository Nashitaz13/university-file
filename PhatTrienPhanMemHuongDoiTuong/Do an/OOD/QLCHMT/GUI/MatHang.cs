using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMT.GUI
{
    public partial class MatHang : UserControl
    {
        //bool checkEditor = false;
        public MatHang()
        {
            InitializeComponent();
        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            mATHANGTableAdapter.Fill(qLCHDTdataset.MATHANG);
            lOAIHANGTableAdapter.Fill(qLCHDTdataset.LOAIHANG);
            nHASANXUATTableAdapter.Fill(qLCHDTdataset.NHASANXUAT);

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            gridView_mathang.ClearSorting();
            gridView_mathang.AddNewRow();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_mathang.RowCount == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            mATHANGBindingSource.RemoveCurrent();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            gridView_mathang.ShowEditor();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            mATHANGBindingSource.EndEdit();
            mATHANGTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isChange = false;
            mATHANGTableAdapter.Fill(qLCHDTdataset.MATHANG);
        }

        private void gridView_mathang_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView_mathang.ClearSorting();
            string strMaMatHangMoi;
            if (gridView_mathang.RowCount == 1)
                strMaMatHangMoi = "MH0001";
            else
                strMaMatHangMoi = QLCHMT.Funtion.Global.IncreateID(gridView_mathang.GetRowCellValue(gridView_mathang.RowCount - 2, "MaMatHang").ToString());
            gridView_mathang.SetRowCellValue(e.RowHandle, "MaMatHang", strMaMatHangMoi);
            gridView_mathang.SetRowCellValue(e.RowHandle, "SoLuong", "0");
        }

        private void gridView_mathang_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //checkEditor = true;
            //Validate ten mat hang
            if (gridView_mathang.FocusedColumn.FieldName == "TenMatHang")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Tên mặt hàng không được để trống";
                }
                else
                {
                    for (int i = 0; i < gridView_mathang.RowCount-1; i++)
                    {
                        string str = gridView_mathang.GetDataRow(i)[1].ToString().Trim().ToLower();
                        if (e.Value.ToString().Trim().ToLower() == str)
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên mặt hàng đã tồn tại";
                        }
                    }
                }
            }

            //Validate thoi gian bao hanh
            if (gridView_mathang.FocusedColumn.FieldName == "ThoiGianBaoHanh")
            {
                //Validate ki tu dac biet
                string _TGBH = e.Value.ToString();
                foreach (Char c in _TGBH)
                {
                    if (!Char.IsNumber(c))
                    {
                        e.Valid = false;
                        e.ErrorText = "Thời gian bảo hành không được có chữ hoặc kí tự đặc biệt";
                    }
                    else
                    {
                        //Validate thoi gian bao hanh lon hon hoac bang 0
                        int temp = Convert.ToInt32(e.Value);
                        if (temp < 0)
                        {
                            e.Valid = false;
                            e.ErrorText = "Thời gian bảo hành phải lớn hơn hoặc bằng 0";
                        }
                    }                
                }             
            }

            //Validate gia
            if (gridView_mathang.FocusedColumn.FieldName == "Gia")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Giá mặt hàng không được để trống";
                }
                else
                {
                    //Validate ki tu dac bet
                    string _Gia = e.Value.ToString();
                    foreach (Char c in _Gia)
                    {
                        if (!Char.IsNumber(c) && !Char.IsPunctuation(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Giá mặt hàng không được có chữ hoặc kí tự đặc biệt";
                        }
                        else
                        {
                            //Vaidate gia phai lon hon 0
                            double temp = Convert.ToDouble(e.Value);
                            if (temp <= 0)
                            {
                                e.Valid = false;
                                e.ErrorText = "Giá mặt hàng phải lớn hơn 0";
                            }
                        }
                    }

                }
            }

            //Validate so luong
            if (gridView_mathang.FocusedColumn.FieldName == "SoLuong")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Số lượng không được để trống";
                }
                else
                {
                    //Validate ki tu dac biet
                    string soLuong = e.Value.ToString();
                    foreach (Char c in soLuong)
                    {
                        if (!Char.IsNumber(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Số lượng không được có chữ hoặc kí tự đặc biệt";
                        }
                        else
                        {
                            //Validate so luong phai lon hon hoac bang 0
                            int temp = Convert.ToInt32(e.Value);
                            if (temp < 0)
                            {
                                e.Valid = false;
                                e.ErrorText = "Số lượng phải lớn hơn hoặc bằng 0";
                            }
                        }
                    }                  
                }
            }
        }

        private void gridView_mathang_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

        }

        private void MatHang_Leave(object sender, EventArgs e)
        {
            if (isChange)
            {
                if (MessageBox.Show("Bạn chưa lưu chỉnh sửa.\nBạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                isChange = false;
            }
        }

        bool isChange;
        private void gridView_mathang_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChange = true;
        }

    }
}
