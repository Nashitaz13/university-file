using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class HangHoaBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();
        public IEnumerable<HANGHOA> LayDanhSachHangHoa()
        {
            IEnumerable<HANGHOA> query = from dv in dbContext.HANGHOA select dv;
            return query;
        }

        public void ThemHangHoaMoi(HANGHOA dv)
        {
            HANGHOA _dv = new HANGHOA();
            _dv.TenHangHoa = dv.TenHangHoa;
            _dv.MaDonVi = dv.MaDonVi;
            _dv.DonGiaNhap = dv.DonGiaNhap;
            _dv.SoLuongTon = dv.SoLuongTon;
            dbContext.HANGHOA.InsertOnSubmit(_dv);
            dbContext.SubmitChanges();
        }



        public void CapNhatHangHoa(HANGHOA dv)
        {
            HANGHOA _dv = dbContext.HANGHOA.Single<HANGHOA>(x => x.MaHangHoa == dv.MaHangHoa);
            _dv.TenHangHoa = dv.TenHangHoa;
            _dv.MaDonVi = dv.MaDonVi;
            _dv.DonGiaNhap = dv.DonGiaNhap;
            _dv.SoLuongTon = dv.SoLuongTon;
            // update 
            dbContext.SubmitChanges();
        }
        public HANGHOA LayHangHoaTheoMaHH(int id)
        {
            HANGHOA _dv = dbContext.HANGHOA.Single<HANGHOA>(x => x.MaHangHoa == id);
            return _dv;
        }
        public string LayHangHoa(int? iddv)
        {
            IEnumerable<HANGHOA> query = from dv in dbContext.HANGHOA where dv.MaHangHoa == iddv select dv;
            return query.First().TenHangHoa;
        }
        public void XoaHangHoa(int _dvID)
        {
            try
            {
                HANGHOA _dv = dbContext.HANGHOA.Single<HANGHOA>(x => x.MaHangHoa == _dvID);
                dbContext.HANGHOA.DeleteOnSubmit(_dv);

                dbContext.SubmitChanges();

            }
            catch { }
        }
        public bool KiemTraTenHangHoaTonTai(string _ten, int id = -1)
        {
            IEnumerable<HANGHOA> query = from dv in dbContext.HANGHOA where dv.TenHangHoa == _ten select dv;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.MaHangHoa == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
