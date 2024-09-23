using CommonLayer;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PositionDAL
    {
        
        ///
        public DataTable GetPositionCount()
        {

            try
            {
                //SqlParameter[] para =
                //{
                //    new SqlParameter ("@MaChucVu",positionID),
                //};


                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetPositionCount").Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable GetAllPosition()
        {
            try
            {
                //SqlParameter[] para =
                //{
                //    new SqlParameter ("@MaChucVu",positionID),
                //};


                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetAllPosition").Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        

        public void SavePosition(string PositionID, string PositionName, string Salary, string ControlID)
        {
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlParameter[] para1 =
                {
                    new SqlParameter ("@MaChucNang",ControlID),
                };
                
                SqlParameter[] para2 =
                {
                    new SqlParameter ("@MaChucVu",PositionID),
                    new SqlParameter ("@TenChucVu",PositionName),
                    new SqlParameter ("@Luong",Salary),
                    new SqlParameter ("@MaCN",ControlID),
                };



                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "CreateFuntion", para1);
                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "SavePosition",para2);
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdatePosition(string PositionID, string PositionName, string Salary, string ControlID, string IsDelete)
        {
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlParameter[] para1 =
                {
                    new SqlParameter ("@MaChucVu",PositionID),
                    new SqlParameter ("@TenChucVu",PositionName),
                    new SqlParameter ("@Luong",Salary),
                    new SqlParameter ("@MaCN",ControlID),
                    new SqlParameter("@DaXoa",IsDelete),
                };
                SqlParameter[] para2 =
                {
                    new SqlParameter ("@MaChucNang",ControlID),
                };


                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "UpdateFuntion", para2);

                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "UpdatePosition",para1);
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletePosition(string PositionID)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter ("@MaChucVu",PositionID)
                };


                SqlHelper.ExecuteNonQuery(Constants.ConnectionString,
                   CommandType.StoredProcedure,
                   "DeletePosition", para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetFuntion(string ControlID)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter ("@MaCN",ControlID),
                };


                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetFuntion", para).Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public DataTable GetCountEmployeeUsePosition(string PositionID)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter ("@MaChucVu",PositionID),
                };


                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetCountEmployeeUsePosition", para).Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}
