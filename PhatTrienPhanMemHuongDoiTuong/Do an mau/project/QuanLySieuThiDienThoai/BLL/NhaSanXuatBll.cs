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
    class NhaSanXuatBll
    {
        private static NhaSanXuatDao data = new NhaSanXuatDao();
        public DataTable DanhSachNhaSanXuat()
        {
            return data.DanhSachNhaSanXuat();
        }

        public DataTable ChonTenNhaSanXuat()
        {

            return data.ChonTenNhaSanXuat();
        }
        public int ThemNhaSanXuat(NhaSanXuat info)
        {
            // nhao nan, che bien du lieu roi goi ham tu tang DAL de luu tru
            return data.Them(info);
        }
        public int CapNhatNhaSanXuat(NhaSanXuat info)
        {
            return data.CapNhat(info);
        }
        public int XoaNhaSanXuat(NhaSanXuat info)
        {
            return data.Xoa(info);
        }
        public DataTable TimKiemNhaSanXuat(string search)
        {
            return data.TimKiem(search);
        }
    }

}
