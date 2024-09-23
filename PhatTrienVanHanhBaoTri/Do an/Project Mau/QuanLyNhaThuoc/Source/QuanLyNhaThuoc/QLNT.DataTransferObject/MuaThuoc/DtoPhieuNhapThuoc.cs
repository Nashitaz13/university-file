using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNT.DataTransferObject
{
    public class DtoPhieuNhapThuoc : INotifyPropertyChanged
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

        private int _MaHoaDonNhap; public int MaHoaDonNhap { get { return _MaHoaDonNhap; } set { _MaHoaDonNhap = value; } }
        private int _MaHinhThucThanhToan; public int MaHinhThucThanhToan { get { return _MaHinhThucThanhToan; } set { _MaHinhThucThanhToan = value; } }
        private int _MaNhaCungCap; public int MaNhaCungCap { get { return _MaNhaCungCap; } set { _MaNhaCungCap = value; } }
        private int _MaNhanVien; public int MaNhanVien { get { return _MaNhanVien; } set { _MaNhanVien = value; } }
        public int VAT { get; set; }
        private string _SeriHoaDonNhap; public string SeriHoaDonNhap { get { return _SeriHoaDonNhap; } set { _SeriHoaDonNhap = value; } }       
        private DateTime? _NgayNhap; public DateTime? NgayNhap { get { if (_NgayNhap == SqlDateTime.MinValue.Value) { _NgayNhap = null; } return _NgayNhap; } set { _NgayNhap = value; } }

        private decimal _TongTienThuoc;
        public decimal TongTienThuoc
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

        private decimal _TienVAT;
        public decimal TienVAT
        {
            get { return _TienVAT; }
            set
            {
                if (value != _TienVAT)
                {
                    _TienVAT = value;
                    OnPropertyChanged("TienVAT");
                }
            }
        }

        private decimal _TongTienThanhToan;
        public decimal TongTienThanhToan
        {
            get { return _TongTienThanhToan; }
            set
            {
                if (value != _TongTienThanhToan)
                {
                    _TongTienThanhToan = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged("TongTienThanhToan");
                }
            }
        }
        private string _GhiChu; public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; } }
    }

    public class DtoChiTietPhieuNhapThuoc
    {
        private int _MaHoaDonNhap; public int MaHoaDonNhap { get { return _MaHoaDonNhap; } set { _MaHoaDonNhap = value; } }
        private int _MaThuoc; public int MaThuoc { get { return _MaThuoc; } set { _MaThuoc = value; } }
        private string _SoLo; public string SoLo { get { return _SoLo; } set { _SoLo = value; } }
        private DateTime? _NgaySanXuat; public DateTime? NgaySanXuat { get { if (_NgaySanXuat == SqlDateTime.MinValue.Value) { _NgaySanXuat = null; } return _NgaySanXuat; } set { _NgaySanXuat = value; } }
        private DateTime? _NgayHetHan; public DateTime? NgayHetHan { get { if (_NgayHetHan == SqlDateTime.MinValue.Value) { _NgayHetHan = null; } return _NgayHetHan; } set { _NgayHetHan = value; } }
        private int _SoLuong; public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; } }
        private decimal _DonGia; public decimal DonGia { get { return _DonGia; } set { _DonGia = value; } }
        private decimal _ThanhTien; public decimal ThanhTien { get { return _ThanhTien; } set { _ThanhTien = value; } }
        //private int _SoLuongDuocPhepXuat; public int SoLuongDuocPhepXuat { get { return _SoLuongDuocPhepXuat; } set { _SoLuongDuocPhepXuat = value; } }
        private int _SoLuongBanDau; public int SoLuongBanDau { get { return _SoLuongBanDau; } set { _SoLuongBanDau = value; } }
    }
}
