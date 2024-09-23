using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using QuanLySieuThiDienThoai.DTO;

namespace DAO
{
    class PhieuNhapDao
    {
            private DataProvider provider = new DataProvider();

            public PhieuNhapDao()
            {
                provider.connect();
            }
      
            #region "them"
            public void ThemPN(QuanLySieuThiDienThoai.DTO.PhieuNhap info)
            {
                List<SqlParameter> paramters = new List<SqlParameter>(); 
                paramters.Add(new SqlParameter("@MaPhieuNhap", info.MaPhieuNhap));
                paramters.Add(new SqlParameter("@MaNhanVien", info.MaNhanVien));
                paramters.Add(new SqlParameter("@NgayHoaDon", info.NgayHoaDon));

                SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("LuuPhieuNhap", paramters);
                reader.Close();
            }

            public void ThemCTPN(QuanLySieuThiDienThoai.DTO.CTPhieuNhap info)
            {
                List<SqlParameter> paramters = new List<SqlParameter>();
                paramters.Add(new SqlParameter("@MaPhieuNhap", info.MaPhieuNhap));
                paramters.Add(new SqlParameter("@MaMatHang", info.MaMatHang));
                paramters.Add(new SqlParameter("@SoLuong", info.SoLuong));
                paramters.Add(new SqlParameter("@MaNCC", info.MaNCC));

                SqlDataReader reader = (SqlDataReader)provider.executeQueryParameter("LuuCTPhieuNhap", paramters);
                reader.Close();
            }
            #endregion

            public string LayMaPhieuNhapMax()
            {
                SqlDataReader reader3 = (SqlDataReader)provider.executeQuery("LayMaPhieuNhapMax");
                reader3.Read();
                string ma = reader3["Maxi"].ToString();
                reader3.Close();

                return ma;
            }

   
        }
  }

