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
    class NhaCungCapBll
    {
        private static NhaCungCapDao data = new NhaCungCapDao();
        public DataTable DanhSachNhaCungCap()
        {
            return data.DanhSachNhaCungCap();
        }

        public DataTable ChonTenNhaCungCap()
        {

            return data.ChonTenNhaCungCap();
        }
        public int ThemNhaCungCap(NhaCungCap info)
        {
            // nhao nan, che bien du lieu roi goi ham tu tang DAL de luu tru
            return data.Them(info);
        }
        public int CapNhatNhaCungCap(NhaCungCap info)
        {
            return data.CapNhat(info);
        }
        public int XoaNhaCungCap(NhaCungCap info)
        {
            return data.Xoa(info);
        }

        public DataTable LayDanhSachNCC()
        {
            return data.LayDanhSachNCC();
        }

        public DataTable TimKiemNhaCungCap(string search)
        {
            return data.TimKiem(search);
        }
    }

}
