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
    public class DalSoPhieuXuatThuoc
    {
        public DataTable DocDanhSachPhieuXuatThuoc()
        {
            return SqlHelper.ExecuteDatatable(Constants.ConnectionString, "DocDSPhieuXuatThuoc");
        }
    }
}
