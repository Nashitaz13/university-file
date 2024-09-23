using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNT.DataTransferObject
{
    public class DtoPhieuXuatThuoc : INotifyPropertyChanged
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

        private int _MaHoaDonXuat; public int MaHoaDonXuat { get { return _MaHoaDonXuat; } set { _MaHoaDonXuat = value; } }
        private int _MaNguoiGhiPhieu; public int MaNguoiGhiPhieu { get { return _MaNguoiGhiPhieu; } set { _MaNguoiGhiPhieu = value; } }
        private int _MaNguoiPhatThuoc; public int MaNguoiPhatThuoc { get { return _MaNguoiPhatThuoc; } set { _MaNguoiPhatThuoc = value; } }
        private string _SeriHoaDonXuat; public string SeriHoaDonXuat { get { return _SeriHoaDonXuat; } set { _SeriHoaDonXuat = value; } }
        private string _ThongTinBenhNhan; public string ThongTinBenhNhan { get { return _ThongTinBenhNhan; } set { _ThongTinBenhNhan = value; } }
        private DateTime? _NgayXuat; public DateTime? NgayXuat { get { if (_NgayXuat == SqlDateTime.MinValue.Value) { _NgayXuat = null; } return _NgayXuat; } set { _NgayXuat = value; } }
        
        private long _TongTienThuoc;
        public long TongTienThuoc 
        { 
            get { return _TongTienThuoc; } 
            set 
            {                
                if (value != _TongTienThuoc)
                {
                    _TongTienThuoc = value;
                    OnPropertyChanged("TongTienThuoc");
                }
            } 
        }

        private long _TongTienVAT;
        public long TongTienVAT 
        { 
            get { return _TongTienVAT; } 
            set 
            {
                if (value != _TongTienVAT)
                {
                    _TongTienVAT = value;
                    OnPropertyChanged("TongTienVAT");
                }
            } 
        }

        private long _TongTienThanhToan;
        public long TongTienThanhToan 
        { 
            get { return _TongTienThanhToan; } 
            set 
            {
                if (value != _TongTienThanhToan)
                {
                    _TongTienThanhToan = value;
                    OnPropertyChanged("TongTienThanhToan");
                }
            } 
        }
    }

    public class DtoChiTietPhieuXuatThuoc
    {
        private int _MaHoaDonXuat; public int MaHoaDonXuat { get { return _MaHoaDonXuat; } set { _MaHoaDonXuat = value; } }
        private int _MaThuoc; public int MaThuoc { get { return _MaThuoc; } set { _MaThuoc = value; } }
        private int _SoLuong; public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; } }
        private int _DonGiaXuat; public int DonGiaXuat { get { return _DonGiaXuat; } set { _DonGiaXuat = value; } }      
        private long _ThanhTien; public long ThanhTien { get { return _ThanhTien; } set { _ThanhTien = value; } }
        private int _SoLuongBanDau; public int SoLuongBanDau { get { return _SoLuongBanDau; } set { _SoLuongBanDau = value; } }
    }
}
