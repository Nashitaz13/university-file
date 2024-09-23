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
    public partial class Frm_NhapHang : Form
    {
        private NhapHangBLL _phieunhapBLL = new NhapHangBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        private bool testupdate = false;
        DataTable dt = new DataTable();
        DataTable dt_ctpn = new DataTable();
        public Frm_NhapHang()
        {
            InitializeComponent();
        }
        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<PHIEUNHAP>(_phieunhapBLL.LayDanhSachPhieuNhap());
            gridControl_PN.DataSource = dt;
            btn_LuuPhieuNhap.Enabled = false;
            btn_XoaPhieuXuat.Enabled = false;
            _listUpdate.Clear();
        }
        private void TaoDT_CTPN()
        {
            dt_ctpn.Columns.Add("MaHangHoa", typeof(int));
            dt_ctpn.Columns.Add("DonGiaNhap", typeof(int));
            dt_ctpn.Columns.Add("SoLuongNhap", typeof(int));
            dt_ctpn.Columns.Add("SoLuongChuaNhap", typeof(int));
            dt_ctpn.Columns.Add("ThanhTien", typeof(int));
            dt_ctpn.NewRow();
            grid_CTPN.DataSource = dt_ctpn;
        }
        private void LoadDanhSachHangHoa()
        {
            HangHoaBLL h = new HangHoaBLL();
            gridControl1.DataSource = Utils.Util.ConvertToDataTable<HANGHOA>(h.LayDanhSachHangHoa());
        }
        private void LoadNhaCungCap()
        {
            NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();
            lkup_NhaCungCap.Properties.DataSource = _nhaCungCapBLL.LayDanhSachNhaCungCap();
            lkup_NhaCungCap.Properties.ValueMember = "MaNhaCungCap";
            lkup_NhaCungCap.Properties.DisplayMember = "TenNhaCungCap";

        }
        private void LoadNhanVien()
        {
            NguoiDungBLL _nguoidungBLL = new NguoiDungBLL();
            lkup_NhanVien.Properties.DataSource = _nguoidungBLL.LayDanhSachNguoiDung();
            lkup_NhanVien.Properties.ValueMember = "MaNguoiDung";
            lkup_NhanVien.Properties.DisplayMember = "TenNguoiDung";

        }
        private void LoadHangHoa()
        {
            HangHoaBLL _hanghoaBLL = new HangHoaBLL();
            lkup_HangHoa2.DataSource = lkup_HangHoa.DataSource = _hanghoaBLL.LayDanhSachHangHoa();
            lkup_HangHoa2.ValueMember = lkup_HangHoa.ValueMember = "MaHangHoa";
            lkup_HangHoa2.DisplayMember = lkup_HangHoa.DisplayMember = "TenHangHoa";
        }
        private void Frm_NhapHang_Load(object sender, EventArgs e)
        {
            txtConLai.Enabled = txt_TongThanhTien.Enabled = txt_TongThanhToan.Enabled = false;
            LoadNhanVien();
            TaoDT_CTPN();
            LoadHangHoa();
            LoadNhaCungCap();
            LoadDataSource();
            LoadDanhSachHangHoa();
            gridView_CTPN.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        private void gridView_PN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (btn_LuuPhieuNhap.Enabled == true)
            {
                if (Notification.Answers("Bạn có dữ liệu chưa lưu?") == DialogResult.Cancel)
                {
                }
                else
                {
                    try
                    {
                        _phieunhapBLL.CapNhatPhieuNhap(LayDuLieuPhieuNhap());
                        foreach (int id in _listUpdate)
                        {
                            _phieunhapBLL.CapNhatCTPhieuNhap(LayDuLieuCTPhieuNhap(id), txt_MaPhieuNhap.Text, id);

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
            PHIEUNHAP p = new PHIEUNHAP();
            p = _phieunhapBLL.LayPhieuNhap(gridView_PN.GetFocusedRowCellValue("MaPhieuNhap").ToString());
            txt_MaPhieuNhap.Text = p.MaPhieuNhap.ToString();
            dt_NgayNhapHang.EditValue = p.NgayLap;
            lkup_NhanVien.EditValue = p.MaNguoiDung;
            txt_TongThanhTien.Text = p.TongThanhTien.ToString();
            txtThanhToan.Text = p.ThanhToan.ToString();
            txtConLai.Text = p.ConLai.ToString();
            txtDDH.Text = p.MaDonDatHangNCC;

            grid_CTPN.DataSource = Utils.Util.ConvertToDataTable<CTPHIEUNHAP>(_phieunhapBLL.LayChiTietPhieuNhap(gridView_PN.GetFocusedRowCellValue("MaPhieuNhap").ToString()));
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

        private PHIEUNHAP LayDuLieuPhieuNhap()
        {
            PHIEUNHAP p = new PHIEUNHAP();
            if (txt_MaPhieuNhap.Text != "") p.MaPhieuNhap = txt_MaPhieuNhap.Text;
            p.MaNguoiDung = int.Parse(lkup_NhanVien.EditValue.ToString());
            p.MaDonDatHangNCC = txtDDH.Text;
            p.NgayLap = dt_NgayNhapHang.DateTime;
            p.TongThanhTien = int.Parse(txt_TongThanhToan.Text);
            p.ThanhToan = int.Parse(txtThanhToan.Text);
            p.ConLai = int.Parse(txtConLai.Text);
            return p;
        }
        private CTPHIEUNHAP LayDuLieuCTPhieuNhap(int i)
        {
            CTPHIEUNHAP ct = new CTPHIEUNHAP();
            ct.MaPhieuNhap = txt_MaPhieuNhap.Text;
            ct.MaHangHoa = int.Parse(gridView_CTPN.GetRowCellValue(i, "MaHangHoa").ToString());
            ct.DonGiaNhap = int.Parse(gridView_CTPN.GetRowCellValue(i, "DonGiaNhap").ToString());
            ct.SoLuongNhap = int.Parse(gridView_CTPN.GetRowCellValue(i, "SoLuongNhap").ToString());
            ct.SoLuongChuaNhap = int.Parse(gridView_CTPN.GetRowCellValue(i, "SoLuongChuaNhap").ToString());
            ct.ThanhTien = int.Parse(gridView_CTPN.GetRowCellValue(i, "ThanhTien").ToString());
            return ct;
        }
        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn thêm dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            _phieunhapBLL.ThemPhieuNhapMoi(LayDuLieuPhieuNhap());

            for (int i = 0; i < gridView_CTPN.RowCount; i++)
            {
                _phieunhapBLL.ThemCTPhieuNhapMoi(LayDuLieuCTPhieuNhap(i));
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
            if (gridView_CTPN.GetRowCellValue(e.RowHandle, "DonGiaNhap").ToString() != "" && gridView_CTPN.GetRowCellValue(e.RowHandle, "SoLuongNhap").ToString() != "")
            {
                if (e.Column.Name == "col_DonGiaNhap" || e.Column.Name == "col_SoLuongNhap")
                {
                    double SoLuong = int.Parse(gridView_CTPN.GetFocusedRowCellValue("SoLuongNhap").ToString());
                    double DonGiaNhap = int.Parse(gridView_CTPN.GetFocusedRowCellValue("DonGiaNhap").ToString());
                    double ThanhTien = SoLuong * DonGiaNhap;
                    gridView_CTPN.SetFocusedRowCellValue("ThanhTien", ThanhTien.ToString());
                }
            }
            if (e.Column.Name == "col_ThanhTien" && gridView_CTPN.GetRowCellValue(e.RowHandle, "ThanhTien").ToString() != "")
            {
                int t = 0;
                for (int i = 0; i < gridView_CTPN.DataRowCount; i++)
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

        private void btn_ThemTuPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn thêm dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            _phieunhapBLL.ThemPhieuNhapMoi(LayDuLieuPhieuNhap());

            for (int i = 0; i < gridView_CTPN.RowCount; i++)
            {
                _phieunhapBLL.ThemCTPhieuNhapMoi(LayDuLieuCTPhieuNhap(i));
            }
            Util.ShowAlert("  Thêm Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void btn_ThemHang_Click(object sender, EventArgs e)
        {
            HANGHOA ct = new HANGHOA();
            HangHoaBLL hh = new HangHoaBLL();
            ct = hh.LayHangHoaTheoMaHH(int.Parse(gridView1.GetFocusedRowCellValue("MaHangHoa").ToString()));
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
                gridView_CTPN.SetRowCellValue(rowHandle, "DonGiaNhap", ct.DonGiaNhap);
                gridView_CTPN.SetRowCellValue(rowHandle, "SoLuongNhap", 10);
            }
        }

        private void btn_XoaPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            _phieunhapBLL.XoaPhieuNhap(gridView_PN.GetFocusedRowCellValue("MaPhieuNhap").ToString());
            Util.ShowAlert("  Xóa Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void btn_LuuPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn lưu dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                _phieunhapBLL.CapNhatPhieuNhap(LayDuLieuPhieuNhap());
                foreach (int id in _listUpdate)
                {
                    _phieunhapBLL.CapNhatCTPhieuNhap(LayDuLieuCTPhieuNhap(id), txt_MaPhieuNhap.Text, id);

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
            btn_LuuPhieuNhap.Enabled = true;
        }

        private void lkup_NhaCungCap_TextChanged(object sender, EventArgs e)
        {

            if (testupdate == true)
                btn_LuuPhieuNhap.Enabled = true;

        }

        private void dt_NgayNhapHang_TextChanged(object sender, EventArgs e)
        {
            if (testupdate == true)
                btn_LuuPhieuNhap.Enabled = true;
        }

        private void lkup_NhanVien_TextChanged(object sender, EventArgs e)
        {

            if (testupdate == true)
                btn_LuuPhieuNhap.Enabled = true;
        }

        private void gridView_PN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //btn_XoaPhieuXuat.Enabled = true;

            //PHIEUNHAP p = new PHIEUNHAP();
            //p = _phieunhapBLL.LayPhieuNhap(int.Parse(gridView_PN.GetFocusedRowCellValue("MaPhieuNhap").ToString()));
            //txt_MaPhieuNhap.Text = p.MaPhieuNhap.ToString();
            //lkup_NhaCungCap.EditValue = p.MaNhaCungCap;
            //dt_NgayNhapHang.EditValue = p.NgayLap;
            //lkup_NhanVien.EditValue = p.MaNguoiDung;

            //grid_CTPN.DataSource = Utils.Util.ConvertToDataTable<CTPHIEUNHAP>(_phieunhapBLL.LayChiTietPhieuNhap(int.Parse(gridView_PN.GetFocusedRowCellValue("MaPhieuNhap").ToString())));
        }

        private void spinEdit_VAT_TextChanged(object sender, EventArgs e)
        {
            txt_TongThanhToan.Text = (int.Parse(txt_TongTienHang.Text) + int.Parse(spinEdit_VAT.Text)* int.Parse(txt_TongTienHang.Text)/100).ToString();
        }

        private void txtThanhToan_TextChanged(object sender, EventArgs e)
        {
            if (testupdate == true)
                btn_LuuPhieuNhap.Enabled = true;
            if (txt_TongThanhTien.Text != "" && txtThanhToan.Text != "")
            {
                txtConLai.Text = (int.Parse(txt_TongThanhTien.Text) - int.Parse(txtThanhToan.Text)).ToString();
            }
        }

        private void txt_TongThanhToan_TextChanged(object sender, EventArgs e)
        {
            txt_TongThanhTien.Text = txt_TongThanhToan.Text;
        }

        private void txt_TongThanhTien_TextChanged(object sender, EventArgs e)
        {
            if(txt_TongThanhTien.Text!="" && txtThanhToan.Text !="")
            {
                txtConLai.Text = (int.Parse(txt_TongThanhTien.Text) - int.Parse(txtThanhToan.Text)).ToString();
            }
        }

        private void btn_MaTuSinh_Click(object sender, EventArgs e)
        {
            txt_MaPhieuNhap.Text = _phieunhapBLL.XuLyMaPhieuNhap();
        }
    }
}
