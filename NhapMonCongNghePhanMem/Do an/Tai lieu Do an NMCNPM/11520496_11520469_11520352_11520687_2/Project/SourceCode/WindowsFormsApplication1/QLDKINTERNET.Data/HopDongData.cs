using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class HopDongData
    {
        clsConnect cn;
        public HopDongData()
        {
            cn = new clsConnect();
        }

        public int ThemKhachHang(HopDongPublic kh)
        {
            int param = 8;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@NgayDangKy";
            name[1] = "@HoTen";
            name[2] = "@CMND";
            name[3] = "@NgheNghiep";
            name[4] = "@Email";
            name[5] = "@ChucVu";
            name[6] = "@DiaChi";
            name[7] = "@DienThoai";

            values[0] = kh.NgayDangKy;
            values[1] = kh.HoTen;
            values[2] = kh.CMND;
            values[3] = kh.NgheNghiep;
            values[4] = kh.Email;
            values[5] = kh.ChucVu;
            values[6] = kh.DiaChi;
            values[7] = kh.DienThoai;

            return cn.ExcuteNonQuery("HOPDONG_Insert", name, values, param);
        }

        public int SuaKhachHang(HopDongPublic kh)
        {
            int param = 9;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaHopDong";
            name[1] = "@NgayDangKy";
            name[2] = "@HoTen";
            name[3] = "@CMND";
            name[4] = "@NgheNghiep";
            name[5] = "@Email";
            name[6] = "@ChucVu";
            name[7] = "@DiaChi";
            name[8] = "@DienThoai";

            values[0] = kh.MaHopDong;
            values[1] = kh.NgayDangKy;
            values[2] = kh.HoTen;
            values[3] = kh.CMND;
            values[4] = kh.NgheNghiep;
            values[5] = kh.Email;
            values[6] = kh.ChucVu;
            values[7] = kh.DiaChi;
            values[8] = kh.DienThoai;

            return cn.ExcuteNonQuery("HOPDONG_Update", name, values, param);
        }

        public int XoaKhachHang(HopDongPublic kh)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaHopDong";

            values[0] = kh.MaHopDong;

            return cn.ExcuteNonQuery("HOPDONG_Delete", name, values, param);
        }

        public DataTable TimKiemKhachHang(HopDongPublic kh)
        {
            int param = 7;
            string[] name = new string[param];
            object[] values = new object[param];
           
            name[0] = "@HoTen";
            name[1] = "@CMND";
            name[2] = "@NgheNghiep";
            name[3] = "@Email";
            name[4] = "@ChucVu";
            name[5] = "@DiaChi";
            name[6] = "@DienThoai";

            values[0] = kh.HoTen;
            values[1] = kh.CMND;
            values[2] = kh.NgheNghiep;
            values[3] = kh.Email;
            values[4] = kh.ChucVu;
            values[5] = kh.DiaChi;
            values[6] = kh.DienThoai;

            return cn.getData("HOPDONG_Select", name, values, param);
        }

        public DataTable HopDong_SelectAll()
        {
            return cn.getData("HOPDONG_SelectAll");
        }
    }
}
