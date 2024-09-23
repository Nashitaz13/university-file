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
    class MatHangBll
    {
        private static MatHangDao data = new MatHangDao();
        public DataTable DanhSachMatHang()
        {
            return data.DanhSachMatHang();
        }
        public int ThemMatHang(MatHang info)
        {
            return data.Them(info);
        }
        public int CapNhatMatHang(MatHang info)
        {
            return data.CapNhat(info);
        }
        public int XoaMatHang(MatHang info)
        {
            return data.Xoa(info);
        }

        public void CapNhatSoLuongKhiNhap(int soLuong, string maMatHang)
        {
            data.CapNhatSoLuongKhiNhap(soLuong, maMatHang);
        }

        public void CapNhatSoLuongKhiXuat(int soLuong, string maMatHang)
        {
            data.CapNhatSoLuongKhiXuat(soLuong, maMatHang);
        }

        public int LaySoLuongMatHang(string mamh)
        {
            return data.LaySoLuongMatHang(mamh);
        }

        public DataTable LayDanhSachMaMH()
        {
            return data.LayDanhSachMaMH();
        }

        public DataTable TimKiemMatHang(string search)
        {
            return data.TimKiem(search);
        }
    }
}
