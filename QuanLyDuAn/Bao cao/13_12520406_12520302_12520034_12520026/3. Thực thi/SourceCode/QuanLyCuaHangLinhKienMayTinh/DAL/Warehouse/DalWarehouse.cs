using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using DTO.Warehouses;
using Microsoft.ApplicationBlocks.Data;

namespace DAL.Warehouse
{
    public class DalWarehouse
    {
        public DataTable GetListWarehouse()
        {
            return
                SqlHelper.ExecuteDataset(Constants.ConnectionString, 
                CommandType.StoredProcedure, 
                "GetListWarehouses")
                    .Tables[0];
        }

        public int AddWarehouse(DtoWarehouse data)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter("@MaKho", data.MaKho),
                    new SqlParameter("@TenKho", data.TenKho),
                    new SqlParameter("@Ghichu", data.GhiChu),
                };
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, 
                    CommandType.StoredProcedure, 
                    "AddWarehouse", para);

            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionSql);
            }
            catch (Exception)
            {
                throw new  AggregateException(Constants.MsgExceptionError);
            }
        }

        public DataTable SearchWarehouse(string q)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Query", q)
            };
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, 
                CommandType.StoredProcedure,
                "SearchWarehouse",
                para).
                Tables[0];
        }

        public int EditWarehouse(DtoWarehouse data) 
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter("@MaKho", data.MaKho),
                    new SqlParameter("@TenKho", data.TenKho),
                    new SqlParameter("@Ghichu", data.GhiChu),
                };
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "EditWarehouse", para);

            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionSql);
            }
            catch (Exception)
            {
                throw new AggregateException(Constants.MsgExceptionError);
            }
        }
    }
}
