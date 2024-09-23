using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class PhongPublic
    {
        private int _maPhong;

        public int MaPhong
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
        private int _maLoaiPhong;

        public int MaLoaiPhong
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
