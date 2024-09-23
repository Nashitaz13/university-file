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

namespace EasyPOS.GUI
{
    public partial class Frm_DonDatHangNCC : Form
    {
        private DonNhapHangBLL _donNHBLL = new DonNhapHangBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        bool testupdate = false;
        public Frm_DonDatHangNCC()
        {
            InitializeComponent();
        }

        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<DONDATHANGNCC>(_donNHBLL.LayDanhSachDonNhapHang());
            gridControl1.DataSource = dt;
            btn_Luu.Enabled = false;
            _listUpdate.Clear();
        }
        private void LoadNhaCungCap()
        {
            NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();
            lkup_NCC.DataSource = _nhaCungCapBLL.LayDanhSachNhaCungCap();
            lkup_NCC.ValueMember = "MaNhaCungCap";
            lkup_NCC.DisplayMember = "TenNhaCungCap";
            lkupNCC.Properties.DataSource = _nhaCungCapBLL.LayDanhSachNhaCungCap();
            lkupNCC.Properties.ValueMember = "MaNhaCungCap";
            lkupNCC.Properties.DisplayMember = "TenNhaCungCap";
        }
        private void LoadHangHoa()
        {
            HangHoaBLL _hanghoaBLL = new HangHoaBLL();
            lkup_HangHoa.DataSource = _hanghoaBLL.LayDanhSachHangHoa();
            lkup_HangHoa.ValueMember = "MaHangHoa";
            lkup_HangHoa.DisplayMember = "TenHangHoa";
        }
        private void Frm_DonDatHangNCC_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            LoadHangHoa();
            LoadDataSource();
            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
                        _donNHBLL.CapNhatDonNhapHang(LayDuLieuDonNhapHang());
                        foreach (int id in _listUpdate)
                        {
                            _donNHBLL.CapNhatCTDonNhapHang(LayDuLieuCTDonNhapHang(id), txtDonDatHang.Text, id);

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
            btn_Xoa.Enabled = true;
            testupdate = false;
            DONDATHANGNCC d = new DONDATHANGNCC();
            d = _donNHBLL.LayDonNhapHang(gridView1.GetFocusedRowCellValue("MaDonDatHangNCC").ToString());
            txtDonDatHang.Text = d.MaDonDatHangNCC;
            dateNgayLap.Text = d.NgayLap.ToString();
            lkupNCC.EditValue = d.MaNCC;
            NguoiDungBLL nguoidungBLL = new NguoiDungBLL();
            txtNhanVien.Text = nguoidungBLL.LayNguoiDung(d.MaNhanVien);
            gridControl2.DataSource = Utils.Util.ConvertToDataTable<CTDONDATHANGNCC>(_donNHBLL.LayCTDonNhapHang(gridView1.GetFocusedRowCellValue("MaDonDatHangNCC").ToString()));
            testupdate = true;
        }
        private DONDATHANGNCC LayDuLieuDonNhapHang()
        {
            DONDATHANGNCC d = new DONDATHANGNCC();
            if (txtDonDatHang.Text == "")
            {
                Notification.Error("Có lỗi xảy ra khi chưa có dữ liệu mã đơn đặt hàng.");
                return d;
            }
            d.MaDonDatHangNCC = txtDonDatHang.Text;
            NguoiDungBLL nguoidungBLL = new NguoiDungBLL();
            d.MaNhanVien = nguoidungBLL.LayMaNguoiDung(txtNhanVien.Text);
            d.MaNCC = int.Parse(lkupNCC.EditValue.ToString());
            d.NgayLap = dateNgayLap.DateTime;
            return d;
        }
        private CTDONDATHANGNCC LayDuLieuCTDonNhapHang(int i)
        {
            CTDONDATHANGNCC ct = new CTDONDATHANGNCC();
            ct.MaHangHoa = int.Parse(gridView2.GetRowCellValue(i, "MaHangHoa").ToString());
            ct.SoLuongDat = int.Parse(gridView2.GetRowCellValue(i, "SoLuongDat").ToString());
            ct.SoLuongDaNhap = int.Parse(gridView2.GetRowCellValue(i, "SoLuongDaNhap").ToString());
            ct.MaDonDatHangNCC = txtDonDatHang.Text;
            return ct;
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn thêm dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }

            if (gridView2.RowCount == 0)
            {
                _donNHBLL.ThemDonNhapHangMoi(LayDuLieuDonNhapHang());
            }
            else
            {
                _donNHBLL.ThemCTDonNhapHangMoi(LayDuLieuDonNhapHang());
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    _donNHBLL.ThemCTDonNhapHangMoi(LayDuLieuCTDonNhapHang(i));
                }
            }
            Util.ShowAlert("  Thêm Thành Công!", "Thông báo", this);
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
                _donNHBLL.CapNhatDonNhapHang(LayDuLieuDonNhapHang());
                foreach (int id in _listUpdate)
                {
                    _donNHBLL.CapNhatCTDonNhapHang(LayDuLieuCTDonNhapHang(id),txtDonDatHang.Text, id);

                }
                Util.ShowAlert("  Cập dữ liệu thành công.", "Thông báo", this);
            }
            catch (Exception)
            {
                Notification.Error("Có lỗi xảy ra khi cập nhật dữ liệu.");
            }
            LoadDataSource();
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Notification.Answers("Bạn có thật sự muốn xóa dữ liệu?") == DialogResult.Cancel)
            {
                return;
            }
            _donNHBLL.XoaDonNhapHang(txtDonDatHang.Text);
            Util.ShowAlert("  Xóa Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtDonDatHang.Text = "";
            txtNhanVien.Text = "";
            lkupNCC.EditValue = null;
            dateNgayLap.EditValue = null;
            gridControl2.DataSource = null;
        }

        private void lkupNCC_TextChanged(object sender, EventArgs e)
        {
            if (testupdate) btn_Luu.Enabled = true;
        }

        private void dateNgayLap_TextChanged(object sender, EventArgs e)
        {
            if (testupdate) btn_Luu.Enabled = true;
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            _listUpdate.Add(e.RowHandle);
            btn_Luu.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtDonDatHang.Text = _donNHBLL.XuLyMaDonNhapHang();
        }
    }
}
