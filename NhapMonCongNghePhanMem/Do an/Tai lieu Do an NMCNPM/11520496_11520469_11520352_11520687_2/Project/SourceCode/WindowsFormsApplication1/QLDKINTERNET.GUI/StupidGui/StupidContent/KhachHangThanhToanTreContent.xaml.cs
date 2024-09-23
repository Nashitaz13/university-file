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
    /// Interaction logic for KhachHangThanhToanTreContent.xaml
    /// </summary>
    public partial class KhachHangThanhToanTreContent : UserControl
    {
        public KhachHangThanhToanTreContent()
        {
            InitializeComponent();
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            HoaDonThanhToanBLL hd_bll = new HoaDonThanhToanBLL();
            DataTable dt1 = new DataTable();
            dt1 = hd_bll.HoaDonThanhToan_HoaDonChuaThanhToan();
            DataTable dt2 = new DataTable();
            dt2 = hd_bll.HoaDonThanhToan_HoaDonQuaHan();
            dgHoaDonChuaThanhToan.ItemsSource = dt1.AsDataView();
            dgHoaDonQuaHan.ItemsSource = dt2.AsDataView();
            
        }

        private void btnCatMang_Click(object sender, RoutedEventArgs e)
        {
            DichVuBLL dv_bll = new DichVuBLL();
            dv_bll.DichVu_CatMangDichVuChuaThanhToan();
            MessageBox.Show("Đã Cắt");
        }
    }
}
