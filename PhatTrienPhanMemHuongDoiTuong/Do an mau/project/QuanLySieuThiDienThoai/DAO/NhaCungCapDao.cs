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
    class NhaCungCapDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public NhaCungCapDao()
        {
            provider.connect();
        }
        public DataTable DanhSachNhaCungCap()
        {
            SqlCommand cmd = new SqlCommand("DanhSachNhaCungCap", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable ChonTenNhaCungCap()
        {
            SqlCommand cmd = new SqlCommand("ChonTenNhaCungCap", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public int Them(NhaCungCap info)
        {
            SqlCommand cmd = new SqlCommand("ThemNhaCungCap", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhaCungCap", info.MaNhaCungCap);
            cmd.Parameters.AddWithValue("@TenNhaCungCap", info.TenNhaCungCap);
            cmd.Parameters.AddWithValue("@DiaChi", info.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", info.SoDienThoai);
            return cmd.ExecuteNonQuery();
        }

        public int CapNhat(NhaCungCap info)
        {
            SqlCommand cmd = new SqlCommand("CapNhatNhaCungCap", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhaCungCap", info.MaNhaCungCap);
            cmd.Parameters.AddWithValue("@TenNhaCungCap", info.TenNhaCungCap);
            cmd.Parameters.AddWithValue("@DiaChi", info.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", info.SoDienThoai);
            return cmd.ExecuteNonQuery();
        }

        public int Xoa(NhaCungCap info)
        {
            SqlCommand cmd = new SqlCommand("XoaNhaCungCap", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhaCungCap", info.MaNhaCungCap);
            return cmd.ExecuteNonQuery();
        }

        public DataTable LayDanhSachNCC()
        {
            SqlCommand cmd = new SqlCommand("LayNCC", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable TimKiem(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachNhaCungCap", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaNhaCungCap like '%{0}%' OR TenNhaCungCap like '%{0}%' OR DiaChi like '%{0}%' OR SoDienThoai like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);

            return dt;
        }
    }
}
