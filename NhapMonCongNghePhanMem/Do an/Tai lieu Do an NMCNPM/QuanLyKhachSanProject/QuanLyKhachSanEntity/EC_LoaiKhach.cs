using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_LoaiKhach
    {
        private string _maLoaiKhach;

        public string MaLoaiKhach
        {
            get { return _maLoaiKhach; }
            set { _maLoaiKhach = value; }
        }
        private string _tenLoaiKhach;

        public string TenLoaiKhach
        {
            get { return _tenLoaiKhach; }
            set { _tenLoaiKhach = value; }
        }
    }
}
