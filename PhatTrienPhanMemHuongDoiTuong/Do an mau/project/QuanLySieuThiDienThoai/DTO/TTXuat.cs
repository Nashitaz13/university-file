using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class TTXuat
    {
        private string maPhieuXuat;
        private string maNhanVien;
        private string ngayHoaDon;
        private string tenKhachHang;
        private string diaChi;
        private string soDienThoai;

        public string MaPhieuXuat
        {
            get { return maPhieuXuat; }
            set { maPhieuXuat = value; }
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public string NgayHoaDon
        {
            get { return ngayHoaDon; }
            set { ngayHoaDon = value; }
        }

        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

    }
}
