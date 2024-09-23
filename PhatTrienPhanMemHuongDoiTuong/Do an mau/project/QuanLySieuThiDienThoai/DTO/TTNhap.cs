using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class TTNhap
    {
        private string maPhieuNhap;

        public string MaPhieuNhap
        {
            get { return maPhieuNhap; }
            set { maPhieuNhap = value; }
        }
        private string tenNhanVien;

        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }
        private string ngayHoaDon;

        public string NgayHoaDon
        {
            get { return ngayHoaDon; }
            set { ngayHoaDon = value; }
        }
    }
}
