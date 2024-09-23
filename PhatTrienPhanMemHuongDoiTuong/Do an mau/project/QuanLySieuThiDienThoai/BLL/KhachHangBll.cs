using QuanLySieuThiDienThoai.DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLySieuThiDienThoai.BLL
{
    class KhachHangBll
    {
        private static KhachHangDao data = new KhachHangDao();
        public DataTable DanhSachKhachHang()
        {
            return data.DanhSachKhachHang();
        }
        public int ThemKhachHang(KhachHang info)
        {
            return data.Them(info);
        }
        public int CapNhatKhachHang(KhachHang info)
        {
            return data.CapNhat(info);
        }
        public int XoaKhachHang(KhachHang info)
        {
            return data.Xoa(info);
        }

        public DataTable LayDanhSachMaKH()
        {
            return data.LayDanhSachMaKH();
        }

        public DataTable TimKiemKhachHang(string search)
        {
            return data.TimKiem(search);
        }
    }
}
