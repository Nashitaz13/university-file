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
using DevExpress.XtraGrid.Views.Grid;

namespace EasyPOS
{
    public partial class Frm_XuatHang : Form
    {
        private XuatHangBLL _phieuxuatBLL = new XuatHangBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        private bool testupdate = false;
        private NguoiDungBLL ngDungBLL = new NguoiDungBLL();
        DataTable dt = new DataTable();
        DataTable dt_ctpx = new DataTable();
        public Frm_XuatHang()
        {
            InitializeComponent();
        }
        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<PHIEUGIAOHANG>(_phieuxuatBLL.LayDanhSachPhieuGiaoHang());
            gridControl_PN.DataSource = dt;
            btn_Luu.Enabled = false;
            btn_XoaPhieuXuat.Enabled = false;
            _listUpdate.Clear();
        }
        private void TaoDT_CTPN()
        {
            dt_ctpx.Columns.Add("MaHangHoa", typeof(int));
            dt_ctpx.Columns.Add("DonGiaNhap", typeof(int));
            dt_ctpx.Columns.Add("SoLuong", typeof(int));
            dt_ctpx.Columns.Add("ThanhTien", typeof(int));
            dt_ctpx.NewRow();
            grid_CTPN.DataSource = dt_ctpx;
        }
        private void LoadDanhSachHangHoa()
        {
            HangHoaBLL h = new HangHoaBLL();
            gridControl1.DataSource = Utils.Util.ConvertToDataTable<HANGHOA>(h.LayDanhSachHangHoa());
        }
        private void LoadKhachHang()
        {
     //       KhachHangBLL _khachhangBLL = new KhachHangBLL();
     //       lkup_KhachHang = _khachhangBLL.LayDanhSachKhachHang();
    //        lkup_KhachHang.Properties.ValueMember = "MaNhaCungCap";
   //         lkup_KhachHang.Properties.DisplayMember = "TenNhaCungCap";
        }

        private void LoadHangHoa()
        {
            HangHoaBLL _hanghoaBLL = new HangHoaBLL();
            lkup_HangHoa2.DataSource = lkup_HangHoa.DataSource = _hanghoaBLL.LayDanhSachHangHoa();
            lkup_HangHoa2.ValueMember = lkup_HangHoa.ValueMember = "MaHangHoa";
            lkup_HangHoa2.DisplayMember = lkup_HangHoa.DisplayMember = "TenHangHoa";
        }
        private void Frm_XuatHang_Load(object sender, EventArgs e)
        {
            TaoDT_CTPN();
            LoadHangHoa();
            LoadKhachHang();
            LoadDataSource();
            LoadDanhSachHangHoa();
            gridView_CTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        private void gridView_PN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (btn_Luu.Enabled == true)
            {
                if (Notification.Answers("Bạn có dữ liệu chưa lưu?") == DialogResult.Cancel)
                {
                }
                else
                {
                    try
                    {
                        _phieuxuatBLL.CapNhatPhieuGiaoHang(LayDuLieuPhieuXuat());
                        foreach (int id in _listUpdate)
                        {
                            _phieuxuatBLL.CapNhatCTPhieuGiaoHang(LayDuLieuCTPhieuXuat(id), txt_MaPhieuXuat.Text, id);

                        }
                        Util.ShowAlert("  Cập dữ liệu thành công.", "Thông báo", this);
                    }
                    catch (Exception)
                    {
                        Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu.");
                    }
                    LoadDataSource();
                }
            }
            btn_XoaPhieuXuat.Enabled = true;
            testupdate = false;
            PHIEUGIAOHANG p = new PHIEUGIAOHANG();
            p = _phieuxuatBLL.LayPhieuGiaoHang(gridView_PN.GetFocusedRowCellValue("MaPhieuGiaoHang").ToString());
            txt_MaPhieuXuat.Text = p.MaPhieuGiaoHang.ToString();
       //     lkup_KhachHang.EditValue = p.MaKhachHang;
            dt_NgayXuatHang.EditValue = p.NgayGiao;
            txt_NhanVien.Text = ngDungBLL.LayNguoiDung(p.MaNguoiDung);

            grid_CTPN.DataSource = Utils.Util.ConvertToDataTable<CTPHIEUGIAOHANG>(_phieuxuatBLL.LayChiTietPhieuGiaoHang(gridView_PN.GetFocusedRowCellValue("MaPhieuXuat").ToString()));
            testupdate = true;
        }

