using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;
using QLDKINTERNET.Data;

namespace QLDKINTERNET.BLL
{
    public class HopDongBLL
    {
        HopDongData cls = new HopDongData();

        //Tiep Nhan Khach Hang
        public int TiepNhanKhachHang(HopDongPublic hd)
        {
            return cls.ThemKhachHang(hd);
        }

        //Sua Thong Tin Khach Hang
        public int SuaThongTinKhachHang(HopDongPublic hd)
        {
            return cls.SuaKhachHang(hd);
        }

        //Xoa Khach Hang
        public int XoaKhachHang(HopDongPublic hd)
        {
            return cls.XoaKhachHang(hd);
        }

        //Tim Kiem Khach Hang
        public DataTable TimKiemKhachHang(HopDongPublic hd)
        {
            return cls.TimKiemKhachHang(hd);
        }

        // Xuat het danh sach khach hang
        public DataTable HopDong_SelectAll()
        {
            return cls.HopDong_SelectAll();
        }
    }
}
