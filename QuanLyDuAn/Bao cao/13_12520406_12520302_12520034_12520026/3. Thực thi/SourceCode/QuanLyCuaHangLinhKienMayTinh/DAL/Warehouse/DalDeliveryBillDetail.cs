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

namespace DAL.Delivery
{
    public class DalDeliveryBillDetail
    {
        public DataTable GetDeliveryBillDetailList()
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure,
                "GetDeliveryBillDetailList").Tables[0];
        }

        public int AddDeliveryBillDetail(DtoDeliveryBillDetail data)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaChiTietPhieuXuatKho", data.MaChiTietPhieuXuatKho),
                new SqlParameter("@MaPhieuXuatKho", data.MaPhieuXuatKho),
                new SqlParameter("@MaSanPham", data.MaSanPham),
                new SqlParameter("@SoLuong", data.SoLuong),
                new SqlParameter("@GhiChu", data.GhiChu),
            };

            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure,
                    "AddDeliveryBillDetail",
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

        public DataTable GetDeliveryBillDetailWithDeliveryBillID(string id)
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure,
                "GetDeliveryBillDetailListWithMaPhieuXuatKho",
                new SqlParameter("@MaPhieuXuatKho", id)).Tables[0];
        }
    }
}
