using QuanLySieuThiDienThoai.DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.BLL
{
    class LoaiKhachHangBll
    {
        private static LoaiKhachHangDao data = new LoaiKhachHangDao();
        public DataTable DanhSachLoaiKhachHang()
        {
            return data.DanhSachLoaiKhachHang();
        }

        public DataTable ChonTenLoaiKhachHang()
        {

            return data.ChonTenLoaiKhachHang();
        }
        public int ThemLoaiKhachHang(LoaiKhachHang info)
        {
       
            return data.Them(info);
        }
        public int CapNhatLoaiKhachHang(LoaiKhachHang info)
        {
            return data.CapNhat(info);
        }
        public int XoaLoaiKhachHang(LoaiKhachHang info)
        {
            return data.Xoa(info);
        }

        public DataTable TimKiemLoaiKhachHang(string search)
        {
            return data.TimKiem(search);
        }
    }

}
