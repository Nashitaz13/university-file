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
using QuanLyKhachSan.View.ContentView;
using QuanLyKhachSan.View.Windows;
using QuanLyKhachSan.ProcessData;

namespace QuanLyKhachSan
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
        Report report;
        Search search;
        LogInWindow logIn;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bill = new Bill();
            listRoom = new ListRoom();
            rentRoom = new RentRoom();
            report = new Report();
            search = new Search();
            logIn = new LogInWindow();
            contentBill.Content = bill;
            contentListRoom.Content = listRoom;
            contentRentRoom.Content = rentRoom;
            contentReport.Content = report;
            contentSearchRoom.Content = search;
            logIn.ShowDialog();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutProgram about = new AboutProgram();
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
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (logIn.ShowActivated == true)
                logIn.ShowDialog();
            else
            {
                logIn = new LogInWindow();
                logIn.ShowDialog();
            }
        }

        private void btnAddOrEditRoom_Click(object sender, RoutedEventArgs e)
        {
            UpdateRoom updateRoom = new UpdateRoom();
            listRoom.addRoom();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            listRoom.contentEditRoom.Visibility = System.Windows.Visibility.Collapsed;
            listRoom.refresh();
            this.tabListRoom.Focus();
        }

        private void btnNewBill_Click(object sender, RoutedEventArgs e)
        {
            this.tabBill.Focus();
            bill.clear();
        }

        private void btnNewRentRoom_Click(object sender, RoutedEventArgs e)
        {
            rentRoom.clear();
            tabRentRoom.Focus();
        }

        private void btnViewListRentRoom_Click(object sender, RoutedEventArgs e)
        {
            ListRentRoom listRentRoom = new ListRentRoom();
            listRentRoom.Show();
        }

        private void btnListBill_Click(object sender, RoutedEventArgs e)
        {
            ListBiil listBill = new ListBiil();
            listBill.Show();
        }

        private void btnListReport_Click(object sender, RoutedEventArgs e)
        {
            ListReport listReport = new ListReport();
            listReport.Show();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            DetailRoomRented dataCustomer = new DetailRoomRented();
            dataCustomer.Show();
        }
    }
}
