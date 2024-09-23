using DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DAO
{
    class NhaSanXuatDao:DataProvider
    {
        private DataProvider provider = new DataProvider();
        public NhaSanXuatDao()
        {
            provider.connect();
        }
        public DataTable DanhSachNhaSanXuat()
        {
            SqlCommand cmd = new SqlCommand("DanhSachNhaSanXuat", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable ChonTenNhaSanXuat()
        {
            SqlCommand cmd = new SqlCommand("ChonTenNhaSanXuat", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public int Them(NhaSanXuat info)
        {
            SqlCommand cmd = new SqlCommand("ThemNhaSanXuat", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhaSanXuat", info.MaNhaSanXuat);
            cmd.Parameters.AddWithValue("@TenNhaSanXuat", info.TenNhaSanXuat);
            return cmd.ExecuteNonQuery();
        }

        public int CapNhat(NhaSanXuat info)
        {
            SqlCommand cmd = new SqlCommand("CapNhatNhaSanXuat", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhaSanXuat", info.MaNhaSanXuat);
            cmd.Parameters.AddWithValue("@TenNhaSanXuat", info.TenNhaSanXuat);
            return cmd.ExecuteNonQuery();
        }

        public int Xoa(NhaSanXuat info)
        {
            SqlCommand cmd = new SqlCommand("XoaNhaSanXuat", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhaSanXuat", info.MaNhaSanXuat);
            return cmd.ExecuteNonQuery();
        }

        public DataTable TimKiem(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachNhaSanXuat", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaNhaSanXuat like '%{0}%' OR TenNhaSanXuat like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);

            return dt;
        }
    }
}
