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
    class MatHangDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public MatHangDao()
        {
            provider.connect();
        }

        public DataTable DanhSachMatHang()
        {
            SqlCommand cmd = new SqlCommand("DanhSachMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public int Them(MatHang info)
        {
            SqlCommand cmd = new SqlCommand("ThemMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaMatHang", info.MaMatHang);
            cmd.Parameters.AddWithValue("@TenMatHang", info.TenMatHang);
            cmd.Parameters.AddWithValue("@NhaSanXuat", info.NhaSanXuat);
            cmd.Parameters.AddWithValue("@Hinh", info.Hinh);
            cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", info.ThoiGianBaoHanh);
            cmd.Parameters.AddWithValue("@SoLuong", info.SoLuong);
            cmd.Parameters.AddWithValue("@GiaNhap", info.GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", info.GiaBan);
            return cmd.ExecuteNonQuery();
        }

        public int CapNhat(MatHang info)
        {
            SqlCommand cmd = new SqlCommand("CapNhatMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaMatHang", info.MaMatHang);
            cmd.Parameters.AddWithValue("@TenMatHang", info.TenMatHang);
            cmd.Parameters.AddWithValue("@NhaSanXuat", info.NhaSanXuat);
            cmd.Parameters.AddWithValue("@Hinh", info.Hinh);
            cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", info.ThoiGianBaoHanh);
            cmd.Parameters.AddWithValue("@SoLuong", info.SoLuong);
            cmd.Parameters.AddWithValue("@GiaNhap", info.GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", info.GiaBan);
            return cmd.ExecuteNonQuery();
        }

        public void CapNhatSoLuongKhiNhap(int soluong, string mamh)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaMatHang", mamh));
            paramters.Add(new SqlParameter("@SoLuong",soluong));

            SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("CapNhatSoLuongKhiNhap", paramters);
            reader.Close();
        }

        public void CapNhatSoLuongKhiXuat(int soluong, string mamh)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaMatHang", mamh));
            paramters.Add(new SqlParameter("@SoLuong", soluong));

            SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("CapNhatSoLuongKhiXuat", paramters);
            reader.Close();
        }


        public int Xoa(MatHang info)
        {
            SqlCommand cmd = new SqlCommand("XoaMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaMatHang", info.MaMatHang);
            return cmd.ExecuteNonQuery();
        }

        public int  LaySoLuongMatHang(string mamh)
        {
            int soLuong;
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaMatHang", mamh));

            SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("LaySoLuongMatHang", paramters);
            reader.Read();
            soLuong = Int32.Parse(reader["SoLuong"].ToString());
            reader.Close();

            return soLuong;

        }

        public DataTable LayDanhSachMaMH()
        {
            SqlCommand cmd = new SqlCommand("LayMaMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachMatHang", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaMatHang like '%{0}%' OR TenMatHang like '%{0}%'  OR TenNhaSanXuat like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);

            return dt;
        }
    }
}
