using DAO;
using QuanLySieuThiDienThoai.DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.BLL
{
    class GioiTinhBll
    {
        private static GioiTinhDao data = new GioiTinhDao();
        public DataTable SelectAllGioiTinh()
        {
            return data.SelectAll();
        }
        public DataTable SelectTenGioiTinh()
        {
            return data.SelectTenGioiTinh();
        }
        public int InsertGioiTinh(GioiTinh info)
        {
            return data.Insert(info);
        }
        public int UpdateGioiTinh(GioiTinh info)
        {
            return data.Update(info);
        }
        public int DeleteGioiTinh(GioiTinh info)
        {
            return data.Delete(info);
        }
    }

}
