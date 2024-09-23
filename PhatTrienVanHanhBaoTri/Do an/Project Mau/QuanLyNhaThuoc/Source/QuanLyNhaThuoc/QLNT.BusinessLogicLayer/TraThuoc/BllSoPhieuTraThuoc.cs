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
    public class BllSoPhieuTraThuoc
    {
        DalSoPhieuTraThuoc dalSoPhieuTraThuoc;
        public BllSoPhieuTraThuoc()
        {
            dalSoPhieuTraThuoc = new DalSoPhieuTraThuoc();
        }

        public DataTable DocDanhSachPhieuTraThuoc()
        {
            return dalSoPhieuTraThuoc.DocDanhSachPhieuTraThuoc();
        }
    }
}
