using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class PhongBan
    {
        string maPhong;
        string tenPhong;

        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }

        public string TenPhong
        {
            get { return tenPhong; }
            set { tenPhong = value; }
        }

        public PhongBan(string MaPhong)
        {
            maPhong = MaPhong;
        }

        public PhongBan(string MaPhong, string TenPhong)
        {
            maPhong = MaPhong;
            tenPhong = TenPhong;
        }
    }
}
