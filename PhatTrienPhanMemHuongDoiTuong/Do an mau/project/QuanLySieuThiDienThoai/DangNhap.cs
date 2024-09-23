using DTO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThiDienThoai.Connect
{
    public partial class DangNhap : Form
    {
        //Biến kiểm tra số lần đăng nhập sai
        int signinFail = 0;

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            QuanLySieuThiDienThoai.main.PhongBan = null;
            this.Close();
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string matKhau = new GUI.NhanVien().GetMD5(txt_mk.Text);
            if (txt_tendangnhap.Text.Equals("") || txt_mk.Text.Equals(""))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị bỏ trống", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TTDangNhap ttdn = BLL.DangNhapBll.LayThongTinDangNhap(txt_tendangnhap.Text, matKhau); //txt_mk.Text

            if (ttdn.MaNhanVien != null)
            {
                QuanLySieuThiDienThoai.main.PhongBan = ttdn.PhongBan;
                QuanLySieuThiDienThoai.main.TenDangNhap = ttdn.TenNhanVien;
                QuanLySieuThiDienThoai.main.MaNhanVien = ttdn.MaNhanVien;
                this.Close();
                return;
            }
            signinFail++;
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (signinFail == 3)
            {
                MessageBox.Show("Bạn đã sai tên đăng nhập hoặc mật khẩu 3 lần \nỨng dụng sẽ thoát", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        //Nhấn phím Enter để đăng nhập
        private void txt_mk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_dangnhap.PerformClick();
        }


    }
}
