using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class ChiTietPhieuThuePhongPublic
    {
        private int _maChiTietPhieuThuePhong;

        public int MaChiTietPhieuThuePhong
        {
            get { return _maChiTietPhieuThuePhong; }
            set { _maChiTietPhieuThuePhong = value; }
        }
        private int _maPhieuThue;

        public int MaPhieuThue
        {
            get { return _maPhieuThue; }
            set { _maPhieuThue = value; }
        }
        private string _tenKhachHang;

        public string TenKhachHang
        {
            get { return _tenKhachHang; }
            set { _tenKhachHang = value; }
        }
        private string _cMND;

        public string CMND
        {
            get { return _cMND; }
            set { _cMND = value; }
        }

        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private int _maLoaiKhachHang;

        public int MaLoaiKhachHang
        {
            get { return _maLoaiKhachHang; }
            set { _maLoaiKhachHang = value; }
        }
    }
}
