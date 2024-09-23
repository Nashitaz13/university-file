using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class DonDatHangBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        ThamSoBLL t = new ThamSoBLL();
        public IEnumerable<DONDATHANGKH> LayDanhSachDonDatHang()
        {

            IEnumerable<DONDATHANGKH> query = from dv in dbContext.DONDATHANGKH select dv;
            return query;
        }

        public void ThemDonDatHangMoi(DONDATHANGKH d)
        {
            dbContext.DONDATHANGKH.InsertOnSubmit(d);
            dbContext.SubmitChanges();

            CTDONDATHANGKH ct = new CTDONDATHANGKH();
            ct.MaDonDatHangKH = dbContext.DONDATHANGKH.ToList().Last().MaDonDatHangKH;
            dbContext.CTDONDATHANGKH.InsertOnSubmit(ct);
            dbContext.SubmitChanges();

        }
        public void ThemCTDonDatHangMoi(DONDATHANGKH d)
        {
            dbContext.DONDATHANGKH.InsertOnSubmit(d);
            dbContext.SubmitChanges();

        }
        public void ThemCTDonDatHangMoi(CTDONDATHANGKH ct)
        {
            dbContext.CTDONDATHANGKH.InsertOnSubmit(ct);
            dbContext.SubmitChanges();

        }
        public DONDATHANGKH LayDonDatHang(string id)
        {
            return dbContext.DONDATHANGKH.Single<DONDATHANGKH>(x => x.MaDonDatHangKH == id);
        }
        public IEnumerable<CTDONDATHANGKH> LayCTDonDatHang(string id)
        {
            IEnumerable<CTDONDATHANGKH> query = from dv in dbContext.CTDONDATHANGKH where dv.MaDonDatHangKH == id select dv;
            return query;
        }
        public void CapNhatDonDatHang(DONDATHANGKH d)
        {
            DONDATHANGKH _d = dbContext.DONDATHANGKH.Single<DONDATHANGKH>(x => x.MaDonDatHangKH == d.MaDonDatHangKH);
            _d.MaKhachHang = d.MaKhachHang;
            _d.MaNhanVien = d.MaNhanVien;
            _d.NgayDat = d.NgayDat;
            _d.NgayGiaoDuKien = d.NgayGiaoDuKien;
            _d.TrangThaiGiaoHang = d.TrangThaiGiaoHang;
            // update 
            dbContext.SubmitChanges();
        }
        public void CapNhatCTDonDatHang(CTDONDATHANGKH ct, string id, int row)
        {
            var _ct = (from p in dbContext.CTDONDATHANGKH where p.MaDonDatHangKH == id select p).ToList().ElementAt(row);
            _ct.MaDonDatHangKH = ct.MaDonDatHangKH;
            _ct.MaHangHoa = ct.MaHangHoa;
            _ct.SoLuongDat = ct.SoLuongDat;
            _ct.SoLuongDaGiao = ct.SoLuongDaGiao;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaDonDatHang(string id)
        {
            IEnumerable<CTDONDATHANGKH> query = from ct in dbContext.CTDONDATHANGKH where ct.MaDonDatHangKH == id select ct;
            dbContext.CTDONDATHANGKH.DeleteAllOnSubmit(query);
            dbContext.SubmitChanges();

            DONDATHANGKH d = dbContext.DONDATHANGKH.Single<DONDATHANGKH>(x => x.MaDonDatHangKH == id);
            dbContext.DONDATHANGKH.DeleteOnSubmit(d);
            dbContext.SubmitChanges();
        }
        public string XuLyMaDonDatHang()
        {
            var query = from p in dbContext.DONDATHANGKH select p;
            string ma = query.ToList().ElementAt(query.Count() - 1).MaDonDatHangKH;
            string mapn = "DDHKH" + (int.Parse(ma.Substring(5, ma.Length - 5)) + 1);
            return mapn;
        }


    }
}
