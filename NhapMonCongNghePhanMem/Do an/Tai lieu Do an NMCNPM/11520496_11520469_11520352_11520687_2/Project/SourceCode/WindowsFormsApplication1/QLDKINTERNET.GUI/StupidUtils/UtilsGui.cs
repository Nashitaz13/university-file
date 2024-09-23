using QLDKINTERNET.BLL;
using QLDKINTERNET.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.GUI.StupidUtils
{
    public class UtilsGui
    {
        public static HopDongPublic dataRowToHopDongPublic(DataRow dataRow)
        {
            HopDongPublic hopDongPublic = new HopDongPublic();
            hopDongPublic.MaHopDong = int.Parse(dataRow["MaHopDong"].ToString());
            String strNgayDangKy = dataRow["NgayDangKy"].ToString();
            IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
            hopDongPublic.NgayDangKy = DateTime.Parse(strNgayDangKy, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            hopDongPublic.HoTen = dataRow["HoTen"].ToString();
            hopDongPublic.CMND = dataRow["CMND"].ToString();
            hopDongPublic.NgheNghiep = dataRow["NgheNghiep"].ToString();
            hopDongPublic.Email = dataRow["Email"].ToString();
            hopDongPublic.ChucVu = dataRow["ChucVu"].ToString();
            hopDongPublic.DiaChi = dataRow["DiaChi"].ToString();
            hopDongPublic.DienThoai = dataRow["DienThoai"].ToString();
            return hopDongPublic;
        }

        public static ModemPublic dataRowToModemPublic(DataRow dataRow)
        {
            ModemPublic modem = new ModemPublic();
            modem.MaModem = dataRow["MaMoDem"].ToString();
            modem.TenModem = dataRow["TenModem"].ToString();
            modem.GiaModem = int.Parse(dataRow["GiaModem"].ToString());
            return modem;
        }

        public static KieuCaiDatPublic dataRowToKieuCaiDatPublic(DataRow dataRow)
        {
            KieuCaiDatPublic kieuCaiDat = new KieuCaiDatPublic();
            kieuCaiDat.MaKieuCaiDat = dataRow["MaKieuCaiDat"].ToString();
            kieuCaiDat.TenKieuCaiDat = dataRow["TenKieuCaiDat"].ToString();
            kieuCaiDat.GiaKieuCaiDat = int.Parse(dataRow["GiaKieuCaiDat"].ToString());
            return kieuCaiDat;
        }

        public static GoiCuocPublic dataRowToGoiCuocPublic(DataRow dataRow)
        {
            GoiCuocPublic goiCuoc = new GoiCuocPublic();
            goiCuoc.MaGoiCuoc = dataRow["MaGoiCuoc"].ToString();
            goiCuoc.TenGoiCuoc = dataRow["TenGoiCuoc"].ToString();
            goiCuoc.GiaTronGoi = int.Parse(dataRow["GiaTronGoi"].ToString());
            return goiCuoc;
        }

        public static List<GoiCuocPublic> getListGoiCuoc()
        {
            
            GoiCuocBLL goiCuocBll = new GoiCuocBLL();
            DataTable dtGoiCuoc = goiCuocBll.GoiCuoc_SelectAll();
            List<GoiCuocPublic> lGoiCuoc = new List<GoiCuocPublic>();
            lGoiCuoc = new List<GoiCuocPublic>(
               (from dRow in dtGoiCuoc.AsEnumerable()
                select (UtilsGui.dataRowToGoiCuocPublic(dRow)))
               );

            return lGoiCuoc;
        }

        public static List<KieuCaiDatPublic> getListKieuCaiDat()
        {

            KieuCaiDatBLL kieuCaiDatBll = new KieuCaiDatBLL();
            DataTable dtKieuCaiDat = kieuCaiDatBll.SelectKieuCaiDat();
            List<KieuCaiDatPublic> lKieuCaiDat = new List<KieuCaiDatPublic>();
            lKieuCaiDat = new List<KieuCaiDatPublic>(
               (from dRow in dtKieuCaiDat.AsEnumerable()
                select (UtilsGui.dataRowToKieuCaiDatPublic(dRow)))
               );

            return lKieuCaiDat;
        }


        public static List<ModemPublic> getListModem()
        {

            ModemBLL modemBll = new ModemBLL();
            DataTable dtModem = modemBll.Modem_SelectAll();
            List<ModemPublic> lModem = new List<ModemPublic>();
            lModem = new List<ModemPublic>(
               (from dRow in dtModem.AsEnumerable()
                select (UtilsGui.dataRowToModemPublic(dRow)))
               );

            return lModem;
        }

    }
}
