using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace QuanLySieuThiDienThoai.BLL
{
    class PhanQuyenBll
    {
        private static PhanQuyenDao data = new PhanQuyenDao();
        public void insert(PhanQuyen info)
        {
            data.insert(info);
        }
        public void delete(PhanQuyen info)
        {
            data.delete(info);
        }
        public void update(PhanQuyen info)
        {
            data.update(info);
        }
        public static List<PhanQuyen> getdsPhanQuyen()
        {
            return data.getdsPhanQuyen();
        }
    }
}
