using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_Phong
    {
        private string _maPhong;

        public string MaPhong
        {
            get { return _maPhong; }
            set { _maPhong = value; }
        }
        private string _tenPhong;

        public string TenPhong
        {
            get { return _tenPhong; }
            set { _tenPhong = value; }
        }
        private string _maLoaiPhong;

        public string MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        private string _tinhTrang;

        public string TinhTrang
        {
            get { return _tinhTrang; }
            set { _tinhTrang = value; }
        }
    }
}
