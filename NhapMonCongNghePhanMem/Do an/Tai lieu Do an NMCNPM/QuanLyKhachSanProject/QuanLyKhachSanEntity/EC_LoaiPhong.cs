using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_LoaiPhong
    {
        private string _maLoaiPhong;

        public string MaLoaiPhong
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
        private decimal _donGia;

        public decimal DonGia
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
