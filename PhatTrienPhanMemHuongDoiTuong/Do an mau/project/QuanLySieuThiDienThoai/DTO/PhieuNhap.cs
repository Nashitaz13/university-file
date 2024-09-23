using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class PhieuNhap
    {
        private string maPhieuNhap;
        private string maNhanVien;
        private DateTime ngayHoaDon;


        public string MaPhieuNhap
        {
            get { return maPhieuNhap; }
            set { maPhieuNhap = value; }
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