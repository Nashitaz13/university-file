using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using QLNT.DataTransferObject;
using QLNT.CommonLayer;

namespace QLNT.DataAccessLayer
{
    public class DalNhaCungCap
    {
        public DalNhaCungCap()
        {
        }

        public void DocDanhSachNhaCungCap(DataTable dtNhaCungCap)
        {
            SqlHelper.FillDataTable(Constants.ConnectionString, "DocDSNhaCungCap", dtNhaCungCap, null);
        }
    }
}
