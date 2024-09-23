using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class LoaiPhongPublic
    {
        private int _maLoaiPhong;

        public int MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        private string _tenLoaiPhong;

        public string TenLoaiPhong
        {
            get { return _tenLoaiPhong; }
            set { _tenLoaiPhong = value; }
        }
        private float _donGia;

        public float DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
        private int _soKhachToiDa;

        public int SoKhachToiDa
        {
            get { return _soKhachToiDa; }
            set { _soKhachToiDa = value; }
        }
    }
}
