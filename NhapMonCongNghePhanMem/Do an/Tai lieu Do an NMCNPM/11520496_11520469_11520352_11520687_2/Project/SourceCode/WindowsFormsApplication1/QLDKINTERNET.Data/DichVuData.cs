using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class DichVuData
    {
        clsConnect cn;

        public DichVuData()
        {
            cn = new clsConnect();           
        }

        //Dang Ky Dich Vu
        public int DangKyDichVu(DichVuPublic dv)
        {
            int param = 13;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";
            name[1] = "@MaGoiCuoc";
            name[2] = "@MaHopDong";
            name[3] = "@DiaChiCaiDat";
            name[4] = "@DiaChiHoaDon";
            name[5] = "@TenDichVu";
            name[6] = "@TinhTrangDichVu";
            name[7] = "@SoLuongTaiKhoan";
            name[8] = "@NgayLapDat";
            name[9] = "@TinhTrangThanhToan";
            name[10] = "@NgayDangKy";
            name[11] = "@MaModem";
            name[12] = "@MaKieuCaiDat";

            values[0] = dv.MaDV;
            values[1] = dv.MaGoiCuoc;
            values[2] = dv.MaHopDong;
            values[3] = dv.DiaChiCaiDat;
            values[4] = dv.DiaChiHoaDon;
            values[5] = dv.TenDichVu;
            values[6] = dv.TinhTrangDichVu;
            values[7] = dv.SoLuongTaiKhoan;
            values[8] = dv.NgayLapDat;
            values[9] = dv.TinhTrangThanhToan;
            values[10] = dv.NgayDangKy;
            values[11] = dv.MaModem;
            values[12] = dv.MaKieuCaiDat;

            return cn.ExcuteNonQuery("DICHVU_Insert", name, values, param);
        }

        //Huy Dich Vu
        public int HuyDichVu(DichVuPublic dv)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";

            values[0] = dv.MaDV;

            return cn.ExcuteNonQuery("DICHVU_Delete", name, values, param);
        }

        //Tim Kiem Dich Vu
        public DataTable TimKiemDichVu(DichVuPublic dv)
        {
            int param = 6;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";
            name[1] = "@MaGoiCuoc";
            name[2] = "@MaHopDong";
            name[3] = "@DiaChiCaiDat";
            name[4] = "@DiaChiHoaDon";
            name[5] = "@TenDichVu";

            values[0] = dv.MaDV;
            values[1] = dv.MaGoiCuoc;
            values[2] = dv.MaHopDong;
            values[3] = dv.DiaChiCaiDat;
            values[4] = dv.DiaChiHoaDon;
            values[5] = dv.TenDichVu;

            return cn.getData("DICHVU_Select", name, values, param);
        }

        // Cap Nhat Dich Vu
        public int CapNhatDichVu(DichVuPublic dv)
        {
            int param = 3;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";
            name[1] = "@DiaChiHoaDon";
            name[2] = "@SoLuongTaiKhoan";

            values[0] = dv.MaDV;
            values[1] = dv.DiaChiHoaDon;
            values[2] = dv.SoLuongTaiKhoan;

            return cn.ExcuteNonQuery("DICHVU_Update", name, values, param);
        }

        //Tim Dich Vu Theo Tinh Trang Thanh Toan
        public DataTable DichVu_Select_TheoTinhTrangThanhToan(DichVuPublic dv)
        {
            int param = 2;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaHopDong";
            name[1] = "@TinhTrangThanhToan";

            values[0] = dv.MaHopDong;
            values[1] = dv.TinhTrangThanhToan;

            return cn.getData("DICHVU_Select_TheoTinhTrangThanhToan", name, values, param);
        }

        //Update TinhTrangThanhToan
        public int DichVu_Update_TinhTrangThanhToan(DichVuPublic dv)
        {
            int param = 2;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";
            name[1] = "@TinhTrangThanhToan";

            values[0] = dv.MaDV;
            values[1] = dv.TinhTrangThanhToan;

            return cn.ExcuteNonQuery("DICHVU_Update_TinhTrangThanhToan", name, values, param);
        }

        //Select DICHVU_Select_TinhTrangDichVu_ThanhToan
        public DataTable DICHVU_Select_TinhTrangDichVu_ThanhToan()
        {
            return cn.getData("DICHVU_Select_TinhTrangDichVu_ThanhToan");                
        }

        //Select DICHVU_Select_TinhTrangDichVu
        public DataTable DICHVU_Select_TinhTrangDichVu()
        {
            return cn.getData("DICHVU_Select_TinhTrangDichVu");
        }

        //Update Tinh Trang Dich Vu
        public int DichVu_Update_TinhTrangDichVu(DichVuPublic dv)
        {
            int param = 2;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";
            name[1] = "@TinhTrangDichVu";

            values[0] = dv.MaDV;
            values[1] = dv.TinhTrangDichVu;

            return cn.ExcuteNonQuery("DICHVU_Update_TinhTrangDichVu", name, values, param);
        }

        //Select DichVu Theo MaDV
        public DataTable DichVu_Select_MaDV(DichVuPublic dv)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";           

            values[0] = dv.MaDV;        

            return cn.getData("DICHVU_Select_MaDV", name, values, param);
        }

        //Cat mang dich vu chua tra tien
        public int DichVu_CatMangDichVuChuaThanhToan()
        {
            return cn.ExcuteNonQuery("DICHVU_CatMangChoDichVuChuaNopTien");
        }
    }
}
