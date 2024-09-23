using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyKhachSanDAL;

namespace QuanLyKhachSanBUS
{
    public class BUS_Phong
    {
        public static DataTable LoadDuLieuPhong()
        {
            //goi xuong DAL_Phong xử lý
            return DAL_Phong.LoadDuLieuPhong();
        }
    }
}
