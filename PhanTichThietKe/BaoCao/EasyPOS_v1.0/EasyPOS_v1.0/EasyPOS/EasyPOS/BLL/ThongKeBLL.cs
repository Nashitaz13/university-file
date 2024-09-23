using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;
using System.Data;

namespace EasyPOS.BLL
{
    class ThongKeBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();
        //public DataTable ThongKeTheoNgay(DateTime d1, DateTime d2)
        //{
        //    var query = from a in dbContext.PHIEUXUATs
        //                where a.NgayLap >= d1 && a.NgayLap <= d2 
        //                //&& a.Trang_Thai_Thanh_Toan == 0
        //                group a by a.NgayLap into b
        //                select new
        //                {
        //                    Ngay_Lap = b.Key,
        //                    So_Luong_HD = b.Count(),
        //                    Tong_Thanh_Toan = b.Sum(s => s.TongThanhTien)
        //                };

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("STT", typeof(int));
        //    dt.Columns.Add("Ngay_Lap", typeof(string));
        //    dt.Columns.Add("So_Luong_HD", typeof(int));
        //    dt.Columns.Add("Tong_Thanh_Toan", typeof(int));
        //    int dem = 0;
        //    foreach (var i in query)
        //    {
        //        dem++;
        //        DataRow dr = dt.NewRow();
        //        dr["STT"] = dem;
        //        dr["Ngay_Lap"] = ((DateTime)i.Ngay_Lap).ToShortDateString();
        //        dr["So_Luong_HD"] = i.So_Luong_HD;
        //        dr["Tong_Thanh_Toan"] = i.Tong_Thanh_Toan;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
        //public DataTable ThongKeTheoThang(DateTime d1, DateTime d2)
        //{
        //    var query = from a in dbContext.PHIEUXUATs
        //                where ((((DateTime)a.NgayLap).Month >= d1.Month && ((DateTime)a.NgayLap).Year == d1.Year) || ((DateTime)a.NgayLap).Year > d1.Year)
        //                        && ((((DateTime)a.NgayLap).Month <= d2.Month && ((DateTime)a.NgayLap).Year == d2.Year) || ((DateTime)a.NgayLap).Year < d2.Year)
        //                      //  && a.Trang_Thai_Thanh_Toan == 0
        //                group a by new { ((DateTime)a.NgayLap).Month, ((DateTime)a.NgayLap).Year } into b
        //                select new
        //                {
        //                    Ngay_Lap = b.Key.Month + "/" + b.Key.Year,
        //                    So_Luong_HD = b.Count(),
        //                    Tong_Thanh_Toan = b.Sum(s => s.TongThanhTien)
        //                };

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("STT", typeof(int));
        //    dt.Columns.Add("Thang", typeof(string));
        //    dt.Columns.Add("So_Luong_HD", typeof(int));
        //    dt.Columns.Add("Tong_Thanh_Toan", typeof(int));
        //    int dem = 0;
        //    foreach (var i in query)
        //    {
        //        dem++;
        //        DataRow dr = dt.NewRow();
        //        dr["STT"] = dem;
        //        dr["Thang"] = i.Ngay_Lap;
        //        dr["So_Luong_HD"] = i.So_Luong_HD;
        //        dr["Tong_Thanh_Toan"] = i.Tong_Thanh_Toan;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
        //        public DataTable ThongKeTheoMatHang(DateTime d1, DateTime d2)
        //        {
        //            MonBLL _monBLL = new MonBLL();
        //            var query = from a in dbContext.CHI_TIET_HOA_DONs
        //                        join c in dbContext.HOA_DONs
        //on a.ID_Hoa_Don equals c.ID_Hoa_Don
        //                        where c.Ngay_Lap >= d1 && c.Ngay_Lap <= d2
        //                        group a by a.ID_Mon into b
        //                        select new
        //                        {
        //                            ID_Mon = b.Key,
        //                            So_Luong = b.Sum(s => s.So_Luong),
        //                        };

        //            DataTable dt = new DataTable();
        //            dt.Columns.Add("STT", typeof(int));
        //            dt.Columns.Add("Ten_Mon", typeof(string));
        //            dt.Columns.Add("So_Luong", typeof(int));
        //            dt.Columns.Add("Tong_Thanh_Toan", typeof(int));
        //            int dem = 0;
        //            foreach (var i in query)
        //            {
        //                dem++;
        //                DataRow dr = dt.NewRow();
        //                dr["STT"] = dem;
        //                dr["Ten_Mon"] = _monBLL.LayTenMon(i.ID_Mon);
        //                dr["So_Luong"] = i.So_Luong;
        //                dr["Tong_Thanh_Toan"] = i.So_Luong * _monBLL.LayDonGia(i.ID_Mon);
        //                dt.Rows.Add(dr);
        //            }
        //            return dt;
        //        }
        //        public DataTable ThongKeTheoTonKho()
        //        {
        //            var query = from a in dbContext.NGUYEN_LIEUs
        //                        from b in dbContext.CHI_TIET_PHIEU_NHAPs
        //                        from c in dbContext.DON_VIs
        //                        from d in dbContext.PHIEU_NHAPs
        //                        where a.ID_Nguyen_Lieu == b.ID_Nguyen_Lieu && a.ID_Don_Vi == c.ID_Don_Vi && b.ID_Phieu_Nhap == d.ID_Phieu_Nhap
        //                        && d.Ngay_Lap == (from f in dbContext.PHIEU_NHAPs select f.Ngay_Lap).Max()
        //                        select new
        //                        {
        //                            Ten_Nguyen_Lieu = a.Ten_Nguyen_Lieu,
        //                            Don_Vi = c.Ten_Don_Vi,
        //                            So_Luong_Nhap = b.So_Luong,
        //                            So_Luong_Ton = a.So_Luong_Ton,
        //                        };

        //            DataTable dt = new DataTable();
        //            dt.Columns.Add("STT", typeof(int));
        //            dt.Columns.Add("Ten_Nguyen_Lieu", typeof(string));
        //            dt.Columns.Add("Don_Vi", typeof(string));
        //            dt.Columns.Add("So_Luong_Nhap", typeof(int));
        //            dt.Columns.Add("So_Luong_Ton", typeof(int));
        //            int dem = 0;
        //            foreach (var i in query)
        //            {
        //                dem++;
        //                DataRow dr = dt.NewRow();
        //                dr["STT"] = dem;
        //                dr["Ten_Nguyen_Lieu"] = i.Ten_Nguyen_Lieu;
        //                dr["Don_Vi"] = i.Don_Vi;
        //                dr["So_Luong_Nhap"] = i.So_Luong_Nhap;
        //                dr["So_Luong_Ton"] = i.So_Luong_Ton;
        //                dt.Rows.Add(dr);
        //            }
        //            return dt;
        //        }
    }
}
