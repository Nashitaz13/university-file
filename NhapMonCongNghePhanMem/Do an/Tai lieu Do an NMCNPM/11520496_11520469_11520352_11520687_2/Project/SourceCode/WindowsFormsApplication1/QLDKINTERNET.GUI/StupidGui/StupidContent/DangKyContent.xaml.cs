using QLDKINTERNET.BLL;
using QLDKINTERNET.GUI.StupidUtils;
using QLDKINTERNET.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace QLDKINTERNET.GUI.StupidGui.StupidContent
{
    /// <summary>
    /// Interaction logic for DangKyContent.xaml
    /// </summary>
    public partial class DangKyContent : UserControl, INotifyPropertyChanged
    {
        
        ICollectionView _iDichVuGui;
        HopDongBLL _hopDongBLL;
        DichVuBLL _dichVuBLL;

        public ICollectionView IDichVuGui
        {
            get { return _iDichVuGui; }
            set 
            {
                SetProperty(ref _iDichVuGui, value, "IDichVuGui");
            }
        }

        public DangKyContent()
        {
            InitializeComponent();
            _initializeReference();
            _initializeTiepNhanDangKy();
            IDichVuGui.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dgDichVu_Changed);
        }

        private void dgDichVu_Changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action.CompareTo(System.Collections.Specialized.NotifyCollectionChangedAction.Remove) == 0)
            {
                dgDangKyDichVu.Items.Refresh();
            }
        }

        private void _initializeReference()
        {
            _hopDongBLL = new HopDongBLL();
            _dichVuBLL = new DichVuBLL();
        }

        private void btnDangKy_Click(object sender, RoutedEventArgs e)
        {
            // kiem tra thong tin dang ky hop le
            if (_isTiepNhanDangKyInforInvalid())
            {
                MessageBox.Show("Thông tin đăng ký không chính xác, xin nhập lại");
                return;
            }

            // Kiem tra da nhap dich vu
            int count = ((IEnumerable<DichVuGui>)_iDichVuGui.SourceCollection).Count();
            if (count == 0)
            {
                MessageBox.Show("Mời nhập ít nhất 1 dịch vụ!");
                return;
            }

            // Dang ky hop dong
            HopDongPublic hopDong = new HopDongPublic();
            hopDong.HoTen = this.txtbTenKhachHang.Text;
            hopDong.CMND = this.txtbSoCMND.Text;
            hopDong.NgheNghiep = txtbNgheNghiep.Text;
            hopDong.ChucVu = txtbChucVu.Text;
            hopDong.DiaChi = txtbDiaChi.Text;
            hopDong.Email = txtbEmail.Text;
            hopDong.DienThoai = txtbSoDienThoai.Text;
            hopDong.NgayDangKy = (DateTime)dpNgayDangKy.SelectedDate;
            _hopDongBLL.TiepNhanKhachHang(hopDong);

            MessageBox.Show("Đăng ký hợp đồng thành công!");

            /// Dang ky dich vu
            /// 
            try
            {

                // Lay ma hop dong
                HopDongPublic hopDongPublic = _getHopDong(txtbSoCMND.Text);
                int maHopDong = hopDongPublic.MaHopDong;
                // Dang ky tung dich vu
                IEnumerable<DichVuGui> iDichVu = _iDichVuGui.SourceCollection as IEnumerable<DichVuGui>;
                IEnumerator<DichVuGui> itorDichVu = iDichVu.GetEnumerator();
                while (itorDichVu.MoveNext())
                {
                    DichVuGui tmp = itorDichVu.Current;
                    DichVuPublic dichVuPublicTmp = new DichVuPublic();
                    dichVuPublicTmp.DiaChiCaiDat = tmp.DiaChiCaiDat;
                    dichVuPublicTmp.DiaChiHoaDon = tmp.DiaChiHoaDon;
                    dichVuPublicTmp.MaDV = 0;
                    dichVuPublicTmp.MaHopDong = maHopDong;
                    dichVuPublicTmp.NgayDangKy = (DateTime)dpNgayDangKy.SelectedDate;
                    dichVuPublicTmp.NgayLapDat = dichVuPublicTmp.NgayDangKy;
                    dichVuPublicTmp.PhiLapDat = 0;
                    dichVuPublicTmp.SoLuongTaiKhoan = tmp.SoLuongTaiKhoan;
                    dichVuPublicTmp.TenDichVu = "anonymous";
                    dichVuPublicTmp.TinhTrangDichVu = 0;
                    dichVuPublicTmp.TinhTrangThanhToan = 0;

                    dichVuPublicTmp.MaGoiCuoc = tmp.TenGoiCuoc;
                    dichVuPublicTmp.MaKieuCaiDat = tmp.TenKieuCaiDat;
                    dichVuPublicTmp.MaModem = tmp.TenModem;

                    //luu vao csdl
                    _dichVuBLL.DangKyDichVu(dichVuPublicTmp);
                }
                MessageBox.Show("Đăng ký các dịch vụ thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký dịch vụ bị lỗi!");
            }
        }

        private bool _isTiepNhanDangKyInforInvalid()
        {
            return txtbDiaChi.Text.Length == 0 || txtbSoCMND.Text.Length < 9 || txtbTenKhachHang.Text.Length < 4 || !dpNgayDangKy.SelectedDate.HasValue;
        }

        private HopDongPublic _getHopDong(String cmnd_)
        {
            HopDongPublic hopDongPublic = new HopDongPublic();
            hopDongPublic.init();
            hopDongPublic.CMND = txtbSoCMND.Text;
            DataTable dtHopDong = _hopDongBLL.TimKiemKhachHang(hopDongPublic);
            List<HopDongPublic> lHopDongPublic = new List<HopDongPublic>();
            lHopDongPublic = new List<HopDongPublic>(
               (from dRow in dtHopDong.AsEnumerable()
                select (UtilsGui.dataRowToHopDongPublic(dRow)))
               );
            return lHopDongPublic.ElementAt(0);
        }

        private void _initializeTiepNhanDangKy()
        {
            List<DichVuGui> lDichVu = new List<DichVuGui>();
            IDichVuGui = CollectionViewSource.GetDefaultView(lDichVu);

            _init_dbcbbTenGoiCuoc();

            _init_dgcbbTenModem();

            _init_dgcbbTenKieuCaiDat();
        }

        private void _init_dgcbbTenKieuCaiDat()
        {
            // init dg combobox TenKieuCaiDat
            List<KieuCaiDatPublic> lKieuCaiDatPublic = UtilsGui.getListKieuCaiDat();
            List<String> lTenKieuCaiDat = new List<string>();
            foreach (KieuCaiDatPublic kieuCaiDat in lKieuCaiDatPublic)
            {
                lTenKieuCaiDat.Add(kieuCaiDat.TenKieuCaiDat);
            }
            dgcbbTenKieuCaiDat.ItemsSource = lTenKieuCaiDat;
        }

        private void _init_dgcbbTenModem()
        {
            // init dg combobox TenModem
            List<ModemPublic> lModemPublic = UtilsGui.getListModem();
            List<String> lTenModem = new List<string>();
            foreach (ModemPublic modem in lModemPublic)
            {
                lTenModem.Add(modem.TenModem);
            }
            dgcbbTenModem.ItemsSource = lTenModem;
        }

        private void _init_dbcbbTenGoiCuoc()
        {
            // init dg combobox TenGoiCuoc
            List<GoiCuocPublic> lGoiCuocPublic = UtilsGui.getListGoiCuoc();
            List<String> lTenGoiCuoc = new List<string>();
            foreach (GoiCuocPublic goiCuoc in lGoiCuocPublic)
            {
                lTenGoiCuoc.Add(goiCuoc.TenGoiCuoc);
            }
            dgcbbTenGoiCuoc.ItemsSource = lTenGoiCuoc;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        #region Interface PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetProperty<T>(ref T property, T value, string propertyName)
        {
            if (!object.Equals(property, value))
            {
                property = value;
                OnPropertyChanged(propertyName);
            }
        }
        #endregion

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            _initializeTiepNhanDangKy();
        }

        private void txtbSoCMND_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtbSoDienThoai_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
