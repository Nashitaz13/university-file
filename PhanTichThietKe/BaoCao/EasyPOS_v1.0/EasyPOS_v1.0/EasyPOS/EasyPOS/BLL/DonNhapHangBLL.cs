using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class DonNhapHangBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();
        ThamSoBLL t = new ThamSoBLL();
        public IEnumerable<DONDATHANGNCC> LayDanhSachDonNhapHang()
        {

            IEnumerable<DONDATHANGNCC> query = from dv in dbContext.DONDATHANGNCC select dv;
            return query;
        }

        public void ThemDonNhapHangMoi(DONDATHANGNCC d)
        {
            dbContext.DONDATHANGNCC.InsertOnSubmit(d);
            dbContext.SubmitChanges();

            CTDONDATHANGNCC ct = new CTDONDATHANGNCC();
            ct.MaDonDatHangNCC = dbContext.DONDATHANGNCC.ToList().Last().MaDonDatHangNCC;
            dbContext.CTDONDATHANGNCC.InsertOnSubmit(ct);
            dbContext.SubmitChanges();

        }
        public void ThemCTDonNhapHangMoi(DONDATHANGNCC d)
        {
            dbContext.DONDATHANGNCC.InsertOnSubmit(d);
            dbContext.SubmitChanges();

        }
        public void ThemCTDonNhapHangMoi(CTDONDATHANGNCC ct)
        {
            dbContext.CTDONDATHANGNCC.InsertOnSubmit(ct);
            dbContext.SubmitChanges();

        }
        public DONDATHANGNCC LayDonNhapHang(string id)
        {
            return dbContext.DONDATHANGNCC.Single<DONDATHANGNCC>(x => x.MaDonDatHangNCC ==  id);
        }
        public IEnumerable<CTDONDATHANGNCC> LayCTDonNhapHang(string id)
        {
            IEnumerable<CTDONDATHANGNCC> query = from dv in dbContext.CTDONDATHANGNCC where dv.MaDonDatHangNCC==id select dv;
            return query;
        }
        public void CapNhatDonNhapHang(DONDATHANGNCC d)
        {
            DONDATHANGNCC _d = dbContext.DONDATHANGNCC.Single<DONDATHANGNCC>(x => x.MaDonDatHangNCC == d.MaDonDatHangNCC);
            _d.MaNCC = d.MaNCC;
            _d.MaNhanVien = d.MaNhanVien;
            _d.NgayLap = d.NgayLap;
            // update 
            dbContext.SubmitChanges();
        }
        public void CapNhatCTDonNhapHang(CTDONDATHANGNCC ct,string id, int row)
        {
            var _ct = (from p in dbContext.CTDONDATHANGNCC where p.MaDonDatHangNCC == id select p).ToList().ElementAt(row);
            _ct.MaDonDatHangNCC = ct.MaDonDatHangNCC;
            _ct.MaHangHoa = ct.MaHangHoa;
            _ct.SoLuongDat = ct.SoLuongDat;
            _ct.SoLuongDaNhap = ct.SoLuongDaNhap;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaDonNhapHang(string id)
        {
            IEnumerable<CTDONDATHANGNCC> query = from ct in dbContext.CTDONDATHANGNCC where ct.MaDonDatHangNCC == id select ct;
            dbContext.CTDONDATHANGNCC.DeleteAllOnSubmit(query);
            dbContext.SubmitChanges();

            DONDATHANGNCC d = dbContext.DONDATHANGNCC.Single<DONDATHANGNCC>(x => x.MaDonDatHangNCC == id);
            dbContext.DONDATHANGNCC.DeleteOnSubmit(d);
            dbContext.SubmitChanges();
        }
        public string XuLyMaDonNhapHang()
        {
            var query = from p in dbContext.DONDATHANGNCC select p;
            string ma = query.ToList().ElementAt(query.Count() - 1).MaDonDatHangNCC;
            string mapn = "DDHNCC" + (int.Parse(ma.Substring(6, ma.Length - 6)) + 1);
            return mapn;
        }
    }
}
