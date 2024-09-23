using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PhanQuyenControl
    {
        private static PhanQuyenDataAccess data = new PhanQuyenDataAccess();
        public void insert(PhanQuyenInfo info)
        {
            data.insert(info);
        }
        public void delete(PhanQuyenInfo info)
        {
            data.delete(info);
        }
        public void update(PhanQuyenInfo info)
        {
            data.update(info);
        }
        public static List<PhanQuyenInfo> getdsPhanQuyen()
        {
            return data.getdsPhanQuyen();
        }
    }
}
