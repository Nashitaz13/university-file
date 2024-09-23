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
using QLDKINTERNET.Public;
using QLDKINTERNET.BLL;
namespace QLDKINTERNET.GUI.StupidGui.StupidContent
{
    /// <summary>
    /// Interaction logic for TinhTrangDichVuContent.xaml
    /// </summary>
    public partial class TinhTrangDichVuContent : UserControl
    {
        int current_MaDVTat;
        int current_MaDVMo;
        public TinhTrangDichVuContent()
        {
            InitializeComponent();
            Load_DichVuTat();
            Load_DichVuMo();
        }

        public void Load_DichVuTat()
        {
            DichVuBLL dv_bll = new DichVuBLL ();
            DataTable dt = dv_bll.DichVu_Select_TinhTrangDichVu_ThanhToan();
            dgDichVuTat.ItemsSource = dt.AsDataView();
        }

        public void Load_DichVuMo()
        {
            DichVuBLL dv_bll = new DichVuBLL();
            DataTable dt = dv_bll.DichVu_Select_TinhTrangDichVu();
            dgDichVuMo.ItemsSource = dt.AsDataView();
        }

        private void dgDichVuTat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object item = dgDichVuTat.SelectedItem;
                string ID = (dgDichVuTat.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                current_MaDVTat = Convert.ToInt32(ID);
            }
            catch
            {
                MessageBox.Show("Chọn Dịch Vụ");
            }
        }

        private void dgDichVuMo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object item = dgDichVuMo.SelectedItem;
                string ID = (dgDichVuMo.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                current_MaDVMo = Convert.ToInt32(ID);
            }
            catch
            {
                MessageBox.Show("Chọn Dịch Vụ");
            }
        }

        private void btnMo_Click(object sender, RoutedEventArgs e)
        {
            DichVuPublic dv_pub = new DichVuPublic();
            dv_pub.MaDV = current_MaDVTat;
            dv_pub.TinhTrangDichVu = 1;
            DichVuBLL dv_bll = new DichVuBLL();
            dv_bll.DichVu_Update_TinhTrangDichVu(dv_pub);
            Load_DichVuTat();
            Load_DichVuMo();
        }

        private void btnTat_Click(object sender, RoutedEventArgs e)
        {
            DichVuPublic dv_pub = new DichVuPublic();
            dv_pub.MaDV = current_MaDVMo;
            dv_pub.TinhTrangDichVu = 0;
            DichVuBLL dv_bll = new DichVuBLL();
            dv_bll.DichVu_Update_TinhTrangDichVu(dv_pub);
            Load_DichVuMo();
            Load_DichVuTat();
        }

    }
}
