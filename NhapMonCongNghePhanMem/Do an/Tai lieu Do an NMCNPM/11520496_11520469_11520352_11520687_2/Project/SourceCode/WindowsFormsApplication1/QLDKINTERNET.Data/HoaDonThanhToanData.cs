using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class HoaDonThanhToanData
    {
         clsConnect cn;

        public HoaDonThanhToanData()
        {
            cn = new clsConnect();           
        }

        //Tinh Hoa Don Thanh Toan
        public int HoaDonThanhToan_Insert(HoaDonThanhToanPublic hd)
        {
            int param = 3;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaDV";
            name[1] = "@CuocTuNgay";
            name[2] = "@CuocDenNgay";

            value[0] = hd.MaDV;
            value[1] = hd.CuocTuNgay;
            value[2] = hd.CuocDenNgay;

            return cn.ExcuteNonQuery("HOADONTHANHTOAN_Insert", name, value, param);
        }
        
        //Cap Nhat Tinh Trang Thanh Toan
        public int HoaDonThanhToan_Update_TinhTrangThanhToan(HoaDonThanhToanPublic hd)
        {
            int param = 2;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaHDTT";
            name[1] = "@TinhTrangThanhToan";            

            value[0] = hd.MaHDTT;
            value[1] = hd.TinhTrangThanhToan;            

            return cn.ExcuteNonQuery("HOADONTHANHTOAN_Update_TinhTrangThanhToan", name, value, param);
        }

        //Select Hoa Don Thanh Toan
        public DataTable HoaDonThanhToan_Select(HoaDonThanhToanPublic hd)
        {
            int param = 1;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaDV";

            value[0] = hd.MaDV;

            return cn.getData("HOADONTHANHTOAN_Select", name, value, param);
        }

        //Select Hoa Don Thanh Toan Tre
        public DataTable HoaDonThanhToan_HoaDonChuaThanhToan()
        {
            return cn.getData("HOADONTHANHTOAN_Select_DichVuThanhToanTre");
        }

        //Select Hoa Don qua han thanh toan
        public DataTable HoaDonThanhToan_HoaDonQuaHan()
        {
            return cn.getData("HOADONTHANHTOAN_DichVuQuaHanThanhToan");
        }
    }
}
