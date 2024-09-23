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
using System.Data;
using QLDKINTERNET.BLL;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.GUI.StupidGui.StupidContent
{
    /// <summary>
    /// Interaction logic for HoaDonHangThangContent.xaml
    /// </summary>
    public partial class HoaDonHangThangContent : UserControl
    {
        string MaHDTT_current;
        public HoaDonHangThangContent()
        {
            InitializeComponent();
        }

        private void LoadHoaDon()
        {
            HoaDonThanhToanPublic hd_pub = new HoaDonThanhToanPublic();
            hd_pub.MaDV = Convert.ToInt32(txtMaDV.Text);
            HoaDonThanhToanBLL hd_bll = new HoaDonThanhToanBLL();
            DataTable dt = hd_bll.HoaDonThanhToan_Select(hd_pub);
            dgThongTinHoaDon.ItemsSource = dt.AsDataView();
        }
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            LoadHoaDon();
        }

        private void dgThongTinHoaDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                object item = dgThongTinHoaDon.SelectedItem;
                string ID = (dgThongTinHoaDon.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                MaHDTT_current = ID;                
            }
            catch
            {
                MessageBox.Show("Chọn Hóa Đơn");
            }
        }

        private void btnThemHoaDon_Click(object sender, RoutedEventArgs e)
        {
            HoaDonThanhToanPublic hd_pub = new HoaDonThanhToanPublic();
            hd_pub.MaDV = Convert.ToInt32(txtMaDV.Text);
            hd_pub.CuocTuNgay = Convert.ToDateTime(txtTuNgay.Text);
            hd_pub.CuocDenNgay = Convert.ToDateTime(txtDenNgay.Text);
            HoaDonThanhToanBLL hd_bll = new HoaDonThanhToanBLL();
            hd_bll.HoaDonThanhToan_Insert(hd_pub);
            LoadHoaDon();
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            HoaDonThanhToanPublic hd_pub = new HoaDonThanhToanPublic();
            hd_pub.MaHDTT = MaHDTT_current;
            hd_pub.TinhTrangThanhToan = 1;
            HoaDonThanhToanBLL hd_bll = new HoaDonThanhToanBLL();
            hd_bll.HoaDonThanhToan_Update_TinhTrangThanhToan(hd_pub);
            LoadHoaDon();
        }
    }
}
