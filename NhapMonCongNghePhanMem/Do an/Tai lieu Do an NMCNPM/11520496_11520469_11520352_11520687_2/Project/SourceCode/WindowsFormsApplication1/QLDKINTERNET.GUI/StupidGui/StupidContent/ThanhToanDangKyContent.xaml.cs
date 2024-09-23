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
using QLDKINTERNET.Public;
using QLDKINTERNET.BLL;
using System.Data;

namespace QLDKINTERNET.GUI.StupidGui.StupidContent
{
    /// <summary>
    /// Interaction logic for ThanhToanDangKyContent.xaml
    /// </summary>
    public partial class ThanhToanDangKyContent : UserControl
    {
        private int max_account = 0;
        private int current_MaDV;
        public ThanhToanDangKyContent()
        {
            InitializeComponent();

        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            dgThongTinHopDong.ItemsSource = null;

            HopDongPublic hd_pub = new HopDongPublic();
            hd_pub.HoTen = txtTenKhachHang.Text.Trim();
            hd_pub.CMND = txtCMND.Text.Trim();
            hd_pub.NgheNghiep = "";
            hd_pub.Email = "";
            hd_pub.ChucVu = "";
            hd_pub.DiaChi = "";
            hd_pub.DienThoai = "";

            HopDongBLL hd_bll = new HopDongBLL();
            dgThongTinHopDong.ItemsSource = hd_bll.TimKiemKhachHang(hd_pub).AsDataView();
        }

        private void dgThongTinHopDong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DichVuPublic dv_pub = new DichVuPublic();
            
            try
            {
                object item = dgThongTinHopDong.SelectedItem;
                string ID = (dgThongTinHopDong.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                dv_pub.MaHopDong = Convert.ToInt32(ID);
                dv_pub.TinhTrangThanhToan = 0;

                DichVuBLL dv_bll = new DichVuBLL();
                dgThongTinDichVu.ItemsSource = dv_bll.DichVu_Select_TheoTinhTrangThanhToan(dv_pub).AsDataView();
            }
            catch
            {
                MessageBox.Show("Chọn Khách Hàng");
            }
             
        }

        private void dgThongTinDichVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object item = dgThongTinDichVu.SelectedItem;
                string ID = (dgThongTinDichVu.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                current_MaDV = Convert.ToInt32(ID);
                string ID1 = (dgThongTinDichVu.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                max_account = Convert.ToInt32(ID1);
                btnThem.IsEnabled = true;
                MessageBox.Show("Hãy Thêm Tên Đăng Nhập Ở Bên Dưới");
            }
            catch
            {
                MessageBox.Show("Chọn Dịch Vụ");                    
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            int num = Convert.ToInt32(lblAccNum.Content);
            if ( num == max_account)
            {
                TaiKhoanDangNhapPublic tk_pub = new TaiKhoanDangNhapPublic();
                tk_pub.Username = txtUser.Text.Trim();
                tk_pub.Password = txtPass.Password;
                tk_pub.MaDV = current_MaDV;
                TaiKhoanDangNhapBLL tk_bll = new TaiKhoanDangNhapBLL();
                tk_bll.TaiKhoanDangNhap_Insert(tk_pub);
                lblAccNum.Content = "1";
                txtUser.Text = "admin1";
                txtPass.Password = "";
                btnThem.IsEnabled = false;
                btnThanhToan.IsEnabled = true;                
            }
            else if (num > max_account)
            {
                MessageBox.Show("Đã quá số tài khoản tối đa");
            }
            else
            {
                TaiKhoanDangNhapPublic tk_pub = new TaiKhoanDangNhapPublic();
                tk_pub.Username = txtUser.Text.Trim();
                tk_pub.Password = txtPass.Password;
                tk_pub.MaDV = current_MaDV;
                TaiKhoanDangNhapBLL tk_bll = new TaiKhoanDangNhapBLL();
                tk_bll.TaiKhoanDangNhap_Insert(tk_pub);
                lblAccNum.Content = (num + 1).ToString();
                txtUser.Text = "admin" + lblAccNum.Content;
            }
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            DichVuPublic dv_pub = new DichVuPublic();
            dv_pub.MaDV = current_MaDV;
            dv_pub.TinhTrangThanhToan = 1;
            DichVuBLL dv_bll = new DichVuBLL();
            dv_bll.DichVu_Update_TinhTrangThanhToan(dv_pub);
            btnThanhToan.IsEnabled = false;
        }

    }
}
