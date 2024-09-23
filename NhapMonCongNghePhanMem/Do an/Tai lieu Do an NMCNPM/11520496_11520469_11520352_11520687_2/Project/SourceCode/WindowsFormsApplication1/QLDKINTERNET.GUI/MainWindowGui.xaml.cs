using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLDKINTERNET.Public;
using QLDKINTERNET.BLL;
using System.Data;
using QLDKINTERNET.GUI.StupidGui.StupidContent;
using QLDKINTERNET.GUI.StupidGui.StupidWindow;

namespace QLDKINTERNET.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowGui : Window
    {
        HopDongBLL hopDongBLL;        
        ICollectionView _iDanhSachKhachHang;

        // define Usercontent
        DangKyContent _dangKyContent;
        ThanhToanDangKyContent _thanhToanDangKyContent;
        TinhTrangDichVuContent _tinhTrangDichVuContent;

        
        public ICollectionView IDanhSachKhachHang
        {
            get { return _iDanhSachKhachHang; }
            set { _iDanhSachKhachHang = value; }
        }
        
        public MainWindowGui()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindowGui_Loaded);
        }

        private void MainWindowGui_Loaded(object sender, RoutedEventArgs e)
        {
            _initializeUserContent();
            _initializeBLL();
            //_initializeDanhSachKhachHang();
        }

        private void _initializeUserContent()
        {
            // init DangKyContent
            _dangKyContent = new DangKyContent();
            ccDangKy.Content = _dangKyContent;

            // init ThanhToanDangKy ct
            _thanhToanDangKyContent = new ThanhToanDangKyContent();
            ccThanhToanDangKy.Content = _thanhToanDangKyContent;

            // init TTDichVu ct
            _tinhTrangDichVuContent = new TinhTrangDichVuContent();
            ccTinhTrangDichVu.Content = _tinhTrangDichVuContent;
        }

        private void _initializeBLL()
        {
            hopDongBLL = new HopDongBLL();
        }

        //private void _initializeDanhSachKhachHang()
        //{
        //    DataTable dtHopDong = hopDongBLL.HopDong_SelectAll();
        //    dgDanhSachKhachHang.ItemsSource = dtHopDong.AsDataView();
        //}

        private void btnQuanLyKhachHang_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDataSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }


    }
}
