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
    public partial class LapPhieuXuat : UserControl
    {
        String MaNhanVien;
        String MaPhieuXuat;
        public LapPhieuXuat()
        {
            InitializeComponent();
            mATHANGTableAdapter.Fill(qLCHDTdataset.MATHANG);
            lOAIHANGTableAdapter.Fill(qLCHDTdataset.LOAIHANG);
            nHASANXUATTableAdapter.Fill(qLCHDTdataset.NHASANXUAT);
            //date_dt.Properties.Mask.EditMask = "MM/dd/yyyy";
            txt_maphieuxuat.ReadOnly = true;
            txt_nhanvien.ReadOnly = true;
            date_dt.ReadOnly = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            String MaHang = gridView_mathang.GetFocusedRowCellDisplayText(colMaMatHang);
            DataRow[] rows = qLCHDTdataset.CHITIETPHIEUXUAT.Select("MaMatHang='" + MaHang + "'");
            if (rows.Length != 0)
            {
                MessageBox.Show("Sản phẩm đã có trong danh sách");
                return;
            }
            DataRow dr = qLCHDTdataset.CHITIETPHIEUXUAT.NewRow();
            dr[0] = MaPhieuXuat;
            dr[1] = MaHang;
            dr[2] = mATHANGTableAdapter.getGia(MaHang);
            dr[3] = 1;
            qLCHDTdataset.CHITIETPHIEUXUAT.Rows.Add(dr);
        }

        private void LapPhieuXuat_Load(object sender, EventArgs e)
        {
            date_dt.Text = System.DateTime.Now.ToString();
            if (pHIEUXUATTableAdapter.getMax()==null)
                MaPhieuXuat = "PX0001";
            else MaPhieuXuat = QLCHMT.Funtion.Global.IncreateID(pHIEUXUATTableAdapter.getMax());
            txt_maphieuxuat.Text = MaPhieuXuat;

            MaNhanVien = main.MaNhanVien;
            txt_nhanvien.Text = MaNhanVien;

            txt_khachhang.Text = "";
            txt_sdtkh.Text = "";

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            double TongTien = 0;
            if (gridView_chitiet.RowCount == 0)
            {
                MessageBox.Show("Chưa chọn sản phẩm vào danh sách");
                return;
            }
            //if (txt_khachhang.Text == "")
            //{
            //    MessageBox.Show("Tên khách hàng không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (txt_sdtkh.Text.Length > 11 || txt_sdtkh.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải từ 10 đến 11 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            pHIEUXUATTableAdapter.InsertQuery(MaPhieuXuat, MaNhanVien, date_dt.DateTime, txt_khachhang.Text, txt_sdtkh.Text, 0);

            for (int i = 0; i < gridView_chitiet.RowCount; i++)
            {
                double dDonGia = double.Parse(gridView_chitiet.GetDataRow(i)[2].ToString());
                int iSoLuong = Int16.Parse(gridView_chitiet.GetDataRow(i)[3].ToString());
                string strMaHang=gridView_chitiet.GetDataRow(i)[1].ToString();
                TongTien+=dDonGia*iSoLuong;
                cHITIETPHIEUXUATTableAdapter.Insert(MaPhieuXuat, strMaHang, dDonGia, iSoLuong);
                mATHANGTableAdapter.UpdateQuerySoLuongGiam(iSoLuong, strMaHang);
            }
            pHIEUXUATTableAdapter.UpdateQueryTongTien(TongTien, MaPhieuXuat);
            //MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            while (gridView_chitiet.RowCount != 0)
            {
                gridView_chitiet.DeleteRow(0);
            }

            Report.XtraInPhieuXuat.MaPhieuXuat = MaPhieuXuat;
            Report.frmBaoCao.Choose = 6;
            Report.Report rp = new Report.Report();
            rp.Show();

            LapPhieuXuat_Load(sender, e);
        }

        private void gridView_chitiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colSoLuong1)
            {
                gridView_chitiet.SetRowCellValue(e.RowHandle, gridView_chitiet.Columns["ThanhTien"],double.Parse(gridView_chitiet.GetRowCellValue(e.RowHandle,colGia1).ToString())* Int16.Parse(gridView_chitiet.GetRowCellValue(e.RowHandle,colSoLuong1).ToString()));
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_chitiet.RowCount != 0)
                cHITIETPHIEUXUATBindingSource.RemoveCurrent();
        }

        private void gridView_chitiet_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //Validate don gia
            if (gridView_chitiet.FocusedColumn.FieldName == "DonGia")
            {
                if (e.Value.ToString() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "Đơn giá không được để trống";
                }
                else
                {
                    //Validate ki tu dac biet
                    string donGia = e.Value.ToString();
                    foreach (Char c in donGia)
                    {
                        if (!Char.IsNumber(c) && !Char.IsPunctuation(c))
                        {
                            e.Valid = false;
                            e.ErrorText = "Đơn giá không được có chữ hoặc kí tự đặc biệt";
                        }
                        else
                        {
                            //Vaidate don gia phai lon hon 0
                            double temp = Convert.ToDouble(e.Value);
                            if (temp <= 0)
                            {
                                e.Valid = false;
                                e.ErrorText = "Đơn giá phải lớn hơn 0";
                            }
                        }
                    }        
                }
            }

            //Validate so luong
            if (gridView_chitiet.FocusedColumn.FieldName == "SoLuong")
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
                            //Validate so luong phai lon hon 0
                            int temp = Convert.ToInt32(e.Value);
                            if (temp <= 0)
                            {
                                e.Valid = false;
                                e.ErrorText = "Số lượng phải lớn hơn 0";
                            }
                        }
                    }                   
                }
            }
        }

        private void date_dt_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void date_dt_Leave(object sender, EventArgs e)
        {

        }

        private void txt_khachhang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("Tên khách hàng không được có số hoặc kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txt_sdtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Số điện thoại không được có chữ hoặc kí tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }  
        }
    }
}
