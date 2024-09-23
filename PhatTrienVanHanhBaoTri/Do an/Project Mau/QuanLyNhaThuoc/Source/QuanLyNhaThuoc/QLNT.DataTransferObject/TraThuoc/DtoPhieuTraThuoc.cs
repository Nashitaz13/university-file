using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNT.DataTransferObject
{
    public class DtoPhieuTraThuoc : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _MaPhieuTraThuoc; public int MaPhieuTraThuoc { get { return _MaPhieuTraThuoc; } set { _MaPhieuTraThuoc = value; } }
        private int _MaHoaDonXuat; public int MaHoaDonXuat { get { return _MaHoaDonXuat; } set { _MaHoaDonXuat = value; } }
        private string _SeriHoaDonTra; public string SeriHoaDonTra { get { return _SeriHoaDonTra; } set { _SeriHoaDonTra = value; } }
        private int _MaNguoiGhiPhieu; public int MaNguoiGhiPhieu { get { return _MaNguoiGhiPhieu; } set { _MaNguoiGhiPhieu = value; } }
        private int _MaNguoiNhanThuoc; public int MaNguoiNhanThuoc { get { return _MaNguoiNhanThuoc; } set { _MaNguoiNhanThuoc = value; } }
        private DateTime? _NgayTraThuoc; public DateTime? NgayTraThuoc { get { if (_NgayTraThuoc == SqlDateTime.MinValue.Value) { _NgayTraThuoc = null; } return _NgayTraThuoc; } set { _NgayTraThuoc = value; } }
        private string _LyDo; public string LyDo { get { return _LyDo; } set { _LyDo = value; } }
        private long _TongTienPhaiTra; 
        public long TongTienPhaiTra 
        { 
            get { return _TongTienPhaiTra; } 
            set 
            { 
                if (value != _TongTienPhaiTra)
                {
                    _TongTienPhaiTra = value;
                    OnPropertyChanged("TongTienPhaiTra");
                }
            } 
        }
    }

    public class DtoChiTietPhieuTraThuoc
    {
        private int _MaPhieuTraThuoc; public int MaPhieuTraThuoc { get { return _MaPhieuTraThuoc; } set { _MaPhieuTraThuoc = value; } }
        private int _MaThuoc; public int MaThuoc { get { return _MaThuoc; } set { _MaThuoc = value; } }
        private int _SoLuongXuatBanDau; public int SoLuongXuatBanDau { get { return _SoLuongXuatBanDau; } set { _SoLuongXuatBanDau = value; } }
        private int _SoLuongTra; public int SoLuongTra { get { return _SoLuongTra; } set { _SoLuongTra = value; } }
        private int _DonGiaXuat; public int DonGiaXuat { get { return _DonGiaXuat; } set { _DonGiaXuat = value; } }
        private int _VAT; public int VAT { get { return _VAT; } set { _VAT = value; } }
        private long _ThanhTien; public long ThanhTien { get { return _ThanhTien; } set { _ThanhTien = value; } }
        private int _SoLuongBanDau; public int SoLuongBanDau { get { return _SoLuongBanDau; } set { _SoLuongBanDau = value; } }
    }
}
