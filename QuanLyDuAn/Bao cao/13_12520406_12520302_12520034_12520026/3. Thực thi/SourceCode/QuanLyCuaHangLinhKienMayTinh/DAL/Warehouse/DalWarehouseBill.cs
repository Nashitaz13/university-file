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
using Microsoft.SqlServer.Server;

namespace DAL
{
    public class DalWarehouseBill
    {
        public DataTable GetWarehouseBillList()
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure,
                "GetWarehouseBillList").Tables[0];
        }

        public int AddWarehouseBill(DtoWarehouseBill data)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaPhieuNhapKho", data.MaPhieuNhapKho),
                new SqlParameter("@NgayLapPhieu", data.NgayLapPhieu),
                new SqlParameter("@MaNguoLapPhieu", data.MaNguoiLapPhieu),
                new SqlParameter("@GhiChu", data.GhiChu),
            };
            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure,
                    "AddWarehouseBill",
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

        public int AddWarehouseBillTran(DtoWarehouseBill warehouseBill, List<DtoWarehouseBillDetail> list)
        {
            SqlConnection con = new SqlConnection(Constants.ConnectionString);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter("@MaPhieuNhapKho", warehouseBill.MaPhieuNhapKho),
                    new SqlParameter("@NgayLapPhieu", warehouseBill.NgayLapPhieu),
                    new SqlParameter("@MaNguoiLapPhieu", warehouseBill.MaNguoiLapPhieu),
                    new SqlParameter("@GhiChu", warehouseBill.GhiChu),
                };
                SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "AddWarehouseBill", para);

                foreach (DtoWarehouseBillDetail detail in list)
                {
                    SqlParameter[] para1 =
                    {
                        new SqlParameter("@MaChiTietPhieuNhapKho", detail.MaChiTietPhieuNhapKho),
                        new SqlParameter("@MaPhieuNhapKho", detail.MaPhieuNhapKho),
                        new SqlParameter("@MaSanPham", detail.MaSanPham),
                        new SqlParameter("@SoLuong", detail.SoLuong),
                        new SqlParameter("@GhiChu", detail.GhiChu),
                    };
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure,
                    "AddWarehouseBillDetail",
                    para1);

                    SqlParameter[] para2 =
                    {
                        new SqlParameter("@MaSanPham", detail.MaSanPham),
                        new SqlParameter("@SoLuong", detail.SoLuong),
                    };
                    SqlHelper.ExecuteNonQuery(tran, CommandType.StoredProcedure, "UpdateCountProduct", para2);
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
