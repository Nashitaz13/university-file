using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_ChiTietHoaDon
    {
        private string _maChiTietHD;

        public string MaChiTietHD
        {
            get { return _maChiTietHD; }
            set { _maChiTietHD = value; }
        }
        private string _maHoaDon;

        public string MaHoaDon
        {
            get { return _maHoaDon; }
            set { _maHoaDon = value; }
        }
        private int _soNgayThue;

        public int SoNgayThue
        {
            get { return _soNgayThue; }
            set { _soNgayThue = value; }
        }
        private string _maPhieuThue;

        public string MaPhieuThue
        {
            get { return _maPhieuThue; }
            set { _maPhieuThue = value; }
        }
    }
}
