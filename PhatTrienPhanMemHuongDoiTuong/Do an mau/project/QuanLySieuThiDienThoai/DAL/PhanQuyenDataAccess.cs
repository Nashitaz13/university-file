using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class PhanQuyenDataAccess
    {
        private DataProvider _provider = new DataProvider();
        public PhanQuyenDataAccess()
        {
            _provider.connect();
        }
        #region "getds"
        public List<PhanQuyenInfo> getdsPhanQuyen()
        {
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("getdsPhanQuyen");
            List<PhanQuyenInfo> List_PhanQuyen = new List<PhanQuyenInfo>();
            while (reader.Read())
            {
                PhanQuyenInfo PhanQuyen = new PhanQuyenInfo();
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
        public void insert(PhanQuyenInfo info)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@Quyen", info.Quyen));
            paramters.Add(new SqlParameter("@MaNhanVien", info.MaNhanVien));
            paramters.Add(new SqlParameter("@TenDangNhap", info.TenDangNhap));
            paramters.Add(new SqlParameter("@MatKhau", info.MatKhau));
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("insertPhanQuyen", paramters);
            reader.Close();
        }
        #endregion

        #region "update"
        public void update(PhanQuyenInfo info)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@Quyen", info.Quyen));
            paramters.Add(new SqlParameter("@MaNhanVien", info.MaNhanVien));
            paramters.Add(new SqlParameter("@TenDangNhap", info.TenDangNhap));
            paramters.Add(new SqlParameter("@MatKhau", info.MatKhau));
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("updatePhanQuyen", paramters);
            reader.Close();
        }
        #endregion

        #region "delete"
        public void delete(PhanQuyenInfo info)
        {
            string deleteCommand = "delete from PhanQuyen where TenDangNhap='" + info.TenDangNhap + "'";
            _provider.executeNonQuery(deleteCommand);
        }
        #endregion
    }
}