using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySieuThiDienThoai.Rerport;
using System.IO;
using System.Drawing.Imaging;
using QuanLySieuThiDienThoai.BLL;
using QuanLySieuThiDienThoai.DTO;
using QuanLySieuThiDienThoai.DataSetTableAdapters;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace QuanLySieuThiDienThoai.GUI
{
    public partial class KhachHang : UserControl
    {

        KhachHangBll khachHangBll = new KhachHangBll();
        LoaiKhachHangBll loaiKhachHangBll = new LoaiKhachHangBll();

        DTO.KhachHang khachHang;
        DTO.LoaiKhachHang loaiKhachHang;
        int ViTri = 0;//Biến lấy vị trí dòng trên DataGridView
        int ChucNang = 0;//Biến này có tác dụng thay đổi chức năng khi chuyển đổi từ Nhân Viên qua Loai Khach Hang
        int Them = 0;//Biến kiểm tra khi thêm
        int Sua = 0;//Biến kiểm tra khi sửa
        int tuoi = 0;//Biến kiểm tra tuổi khách hàng
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadDataGridViewKhachHang();
            LoadDataGridViewLoaiKhachHang();
            cmb_KH_LoaiKH.DataSource = loaiKhachHangBll.ChonTenLoaiKhachHang();
            cmb_KH_LoaiKH.ValueMember = "TenLoaiKhachHang";
            ChucNang = 1;
            KhoiTao();
        }

        public void KhoiTao()
        {
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = true;
            btn_huy.Enabled = false;
            btn_sua.Enabled = true;

            if (ChucNang == 1)
            {
                txt_KH_MaKH.Enabled = false;
                txt_KH_TenKH.Enabled = false;
                dtp_KH_NgaySinh.Enabled = false;
                txt_KH_DiaChi.Enabled = false;
                txt_KH_SDT.Enabled = false;
                txt_KH_Email.Enabled = false;
                txt_KH_TimKiem.Text = null;
                cmb_KH_LoaiKH.Enabled = false;

                lbl_KH_TenKH.Visible = false;
                lbl_KH_NgaySinh.Visible = false;
                lbl_KH_DiaChi.Visible = false;
                lbl_KH_Email.Visible = false;
                lbl_KH_SDT.Visible = false;

                pictureBox_KH_TenKH.Visible = false;
                pictureBox_KH_NgaySinh.Visible = false;
                pictureBox_KH_DiaChi.Visible=false;
                pictureBox_KH_Email.Visible = false;
                pictureBox_KH_SDT.Visible = false;
            }

            if (ChucNang == 2)
            {
                txt_LKH_MaLoaiKhachHang.Enabled = false;
                txt_LKH_TenLoaiKhachHang.Enabled = false;
                txt_LKH_HeSoGiamGia.Enabled = false;
                txt_LKH_TimKiem.Text = null;

                lbl_LKH_TenLKH.Visible = false;
                lbl_LKH_HeSoGiamGia.Visible = false;

                pictureBox_LKH_TenLKH.Visible = false;
                pictureBox_LKH_HeSoGiamGia.Visible = false;
            }
        }

        private void backstageViewTabItem_khachhang_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 1;
            KhoiTaoKhachHang();
            cmb_KH_LoaiKH.DataSource = loaiKhachHangBll.ChonTenLoaiKhachHang();
            cmb_KH_LoaiKH.ValueMember = "MaLoaiKhachHang";
            cmb_KH_LoaiKH.DisplayMember = "TenLoaiKhachHang";
            KhoiTao();
            LoadDataGridViewKhachHang();
        }

        private void backstageViewTabItem_loaikhachhang_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 2;
            KhoiTaoLoaiKhachHang();
            KhoiTao();
            LoadDataGridViewLoaiKhachHang();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_huy.Enabled = true;
            btn_them.Enabled = false;
            btn_sua.Enabled = false;

            Them = 1;
            Sua = 0;
            if (ChucNang == 1)
            {
                ThemKhachHang();
            }

            if (ChucNang == 2)
            {
                ThemLoaiKhachHang();
            }

        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                LuuKhachHang();
                if (txt_KH_TenKH.Text != "" && tuoi > 15 && txt_KH_Email.Text != "" && txt_KH_DiaChi.Text !="")
                {
                    if (txt_KH_SDT.Text.Length >= 10 && lbl_KH_SDT.Visible == false)
                    {
                        KhoiTaoKhachHang();
                        this.ActiveControl = null;
                    }                                 
                }
            }
            if (ChucNang == 2)
            {
                LuuLoaiKhachHang();
                if (lbl_LKH_TenLKH.Visible == false && lbl_LKH_HeSoGiamGia.Visible == false)
                {
                    if (double.Parse(txt_LKH_HeSoGiamGia.Text) > 0 && double.Parse(txt_LKH_HeSoGiamGia.Text) <= 1)
                    {
                        KhoiTaoLoaiKhachHang();
                        this.ActiveControl = null;
                    }                 
                }
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                XoaKhachHang();
            }
            if (ChucNang == 2)
            {
                XoaLoaiKhachHang();
            }
        }

        private void btn_huy_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                KhoiTao();
                dgvKhachHang.Enabled = true;
                GanGiaTriKhachHang();
                ViTri = dgvKhachHang.CurrentCell.RowIndex;

            }
            if (ChucNang == 2)
            {
                KhoiTao();
                dgvLoaiKhachHang.Enabled = true;
                GanGiaTriLoaiKhachHang();
                ViTri = dgvLoaiKhachHang.CurrentCell.RowIndex;

            }
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            btn_them.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_huy.Enabled = true;
            btn_sua.Enabled = false;

            Sua = 1;
            Them = 0;

            if (ChucNang == 1)
            {
                SuaKhachHang();
            }

            if (ChucNang == 2)
            {
                SuaLoaiKhachHang();
            }
        }

        #region "Các hàm xử lý Khách Hàng"
        public void LoadDataGridViewKhachHang()
        {
            try
            {
                this.dgvKhachHang.AutoGenerateColumns = false;
                dgvKhachHang.DataSource = khachHangBll.DanhSachKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string TuTangMaKhachHang()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = khachHangBll.DanhSachKhachHang();
            if (dt.Rows.Count <= 0)//Kiểm tra nếu không có dòng nào thì tự động tăng mã khách hàng bằng KH001
            {
                str = "KH001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã khách hàng
                str = "KH";//ký tự mặc định của mã khách hàng    
                //Lấy 3 kí tự sau cùng trong mã khách hàng và chuyển sang kiểu int
                i = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                i = i + 1;
                if (i < 10)
                    str = str + "00";
                else if (i < 100)
                    str = str + "0";
                str = str + i.ToString();
            }
            return str;
        }

        public void ThemKhachHang()
        {
            txt_KH_MaKH.Text = TuTangMaKhachHang();
            txt_KH_TenKH.Text = "";
            dtp_KH_NgaySinh.Text = "";
            txt_KH_DiaChi.Text = "";
            txt_KH_SDT.Text = "";
            txt_KH_Email.Text = "";

            txt_KH_MaKH.Enabled = false;
            txt_KH_TenKH.Enabled = true;
            dtp_KH_NgaySinh.Enabled = true;
            txt_KH_DiaChi.Enabled = true;
            txt_KH_SDT.Enabled = true;
            txt_KH_Email.Enabled = true;
            cmb_KH_LoaiKH.Enabled = true;
            dgvKhachHang.Enabled = false;
        }

        public void SuaKhachHang()
        {
            txt_KH_MaKH.Enabled = false;
            txt_KH_TenKH.Enabled = true;
            dtp_KH_NgaySinh.Enabled = true;
            txt_KH_DiaChi.Enabled = true;
            txt_KH_SDT.Enabled = true;
            txt_KH_Email.Enabled = true;
            cmb_KH_LoaiKH.Enabled = true;
        }

        public void XoaKhachHang()
        {
            try
            {
                string MaKhachHang = txt_KH_MaKH.Text;
                if (MessageBox.Show("Bạn có muốn xóa khách hàng'" + txt_KH_MaKH.Text + "'không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                {
                    khachHang = new DTO.KhachHang(MaKhachHang);
                    khachHangBll.XoaKhachHang(khachHang);
                    //ResetKhachHang();
                    if (ViTri > 0)
                    {
                        dgvKhachHang.CurrentCell = dgvKhachHang.Rows[ViTri - 1].Cells[0];
                        dgvKhachHang.Rows[ViTri - 1].Selected = true;
                        GanGiaTriKhachHang();
                    }
                    LoadDataGridViewKhachHang();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LuuKhachHang()
        {
            if (Them == 1)
            {
                try
                {
                    //Lấy các thông tin khách hàng được nhập từ người dùng                
                    string MaKhachHang = txt_KH_MaKH.Text;
                    string TenKhachHang = txt_KH_TenKH.Text;
                    DateTime NgaySinh = dtp_KH_NgaySinh.Value.Date;
                    string DiaChi = txt_KH_DiaChi.Text;
                    string SDT = txt_KH_SDT.Text;
                    string Email = txt_KH_Email.Text;
                    string LoaiKhachHang = cmb_KH_LoaiKH.Text;

                    //Gọi các hàm kiểm tra ràng buộc cho Khách Hàng
                    KiemTraTenKhachHang();
                    KiemTraNgaySinh();            
                    KiemTraDiaChi();
                    KiemTraEmail();
                    KiemTraSDT();                

                    if (lbl_KH_TenKH.Visible==false && lbl_KH_NgaySinh.Visible==false && lbl_KH_DiaChi.Visible==false && lbl_KH_Email.Visible==false && lbl_KH_SDT.Visible==false)
                    {
                        khachHang = new DTO.KhachHang(MaKhachHang, TenKhachHang, NgaySinh, DiaChi, SDT, Email, LoaiKhachHang);
                        khachHangBll.ThemKhachHang(khachHang);
                        dgvKhachHang.DataSource = khachHangBll.DanhSachKhachHang();
                        LoadDataGridViewKhachHang();
                        MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvKhachHang.Enabled = true;
                    }
                }
                catch 
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Sua == 1)
            {
                try
                {
                    //Lấy các thông tin khách hàng được nhập từ người dùng
                    string MaKhachHang = txt_KH_MaKH.Text;
                    string TenKhachHang = txt_KH_TenKH.Text;
                    DateTime NgaySinh = dtp_KH_NgaySinh.Value.Date;
                    string DiaChi = txt_KH_DiaChi.Text;
                    string SDT = txt_KH_SDT.Text;
                    string Email = txt_KH_Email.Text;
                    string LoaiKhachHang = cmb_KH_LoaiKH.Text;

                    //Gọi các hàm kiểm tra ràng buộc cho khách hàng
                    KiemTraTenKhachHang();
                    KiemTraNgaySinh();
                    KiemTraDiaChi();
                    KiemTraEmail();
                    KiemTraSDT();

                    if (lbl_KH_TenKH.Visible == false && lbl_KH_NgaySinh.Visible == false && lbl_KH_DiaChi.Visible == false && lbl_KH_Email.Visible == false && lbl_KH_SDT.Visible == false)
                    {
                        if (txt_KH_SDT.Text.Length >= 10)
                        {
                            khachHang = new DTO.KhachHang(MaKhachHang, TenKhachHang, NgaySinh, DiaChi, SDT, Email, LoaiKhachHang);
                            khachHangBll.CapNhatKhachHang(khachHang);
                            dgvKhachHang.CurrentCell = dgvKhachHang.Rows[ViTri].Cells[0];
                            dgvKhachHang.Rows[ViTri].Selected = true;
                            GanGiaTriKhachHang();
                            LoadDataGridViewKhachHang();
                            MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                catch 
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void KhoiTaoKhachHang()
        {
            if (txt_KH_TenKH.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;

                txt_KH_TenKH.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_luu.Enabled = false;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;


                txt_KH_MaKH.Enabled = false;
                txt_KH_TenKH.Enabled = false;
                dtp_KH_NgaySinh.Enabled = false;
                txt_KH_DiaChi.Enabled = false;
                txt_KH_SDT.Enabled = false;
                txt_KH_Email.Enabled = false;
                cmb_KH_LoaiKH.Enabled = false;

                pictureBox_KH_TenKH.Visible = false;
                pictureBox_KH_NgaySinh.Visible = false;
                pictureBox_KH_DiaChi.Visible = false;
                pictureBox_KH_SDT.Visible = false;          
                pictureBox_KH_Email.Visible = false;

                lbl_KH_TenKH.Visible = false;
                lbl_KH_NgaySinh.Visible = false;
                lbl_KH_DiaChi.Visible=false;
                lbl_KH_SDT.Visible = false;
                lbl_KH_Email.Visible = false;

                GanGiaTriKhachHang();
                ViTri = dgvKhachHang.CurrentCell.RowIndex;
            }
        }
        
        public void GanGiaTriKhachHang()
        {
            try
            {
                if (this.dgvKhachHang.SelectedRows.Count == 0)
                    return;
                DataGridViewRow dgvr = this.dgvKhachHang.SelectedRows[0];
                GanDieuKienKhachHang(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GanDieuKienKhachHang(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvKhachHang.Rows.Count != 0)
                {
                    this.txt_KH_MaKH.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_KH_TenKH.Text = dgvr.Cells[1].Value.ToString();
                    this.dtp_KH_NgaySinh.Text = dgvr.Cells[2].Value.ToString();
                    this.txt_KH_DiaChi.Text = dgvr.Cells[3].Value.ToString();
                    this.txt_KH_SDT.Text = dgvr.Cells[4].Value.ToString();
                    this.txt_KH_Email.Text = dgvr.Cells[5].Value.ToString();
                    this.cmb_KH_LoaiKH.Text = dgvr.Cells[6].Value.ToString();

                }
                else
                {
                    this.txt_KH_MaKH.Text = " ";
                    this.txt_KH_TenKH.Text = " ";
                    this.dtp_KH_NgaySinh.Text = "";
                    this.txt_KH_DiaChi.Text = " ";
                    this.txt_KH_SDT.Text = " ";
                    this.txt_KH_Email.Text = "";
                    this.cmb_KH_LoaiKH.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            GanGiaTriKhachHang();
            ViTri = dgvKhachHang.CurrentCell.RowIndex;
        }
        #endregion

        #region "Các hàm xử lý Loại Khách Hàng"
        public void LoadDataGridViewLoaiKhachHang()
        {
            try
            {
                this.dgvLoaiKhachHang.AutoGenerateColumns = false;
                this.dgvLoaiKhachHang.DataSource = loaiKhachHangBll.DanhSachLoaiKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string TuTangMaLoaiKhachHang()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = loaiKhachHangBll.DanhSachLoaiKhachHang();
            if (dt.Rows.Count <= 0)//Kiểm tra nếu không có dòng nào thì tự động tăng mã loại khách hàng bằng LKH001
            {
                str = "LKH001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã loại khách hàng
                str = "LKH";//ký tự mặc định của mã loại khách hàng    
                //Lấy 3 kí tự sau cùng trong mã loại khách hàng và chuyển sang kiểu int
                i = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 3));
                i = i + 1;
                if (i < 10)
                    str = str + "00";
                else if (i < 100)
                    str = str + "0";
                str = str + i.ToString();
            }
            return str;
        }

        public void ThemLoaiKhachHang()
        {
            txt_LKH_MaLoaiKhachHang.Text = TuTangMaLoaiKhachHang();
            txt_LKH_TenLoaiKhachHang.Text = "";
            txt_LKH_HeSoGiamGia.Text = "";
            txt_LKH_MaLoaiKhachHang.Enabled = false;
            txt_LKH_TenLoaiKhachHang.Enabled = true;
            txt_LKH_HeSoGiamGia.Enabled = true;
            dgvLoaiKhachHang.Enabled = false;
        }

        public void SuaLoaiKhachHang()
        {
            txt_LKH_MaLoaiKhachHang.Enabled = false;
            txt_LKH_TenLoaiKhachHang.Enabled = true;
            txt_LKH_HeSoGiamGia.Enabled = true;
        }

        public void XoaLoaiKhachHang()
        {
            try
            {
                string MaLoaiKhachHang = txt_LKH_MaLoaiKhachHang.Text;
                if (MessageBox.Show("Bạn có muốn xóa loại khách hàng'" + txt_LKH_TenLoaiKhachHang.Text + "'không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    loaiKhachHang = new LoaiKhachHang(MaLoaiKhachHang);
                    loaiKhachHangBll.XoaLoaiKhachHang(loaiKhachHang);
                    //ResetLoaiKhachHang();
                    if (ViTri > 0)
                    {
                        dgvLoaiKhachHang.CurrentCell = dgvLoaiKhachHang.Rows[ViTri - 1].Cells[0];
                        dgvLoaiKhachHang.Rows[ViTri - 1].Selected = true;
                        GanGiaTriLoaiKhachHang();
                    }
                    LoadDataGridViewLoaiKhachHang();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LuuLoaiKhachHang()
        {
            if (Them == 1)
            {
                try
                {
                    //Lấy các thông tin nhân viên được nhập từ loại khách hàng            
                    string MaLoaiKhachHang = txt_LKH_MaLoaiKhachHang.Text;
                    string TenLoaiKhachHang = txt_LKH_TenLoaiKhachHang.Text;
                    double HeSoGiamGia = 0;

                    if (txt_LKH_HeSoGiamGia.Text != "")
                    {
                        HeSoGiamGia = double.Parse(txt_LKH_HeSoGiamGia.Text);
           
                    }
                      
                    //Gọi hàm kiểm tra ràng buộc cho loại khách hàng
                    KiemTraTenLoaiKhachHang();
                    KiemTraHeSoGiamGia();

                    if (lbl_LKH_TenLKH.Visible==false && lbl_LKH_HeSoGiamGia.Visible==false)
                    {
                        if (double.Parse(txt_LKH_HeSoGiamGia.Text) > 0 && double.Parse(txt_LKH_HeSoGiamGia.Text)<=1)
                        {
                            loaiKhachHang = new LoaiKhachHang(MaLoaiKhachHang, TenLoaiKhachHang, HeSoGiamGia);
                            loaiKhachHangBll.ThemLoaiKhachHang(loaiKhachHang);
                            dgvLoaiKhachHang.DataSource = loaiKhachHangBll.DanhSachLoaiKhachHang();
                            LoadDataGridViewLoaiKhachHang();
                            MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvLoaiKhachHang.Enabled = true;
                        }
                      
                    }
                }

                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Sua == 1)
            {
                try
                {
                    //Lấy các thông tin nhân viên được nhập từ loại khách hàng            
                    string MaLoaiKhachHang = txt_LKH_MaLoaiKhachHang.Text;
                    string TenLoaiKhachHang = txt_LKH_TenLoaiKhachHang.Text;
                    double HeSoGiamGia = 0;

                    if (txt_LKH_HeSoGiamGia.Text != "")
                    {
                        HeSoGiamGia = double.Parse(txt_LKH_HeSoGiamGia.Text);
                    }

                    //Gọi hàm kiểm tra ràng buộc cho loại khách hàng
                    KiemTraTenLoaiKhachHang();
                    KiemTraHeSoGiamGia();

                    if (lbl_LKH_TenLKH.Visible == false && lbl_LKH_HeSoGiamGia.Visible == false)
                    {
                        if (double.Parse(txt_LKH_HeSoGiamGia.Text) > 0 && double.Parse(txt_LKH_HeSoGiamGia.Text) <= 1)
                        {
                            loaiKhachHang = new LoaiKhachHang(MaLoaiKhachHang, TenLoaiKhachHang, HeSoGiamGia);
                            loaiKhachHangBll.CapNhatLoaiKhachHang(loaiKhachHang);
                            dgvLoaiKhachHang.CurrentCell = dgvLoaiKhachHang.Rows[ViTri].Cells[0];
                            dgvLoaiKhachHang.Rows[ViTri].Selected = true;
                            GanGiaTriLoaiKhachHang();
                            LoadDataGridViewLoaiKhachHang();
                            MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch 
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void KhoiTaoLoaiKhachHang()
        {
            if (txt_LKH_TenLoaiKhachHang.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
                txt_LKH_TenLoaiKhachHang.Enabled = true;
                txt_LKH_HeSoGiamGia.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_luu.Enabled = false;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;


                txt_LKH_MaLoaiKhachHang.Enabled = false;
                txt_LKH_TenLoaiKhachHang.Enabled = false;
                txt_LKH_HeSoGiamGia.Enabled = false;

                lbl_LKH_TenLKH.Visible = false;
                lbl_LKH_HeSoGiamGia.Visible = false;

                pictureBox_LKH_TenLKH.Visible = false;
                pictureBox_LKH_HeSoGiamGia.Visible = false;              

                GanGiaTriLoaiKhachHang();
                ViTri = dgvLoaiKhachHang.CurrentCell.RowIndex;
            }
        }

        public void GanGiaTriLoaiKhachHang()
        {
            try
            {
                if (this.dgvLoaiKhachHang.SelectedRows.Count == 0)
                    return;
                DataGridViewRow dgvr = this.dgvLoaiKhachHang.SelectedRows[0];
                GanDieuKienLoaiKhachHang(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GanDieuKienLoaiKhachHang(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvLoaiKhachHang.Rows.Count != 0)
                {
                    this.txt_LKH_MaLoaiKhachHang.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_LKH_TenLoaiKhachHang.Text = dgvr.Cells[1].Value.ToString();
                    this.txt_LKH_HeSoGiamGia.Text = dgvr.Cells[2].Value.ToString();
                }
                else
                {
                    this.txt_LKH_MaLoaiKhachHang.Text = " ";
                    this.txt_LKH_TenLoaiKhachHang.Text = "";
                    this.txt_LKH_HeSoGiamGia.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvLoaiKhachHang_Click(object sender, EventArgs e)
        {
            GanGiaTriLoaiKhachHang();
            ViTri = dgvLoaiKhachHang.CurrentCell.RowIndex;
        }
        #endregion

        #region "Kiểm tra các ràng buộc thuộc khách hàng"
        //Hàm kiểm tra khi đang nhập tên khách hàng
        private void txt_KH_TenKH_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                pictureBox_KH_TenKH.Visible = true;
                pictureBox_KH_TenKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                lbl_KH_TenKH.Visible = true;
                lbl_KH_TenKH.Text = "Tên khách hàng không có chữ số hoặc ký tự đặc biệt!";
                e.Handled = true;
            }
            else
            {
                pictureBox_KH_TenKH.Visible = false;
                lbl_KH_TenKH.Visible = false;
            }
        }

        //Hàm kiểm tra khi đang nhập ngày sinh
        private void dtp_KH_NgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox_KH_NgaySinh.Visible = false;
            lbl_KH_NgaySinh.Visible = false;
        }

        //Hàm kiểm tra khi đang nhập địa chỉ
        private void txt_KH_DiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox_KH_DiaChi.Visible = false;
            lbl_KH_DiaChi.Visible = false;
        }

        //Hàm kiểm tra khi đang nhập email
        private void txt_KH_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            lbl_KH_Email.Visible = false;
            pictureBox_KH_Email.Visible = false;
        }

        //Hàm kiểm tra khi đang nhập số điện thoại
        private void txt_KH_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                lbl_KH_SDT.Text = "Số điện thoại không được có chữ cái!";
                lbl_KH_SDT.Visible = true;
                pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_SDT.Visible = true;
            }
            else
            {
                pictureBox_KH_SDT.Visible = false;
                lbl_KH_SDT.Visible = false;
            }
        }

        //Hàm kiểm tra nhập tên khách hàng
        public void KiemTraTenKhachHang()
        {
            if (txt_KH_TenKH.Text == "")
            {
                pictureBox_KH_TenKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_TenKH.Visible = true;
                lbl_KH_TenKH.Text = "Bạn chưa nhập tên khách hàng!";
                lbl_KH_TenKH.Visible = true;
            }
            else
            {
                pictureBox_KH_TenKH.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_KH_TenKH.Visible = true;
                lbl_KH_TenKH.Visible = false;
            }
        }

        //Hàm kiểm tra nhập số điện thoại
        public void KiemTraSDT()
        {
            DataTable dt = new DataTable();
            dt = khachHangBll.DanhSachKhachHang();
            int kiemTra = 0;

            if (txt_KH_SDT.Text == "")
            {
                pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_SDT.Visible = true;
                lbl_KH_SDT.Text = "Chưa nhập số điện thoại!";
                lbl_KH_SDT.Visible = true;
            }
            if (txt_KH_SDT.Text != "" && txt_KH_SDT.Text.Length < 10)
            {
                pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_SDT.Visible = true;
                lbl_KH_SDT.Text = "SDT tối thiểu 10 chữ số!";
                lbl_KH_SDT.Visible = true;
            }
            if(Them==1)
            {
                if (txt_KH_SDT.Text != "" && txt_KH_SDT.Text.Length >= 10)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][4].ToString().Equals(txt_KH_SDT.Text))
                        {
                            pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_KH_SDT.Visible = true;
                            lbl_KH_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_KH_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if(Sua==1)
            {
                if (txt_KH_SDT.Text != "" && txt_KH_SDT.Text.Length >= 10)
                {
                    for (int i = 0; i < dgvKhachHang.CurrentCell.RowIndex; i++)
                    {
                        if (dgvKhachHang.Rows[i].Cells[4].Value.ToString().Equals(txt_KH_SDT.Text))
                        {
                            pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_KH_SDT.Visible = true;
                            lbl_KH_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_KH_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvKhachHang.CurrentCell.RowIndex + 1; i < dgvKhachHang.Rows.Count; i++)
                    {
                        if (dgvKhachHang.Rows[i].Cells[4].Value.ToString().Equals(txt_KH_SDT.Text))
                        {
                            pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_KH_SDT.Visible = true;
                            lbl_KH_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_KH_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }              
            }
            if ((txt_KH_SDT.Text.Length >= 10 && kiemTra == 0))
            {
                pictureBox_KH_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_KH_SDT.Visible = true;
                lbl_KH_SDT.Visible = false;
            }
        }

        //Hàm kiểm tra nhập ngày sinh
        public void KiemTraNgaySinh()
        {
            do
            {
                int namHienTai = DateTime.Now.Year;
                int namKhachHang = dtp_KH_NgaySinh.Value.Year;
                tuoi = namHienTai - namKhachHang;
                if (tuoi < 15)
                {
                    pictureBox_KH_NgaySinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                    pictureBox_KH_NgaySinh.Visible = true;
                    lbl_KH_NgaySinh.Text = "Bạn phải trên 15 tuổi!";
                    lbl_KH_NgaySinh.Visible = true;
                    dtp_KH_NgaySinh.Enabled = true;
                }
            } while (false);

            if (tuoi > 15)
            {
                pictureBox_KH_NgaySinh.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_KH_NgaySinh.Visible = true;
                lbl_KH_NgaySinh.Visible = false;
            }
        }

        //Hàm kiểm tra nhập email
        public void KiemTraEmail()
        {
            DataTable dt = new DataTable();
            dt = khachHangBll.DanhSachKhachHang();
            int kiemTra = 0;

            if (txt_KH_Email.Text == "")
            {
                pictureBox_KH_Email.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_Email.Visible = true;
                lbl_KH_Email.Visible = true;
                lbl_KH_Email.Text = "Chưa nhập email";
            }
            if (txt_KH_Email.Text != "" && txt_KH_Email.Text.Length <10)
            {
                pictureBox_KH_Email.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_Email.Visible = true;
                lbl_KH_Email.Visible = true;
                lbl_KH_Email.Text = "Email phải có dạng: abc@gmail.com!";
            }
            if (Them == 1)
            {
                if (txt_KH_Email.Text != "" && txt_KH_Email.Text.Length >= 10)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][5].ToString().Equals(txt_KH_Email.Text))
                        {
                            pictureBox_KH_Email.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_KH_Email.Visible = true;
                            lbl_KH_Email.Text = "Email đã tồn tại!";
                            lbl_KH_Email.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_KH_Email.Text != "" && txt_KH_Email.Text.Length >= 10)
                {
                    for (int i = 0; i < dgvKhachHang.CurrentCell.RowIndex; i++)
                    {
                        if (dgvKhachHang.Rows[i].Cells[5].Value.ToString().Equals(txt_KH_Email.Text))
                        {
                            pictureBox_KH_Email.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_KH_Email.Visible = true;
                            lbl_KH_Email.Text = "Email đã tồn tại!";
                            lbl_KH_Email.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvKhachHang.CurrentCell.RowIndex + 1; i < dgvKhachHang.Rows.Count; i++)
                    {
                        if (dgvKhachHang.Rows[i].Cells[5].Value.ToString().Equals(txt_KH_Email.Text))
                        {
                            pictureBox_KH_Email.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_KH_Email.Visible = true;
                            lbl_KH_Email.Text = "Email đã tồn tại!";
                            lbl_KH_Email.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (txt_KH_Email.Text != "" && txt_KH_Email.Text.Length >= 10 && kiemTra == 0)
            {
                pictureBox_KH_Email.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_KH_Email.Visible = true;
                lbl_KH_Email.Visible = false;
            }
        }

        //Hàm kiểm tra nhập địa chỉ
        public void KiemTraDiaChi()
        {
            if (txt_KH_DiaChi.Text == "")
            {
                pictureBox_KH_DiaChi.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_DiaChi.Visible = true;
                lbl_KH_DiaChi.Visible = true;
                lbl_KH_DiaChi.Text = "Chưa nhập địa chỉ!";
            }
            else if (txt_KH_DiaChi.Text.Length < 2)
            {
                pictureBox_KH_DiaChi.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_KH_DiaChi.Visible = true;
                lbl_KH_DiaChi.Visible = true;
                lbl_KH_DiaChi.Text = "Địa chỉ phải từ 2 kí tự trở lên!";
            }
            else
            {
                pictureBox_KH_DiaChi.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_KH_DiaChi.Visible = true;
                lbl_KH_DiaChi.Visible = false;
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc thuộc loại khách hàng"
        //Hàm kiểm tra tên loại khách hàng
        public void KiemTraTenLoaiKhachHang()
        {
            int kiemTra = 0;
            DataTable dt = new DataTable();
            dt = loaiKhachHangBll.DanhSachLoaiKhachHang();

            if (txt_LKH_TenLoaiKhachHang.Text == "")
            {
                pictureBox_LKH_TenLKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_LKH_TenLKH.Visible = true;
                lbl_LKH_TenLKH.Text = "Bạn chưa nhập tên loại khách hàng!";
                lbl_LKH_TenLKH.Visible = true;
            }
            if (Them == 1)
            {
                if (txt_LKH_TenLoaiKhachHang.Text != "")
                {
                    for (int i = 0; i < dgvLoaiKhachHang.Rows.Count; i++)
                    {
                        if (txt_LKH_TenLoaiKhachHang.Text.Trim().ToLower().Equals(dgvLoaiKhachHang.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_LKH_TenLKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_LKH_TenLKH.Visible = true;
                            lbl_LKH_TenLKH.Text = "Tên loại khách hàng đã tồn tại!";
                            lbl_LKH_TenLKH.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_LKH_TenLoaiKhachHang.Text != "")
                {
                    for (int i = 0; i < dgvLoaiKhachHang.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_LKH_TenLoaiKhachHang.Text.Trim().ToLower().Equals(dgvLoaiKhachHang.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_LKH_TenLKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_LKH_TenLKH.Visible = true;
                            lbl_LKH_TenLKH.Text = "Tên loại khách hàng đã tồn tại!";
                            lbl_LKH_TenLKH.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvLoaiKhachHang.CurrentCell.RowIndex + 1; i < dgvLoaiKhachHang.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_LKH_TenLoaiKhachHang.Text.Trim().ToLower().Equals(dgvLoaiKhachHang.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_LKH_TenLKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_LKH_TenLKH.Visible = true;
                            lbl_LKH_TenLKH.Text = "Tên loại khách hàng đã tồn tại!";
                            lbl_LKH_TenLKH.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (txt_LKH_TenLoaiKhachHang.Text != "" && kiemTra == 0)      
            {
                pictureBox_LKH_TenLKH.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_LKH_TenLKH.Visible = true;
                lbl_LKH_TenLKH.Visible = false;
            }
        }

        //Hàm kiểm tra hệ số giảm giá
        public void KiemTraHeSoGiamGia()
        {
            if (txt_LKH_HeSoGiamGia.Text == "")
            {
                pictureBox_LKH_HeSoGiamGia.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_LKH_HeSoGiamGia.Visible = true;
                lbl_LKH_HeSoGiamGia.Text = "Bạn chưa nhập hệ số giảm giá!";
                lbl_LKH_HeSoGiamGia.Visible = true;
            }
            if (txt_LKH_HeSoGiamGia.Text != "" && (double.Parse(txt_LKH_HeSoGiamGia.Text) <= 0 || double.Parse(txt_LKH_HeSoGiamGia.Text) > 1))
            {
                pictureBox_LKH_HeSoGiamGia.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_LKH_HeSoGiamGia.Visible = true;
                lbl_LKH_HeSoGiamGia.Text = "Hệ số giảm giá phải lớn hơn 0 và nhỏ hơn hoặc bằng 1!";
                lbl_LKH_HeSoGiamGia.Visible = true;
                txt_LKH_HeSoGiamGia.Enabled = true;
            }
            if (txt_LKH_HeSoGiamGia.Text != "" && double.Parse(txt_LKH_HeSoGiamGia.Text) > 0 && double.Parse(txt_LKH_HeSoGiamGia.Text) <= 1)
            {
                pictureBox_LKH_HeSoGiamGia.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_LKH_HeSoGiamGia.Visible = true;
                lbl_LKH_HeSoGiamGia.Visible = false;
            }    
        }

        //Hàm kiểm tra tên loại khách hàng khi đang nhập dữ liệu
        private void txt_LKH_TenLoaiKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {           
                pictureBox_LKH_TenLKH.Visible = true;
                lbl_LKH_TenLKH.Visible = true;
                lbl_LKH_TenLKH.Text = "Loại khách hàng không có chữ số hoặc ký tự đặc biệt!";
                e.Handled = true;
            }
            else
            {
                pictureBox_LKH_TenLKH.Visible = false;
                lbl_LKH_TenLKH.Visible = false;

            }
        }

        //Hàm kiểm tra hệ số giảm giá khi đang nhập dữ liệu
        private void txt_LKH_HeSoGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
               (e.KeyChar == '.' && (txt_LKH_HeSoGiamGia.Text.Length == 0 || txt_LKH_HeSoGiamGia.Text.IndexOf('.') != -1))))
            {
                e.Handled = true;
                lbl_LKH_HeSoGiamGia.Text = "Hệ số giảm giá không được có chữ cái hoặc kí tự đặc biệt!";
                lbl_LKH_HeSoGiamGia.Visible = true;
                pictureBox_LKH_HeSoGiamGia.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_LKH_HeSoGiamGia.Visible = true;
            }
            else
            {
                pictureBox_LKH_HeSoGiamGia.Visible = false;
                lbl_LKH_HeSoGiamGia.Visible = false;
            }
        }

        #endregion

        #region "Tìm kiếm cho khách hàng"
        private void btn_KH_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = khachHangBll.TimKiemKhachHang(txt_KH_TimKiem.Text);
                dgvKhachHang.DataSource = dt;
                if (dgvKhachHang.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_KH_TimKiem.Text = null;
                    txt_KH_TimKiem.Focus();
                    LoadDataGridViewKhachHang();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }

        }
        #endregion

        #region "Tìm kiếm cho loại khách hàng"
        private void btn_LKH_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = loaiKhachHangBll.TimKiemLoaiKhachHang(txt_LKH_TimKiem.Text);
                dgvLoaiKhachHang.DataSource = dt;
                if (dgvLoaiKhachHang.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_LKH_TimKiem.Text = null;
                    txt_LKH_TimKiem.Focus();
                    LoadDataGridViewLoaiKhachHang();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }
        }
        #endregion

        private void txt_KH_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_KH_TimKiem.PerformClick();
        }

        private void txt_LKH_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_LKH_TimKiem.PerformClick();
        }


    }
}
