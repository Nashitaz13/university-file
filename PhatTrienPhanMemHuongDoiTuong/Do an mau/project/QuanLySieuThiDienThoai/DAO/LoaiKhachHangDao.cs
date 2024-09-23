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
    class LoaiKhachHangDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public LoaiKhachHangDao()
        {
            provider.connect();
        }
        public DataTable DanhSachLoaiKhachHang()
        {
            SqlCommand cmd = new SqlCommand("DanhSachLoaiKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable ChonTenLoaiKhachHang()
        {
            SqlCommand cmd = new SqlCommand("ChonTenLoaiKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public int Them(LoaiKhachHang info)
        {
            SqlCommand cmd = new SqlCommand("ThemLoaiKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaLoaiKhachHang", info.MaLoaiKhachHang);
            cmd.Parameters.AddWithValue("@TenLoaiKhachHang", info.TenLoaiKhachHang);
            cmd.Parameters.AddWithValue("@HeSoGiamGia", info.HeSoGiamGia);
            return cmd.ExecuteNonQuery();
        }

        public int CapNhat(LoaiKhachHang info)
        {
            SqlCommand cmd = new SqlCommand("CapNhatLoaiKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaLoaiKhachHang", info.MaLoaiKhachHang);
            cmd.Parameters.AddWithValue("@TenLoaiKhachHang", info.TenLoaiKhachHang);
            cmd.Parameters.AddWithValue("@HeSoGiamGia", info.HeSoGiamGia);
            return cmd.ExecuteNonQuery();
        }

        public int Xoa(LoaiKhachHang info)
        {
            SqlCommand cmd = new SqlCommand("XoaLoaiKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaLoaiKhachHang", info.MaLoaiKhachHang);
            return cmd.ExecuteNonQuery();
        }
        public DataTable TimKiem(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachLoaiKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaLoaiKhachHang like '%{0}%' OR TenLoaiKhachHang like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);

            return dt;
        }
    }
}
