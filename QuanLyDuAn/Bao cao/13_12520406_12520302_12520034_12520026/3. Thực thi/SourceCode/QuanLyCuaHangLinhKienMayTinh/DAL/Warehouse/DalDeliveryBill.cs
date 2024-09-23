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
    public class DalDeliveryBill
    {
        public DataTable GetDeliveryBillList()
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure,
                "GetDeliveryBillList").Tables[0];
        }

        public int AddDeliveryBill(DtoDeliveryBill data)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaPhieuXuatKho", data.MaPhieuXuatKho),
                new SqlParameter("@NgayLapPhieu", data.NgayLapPhieu),
                new SqlParameter("@MaNguoiNhan", data.MaNguoiNhan), 
                new SqlParameter("@MaNguoLapPhieu", data.MaNguoiLapPhieu),
                new SqlParameter("@GhiChu", data.GhiChu),
            };
            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure,
                    "AddDeliveryBill",
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

        public DataTable GetEmployeeList()
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure, "GetEmployeeList").Tables[0];
        }

        public int AddDeliveryBillTran(DtoDeliveryBill DeliveryBill, List<DtoDeliveryBillDetail> list)
        {
            SqlConnection con = new SqlConnection(Constants.ConnectionString);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter("@MaPhieuXuatKho", DeliveryBill.MaPhieuXuatKho),
                    new SqlParameter("@NgayLapPhieu", DeliveryBill.NgayLapPhieu),
                    new SqlParameter("@MaNguoiNhan", DeliveryBill.MaNguoiNhan), 
                    new SqlParameter("@MaNguoiLapPhieu", DeliveryBill.MaNguoiLapPhieu),
                    new SqlParameter("@GhiChu", DeliveryBill.GhiChu),
                };
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "AddDeliveryBill", para);

                foreach (DtoDeliveryBillDetail detail in list)
                {
                    SqlParameter[] para1 =
                    {
                        new SqlParameter("@MaChiTietPhieuXuatKho", detail.MaChiTietPhieuXuatKho),
                        new SqlParameter("@MaPhieuXuatKho", detail.MaPhieuXuatKho),
                        new SqlParameter("@MaSanPham", detail.MaSanPham),
                        new SqlParameter("@SoLuong", detail.SoLuong),
                        new SqlParameter("@GhiChu", detail.GhiChu),
                    };
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure,
                    "AddDeliveryBillDetail",
                    para1);

                    SqlParameter[] para2 =
                    {
                        new SqlParameter("@MaSanPham", detail.MaSanPham),
                        new SqlParameter("@SoLuong", detail.SoLuong),
                    };
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "UpdateCountProductOut", para2);
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return 0;
            }
            return 1;

        }
    }
}
