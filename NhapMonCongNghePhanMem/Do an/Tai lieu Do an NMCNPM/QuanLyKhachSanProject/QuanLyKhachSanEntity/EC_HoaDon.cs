using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_HoaDon
    {
        private string _maHD;

        public string MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
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
