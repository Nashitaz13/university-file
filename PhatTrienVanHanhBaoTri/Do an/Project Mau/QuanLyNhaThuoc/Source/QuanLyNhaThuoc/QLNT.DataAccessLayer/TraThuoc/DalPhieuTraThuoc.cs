using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using QLNT.DataTransferObject;
using QLNT.CommonLayer;


namespace QLNT.DataAccessLayer
{

    public class DalPhieuTraThuoc
    {
        public DalPhieuTraThuoc()
        {
        }

        public void DocPhieuTraThuocTheoMaHD(DataTable dtPhieuTraThuoc, int maHoaDon)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaPhieuTraThuoc", maHoaDon) };
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocPhieuTraThuocTheoMaHD", dtPhieuTraThuoc, parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public void DocChiTietPhieuTraThuocTheoMaHD(DataTable dtChiTietPhieuTraThuoc, int maHoaDon)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaPhieuTraThuoc", maHoaDon) };
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocChiTietPhieuTraThuocTheoMaHD", dtChiTietPhieuTraThuoc, parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public int LuuPhieuTraThuoc(DtoPhieuTraThuoc dtoPhieuTraThuoc)
        {
            try
            {
                SqlParameter sqlpMaPhieuTraThuoc = new SqlParameter("@MaPhieuTraThuoc", dtoPhieuTraThuoc.MaPhieuTraThuoc);
                sqlpMaPhieuTraThuoc.Direction = ParameterDirection.InputOutput;

                SqlParameter[] parameters = {
                    sqlpMaPhieuTraThuoc,                   
                    new SqlParameter( "@MaHoaDonXuat",dtoPhieuTraThuoc.MaHoaDonXuat),
                    new SqlParameter( "@SeriHoaDonTra",dtoPhieuTraThuoc.SeriHoaDonTra),
                    new SqlParameter( "@MaNguoiGhiPhieu",dtoPhieuTraThuoc.MaNguoiGhiPhieu),
                    new SqlParameter( "@MaNguoiNhanThuoc",dtoPhieuTraThuoc.MaNguoiNhanThuoc),
                    new SqlParameter( "@NgayTraThuoc",dtoPhieuTraThuoc.NgayTraThuoc),
                    new SqlParameter( "@LyDo",dtoPhieuTraThuoc.LyDo),
                    new SqlParameter( "@TongTienPhaiTra",dtoPhieuTraThuoc.TongTienPhaiTra)                    
                };

                int rowCount = Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "LuuPhieuTraThuoc", parameters));
                if (sqlpMaPhieuTraThuoc.Value != null)
                {
                    return Convert.ToInt32(sqlpMaPhieuTraThuoc.Value);
                }
                return 0;
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionTonTaiMauTin);
            }
            catch (Exception)
            {
                //throw ex;
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public int ThemChiTietPhieuTra(DtoChiTietPhieuTraThuoc dtoChiTietPhieuTraThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhieuTraThuoc",dtoChiTietPhieuTraThuoc.MaPhieuTraThuoc),
	                new SqlParameter("@MaThuoc",dtoChiTietPhieuTraThuoc.MaThuoc),                   
	                new SqlParameter("@SoLuongBanDau",dtoChiTietPhieuTraThuoc.SoLuongBanDau),
                    new SqlParameter("@SoLuongTra",dtoChiTietPhieuTraThuoc.SoLuongTra),                   
                    new SqlParameter("@DonGiaXuat",dtoChiTietPhieuTraThuoc.DonGiaXuat),
                    new SqlParameter("@ThanhTien",dtoChiTietPhieuTraThuoc.ThanhTien)
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "ThemChiTietPhieuTraThuoc", parameters));
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionTonTaiMauTin);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }

        }

        public int SuaChiTietPhieuTra(DtoChiTietPhieuTraThuoc dtoChiTietPhieuTraThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhieuTraThuoc",dtoChiTietPhieuTraThuoc.MaPhieuTraThuoc),
	                new SqlParameter("@MaThuoc",dtoChiTietPhieuTraThuoc.MaThuoc),                   
	                new SqlParameter("@SoLuongBanDau",dtoChiTietPhieuTraThuoc.SoLuongBanDau),
                    new SqlParameter("@SoLuongTra",dtoChiTietPhieuTraThuoc.SoLuongTra),                   
                    new SqlParameter("@DonGiaXuat",dtoChiTietPhieuTraThuoc.DonGiaXuat),
                    new SqlParameter("@ThanhTien",dtoChiTietPhieuTraThuoc.ThanhTien)
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "SuaChiTietPhieuTraThuoc", parameters));
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionTonTaiMauTin);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }

        }

        public void XoaChiTietPhieuTra(int maPhieuTraThuoc, int maThuoc)
        {
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@MaPhieuTraThuoc", maPhieuTraThuoc),
                                                new SqlParameter("@MaThuoc", maThuoc)
                                            };
                SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "XoaChiTietPhieuTraThuoc", parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }


    }
}
