using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class NhaCungCapBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        public IEnumerable<NHACUNGCAP> LayDanhSachNhaCungCap()
        {
            IEnumerable<NHACUNGCAP> query = from ncc in dbContext.NHACUNGCAP select ncc;
            return query;
        }

        public void ThemNhaCungCapMoi(string _tenNhaCungCap, string _diaChi, string _sdt)
        {
            NHACUNGCAP ncc = new NHACUNGCAP();
            ncc.TenNhaCungCap = _tenNhaCungCap;
            ncc.DiaChi = _diaChi;
            ncc.SDT = _sdt;
  //          ncc.SoTienHangCuaHangNo = int.Parse(sotienhang);
            dbContext.NHACUNGCAP.InsertOnSubmit(ncc);
            dbContext.SubmitChanges();
        }

        public bool KiemTraTenNhaCungCapTonTai(string _tenNhaCungCap, int id = -1)
        {
            IEnumerable<NHACUNGCAP> query = from ncc in dbContext.NHACUNGCAP where ncc.TenNhaCungCap == _tenNhaCungCap select ncc;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.MaNhaCungCap == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void CapNhatNhaCungCap(NHACUNGCAP ncc)
        {
            NHACUNGCAP _ncc = dbContext.NHACUNGCAP.Single<NHACUNGCAP>(x => x.MaNhaCungCap == ncc.MaNhaCungCap);
            _ncc.TenNhaCungCap = ncc.TenNhaCungCap;
            _ncc.DiaChi = ncc.DiaChi;
            _ncc.SDT = ncc.SDT;
            _ncc.SoTienHangCuaHangNo = ncc.SoTienHangCuaHangNo;
            dbContext.SubmitChanges();
        }

        public string LayNhaCungCap(int? idncc)
        {
            IEnumerable<NHACUNGCAP> query = from ncc in dbContext.NHACUNGCAP where ncc.MaNhaCungCap == idncc select ncc;
            return query.First().TenNhaCungCap;
        }

        public void XoaNhaCungCap(int _nccID)
        {
            NHACUNGCAP _ncc = dbContext.NHACUNGCAP.Single<NHACUNGCAP>(x => x.MaNhaCungCap == _nccID);
            dbContext.NHACUNGCAP.DeleteOnSubmit(_ncc);
            dbContext.SubmitChanges();
        }
    }
}
