using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class KhachHangBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        public IEnumerable<KHACHHANG> LayDanhSachKhachHang()
        {
            IEnumerable<KHACHHANG> query = from kh in dbContext.KHACHHANG select kh;
            return query;
        }

        public void ThemKhachHangMoi(string _tenKhachHang, string _gioiTinh, string _diaChi, string _sdt)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.TenKhachHang = _tenKhachHang;
            kh.GioiTinh = _gioiTinh;
            kh.DiaChi = _diaChi;
            kh.SDT = _sdt;
            dbContext.KHACHHANG.InsertOnSubmit(kh);
            dbContext.SubmitChanges();
        }

        public bool KiemTraTenKhachHangTonTai(string _tenKhachHang, int id = -1)
        {
            IEnumerable<KHACHHANG> query = from kh in dbContext.KHACHHANG where kh.TenKhachHang == _tenKhachHang select kh;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.MaKhachHang == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public void CapNhatKhachHang(KHACHHANG kh)
        {
            KHACHHANG _kh = dbContext.KHACHHANG.Single<KHACHHANG>(x => x.MaKhachHang == kh.MaKhachHang);
            _kh.TenKhachHang = kh.TenKhachHang;
            _kh.GioiTinh = kh.GioiTinh;
            _kh.DiaChi = kh.DiaChi;
            _kh.SDT = kh.SDT;
            _kh.SoTienNo = kh.SoTienNo;
            dbContext.SubmitChanges();
        }

        public string LayKhachHang(int? idkh)
        {
            IEnumerable<KHACHHANG> query = from kh in dbContext.KHACHHANG where kh.MaKhachHang == idkh select kh;
            return query.First().TenKhachHang;
        }

        public void XoaKhachHang(int _khID)
        {
            KHACHHANG _kh = dbContext.KHACHHANG.Single<KHACHHANG>(x => x.MaKhachHang == _khID);
            dbContext.KHACHHANG.DeleteOnSubmit(_kh);
            dbContext.SubmitChanges();
        }
    }
}
