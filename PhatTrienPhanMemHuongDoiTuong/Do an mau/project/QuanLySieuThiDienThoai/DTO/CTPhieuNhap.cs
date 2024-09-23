using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class CTPhieuNhap
    {
        private string maPhieuNhap;
        private string maMatHang;
        private int soLuong;
        private string maNCC;

        public string MaNCC
        {
            get { return maNCC; }
            set { maNCC = value; }
        }


        public string MaPhieuNhap
        {
            get { return maPhieuNhap; }
            set { maPhieuNhap = value; }
        }

        public string MaMatHang
        {
            get { return maMatHang; }
            set { maMatHang = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

    }
}
