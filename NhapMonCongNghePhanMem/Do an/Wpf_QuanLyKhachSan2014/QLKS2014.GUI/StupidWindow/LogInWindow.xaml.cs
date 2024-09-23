
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLKS2014.GUI.StupidWindow
{
    /// <summary>
    /// Đăng nhập vào hệ thống
    /// </summary>
    public partial class LoginWindow : Window
    {
        //public static DataUser user = new DataUser();
        public LoginWindow()
        {
            InitializeComponent();
            this.lbName.Focus();
            Closing += LogInWindow_Closing;
        }

        void LogInWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBoxResult msb = MessageBox.Show("Đóng toàn bộ chương trình",
            //    "Warnning ", MessageBoxButton.OK);
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //if (
            //    string.IsNullOrEmpty(this.tbxUserName.Text) ||
            //    string.IsNullOrEmpty(this.pwbxPassWord.Password)
            //    )
            //    return;
            //DataUser.userName = this.tbxUserName.Text;
            //Boolean temp = user.testAccount(this.pwbxPassWord.Password);
            //if (temp == false)
            //{
            //    MessageBox.Show(
            //        "Sai tên người dùng hoặc mật khẩu",
            //        "Error", MessageBoxButton.OK, MessageBoxImage.Error
            //        );
            //    return;
            //}
            //lbName.Visibility = System.Windows.Visibility.Hidden;
            //lbPassWord.Visibility = System.Windows.Visibility.Hidden;
            //tbxUserName.Visibility = System.Windows.Visibility.Hidden;
            //pwbxPassWord.Visibility = System.Windows.Visibility.Hidden;
            //btnCancle.Visibility = System.Windows.Visibility.Hidden;
            //btnLogIn.Visibility = System.Windows.Visibility.Hidden;
            //btnLogOut.Visibility = System.Windows.Visibility.Visible;
            //lbShowName.Visibility = System.Windows.Visibility.Visible;
            //lbShowName.Content = "Chào " + DataUser.userName;
            //this.Hide();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            lbName.Visibility = System.Windows.Visibility.Visible;
            lbPassWord.Visibility = System.Windows.Visibility.Visible;
            tbxUserName.Visibility = System.Windows.Visibility.Visible;
            pwbxPassWord.Visibility = System.Windows.Visibility.Visible;
            btnExit.Visibility = System.Windows.Visibility.Visible;
            btnLogIn.Visibility = System.Windows.Visibility.Visible;
            btnLogOut.Visibility = System.Windows.Visibility.Hidden;
            lbShowName.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    if (
            //        string.IsNullOrEmpty(this.tbxUserName.Text) ||
            //        string.IsNullOrEmpty(this.pwbxPassWord.Password)
            //        )
            //        return;
            //    DataUser.userName = this.tbxUserName.Text;
            //    Boolean temp = user.testAccount(this.pwbxPassWord.Password);
            //    if (temp == false)
            //    {
            //        MessageBox.Show(
            //            "Sai tên người dùng hoặc mật khẩu",
            //            "Error", MessageBoxButton.OK, MessageBoxImage.Error
            //            );
            //        return;
            //    }
            //    lbName.Visibility = System.Windows.Visibility.Hidden;
            //    lbPassWord.Visibility = System.Windows.Visibility.Hidden;
            //    tbxUserName.Visibility = System.Windows.Visibility.Hidden;
            //    pwbxPassWord.Visibility = System.Windows.Visibility.Hidden;
            //    btnCancle.Visibility = System.Windows.Visibility.Hidden;
            //    btnLogIn.Visibility = System.Windows.Visibility.Hidden;
            //    btnLogOut.Visibility = System.Windows.Visibility.Visible;
            //    lbShowName.Visibility = System.Windows.Visibility.Visible;
            //    lbShowName.Content = "Chào " + DataUser.userName;
            //    this.Hide();
            //}
        }
    }
}
