using QuanLySieuThiDienThoai.GUI;
using QuanLySieuThiDienThoai.Rerport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuanLySieuThiDienThoai.DTO;

namespace QuanLySieuThiDienThoai
{
    public partial class main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Biến lưu thông tin đăng nhập lấy dữ liệu từ form DangNhap
        public static string TenDangNhap;
        public static string PhongBan;
        public static string MaNhanVien;

        public main()
        {
            InitializeComponent();
        }

        //Phần mềm hiện lên sẽ gọi form DangNhap
        private void frmMain_Load(object sender, EventArgs e)
        {
            DangNhap();
        }

        //Nhấn nút Nhân viên
        private void barButtonItem_nhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.GUI.NhanVien uc = new QuanLySieuThiDienThoai.GUI.NhanVien();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }

        //Nhấn nút Khách hàng
        private void barButtonItem_khachhang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.GUI.KhachHang uc = new QuanLySieuThiDienThoai.GUI.KhachHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }

        //Nhấn nút mặt hàng
        private void barButtonItem_mathang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.GUI.MatHang uc = new QuanLySieuThiDienThoai.GUI.MatHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }

        private void barButtonItem_nhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            NhapHang uc = new NhapHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }

        //Nhấn nút xuất hàng
        private void barButtonItem_xuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            XuatHang uc = new XuatHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }


        //Nhấn nút hàng tồn kho
        private void barButtonItem_hangton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "ThongKeTonKho";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        //Nhấn nút phiếu nhập
        private void barButtonItem_phieunhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            TimPhieuNhapHang uc = new TimPhieuNhapHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }

        //Nhấn nút phiếu xuất
        private void barButtonItem_phieuxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            TimPhieuXuatHang uc = new TimPhieuXuatHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);
        }

        //Nhấn nút DoanhThuTheoThang
        private void barButtonItem_doanhthu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "DoanhThuTheoThang";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        //Nhấn nút ThongKeBanHangTheoThang
        private void barButtonItem_banhang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "ThongKeBanHangTheoThang";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        //Nhấn nút DanhSachNhanVien
        private void barButtonItem_indsnv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "DanhSachNhanVien";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        #region "Thiết lập quyền"
        void Quest()
        {
            ribbonPageGroup_hethong.Enabled = true;
            ribbonPageGroup_trangquanly.Enabled = false;
            ribbonPageGroup_lapphieu.Enabled = false;
            ribbonPageGroup_thongke.Enabled = false;
            ribbonPageGroup_trogiup.Enabled = true;

            barButtonItem_saoluu.Enabled = false;
            barButtonItem_hoiphuc.Enabled = false;
        }
        void admin()
        {
            ribbonPageGroup_hethong.Enabled = true;
            ribbonPageGroup_lapphieu.Enabled = true;
            ribbonPageGroup_thongke.Enabled = true;
            ribbonPageGroup_trangquanly.Enabled = true;
            ribbonPageGroup_trogiup.Enabled = true;

            barButtonItem_saoluu.Enabled = true;
            barButtonItem_hoiphuc.Enabled = true;

            barButtonItem_phieunhap.Enabled = true;
            barButtonItem_phieuxuat.Enabled = true;
        }
        void NVBanHang()
        {
            ribbonPageGroup_hethong.Enabled = true;
            ribbonPageGroup_trangquanly.Enabled = false;
            ribbonPageGroup_lapphieu.Enabled = true;
            ribbonPageGroup_thongke.Enabled = false;
            ribbonPageGroup_trogiup.Enabled = true;

            barButtonItem_saoluu.Enabled = false;
            barButtonItem_hoiphuc.Enabled = false;
        }
        void NVKeToan()
        {
            ribbonPageGroup_hethong.Enabled = true;
            ribbonPageGroup_trangquanly.Enabled = false;
            ribbonPageGroup_lapphieu.Enabled = false;
            ribbonPageGroup_thongke.Enabled = true;
            ribbonPageGroup_trogiup.Enabled = true;

            barButtonItem_saoluu.Enabled = false;
            barButtonItem_hoiphuc.Enabled = false;
        }
        void NVKho()
        {
            ribbonPageGroup_hethong.Enabled = true;
            ribbonPageGroup_trangquanly.Enabled = false;
            ribbonPageGroup_lapphieu.Enabled = true;
            ribbonPageGroup_thongke.Enabled = false;
            ribbonPageGroup_trogiup.Enabled = true;

            barButtonItem_phieunhap.Enabled = false;
            barButtonItem_phieuxuat.Enabled = false;

            barButtonItem_saoluu.Enabled = false;
            barButtonItem_hoiphuc.Enabled = false;
        }
        void QuanLy()
        {
            ribbonPageGroup_hethong.Enabled = true;
            ribbonPageGroup_lapphieu.Enabled = true;
            ribbonPageGroup_thongke.Enabled = true;
            ribbonPageGroup_trangquanly.Enabled = true;
            ribbonPageGroup_trogiup.Enabled = true;

            barButtonItem_saoluu.Enabled = false;
            barButtonItem_hoiphuc.Enabled = false;
        }
        #endregion

        //Nhấn nút đăng xuất sẽ gọi đến form đăng nhập
        private void barButtonItem_dangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            DangNhap();
        }

        void DangNhap()
        {
            Connect.DangNhap frm = new Connect.DangNhap();
            frm.ShowDialog();
            if (PhongBan == null) Quest();
            if (PhongBan == "PB001") admin();
            if (PhongBan == "PB002") NVBanHang();
            if (PhongBan == "PB003") NVKeToan();
            if (PhongBan == "PB004") NVKho();
            lbl_hello.Text = "Xin chào " + TenDangNhap;
        }

        //Nhấn nút Sao lưu
        private void barButtonItem_saoluu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "QLSTDT.Bak";
            save.Filter = "File(*.bak)|*.bak";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BLL.RestoreBackupBll.DoBackup(save.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Sao lưu thất bại\n Liên hệ admin để giải quyết", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Đã sao lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        //Nhấn nút hồi phục
        private void barButtonItem_hoiphuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "QLSTDT.Bak";
            open.Filter = "File(*.bak)|*.bak";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BLL.RestoreBackupBll.DoRestore(open.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hồi phục thất bại\n Liên hệ admin để giải quyết", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Đã hồi phục thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        //Nhấn nút thông tin phần mềm
        private void barButtonItem_thongtin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            Info uc = new Info();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl.Controls.Add(uc);

        }

        //Nhấn nút ThongKeBanHangTheoNgay
        private void barButtonItem_thongkebanhangthe0ngay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "ThongKeBanHangTheoNgay";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        //Nhấn nút DoanhThuTheoNgay
        private void barButtonItem_banhangtheongay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl.Controls.Clear();
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "DoanhThuTheoNgay";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        //Nhấn nút trợ giúp
        private void barButtonItem_trogiup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("..\\..\\Resources\\Help.pdf");
        }

    }
}
