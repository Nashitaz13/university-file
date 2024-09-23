using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPOS.DAL;
using EasyPOS.BLL;
using EasyPOS.Utils;

namespace EasyPOS
{
    public partial class Frm_DonDatHang : Form
    {
        DonDatHangBLL ddhBLL = new DonDatHangBLL();
        private List<int> _listUpdate = new List<int>();      // Danh sách các đối tượng cần update
        DataTable dt = new DataTable();
        bool testupdate = false;
        public Frm_DonDatHang()
        {
            InitializeComponent();
        }

        //    private void Frm_DonDatHang_Load(object sender, EventArgs e)
        //    {
        ////        dt = Utils.Util.ConvertToDataTable<DONDATHANG>(d.LayDanhSachDonDatHang());
        //        gridControl1.DataSource = dt;
        //    }
        //    Form GetMdiFormByName(string name)
        //    {
        //        Frm_Chinh frm = (Frm_Chinh)this.ParentForm;
        //        return frm.MdiChildren.FirstOrDefault(f => f.Name == name);
        //    }
        //    private void btn_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //    {
        //        string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
        //        Form f = GetMdiFormByName(typeName);
        //        if (f != null)
        //            f.BringToFront();
        //        else
        //        {
        //            f = new Frm_NhapHang();
        //            f.Name = f.GetType().ToString();
        //            e.Item.Tag = f.Name;
        //            f.MdiParent = (Frm_Chinh)this.ParentForm;
        //            f.Show();
        //        }
        //    }

        //    private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //    {

        //    }
        private void LoadDataSource()
        {
            dt = Utils.Util.ConvertToDataTable<DONDATHANGKH>(ddhBLL.LayDanhSachDonDatHang());
            gridControl1.DataSource = dt;
            btn_Luu.Enabled = false;
            _listUpdate.Clear();
        }
        private void LoadKhachHang()
        {
            KhachHangBLL _khBLL = new KhachHangBLL();
            lkup_KhachHang.Properties.DataSource = _khBLL.LayDanhSachKhachHang();
            lkup_KhachHang.Properties.ValueMember = "MaKhachHang";
            lkup_KhachHang.Properties.DisplayMember = "TenKhachHang";
        }
        private void LoadHangHoa()
        {
            HangHoaBLL _hanghoaBLL = new HangHoaBLL();
            lkup_HangHoa.DataSource = _hanghoaBLL.LayDanhSachHangHoa();
            lkup_HangHoa.ValueMember = "MaHangHoa";
            lkup_HangHoa.DisplayMember = "TenHangHoa";
        }
        private void Frm_DonDatHang_Load(object sender, EventArgs e)
        {

            LoadHangHoa();
            LoadKhachHang();
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
                        ddhBLL.CapNhatDonDatHang(LayDuLieuDonDatHang());
                        foreach (int id in _listUpdate)
                        {
                            ddhBLL.CapNhatCTDonDatHang(LayDuLieuCTDonDatHang(id), txt_MaDonDatHang.Text, id);

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
            DONDATHANGKH d = new DONDATHANGKH();
            d = ddhBLL.LayDonDatHang(gridView1.GetFocusedRowCellValue("MaDonDatHangKH").ToString());
            txt_MaDonDatHang.Text = d.MaDonDatHangKH;
            dt_NgayDatHang.Text = d.NgayDat.ToString();
            dt_NgayNhanHang.Text = d.NgayGiaoDuKien.ToString();
            lkup_KhachHang.EditValue = d.MaKhachHang;
            if (d.TrangThaiGiaoHang) checkChuaGiaoHang.Checked = true;
            else checkChuaGiaoHang.Checked = false;

            gridControl2.DataSource = Utils.Util.ConvertToDataTable<CTDONDATHANGKH>(ddhBLL.LayCTDonDatHang(gridView1.GetFocusedRowCellValue("MaDonDatHangKH").ToString()));
            testupdate = true;
        }
        private DONDATHANGKH LayDuLieuDonDatHang()
        {
            DONDATHANGKH d = new DONDATHANGKH();
            if (txt_MaDonDatHang.Text == "")
            {
                Notification.Error("Có lỗi xảy ra khi chưa có dữ liệu mã đơn đặt hàng.");
                return d;
            }
            d.MaDonDatHangKH = txt_MaDonDatHang.Text;
            d.MaKhachHang = int.Parse(lkup_KhachHang.EditValue.ToString());
            d.NgayDat = dt_NgayDatHang.DateTime;
            d.NgayGiaoDuKien = dt_NgayNhanHang.DateTime;
            if (checkChuaGiaoHang.Checked) d.TrangThaiGiaoHang = true;
            else d.TrangThaiGiaoHang = false;
            return d;
        }
        private CTDONDATHANGKH LayDuLieuCTDonDatHang(int i)
        {
            CTDONDATHANGKH ct = new CTDONDATHANGKH();
            ct.MaHangHoa = int.Parse(gridView2.GetRowCellValue(i, "MaHangHoa").ToString());
            ct.SoLuongDat = int.Parse(gridView2.GetRowCellValue(i, "SoLuongDat").ToString());
            ct.SoLuongDaGiao = int.Parse(gridView2.GetRowCellValue(i, "SoLuongDaGiao").ToString());
            ct.MaDonDatHangKH = txt_MaDonDatHang.Text;
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
                ddhBLL.ThemDonDatHangMoi(LayDuLieuDonDatHang());
            }
            else
            {
                ddhBLL.ThemCTDonDatHangMoi(LayDuLieuDonDatHang());
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    ddhBLL.ThemCTDonDatHangMoi(LayDuLieuCTDonDatHang(i));
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
                ddhBLL.CapNhatDonDatHang(LayDuLieuDonDatHang());
                foreach (int id in _listUpdate)
                {
                    ddhBLL.CapNhatCTDonDatHang(LayDuLieuCTDonDatHang(id), txt_MaDonDatHang.Text, id);

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
            ddhBLL.XoaDonDatHang(txt_MaDonDatHang.Text);
            Util.ShowAlert("  Xóa Thành Công!", "Thông báo", this);
            LoadDataSource();
        }

        private void btn_LamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_MaDonDatHang.Text = "";
            lkup_KhachHang.EditValue = null;
            dt_NgayDatHang.EditValue = null;
            dt_NgayNhanHang.EditValue = null;
            gridControl2.DataSource = null;
        }

        private void lkupKH_TextChanged(object sender, EventArgs e)
        {
            if (testupdate) btn_Luu.Enabled = true;
        }

        private void dateNgayDat_TextChanged(object sender, EventArgs e)
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
            txt_MaDonDatHang.Text = ddhBLL.XuLyMaDonDatHang();
        }

        private void dt_NgayNhanHang_TextChanged(object sender, EventArgs e)
        {
            if (testupdate) btn_Luu.Enabled = true;
        }

        private void checkChuaGiaoHang_EditValueChanged(object sender, EventArgs e)
        {
            if (testupdate) btn_Luu.Enabled = true;
        }
    }
}
