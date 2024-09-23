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
    public class DalPhieuXuatThuoc
    {
        public void DocPhieuXuatThuocTheoMaHD(DataTable dtPhieuXuatThuoc, int maHoaDon)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaHoaDonXuat", maHoaDon) };
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocHoaDonXuatTheoMaHD", dtPhieuXuatThuoc, parameters);
            }
            catch (Exception)
            {                
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public void DocChiTietPhieuXuatThuocTheoMaHD(DataTable dtChiTietPhieuXuatThuoc, int maHoaDon)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaHoaDonXuat", maHoaDon) };
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocChiTietHoaDonXuatTheoMaHD", dtChiTietPhieuXuatThuoc, parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public int LuuPhieuXuatThuoc(DtoPhieuXuatThuoc dtoPhieuXuatThuoc)
        {
            try
            {
                SqlParameter sqlpMaPhieuXuatThuoc = new SqlParameter("@MaHoaDonXuat", dtoPhieuXuatThuoc.MaHoaDonXuat);
                sqlpMaPhieuXuatThuoc.Direction = ParameterDirection.InputOutput;

                SqlParameter[] parameters = {
                    sqlpMaPhieuXuatThuoc,
                    new SqlParameter( "@MaNguoiGhiPhieu",dtoPhieuXuatThuoc.MaNguoiGhiPhieu),
                    new SqlParameter( "@MaNguoiPhatThuoc",dtoPhieuXuatThuoc.MaNguoiPhatThuoc),
                    new SqlParameter( "@SeriHoaDonXuat",dtoPhieuXuatThuoc.SeriHoaDonXuat),
                    new SqlParameter( "@ThongTinBenhNhan",dtoPhieuXuatThuoc.ThongTinBenhNhan),
                    new SqlParameter( "@NgayXuat",dtoPhieuXuatThuoc.NgayXuat),
                    new SqlParameter( "@TongTienThuoc",dtoPhieuXuatThuoc.TongTienThuoc),
                    new SqlParameter( "@TongTienVAT",dtoPhieuXuatThuoc.TongTienVAT),
                    new SqlParameter( "@TongTienThanhToan",dtoPhieuXuatThuoc.TongTienThanhToan)                    
                };

                int rowCount = Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "LuuHoaDonXuat", parameters));
                if (sqlpMaPhieuXuatThuoc.Value != null)
                {
                    return Convert.ToInt32(sqlpMaPhieuXuatThuoc.Value);
                }
                return 0;
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionTonTaiMauTin);
            }
            catch (Exception)
            {
                //throw e;
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public int ThemChiTietPhieuXuat(DtoChiTietPhieuXuatThuoc dtoChiTietPhieuXuatThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaHoaDonXuat",dtoChiTietPhieuXuatThuoc.MaHoaDonXuat),
	                new SqlParameter("@MaThuoc",dtoChiTietPhieuXuatThuoc.MaThuoc),                   
	                new SqlParameter("@SoLuong",dtoChiTietPhieuXuatThuoc.SoLuong),
                    new SqlParameter("@DonGiaXuat",dtoChiTietPhieuXuatThuoc.DonGiaXuat),                   
                    new SqlParameter("@ThanhTien",dtoChiTietPhieuXuatThuoc.ThanhTien)
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "ThemChiTietHoaDonXuat", parameters));
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

        public int SuaChiTietPhieuXuat(DtoChiTietPhieuXuatThuoc dtoChiTietPhieuXuatThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaHoaDonXuat",dtoChiTietPhieuXuatThuoc.MaHoaDonXuat),
	                new SqlParameter("@MaThuoc",dtoChiTietPhieuXuatThuoc.MaThuoc),                   
	                new SqlParameter("@SoLuong",dtoChiTietPhieuXuatThuoc.SoLuong),
                    new SqlParameter("@DonGiaXuat",dtoChiTietPhieuXuatThuoc.DonGiaXuat),                 
                    new SqlParameter("@ThanhTien",dtoChiTietPhieuXuatThuoc.ThanhTien)
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "SuaChiTietHoaDonXuat", parameters));
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

        public void XoaChiTietPhieuXuat(int maHoaDonXuat, int maThuoc)
        {
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@MaHoaDonXuat", maHoaDonXuat),
                                                new SqlParameter("@MaThuoc", maThuoc)
                                            };
                SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "XoaChiTietHoaDonXuat", parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }


    }
}
