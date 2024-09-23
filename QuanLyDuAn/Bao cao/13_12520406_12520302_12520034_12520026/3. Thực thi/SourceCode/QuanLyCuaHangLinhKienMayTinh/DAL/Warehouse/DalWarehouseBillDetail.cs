using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using DTO.Warehouse;
using Microsoft.ApplicationBlocks.Data;

namespace DAL.Warehouse
{
    public class DalWarehouseBillDetail
    {
        public DataTable GetWarehouseBillDetailList()
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure,
                "GetWarehouseBillDetailList").Tables[0];
        }

        public int AddWarehouseBillDetail(DtoWarehouseBillDetail data)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaChiTietPhieuNhapKho", data.MaChiTietPhieuNhapKho),
                new SqlParameter("@MaPhieuNhapKho", data.MaPhieuNhapKho),
                new SqlParameter("@MaSanPham", data.MaSanPham),
                new SqlParameter("@SoLuong", data.SoLuong),
                new SqlParameter("@GhiChu", data.GhiChu),
            };

            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure,
                    "AddWarehouseBillDetail",
                    para);
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

        public DataTable GetWarehouseBillDetailWithWarehouseBillID(string id)
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure,
                "GetWarehouseBillDetailListWithMaPhieuNhapKho",
                new SqlParameter("@MaPhieuNhapKho", id)).Tables[0];
        }

    }
}
