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
    class KhachHangDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public KhachHangDao()
        {
            provider.connect();
        }

        public DataTable DanhSachKhachHang()
        {
            SqlCommand cmd = new SqlCommand("DanhSachKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }


        public int Them(KhachHang info)
        {
            SqlCommand cmd = new SqlCommand("ThemKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaKhachHang", info.MaKhachHang);
            cmd.Parameters.AddWithValue("@TenKhachHang", info.TenKhachHang);
            cmd.Parameters.AddWithValue("@NgaySinh", info.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", info.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", info.SoDienThoai);
            cmd.Parameters.AddWithValue("Email", info.Email);
            cmd.Parameters.AddWithValue("@LoaiKhachHang", info.LoaiKhachHang);

            return cmd.ExecuteNonQuery();
        }

        public int CapNhat(KhachHang info)
        {
            SqlCommand cmd = new SqlCommand("CapNhatKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaKhachHang", info.MaKhachHang);
            cmd.Parameters.AddWithValue("@TenKhachHang", info.TenKhachHang);
            cmd.Parameters.AddWithValue("@NgaySinh", info.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", info.DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", info.SoDienThoai);
            cmd.Parameters.AddWithValue("Email", info.Email);
            cmd.Parameters.AddWithValue("@LoaiKhachHang", info.LoaiKhachHang);
            return cmd.ExecuteNonQuery();
        }

        public int Xoa(KhachHang info)
        {
            SqlCommand cmd = new SqlCommand("XoaKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaKhachHang", info.MaKhachHang);
            return cmd.ExecuteNonQuery();
        }

        public DataTable LayDanhSachMaKH()
        {
            SqlCommand cmd = new SqlCommand("LayMaKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachKhachHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaKhachHang like '%{0}%' OR TenKhachHang like '%{0}%' OR DiaChi like '%{0}%' OR SoDienThoai like '%{0}%'  OR Email like '%{0}%' OR TenLoaiKhachHang like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);
            return dt;
              
        }
    }
}
