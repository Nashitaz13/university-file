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
    public partial class Frm_Don_Vi : Form
    {
        private DonViBLL _donViBLL = new DonViBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        public Frm_Don_Vi()
        {
            InitializeComponent();
        }

        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<DONVI>(_donViBLL.LayDanhSachDonVi());
            gridControl1.DataSource = dt;
            btn_Luu_Lai.Enabled = false;
            _listUpdate.Clear();
        }
        private void Frm_Don_Vi_Load(object sender, EventArgs e)
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
                int _ID_Don_Vi = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "MaDonVi").ToString());
                _donViBLL.XoaDonVi(_ID_Don_Vi);
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
                DONVI _donVi = new DONVI();
                _donVi.MaDonVi = int.Parse(gridView1.GetRowCellValue(id, "MaDonVi").ToString());
                _donVi.TenDonVi = gridView1.GetRowCellValue(id, "TenDonVi").ToString();
                if (!_donViBLL.KiemTraTenDonViTonTai(_donVi.TenDonVi, _donVi.MaDonVi))
                {
                    _donViBLL.CapNhatDonVi(_donVi);
                    isUpdate = true;
                }
                else
                {
                    if (error == "")
                    {
                        error += _donVi.TenDonVi;
                    }
                    else
                    {
                        error += " | " + _donVi.MaDonVi;
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

        // Tải lại dữ liệu lên gridView
        private void btn_Lam_Moi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataSource();
        }

        // Nếu có chọn dòng để xóa thì bật button xóa, còn nếu không hide nó đi
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
                string t = "";
                if (gridView1.RowCount > 0)
                {
                    t = gridView1.GetRowCellValue(gridView1.RowCount - 1, "TenDonVi").ToString();
                }
                if (_donViBLL.KiemTraTenDonViTonTai(t) == false)
                {
                    _donViBLL.ThemDonViMoi(t);
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
            Util.PreviewReport(gridControl1, "DANH MỤC ĐƠN VỊ", this.Controls);
        }
    }
}
