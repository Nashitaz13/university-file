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
    public class DalPhieuNhapThuoc
    {
        public DalPhieuNhapThuoc()
        {
        }

        /// <summary>
        /// Doc phieu nhap theo MaHoaDonNhap
        /// </summary>
        /// <param name="dtChiTietPhieuNhapThuoc">Doi tuong kieu DataTable de chua dung du lieu se duoc tra ve tu CSDL</param>
        /// <param name="maHoaDon">Ma hoa don nhap</param>
        public void DocPhieuNhapThuocTheoMaHD(DataTable dtPhieuNhapThuoc, int maHoaDon)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaHoaDonNhap", maHoaDon) };
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocHoaDonNhapTheoMaHD", dtPhieuNhapThuoc, parameters);
            }
            catch (Exception)
            {
                //throw ex;
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        /// <summary>
        /// Doc danh sach chi tiet phieu nhap theo MaHoaDonNhap
        /// </summary>
        /// <param name="dtChiTietPhieuNhapThuoc">Doi tuong kieu DataTable de chua dung du lieu se duoc tra ve tu CSDL</param>
        /// <param name="maHoaDon">Ma hoa don nhap</param>
        public void DocChiTietPhieuNhapThuocTheoMaHD(DataTable dtChiTietPhieuNhapThuoc, int maHoaDon)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@MaHoaDonNhap", maHoaDon) };
                SqlHelper.FillDataTable(Constants.ConnectionString, "DocChiTietHoaDonNhapTheoMaHD", dtChiTietPhieuNhapThuoc, parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public int LuuPhieuNhapThuoc(DtoPhieuNhapThuoc dtoPhieuNhapThuoc)
        {
            try
            {
                    SqlParameter sqlpMaPhieuNhapThuoc = new SqlParameter("@MaHoaDonNhap", dtoPhieuNhapThuoc.MaHoaDonNhap);
                    sqlpMaPhieuNhapThuoc.Direction = ParameterDirection.InputOutput;
                
                SqlParameter[] parameters = {
                    sqlpMaPhieuNhapThuoc,
                    new SqlParameter( "@MaHinhThucThanhToan",dtoPhieuNhapThuoc.MaHinhThucThanhToan),
                    new SqlParameter( "@MaNhaCungCap",dtoPhieuNhapThuoc.MaNhaCungCap),
                    new SqlParameter( "@MaNhanVien",dtoPhieuNhapThuoc.MaNhanVien),
                    new SqlParameter( "@SeriHoaDonNhap",dtoPhieuNhapThuoc.SeriHoaDonNhap),                   
                    new SqlParameter( "@NgayNhap",dtoPhieuNhapThuoc.NgayNhap),
                    new SqlParameter( "@TongTienThuoc",dtoPhieuNhapThuoc.TongTienThuoc),                    
                    new SqlParameter( "@TienVAT",dtoPhieuNhapThuoc.TienVAT),
                    new SqlParameter( "@TongTienThanhToan",dtoPhieuNhapThuoc.TongTienThanhToan),
                    new SqlParameter( "@GhiChu",dtoPhieuNhapThuoc.GhiChu)
                };

                int rowCount = Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "LuuHoaDonNhap", parameters));
                if (sqlpMaPhieuNhapThuoc.Value != null)
                {
                    return Convert.ToInt32(sqlpMaPhieuNhapThuoc.Value);
                }
                return 0;
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionTonTaiMauTin);
            }
            catch (Exception )
            {
                //throw e;
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }

        public int ThemChiTietPhieuNhap(DtoChiTietPhieuNhapThuoc dtoChiTietPhieuNhapThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaHoaDonNhap",dtoChiTietPhieuNhapThuoc.MaHoaDonNhap),
	                new SqlParameter("@MaThuoc",dtoChiTietPhieuNhapThuoc.MaThuoc),
                    new SqlParameter("@SoLo",dtoChiTietPhieuNhapThuoc.SoLo),
                    new SqlParameter("@NgaySanXuat",dtoChiTietPhieuNhapThuoc.NgaySanXuat),
                    new SqlParameter("@NgayHetHan",dtoChiTietPhieuNhapThuoc.NgayHetHan),
	                new SqlParameter("@SoLuong",dtoChiTietPhieuNhapThuoc.SoLuong),
                    new SqlParameter("@DonGia",dtoChiTietPhieuNhapThuoc.DonGia),
                    new SqlParameter("@ThanhTien",dtoChiTietPhieuNhapThuoc.ThanhTien)
                   
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "ThemChiTietHoaDonNhap", parameters));
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

        public int SuaChiTietPhieuNhap(DtoChiTietPhieuNhapThuoc dtoChiTietPhieuNhapThuoc)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@MaHoaDonNhap",dtoChiTietPhieuNhapThuoc.MaHoaDonNhap),
	                new SqlParameter("@MaThuoc",dtoChiTietPhieuNhapThuoc.MaThuoc),
                    new SqlParameter("@SoLo",dtoChiTietPhieuNhapThuoc.SoLo),
                    new SqlParameter("@NgaySanXuat",dtoChiTietPhieuNhapThuoc.NgaySanXuat),
                    new SqlParameter("@NgayHetHan",dtoChiTietPhieuNhapThuoc.NgayHetHan),
	                new SqlParameter("@SoLuong",dtoChiTietPhieuNhapThuoc.SoLuong),
                    new SqlParameter("@DonGia",dtoChiTietPhieuNhapThuoc.DonGia),
                    new SqlParameter("@ThanhTien",dtoChiTietPhieuNhapThuoc.ThanhTien)
                    
                };
                return Convert.ToInt32(SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "SuaChiTietHoaDonNhap", parameters));
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

        public void XoaChiTietPhieuNhap(int maHoaDonNhap, int maThuoc)
        {
            try
            {
                SqlParameter[] parameters = { 
                                                new SqlParameter("@MaHoaDonNhap", maHoaDonNhap),
                                                new SqlParameter("@MaThuoc", maThuoc)
                                            };
                SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "XoaChiTietHoaDonNhap", parameters);
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.MsgExceptionTruyCapLoi);
            }
        }
    }
}
