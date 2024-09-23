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
    class GiaBll
    {
        private static GiaDao data = new GiaDao();

        public DataTable DanhSachGia()
        {
            return data.DanhSachGia();
        }

        public DataTable ChonTenMatHang()
        {
            return data.ChonTenMatHang();
        }
        public int ThemGia(Gia info)
        {
            // nhao nan, che bien du lieu roi goi ham tu tang DAL de luu tru
            return data.Them(info);
        }
        public int CapNhatGia(Gia info)
        {
            return data.CapNhat(info);
        }
        public int XoaGia(Gia info)
        {
            return data.Xoa(info);
        }
    }

}
