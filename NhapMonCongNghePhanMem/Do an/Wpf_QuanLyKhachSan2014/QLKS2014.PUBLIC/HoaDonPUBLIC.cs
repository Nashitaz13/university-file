using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class HoaDonPublic
    {
        private int _maHoaDon;

        public int MaHoaDon
        {
            get { return _maHoaDon; }
            set { _maHoaDon = value; }
        }
        private string _tenKhachHang;

        public string TenKhachHang
        {
            get { return _tenKhachHang; }
            set { _tenKhachHang = value; }
        }
        private DateTime _ngayLap;

        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }
        private decimal _triGia;

        public decimal TriGia
        {
            get { return _triGia; }
            set { _triGia = value; }
        }
    }
}
