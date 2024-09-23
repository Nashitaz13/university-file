using QuanLySieuThiDienThoai.DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.BLL
{
    class DangNhapBll
    {
        private static DangNhapDao data = new DangNhapDao();
        public static TTDangNhap LayThongTinDangNhap(string TenDangNhap, string MatKhau)
        {
            return data.LayThongTinDangNhap(TenDangNhap,MatKhau);
        }
    }
}
