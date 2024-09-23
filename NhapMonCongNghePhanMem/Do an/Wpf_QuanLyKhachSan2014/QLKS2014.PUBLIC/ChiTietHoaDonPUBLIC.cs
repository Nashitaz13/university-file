using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class ChiTietHoaDonPublic
    {
        private int _maChiTietHoaDon;

        public int MaChiTietHoaDon
        {
            get { return _maChiTietHoaDon; }
            set { _maChiTietHoaDon = value; }
        }
        private int _maHoaDon;

        public int MaHoaDon
        {
            get { return _maHoaDon; }
            set { _maHoaDon = value; }
        }
        private int _maPhieuThue;

        public int MaPhieuThue
        {
            get { return _maPhieuThue; }
            set { _maPhieuThue = value; }
        }
        private int _soNgayThue;

        public int SoNgayThue
        {
            get { return _soNgayThue; }
            set { _soNgayThue = value; }
        }
    }
}
