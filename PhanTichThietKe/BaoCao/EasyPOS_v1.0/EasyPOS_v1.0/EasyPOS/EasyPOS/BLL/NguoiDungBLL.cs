using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class NguoiDungBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        public IEnumerable<NGUOIDUNG> LayDanhSachNguoiDung()
        {
            IEnumerable<NGUOIDUNG> query = from nd in dbContext.NGUOIDUNG select nd;
            return query;
        }

        public void ThemNguoiDungMoi(string _tenNguoiDung, string _tenTaiKhoan, string _matKhau, bool _loaiNguoiDung)
        {
            NGUOIDUNG nd = new NGUOIDUNG();
            nd.TenNguoiDung = _tenNguoiDung;
            nd.TenTaiKhoan = _tenTaiKhoan;
            nd.MatKhau = _matKhau;
            nd.QuanTriHeThong = _loaiNguoiDung;
            dbContext.NGUOIDUNG.InsertOnSubmit(nd);
            dbContext.SubmitChanges();
        }
        public bool KiemTraTenNguoiDungTonTai(string _tenTaiKhoan, int id = -1)
        {
            IEnumerable<NGUOIDUNG> query = from nd in dbContext.NGUOIDUNG where nd.TenTaiKhoan == _tenTaiKhoan select nd;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.MaNguoiDung == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void CapNhatNguoiDung(NGUOIDUNG nd)
        {
            NGUOIDUNG _nd = dbContext.NGUOIDUNG.Single<NGUOIDUNG>(x => x.MaNguoiDung == nd.MaNguoiDung);
            _nd.TenTaiKhoan = nd.TenTaiKhoan;
            _nd.TenNguoiDung = nd.TenNguoiDung;
            _nd.QuanTriHeThong = nd.QuanTriHeThong;
            dbContext.SubmitChanges();
        }

        public string LayNguoiDung(int? idnd)
        {
            IEnumerable<NGUOIDUNG> query = from nd in dbContext.NGUOIDUNG where nd.MaNguoiDung == idnd select nd;
            return query.First().TenNguoiDung;
        }
        public int LayMaNguoiDung(string ten)
        {
            IEnumerable<NGUOIDUNG> query = from nd in dbContext.NGUOIDUNG where nd.TenNguoiDung == ten select nd;
            return query.First().MaNguoiDung;
        }
        public void XoaNguoiDung(int _ndID)
        {
            NGUOIDUNG _nd = dbContext.NGUOIDUNG.Single<NGUOIDUNG>(x => x.MaNguoiDung == _ndID);
            dbContext.NGUOIDUNG.DeleteOnSubmit(_nd);
            dbContext.SubmitChanges();
        }
    }
}
