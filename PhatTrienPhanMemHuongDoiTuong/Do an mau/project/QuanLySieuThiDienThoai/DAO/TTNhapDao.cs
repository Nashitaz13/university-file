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
    class TTNhapDao
    {
        private DataProvider provider = new DataProvider();
        public TTNhapDao()
        {
            provider.connect();
        }
        public List<TTNhap> layTTNhap()
        {
            SqlDataReader reader = (SqlDataReader)provider.executeQuery("LayThongTinPhieuNhap");
            List<TTNhap> List_TTNhap = new List<TTNhap>();
            while (reader.Read())
            {
                TTNhap ttNhap = new TTNhap();
                ttNhap.MaPhieuNhap = reader["MaPhieuNhap"].ToString();
                ttNhap.TenNhanVien = reader["TenNhanVien"].ToString();
                ttNhap.NgayHoaDon = reader["NgayHoaDon"].ToString();
                List_TTNhap.Add(ttNhap);
            }
            reader.Close();
            return List_TTNhap;
        }
    }
}
