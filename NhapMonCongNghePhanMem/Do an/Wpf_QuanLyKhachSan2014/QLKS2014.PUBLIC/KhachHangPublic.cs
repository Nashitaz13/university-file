using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class KhachHangPublic
    {
        private int _maKhachHang;

        public int MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
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
        private int _maLoaiKhach;

        public int MaLoaiKhach
        {
            get { return _maLoaiKhach; }
            set { _maLoaiKhach = value; }
        }
        private int _maPhieuThue;

        public int MaPhieuThue
        {
            get { return _maPhieuThue; }
            set { _maPhieuThue = value; }
        }
        private int _maPhong;

        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
    }
}
