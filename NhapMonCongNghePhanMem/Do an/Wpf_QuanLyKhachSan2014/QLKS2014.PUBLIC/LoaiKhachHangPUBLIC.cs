using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class LoaiKhachHangPublic
    {
        private int _maLoaiKhachHang;

        public int MaLoaiKhachHang
        {
            get { return _maLoaiKhachHang; }
            set { _maLoaiKhachHang = value; }
        }
        private string _tenLoaiKhachHang;

        public string TenLoaiKhachHang
        {
            get { return _tenLoaiKhachHang; }
            set { _tenLoaiKhachHang = value; }
        }
    }
}
