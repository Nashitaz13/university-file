using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DAO;

namespace QLCHMT
{
    public partial class main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static String MaNhanVien = null;
        public static String TenNhanVien = null;

        public main()
        {
            InitializeComponent();
            if(MaNhanVien==null) 
                login();
        }

        private void login()
        {
            Login lg = new Login();
            lg.ShowDialog();
            lbl_infologin.Text = "Xin Chào " + TenNhanVien;
            resetPermit();
            getPermit();
        }

        private void btn_nhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.NhanVien uc = new GUI.NhanVien();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_mathang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.MatHang uc = new GUI.MatHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_thongtin_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.ThongTin uc = new GUI.ThongTin();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_trogiup_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.TroGiup uc = new GUI.TroGiup();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_phong_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.PhongBan uc = new GUI.PhongBan();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_loaihang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.LoaiHang uc = new GUI.LoaiHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }


        private void btn_lapphieunhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.LapPhieuNhap uc = new GUI.LapPhieuNhap();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_mau_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_capnhatnhap_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_lapphieuxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.LapPhieuXuat uc = new GUI.LapPhieuXuat();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_thanhtoanxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.ThanhToan uc = new GUI.ThanhToan();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_giaohang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.GiaoHang uc = new GUI.GiaoHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_doanhsobanhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.Report.BaoCaoDoanhSoBanHang uc = new Report.BaoCaoDoanhSoBanHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
            //btn_doanhsobanhang
        }

        private void btn_doanhsonhaphang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.Report.BaoCaoDoanhSoNhapHang uc = new Report.BaoCaoDoanhSoNhapHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void barButtonItem_doanhthubanhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.Report.BaoCaoDoanhThuBanHang uc = new Report.BaoCaoDoanhThuBanHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void barButtonItem_chinhaphang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.Report.BaoCaoChiNhapHang uc = new Report.BaoCaoChiNhapHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_saoluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "QLCHMT.Bak";
            save.Filter = "File(*.bak)|*.bak";
            if (save.ShowDialog() == DialogResult.OK)
            {
                DataProvider provider = new DataProvider();
                provider.connect();
                try
                {
                    string backupCommand = "BACKUP DATABASE [QLCHMT] TO DISK='" + save.FileName + "'";
                    provider.executeNonQuery(backupCommand);
                }
                catch (Exception)
                {
                    MessageBox.Show("Sao lưu thất bại\n Liên hệ admin để giải quyết", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    provider.disconnect();
                    return;
                }
                MessageBox.Show("Đã sao lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                provider.disconnect();
            } 
        }

        private void btn_hoiphuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "QLCHMT.Bak";
            open.Filter = "File(*.bak)|*.bak";
            if (open.ShowDialog() == DialogResult.OK)
            {
                DataProvider provider = new DataProvider();
                provider.connect();
                try
                {
                    string restoreCommand = "alter database [QLCHMT] set offline with rollback immediate Restore Database [QLCHMT] from disk='" + open.FileName + "'alter database [QLCHMT] set online";
                    provider.executeNonQuery(restoreCommand);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hồi phục thất bại\n Liên hệ admin để giải quyết", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    provider.disconnect();
                    return;
                }
                MessageBox.Show("Đã hồi phục thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                provider.disconnect();
            }
        }

        private void btn_dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            MaNhanVien = null;
            panel.Controls.Clear();
            resetPermit();
            login();
        }
        private void getPermit()
        {
            if (MaNhanVien == null) return;
            gETQUYENTableAdapter.FillByMaNhanVien(qLCHDTdataset.GETQUYEN, MaNhanVien);
            for (int i = 0; i < qLCHDTdataset.GETQUYEN.Count; i++)
            {
                String strQuyen=qLCHDTdataset.GETQUYEN[i][0].ToString();
                if (strQuyen.Equals("Q0001"))
                    btn_saoluu.Enabled = true;
                if (strQuyen.Equals("Q0002"))
                    btn_hoiphuc.Enabled = true;
                if (strQuyen.Equals("Q0003"))
                    btn_nhanvien.Enabled=true;
                if (strQuyen.Equals("Q0004"))
                    btn_phanphongban.Enabled=true;
                if (strQuyen.Equals("Q0005"))
                    btn_phong.Enabled=true;
                if (strQuyen.Equals("Q0006"))
                    btn_phanquyen.Enabled=true;
                //if (strQuyen.Equals("Q0007"))
                //    btn_quyen.Enabled=true;
                if (strQuyen.Equals("Q0008"))
                    btn_mathang.Enabled=true;
                if (strQuyen.Equals("Q0009"))
                    btn_loaihang.Enabled=true;
                if (strQuyen.Equals("Q0010"))
                    btn_lapphieunhap.Enabled=true;
                if (strQuyen.Equals("Q0011"))
                    btn_lapphieuxuat.Enabled=true;
                if (strQuyen.Equals("Q0012"))
                    btn_thanhtoanxuat.Enabled=true;
                if (strQuyen.Equals("Q0013"))
                    btn_giaohang.Enabled=true;
                if (strQuyen.Equals("Q0014"))
                    btn_lapphieubaohanh.Enabled=true;
                if (strQuyen.Equals("Q0015"))
                    btn_tiepnhanbaohanh.Enabled=true;
                if (strQuyen.Equals("Q0016"))
                    btn_capnhatbaohanh.Enabled=true;
                if (strQuyen.Equals("Q0017"))
                    btn_trabaohanh.Enabled=true;
                if (strQuyen.Equals("Q0018"))
                    btn_doanhsobanhang.Enabled=true;
                if (strQuyen.Equals("Q0019"))
                    btn_doanhsonhaphang.Enabled=true;
                if (strQuyen.Equals("Q0020"))
                    btn_doanhthubanhang.Enabled=true;
                if (strQuyen.Equals("Q0021"))
                    btn_chinhaphang.Enabled = true;
                if (strQuyen.Equals("Q0022"))
                    btn_tonkho.Enabled = true;
                if (strQuyen.Equals("Q0023"))
                    btn_thongkebanhang.Enabled = true;
                    
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLCHDTdataset.NHANVIEN' table. You can move, or remove it, as needed.
            //this.nHANVIENTableAdapter.Fill(this.qLCHDTdataset.NHANVIEN);
            // TODO: This line of code loads data into the 'qLCHDTdataset.CHITIETPHONGBAN' table. You can move, or remove it, as needed.
            this.cHITIETPHONGBANTableAdapter.Fill(this.qLCHDTdataset.CHITIETPHONGBAN);

        }
        private void resetPermit()
        {
            //btn_dangxuat.Enabled = false;
            btn_saoluu.Enabled = false;
            btn_hoiphuc.Enabled = false;

            btn_phanphongban.Enabled = false;
            btn_nhanvien.Enabled = false;
            btn_mathang.Enabled = false;
            btn_phong.Enabled = false;
            btn_loaihang.Enabled = false;
            btn_phanquyen.Enabled = false;

            btn_lapphieunhap.Enabled = false;

            btn_lapphieuxuat.Enabled = false;
            btn_thanhtoanxuat.Enabled = false;
            btn_giaohang.Enabled = false;

            btn_lapphieubaohanh.Enabled = false;
            btn_trabaohanh.Enabled = false;
            btn_capnhatbaohanh.Enabled = false;
            btn_tiepnhanbaohanh.Enabled = false;

            btn_doanhsobanhang.Enabled = false;
            btn_doanhsonhaphang.Enabled = false;
            btn_doanhthubanhang.Enabled = false;
            btn_chinhaphang.Enabled = false;
            btn_tonkho.Enabled = false;
            btn_thongkebanhang.Enabled = false;


        }
        private void btn_phanquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.PhanPhongBan uc = new GUI.PhanPhongBan();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_quyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.Quyen uc = new GUI.Quyen();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_phanquyen_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.PhanQuyen uc = new GUI.PhanQuyen();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_tonkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report.frmBaoCao.Choose = 7;
            panel.Controls.Clear();
            QLCHMT.Report.frmBaoCao uc = new Report.frmBaoCao();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_lapphieubaohanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.LapPhieuBaoHanh uc = new GUI.LapPhieuBaoHanh();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_trabaohanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.TraHangBaoHanh uc = new GUI.TraHangBaoHanh();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_tiepnhanbaohanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.TiepNhanBaoHanh uc = new GUI.TiepNhanBaoHanh();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_capnhatbaohanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.CapNhatSuaChuaBaoHanh uc = new GUI.CapNhatSuaChuaBaoHanh();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_khuyenmai_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.Report.BaosCaoBanHang uc = new Report.BaosCaoBanHang();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void btn_nhasanxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            panel.Controls.Clear();
            QLCHMT.GUI.NhaSanXuat uc = new GUI.NhaSanXuat();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(uc);
        }
    }
}