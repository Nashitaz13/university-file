using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using QLNT.DataAccessLayer;
using QLNT.CommonLayer;
using QLNT.DataTransferObject;
using System.Data.SqlTypes;
using System.Windows.Forms;
using QLNT.DataTransferObject.MuaThuoc;

namespace QLNT.BusinessLogicLayer
{
    public class BllPhieuNhapThuoc
    {
        DalPhieuNhapThuoc dalPhieuNhapThuoc;
        DtoPhieuNhapThuoc dtoPhieuNhapThuoc;
        DalThuoc dalTonKho;

        public BllPhieuNhapThuoc()
        {
            dalPhieuNhapThuoc = new DalPhieuNhapThuoc();
            dtoPhieuNhapThuoc = new DtoPhieuNhapThuoc();
            dalTonKho = new DalThuoc();
        }

        /// <summary>
        /// Doc phieu nhap theo MaHoaDonNhap
        /// </summary>
        /// <param name="dtChiTietPhieuNhapThuoc">Doi tuong kieu DataTable de chua dung du lieu se duoc tra ve tu CSDL</param>
        /// <param name="maHoaDon">Ma hoa don nhap</param>
        public void DocPhieuNhapThuocTheoMaHD(DataTable dtPhieuNhapThuoc, int maHoaDon)
        {
            dalPhieuNhapThuoc.DocPhieuNhapThuocTheoMaHD(dtPhieuNhapThuoc, maHoaDon);
        }

        public DtoPhieuNhapThuoc DocPhieuNhapThuocTheoMaHD(int maHoaDon)
        {
            DataTable dtPhieuNhapThuoc = new DataTable();
            //DtoPhieuNhapThuoc dtoPhieuNhapThuoc = new DtoPhieuNhapThuoc();

            dalPhieuNhapThuoc.DocPhieuNhapThuocTheoMaHD(dtPhieuNhapThuoc, maHoaDon);
            if (dtPhieuNhapThuoc.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPhieuNhapThuoc.Rows)
                {
                    dtoPhieuNhapThuoc.MaHoaDonNhap = int.Parse(dr["MaHoaDonNhap"].ToString());
                    dtoPhieuNhapThuoc.MaNhaCungCap = int.Parse(dr["MaNhaCungCap"].ToString());
                    dtoPhieuNhapThuoc.MaHinhThucThanhToan = int.Parse(dr["MaHinhThucThanhToan"].ToString());
                    dtoPhieuNhapThuoc.MaNhanVien = int.Parse(dr["MaNhanVien"].ToString());
                    dtoPhieuNhapThuoc.SeriHoaDonNhap = dr["SeriHoaDonNhap"].ToString();                   
                    dtoPhieuNhapThuoc.NgayNhap = DateTime.Parse(dr["NgayNhap"].ToString());
                    dtoPhieuNhapThuoc.TongTienThuoc = decimal.Parse(dr["TongTienThuoc"].ToString());                 
                    dtoPhieuNhapThuoc.TienVAT = decimal.Parse(dr["TienVAT"].ToString());
                    dtoPhieuNhapThuoc.TongTienThuoc = decimal.Parse(dr["TongTienThuoc"].ToString());
                    dtoPhieuNhapThuoc.TongTienThanhToan = decimal.Parse(dr["TongTienThanhToan"].ToString());
                    dtoPhieuNhapThuoc.GhiChu = dr["GhiChu"].ToString();
                }
            }
            return dtoPhieuNhapThuoc;
        }

        /// <summary>
        /// Doc danh sach chi tiet phieu nhap theo MaHoaDonNhap
        /// </summary>
        /// <param name="dtChiTietPhieuNhapThuoc">Doi tuong kieu DataTable de chua dung du lieu se duoc tra ve tu CSDL</param>
        /// <param name="maHoaDon">Ma hoa don nhap</param>
        public void DocChiTietPhieuNhapThuocTheoMaHD(DataTable dtChiTietPhieuNhapThuoc, int maHoaDon)
        {
            dalPhieuNhapThuoc.DocChiTietPhieuNhapThuocTheoMaHD(dtChiTietPhieuNhapThuoc, maHoaDon);
        }

        public int LuuPhieuNhapThuoc(DtoPhieuNhapThuoc dtoPhieuNhapThuoc)
        {
            return dalPhieuNhapThuoc.LuuPhieuNhapThuoc(dtoPhieuNhapThuoc);
        }

        public decimal TinhTienThuoc(DataRow dr)
        {
            int soLuong = 0;
            decimal donGia = 0;
            decimal tienThuoc = 0;
            TypedDSPhieuNhapThuoc.tbChiTietHoaDonNhapRow drHienTai = (TypedDSPhieuNhapThuoc.tbChiTietHoaDonNhapRow)dr;

            soLuong = (drHienTai.IsSoLuongNull()) ? 0 : Convert.ToInt32(drHienTai.SoLuong);
            donGia = (drHienTai.IsDonGiaNull()) ? 0 : Convert.ToDecimal(drHienTai.DonGia);
            tienThuoc = soLuong * donGia;

            return tienThuoc;            
        }

        public void TinhTienVAT()
        {
            dtoPhieuNhapThuoc.TienVAT = dtoPhieuNhapThuoc.TongTienThuoc * 5 / 100;           
        }

        public void TinhTongThanhTien()
        {
            dtoPhieuNhapThuoc.TongTienThanhToan = dtoPhieuNhapThuoc.TongTienThuoc + dtoPhieuNhapThuoc.TienVAT;
        }