        private void txt_TongTienHang_TextChanged(object sender, EventArgs e)
        {
            txt_VAT.Text = (int.Parse(spinEdit_VAT.Text) * (int.Parse(txt_TongTienHang.Text) / 100)).ToString();
            txt_TongThanhToan.Text = (int.Parse(txt_TongTienHang.Text) + int.Parse(txt_VAT.Text)).ToString();
        }

        private void txt_VAT_TextChanged(object sender, EventArgs e)
        {
            txt_TongThanhToan.Text = (int.Parse(txt_TongTienHang.Text) + int.Parse(txt_VAT.Text)).ToString();
        }

        private PHIEUGIAOHANG LayDuLieuPhieuXuat()
        {
            PHIEUGIAOHANG p = new PHIEUGIAOHANG();
            if (txt_MaPhieuXuat.Text != "") p.MaPhieuGiaoHang = txt_MaPhieuXuat.Text;           
            p.MaNguoiDung = ngDungBLL.LayMaNguoiDung(txt_NhanVien.EditValue.ToString());
           // p.MaDonDatHangKH =
            p.NgayGiao = dt_NgayXuatHang.DateTime;
            p.TongTien = int.Parse(txt_TongThanhToan.Text);
            return p;
        }
        private CTPHIEUGIAOHANG LayDuLieuCTPhieuXuat(int i)
        {
            CTPHIEUGIAOHANG ct = new CTPHIEUGIAOHANG();
            ct.MaPhieuGiaoHang = txt_MaPhieuXuat.Text;
            ct.MaHangHoa = int.Parse(gridView_CTPN.GetRowCellValue(i, "MaHangHoa").ToString());
            ct.DonGia = int.Parse(gridView_CTPN.GetRowCellValue(i, "DonGia").ToString());
            ct.SoLuongGiao = int.Parse(gridView_CTPN.GetRowCellValue(i, "SoLuongGiao").ToString());
            ct.SoLuongChuaGiao = int.Parse(gridView_CTPN.GetRowCellValue(i, "SoLuongChuaGiao").ToString());
            ct.ThanhTien = int.Parse(gridView_CTPN.GetRowCellValue(i, "ThanhTien").ToString());
            return ct;
        }
        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn thêm dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            _phieuxuatBLL.ThemPhieuGiaoHangMoi(LayDuLieuPhieuXuat());

