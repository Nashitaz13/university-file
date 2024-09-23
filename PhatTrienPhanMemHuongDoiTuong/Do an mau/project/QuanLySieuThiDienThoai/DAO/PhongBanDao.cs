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
    class PhongBanDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public PhongBanDao()
        {
            provider.connect();
        }
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand("DanhSachPhongBan", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable Search(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachPhongBan", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaPhong like '%{0}%' OR TenPhong like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);

            return dt;
        }
        public DataTable SelectTenPhongBan()
        {
            SqlCommand cmd = new SqlCommand("SelectTenPhongBan", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public int Insert(PhongBan info)
        {
            SqlCommand cmd = new SqlCommand("InsertPhongBan", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaPhong", info.MaPhong);
            cmd.Parameters.AddWithValue("@TenPhong", info.TenPhong);
            return cmd.ExecuteNonQuery();
        }

        public int Update(PhongBan info)
        {
            SqlCommand cmd = new SqlCommand("UpdatePhongBan", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaPhong", info.MaPhong);
            cmd.Parameters.AddWithValue("@TenPhong", info.TenPhong);
            return cmd.ExecuteNonQuery();
        }

        public int Delete(PhongBan info)
        {
            SqlCommand cmd = new SqlCommand("DeletePhongBan", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaPhong", info.MaPhong);
            return cmd.ExecuteNonQuery();
        }

    }
}
