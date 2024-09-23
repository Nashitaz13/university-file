using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.ApplicationBlocks.Data;
using CommonLayer;
using System.Data.SqlClient;

namespace DAL
{

   public class EmployeeDAL
    {
         
        public DataTable GetEmployeeCount()
        {
            try
            {
                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GeCountEmployee").Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public void Save(string manv, string ten, string gioitinh, string cmnd, string sdt,
                         string ngaysinh, string diachi, string noisinh, string tuoi, string chucvu,
                         string luong, string ngayVaoLam, MemoryStream anhThe,string pass, string trangthai)
        {
           
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlParameter[] para1 =
                {
                    new SqlParameter("@MaNV", manv),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@GioiTinh", gioitinh),
                    new SqlParameter("@CMND", cmnd),
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@NgaySinh", ngaysinh),
                    new SqlParameter("@DiaChi", diachi),
                    new SqlParameter("@NoiSinh", noisinh),
                    new SqlParameter("@Tuoi", tuoi),
                    new SqlParameter("@ChucVu", chucvu),
                    new SqlParameter("@Luong", luong),
                    new SqlParameter("@NgayVaoLam", ngayVaoLam),
                    new SqlParameter("@AnhThe", anhThe.ToArray()),
                    new SqlParameter("@TrangThai", trangthai),
                    new SqlParameter("@Password", pass),
                    new SqlParameter("@MaCN",manv)
                };
                SqlParameter[] para2 =
                {
                    new SqlParameter ("@MaChucNang",manv),
                };


                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "CreateFuntion", para2);
                SqlHelper.ExecuteNonQuery(tran,
                    CommandType.StoredProcedure,
                    "InsertEmployee", para1);
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdateEmployee(string manv, string ten, string gioitinh, string cmnd, string sdt,
                         string ngaysinh, string diachi, string noisinh, string tuoi, string chucvu,
                         string luong, string ngayVaoLam, MemoryStream anhThe, string pass, string trangthai)
        {
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                SqlParameter[] para1 =
                {

                    new SqlParameter("@MaNV", manv),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@GioiTinh", gioitinh),
                    new SqlParameter("@CMND", cmnd),
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@NgaySinh", ngaysinh),
                    new SqlParameter("@DiaChi", diachi),
                    new SqlParameter("@NoiSinh", noisinh),
                    new SqlParameter("@Tuoi", tuoi),
                    new SqlParameter("@ChucVu", chucvu),
                    new SqlParameter("@Luong", luong),
                    new SqlParameter("@NgayVaoLam", ngayVaoLam),
                    new SqlParameter("@AnhThe", anhThe.ToArray()),
                    new SqlParameter("@TrangThai", trangthai),
                    new SqlParameter("@Password", pass),
                    new SqlParameter("@MaCN",manv)
                };
                SqlParameter[] para2 =
               {
                    new SqlParameter ("@MaChucNang",manv),
                };


                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "UpdateFuntion", para2);
                SqlHelper.ExecuteNonQuery(tran,
                   CommandType.StoredProcedure,
                   "UpdateEmployee", para1);
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteEmployee(string manv,string trangthai)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter("@MaNV", manv),
                    new SqlParameter("@TrangThai", trangthai),
                };
                SqlHelper.ExecuteNonQuery(Constants.ConnectionString,
                   CommandType.StoredProcedure,
                   "DeleteEmployee", para);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetListPosition()
        {
            try
            {
                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetAllPosition").Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }

        }
       

        public DataTable GetAllEmployee()
        {
            try
            {
                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetAllEmployee").Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable GetImage(string EmployeeID)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter ("@MaNV",EmployeeID),
                };
                    

                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetImage",para).Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetPositionName(string positionID)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter ("@MaChucVu",positionID),
                };


                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetPositionName",para).Tables[0];

            }
            catch (Exception e)
            {
                throw e;
            }
        }
         
        public DataTable GetPosition(string positionID)
        {
            try
            {
                SqlParameter[] para =
                {
                    new SqlParameter ("@MaChucVu",positionID),
                };


                return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                    CommandType.StoredProcedure,
                    "GetPosition",para).Tables[0];

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


       


    }
}
