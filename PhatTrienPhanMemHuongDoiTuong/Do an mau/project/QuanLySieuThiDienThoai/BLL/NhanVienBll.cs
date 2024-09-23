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
    class NhanVienBll
    {
        private static NhanVienDao data = new NhanVienDao();
        public DataTable SelectAllNhanVien()
        {
            return data.SelectAll();
        }
        public DataTable SearchNhanVien(string search)
        {
            return data.Search(search);
        }
        public int InsertNhanVien(NhanVien info)
        {
            // nhao nan, che bien du lieu roi goi ham tu tang DAL de luu tru
            return data.Insert(info);
        }
        public int UpdateNhanVien(NhanVien info)
        {
            return data.Update(info);
        }
        public int DeleteNhanVien(NhanVien info)
        {
            return data.Delete(info);
        }
    }
}
