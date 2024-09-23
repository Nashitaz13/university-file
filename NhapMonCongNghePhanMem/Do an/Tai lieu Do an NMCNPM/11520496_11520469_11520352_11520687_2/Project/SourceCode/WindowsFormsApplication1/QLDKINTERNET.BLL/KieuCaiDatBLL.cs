using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;
using QLDKINTERNET.Data;

namespace QLDKINTERNET.BLL
{
    public class KieuCaiDatBLL
    {
        KieuCaiDatData cls = new KieuCaiDatData();

        public int ThemKieuCaiDat(KieuCaiDatPublic kcd)
        {
            return cls.ThemKieuCaiDat(kcd);
        }

        public DataTable SelectKieuCaiDat()
        {
            return cls.SelectKieuCaiDat();
        }
    }
}
