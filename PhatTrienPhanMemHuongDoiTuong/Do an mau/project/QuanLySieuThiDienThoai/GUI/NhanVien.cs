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
    public partial class NhanVien : UserControl
    {
        NhanVienBll nhanVienBll = new NhanVienBll();
        PhongBanBll phongBanBll = new PhongBanBll();
        GioiTinhBll gioiTinhBll = new GioiTinhBll();
        DTO.NhanVien nhanVien;
        DTO.PhongBan phongBan;
        DTO.GioiTinh gioiTinh;
        int ViTri = 0;//Biến lấy vị trí dòng trên DataGridView
        int ChucNang = 0;//Biến này có tác dụng thay đổi chức năng khi chuyển đổi từ Nhân Viên qua Phòng Ban
        int Them = 0;//Biến kiểm tra khi thêm
        int Sua = 0;//Biến kiểm tra khi sửa
        int tuoi = 0;//Biến kiểm tra tuổi nhân viên
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridViewNhanVien();
            LoadDataGridViewPhongBan();
            LoadDataGridViewGioiTinh();

            cmb_NV_PB.DataSource = phongBanBll.SelectTenPhongBan();
            cmb_NV_PB.ValueMember = "TenPhong";
            cmb_NV_GioiTinh.DataSource = gioiTinhBll.SelectTenGioiTinh();
            cmb_NV_GioiTinh.ValueMember = "MaGioiTinh";
            cmb_NV_GioiTinh.DisplayMember = "TenGioiTinh";

            ChucNang = 1;
            Fresh();
        }

        //Hàm Reset lại các field cho Nhân Viên và Phòng Ban
        public void Fresh()
        {
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = true;
            btn_huy.Enabled = false;
            btn_sua.Enabled = true;
            btn_NV_Picture.Enabled = false;

            if (ChucNang == 1)
            {
                txt_NV_MaNV.Enabled = false;
                txt_NV_TenNhanVien.Enabled = false;
                dtp_NV_NgaySinh.Enabled = false;
                cmb_NV_GioiTinh.Enabled = false;
                txt_NV_CMND.Enabled = false;
                txt_NV_DiaChi.Enabled = false;
                txt_NV_SDT.Enabled = false;
                cmb_NV_PB.Enabled = false;
                txt_NV_TenDangNhap.Enabled = false;
                txt_NV_MatKhau.Enabled = false;
                txt_NV_TimKiem.Text = null;

                lbl_NV_TenNhanVien.Visible = false;
                lbl_NV_NgaySinh.Visible = false;
                lbl_NV_SDT.Visible = false;
                lbl_NV_CMND.Visible = false;
                lbl_NV_TenDangNhap.Visible = false;
                lbl_NV_MatKhau.Visible = false;

                pictureBox_NV_TenNhanVien.Visible = false;
                pictureBox_NV_NgaySinh.Visible = false;
                pictureBox_NV_SDT.Visible = false;
                pictureBox_NV_CMND.Visible = false;
                pictureBox_NV_TenDangNhap.Visible = false;
                pictureBox_NV_MatKhau.Visible = false;
            }
            if (ChucNang == 2)
            {
                txt_PB_MaPhong.Enabled = false;
                txt_PB_TenPhong.Enabled = false;
                txt_PB_TimKiem.Text = null;
                pictureBox_PB_TenPhongBan.Visible = false;
                lbl_PB_TenPhongBan.Visible = false;
            }
            if (ChucNang == 3)
            {
                txt_GT_MaGioiTinh.Enabled = false;
                txt_GT_TenGioiTinh.Enabled = false;
                pictureBox_GT_TenGioiTinh.Visible = false;
                lbl_GT_TenGioiTinh.Visible = false;
            }
        }

        //Hàm mã hóa mật khẩu
        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }

        private void backstageViewTabItem_nhanvien_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 1;
            FreshNhanVien();
            cmb_NV_PB.DataSource = phongBanBll.SelectTenPhongBan();
            cmb_NV_PB.ValueMember = "TenPhong";
            cmb_NV_GioiTinh.DataSource = gioiTinhBll.SelectTenGioiTinh();
            cmb_NV_GioiTinh.ValueMember = "MaGioiTinh";
            cmb_NV_GioiTinh.DisplayMember = "TenGioiTinh";
            Fresh();
            LoadDataGridViewNhanVien();
        }

        private void backstageViewTabItem_phongban_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 2;
            FreshPhongBan();
            Fresh();
            LoadDataGridViewPhongBan();
        }

        private void backstageViewTabItem_gioitinh_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 3;
            FreshGioiTinh();
            Fresh();
            LoadDataGridViewGioiTinh();
        }

        #region "Xử lý Thêm, Xóa, Sửa, Hủy, Lưu"
        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_huy.Enabled = true;
            btn_them.Enabled = false;
            btn_sua.Enabled = false;
            btn_NV_Picture.Enabled = true;
            Them = 1;
            Sua = 0;
            if (ChucNang == 1)
            {
                ThemNhanVien();
            }
            if (ChucNang == 2)
            {
                ThemPhongBan();
            }
            if (ChucNang == 3)
            {
                ThemGioiTinh();
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)//Chức năng bằng 1 tức là đang ở tab Nhân Viên
            {
                LuuNhanVien();//Gọi hàm lưu nhân viên
                if (txt_NV_TenNhanVien.Text != "" && tuoi > 18 && txt_NV_TenDangNhap.Text != "" && txt_NV_MatKhau.Text != "")
                {
                    if (((txt_NV_SDT.Text.Length >= 10) && (lbl_NV_SDT.Visible == false) || txt_NV_SDT.Text == "") && ((txt_NV_CMND.Text.Length == 9) && (lbl_NV_CMND.Visible == false) || txt_NV_CMND.Text == "") && lbl_NV_TenDangNhap.Visible == false)
                    {
                        FreshNhanVien();
                        this.ActiveControl = null;
                    }
                        
                }
            }
            if (ChucNang == 2)//Chức năng bằng 2 tức là đang ở tab Phòng Ban
            {
                LuuPhongBan();//Gọi hàm lưu phòng ban
                if (txt_PB_TenPhong.Text != "" && lbl_PB_TenPhongBan.Visible == false)
                {
                    FreshPhongBan();
                    this.ActiveControl = null;
                }                
            }
            if (ChucNang == 3)//Chức năng bằng 3 tức là đang ở tab Giới tính
            {
                LuuGioiTinh();//Gọi hàm lưu giới tính
                if (txt_GT_TenGioiTinh.Text != "")
                    FreshGioiTinh();
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                XoaNhanVien();//Gọi hàm xóa nhân viên
            }
            if (ChucNang == 2)
            {
                XoaPhongBan();//Gọi hàm xóa phòng ban
            }
            if (ChucNang == 3)
            {
                XoaGioiTinh();//Gọi hàm xóa giới tính
            }
        }

        private void btn_huy_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)//Chức năng bằng 1 tức là đang ở tab Nhân Viên
            {
                Fresh();//Gọi hàm fresh chung cho cả 2 tab nhân viên và phòng ban
                dgvNhanVien.Enabled = true;
                GanGiaTriNhanVien();//Gọi hàm gán giá trị từ DataGridView lên từng TextBox tương ứng 
                ViTri = dgvNhanVien.CurrentCell.RowIndex;

            }
            if (ChucNang == 2)//Chức năng bằng 2 tức là đang ở tab Phòng Ban
            {
                Fresh();
                dgvPhongBan.Enabled = true;
                GanGiaTriPhongBan();
                ViTri = dgvPhongBan.CurrentCell.RowIndex;
            }
            if (ChucNang == 3)//Chức năng bằng 3 tức là đang ở tab giới tính
            {
                Fresh();
                dgvGioiTinh.Enabled = true;
                GanGiaTriGioiTinh();
                ViTri = dgvGioiTinh.CurrentCell.RowIndex;
            }
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            btn_them.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_huy.Enabled = true;
            btn_sua.Enabled = false;
            btn_NV_Picture.Enabled = true;
            Sua = 1;
            Them = 0;

            if (ChucNang == 1)
            {
                SuaNhanVien();//Gọi hàm sửa nhân viên
            }
            if (ChucNang == 2)
            {
                SuaPhongBan();//Gọi hàm sửa phòng ban
            }
            if (ChucNang == 3)
            {
                SuaGioiTinh();//Gọi hàm sửa giới tính
            }
        }

        #endregion

        #region "Các hàm xử lý Nhân Viên"
        //Hàm load DataGridView Nhân Viên
        public void LoadDataGridViewNhanVien()
        {
            try
            {
                this.dgvNhanVien.AutoGenerateColumns = false;
                dgvNhanVien.DataSource = nhanVienBll.SelectAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm tự tăng mã nhân viên khi thêm
        public string TuTangMaNhanVien()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = nhanVienBll.SelectAllNhanVien();
            if (dt.Rows.Count <= 0)//Kiểm tra nếu không có dòng nào thì tự động tăng mã nhân viên bằng NV001
            {
                str = "NV001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã nhân viên
                str = "NV";//ký tự mặc định của mã nhân viên    
                //Lấy 3 kí tự sau cùng trong mã nhân viên và chuyển sang kiểu int
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

        //Hàm xử lý thêm nhân viên
        public void ThemNhanVien()
        {
            txt_NV_MaNV.Text = TuTangMaNhanVien();
            txt_NV_TenNhanVien.Text = "";
            txt_NV_DiaChi.Text = "";
            txt_NV_CMND.Text = "";
            txt_NV_SDT.Text = "";
            txt_NV_TenDangNhap.Text = "";
            txt_NV_MatKhau.Text = "";
            pictureBox.Image = QuanLySieuThiDienThoai.Properties.Resources.default_avatar;
            dtp_NV_NgaySinh.Text = "";
            //cmb_NV_GioiTinh.Text = "Nam";

            txt_NV_MaNV.Enabled = false;
            txt_NV_TenNhanVien.Enabled = true;
            dtp_NV_NgaySinh.Enabled = true;
            cmb_NV_GioiTinh.Enabled = true; ;
            txt_NV_CMND.Enabled = true;
            txt_NV_DiaChi.Enabled = true;
            txt_NV_SDT.Enabled = true;
            cmb_NV_PB.Enabled = true;
            txt_NV_TenDangNhap.Enabled = true;
            txt_NV_MatKhau.Enabled = true;
            dgvNhanVien.Enabled = false;
        }

        //Hàm xử lý sửa nhân viên
        public void SuaNhanVien()
        {
            txt_NV_MaNV.Enabled = false;
            txt_NV_TenNhanVien.Enabled = true;
            dtp_NV_NgaySinh.Enabled = true;
            cmb_NV_GioiTinh.Enabled = true;
            txt_NV_CMND.Enabled = true;
            txt_NV_DiaChi.Enabled = true;
            txt_NV_SDT.Enabled = true;
            cmb_NV_PB.Enabled = true;
            txt_NV_TenDangNhap.Enabled = true;
            txt_NV_MatKhau.Enabled = true;

        }

        //Hàm xử lý xóa nhân viên
        public void XoaNhanVien()
        {
            try
            {
                string MaNhanVien = txt_NV_MaNV.Text;
                if (MessageBox.Show("Bạn có muốn xóa nhân viên '" + txt_NV_MaNV.Text + "' không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                {
                    nhanVien = new DTO.NhanVien(MaNhanVien);
                    nhanVienBll.DeleteNhanVien(nhanVien);
                    //ResetNhanVien();
                    if (ViTri > 0)
                    {
                        dgvNhanVien.CurrentCell = dgvNhanVien.Rows[ViTri - 1].Cells[0];
                        dgvNhanVien.Rows[ViTri - 1].Selected = true;
                        GanGiaTriNhanVien();
                    }
                    LoadDataGridViewNhanVien();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //Hàm xử lý lưu nhân viên
        public void LuuNhanVien()
        {
            if (Them == 1)
            {
                try
                {
                    //Lấy ảnh từ Database và lưu ảnh xuống Database
                    MemoryStream stream = new MemoryStream();
                    pictureBox.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] Hinh = stream.ToArray();

                    //Lấy các thông tin nhân viên được nhập từ người dùng            
                    string MaNhanVien = txt_NV_MaNV.Text;
                    string TenNhanVien = txt_NV_TenNhanVien.Text;
                    //DateTime NgaySinh = DateTime.Parse(dtp_NV_NgaySinh.Text);
                    DateTime NgaySinh = dtp_NV_NgaySinh.Value.Date;
                    string GioiTinh = cmb_NV_GioiTinh.Text;
                    string CMND = txt_NV_CMND.Text;
                    string DiaChi = txt_NV_DiaChi.Text;
                    string SDT = txt_NV_SDT.Text;
                    string PhongBan = cmb_NV_PB.SelectedValue.ToString();
                    string TenDangNhap = txt_NV_TenDangNhap.Text;
                    string MatKhau = GetMD5(txt_NV_MatKhau.Text);


                    //Gọi các hàm kiểm tra ràng buộc cho Nhân Viên
                    KiemTraTenNhanVien();
                    KiemTraNgaySinh();
                    KiemTraSDT();
                    KiemTraCMND();
                    KiemTraTenDangNhap();
                    KiemTraMatKhau();

                    if (txt_NV_TenNhanVien.Text != "" && tuoi > 18 && txt_NV_TenDangNhap.Text != "" && txt_NV_MatKhau.Text != "")
                    {
                        if (lbl_NV_SDT.Visible == false && lbl_NV_CMND.Visible == false && lbl_NV_TenDangNhap.Visible == false)//lbl_NV_CMND.Visible == false
                        {
                            nhanVien = new DTO.NhanVien(MaNhanVien, TenNhanVien, NgaySinh, GioiTinh, CMND, DiaChi, SDT, Hinh, PhongBan, TenDangNhap, MatKhau);
                            nhanVienBll.InsertNhanVien(nhanVien);
                            dgvNhanVien.DataSource = nhanVienBll.SelectAllNhanVien();
                            LoadDataGridViewNhanVien();
                            MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvNhanVien.Enabled = true;
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
                    //Lấy ảnh từ Database và lưu lại ảnh nếu có thay đổi
                    MemoryStream stream = new MemoryStream();
                    pictureBox.Image.Save(stream, ImageFormat.Jpeg);
                    byte[] Hinh = stream.ToArray();

                    //Lấy các thông tin nhân viên được nhập từ người dùng
                    string MaNhanVien = txt_NV_MaNV.Text;
                    string TenNhanVien = txt_NV_TenNhanVien.Text;
                    DateTime NgaySinh = dtp_NV_NgaySinh.Value.Date;
                    string GioiTinh = cmb_NV_GioiTinh.Text;
                    string CMND = txt_NV_CMND.Text;
                    string DiaChi = txt_NV_DiaChi.Text;
                    string SDT = txt_NV_SDT.Text;
                    string PhongBan = cmb_NV_PB.SelectedValue.ToString();
                    string TenDangNhap = txt_NV_TenDangNhap.Text;
                    string MatKhau = GetMD5(txt_NV_MatKhau.Text);

                    //Gọi các hàm kiểm tra ràng buộc cho nhân viên
                    KiemTraTenNhanVien();
                    KiemTraNgaySinh();
                    KiemTraSDT();
                    KiemTraCMND();
                    KiemTraTenDangNhap();
                    KiemTraMatKhau();

                    if (txt_NV_TenNhanVien.Text != "" && tuoi > 18 && txt_NV_TenDangNhap.Text != "" && txt_NV_MatKhau.Text != "")
                    {
                        if ((txt_NV_SDT.Text.Length >= 10 || txt_NV_SDT.Text == "") && (txt_NV_CMND.Text.Length == 9 || txt_NV_CMND.Text == ""))
                        {
                            if (lbl_NV_SDT.Visible == false && lbl_NV_CMND.Visible == false && lbl_NV_TenDangNhap.Visible == false)
                            {
                                nhanVien = new DTO.NhanVien(MaNhanVien, TenNhanVien, NgaySinh, GioiTinh, CMND, DiaChi, SDT, Hinh, PhongBan, TenDangNhap, MatKhau);
                                nhanVienBll.UpdateNhanVien(nhanVien);
                                dgvNhanVien.CurrentCell = dgvNhanVien.Rows[ViTri].Cells[0];
                                dgvNhanVien.Rows[ViTri].Selected = true;
                                GanGiaTriNhanVien();
                                LoadDataGridViewNhanVien();
                                MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Hàm xử lý làm mới nhân viên
        public void FreshNhanVien()
        {
            if (txt_NV_TenNhanVien.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
             
                txt_NV_TenNhanVien.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_luu.Enabled = false;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;
                btn_NV_Picture.Enabled = false;

                txt_NV_MaNV.Enabled = false;
                txt_NV_TenNhanVien.Enabled = false;
                dtp_NV_NgaySinh.Enabled = false;
                cmb_NV_GioiTinh.Enabled = false;
                txt_NV_CMND.Enabled = false;
                txt_NV_DiaChi.Enabled = false;
                txt_NV_SDT.Enabled = false;
                cmb_NV_PB.Enabled = false;
                txt_NV_TenDangNhap.Enabled = false;
                txt_NV_MatKhau.Enabled = false;
        

                pictureBox_NV_TenNhanVien.Visible = false;
                pictureBox_NV_NgaySinh.Visible = false;
                pictureBox_NV_SDT.Visible = false;
                pictureBox_NV_CMND.Visible = false;
                pictureBox_NV_TenDangNhap.Visible = false;
                pictureBox_NV_MatKhau.Visible = false;

                GanGiaTriNhanVien();
                ViTri = dgvNhanVien.CurrentCell.RowIndex;
            }
        }

        //Hàm xử lý gán giá trị từ DataGridView lên các TextBox trong tab Nhân Viên
        public void GanGiaTriNhanVien()
        {
            try
            {
                if (this.dgvNhanVien.SelectedRows.Count == 0)
                    return;
                DataGridViewRow dgvr = this.dgvNhanVien.SelectedRows[0];
                GanDieuKienNhanVien(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm xử lý đảm bảo gán đúng các giá trị tương ứng với các TextBox tương ứng trong tab Nhân Viên
        public void GanDieuKienNhanVien(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvNhanVien.Rows.Count != 0)
                {
                    this.txt_NV_MaNV.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_NV_TenNhanVien.Text = dgvr.Cells[1].Value.ToString();
                    this.dtp_NV_NgaySinh.Text = dgvr.Cells[2].Value.ToString();
                    this.cmb_NV_GioiTinh.Text = dgvr.Cells[3].Value.ToString();
                    this.txt_NV_CMND.Text = dgvr.Cells[4].Value.ToString();
                    this.txt_NV_DiaChi.Text = dgvr.Cells[5].Value.ToString();
                    this.txt_NV_SDT.Text = dgvr.Cells[6].Value.ToString();
                    this.cmb_NV_PB.Text = dgvr.Cells[7].Value.ToString();
                    this.txt_NV_TenDangNhap.Text = dgvr.Cells[8].Value.ToString();
                    this.txt_NV_MatKhau.Text = "******";
                }
                else
                {
                    this.txt_NV_MaNV.Text = "";
                    this.txt_NV_TenNhanVien.Text = "";
                    this.dtp_NV_NgaySinh.Text = "";
                    this.cmb_NV_GioiTinh.Text = "";
                    this.txt_NV_CMND.Text = "";
                    this.txt_NV_DiaChi.Text = "";
                    this.txt_NV_SDT.Text = "";
                    this.cmb_NV_PB.Text = "";
                    this.txt_NV_TenDangNhap.Text = "";
                    this.txt_NV_MatKhau.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm xử lý gán giá trị nhân viên khi chọn các dòng khác nhau trên DataGridView
        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            GanGiaTriNhanVien();
            ViTri = dgvNhanVien.CurrentCell.RowIndex;
            try
            {
                byte[] MyData = new byte[0];
                MyData = (byte[])dgvNhanVien.Rows[ViTri].Cells[10].Value;
                MemoryStream stream = new MemoryStream(MyData);
                pictureBox.Image = Image.FromStream(stream);
            }
            catch
            {
                pictureBox.Image = QuanLySieuThiDienThoai.Properties.Resources.default_avatar;
            }
        }
        #endregion

        #region "Các hàm xử lý Phòng Ban"
        //Hàm load DataGridView Phòng Ban 
        public void LoadDataGridViewPhongBan()
        {
            try
            {
                this.dgvPhongBan.AutoGenerateColumns = false;
                this.dgvPhongBan.DataSource = phongBanBll.SelectAllPhongBan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm tự tăng mã phòng ban khi thêm
        public string TuTangMaPhongBan()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = phongBanBll.SelectAllPhongBan();
            if (dt.Rows.Count <= 0)//Kiểm tra nếu không có dòng nào thì tự động tăng mã phòng ban bằng PB001
            {
                str = "PB001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã phòng ban
                str = "PB";//ký tự mặc định của mã phòng ban 
                //Lấy 3 kí tự sau cùng trong mã phòng ban và chuyển sang kiểu int
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

        //Hàm xử lý thêm phòng ban
        public void ThemPhongBan()
        {
            txt_PB_MaPhong.Text = TuTangMaPhongBan();
            txt_PB_TenPhong.Text = "";

            txt_PB_MaPhong.Enabled = false;
            txt_PB_TenPhong.Enabled = true;
            dgvPhongBan.Enabled = false;
        }

        //Hàm xử lý sửa phòng ban
        public void SuaPhongBan()
        {
            txt_PB_MaPhong.Enabled = false;
            txt_PB_TenPhong.Enabled = true;
        }

        //Hàm xử lý xóa phòng ban
        public void XoaPhongBan()
        {
            try
            {
                string MaPhong = txt_PB_MaPhong.Text;
                if (MessageBox.Show("Bạn có muốn xóa phòng '" + txt_PB_TenPhong.Text + "' không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    phongBan = new PhongBan(MaPhong);
                    phongBanBll.DeletePhongBan(phongBan);
                    //ResetPhongBan();
                    if (ViTri > 0)
                    {
                        dgvPhongBan.CurrentCell = dgvPhongBan.Rows[ViTri - 1].Cells[0];
                        dgvPhongBan.Rows[ViTri - 1].Selected = true;
                        GanGiaTriPhongBan();
                    }
                    LoadDataGridViewPhongBan();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //Hàm xử lý Lưu phòng ban
        public void LuuPhongBan()
        {
            if (Them == 1)
            {
                try
                {
                    //Insert Phòng Ban             
                    string MaPhong = txt_PB_MaPhong.Text;
                    string TenPhong = txt_PB_TenPhong.Text;

                    KiemTraTenPhongBan();//Gọi hàm kiểm tra tên phòng ban
                    if (txt_PB_TenPhong.Text != "" && lbl_PB_TenPhongBan.Visible == false)
                    {
                        phongBan = new PhongBan(MaPhong, TenPhong);
                        phongBanBll.InsertPhongBan(phongBan);
                        dgvPhongBan.DataSource = phongBanBll.SelectAllPhongBan();
                        LoadDataGridViewPhongBan();
                        MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvPhongBan.Enabled = true;
                    }

                }
                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Sua == 1)
            {
                try
                {
                    //Update Phòng Ban
                    string MaPhong = txt_PB_MaPhong.Text;
                    string TenPhong = txt_PB_TenPhong.Text;

                    //Gọi hàm kiểm tra tên phòng ban
                    KiemTraTenPhongBan();

                    if (txt_PB_TenPhong.Text != "" && lbl_PB_TenPhongBan.Visible == false)
                    {
                        phongBan = new PhongBan(MaPhong, TenPhong);
                        phongBanBll.UpdatePhongBan(phongBan);
                        dgvPhongBan.CurrentCell = dgvPhongBan.Rows[ViTri].Cells[0];
                        dgvPhongBan.Rows[ViTri].Selected = true;
                        GanGiaTriPhongBan();
                        LoadDataGridViewPhongBan();
                        MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Hàm làm mới phòng ban
        public void FreshPhongBan()
        {
            if (txt_PB_TenPhong.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
                txt_PB_TenPhong.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;
                btn_NV_Picture.Enabled = false;
                txt_PB_MaPhong.Enabled = false;
                txt_PB_TenPhong.Enabled = false;

                pictureBox_PB_TenPhongBan.Visible = false;
                lbl_PB_TenPhongBan.Visible = false;

                GanGiaTriPhongBan();
                ViTri = dgvPhongBan.CurrentCell.RowIndex;
            }
        }

        //Hàm xử lý gán giá trị từ DataGridView lên các TextBox trong tab Phòng Ban
        public void GanGiaTriPhongBan()
        {
            try
            {
                if (this.dgvPhongBan.SelectedRows.Count == 0)
                    return;

                DataGridViewRow dgvr = this.dgvPhongBan.SelectedRows[0];
                GanDieuKienPhongBan(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Hàm xử lý đảm bảo gán đúng các giá trị tương ứng với các TextBox tương ứng trong tab Phòng Ban
        public void GanDieuKienPhongBan(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvPhongBan.Rows.Count != 0)
                {
                    this.txt_PB_MaPhong.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_PB_TenPhong.Text = dgvr.Cells[1].Value.ToString();
                }
                else
                {
                    this.txt_PB_MaPhong.Text = "";
                    this.txt_PB_TenPhong.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Hàm xử lý gán giá trị phòng ban khi chọn các dòng khác nhau trên DataGridView
        private void dgvPhongBan_Click(object sender, EventArgs e)
        {
            GanGiaTriPhongBan();
            ViTri = dgvPhongBan.CurrentCell.RowIndex;
        }
        #endregion

        #region "Các hàm xử lý cho Giới Tính"
        //Hàm load DataGridView Giới Tính
        public void LoadDataGridViewGioiTinh()
        {
            try
            {
                this.dgvGioiTinh.AutoGenerateColumns = false;
                this.dgvGioiTinh.DataSource = gioiTinhBll.SelectAllGioiTinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm tự tăng mã giới tính khi thêm
        public string TuTangMaGioiTinh()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = gioiTinhBll.SelectAllGioiTinh();
            if (dt.Rows.Count <= 0)//Kiểm tra nếu không có dòng nào thì tự động tăng mã giới tính bằng GT001
            {
                str = "GT001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã giới tính
                str = "GT";//ký tự mặc định của mã giới tính    
                //Lấy 3 kí tự sau cùng trong mã giới tính và chuyển sang kiểu int
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

        ////Hàm xử lý thêm giới tính
        public void ThemGioiTinh()
        {
            txt_GT_MaGioiTinh.Text = TuTangMaGioiTinh();
            txt_GT_TenGioiTinh.Text = "";

            txt_GT_MaGioiTinh.Enabled = false;
            txt_GT_TenGioiTinh.Enabled = true;
            dgvGioiTinh.Enabled = false;
        }

        ////Hàm xử lý sửa giới tính
        public void SuaGioiTinh()
        {
            txt_GT_MaGioiTinh.Enabled = false;
            txt_GT_TenGioiTinh.Enabled = true;
        }

        ////Hàm xử lý xóa giới tính
        public void XoaGioiTinh()
        {
            try
            {
                string MaGioiTinh = txt_GT_MaGioiTinh.Text;
                if (MessageBox.Show("Bạn có muốn xóa giới tính '" + txt_GT_TenGioiTinh.Text + "' không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gioiTinh = new GioiTinh(MaGioiTinh);
                    gioiTinhBll.DeleteGioiTinh(gioiTinh);
                    //ResetGioiTinh();
                    if (ViTri > 0)
                    {
                        dgvGioiTinh.CurrentCell = dgvGioiTinh.Rows[ViTri - 1].Cells[0];
                        dgvGioiTinh.Rows[ViTri - 1].Selected = true;
                        GanGiaTriGioiTinh();
                    }
                    LoadDataGridViewGioiTinh();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        ////Hàm xử lý Lưu giới tính
        public void LuuGioiTinh()
        {
            if (Them == 1)
            {
                try
                {
                    //Insert Giới Tính         
                    string MaGioiTinh = txt_GT_MaGioiTinh.Text;
                    string TenGioiTinh = txt_GT_TenGioiTinh.Text;

                    KiemTraTenGioiTinh();//Gọi hàm kiểm tra tên giới tính
                    if (txt_GT_TenGioiTinh.Text != "")
                    {
                        gioiTinh = new DTO.GioiTinh(MaGioiTinh, TenGioiTinh);
                        gioiTinhBll.InsertGioiTinh(gioiTinh);
                        dgvGioiTinh.DataSource = gioiTinhBll.SelectAllGioiTinh();
                        LoadDataGridViewGioiTinh();
                        MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvGioiTinh.Enabled = true;
                    }

                }
                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Sua == 1)
            {
                try
                {
                    //Update Giới Tính
                    string MaGioiTinh = txt_GT_MaGioiTinh.Text;
                    string TenGioiTinh = txt_GT_TenGioiTinh.Text;

                    KiemTraTenGioiTinh();//Gọi hàm kiểm tra tên giới tính
                    if (txt_GT_TenGioiTinh.Text != "")
                    {
                        gioiTinh = new DTO.GioiTinh(MaGioiTinh, TenGioiTinh);
                        gioiTinhBll.UpdateGioiTinh(gioiTinh);
                        dgvGioiTinh.CurrentCell = dgvGioiTinh.Rows[ViTri].Cells[0];
                        dgvGioiTinh.Rows[ViTri].Selected = true;
                        GanGiaTriGioiTinh();
                        LoadDataGridViewGioiTinh();
                        MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        ////Hàm làm mới giới tính
        public void FreshGioiTinh()
        {
            if (txt_GT_TenGioiTinh.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
                txt_GT_TenGioiTinh.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;
                btn_NV_Picture.Enabled = false;
                txt_GT_MaGioiTinh.Enabled = false;
                txt_GT_TenGioiTinh.Enabled = false;

                pictureBox_GT_TenGioiTinh.Visible = false;
                lbl_GT_TenGioiTinh.Visible = false;

                GanGiaTriGioiTinh();
                ViTri = dgvGioiTinh.CurrentCell.RowIndex;
            }
        }

        //Hàm xử lý gán giá trị từ DataGridView lên các TextBox trong tab Phòng Ban
        public void GanGiaTriGioiTinh()
        {

            try
            {
                if (this.dgvGioiTinh.SelectedRows.Count == 0)
                    return;

                DataGridViewRow dgvr = this.dgvGioiTinh.SelectedRows[0];
                GanDieuKienGioiTinh(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Hàm xử lý đảm bảo gán đúng các giá trị tương ứng với các TextBox tương ứng trong tab Phòng Ban
        public void GanDieuKienGioiTinh(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvGioiTinh.Rows.Count != 0)
                {
                    this.txt_GT_MaGioiTinh.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_GT_TenGioiTinh.Text = dgvr.Cells[1].Value.ToString();
                }
                else
                {
                    this.txt_GT_MaGioiTinh.Text = "";
                    this.txt_GT_TenGioiTinh.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Hàm xử lý gán giá trị phòng ban khi chọn các dòng khác nhau trên DataGridView
        private void dgvGioiTinh_Click(object sender, EventArgs e)
        {
            GanGiaTriGioiTinh();
            ViTri = dgvGioiTinh.CurrentCell.RowIndex;
        }
        #endregion

        #region"Xử lý sự kiện cho Picture"
        //Hàm xử lý thêm hoặc sửa ảnh
        private void btn_NV_Picture_Click(object sender, EventArgs e)
        {
            if (Them == 1 || Sua == 1)
            {
                try
                {
                    openFileDialog.Filter = openFileDialog.Filter = "PNG Files(*.png)|*.png|JPG Files(*.jpg)|*.jpg|All Files(*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox.ImageLocation = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc thuộc nhân viên"
        private void txt_NV_TenNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                lbl_NV_TenNhanVien.Text = "Không được có số hoặc kí tự đặc biệt!";
                lbl_NV_TenNhanVien.Visible = true;
                pictureBox_NV_TenNhanVien.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_TenNhanVien.Visible = true;
                e.Handled = true;
            }
            else
            {
                pictureBox_NV_TenNhanVien.Visible = false;
                lbl_NV_TenNhanVien.Visible = false;
            }
        }

        private void dtp_NV_NgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox_NV_NgaySinh.Visible = false;
            lbl_NV_NgaySinh.Visible = false;
        }

        private void txt_NV_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                lbl_NV_SDT.Text = "Số điện thoại không được có chữ cái!";
                lbl_NV_SDT.Visible = true;
                pictureBox_NV_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_SDT.Visible = true;
            }
            else
            {
                pictureBox_NV_SDT.Visible = false;
                lbl_NV_SDT.Visible = false;
            }
        }

        private void txt_NV_CMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                lbl_NV_CMND.Text = "Số chứng minh không được có chữ cái!";
                lbl_NV_CMND.Visible = true;
                pictureBox_NV_CMND.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_CMND.Visible = true;
            }
            else
            {
                pictureBox_NV_CMND.Visible = false;
                lbl_NV_CMND.Visible = false;
            }
        }

        private void txt_NV_TenDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox_NV_TenDangNhap.Visible = false;
            lbl_NV_TenDangNhap.Visible = false;
        }

        private void txt_NV_MatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            pictureBox_NV_MatKhau.Visible = false;
            lbl_NV_MatKhau.Visible = false;
        }

        //Hàm kiểm tra ràng buộc tên nhân viên
        public void KiemTraTenNhanVien()
        {
            if (txt_NV_TenNhanVien.Text == "")
            {
                pictureBox_NV_TenNhanVien.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_TenNhanVien.Visible = true;
                lbl_NV_TenNhanVien.Text = "Bạn chưa nhập tên nhân viên!";
                lbl_NV_TenNhanVien.Visible = true;
            }
            else
            {
                pictureBox_NV_TenNhanVien.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NV_TenNhanVien.Visible = true;
                lbl_NV_TenNhanVien.Visible = false;
            }
        }

        //Hàm kiểm tra ràng buộc ngày sinh nhân viên
        public void KiemTraNgaySinh()
        {
            do
            {
                int namHienTai = DateTime.Now.Year;
                int namNhanVien = dtp_NV_NgaySinh.Value.Year;
                tuoi = namHienTai - namNhanVien;
                if (tuoi < 18)
                {
                    pictureBox_NV_NgaySinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                    pictureBox_NV_NgaySinh.Visible = true;
                    lbl_NV_NgaySinh.Text = "Nhân viên phải trên 18 tuổi!";
                    lbl_NV_NgaySinh.Visible = true;
                }
            } while (false);

            if (tuoi > 18)
            {
                pictureBox_NV_NgaySinh.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NV_NgaySinh.Visible = true;
                lbl_NV_NgaySinh.Visible = false;
            }
        }

        //Hàm kiểm tra ràng buộc số điện thoại
        public void KiemTraSDT()
        {
            DataTable dt = new DataTable();
            dt = nhanVienBll.SelectAllNhanVien();
            int kiemTra = 0;

            if (txt_NV_SDT.Text == "")
            {
                pictureBox_NV_SDT.Visible = false;
                lbl_NV_SDT.Visible = false;
            }
            if (txt_NV_SDT.Text != "" && txt_NV_SDT.Text.Length < 10)
            {
                pictureBox_NV_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_SDT.Visible = true;
                lbl_NV_SDT.Text = "SDT tối thiểu 10 chữ số!";
                lbl_NV_SDT.Visible = true;
            }
            if(Them==1)
            {
                if (txt_NV_SDT.Text != "" && txt_NV_SDT.Text.Length >= 10)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][6].ToString().Equals(txt_NV_SDT.Text))
                        {
                            pictureBox_NV_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_SDT.Visible = true;
                            lbl_NV_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_NV_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if(Sua==1)
            {
                if (txt_NV_SDT.Text != "" && txt_NV_SDT.Text.Length >= 10)
                {
                    for (int i = 0; i < dgvNhanVien.CurrentCell.RowIndex; i++)
                    {
                        if (dgvNhanVien.Rows[i].Cells[6].Value.ToString().Equals(txt_NV_SDT.Text))
                        {
                            pictureBox_NV_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_SDT.Visible = true;
                            lbl_NV_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_NV_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvNhanVien.CurrentCell.RowIndex + 1; i < dgvNhanVien.Rows.Count; i++)
                    {
                        if (dgvNhanVien.Rows[i].Cells[6].Value.ToString().Equals(txt_NV_SDT.Text))
                        {
                            pictureBox_NV_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_SDT.Visible = true;
                            lbl_NV_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_NV_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }              
            }
           
            if (txt_NV_SDT.Text.Length >= 10 && kiemTra == 0)
            {
                pictureBox_NV_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NV_SDT.Visible = true;
                lbl_NV_SDT.Visible = false;
            }
        }      

        //Hàm kiểm tra số chứng minh nhân dân
        public void KiemTraCMND()
        {
            DataTable dt = new DataTable();
            dt = nhanVienBll.SelectAllNhanVien();
            int kiemTra = 0;
            if (txt_NV_CMND.Text == "")
            {
                pictureBox_NV_CMND.Visible = false;
                lbl_NV_CMND.Visible = false;
            }
            if (txt_NV_CMND.Text != "" && txt_NV_CMND.Text.Length < 9)
            {
                pictureBox_NV_CMND.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_CMND.Visible = true;
                lbl_NV_CMND.Text = "Số CMND tối thiểu 9 chữ số!";
                lbl_NV_CMND.Visible = true;
            }
            if(Them==1)
            {
                if (txt_NV_CMND.Text != "" && txt_NV_CMND.Text.Length >= 9)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][4].ToString().Equals(txt_NV_CMND.Text))
                        {
                            pictureBox_NV_CMND.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_CMND.Visible = true;
                            lbl_NV_CMND.Text = "Số CMND đã tồn tại!";
                            lbl_NV_CMND.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if(Sua==1)
            {
                if (txt_NV_CMND.Text != "" && txt_NV_CMND.Text.Length >= 9)
                {
                    for (int i = 0; i < dgvNhanVien.CurrentCell.RowIndex; i++)
                    {
                        if (dgvNhanVien.Rows[i].Cells[4].Value.ToString().Equals(txt_NV_CMND.Text))
                        {
                            pictureBox_NV_CMND.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_CMND.Visible = true;
                            lbl_NV_CMND.Text = "Số CMND đã tồn tại!";
                            lbl_NV_CMND.Visible = true;
                            kiemTra = 1;
                        }                                     
                    }
                    for (int i=dgvNhanVien.CurrentCell.RowIndex+1;i<dgvNhanVien.Rows.Count;i++)
                    {
                        if (dgvNhanVien.Rows[i].Cells[4].Value.ToString().Equals(txt_NV_CMND.Text))
                        {
                            pictureBox_NV_CMND.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_CMND.Visible = true;
                            lbl_NV_CMND.Text = "Số CMND đã tồn tại!";
                            lbl_NV_CMND.Visible = true;
                            kiemTra = 1;
                        }    
                    }
                }
            }        
            if (txt_NV_CMND.Text.Length >= 9 && kiemTra == 0)
            {
                pictureBox_NV_CMND.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NV_CMND.Visible = true;
                lbl_NV_CMND.Visible = false;
            }

        }
       
        //Hàm kiểm tra tên đăng nhập
        public void KiemTraTenDangNhap()
        {
            int kiemtra = 0;
            DataTable dt = new DataTable();
            dt = nhanVienBll.SelectAllNhanVien();
            if (txt_NV_TenDangNhap.Text == "")
            {
                pictureBox_NV_TenDangNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_TenDangNhap.Visible = true;
                lbl_NV_TenDangNhap.Text = "Bạn chưa nhập tên đăng nhập!";
                lbl_NV_TenDangNhap.Visible = true;
            }
            if(Them==1)
            {
                if (txt_NV_TenDangNhap.Text != "")
                {
                    for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                    {
                        if (txt_NV_TenDangNhap.Text.Trim().Equals(dgvNhanVien.Rows[i].Cells[8].Value.ToString().Trim()))
                        {
                            pictureBox_NV_TenDangNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_TenDangNhap.Visible = true;
                            lbl_NV_TenDangNhap.Text = "Tên đăng nhập đã tồn tại!";
                            lbl_NV_TenDangNhap.Visible = true;
                            kiemtra = 1;
                        }
                    }
                }
            }
            if(Sua==1)
            {
                if (txt_NV_TenDangNhap.Text != "")
                {
                    for (int i = 0; i < dgvNhanVien.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_NV_TenDangNhap.Text.Trim().Equals(dgvNhanVien.Rows[i].Cells[8].Value.ToString().Trim()))
                        {
                            pictureBox_NV_TenDangNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_TenDangNhap.Visible = true;
                            lbl_NV_TenDangNhap.Text = "Tên đăng nhập đã tồn tại!";
                            lbl_NV_TenDangNhap.Visible = true;
                            kiemtra = 1;
                        }
                    }
                    for (int i = dgvNhanVien.CurrentCell.RowIndex+1; i < dgvNhanVien.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_NV_TenDangNhap.Text.Trim().Equals(dgvNhanVien.Rows[i].Cells[8].Value.ToString().Trim()))
                        {
                            pictureBox_NV_TenDangNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NV_TenDangNhap.Visible = true;
                            lbl_NV_TenDangNhap.Text = "Tên đăng nhập đã tồn tại!";
                            lbl_NV_TenDangNhap.Visible = true;
                            kiemtra = 1;
                        }
                    }
                }
            }
           
            if (txt_NV_TenDangNhap.Text != "" && kiemtra == 0)
            {
                pictureBox_NV_TenDangNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NV_TenDangNhap.Visible = true;
                lbl_NV_TenDangNhap.Visible = false;
            }
        }     
        //Hàm kiểm tra mật khẩu
        public void KiemTraMatKhau()
        {
            if (txt_NV_MatKhau.Text == "")
            {
                pictureBox_NV_MatKhau.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NV_MatKhau.Visible = true;
                lbl_NV_MatKhau.Text = "Bạn chưa nhập mật khẩu!";
                lbl_NV_MatKhau.Visible = true;
            }
            else
            {
                pictureBox_NV_MatKhau.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NV_MatKhau.Visible = true;
                lbl_NV_MatKhau.Visible = false;
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc thuộc phòng bàng
        //Hàm kiểm tra ràng buộc tên phòng ban
        public void KiemTraTenPhongBan()
        {
            int kiemTra = 0;
            DataTable dt = new DataTable();
            dt = phongBanBll.SelectAllPhongBan();

            if (txt_PB_TenPhong.Text == "")
            {
                pictureBox_PB_TenPhongBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_PB_TenPhongBan.Visible = true;
                lbl_PB_TenPhongBan.Text = "Bạn chưa nhập tên phòng ban!";
                lbl_PB_TenPhongBan.Visible = true;
            }
            if (Them == 1)
            {
                if (txt_PB_TenPhong.Text != "")
                {
                    for (int i = 0; i < dgvPhongBan.Rows.Count; i++)
                    {
                        if (txt_PB_TenPhong.Text.Trim().ToLower().Equals(dgvPhongBan.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_PB_TenPhongBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_PB_TenPhongBan.Visible = true;
                            lbl_PB_TenPhongBan.Text = "Tên phòng ban đã tồn tại!";
                            lbl_PB_TenPhongBan.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_PB_TenPhong.Text != "")
                {
                    for (int i = 0; i < dgvPhongBan.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_PB_TenPhong.Text.Trim().ToLower().Equals(dgvPhongBan.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_PB_TenPhongBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_PB_TenPhongBan.Visible = true;
                            lbl_PB_TenPhongBan.Text = "Tên phòng ban đã tồn tại!";
                            lbl_PB_TenPhongBan.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvPhongBan.CurrentCell.RowIndex + 1; i < dgvPhongBan.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_PB_TenPhong.Text.Trim().ToLower().Equals(dgvPhongBan.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                           pictureBox_PB_TenPhongBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                           pictureBox_PB_TenPhongBan.Visible = true;
                           lbl_PB_TenPhongBan.Text = "Tên phòng ban đã tồn tại!";
                           lbl_PB_TenPhongBan.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (txt_PB_TenPhong.Text != "" && kiemTra == 0)      
            {
                pictureBox_PB_TenPhongBan.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_PB_TenPhongBan.Visible = true;
                lbl_PB_TenPhongBan.Visible = false;
            }

        }      

        private void txt_PB_TenPhong_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                lbl_PB_TenPhongBan.Text = "Không được có số hoặc kí tự đặc biệt!";
                lbl_PB_TenPhongBan.Visible = true;
                pictureBox_PB_TenPhongBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_PB_TenPhongBan.Visible = true;
                e.Handled = true;
            }
            else
            {
                pictureBox_PB_TenPhongBan.Visible = false;
                lbl_PB_TenPhongBan.Visible = false;
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc giới tính"
        //Hàm kiểm tra ràng buộc tên giới tính
        public void KiemTraTenGioiTinh()
        {
            int kiemTra = 0;
            DataTable dt = new DataTable();
            dt = gioiTinhBll.SelectAllGioiTinh(); 

            if (txt_GT_TenGioiTinh.Text == "")
            {
                pictureBox_GT_TenGioiTinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_GT_TenGioiTinh.Visible = true;
                lbl_GT_TenGioiTinh.Text = "Bạn chưa nhập tên giới tính!";
                lbl_GT_TenGioiTinh.Visible = true;
            }
            if (Them == 1)
            {
                if (txt_GT_TenGioiTinh.Text != "")
                {
                    for (int i = 0; i < dgvGioiTinh.Rows.Count; i++)
                    {
                        if (txt_GT_TenGioiTinh.Text.Trim().ToLower().Equals(dgvGioiTinh.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_GT_TenGioiTinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_GT_TenGioiTinh.Visible = true;
                            lbl_GT_TenGioiTinh.Text = "Tên giới tính đã tồn tại!";
                            lbl_GT_TenGioiTinh.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_GT_TenGioiTinh.Text != "")
                {
                    for (int i = 0; i < dgvGioiTinh.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_GT_TenGioiTinh.Text.Trim().ToLower().Equals(dgvGioiTinh.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_GT_TenGioiTinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_GT_TenGioiTinh.Visible = true;
                             lbl_GT_TenGioiTinh.Text = "Tên giới tính đã tồn tại!";
                             lbl_GT_TenGioiTinh.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvGioiTinh.CurrentCell.RowIndex + 1; i < dgvGioiTinh.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_GT_TenGioiTinh.Text.Trim().ToLower().Equals(dgvGioiTinh.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_GT_TenGioiTinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_GT_TenGioiTinh.Visible = true;
                             lbl_GT_TenGioiTinh.Text = "Tên giới tính đã tồn tại!";
                             lbl_GT_TenGioiTinh.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }

            if (txt_GT_TenGioiTinh.Text != "" && kiemTra == 0)
            {
                pictureBox_GT_TenGioiTinh.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_GT_TenGioiTinh.Visible = true;
                lbl_GT_TenGioiTinh.Visible = false;
            }
        }

        private void txt_GT_TenGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                lbl_GT_TenGioiTinh.Text = "Không được có số hoặc kí tự đặc biệt!";
                lbl_GT_TenGioiTinh.Visible = true;
                pictureBox_GT_TenGioiTinh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_GT_TenGioiTinh.Visible = true;
                e.Handled = true;
            }
            else
            {
                pictureBox_GT_TenGioiTinh.Visible = false;
                lbl_GT_TenGioiTinh.Visible = false;
            }
        }

        #endregion

        #region "Tìm kiếm cho nhân viên"
        private void btn_NV_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = nhanVienBll.SearchNhanVien(txt_NV_TimKiem.Text);
                dgvNhanVien.DataSource = dt;
                if (dgvNhanVien.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_NV_TimKiem.Text = null;
                    txt_NV_TimKiem.Focus();
                    LoadDataGridViewNhanVien();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }         
        }    
        #endregion

        #region "Tìm kiếm cho phòng ban"
        private void btn_PB_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = phongBanBll.SearchPhongBan(txt_PB_TimKiem.Text);
                dgvPhongBan.DataSource = dt;
                if (dgvPhongBan.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_PB_TimKiem.Text = "";
                    txt_PB_TimKiem.Focus();
                    LoadDataGridViewPhongBan();
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }
          
        }
        #endregion

        private void txt_NV_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_NV_TimKiem.PerformClick();
        }

        private void txt_PB_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_PB_TimKiem.PerformClick();
        }

    }
}
