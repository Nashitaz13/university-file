using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class NhanVien
    {
        string maNhanVien;
        string tenNhanVien;
        DateTime ngaySinh;
        string gioiTinh;
        string _CMND;
        string diaChi;
        string _SDT;
        byte[] hinh;
        string phongBan;
        string tenDangNhap;
        string matKhau;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }
        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        public string CMND
        {
            get { return _CMND; }
            set { _CMND = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

        public byte[] Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        public string PhongBan
        {
            get { return phongBan; }
            set { phongBan = value; }
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

        public NhanVien(string MaNhanVien)
        {
            maNhanVien = MaNhanVien;
        }

        public NhanVien(string MaNhanVien, string TenNhanVien, DateTime NgaySinh, string GioiTinh, string CMND, string DiaChi, string SDT, byte[] Hinh, string PhongBan, string TenDangNhap, string MatKhau)
        {
            maNhanVien = MaNhanVien;
            tenNhanVien = TenNhanVien;
            ngaySinh = NgaySinh;
            gioiTinh = GioiTinh;
            _CMND = CMND;
            diaChi = DiaChi;
            _SDT = SDT;
            hinh = Hinh;
            phongBan = PhongBan;
            tenDangNhap = TenDangNhap;
            matKhau = MatKhau;
        }
    }
}
