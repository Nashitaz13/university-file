using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EasyPOS.DAL;
using EasyPOS.BLL;
using EasyPOS.Utils;

namespace EasyPOS
{
    public partial class Frm_HangHoa : Form
    {
        private HangHoaBLL _hanghoaBLL = new HangHoaBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        bool testloaddata = false;
        public Frm_HangHoa()
        {
            InitializeComponent();
        }
        private void LoadDataSource()
        {
            testloaddata = true;
            dt = Utils.Util.ConvertToDataTable<HANGHOA>(_hanghoaBLL.LayDanhSachHangHoa());
            gridControl1.DataSource = dt;
            btn_Luu_Lai.Enabled = false;
            _listUpdate.Clear();
            testloaddata = false;
        }

        private void LoadDonVi()
        {
            DonViBLL _donviBLL = new DonViBLL();
            lkup_DonVi.Properties.DataSource = _donviBLL.LayDanhSachDonVi();
            lkup_DonVi.Properties.ValueMember = "MaDonVi";
            lkup_DonVi.Properties.DisplayMember = "TenDonVi";
        }
        private void Frm_HangHoa_Load(object sender, EventArgs e)
        {
            LoadDonVi();
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
                int _ID_HH = int.Parse(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "MaHangHoa").ToString());
                _hanghoaBLL.XoaHangHoa(_ID_HH);
            }
            Util.ShowAlert("  Xóa Thành Công!", "Thông báo", this);
            LoadDataSource();
        }
        private void btn_Luu_Lai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (int id in _listUpdate)
                {
                    HANGHOA _HH = new HANGHOA();                   
                    _HH.MaHangHoa = int.Parse(gridView1.GetRowCellValue(id, "MaHangHoa").ToString());
                    _HH.MaDonVi = int.Parse(gridView1.GetRowCellValue(id, "MaDonVi").ToString());
                    _HH.SoLuongTon = int.Parse(gridView1.GetRowCellValue(id, "SoLuongTon").ToString());
                    _HH.DonGiaNhap = int.Parse(gridView1.GetRowCellValue(id, "DonGiaNhap").ToString());
                    _HH.TenHangHoa = gridView1.GetRowCellValue(id, "TenHangHoa").ToString();
                    _hanghoaBLL.CapNhatHangHoa(_HH);

                }
                Util.ShowAlert("  Cập dữ liệu thành công.", "Thông báo", this);
            }
            catch (Exception)
            {
                Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu.");
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

        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            if (testloaddata) return;
            string error = "";
            bool isUpdate = false;
            foreach (int id in _listUpdate)
            {
                HANGHOA _HH = new HANGHOA();
                _HH.MaHangHoa = int.Parse(gridView1.GetRowCellValue(id, "MaHangHoa").ToString());
                _HH.MaDonVi = int.Parse(gridView1.GetRowCellValue(id, "MaDonVi").ToString());
                _HH.SoLuongTon = int.Parse(gridView1.GetRowCellValue(id, "SoLuongTon").ToString());
                _HH.DonGiaNhap = int.Parse(gridView1.GetRowCellValue(id, "DonGiaNhap").ToString());
                _HH.TenHangHoa = gridView1.GetRowCellValue(id, "TenHangHoa").ToString();
                if (!_hanghoaBLL.KiemTraTenHangHoaTonTai(_HH.TenHangHoa, _HH.MaHangHoa))
                {
                    _hanghoaBLL.CapNhatHangHoa(_HH);
                    isUpdate = true;
                }
                else
                {
                    if (error == "")
                    {
                        error += _HH.TenHangHoa;
                    }
                    else
                    {
                        error += " | " + _HH.MaHangHoa;
                    }
                }
            }
            if (isUpdate == true)
            {
                if (error.Length == 0)
                {
                    Util.ShowAlert("  Thêm dữ liệu thành công.", "Thông báo", this);
                }
                else
                {
                    Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Các ID chưa được cập nhật (" + error + "). Lỗi: Tên hàng hóa đã tồn tại.");
                }
            }
            else
            {
                Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu. Lỗi: Tên hàng hóa đã tồn tại.");
            }
            LoadDataSource();
        }
    }
}
