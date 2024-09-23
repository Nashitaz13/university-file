using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QLCHMT
{
    public partial class Login : Form
    {
        int signinFail = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (txt_tendangnhap.Text.Equals("") || txt_mk.Text.Equals(""))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu bị bỏ trống", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string matKhau = GetMD5(txt_mk.Text);
            nHANVIENTableAdapter.FillByLogin(qLCHDTdataset.NHANVIEN, txt_tendangnhap.Text, matKhau);
            if (qLCHDTdataset.NHANVIEN.Count != 0)
            {
                main.MaNhanVien= qLCHDTdataset.NHANVIEN[0][0].ToString();
                main.TenNhanVien = qLCHDTdataset.NHANVIEN[0][1].ToString();
                this.Close();
                return;
            }
            signinFail++;
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_mk.Text = "";
            if (signinFail == 3)
            {
                MessageBox.Show("Bạn đã sai tên đăng nhập hoặc mật khẩu 3 lần \nỨng dụng sẽ thoát", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            main.TenNhanVien = "Guest";
            main.MaNhanVien = null;
            this.Close();
        }
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

        private void txt_mk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_dangnhap.PerformClick();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLCHDTdataset.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qLCHDTdataset.NHANVIEN);

        }
    }
}
