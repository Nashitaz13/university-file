using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class DonViBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();
        public IEnumerable<DONVI> LayDanhSachDonVi()
        {

            IEnumerable<DONVI> query = from dv in dbContext.DONVI select dv;
            return query;
        }

        public void ThemDonViMoi(string _tenDonVi)
        {
            DONVI dv = new DONVI();
            dv.TenDonVi = _tenDonVi;
            dbContext.DONVI.InsertOnSubmit(dv);
            dbContext.SubmitChanges();
        }

        public bool KiemTraTenDonViTonTai(string _tenDonVi, int id = -1)
        {
            IEnumerable<DONVI> query = from dv in dbContext.DONVI where dv.TenDonVi == _tenDonVi select dv;
            if (0 < query.Count() && query.Count() <= 2)
            {
                if (id != -1)
                {
                    query = query.Where(m => m.MaDonVi == id);
                    if (query.Count() == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void CapNhatDonVi(DONVI dv)
        {
            DONVI _dv = dbContext.DONVI.Single<DONVI>(x => x.MaDonVi == dv.MaDonVi);
            _dv.TenDonVi = dv.TenDonVi;
            // update 
            dbContext.SubmitChanges();
        }

        public string LayDonViTinh(int? iddv)
        {
            IEnumerable<DONVI> query = from dv in dbContext.DONVI where dv.MaDonVi == iddv select dv;
            return query.First().TenDonVi;
        }
        public void XoaDonVi(int _dvID)
        {
            DONVI _dv = dbContext.DONVI.Single<DONVI>(x => x.MaDonVi == _dvID);
            dbContext.DONVI.DeleteOnSubmit(_dv);

            dbContext.SubmitChanges();
        }
    }
}