        public void TinhTongTienThuoc(DataTable dt)
        {
            decimal tongTienThuoc = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (TypedDSPhieuNhapThuoc.tbChiTietHoaDonNhapRow dr in (TypedDSPhieuNhapThuoc.tbChiTietHoaDonNhapDataTable)dt)
                {
                    tongTienThuoc += dr.IsThanhTienNull() ? 0 : (decimal)dr.ThanhTien;
                }
            }
            dtoPhieuNhapThuoc.TongTienThuoc = tongTienThuoc;           
        }

        //private void CapNhatLaiSoLuongDuocPhepXuat(DtoChiTietPhieuNhapThuoc dtoChiTietPhieuNhapThuoc)
        //{
        //    //Phai cap nhat lai So luong duoc phep xuat vi moi khi xuat hoa don thuoc thi SoLuongDuocPhepXuat se bi tru bot. 
        //    //Neu sua lai soluong thuoc trong hoa don nhap thi phai cap nhat lai SoLuongDuocPhepXuat. 
        //    int soLuongBanDau = dtoChiTietPhieuNhapThuoc.SoLuongBanDau;
        //    int soLuongMoi = dtoChiTietPhieuNhapThuoc.SoLuong;
        //    int soLuongDuocPhepXuatHienTai = dtoChiTietPhieuNhapThuoc.SoLuongDuocPhepXuat;

        //    int soLuongChenhLech = soLuongBanDau - soLuongMoi;
        //    int SoLuongDuocPhepXuatMoi = soLuongDuocPhepXuatHienTai - soLuongChenhLech;
        //    dtoChiTietPhieuNhapThuoc.SoLuongDuocPhepXuat = SoLuongDuocPhepXuatMoi;
        //}

        public void LuuChiTietPhieuNhapThuoc(DataTable dt)
        {
            try
            {
                // Tạo ra một TransactionScope để thực thi các lệnh trong một giao tác,
                // đảm bảo các lệnh này hoặc là được thực thi hết hoặc không lệnh nào được thực thi
                // như là một hành động không thể chia cắt
                using (TransactionScope scope = new TransactionScope())
                {
                    int SoMauTin = 0;
                    foreach (DataRow dRow in dt.Rows)
                    {
                        DtoChiTietPhieuNhapThuoc dtoChiTietPhieuNhapThuoc = new DtoChiTietPhieuNhapThuoc()
                        {
                            MaHoaDonNhap = (dRow["MaHoaDonNhap"] == DBNull.Value) ? 0 : (int)dRow["MaHoaDonNhap"],
                            MaThuoc = (dRow["MaThuoc"] == DBNull.Value) ? 0 : (int)dRow["MaThuoc"],
                            DonGia = (decimal)dRow["DonGia"],
                            NgayHetHan =(dRow["NgayHetHan"] == DBNull.Value) ? SqlDateTime.MinValue.Value : (DateTime)dRow["NgayHetHan"],
                            NgaySanXuat = (dRow["NgaySanXuat"] == DBNull.Value) ? SqlDateTime.MinValue.Value : (DateTime)dRow["NgaySanXuat"],                             
                            SoLo = dRow["SoLo"].ToString(),
                            SoLuong = (int)dRow["SoLuong"],
                            ThanhTien = (decimal)dRow["ThanhTien"],                            
                            SoLuongBanDau =(dRow["SoLuongBanDau"]==DBNull.Value)?0: (int)dRow["SoLuongBanDau"]
                        };

                        switch (dRow.RowState)
                        {
                            case DataRowState.Added:
                                SoMauTin += dalPhieuNhapThuoc.ThemChiTietPhieuNhap(dtoChiTietPhieuNhapThuoc);
                                
                                //Them moi thuoc thi SoLuongTon += SoLuong vua nhap vao
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuNhapThuoc.MaThuoc, dtoChiTietPhieuNhapThuoc.SoLuong);
                                break;

                            case DataRowState.Modified:  
                                SoMauTin += dalPhieuNhapThuoc.SuaChiTietPhieuNhap(dtoChiTietPhieuNhapThuoc);

                                //Cap nhat ton kho thuoc tang hoac giam so voi ban dau.
                                int soLuongBanDau = dtoChiTietPhieuNhapThuoc.SoLuongBanDau;
                                int soLuongMoi = dtoChiTietPhieuNhapThuoc.SoLuong;
                                int soLuongCanCapNhat = soLuongMoi - soLuongBanDau;
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuNhapThuoc.MaThuoc, soLuongCanCapNhat);

                                break;

                            case DataRowState.Deleted:
                                int maHoaDonNhap = (int)dRow["MaHoaDonNhap", DataRowVersion.Original];
                                int maThuoc = (int)dRow["MaThuoc", DataRowVersion.Original];
                                int SoLuong = (int)dRow["SoLuong", DataRowVersion.Original];

                                dalPhieuNhapThuoc.XoaChiTietPhieuNhap(maHoaDonNhap, maThuoc);
                                //Xoa thuoc thi SoLuongTon -= SoLuong vua nhap vao
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuNhapThuoc.MaThuoc, -SoLuong);
                                break;
                        }
                    }

                    // Nếu các lệnh trong giao tác thực hiện thành công hết thì phương thức Complete sẽ được gọi
                    // để triển khai ghi nhận kết quả của các lệnh trong giao tác. Nếu phương thức này không được gọi thì
                    // kết quả của các lệnh trong gia tác bị hủy để trở về trạng thái trước khi thực hiện giao tác
                    dt.AcceptChanges();
                    scope.Complete();
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (TransactionAbortedException)
            {
                throw new ArgumentException(Constants.MsgExceptionLuuLoi);
            }
            catch (ApplicationException)
            {
                throw new ArgumentException(Constants.MsgExceptionLoiChung);
            }

        }
    }
}
