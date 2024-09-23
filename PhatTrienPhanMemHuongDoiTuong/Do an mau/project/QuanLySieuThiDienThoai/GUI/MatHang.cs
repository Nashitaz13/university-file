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
    public partial class MatHang : UserControl
    {
        MatHangBll matHangBll = new MatHangBll();
        NhaSanXuatBll nhaSanXuatBll = new NhaSanXuatBll();
        NhaCungCapBll nhaCungCapBll = new NhaCungCapBll();

        DTO.MatHang matHang;
        DTO.NhaSanXuat nhaSanXuat;
        DTO.NhaCungCap nhaCungCap;

        int ViTri = 0;
        int ChucNang = 0;
        int Them = 0;
        int Sua = 0;

        public MatHang()
        {
            InitializeComponent();
        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            LoadDataGridViewMatHang();
            LoadDataGridViewNhaSanXuat();
            LoadDataGridViewNhaCungCap();

            cmb_MH_NSX.DataSource = nhaSanXuatBll.ChonTenNhaSanXuat();
            cmb_MH_NSX.ValueMember = "TenNhaSanXuat";

            ChucNang = 1;
            KhoiTao();
        }

        //Hàm Reset lại các field cho Mặt Hàng, Nhà Sản Xuất, Nhà Cung Cấp
        public void KhoiTao()
        {
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
            btn_xoa.Enabled = true;
            btn_huy.Enabled = false;
            btn_sua.Enabled = true;
            btn_MH_Picture.Enabled = false;

            if (ChucNang == 1)
            {
                txt_MH_MaMH.Enabled = false;
                txt_MH_TenMH.Enabled = false;
                txt_MH_GiaNhap.Enabled = false;
                txt_MH_GiaBan.Enabled = false;
                txt_MH_ThoiGianBaoHanh.Enabled = false;
                txt_MH_TimKiem.Text = null;
                cmb_MH_NSX.Enabled = false;
                
                lbl_MH_TenMH.Visible = false;
                lbl_G_GiaNhap.Visible = false;
                lbl_MH_ThoiGianBaoHanh.Visible = false;
                lbl_MH_GiaBan.Visible = false;

                pictureBox_MH_TenMH.Visible = false;
                pictureBox_MH_ThoiGianBaoHanh.Visible = false;               
                pictureBox_MH_GiaNhap.Visible = false;
                pictureBox_MH_GiaBan.Visible = false;
            }

            if (ChucNang == 2)
            {
                txt_NSX_MaNhaSanXuat.Enabled = false;
                txt_NSX_TenNhaSanXuat.Enabled = false;
                txt_NSX_TimKiem.Text = null;

                lbl_NSX_TenNSX.Visible = false;
                pictureBox_NSX_TenNSX.Visible = false;
            }

            if (ChucNang == 3)
            {
                txt_NCC_MaNhaCungCap.Enabled = false;
                txt_NCC_TenNhaCungCap.Enabled = false;
                txt_NCC_TimKiem.Text = null;

                lbl_NCC_TenNCC.Visible = false;
                lbl_NCC_DiaChi.Visible = false;
                lbl_NCC_SDT.Visible = false;

                pictureBox_NCC_TenNCC.Enabled = false;
                pictureBox_NCC_DiaChi.Enabled = false;
                pictureBox_NCC_SDT.Enabled = false;
            }
        }

        private void backstageViewTabItem_mathang_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 1;
            KhoiTaoMatHang();
            cmb_MH_NSX.DataSource = nhaSanXuatBll.ChonTenNhaSanXuat();
            cmb_MH_NSX.ValueMember = "MaNhaSanXuat";
            cmb_MH_NSX.DisplayMember = "TenNhaSanXuat";
            KhoiTao();
            LoadDataGridViewMatHang();
        }

        private void backstageViewTabItem_nhasx_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 2;
            KhoiTaoNhaSanXuat();
            KhoiTao();
            LoadDataGridViewNhaSanXuat();
        }

        private void backstageViewTabItem_nhacungcap_SelectedChanged_1(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ChucNang = 3;
            KhoiTaoNhaCungCap();
            KhoiTao();
            LoadDataGridViewNhaCungCap();
        }

        #region "Xử lý Thêm, Xóa, Sửa, Hủy, Lưu"
        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_huy.Enabled = true;
            btn_them.Enabled = false;
            btn_sua.Enabled = false;
            btn_MH_Picture.Enabled = true;

            Them = 1;
            Sua = 0;
            if (ChucNang == 1)
            {
                ThemMatHang();
            }
            if (ChucNang == 2)
            {
                ThemNhaSanXuat();
            }
            if (ChucNang == 3)
            {
                ThemNhaCungCap();
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                LuuMatHang();
                if (txt_MH_TenMH.Text != "" && txt_MH_GiaBan.Text != "" && txt_MH_GiaNhap.Text != "" && txt_MH_ThoiGianBaoHanh.Text != "")
                {
                    if (int.Parse(txt_MH_GiaNhap.Text) > 0 && int.Parse(txt_MH_GiaBan.Text) > 0 && int.Parse(txt_MH_GiaBan.Text) >= int.Parse(txt_MH_GiaNhap.Text))
                    {
                        if(lbl_MH_TenMH.Visible==false)
                        {
                            KhoiTaoMatHang();
                            this.ActiveControl = null;
                        }       
                    }                   
                }
            }
            if (ChucNang == 2)
            {
                LuuNhaSanXuat();
                if (txt_NSX_TenNhaSanXuat.Text != "" && lbl_NSX_TenNSX.Visible==false)
                {
                    KhoiTaoNhaSanXuat();
                    this.ActiveControl = null;
                }
                    
            }
            if (ChucNang == 3)
            {
                LuuNhaCungCap();
                if (lbl_NCC_TenNCC.Visible == false && lbl_NCC_DiaChi.Visible == false && lbl_NCC_SDT.Visible == false)
                {
                    if (txt_NCC_SDT.Text.Length >= 10 && txt_NCC_DiaChi.Text.Length >= 2)
                    {
                        KhoiTaoNhaCungCap();
                        this.ActiveControl = null;
                    }
                }
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                XoaMatHang();
            }
            if (ChucNang == 2)
            {
                XoaNhaSanXuat();
            }
            if (ChucNang == 3)
            {
                XoaNhaCungCap();
            }
        }

        private void btn_huy_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            if (ChucNang == 1)
            {
                KhoiTao();            
                dgvMatHang.Enabled = true;
                GanGiaTriMatHang();
                ViTri = dgvMatHang.CurrentCell.RowIndex;

            }
            if (ChucNang == 2)
            {
                KhoiTao();
                dgvNhaSanXuat.Enabled = true;
                GanGiaTriNhaSanXuat();
                ViTri = dgvNhaSanXuat.CurrentCell.RowIndex;
            }

            if (ChucNang == 3)
            {
                KhoiTao();
                dgvNhaCungCap.Enabled = true;
                GanGiaTriNhaCungCap();
                ViTri = dgvNhaCungCap.CurrentCell.RowIndex;
            }

        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            btn_them.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_huy.Enabled = true;
            btn_sua.Enabled = false;
            btn_MH_Picture.Enabled = true;
            Sua = 1;
            Them = 0;

            if (ChucNang == 1)
            {
                SuaMatHang();
            }
            if (ChucNang == 2)
            {
                SuaNhaSanXuat();
            }
            if (ChucNang == 3)
            {
                SuaNhaCungCap();
            }

        }

        #endregion

        #region "Các hàm xử lý Mặt Hàng"
        public void LoadDataGridViewMatHang()
        {
            try
            {
                this.dgvMatHang.AutoGenerateColumns = false;
                dgvMatHang.DataSource = matHangBll.DanhSachMatHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string TuTangMaMatHang()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = matHangBll.DanhSachMatHang();
            if (dt.Rows.Count <= 0)//Kiểm tra nếu không có dòng nào thì tự động tăng mã mặt hàng bằng MH001
            {
                str = "MH001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã mặt hàng
                str = "MH";//ký tự mặc định của mã mặt hàng    
                //Lấy 3 kí tự sau cùng trong mã mặt hàng và chuyển sang kiểu int
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

        public void ThemMatHang()
        {
            txt_MH_MaMH.Text = TuTangMaMatHang();
            txt_MH_TenMH.Text = "";
            txt_MH_ThoiGianBaoHanh.Text = "";
            cmb_MH_NSX.Text = "";
            txt_MH_GiaNhap.Text = "";
            txt_MH_GiaBan.Text = "";
            pictureBox_MH.Image = QuanLySieuThiDienThoai.Properties.Resources.default_device;

            txt_MH_MaMH.Enabled = false;
            txt_MH_TenMH.Enabled = true;
            cmb_MH_NSX.Enabled = true;
            txt_MH_ThoiGianBaoHanh.Enabled = true;
            txt_MH_GiaNhap.Enabled = true;
            txt_MH_GiaBan.Enabled = true;
            dgvMatHang.Enabled = false;

        }

        public void SuaMatHang()
        {
            txt_MH_MaMH.Enabled = false;
            txt_MH_TenMH.Enabled = true;
            cmb_MH_NSX.Enabled = true;
            txt_MH_GiaNhap.Enabled = true;
            txt_MH_GiaBan.Enabled = true;
            txt_MH_ThoiGianBaoHanh.Enabled = true;
        }

        public void XoaMatHang()
        {
            try
            {
                string MaMatHang = txt_MH_MaMH.Text;
                if (MessageBox.Show("Bạn có muốn xóa mặt hàng'" + txt_MH_MaMH.Text + "'không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                {
                    matHang = new DTO.MatHang(MaMatHang);
                    matHangBll.XoaMatHang(matHang);
                    //ResetMatHang();
                    if (ViTri > 0)
                    {
                        dgvMatHang.CurrentCell = dgvMatHang.Rows[ViTri - 1].Cells[0];
                        dgvMatHang.Rows[ViTri - 1].Selected = true;
                        GanGiaTriMatHang();
                    }
                    LoadDataGridViewMatHang();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LuuMatHang()
        {             
            if (Them == 1)
            {
                try
                {
                    //Lấy ảnh từ Database và lưu ảnh xuống Database
                    MemoryStream stream = new MemoryStream();
                    pictureBox_MH.Image.Save(stream, ImageFormat.Jpeg);

                    //Lấy các thông tin mặt hàng được nhập từ người dùng    
                    string MaMatHang = txt_MH_MaMH.Text;
                    string TenMatHang = txt_MH_TenMH.Text;
                    string NhaSanXuat = cmb_MH_NSX.Text;
                    byte[] Hinh = stream.ToArray();
                    int SoLuong = 0;
                    int ThoiGianBaoHanh = 0;
                    float GiaNhap = 0;
                    float GiaBan = 0;

                    if(txt_MH_ThoiGianBaoHanh.Text !="")
                        ThoiGianBaoHanh =int.Parse(txt_MH_ThoiGianBaoHanh.Text);
                    if (txt_MH_GiaNhap.Text !="")
                        GiaNhap =float.Parse(txt_MH_GiaNhap.Text);
                    if (txt_MH_GiaBan.Text !="")
                        GiaBan =float.Parse(txt_MH_GiaBan.Text);

                    //Gọi các hàm kiểm tra ràng buộc cho Mặt Hàng
                    KiemTraTenMatHang();
                    KiemTraThoiGianBaoHanh();
                    KiemTraGiaNhap();
                    KiemTraGiaBan();

                    if (lbl_MH_TenMH.Visible == false && lbl_MH_ThoiGianBaoHanh.Visible == false && lbl_MH_GiaNhap.Visible == false && lbl_MH_GiaBan.Visible == false)
                    {
                        matHang = new DTO.MatHang(MaMatHang, TenMatHang, NhaSanXuat, Hinh, SoLuong, ThoiGianBaoHanh, GiaNhap, GiaBan);
                        matHangBll.ThemMatHang(matHang);
                        dgvMatHang.DataSource = matHangBll.DanhSachMatHang();
                        LoadDataGridViewMatHang();
                        MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvMatHang.Enabled = true;
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
                    //Lấy ảnh từ Database và lưu ảnh xuống Database
                    MemoryStream stream = new MemoryStream();
                    pictureBox_MH.Image.Save(stream, ImageFormat.Jpeg);

                    //Lấy các thông tin mặt hàng được nhập từ người dùng    
                    string MaMatHang = txt_MH_MaMH.Text;
                    string TenMatHang = txt_MH_TenMH.Text;
                    string NhaSanXuat = cmb_MH_NSX.Text;
                    float GiaNhap = float.Parse(txt_MH_GiaNhap.Text);
                    float GiaBan = float.Parse(txt_MH_GiaBan.Text);
                    byte[] Hinh = stream.ToArray();
                    int SoLuong = 0;
                    int ThoiGianBaoHanh = int.Parse(txt_MH_ThoiGianBaoHanh.Text);

                    //Gọi các hàm kiểm tra ràng buộc cho Mặt Hàng
                    KiemTraTenMatHang();
                    KiemTraThoiGianBaoHanh();
                    KiemTraGiaNhap();
                    KiemTraGiaBan();

                    if (lbl_MH_TenMH.Visible == false && lbl_MH_ThoiGianBaoHanh.Visible == false && lbl_MH_GiaNhap.Visible == false && lbl_MH_GiaBan.Visible == false)
                    {
                        matHang = new DTO.MatHang(MaMatHang, TenMatHang, NhaSanXuat, Hinh, SoLuong, ThoiGianBaoHanh, GiaNhap, GiaBan);
                        matHangBll.CapNhatMatHang(matHang);
                        dgvMatHang.CurrentCell = dgvMatHang.Rows[ViTri].Cells[0];
                        dgvMatHang.Rows[ViTri].Selected = true;
                        GanGiaTriMatHang();
                        LoadDataGridViewMatHang();
                        MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch 
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void KhoiTaoMatHang()
        {
            if (txt_MH_TenMH.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;

                txt_MH_TenMH.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_luu.Enabled = false;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;
                btn_MH_Picture.Enabled = false;

                txt_MH_MaMH.Enabled = false;
                txt_MH_TenMH.Enabled = false;
                txt_MH_ThoiGianBaoHanh.Enabled = false;
                txt_MH_GiaNhap.Enabled = false;
                txt_MH_GiaBan.Enabled = false;
                cmb_MH_NSX.Enabled = false;

                pictureBox_MH_TenMH.Visible=false;
                pictureBox_MH_ThoiGianBaoHanh.Visible=false;
                pictureBox_MH_GiaNhap.Visible=false;
                pictureBox_MH_GiaBan.Visible = false;

                GanGiaTriMatHang();
                ViTri = dgvMatHang.CurrentCell.RowIndex;
            }
        }

        public void GanGiaTriMatHang()
        {
            try
            {
                if (this.dgvMatHang.SelectedRows.Count == 0)
                    return;
                DataGridViewRow dgvr = this.dgvMatHang.SelectedRows[0];
                GanDieuKienMatHang(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GanDieuKienMatHang(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvMatHang.Rows.Count != 0)
                {
                    this.txt_MH_MaMH.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_MH_TenMH.Text = dgvr.Cells[1].Value.ToString();
                    this.cmb_MH_NSX.Text = dgvr.Cells[2].Value.ToString();
                    this.txt_MH_ThoiGianBaoHanh.Text = dgvr.Cells[3].Value.ToString();
                    this.txt_MH_GiaNhap.Text = dgvr.Cells[6].Value.ToString();
                    this.txt_MH_GiaBan.Text = dgvr.Cells[7].Value.ToString();
                }
                else
                {
                    this.txt_MH_MaMH.Text = " ";
                    this.txt_MH_TenMH.Text = " ";
                    this.cmb_MH_NSX.Text = " ";
                    this.txt_MH_ThoiGianBaoHanh.Text = " ";
                    this.txt_MH_GiaNhap.Text = "";
                    this.txt_MH_GiaBan.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMatHang_Click(object sender, EventArgs e)
        {
            GanGiaTriMatHang();
            ViTri = dgvMatHang.CurrentCell.RowIndex;
            try
            {
                byte[] MyData = new byte[0];
                MyData = (byte[])dgvMatHang.Rows[ViTri].Cells[5].Value;
                MemoryStream stream = new MemoryStream(MyData);
                pictureBox_MH.Image = Image.FromStream(stream);
            }
            catch
            {
                pictureBox_MH.Image = QuanLySieuThiDienThoai.Properties.Resources.default_avatar;
            }
        }
        #endregion

        #region "Các hàm xử lý Nhà Sản Xuất"
        public void LoadDataGridViewNhaSanXuat()
        {
            try
            {
                this.dgvNhaSanXuat.AutoGenerateColumns = false;
                this.dgvNhaSanXuat.DataSource = nhaSanXuatBll.DanhSachNhaSanXuat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string TuTangMaNhaSanXuat()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = nhaSanXuatBll.DanhSachNhaSanXuat();
            if (dt.Rows.Count <= 0)
            {
                str = "NSX01";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã nhà sản xuất
                str = "NSX";//ký tự mặc định của mã nhà sản xuất             
                i = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 2));
                i = i + 1;
                if (i < 10)
                    str = str + "0";
                str = str + i.ToString();
            }
            return str;
        }

        public void ThemNhaSanXuat()
        {
            txt_NSX_MaNhaSanXuat.Text = TuTangMaNhaSanXuat();
            txt_NSX_TenNhaSanXuat.Text = "";
            txt_NSX_TenNhaSanXuat.Focus();

            txt_NSX_MaNhaSanXuat.Enabled = false;
            txt_NSX_TenNhaSanXuat.Enabled = true;

            dgvNhaSanXuat.Enabled = false;
        }

        public void SuaNhaSanXuat()
        {
            txt_NSX_MaNhaSanXuat.Enabled = false;
            txt_NSX_TenNhaSanXuat.Enabled = true;
        }

        public void XoaNhaSanXuat()
        {
            try
            {
                string MaNhaSanXuat = txt_NSX_MaNhaSanXuat.Text;
                if (MessageBox.Show("Bạn có muốn xóa nhà sản xuất'" + txt_NSX_TenNhaSanXuat.Text + "'không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nhaSanXuat = new NhaSanXuat(MaNhaSanXuat);
                    nhaSanXuatBll.XoaNhaSanXuat(nhaSanXuat);
                    if (ViTri > 0)
                    {
                        dgvNhaSanXuat.CurrentCell = dgvNhaSanXuat.Rows[ViTri - 1].Cells[0];
                        dgvNhaSanXuat.Rows[ViTri - 1].Selected = true;
                        GanGiaTriNhaSanXuat();
                    }
                    LoadDataGridViewNhaSanXuat();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LuuNhaSanXuat()
        {
            if (Them == 1)
            {
                try
                {
                    //Lấy các thông tin nhà sản xuất được nhập từ người dùng               
                    string MaNhaSanXuat = txt_NSX_MaNhaSanXuat.Text;
                    string TenNhaSanXuat = txt_NSX_TenNhaSanXuat.Text;

                    //Gọi các hàm kiểm tra ràng buộc cho nhà sản xuất
                    KiemTraTenNhaSanXuat();

                    if (txt_NSX_TenNhaSanXuat.Text !="" && lbl_NSX_TenNSX.Visible==false)
                    {
                        nhaSanXuat = new NhaSanXuat(MaNhaSanXuat, TenNhaSanXuat);
                        nhaSanXuatBll.ThemNhaSanXuat(nhaSanXuat);
                        dgvNhaSanXuat.DataSource = nhaSanXuatBll.DanhSachNhaSanXuat();
                        LoadDataGridViewNhaSanXuat();
                        MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvNhaSanXuat.Enabled = true;
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!"+ex, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Sua == 1)
            {
                try
                {
                    //Lấy các thông tin nhà sản xuất được nhập từ người dùng       
                    string MaNhaSanXuat = txt_NSX_MaNhaSanXuat.Text;
                    string TenNhaSanXuat = txt_NSX_TenNhaSanXuat.Text;

                    //Gọi các hàm kiểm tra ràng buộc cho nhà sản xuất
                    KiemTraTenNhaSanXuat();

                    if (txt_NSX_TenNhaSanXuat.Text !="" && lbl_NSX_TenNSX.Visible == false)
                    {
                        nhaSanXuat = new NhaSanXuat(MaNhaSanXuat, TenNhaSanXuat);
                        nhaSanXuatBll.CapNhatNhaSanXuat(nhaSanXuat);
                        dgvNhaSanXuat.CurrentCell = dgvNhaSanXuat.Rows[ViTri].Cells[0];
                        dgvNhaSanXuat.Rows[ViTri].Selected = true;
                        GanGiaTriNhaSanXuat();
                        LoadDataGridViewNhaSanXuat();
                        MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch 
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void KhoiTaoNhaSanXuat()
        {
            if (txt_NSX_TenNhaSanXuat.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
                txt_NSX_TenNhaSanXuat.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_luu.Enabled = false;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;
                btn_MH_Picture.Enabled = false;

                txt_NSX_MaNhaSanXuat.Enabled = false;
                txt_NSX_TenNhaSanXuat.Enabled = false;

                pictureBox_NSX_TenNSX.Visible = false;

                GanGiaTriNhaSanXuat();
                ViTri = dgvNhaSanXuat.CurrentCell.RowIndex;
            }
        }

        public void GanGiaTriNhaSanXuat()
        {
            try
            {
                if (this.dgvNhaSanXuat.SelectedRows.Count == 0)
                    return;
                DataGridViewRow dgvr = this.dgvNhaSanXuat.SelectedRows[0];
                GanDieuKienNhaSanXuat(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GanDieuKienNhaSanXuat(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvNhaSanXuat.Rows.Count != 0)
                {
                    this.txt_NSX_MaNhaSanXuat.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_NSX_TenNhaSanXuat.Text = dgvr.Cells[1].Value.ToString();
                }
                else
                {
                    this.txt_NSX_MaNhaSanXuat.Text = "";
                    this.txt_NSX_TenNhaSanXuat.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhaSanXuat_Click(object sender, EventArgs e)
        {
            GanGiaTriNhaSanXuat();
            ViTri = dgvNhaSanXuat.CurrentCell.RowIndex;
        }
        #endregion

        #region "Các hàm xử lý Nhà Cung Cấp"
        public void LoadDataGridViewNhaCungCap()
        {
            try
            {
                this.dgvNhaCungCap.AutoGenerateColumns = false;
                this.dgvNhaCungCap.DataSource = nhaCungCapBll.DanhSachNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string TuTangMaNhaCungCap()
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = nhaCungCapBll.DanhSachNhaCungCap();
            if (dt.Rows.Count <= 0)
            {
                str = "NCC001";
            }
            else
            {
                int i;//lấy giá trị số trong chuỗi mã nhà cung cấp
                str = "NCC";//ký tự mặc định của mã nhà cung cấp             
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
        public void ThemNhaCungCap()
        {
            txt_NCC_MaNhaCungCap.Text = TuTangMaNhaCungCap();
            txt_NCC_TenNhaCungCap.Text = "";
            txt_NCC_DiaChi.Text = "";
            txt_NCC_SDT.Text = "";

            txt_NCC_MaNhaCungCap.Enabled = false;
            txt_NCC_TenNhaCungCap.Enabled = true;
            txt_NCC_DiaChi.Enabled = true;
            txt_NCC_SDT.Enabled = true;

            dgvNhaCungCap.Enabled = false;
        }

        public void SuaNhaCungCap()
        {
            txt_NCC_MaNhaCungCap.Enabled = false;
            txt_NCC_TenNhaCungCap.Enabled = true;
            txt_NCC_DiaChi.Enabled = true;
            txt_NCC_SDT.Enabled = true;
        }

        public void XoaNhaCungCap()
        {
            try
            {
                string MaNhaCungCap = txt_NCC_MaNhaCungCap.Text;
                if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp'" + txt_NCC_TenNhaCungCap.Text + "'không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nhaCungCap = new NhaCungCap(MaNhaCungCap);
                    nhaCungCapBll.XoaNhaCungCap(nhaCungCap);
                    //ResetNhaCungCap();
                    if (ViTri > 0)
                    {
                        dgvNhaCungCap.CurrentCell = dgvNhaCungCap.Rows[ViTri - 1].Cells[0];
                        dgvNhaCungCap.Rows[ViTri - 1].Selected = true;
                        GanGiaTriNhaCungCap();
                    }
                    LoadDataGridViewNhaCungCap();
                    MessageBox.Show("Đã xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LuuNhaCungCap()
        {
            if (Them == 1)
            {
                try
                {
                    //Lấy các thông tin nhà cung cấp được nhập từ người dùng             
                    string MaNhaCungCap = txt_NCC_MaNhaCungCap.Text;
                    string TenNhaCungCap = txt_NCC_TenNhaCungCap.Text;
                    string DiaChi = txt_NCC_DiaChi.Text;
                    string DienThoai = txt_NCC_SDT.Text;

                    //Gọi các hàm kiểm tra ràng buộc cho nhà cung cấp
                    KiemTraTenNhaCungCap();
                    KiemTraDiaChi();
                    KiemTraSDT();

                    if (lbl_NCC_TenNCC.Visible==false && lbl_NCC_DiaChi.Visible==false && lbl_NCC_SDT.Visible==false)
                    {
                        nhaCungCap = new NhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, DienThoai);
                        nhaCungCapBll.ThemNhaCungCap(nhaCungCap);
                        dgvNhaCungCap.DataSource = nhaCungCapBll.DanhSachNhaCungCap();
                        LoadDataGridViewNhaCungCap();
                        MessageBox.Show("Đã Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvNhaCungCap.Enabled = true;
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
                    //Lấy các thông tin nhà cung cấp được nhập từ người dùng             
                    string MaNhaCungCap = txt_NCC_MaNhaCungCap.Text;
                    string TenNhaCungCap = txt_NCC_TenNhaCungCap.Text;
                    string DiaChi = txt_NCC_DiaChi.Text;
                    string DienThoai = txt_NCC_SDT.Text;

                    //Gọi các hàm kiểm tra ràng buộc cho nhà cung cấp
                    KiemTraTenNhaCungCap();
                    KiemTraDiaChi();
                    KiemTraSDT();

                    if (lbl_NCC_TenNCC.Visible == false && lbl_NCC_DiaChi.Visible == false && lbl_NCC_SDT.Visible == false)
                    {
                        nhaCungCap = new NhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, DienThoai);
                        nhaCungCapBll.CapNhatNhaCungCap(nhaCungCap);
                        dgvNhaCungCap.CurrentCell = dgvNhaCungCap.Rows[ViTri].Cells[0];
                        dgvNhaCungCap.Rows[ViTri].Selected = true;
                        GanGiaTriNhaCungCap();
                        LoadDataGridViewNhaCungCap();
                        MessageBox.Show("Đã sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                                 
                    }
                }
                catch 
                {
                    MessageBox.Show("Lỗi nhập dữ liệu!\nVui lòng kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void KhoiTaoNhaCungCap()
        {
            if (txt_NCC_TenNhaCungCap.Text == "")
            {
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
                btn_them.Enabled = false;
                btn_xoa.Enabled = false;
                btn_sua.Enabled = false;
                txt_NCC_TenNhaCungCap.Enabled = true;
            }
            else
            {
                btn_them.Enabled = true;
                btn_xoa.Enabled = true;
                btn_huy.Enabled = false;
                btn_sua.Enabled = true;
                btn_luu.Enabled = false;
                btn_MH_Picture.Enabled = false;

                txt_NCC_MaNhaCungCap.Enabled = false;
                txt_NCC_TenNhaCungCap.Enabled = false;
                txt_NCC_DiaChi.Enabled = false;
                txt_NCC_SDT.Enabled = false;

                lbl_NCC_TenNCC.Visible = false;
                lbl_NCC_DiaChi.Visible = false;
                lbl_NCC_SDT.Visible = false;

                pictureBox_NCC_TenNCC.Visible = false;
                pictureBox_NCC_DiaChi.Visible = false;       
                pictureBox_NCC_SDT.Visible = false;
            }
        }

        public void GanGiaTriNhaCungCap()
        {
            try
            {
                if (this.dgvNhaCungCap.SelectedRows.Count == 0)
                    return;
                DataGridViewRow dgvr = this.dgvNhaCungCap.SelectedRows[0];
                GanDieuKienNhaCungCap(dgvr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GanDieuKienNhaCungCap(DataGridViewRow dgvr)
        {
            try
            {
                if (dgvNhaCungCap.Rows.Count != 0)
                {
                    this.txt_NCC_MaNhaCungCap.Text = dgvr.Cells[0].Value.ToString();
                    this.txt_NCC_TenNhaCungCap.Text = dgvr.Cells[1].Value.ToString();
                    this.txt_NCC_DiaChi.Text = dgvr.Cells[2].Value.ToString();
                    this.txt_NCC_SDT.Text = dgvr.Cells[3].Value.ToString();
                }
                else
                {
                    this.txt_NCC_MaNhaCungCap.Text = " ";
                    this.txt_NCC_TenNhaCungCap.Text = "";
                    this.txt_NCC_DiaChi.Text = "";
                    this.txt_NCC_SDT.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {
            GanGiaTriNhaCungCap();
            ViTri = dgvNhaCungCap.CurrentCell.RowIndex;
        }

        #endregion

        #region"Xử lý sự kiện cho Picture"
        private void btn_MH_Picture_Click(object sender, EventArgs e)
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
                        pictureBox_MH.ImageLocation = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc thuộc mặt hàng"

        private void txt_MH_TenMH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                pictureBox_MH_TenMH.Visible = true;
                pictureBox_MH_TenMH.Image=QuanLySieuThiDienThoai.Properties.Resources.error;
                lbl_MH_TenMH.Visible = true;
                lbl_MH_TenMH.Text = "Tên mặt hàng không được ký tự đặc biệt!";

            }
            else
            {
                pictureBox_MH_TenMH.Visible = false;
                lbl_MH_TenMH.Visible = false;
            }
        }

        private void txt_MH_ThoiGianBaoHanh_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

                if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
                {
                    lbl_MH_ThoiGianBaoHanh.Text = "TGBH không được có chữ cái!";
                    lbl_MH_ThoiGianBaoHanh.Visible = true;
                    pictureBox_MH_ThoiGianBaoHanh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                    pictureBox_MH_ThoiGianBaoHanh.Visible = true;
                }
                else
                {
                    pictureBox_MH_ThoiGianBaoHanh.Visible = false;
                    lbl_MH_ThoiGianBaoHanh.Visible = false;
                }
            }
        }

        private void txt_MH_GiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = true;
                lbl_MH_GiaNhap.Text = "Giá nhập không được có chữ cái\nhoăc kí tự đặc biệt!";
                lbl_MH_GiaNhap.Visible = true;
                pictureBox_MH_GiaNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaNhap.Visible = true;

            }
            else
            {
                e.Handled = false;
                pictureBox_MH_GiaNhap.Visible = false;
                lbl_MH_GiaNhap.Visible = false;
            }
        }

        private void txt_MH_GiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)))
            {
                e.Handled = true;
                lbl_MH_GiaBan.Text = "Giá bán không được có chữ cái\nhoăc kí tự đặc biệt!";
                lbl_MH_GiaBan.Visible = true;
                pictureBox_MH_GiaBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaBan.Visible = true;
            }
            else
            {
                pictureBox_MH_GiaBan.Visible = false;
                lbl_MH_GiaBan.Visible = false;
            }
        }

        public void KiemTraTenMatHang()
        {
            int kiemtra = 0;
            DataTable dt = new DataTable();
            dt = matHangBll.DanhSachMatHang();
            if (txt_MH_TenMH.Text == "")
            {
                pictureBox_MH_TenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_TenMH.Visible = true;
                lbl_MH_TenMH.Text = "Chưa nhập tên mặt hàng!";
                lbl_MH_TenMH.Visible = true;
            }
            if (Them == 1)
            {
                if (txt_MH_TenMH.Text != "")
                {
                    for (int i = 0; i < dgvMatHang.Rows.Count; i++)
                    {
                        if (txt_MH_TenMH.Text.Trim().ToLower().Equals(dgvMatHang.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_MH_TenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_MH_TenMH.Visible = true;
                            lbl_MH_TenMH.Text = "Tên mặt hàng đã tồn tại!";
                            lbl_MH_TenMH.Visible = true;
                            kiemtra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_MH_TenMH.Text != "")
                {
                    for (int i = 0; i < dgvMatHang.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_MH_TenMH.Text.Trim().Equals(dgvMatHang.Rows[i].Cells[1].Value.ToString().Trim()))
                        {
                            pictureBox_MH_TenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_MH_TenMH.Visible = true;
                            lbl_MH_TenMH.Text = "Tên mặt hàng đã tồn tại!";
                            lbl_MH_TenMH.Visible = true;
                            kiemtra = 1;
                        }
                    }
                    for (int i = dgvMatHang.CurrentCell.RowIndex + 1; i < dgvMatHang.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_MH_TenMH.Text.Trim().Equals(dgvMatHang.Rows[i].Cells[1].Value.ToString().Trim()))
                        {
                            pictureBox_MH_TenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_MH_TenMH.Visible = true;
                            lbl_MH_TenMH.Text = "Tên mặt hàng đã tồn tại!";
                            lbl_MH_TenMH.Visible = true;
                            kiemtra = 1;
                        }
                    }
                }
            }

            if (txt_MH_TenMH.Text != "" && kiemtra==0)
            {
                pictureBox_MH_TenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_MH_TenMH.Visible = true;
                lbl_MH_TenMH.Visible = false;
            }
        }

        public void KiemTraThoiGianBaoHanh()
        {
            if (txt_MH_ThoiGianBaoHanh.Text == "")
            {
                pictureBox_MH_ThoiGianBaoHanh.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_ThoiGianBaoHanh.Visible = true;
                lbl_MH_ThoiGianBaoHanh.Text = "Chưa nhập thời gian bảo hành!";
                lbl_MH_ThoiGianBaoHanh.Visible = true;
            }
            else
            {
                pictureBox_MH_ThoiGianBaoHanh.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_MH_ThoiGianBaoHanh.Visible = true;
                lbl_MH_ThoiGianBaoHanh.Visible = false;
            }
        }

        public void KiemTraGiaNhap()
        {
            if (txt_MH_GiaNhap.Text == "")
            {
                pictureBox_MH_GiaNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaNhap.Visible = true;
                lbl_MH_GiaNhap.Text = "Chưa nhập giá nhập!";
                lbl_MH_GiaNhap.Visible = true;
            }
            else if(txt_MH_GiaNhap.Text != "" && int.Parse(txt_MH_GiaNhap.Text)<=0)
            {
                pictureBox_MH_GiaNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaNhap.Visible = true;
                lbl_MH_GiaNhap.Text = "Giá nhập phải lớn hơn 0!";
                lbl_MH_GiaNhap.Visible = true;
            }
            else
            {
                pictureBox_MH_GiaNhap.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_MH_GiaNhap.Visible = true;
                lbl_MH_GiaNhap.Visible = false;
            }
        }

        public void KiemTraGiaBan()
        {
            if (txt_MH_GiaBan.Text == "")
            {
                pictureBox_MH_GiaBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaBan.Visible = true;
                lbl_MH_GiaBan.Text = "Bạn chưa nhập giá bán";
                lbl_MH_GiaBan.Visible = true;
            }
            if (txt_MH_GiaBan.Text != "" && int.Parse(txt_MH_GiaBan.Text) <=0)
            {
                pictureBox_MH_GiaBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaBan.Visible = true;
                lbl_MH_GiaBan.Text = "Giá bán phải lớn hơn 0!";
                lbl_MH_GiaBan.Visible = true;
            }
            if(txt_MH_GiaBan.Text != "" && int.Parse(txt_MH_GiaBan.Text) >0 && int.Parse(txt_MH_GiaBan.Text) < int.Parse(txt_MH_GiaNhap.Text))
            {
                pictureBox_MH_GiaBan.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_MH_GiaBan.Visible = true;
                lbl_MH_GiaBan.Text = "Giá bán phải lớn hơn hoặc bằng giá nhập!";
                lbl_MH_GiaBan.Visible = true;
            }
            if (txt_MH_GiaBan.Text != "" && int.Parse(txt_MH_GiaBan.Text) > 0 && int.Parse(txt_MH_GiaBan.Text) >= int.Parse(txt_MH_GiaNhap.Text))
            {
                pictureBox_MH_GiaBan.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_MH_GiaBan.Visible = true;
                lbl_MH_GiaBan.Visible = false;
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc thuộc nhà sản xuất"
        public void KiemTraTenNhaSanXuat()
        {
            int kiemTra = 0;
            DataTable dt = new DataTable();
            dt = nhaSanXuatBll.DanhSachNhaSanXuat();
            if (txt_NSX_TenNhaSanXuat.Text == "")
            {
                pictureBox_NSX_TenNSX.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NSX_TenNSX.Visible = true;
                lbl_NSX_TenNSX.Text = "Chưa nhập tên nhà sản xuất!";
                lbl_NSX_TenNSX.Visible = true;
            }
            if(Them==1)
            {
                if (txt_NSX_TenNhaSanXuat.Text != "")
                {
                    for (int i = 0; i < dgvNhaSanXuat.Rows.Count; i++)
                    {
                        if (txt_NSX_TenNhaSanXuat.Text.Trim().ToLower().Equals(dgvNhaSanXuat.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_NSX_TenNSX.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NSX_TenNSX.Visible = true;
                            lbl_NSX_TenNSX.Text = "Tên nhà sản xuất đã tồn tại!";
                            lbl_NSX_TenNSX.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if(Sua==1)
            {
                if (txt_NSX_TenNhaSanXuat.Text != "")
                {
                    for (int i = 0; i < dgvNhaSanXuat.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_NSX_TenNhaSanXuat.Text.Trim().ToLower().Equals(dgvNhaSanXuat.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_NSX_TenNSX.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NSX_TenNSX.Visible = true;
                            lbl_NSX_TenNSX.Text = "Tên nhà sản xuất đã tồn tại!";
                            lbl_NSX_TenNSX.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvNhaSanXuat.CurrentCell.RowIndex+1; i < dgvNhaSanXuat.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_NSX_TenNhaSanXuat.Text.Trim().ToLower().Equals(dgvNhaSanXuat.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_NSX_TenNSX.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NSX_TenNSX.Visible = true;
                            lbl_NSX_TenNSX.Text = "Tên nhà sản xuất đã tồn tại!";
                            lbl_NSX_TenNSX.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }

            if (txt_NSX_TenNhaSanXuat.Text != "" && kiemTra==0)
            {
                pictureBox_NSX_TenNSX.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NSX_TenNSX.Visible = true;
                lbl_NSX_TenNSX.Visible = false;
            }
        }

        private void txt_NSX_TenNhaSanXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                pictureBox_NSX_TenNSX.Visible = true;
                lbl_NSX_TenNSX.Visible = true;
                lbl_NSX_TenNSX.Text = "Tên nhà sản xuất không được có kí tự đặc biệt!";
            }
            else
            {
                pictureBox_NSX_TenNSX.Visible = false;
                lbl_NSX_TenNSX.Visible = false;
            }
        }
        #endregion

        #region "Kiểm tra các ràng buộc nhà cung cấp"
        private void txt_NCC_TenNhaCungCap_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                pictureBox_NSX_TenNSX.Visible = true;
                lbl_NSX_TenNSX.Visible = true;
                lbl_NSX_TenNSX.Text = "Tên nhà cung cấp không được có kí tự đặc biệt!";
            }
            else
            {
                pictureBox_NSX_TenNSX.Visible = false;
                lbl_NSX_TenNSX.Visible = false;

            }
        }

        private void txt_NCC_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = true;
                lbl_NCC_SDT.Text = "Số điện thoại không được có chữ cái hoặc kí tự đặc biệt!";
                lbl_NCC_SDT.Visible = true;
                pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NCC_SDT.Visible = true;
            }
            else
            {
                pictureBox_NCC_SDT.Visible = false;
                lbl_NCC_SDT.Visible = false;
            }
        }

        public void KiemTraTenNhaCungCap()
        {
            int kiemTra = 0;
            DataTable dt = new DataTable();
            dt = nhaCungCapBll.DanhSachNhaCungCap();   
 
            if (txt_NCC_TenNhaCungCap.Text == "")
            {
                pictureBox_NCC_TenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NCC_TenNCC.Visible = true;
                lbl_NCC_TenNCC.Text = "Chưa nhập tên nhà cung cấp!";
                lbl_NCC_TenNCC.Visible = true;
            }
            if (Them == 1)
            {
                if (txt_NCC_TenNhaCungCap.Text != "")
                {
                    for (int i = 0; i < dgvNhaCungCap.Rows.Count; i++)
                    {
                        if (txt_NCC_TenNhaCungCap.Text.Trim().ToLower().Equals(dgvNhaCungCap.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_NCC_TenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NCC_TenNCC.Visible = true;
                            lbl_NCC_TenNCC.Text = "Tên nhà cung cấp đã tồn tại!";
                            lbl_NCC_TenNCC.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_NCC_TenNhaCungCap.Text != "")
                {
                    for (int i = 0; i < dgvNhaCungCap.CurrentCell.RowIndex; i++)//cho i chạy từ 0 đến vị trí hiện tại
                    {
                        if (txt_NCC_TenNhaCungCap.Text.Trim().ToLower().Equals(dgvNhaCungCap.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_NCC_TenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NCC_TenNCC.Visible = true;
                            lbl_NCC_TenNCC.Text = "Tên nhà cung cấp đã tồn tại!";
                            lbl_NCC_TenNCC.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvNhaCungCap.CurrentCell.RowIndex + 1; i < dgvNhaCungCap.Rows.Count; i++)//cho i chạy từ vị trí hiện tại+1 đến hết 
                    {
                        if (txt_NCC_TenNhaCungCap.Text.Trim().ToLower().Equals(dgvNhaCungCap.Rows[i].Cells[1].Value.ToString().Trim().ToLower()))
                        {
                            pictureBox_NCC_TenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NCC_TenNCC.Visible = true;
                            lbl_NCC_TenNCC.Text = "Tên nhà cung cấp đã tồn tại!";
                            lbl_NCC_TenNCC.Visible = true;
                            kiemTra = 1;       
                        }
                    }
                }
            }

            if (txt_NCC_TenNhaCungCap.Text != "" && kiemTra==0)
            {
                pictureBox_NCC_TenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NCC_TenNCC.Visible = true;
                lbl_NCC_TenNCC.Visible = false;
            }
        }

        public void KiemTraDiaChi()
        {
            if (txt_NCC_DiaChi.Text =="")
            {
                pictureBox_NCC_DiaChi.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NCC_DiaChi.Visible = true;
                lbl_NCC_DiaChi.Visible = true;
                lbl_NCC_DiaChi.Text = "Chưa nhập địa chỉ!";
            }
            else if (txt_NCC_DiaChi.Text.Length < 2)
            {
                pictureBox_NCC_DiaChi.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NCC_DiaChi.Visible = true;
                lbl_NCC_DiaChi.Visible = true;
                lbl_NCC_DiaChi.Text = "Địa chỉ phải từ 2 kí tự trở lên!";
            }
            else
            {
                pictureBox_NCC_DiaChi.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NCC_DiaChi.Visible = true;
                lbl_NCC_DiaChi.Visible = false;
            }
        }

        public void KiemTraSDT()
        {
            int kiemTra = 0;
            DataTable dt = new DataTable();
            dt = nhaCungCapBll.DanhSachNhaCungCap();
            
            if (txt_NCC_SDT.Text == "")
            {
                pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NCC_SDT.Visible = true;
                lbl_NCC_SDT.Text = "Chưa nhập số điện thoại!";
                lbl_NCC_SDT.Visible = true;
            }
            if (txt_NCC_SDT.Text != "" && txt_NCC_SDT.Text.Length < 10)
            {
                pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pictureBox_NCC_SDT.Visible = true;
                lbl_NCC_SDT.Text = "SDT tối thiểu 10 chữ số!";
                lbl_NCC_SDT.Visible = true;
            }
            if (Them == 1)
            {
                if (txt_NCC_SDT.Text != "" && txt_NCC_SDT.Text.Length >= 10)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][3].ToString().Equals(txt_NCC_SDT.Text))
                        {
                            pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NCC_SDT.Visible = true;
                            lbl_NCC_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_NCC_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if (Sua == 1)
            {
                if (txt_NCC_SDT.Text != "" && txt_NCC_SDT.Text.Length >= 10)
                {
                    for (int i = 0; i < dgvNhaCungCap.CurrentCell.RowIndex; i++)
                    {
                        if (dgvNhaCungCap.Rows[i].Cells[3].Value.ToString().Equals(txt_NCC_SDT.Text))
                        {
                            pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NCC_SDT.Visible = true;
                            lbl_NCC_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_NCC_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                    for (int i = dgvNhaCungCap.CurrentCell.RowIndex + 1; i < dgvNhaCungCap.Rows.Count; i++)
                    {
                        if (dgvNhaCungCap.Rows[i].Cells[3].Value.ToString().Equals(txt_NCC_SDT.Text))
                        {
                            pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                            pictureBox_NCC_SDT.Visible = true;
                            lbl_NCC_SDT.Text = "Số điện thoại đã tồn tại!";
                            lbl_NCC_SDT.Visible = true;
                            kiemTra = 1;
                        }
                    }
                }
            }
            if ((txt_NCC_SDT.Text.Length >= 10 && kiemTra == 0))
            {
                pictureBox_NCC_SDT.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pictureBox_NCC_SDT.Visible = true;
                lbl_NCC_SDT.Visible = false;
            }
        }
        #endregion

        #region "Tìm kiếm cho mặt hàng"       
        private void btn_MH_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = matHangBll.TimKiemMatHang(txt_MH_TimKiem.Text);
                dgvMatHang.DataSource = dt;
                if (dgvMatHang.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_MH_TimKiem.Text = null;
                    txt_MH_TimKiem.Focus();
                    LoadDataGridViewMatHang();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }

        }
        #endregion

        #region "Tìm kiếm cho nhà sản xuất"
        private void btn_NSX_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = nhaSanXuatBll.TimKiemNhaSanXuat(txt_NSX_TimKiem.Text);
                dgvNhaSanXuat.DataSource = dt;
                if (dgvNhaSanXuat.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_NSX_TimKiem.Text = null;
                    txt_NSX_TimKiem.Focus();
                    LoadDataGridViewNhaSanXuat();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }
        }
        #endregion

        #region "Tìm kiếm cho nhà cung cấp"
        private void btn_NCC_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = nhaCungCapBll.TimKiemNhaCungCap(txt_NCC_TimKiem.Text);
                dgvNhaCungCap.DataSource = dt;
                if (dgvNhaCungCap.Rows.Count == 0) // Không tìm thấy kết quả
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!\nHệ thống sẽ tự động load lại dữ liệu!", "Thông báo");
                    txt_NCC_TimKiem.Text = null;
                    txt_NCC_TimKiem.Focus();
                    LoadDataGridViewNhaCungCap();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Thông báo");
            }
        }
        #endregion

        private void txt_MH_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_MH_TimKiem.PerformClick();
        }

        private void txt_NSX_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_NSX_TimKiem.PerformClick();
        }

        private void txt_NCC_TimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_NCC_TimKiem.PerformClick();
        }

    }
}

