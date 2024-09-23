using DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DAO
{
    class DangNhapDao
    {
        private DataProvider _provider = new DataProvider();
        public DangNhapDao()
        {
            _provider.connect();
        }
        public TTDangNhap LayThongTinDangNhap(string TenDangNhap, string MatKhau)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@TenDangNhap", TenDangNhap));
            paramters.Add(new SqlParameter("@MatKhau", MatKhau));
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("DangNhap", paramters);
            TTDangNhap ttdn = new TTDangNhap();
            while (reader.Read())
            {
                ttdn.MaNhanVien = reader["MaNhanVien"].ToString();
                ttdn.TenNhanVien = reader["TenNhanVien"].ToString();
                ttdn.PhongBan = reader["PhongBan"].ToString();
            }
            reader.Close();
            return ttdn;
        }

    }
}
