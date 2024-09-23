using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BLL;

namespace QuanLyCuaHangLinhKienMayTinh
{
    public partial class frmLogin : Form
    {
        public int _exit = 0;
        LoginBLL d = new LoginBLL();
        public frmLogin()
        {
            InitializeComponent();
        }
         
        



        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessLogin();
            }
        }


        public void ProcessLogin()
        {
            if (txtID.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
            {
                lb_loi.Text = "Lỗi ! Nhập sai mã nhân viên hoặc sai mật khẩu...";
            }
            else
            {
                if (d.CheckDangNhap(txtID.Text, txtPassword.Text))
                {
                    lb_loi.Text = "Đăng nhập thành công.!";
                    //this.Close();
                }
                else
                {
                    lb_loi.Text = "Lỗi ! Nhập sai mã nhân viên hoặc sai mật khẩu...";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _exit = 1;
            this.Close();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ trực tiếp với quản lý để được cấp tài khoản");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }
    }
}
