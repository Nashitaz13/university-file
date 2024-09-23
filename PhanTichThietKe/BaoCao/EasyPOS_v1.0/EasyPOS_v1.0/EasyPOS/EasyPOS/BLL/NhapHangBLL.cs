using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class NhapHangBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        public IEnumerable<PHIEUNHAP> LayDanhSachPhieuNhap()
        {
            IEnumerable<PHIEUNHAP> query = from dv in dbContext.PHIEUNHAP select dv;
            return query;
        }
        public PHIEUNHAP LayPhieuNhap(string id)
        {
            IEnumerable<PHIEUNHAP> query = from dv in dbContext.PHIEUNHAP where dv.MaPhieuNhap == id select dv;
            return query.First();
        }
        public IEnumerable<CTPHIEUNHAP> LayChiTietPhieuNhap(string id)
        {
            IEnumerable<CTPHIEUNHAP> query = from dv in dbContext.CTPHIEUNHAP where dv.MaPhieuNhap == id select dv;
            return query;
        }
        public void ThemPhieuNhapMoi(PHIEUNHAP p)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.MaPhieuNhap = p.MaPhieuNhap;
            pn.MaNguoiDung = p.MaNguoiDung;
            pn.NgayLap = p.NgayLap;
            pn.TongThanhTien = p.TongThanhTien;
            pn.MaDonDatHangNCC = p.MaDonDatHangNCC;
            dbContext.PHIEUNHAP.InsertOnSubmit(pn);
            dbContext.SubmitChanges();

        }
        public void ThemCTPhieuNhapMoi(CTPHIEUNHAP ct)
        {
            CTPHIEUNHAP ctpn = new CTPHIEUNHAP();
            ctpn.MaHangHoa = ct.MaHangHoa;
            ctpn.MaPhieuNhap = ct.MaPhieuNhap;
            ctpn.DonGiaNhap = ct.DonGiaNhap;
            ctpn.SoLuongNhap = ct.SoLuongNhap;
            ctpn.SoLuongChuaNhap = ct.SoLuongChuaNhap;
            ctpn.ThanhTien = ct.ThanhTien;
            dbContext.CTPHIEUNHAP.InsertOnSubmit(ctpn);
            dbContext.SubmitChanges();
        }
        public CTPHIEUNHAP LayCTPhieuNhapTheoHangHoa(int mahh)
        {
            CTPHIEUNHAP ctpn = new CTPHIEUNHAP();
            var query = from row in dbContext.CTPHIEUNHAP where row.MaHangHoa == mahh select row;
            ctpn.MaPhieuNhap = query.ToList().ElementAt(query.Count() - 1).MaPhieuNhap;
            ctpn.MaHangHoa = query.ToList().ElementAt(query.Count() - 1).MaHangHoa;
            ctpn.DonGiaNhap = query.ToList().ElementAt(query.Count() - 1).DonGiaNhap;
            ctpn.SoLuongNhap = query.ToList().ElementAt(query.Count() - 1).SoLuongNhap;
            ctpn.SoLuongChuaNhap = query.ToList().ElementAt(query.Count() - 1).SoLuongChuaNhap;
            ctpn.ThanhTien = query.ToList().ElementAt(query.Count() - 1).ThanhTien;
            return ctpn;
        }


        public void CapNhatPhieuNhap(PHIEUNHAP dv)
        {
            PHIEUNHAP _dv = dbContext.PHIEUNHAP.Single<PHIEUNHAP>(x => x.MaPhieuNhap == dv.MaPhieuNhap);
            _dv.MaNguoiDung = dv.MaNguoiDung;
            _dv.MaDonDatHangNCC = dv.MaDonDatHangNCC;
            _dv.NgayLap = dv.NgayLap;
            _dv.TongThanhTien = dv.TongThanhTien;
            _dv.ThanhToan = dv.ThanhToan;
            _dv.ConLai = dv.ConLai;
            // update 
            dbContext.SubmitChanges();
        }

        public void CapNhatCTPhieuNhap(CTPHIEUNHAP dv, string id, int row)
        {         
            var _dv = (from p in dbContext.CTPHIEUNHAP where p.MaPhieuNhap == id select p).ToList().ElementAt(row);
            _dv.MaHangHoa = dv.MaHangHoa;
            _dv.DonGiaNhap = dv.DonGiaNhap;
            _dv.SoLuongNhap = dv.SoLuongNhap;
            _dv.ThanhTien = dv.ThanhTien;
            _dv.SoLuongChuaNhap = dv.SoLuongChuaNhap;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaPhieuNhap(string ID)
        {
            IEnumerable<CTPHIEUNHAP> query = from dv in dbContext.CTPHIEUNHAP where dv.MaPhieuNhap == ID select dv;
            dbContext.CTPHIEUNHAP.DeleteAllOnSubmit(query);
            dbContext.SubmitChanges();

            PHIEUNHAP p = dbContext.PHIEUNHAP.Single<PHIEUNHAP>(x => x.MaPhieuNhap == ID);
            dbContext.PHIEUNHAP.DeleteOnSubmit(p);
            dbContext.SubmitChanges();
        }
        public string XuLyMaPhieuNhap()
        {
            var query = from p in dbContext.PHIEUNHAP select p;
            string ma = query.ToList().ElementAt(query.Count() - 1).MaPhieuNhap;
            string mapn = "PN" + (int.Parse(ma.Substring(2, ma.Length - 2)) + 1);
            return mapn;
        }
    }
}
