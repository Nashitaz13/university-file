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
    public class BllSoPhieuXuatThuoc
    {
        DalSoPhieuXuatThuoc dalSoPhieuXuatThuoc;
        public BllSoPhieuXuatThuoc()
        {
            dalSoPhieuXuatThuoc = new DalSoPhieuXuatThuoc();
        }

        public DataTable DocDanhSachPhieuXuatThuoc()
        {
            return dalSoPhieuXuatThuoc.DocDanhSachPhieuXuatThuoc();
        }
    }
}
