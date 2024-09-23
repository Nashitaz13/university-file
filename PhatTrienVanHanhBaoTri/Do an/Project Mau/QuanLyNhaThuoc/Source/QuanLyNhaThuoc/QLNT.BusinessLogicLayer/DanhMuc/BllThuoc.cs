using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using QLNT.DataAccessLayer;
using QLNT.CommonLayer;
using QLNT.DataTransferObject;

namespace QLNT.BusinessLogicLayer
{
    public class BllThuoc
    {
        DalThuoc dalThuoc;
        public BllThuoc()
        {
            dalThuoc = new DalThuoc();
        }

        public void DocDanhMucThuoc(DataTable dtDanhMucThuoc)
        {
            dalThuoc.DocDanhMucThuoc(dtDanhMucThuoc);
        }

        public void CapNhatTonKho(int maThuoc, int SoLuongTon)
        {
            dalThuoc.CapNhatTonKho(maThuoc, SoLuongTon);
        }
    }
}
