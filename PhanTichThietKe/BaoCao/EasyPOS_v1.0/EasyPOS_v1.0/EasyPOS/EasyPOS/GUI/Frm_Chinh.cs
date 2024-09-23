using DevExpress.XtraBars.Alerter;
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
    public partial class Frm_Chinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {       
        public Frm_Chinh()
        {
            InitializeComponent();
            item_NguoiDung.Caption = BienToanCuc.TenNguoiDung;     
        }
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_BaoCaoDoanhThuNgay();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void Frm_Chinh_Load(object sender, EventArgs e)
        {
            //thiết lập một giao diện ngẫu nhiên
            System.Random r = new Random();

            DevExpress.Skins.SkinContainerCollection skinCollection = DevExpress.Skins.SkinManager.Default.Skins;

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013 Ligh Gray");
            
        }
        // Lấy Mdi của Form theo tên
        Form GetMdiFormByName(string name)
        {
            return this.MdiChildren.FirstOrDefault(f => f.Name == name);
        }
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_NhapHang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new GUI.Frm_HoaDonBanLe();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btn_Ban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private void btn_KhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_HangHoa();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
  //              f = new Frm_LoaiHangHoa();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_Don_Vi();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_Nha_Cung_Cap();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_QuanLyNguoiDung();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btn_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_LienHe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btn_DanhSachHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btn_TienIch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EasyPOS.Utils.Util.ShowAlert("Thêm Người Dùng Thành Công", "Thông Báo", this);
        }

        private void btn_DoanhThuThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_BaoCaoDoanhThuThang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btn_QuanLyDinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_KhachHang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_DonDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_DonDatHang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btn_QuanLyCongNo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new EasyPOS.GUI.Frm_QuanLyCongNo();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barTime.Caption = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnDonNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new EasyPOS.GUI.Frm_DonDatHangNCC();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnGiaoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                f = new Frm_XuatHang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
