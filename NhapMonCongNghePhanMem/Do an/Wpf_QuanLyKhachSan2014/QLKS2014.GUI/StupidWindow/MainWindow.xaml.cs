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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using QLKS2014.GUI.StupidContent;

namespace QLKS2014.GUI.StupidWindow
{
    /// <summary>
    /// Mô tả: cửa sổ chính của chương trình
    /// có thể gọi tất cả các cửa sổ con khác
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        Bill bill;
        ListRoom listRoom;
        RentRoom rentRoom;
        CreateReport createReport;
        SearchRoom searchRoom;
        LoginWindow _loginWindow;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _initialize();
            _showLoginWindow();
        }

        private void _showLoginWindow()
        {
            //_loginWindow.ShowDialog();
        }

        private void _initialize()
        {
            _initializeControl();
            _initializeWindow();
        }

        private void _initializeWindow()
        {
            if(_loginWindow ==null)
                _loginWindow = new LoginWindow();
        }

        private void _initializeControl()
        {
            bill = new Bill();
            listRoom = new ListRoom();
            rentRoom = new RentRoom();
            createReport = new CreateReport();
            searchRoom = new SearchRoom();
            ccBill.Content = bill;
            ccListRoom.Content = listRoom;
            ccRentRoom.Content = rentRoom;
            ccCreateReport.Content = createReport;
            ccSearchRoom.Content = searchRoom;

            
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnUserManual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process pUser = new Process();
                pUser.StartInfo.FileName = getPath();
                pUser.StartInfo.CreateNoWindow = true;
                pUser.Start();
            }
            catch
            {
                MessageBox.Show("Khong tim thay tap tin readme");
            }

        }

        public String getPath()
        {
            String path = "";
            path = System.IO.Path.GetFullPath(@"ReaadMe\Readme.docx");
            path = path.Replace("bin\\Debug\\", "");
            return path;
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow setting = new SettingsWindow();
            setting.ShowDialog();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (_loginWindow.ShowActivated == true)
                _loginWindow.ShowDialog();
            else
            {
                _loginWindow = new LoginWindow();
                _loginWindow.ShowDialog();
            }
        }

        private void btnAddOrEditRoom_Click(object sender, RoutedEventArgs e)
        {
            bool isFocus = tListRoom.IsFocused;
            if (isFocus)
            {
                listRoom.showAddingRoom(false); // false for auto show/hide
            }
            else
            {
                tListRoom.Focus();
                listRoom.showAddingRoom(true);
            }
            
            
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //listRoom.contentEditRoom.Visibility = System.Windows.Visibility.Collapsed;
            //listRoom.refresh();
            //this.tabListRoom.Focus();
        }

        private void btnNewBill_Click(object sender, RoutedEventArgs e)
        {
            tBill.Focus();
        }

        private void btnNewRentRoom_Click(object sender, RoutedEventArgs e)
        {
            tRentRoom.Focus();

        }

        private void btnViewListRentRoom_Click(object sender, RoutedEventArgs e)
        {
            ListRentRoomWindow listRentRoom = new ListRentRoomWindow();
            listRentRoom.Show();
        }

        private void btnListBill_Click(object sender, RoutedEventArgs e)
        {
            ListBillWindow listBill = new ListBillWindow();
            listBill.Show();
        }

        private void btnListReport_Click(object sender, RoutedEventArgs e)
        {
            ListReportWindow listReport = new ListReportWindow();
            listReport.Show();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            DetailRoomRentedWindow dataCustomer = new DetailRoomRentedWindow();
            dataCustomer.Show();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
