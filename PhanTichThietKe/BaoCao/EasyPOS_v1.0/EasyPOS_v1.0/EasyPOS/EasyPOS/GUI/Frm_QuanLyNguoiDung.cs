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
    public partial class Frm_QuanLyNguoiDung : Form
    {
        private NguoiDungBLL _nguoiDungBLL = new NguoiDungBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        public Frm_QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<NGUOIDUNG>(_nguoiDungBLL.LayDanhSachNguoiDung());
            gridControl1.DataSource = dt;
            btn_Luu_Lai.Enabled = false;
            _listUpdate.Clear();
        }

        private void Frm_QuanLyNguoiDung_Load(object sender, EventArgs e)
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
                int _ID_NguoiDung = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "MaNguoiDung").ToString());
                _nguoiDungBLL.XoaNguoiDung(_ID_NguoiDung);
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
                NGUOIDUNG _nguoiDung = new NGUOIDUNG();
                _nguoiDung.MaNguoiDung = int.Parse(gridView1.GetRowCellValue(id, "MaNguoiDung").ToString());
                _nguoiDung.TenTaiKhoan = gridView1.GetRowCellValue(id, "TenNguoiDung").ToString();
                _nguoiDung.TenNguoiDung = gridView1.GetRowCellValue(id, "TenTaiKhoan").ToString();
                _nguoiDung.QuanTriHeThong = (bool)gridView1.GetRowCellValue(id, "QuanTriHeThong");
                if (!_nguoiDungBLL.KiemTraTenNguoiDungTonTai(_nguoiDung.TenTaiKhoan, _nguoiDung.MaNguoiDung))
                {
                    _nguoiDungBLL.CapNhatNguoiDung(_nguoiDung);
                    isUpdate = true;
                }
                else
                {
                    if (error == "")
                    {
                        error += _nguoiDung.TenTaiKhoan;
                    }
                    else
                    {
                        error += " | " + _nguoiDung.MaNguoiDung;
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
                string _tenNguoiDung = "";
                string _tenTaiKhoan = "";
                string _matKhau = "";
                bool _loaiNguoiDung = true;
                if (gridView1.RowCount > 0)
                {
                    _tenNguoiDung = gridView1.GetRowCellValue(gridView1.RowCount - 1, "TenNguoiDung").ToString();
                    _tenTaiKhoan = gridView1.GetRowCellValue(gridView1.RowCount - 1, "TenTaiKhoan").ToString();
                    _matKhau = gridView1.GetRowCellValue(gridView1.RowCount - 1, "MatKhau").ToString();
                    _loaiNguoiDung = (bool)gridView1.GetRowCellValue(gridView1.RowCount - 1, "QuanTriHeThong");
                }
                if (_nguoiDungBLL.KiemTraTenNguoiDungTonTai(_tenNguoiDung) == false)
                {
                    _nguoiDungBLL.ThemNguoiDungMoi(_tenNguoiDung, _tenTaiKhoan, _matKhau, _loaiNguoiDung);
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
            Util.PreviewReport(gridControl1, "NGƯỜI DÙNG", this.Controls);
        }
    }
}
