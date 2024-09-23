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
    public class DalNhomThuoc
    {
        public DalNhomThuoc()
        {
        }

        public DataTable DocDanhMucNhomThuoc()
        {
            return SqlHelper.ExecuteDatatable(Constants.ConnectionString, "DocDanhMucNhomThuoc");
        }

        public int LuuDanhMucNhomThuoc(DtoNhomThuoc dtoNhomThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaNhomThuoc",dtoNhomThuoc.MaNhomThuoc),
	                new SqlParameter( "@TenNhomThuoc",dtoNhomThuoc.TenNhomThuoc)
            
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "LuuDanhMucNhomThuoc", parameters));
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionTonTaiMauTin);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }

        }

        public void XoaDanhMucNhomThuoc(int MaNhomThuoc)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaNhomThuoc", MaNhomThuoc) };
                SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "XoaDanhMucNhomThuoc", parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }
    }
}
