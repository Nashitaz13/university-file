using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DTO;

namespace DAO
{
    public class PhanQuyenDao
    {
        private DataProvider provider = new DataProvider();
        public PhanQuyenDao()
        {
            provider.connect();
        }
        #region "getds"
        public List<PhanQuyen> getdsPhanQuyen()
        {
            SqlDataReader reader = (SqlDataReader)provider.executeQuery("getdsPhanQuyen");
            List<PhanQuyen> List_PhanQuyen = new List<PhanQuyen>();
            while (reader.Read())
            {
                PhanQuyen PhanQuyen = new PhanQuyen();
                PhanQuyen.Quyen = reader["Quyen"].ToString();
                PhanQuyen.MaNhanVien = reader["MaNhanVien"].ToString();
                PhanQuyen.TenDangNhap = reader["TenDangNhap"].ToString();
                PhanQuyen.MatKhau = reader["MatKhau"].ToString();
                List_PhanQuyen.Add(PhanQuyen);
            }
            reader.Close();
            return List_PhanQuyen;
        }
        #endregion

        #region "insert"
        public void insert(PhanQuyen info)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@Quyen", info.Quyen));
            paramters.Add(new SqlParameter("@MaNhanVien", info.MaNhanVien));
            paramters.Add(new SqlParameter("@TenDangNhap", info.TenDangNhap));
            paramters.Add(new SqlParameter("@MatKhau", info.MatKhau));
            SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("insertPhanQuyen", paramters);
            reader.Close();
        }
        #endregion

        #region "update"
        public void update(PhanQuyen info)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@Quyen", info.Quyen));
            paramters.Add(new SqlParameter("@MaNhanVien", info.MaNhanVien));
            paramters.Add(new SqlParameter("@TenDangNhap", info.TenDangNhap));
            paramters.Add(new SqlParameter("@MatKhau", info.MatKhau));
            SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("updatePhanQuyen", paramters);
            reader.Close();
        }
        #endregion

        #region "delete"
        public void delete(PhanQuyen info)
        {
            string deleteCommand = "delete from PhanQuyen where TenDangNhap='" + info.TenDangNhap + "'";
            provider.executeNonQuery(deleteCommand);
        }
        #endregion
    }
}