            for (int i = 0; i < gridView_CTPN.RowCount; i++)
            {
                _phieuxuatBLL.ThemCTPhieuGiaoHangMoi(LayDuLieuCTPhieuXuat(i));
            }
            Util.ShowAlert("  Thêm Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void gridView_CTPN_RowCountChanged(object sender, EventArgs e)
        {
            int t = 0;
            for (int i = 0; i < gridView_CTPN.RowCount; i++)
            {
                t += int.Parse(gridView_CTPN.GetRowCellValue(i, "ThanhTien").ToString());
            }
            txt_TongTienHang.Text = t.ToString();
        }

        private void gridView_CTPN_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView_CTPN.GetRowCellValue(e.RowHandle, "DonGia").ToString() != "" && gridView_CTPN.GetRowCellValue(e.RowHandle, "SoLuongGiao").ToString() != "")
            {
                if (e.Column.Name == "col_DonGiaNhap" || e.Column.Name == "col_SoLuong")
                {
                    double SoLuong = int.Parse(gridView_CTPN.GetFocusedRowCellValue("SoLuongGiao").ToString());
                    double DonGiaNhap = int.Parse(gridView_CTPN.GetFocusedRowCellValue("DonGia").ToString());
                    double ThanhTien = SoLuong * DonGiaNhap;
                    gridView_CTPN.SetFocusedRowCellValue("ThanhTien", ThanhTien.ToString());
                }
            }
            if (e.Column.Name == "col_ThanhTien" && gridView_CTPN.GetRowCellValue(e.RowHandle, "ThanhTien").ToString() != "")
            {
                int t = 0;
                for (int i = 0; i < gridView_CTPN.RowCount; i++)
                {
                    t += int.Parse(gridView_CTPN.GetRowCellValue(i, "ThanhTien").ToString());
                }
                txt_TongTienHang.Text = t.ToString();
            }
        }

        private void btn_XoaCTPN_Click(object sender, EventArgs e)
        {
            gridView_CTPN.DeleteSelectedRows();
        }


        private void btn_ThemHang_Click(object sender, EventArgs e)
        {
            CTPHIEUGIAOHANG ct = new CTPHIEUGIAOHANG();
            ct = _phieuxuatBLL.LayCTPhieuGiaoHangTheoHangHoa(int.Parse(gridView1.GetFocusedRowCellValue("MaHangHoa").ToString()));
            for (int i = 0; i < gridView_CTPN.RowCount; i++)
            {
                if (int.Parse(gridView_CTPN.GetRowCellValue(i, "MaHangHoa").ToString()) == ct.MaHangHoa)
                {
                    return;
                }
            }
            gridView_CTPN.AddNewRow();
            int rowHandle = gridView_CTPN.GetRowHandle(gridView_CTPN.DataRowCount);
            if (gridView_CTPN.IsNewItemRow(rowHandle))
            {
                gridView_CTPN.SetRowCellValue(rowHandle, "MaHangHoa", ct.MaHangHoa);
                gridView_CTPN.SetRowCellValue(rowHandle, "DonGiaNhap", ct.DonGia);
                gridView_CTPN.SetRowCellValue(rowHandle, "SoLuongGiao", 10);
            }
        }

        private void btn_XoaPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            _phieuxuatBLL.XoaPHIEUGIAOHANG(gridView_PN.GetFocusedRowCellValue("MaPhieuXuat").ToString());
            Util.ShowAlert("  Xóa Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn lưu dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                _phieuxuatBLL.CapNhatPhieuGiaoHang(LayDuLieuPhieuXuat());
                foreach (int id in _listUpdate)
                {
                    _phieuxuatBLL.CapNhatCTPhieuGiaoHang(LayDuLieuCTPhieuXuat(id), txt_MaPhieuXuat.Text, id);

                }
                Util.ShowAlert("  Cập dữ liệu thành công.", "Thông báo", this);
            }
            catch (Exception)
            {
                Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu.");
            }
            LoadDataSource();
        }

        private void gridView_CTPN_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            _listUpdate.Add(e.RowHandle);
            btn_Luu.Enabled = true;
        }

        private void lkup_KhachHang_TextChanged(object sender, EventArgs e)
        {

            if (testupdate == true)
                btn_Luu.Enabled = true;

        }

        private void dt_NgayXuatHang_TextChanged(object sender, EventArgs e)
        {
            if (testupdate == true)
                btn_Luu.Enabled = true;
        }

        private void lkup_NhanVien_TextChanged(object sender, EventArgs e)
        {

            if (testupdate == true)
                btn_Luu.Enabled = true;
        }

        private void btn_MaTuSinh_Click(object sender, EventArgs e)
        {
            txt_MaPhieuXuat.Text = _phieuxuatBLL.XuLyMaPhieuGiaoHang();
        }

        private void spinEdit_VAT_TextChanged(object sender, EventArgs e)
        {
            txt_TongThanhToan.Text = (int.Parse(txt_TongTienHang.Text) + int.Parse(spinEdit_VAT.Text) * int.Parse(txt_TongTienHang.Text) / 100).ToString();
        }
    }
}
