using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using QuanLySieuThiDienThoai.DTO;


namespace DAO
{
    class PhieuXuatDao
    {
            private DataProvider provider = new DataProvider();
            public PhieuXuatDao()
            {
                provider.connect();
            }
      
            #region "them"
            public void ThemPX(QuanLySieuThiDienThoai.DTO.PhieuXuat info)
            {
                List<SqlParameter> paramters = new List<SqlParameter>(); 
                paramters.Add(new SqlParameter("@MaPhieuXuat", info.MaPhieuXuat));
                paramters.Add(new SqlParameter("@MaKhachHang", info.MaKhachHang));
                paramters.Add(new SqlParameter("@MaNhanVien", info.MaNhanVien));
                paramters.Add(new SqlParameter("@NgayHoaDon", info.NgayHoaDon));

                SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("LuuPhieuXuat", paramters);
                reader.Close();
            }

            public void ThemCTPX(QuanLySieuThiDienThoai.DTO.CTPhieuXuat info)
            {
                List<SqlParameter> paramters = new List<SqlParameter>();
                paramters.Add(new SqlParameter("@MaPhieuXuat", info.MaPhieuXuat));
                paramters.Add(new SqlParameter("@MaMatHang", info.MaMatHang));
                paramters.Add(new SqlParameter("@SoLuong", info.SoLuong));

                SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("LuuCTPhieuXuat", paramters);
                reader.Close();
            }
            #endregion

            public string LayMaPhieuXuatMax()
            {
                SqlDataReader reader3 = (SqlDataReader)provider.executeQuery("LayMaPhieuXuatMax"); 
                reader3.Read();
                string ma = reader3["Maxi"].ToString();
                reader3.Close();

                return ma;
            }

   
    }
}
