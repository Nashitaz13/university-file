using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class LoaiKhachHang
    {
        private string maLoaiKhachHang;

        public string MaLoaiKhachHang
        {
            get { return maLoaiKhachHang; }
            set { maLoaiKhachHang = value; }
        }

        private string tenLoaiKhachHang;

        public string TenLoaiKhachHang
        {
            get { return tenLoaiKhachHang; }
            set { tenLoaiKhachHang = value; }
        }

        private double heSoGiamGia;

        public double HeSoGiamGia
        {
            get { return heSoGiamGia; }
            set { heSoGiamGia = value; }
        }

        public LoaiKhachHang(string _maLoaiKhachHang)
        {
            maLoaiKhachHang = _maLoaiKhachHang;
        }

        public LoaiKhachHang(string _maLoaiKhachHang, string _tenLoaiKhachHang, double _heSoGiamGia)
        {
            maLoaiKhachHang = _maLoaiKhachHang;
            tenLoaiKhachHang = _tenLoaiKhachHang;
            heSoGiamGia = _heSoGiamGia;
        }
    }
}
