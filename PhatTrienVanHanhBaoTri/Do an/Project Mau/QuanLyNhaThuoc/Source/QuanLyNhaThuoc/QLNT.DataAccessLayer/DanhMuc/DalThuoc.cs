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
    public class DalThuoc
    {
        public DalThuoc()
        {
        }

        public void DocDanhMucThuoc(DataTable dtDanhMucThuoc)
        {
            try
            {
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocDMThuoc", dtDanhMucThuoc, null);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }            
        }

        public void CapNhatTonKho(int maThuoc, int SoLuongTon)
        {  
            SqlParameter[] parameters = {                   
                    new SqlParameter( "@MaThuoc", maThuoc),
                    new SqlParameter( "@SoLuongTon", SoLuongTon)
                };

            Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "CapNhatTonKho", parameters));            
        }
    }
}
