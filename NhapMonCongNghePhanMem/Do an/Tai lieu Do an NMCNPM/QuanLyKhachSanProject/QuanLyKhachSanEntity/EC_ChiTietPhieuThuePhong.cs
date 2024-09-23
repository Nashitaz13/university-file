using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_ChiTietPhieuThuePhong
    {
        private string _maChiTietPTP;

        public string MaChiTietPTP
        {
            get { return _maChiTietPTP; }
            set { _maChiTietPTP = value; }
        }
        private string _maPhieuThue;

        public string MaPhieuThue
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
        private string _cnnd;

        public string Cnnd
        {
            get { return _cnnd; }
            set { _cnnd = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _maLoaiKhach;

        public string MaLoaiKhach
        {
            get { return _maLoaiKhach; }
            set { _maLoaiKhach = value; }
        }
    }
}
