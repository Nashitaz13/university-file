using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyPOS.DAL;

namespace EasyPOS.BLL
{
    class ThamSoBLL
    {
        POS_DBDataContext dbcontext = new POS_DBDataContext();

        public string LayMaDonNhapHang()
        {
            return (from s in dbcontext.THAMSO where s.ThamSo1 == "MaDonDatHangNCC" select s).First().GiaTri;
        }
      
    }
}
