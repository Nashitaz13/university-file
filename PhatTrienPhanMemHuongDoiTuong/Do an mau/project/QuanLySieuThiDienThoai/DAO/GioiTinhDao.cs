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
    class GioiTinhDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public GioiTinhDao()
        {
            provider.connect();
        }
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand("DanhSachGioiTinh", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable SelectTenGioiTinh()
        {
            SqlCommand cmd = new SqlCommand("SelectTenGioiTinh", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public int Insert(GioiTinh info)
        {
            SqlCommand cmd = new SqlCommand("InsertGioiTinh", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaGioiTinh", info.MaGioiTinh);
            cmd.Parameters.AddWithValue("@TenGioiTinh", info.TenGioiTinh);
            return cmd.ExecuteNonQuery();
        }

        public int Update(GioiTinh info)
        {
            SqlCommand cmd = new SqlCommand("UpdateGioiTinh", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaGioiTinh", info.MaGioiTinh);
            cmd.Parameters.AddWithValue("@TenGioiTinh", info.TenGioiTinh);
            return cmd.ExecuteNonQuery();
        }

        public int Delete(GioiTinh info)
        {
            SqlCommand cmd = new SqlCommand("DeleteGioiTinh", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaGioiTinh", info.MaGioiTinh);
            return cmd.ExecuteNonQuery();
        }
    }
}
