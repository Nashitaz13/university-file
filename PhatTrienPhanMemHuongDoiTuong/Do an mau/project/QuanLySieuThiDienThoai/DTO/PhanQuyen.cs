using System;

namespace DTO
{
    public class PhanQuyen
    {
        private string quyen;
        private string maNhanVien;
        private string tenDangNhap;
        private string matKhau;

        public string Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
    }
}
