using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class NguoiDungPublic
    {
        private int _maNguoiDung;

        public int MaNguoiDung
        {
            get { return _maNguoiDung; }
            set { _maNguoiDung = value; }
        }
        private string _tenNguoiDung;

        public string TenNguoiDung
        {
            get { return _tenNguoiDung; }
            set { _tenNguoiDung = value; }
        }
        private string _matKhau;

        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
        private string _loaiNguoiDung;

        public string LoaiNguoiDung
        {
            get { return _loaiNguoiDung; }
            set { _loaiNguoiDung = value; }
        }
    }
}
