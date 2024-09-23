using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class PhieuXuat
    {
        private string maPhieuXuat;
        private string maKhachHang;
        private string maNhanVien;
        private DateTime ngayHoaDon;

        public string MaPhieuXuat
        {
            get { return maPhieuXuat; }
            set { maPhieuXuat = value; }
        }

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public DateTime NgayHoaDon
        {
            get { return ngayHoaDon; }
            set { ngayHoaDon = value; }
        }

    }
}
