using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using QLNT.CommonLayer;

namespace QLNT.DataAccessLayer
{
    public class DalSoPhieuTraThuoc
    {
        public DataTable DocDanhSachPhieuTraThuoc()
        {
            return SqlHelper.ExecuteDatatable(Constants.ConnectionString, "DocDSPhieuTraThuoc");
        }
    }
}
