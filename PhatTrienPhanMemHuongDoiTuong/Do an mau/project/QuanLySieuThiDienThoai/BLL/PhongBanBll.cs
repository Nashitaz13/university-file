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
    class PhongBanBll
    {
        private static PhongBanDao data = new PhongBanDao();
        public DataTable SelectAllPhongBan()
        {
            return data.SelectAll();
        }
        public DataTable SearchPhongBan(string search)
        {
            return data.Search(search);
        }
        public DataTable SelectTenPhongBan()
        {
            return data.SelectTenPhongBan();
        }
        public int InsertPhongBan(PhongBan info)
        {
            return data.Insert(info);
        }
        public int UpdatePhongBan(PhongBan info)
        {
            return data.Update(info);
        }
        public int DeletePhongBan(PhongBan info)
        {
            return data.Delete(info);
        }
    }
}
