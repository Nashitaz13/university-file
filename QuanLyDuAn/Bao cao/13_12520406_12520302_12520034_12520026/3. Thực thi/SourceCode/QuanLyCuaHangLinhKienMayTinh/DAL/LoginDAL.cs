using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using CommonLayer;

namespace DAL
{ 
    public class LoginDAL
    {
        

        // lay mat khau nhan vien
        public DataTable LayMatKhauNhanVien(string manv)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter("@MaNV", manv),
                     
                };
                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetPasswordEmployee", para).Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }
             

        }

        //public int AddWarehouse(DtoWarehouse data)
        //{
        //    try
        //    {
        //        SqlParameter[] para =
        //        {
        //            new SqlParameter("@MaKho", data.MaKho),
        //            new SqlParameter("@TenKho", data.TenKho),
        //            new SqlParameter("@TrangThai", data.TrangThai == true ? 1 : 0),
        //            new SqlParameter("@NgayTao", data.NgayTao),
        //            new SqlParameter("@Ghichu", data.GhiChu),
        //        };
        //        return SqlHelper.ExecuteNonQuery(Constants.ConnectionString,
        //            CommandType.StoredProcedure,
        //            "AddWarehouse", para);

            //    }
            //    catch (SqlException)
            //    {
            //        throw new ArgumentException(Constants.MsgExceptionSql);
            //    }
            //    catch (Exception)
            //    {
            //        throw new AggregateException(Constants.MsgExceptionError);
            //    }
            //}










            ///// <summary>
            ///// cap nhat ma lich su dang nhap
            ///// malsdn =0 // da thoat, khong dang su dung
            ///// #0 dang su dung
            ///// </summary>
            ///// <param name="manv"></param>
            ///// <param name="malsdn"></param>
            //public void CapNhatTinhTrang(string manv,string malsdn)
            //{
            //    string sql = "update TAIKHOAN set DangSuDung =N'"+malsdn+"'  where MaNV='" + manv + "'";
            //     con.Write(sql);
            //}




        }
}
