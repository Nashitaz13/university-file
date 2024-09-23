using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class PhieuThuePhongPublic
    {
        private int _maPhieuThue;

        public int MaPhieuThue
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
        private int _maPhong;

        public int MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
    }
}
