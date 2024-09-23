using EasyPOS.DAL;
using EasyPOS.BLL;
using EasyPOS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS
{
    public partial class Frm_KhachHang : Form
    {
        private KhachHangBLL _khachHangBLL = new KhachHangBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        public Frm_KhachHang()
        {
            InitializeComponent();
        }

        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<KHACHHANG>(_khachHangBLL.LayDanhSachKhachHang());
            gridControl1.DataSource = dt;
            btn_Luu_Lai.Enabled = false;
            _listUpdate.Clear();
        }

        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {
            LoadDataSource();
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int _ID_KhachHang = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "MaKhachHang").ToString());
                _khachHangBLL.XoaKhachHang(_ID_KhachHang);
            }
            Util.ShowAlert("  Xóa Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void btn_Luu_Lai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string error = "";
            bool isUpdate = false;
            foreach (int id in _listUpdate)
            {
                KHACHHANG _khachHang = new KHACHHANG();
                _khachHang.MaKhachHang = int.Parse(gridView1.GetRowCellValue(id, "MaKhachHang").ToString());
                _khachHang.TenKhachHang = gridView1.GetRowCellValue(id, "TenKhachHang").ToString();
                _khachHang.GioiTinh = gridView1.GetRowCellValue(id, "GioiTinh").ToString();
                _khachHang.DiaChi = gridView1.GetRowCellValue(id, "DiaChi").ToString();
                _khachHang.SDT = gridView1.GetRowCellValue(id, "SDT").ToString();
                if(gridView1.GetRowCellValue(id, "SoTienNo").ToString() !="")
                    _khachHang.SoTienNo = int.Parse(gridView1.GetRowCellValue(id, "SoTienNo").ToString());
                if (!_khachHangBLL.KiemTraTenKhachHangTonTai(_khachHang.TenKhachHang, _khachHang.MaKhachHang))
                {
                    _khachHangBLL.CapNhatKhachHang(_khachHang);
                    isUpdate = true;
                }
                else
                {
                    if (error == "")
                    {
                        error += _khachHang.TenKhachHang;
                    }
                    else
                    {
                        error += " | " + _khachHang.MaKhachHang;
                    }
                }
            }
            if (isUpdate == true)
            {
                if (error.Length == 0)
                {
                    Util.ShowAlert("  Cập dữ liệu thành công.", "Thông báo", this);
                }
                else
                {
                    Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các ID chưa được cập nhật (" + error + "). Lỗi: Tên Đơn Vị đã tồn tại.");
                }
            }
            else
            {
                Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Tên đơn vị đã tồn tại.");
            }
            LoadDataSource();
        }

        private void btn_Lam_Moi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btn_Xoa.Enabled = false;

            if (gridView1.SelectedRowsCount > 0)
            {
                btn_Xoa.Enabled = true;
            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btn_Luu_Lai.Enabled = true;
            _listUpdate.Add(e.RowHandle);

            // Thêm mới
            if (e.RowHandle < 0)
            {
                string _tenKhachHang = "";
                string _gioiTinh = "";
                string _diaChi = "";
                string _sdt = "";
                string _sotienno = "";
                if (gridView1.RowCount > 0)
                {
                    _tenKhachHang = gridView1.GetRowCellValue(gridView1.RowCount - 1, "TenKhachHang").ToString();
                    _gioiTinh = gridView1.GetRowCellValue(gridView1.RowCount - 1, "GioiTinh").ToString();
                    _diaChi = gridView1.GetRowCellValue(gridView1.RowCount - 1, "DiaChi").ToString();
                    _sdt = gridView1.GetRowCellValue(gridView1.RowCount - 1, "SDT").ToString();
                    _sotienno = gridView1.GetRowCellValue(gridView1.RowCount - 1, "SoTienNo").ToString();
                }
                if (_khachHangBLL.KiemTraTenKhachHangTonTai(_tenKhachHang) == false)
                {
                    _khachHangBLL.ThemKhachHangMoi(_tenKhachHang, _gioiTinh, _diaChi, _sdt);
                    Util.ShowAlert("Thêm mới dữ liệu thành công.", "Thông báo", this);
                    LoadDataSource();
                }
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
                btn_Xoa.Enabled = false;  
        }
        private void btn_In_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
            Util.PreviewReport(gridControl1, "KHÁCH HÀNG", this.Controls);
        }
    }
}
