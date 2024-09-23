using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class CTPhieuXuat
    {
        private string maPhieuXuat;
        private string maMatHang;
        private int soLuong;

        public string MaPhieuXuat
        {
            get { return maPhieuXuat; }
            set { maPhieuXuat = value; }
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
