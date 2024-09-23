using System;

namespace DTO
{
    public class PhanQuyenInfo
    {
        private string _Quyen;
        private string _MaNhanVien;
        private string _TenDangNhap;
        private string _MatKhau;

        public string Quyen
        {
            get { return _Quyen; }
            set { _Quyen = value; }
        }

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }

        public string TenDangNhap
        {
            get { return _TenDangNhap; }
            set { _TenDangNhap = value; }
        }

        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
    }
}
