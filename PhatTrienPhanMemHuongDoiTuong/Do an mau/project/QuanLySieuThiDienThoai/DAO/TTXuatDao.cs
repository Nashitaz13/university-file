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
    class TTXuatDao
    {
         private DataProvider provider = new DataProvider();
        public TTXuatDao()
        {
            provider.connect();
        }
        public List<TTXuat> layTTXuat()
        {
            SqlDataReader reader = (SqlDataReader)provider.executeQuery("LayThongTinPhieuXuat");
            List<TTXuat> List_TTXuat = new List<TTXuat>();
            while (reader.Read())
            {
                TTXuat ttXuat = new TTXuat();
                ttXuat.MaPhieuXuat = reader["MaPhieuXuat"].ToString();
                ttXuat.MaNhanVien = reader["MaNhanVien"].ToString();
                ttXuat.TenKhachHang = reader["TenKhachHang"].ToString();
                ttXuat.SoDienThoai = reader["SoDienThoai"].ToString();
                ttXuat.DiaChi = reader["DiaChi"].ToString();
                ttXuat.NgayHoaDon = reader["NgayHoaDon"].ToString();

                List_TTXuat.Add(ttXuat);
            }
            reader.Close();
            return List_TTXuat;
        }
    }
}
