using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class TTDangNhap
    {
        private string maNhanVien;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string tenNhanVien;

        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }
        private string phongBan;

        public string PhongBan
        {
            get { return phongBan; }
            set { phongBan = value; }
        }
    }
}
