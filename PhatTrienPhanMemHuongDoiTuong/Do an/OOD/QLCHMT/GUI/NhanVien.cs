using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Cryptography;

namespace QLCHMT.GUI
{
    public partial class NhanVien : UserControl
    {
        List<String> listNhaVienRemove;
        bool checkEditor = false;

        public NhanVien()
        {
            InitializeComponent();
        }


        private void NhanVien_Load(object sender, EventArgs e)
        {
            nHANVIENTableAdapter.Fill(qLCHDTdataset.NHANVIEN);
            listNhaVienRemove = new List<String>();
            //for (int i = 0; i < gridView_nhanvien.RowCount;i++ )
            //    if (i % 2 != 0)
            //    {
            //        gridView_nhanvien.def
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //    }
            //foreach (DataRow r in gridView_nhanvien)
            //{
            //    if(r.ro)
            //}
            //foreach (DataGridViewRow row in gridView_nhanvien)
            //    if (Convert.ToInt32(row.Cells[7].Value) % 2 == 0)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //    }
        }

        string strMaNhanVienMoi;
        private void gridView_nhanvien_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gridView_nhanvien.SetRowCellValue(e.RowHandle, "MaNhanVien", strMaNhanVienMoi);        
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            gridView_nhanvien.ClearSorting();
            if (gridView_nhanvien.RowCount == 0)
                strMaNhanVienMoi = "NV0001";
            else strMaNhanVienMoi = QLCHMT.Funtion.Global.IncreateID(gridView_nhanvien.GetRowCellValue(gridView_nhanvien.RowCount - 1, "MaNhanVien").ToString());
            gridView_nhanvien.AddNewRow();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_nhanvien.RowCount == 0) {
                MessageBox.Show("Không còn dữ liệu nào trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            listNhaVienRemove.Add(gridView_nhanvien.GetFocusedRowCellDisplayText(colMaNhanVien));
            nHANVIENBindingSource.RemoveCurrent();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            gridView_nhanvien.ShowEditor();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            if (listNhaVienRemove.Count != 0)
                foreach (string str in listNhaVienRemove)
                    cHITIETPHONGBANTableAdapter.DeleteQueryByMaNhanVien(str);
            nHANVIENBindingSource.EndEdit();
            nHANVIENTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);         

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            isChange = false;
            nHANVIENTableAdapter.Fill(qLCHDTdataset.NHANVIEN);
        }

        private void gridView_nhanvien_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void gridView_nhanvien_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {

        }

        int i = 0;
        private void gridView_nhanvien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMatKhau&&i==0)
            {
                i = 1;
                gridView_nhanvien.SetRowCellValue(e.RowHandle, colMatKhau, GetMD5(gridView_nhanvien.GetRowCellValue(e.RowHandle, colMatKhau).ToString()));
                i = 0;
            }

        }

        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }

        private void gridView_nhanvien_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            checkEditor = true;
            //Validate ten nhan vien
            if (gridView_nhanvien.FocusedColumn.FieldName == "TenNhanVien")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Tên nhân viên không được để trống";
                }
                else
                {
                    string tenNhanVien = e.Value as String;
                    foreach (Char c in tenNhanVien)
                    {
                        if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên nhân viên không được có số hoặc kí tự đặc biệt";
                        }
                    }
                }
            }

            //Validate CMND
            if (gridView_nhanvien.FocusedColumn.FieldName == "CMND")
            {

                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Số chứng minh không được để trống";
                }
                else if (e.Value.ToString().Length < 9)
                {
                    e.Valid = false;
                    e.ErrorText = "Số chứng minh tối thiểu 9 chữ số";
                }
                else if (e.Value.ToString().Length >= 9)
                {
                    for (int i = 0; i < gridView_nhanvien.RowCount-1; i++)
                    {
                        string str = gridView_nhanvien.GetDataRow(i)[2].ToString();
                        if (e.Value.ToString() == str)
                        {
                            e.Valid = false;
                            e.ErrorText = "Số chứng minh đã tồn tại";
                        }
                    }
                }
                else
                {
                    string CMND = e.Value.ToString();
                    foreach (Char c in CMND)
                    {
                        if (!Char.IsNumber(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Số chứng minh không được có chữ hoặc kí tự đặc biệt";
                        }
                    }
                }
            }

            //Validate ngay sinh
            if (gridView_nhanvien.FocusedColumn.FieldName == "NgaySinh")
            {
                if (e.Value == null)
                {
                    e.Valid = false;
                    e.ErrorText = "Ngày sinh không được để trống";
                }
                else
                {
                    int namHienTai = DateTime.Now.Year;
                    int namNhanVien = ((System.DateTime)(e.Value)).Year;
                    int tuoi = namHienTai - namNhanVien;
                    if (tuoi < 18)
                    {
                        e.Valid = false;
                        e.ErrorText = "Nhân viên phải trên 18 tuổi";
                    }
                }
            }

            //Validate ten dang nhap
            if (gridView_nhanvien.FocusedColumn.FieldName == "TenDangNhap")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Tên đăng nhập không được để trống";
                }
                else
                {
                    for (int i = 0; i < gridView_nhanvien.RowCount-1; i++)
                    {
                        string str = gridView_nhanvien.GetDataRow(i)[4].ToString();
                        if (e.Value.ToString() == str)
                        {
                            e.Valid = false;
                            e.ErrorText = "Tên đăng nhập đã tồn tại";
                        }
                    }
                }
            }

            //Validate mat khau
            if (gridView_nhanvien.FocusedColumn.FieldName == "MatKhau")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Tên đăng nhập không được để trống";
                }
            }
        }

        private void gridView_nhanvien_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //if (checkEditor)
            //{
            //    if (MessageBox.Show("Bạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            //        btn_luu_Click(sender, null);
            //    else              
            //        btn_huy_Click(sender, null);               
            //    checkEditor = false;
            //}
        }

        private void NhanVien_Leave(object sender, EventArgs e)
        {
            if (isChange)
            {
                if (MessageBox.Show("Bạn chưa lưu chỉnh sửa.\nBạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                isChange = false;
            }
        }

        bool isChange;
        private void gridView_nhanvien_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChange = true;
        }
    }
}
