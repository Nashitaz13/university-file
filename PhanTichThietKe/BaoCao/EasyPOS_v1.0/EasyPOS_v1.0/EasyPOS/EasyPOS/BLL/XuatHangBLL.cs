using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class XuatHangBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        public IEnumerable<PHIEUGIAOHANG> LayDanhSachPhieuGiaoHang()
        {
            IEnumerable<PHIEUGIAOHANG> query = from dv in dbContext.PHIEUGIAOHANG select dv;
            return query;
        }
        public PHIEUGIAOHANG LayPhieuGiaoHang(string id)
        {
            IEnumerable<PHIEUGIAOHANG> query = from dv in dbContext.PHIEUGIAOHANG where dv.MaPhieuGiaoHang == id select dv;
            return query.First();
        }
        public IEnumerable<CTPHIEUGIAOHANG> LayChiTietPhieuGiaoHang(string id)
        {
            IEnumerable<CTPHIEUGIAOHANG> query = from dv in dbContext.CTPHIEUGIAOHANG where dv.MaPhieuGiaoHang == id select dv;
            return query;
        }
        public void ThemPhieuGiaoHangMoi(PHIEUGIAOHANG p)
        {
            PHIEUGIAOHANG pn = new PHIEUGIAOHANG();
            pn.MaPhieuGiaoHang = p.MaPhieuGiaoHang;
            pn.MaNguoiDung = p.MaNguoiDung;
            pn.NgayGiao = p.NgayGiao;
            pn.TongTien = p.TongTien;
            pn.ThanhToan = p.ThanhToan;
            pn.ConLai = p.ConLai;
            pn.MaDonDatHangKH = pn.MaDonDatHangKH;
            dbContext.PHIEUGIAOHANG.InsertOnSubmit(pn);
            dbContext.SubmitChanges();

        }
        public void ThemCTPhieuGiaoHangMoi(CTPHIEUGIAOHANG ct)
        {
            CTPHIEUGIAOHANG ctpn = new CTPHIEUGIAOHANG();
            ctpn.MaHangHoa = ct.MaHangHoa;
            var query = from row in dbContext.PHIEUGIAOHANG  select row;
            ctpn.MaPhieuGiaoHang = query.ToList().ElementAt(query.Count() - 1).MaPhieuGiaoHang;
            ctpn.DonGia = ct.DonGia;
            ctpn.SoLuongGiao = ct.SoLuongGiao;
            ctpn.SoLuongChuaGiao = ct.SoLuongChuaGiao;
            ctpn.ThanhTien = ct.ThanhTien;
            dbContext.CTPHIEUGIAOHANG.InsertOnSubmit(ctpn);
            dbContext.SubmitChanges();
        }
        public CTPHIEUGIAOHANG LayCTPhieuGiaoHangTheoHangHoa(int mahh)
        {
            CTPHIEUGIAOHANG ctpn = new CTPHIEUGIAOHANG();
            var query = from row in dbContext.CTPHIEUGIAOHANG where row.MaHangHoa == mahh select row;
            ctpn.MaPhieuGiaoHang = query.ToList().ElementAt(query.Count() - 1).MaPhieuGiaoHang;
            ctpn.MaHangHoa = query.ToList().ElementAt(query.Count() - 1).MaHangHoa;
            ctpn.DonGia = query.ToList().ElementAt(query.Count() - 1).DonGia;
            ctpn.SoLuongGiao = query.ToList().ElementAt(query.Count() - 1).SoLuongGiao;
            ctpn.SoLuongChuaGiao = query.ToList().ElementAt(query.Count() - 1).SoLuongChuaGiao;
            ctpn.ThanhTien = query.ToList().ElementAt(query.Count() - 1).ThanhTien;
            return ctpn;
        }


        public void CapNhatPhieuGiaoHang(PHIEUGIAOHANG dv)
        {
            PHIEUGIAOHANG _dv = dbContext.PHIEUGIAOHANG.Single<PHIEUGIAOHANG>(x => x.MaPhieuGiaoHang == dv.MaPhieuGiaoHang);
            _dv.MaPhieuGiaoHang = dv.MaPhieuGiaoHang;
            _dv.MaNguoiDung = dv.MaNguoiDung;
            _dv.NgayGiao = dv.NgayGiao;
            _dv.TongTien = dv.TongTien;
            _dv.ThanhToan = dv.ThanhToan;
            _dv.ConLai = dv.ConLai;
            _dv.MaDonDatHangKH = dv.MaDonDatHangKH;
            // update 
            dbContext.SubmitChanges();
        }

        public void CapNhatCTPhieuGiaoHang(CTPHIEUGIAOHANG dv, string id, int row)
        {
            var _dv = (from p in dbContext.CTPHIEUGIAOHANG where p.MaPhieuGiaoHang == id select p).ToList().ElementAt(row);
            _dv.MaHangHoa = dv.MaHangHoa;
            var query = from r in dbContext.PHIEUGIAOHANG select r;
            _dv.MaPhieuGiaoHang = query.ToList().ElementAt(query.Count() - 1).MaPhieuGiaoHang;
            _dv.DonGia = dv.DonGia;
            _dv.SoLuongGiao = dv.SoLuongGiao;
            _dv.SoLuongChuaGiao = dv.SoLuongChuaGiao;
            _dv.ThanhTien = dv.ThanhTien;
            // update 
            dbContext.SubmitChanges();
        }
        public void XoaPHIEUGIAOHANG(string ID)
        {
            IEnumerable<CTPHIEUGIAOHANG> query = from dv in dbContext.CTPHIEUGIAOHANG where dv.MaPhieuGiaoHang == ID select dv;
            dbContext.CTPHIEUGIAOHANG.DeleteAllOnSubmit(query);
            dbContext.SubmitChanges();

            PHIEUGIAOHANG p = dbContext.PHIEUGIAOHANG.Single<PHIEUGIAOHANG>(x => x.MaPhieuGiaoHang == ID);
            dbContext.PHIEUGIAOHANG.DeleteOnSubmit(p);
            dbContext.SubmitChanges();
        }
        public string XuLyMaPhieuGiaoHang()
        {
            var query = from p in dbContext.PHIEUGIAOHANG select p;
            string ma = query.ToList().ElementAt(query.Count() - 1).MaPhieuGiaoHang;
            string mapn = "PGH" + (int.Parse(ma.Substring(3, ma.Length - 3)) + 1);
            return mapn;
        }
    }
}
