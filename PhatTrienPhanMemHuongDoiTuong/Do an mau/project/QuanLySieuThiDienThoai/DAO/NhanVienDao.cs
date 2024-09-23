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
    class NhanVienDao : DataProvider
    {
        private DataProvider provider = new DataProvider();
        public NhanVienDao()
        {
            provider.connect();
        }
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand("DanhSachNhanVien", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public DataTable Search(string search)
        {
            SqlCommand cmd = new SqlCommand("DanhSachNhanVien", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            string str = "MaNhanVien like '%{0}%' OR TenNhanVien like '%{0}%'  OR CMND like '%{0}%' OR DiaChi like '%{0}%' OR SDT like '%{0}%'  OR TenDangNhap like '%{0}%'";
            dt.DefaultView.RowFilter = string.Format(str, search);

            return dt;
        }
        public int Insert(NhanVien info)
        {
            SqlCommand cmd = new SqlCommand("InsertNhanVien", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhanVien", info.MaNhanVien);
            cmd.Parameters.AddWithValue("@TenNhanVien", info.TenNhanVien);
            cmd.Parameters.AddWithValue("@NgaySinh", info.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", info.GioiTinh);
            cmd.Parameters.AddWithValue("@CMND", info.CMND);
            cmd.Parameters.AddWithValue("@DiaChi", info.DiaChi);
            cmd.Parameters.AddWithValue("@SDT", info.SDT);
            cmd.Parameters.AddWithValue("@Hinh", info.Hinh);
            cmd.Parameters.AddWithValue("@PhongBan", info.PhongBan);
            cmd.Parameters.AddWithValue("@TenDangNhap", info.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", info.MatKhau);
            return cmd.ExecuteNonQuery();
        }

        public int Update(NhanVien info)
        {
            SqlCommand cmd = new SqlCommand("UpdateNhanVien", connect());
            cmd.CommandType = CommandType.StoredProcedure;

            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhanVien", info.MaNhanVien);
            cmd.Parameters.AddWithValue("@TenNhanVien", info.TenNhanVien);
            cmd.Parameters.AddWithValue("@NgaySinh", info.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", info.GioiTinh);
            cmd.Parameters.AddWithValue("@CMND", info.CMND);
            cmd.Parameters.AddWithValue("@DiaChi", info.DiaChi);
            cmd.Parameters.AddWithValue("@SDT", info.SDT);
            cmd.Parameters.AddWithValue("@Hinh", info.Hinh);
            cmd.Parameters.AddWithValue("@PhongBan", info.PhongBan);
            cmd.Parameters.AddWithValue("@TenDangNhap", info.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", info.MatKhau);
            return cmd.ExecuteNonQuery();
        }
        public int Delete(NhanVien info)
        {
            SqlCommand cmd = new SqlCommand("DeleteNhanVien", connect());
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen tham so cho thu tuc
            cmd.Parameters.AddWithValue("@MaNhanVien", info.MaNhanVien);
            return cmd.ExecuteNonQuery();
        }
    }
}
