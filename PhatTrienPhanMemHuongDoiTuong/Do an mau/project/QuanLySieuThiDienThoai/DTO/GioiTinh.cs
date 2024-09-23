using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class GioiTinh
    {
        string maGioiTinh;
        string tenGioiTinh;

        public string MaGioiTinh
        {
            get { return maGioiTinh; }
            set { maGioiTinh = value; }
        }

        public string TenGioiTinh
        {
            get { return tenGioiTinh; }
            set { tenGioiTinh = value; }
        }

        public GioiTinh(string MaGioiTinh)
        {
            maGioiTinh = MaGioiTinh;
        }
        public GioiTinh(string MaGioiTinh, string TenGioiTinh)
        {
            maGioiTinh = MaGioiTinh;
            tenGioiTinh = TenGioiTinh;
        }
    }
}
