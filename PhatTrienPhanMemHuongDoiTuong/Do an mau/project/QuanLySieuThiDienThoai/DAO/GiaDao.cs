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
    class GiaDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public GiaDao()
        {
            provider.connect();
        }

        public DataTable DanhSachGia()
        {
            SqlCommand cmd = new SqlCommand("DanhSachGia", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable ChonTenMatHang()
        {
            SqlCommand cmd = new SqlCommand("ChonTenMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public int Them(Gia info)
        {
            SqlCommand cmd = new SqlCommand("ThemGia", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaMatHang", info.MaMatHang);
            cmd.Parameters.AddWithValue("@GiaNhap", info.GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", info.GiaBan);
            return cmd.ExecuteNonQuery();
        }

        public int CapNhat(Gia info)
        {
            SqlCommand cmd = new SqlCommand("CapNhatGia", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaMatHang", info.MaMatHang);
            cmd.Parameters.AddWithValue("@GiaNhap", info.GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", info.GiaBan);
            return cmd.ExecuteNonQuery();
        }
        public int Xoa(Gia info)
        {
            SqlCommand cmd = new SqlCommand("XoaGia", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaMatHang", info.MaMatHang);
            return cmd.ExecuteNonQuery();
        }
    }
}
