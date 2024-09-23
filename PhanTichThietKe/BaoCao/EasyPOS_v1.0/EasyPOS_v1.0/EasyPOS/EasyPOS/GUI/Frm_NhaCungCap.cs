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
    public partial class Frm_Nha_Cung_Cap : Form
    {
        private NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        public Frm_Nha_Cung_Cap()
        {
            InitializeComponent();
        }

        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<NHACUNGCAP>(_nhaCungCapBLL.LayDanhSachNhaCungCap());
            gridControl1.DataSource = dt;
            btn_Luu_Lai.Enabled = false;
            _listUpdate.Clear();
        }

        private void Frm_Nha_Cung_Cap_Load(object sender, EventArgs e)
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
                int _ID_NhaCungCap = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "MaNhaCungCap").ToString());
                _nhaCungCapBLL.XoaNhaCungCap(_ID_NhaCungCap);
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
                NHACUNGCAP _nhaCungCap = new NHACUNGCAP();
                _nhaCungCap.MaNhaCungCap = int.Parse(gridView1.GetRowCellValue(id, "MaNhaCungCap").ToString());
                _nhaCungCap.TenNhaCungCap = gridView1.GetRowCellValue(id, "TenNhaCungCap").ToString();
                _nhaCungCap.DiaChi = gridView1.GetRowCellValue(id, "DiaChi").ToString();
                _nhaCungCap.SDT = gridView1.GetRowCellValue(id, "SDT").ToString();
                _nhaCungCap.SoTienHangCuaHangNo = int.Parse(gridView1.GetRowCellValue(id, "SoTienHangCuaHangNo").ToString());
                if (!_nhaCungCapBLL.KiemTraTenNhaCungCapTonTai(_nhaCungCap.TenNhaCungCap, _nhaCungCap.MaNhaCungCap))
                {
                    _nhaCungCapBLL.CapNhatNhaCungCap(_nhaCungCap);
                    isUpdate = true;
                }
                else
                {
                    if (error == "")
                    {
                        error += _nhaCungCap.TenNhaCungCap;
                    }
                    else
                    {
                        error += " | " + _nhaCungCap.MaNhaCungCap;
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
                string _tenNhaCungCap = "";
                string _diaChi = "";
                string _sdt = "";
                string _sotienhang = "";
                if (gridView1.RowCount > 0)
                {
                    _tenNhaCungCap = gridView1.GetRowCellValue(gridView1.RowCount - 1, "TenNhaCungCap").ToString();
                    _diaChi = gridView1.GetRowCellValue(gridView1.RowCount - 1, "DiaChi").ToString();
                    _sdt = gridView1.GetRowCellValue(gridView1.RowCount - 1, "SDT").ToString();
                    _sotienhang = gridView1.GetRowCellValue(gridView1.RowCount - 1, "SoTienHangCuaHangNo").ToString();
                }
                if (_nhaCungCapBLL.KiemTraTenNhaCungCapTonTai(_tenNhaCungCap) == false)
                {
                    _nhaCungCapBLL.ThemNhaCungCapMoi(_tenNhaCungCap, _diaChi, _sdt);
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
            Util.PreviewReport(gridControl1, "NHÀ CUNG CẤP", this.Controls);
        }
    }
}
