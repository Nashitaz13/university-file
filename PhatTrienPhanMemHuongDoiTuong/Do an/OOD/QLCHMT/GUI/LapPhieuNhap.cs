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
    public partial class LapPhieuNhap : UserControl
    {
        String MaNhanVien;
        String MaPhieuNhap;

        public LapPhieuNhap()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            String MaHang = gridView_mathang.GetFocusedRowCellDisplayText(colMaMatHang1);
            DataRow[] rows = qLCHDTdataset.CHITIETPHIEUNHAP.Select("MaMatHang='" + MaHang + "'");
            if(rows.Length!=0)
            {
                MessageBox.Show("Sản phẩm đã có trong danh sách");
                return;
            }
            DataRow dr = qLCHDTdataset.CHITIETPHIEUNHAP.NewRow();
            dr[0] = MaPhieuNhap;
            dr[1] = MaHang;
            dr[2] = 0;
            dr[3] = 1;
            qLCHDTdataset.CHITIETPHIEUNHAP.Rows.Add(dr);
        }

        private void LapPhieuNhap_Load(object sender, EventArgs e)
        {
            mATHANGTableAdapter.Fill(qLCHDTdataset.MATHANG);
            lOAIHANGTableAdapter.Fill(qLCHDTdataset.LOAIHANG);
            nHASANXUATTableAdapter.Fill(qLCHDTdataset.NHASANXUAT);
            //date_dt.Properties.Mask.EditMask = "MM/dd/yyyy";
            txt_maphieunhap.ReadOnly = true;
            txt_nhanvien.ReadOnly = true;
            date_dt.ReadOnly = true;

            date_dt.Text = System.DateTime.Now.ToString();
            String strMaxMa = pHIEUNHAPTableAdapter.getMax();
            if (strMaxMa != null)
                MaPhieuNhap = QLCHMT.Funtion.Global.IncreateID(strMaxMa);
            else MaPhieuNhap = "PN0001";
            txt_maphieunhap.Text = MaPhieuNhap;

            MaNhanVien = main.MaNhanVien;
            txt_nhanvien.Text = MaNhanVien;

            txt_ncc.Text = "";
            memoEdit.Text = "";

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (gridView_chitiet.RowCount != 0)
                cHITIETPHIEUNHAPBindingSource.RemoveCurrent();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            double TongTien = 0;
            if (gridView_chitiet.RowCount == 0)
            {
                MessageBox.Show("Chưa chọn sản phẩm vào danh sách");
                return;
            }

            pHIEUNHAPTableAdapter.Insert(MaPhieuNhap, MaNhanVien, date_dt.DateTime, txt_ncc.Text, memoEdit.Text, 0);

            for (int i = 0; i < gridView_chitiet.RowCount; i++)
            {
                double dDonGia = Double.Parse(gridView_chitiet.GetDataRow(i)[2].ToString());
                int iSoLuong = Int16.Parse(gridView_chitiet.GetDataRow(i)[3].ToString());
                string strMaHang = gridView_chitiet.GetDataRow(i)[1].ToString();
                TongTien += dDonGia * iSoLuong;
                cHITIETPHIEUNHAPTableAdapter.Insert(gridView_chitiet.GetDataRow(i)[0].ToString(), strMaHang, dDonGia, iSoLuong);
                mATHANGTableAdapter.UpdateQuerySoLuongThem(iSoLuong, strMaHang);
            }
            pHIEUNHAPTableAdapter.UpdateQueryTongTien(TongTien, MaPhieuNhap);

            //MessageBox.Show("Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            while (gridView_chitiet.RowCount != 0)
            {
                gridView_chitiet.DeleteRow(0);
            }

            Report.XtraInPhieuNhap.MaPhieuNhap = MaPhieuNhap;
            Report.frmBaoCao.Choose = 5;
            Report.Report rp = new Report.Report();
            rp.Show();

            LapPhieuNhap_Load(sender, e);

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

        private void gridView_chitiet_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
           
        }

        private void date_dt_EditValueChanged(object sender, EventArgs e)
        {
            if((DateTime.Parse(date_dt.Text)) > DateTime.Now)
                MessageBox.Show("Ngày lập hóa đơn không được vượt quá thời gian hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void date_dt_Leave(object sender, EventArgs e)
        {
            date_dt.Text = System.DateTime.Now.ToString();
        }

        private void gridView_chitiet_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            ////Show the message with the error text specified 
            //MessageBox.Show(e.ErrorText);
        }
    }
}
