using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_PhieuThuePhong
    {
        private string _maPhieuThue;

        public string MaPhieuThue
        {
            get { return _maPhieuThue; }
            set { _maPhieuThue = value; }
        }
        private DateTime _ngayThue;

        public DateTime NgayThue
        {
            get { return _ngayThue; }
            set { _ngayThue = value; }
        }
        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private string _maPhong;

        public string MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
    }
}
