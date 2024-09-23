using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class KhachHang
    {
        private string maKhachHang;

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        private string tenKhachHang;

        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string soDienThoai;

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public KhachHang(string _maKhachHang)
        {
            maKhachHang = _maKhachHang;
        }

        private DateTime ngaySinh;

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string loaiKhachHang;

        public string LoaiKhachHang
        {
            get { return loaiKhachHang; }
            set { loaiKhachHang = value; }
        }
        public KhachHang(string _maKhachHang, string _tenKhachHang, DateTime _ngaySinh,  string _diaChi, string _soDienThoai, string _email, string _loaiKhachHang)
        {
            maKhachHang = _maKhachHang;
            tenKhachHang = _tenKhachHang;
            ngaySinh = _ngaySinh;
            diaChi = _diaChi;
            soDienThoai = _soDienThoai;
            email = _email;
            loaiKhachHang = _loaiKhachHang;
        }
    }
}
