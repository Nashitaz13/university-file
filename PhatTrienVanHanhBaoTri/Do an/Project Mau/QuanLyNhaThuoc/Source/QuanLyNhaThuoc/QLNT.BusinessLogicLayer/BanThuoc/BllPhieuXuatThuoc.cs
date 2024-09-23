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

namespace QLNT.BusinessLogicLayer
{
    public class BllPhieuXuatThuoc
    {
        DalPhieuXuatThuoc dalPhieuXuatThuoc;
        DtoPhieuXuatThuoc dtoPhieuXuatThuoc;
        DalThuoc dalTonKho;

        public BllPhieuXuatThuoc()
        {
            dalPhieuXuatThuoc = new DalPhieuXuatThuoc();
            dtoPhieuXuatThuoc = new DtoPhieuXuatThuoc();
            dalTonKho = new DalThuoc();
        }
              
        public void DocPhieuXuatThuocTheoMaHD(DataTable dtPhieuXuatThuoc, int maHoaDon)
        {
            dalPhieuXuatThuoc.DocPhieuXuatThuocTheoMaHD(dtPhieuXuatThuoc, maHoaDon);
        }

        public DtoPhieuXuatThuoc DocPhieuXuatThuocTheoMaHD(int maHoaDon)
        {
            DataTable dtPhieuXuatThuoc = new DataTable();          

            dalPhieuXuatThuoc.DocPhieuXuatThuocTheoMaHD(dtPhieuXuatThuoc, maHoaDon);
            if (dtPhieuXuatThuoc.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPhieuXuatThuoc.Rows)
                {
                    dtoPhieuXuatThuoc.MaHoaDonXuat = int.Parse(dr["MaHoaDonXuat"].ToString());
                    dtoPhieuXuatThuoc.MaNguoiGhiPhieu = int.Parse(dr["MaNguoiGhiPhieu"].ToString());
                    dtoPhieuXuatThuoc.MaNguoiPhatThuoc = int.Parse(dr["MaNguoiPhatThuoc"].ToString());                    
                    dtoPhieuXuatThuoc.SeriHoaDonXuat = dr["SeriHoaDonXuat"].ToString();
                    dtoPhieuXuatThuoc.ThongTinBenhNhan = dr["ThongTinBenhNhan"].ToString();
                    dtoPhieuXuatThuoc.NgayXuat = DateTime.Parse(dr["NgayXuat"].ToString());
                    dtoPhieuXuatThuoc.TongTienThuoc = long.Parse(dr["TongTienThuoc"].ToString());
                    dtoPhieuXuatThuoc.TongTienVAT = long.Parse(dr["TongTienVAT"].ToString());
                    dtoPhieuXuatThuoc.TongTienThuoc = long.Parse(dr["TongTienThuoc"].ToString());
                    dtoPhieuXuatThuoc.TongTienThanhToan = long.Parse(dr["TongTienThanhToan"].ToString());
                   
                }
            }
            return dtoPhieuXuatThuoc;
        }
              
        public void DocChiTietPhieuXuatThuocTheoMaHD(DataTable dtChiTietPhieuXuatThuoc, int maHoaDon)
        {
            dalPhieuXuatThuoc.DocChiTietPhieuXuatThuocTheoMaHD(dtChiTietPhieuXuatThuoc, maHoaDon);
        }

        public int LuuPhieuXuatThuoc(DtoPhieuXuatThuoc dtoPhieuXuatThuoc)
        {
            return dalPhieuXuatThuoc.LuuPhieuXuatThuoc(dtoPhieuXuatThuoc);
        }

        public decimal TinhTienThuoc(DataRow dr)
        {
            int soLuong = 0;
            decimal donGia = 0;
            decimal tienThuoc = 0;
            TypedDSPhieuXuatThuoc.tbChiTietHoaDonXuatRow drHienTai = (TypedDSPhieuXuatThuoc.tbChiTietHoaDonXuatRow)dr;

            soLuong = (drHienTai.IsSoLuongNull()) ? 0 : Convert.ToInt32(drHienTai.SoLuong);
            donGia = (drHienTai.IsDonGiaXuatNull()) ? 0 : Convert.ToDecimal(drHienTai.DonGiaXuat);
            tienThuoc = soLuong * donGia;

            return tienThuoc;
        }

        public void TinhTienVAT()
        {
            dtoPhieuXuatThuoc.TongTienVAT = dtoPhieuXuatThuoc.TongTienThuoc * 5 / 100;            
        }

        public void TinhTongThanhTien()
        {
            dtoPhieuXuatThuoc.TongTienThanhToan = dtoPhieuXuatThuoc.TongTienThuoc + dtoPhieuXuatThuoc.TongTienVAT;
        }

        public void TinhTongTienThuoc(DataTable dt)
        {
            long tongTienThuoc = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (TypedDSPhieuXuatThuoc.tbChiTietHoaDonXuatRow dr in (TypedDSPhieuXuatThuoc.tbChiTietHoaDonXuatDataTable)dt)
                {
                    tongTienThuoc += dr.IsThanhTienNull() ? 0 : (long)dr.ThanhTien;
                }
            }
            dtoPhieuXuatThuoc.TongTienThuoc = tongTienThuoc;           
        }
        
        public void LuuChiTietPhieuXuatThuoc(DataTable dt)
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
                        DtoChiTietPhieuXuatThuoc dtoChiTietPhieuXuatThuoc = new DtoChiTietPhieuXuatThuoc()
                        {
                            MaHoaDonXuat = (dRow["MaHoaDonXuat"] == DBNull.Value) ? 0 : (int)dRow["MaHoaDonXuat"],
                            MaThuoc = (dRow["MaThuoc"] == DBNull.Value) ? 0 : (int)dRow["MaThuoc"],
                            DonGiaXuat = (int)dRow["DonGiaXuat"],                                               
                            SoLuong = (int)dRow["SoLuong"],
                            ThanhTien = (long)dRow["ThanhTien"],
                            SoLuongBanDau =(dRow["SoLuongBanDau"]==DBNull.Value)?0: (int)dRow["SoLuongBanDau"]
                        };

                        switch (dRow.RowState)
                        {
                            case DataRowState.Added:
                                SoMauTin += dalPhieuXuatThuoc.ThemChiTietPhieuXuat(dtoChiTietPhieuXuatThuoc);
                                //Xuat moi thuoc thi SoLuongTon -= SoLuong vua nhap vao
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuXuatThuoc.MaThuoc, -dtoChiTietPhieuXuatThuoc.SoLuong);
                                break;

                            case DataRowState.Modified:
                                SoMauTin += dalPhieuXuatThuoc.SuaChiTietPhieuXuat(dtoChiTietPhieuXuatThuoc);
                                //Cap nhat ton kho thuoc tang hoac giam so voi ban dau.
                                int soLuongBanDau = dtoChiTietPhieuXuatThuoc.SoLuongBanDau;
                                int soLuongMoi = dtoChiTietPhieuXuatThuoc.SoLuong;
                                int soLuongCanCapNhat = soLuongBanDau - soLuongMoi ;
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuXuatThuoc.MaThuoc, soLuongCanCapNhat);
                                break;

                            case DataRowState.Deleted:
                                int maHoaDonXuat = (int)dRow["MaHoaDonXuat", DataRowVersion.Original];
                                int maThuoc = (int)dRow["MaThuoc", DataRowVersion.Original];
                                int SoLuong = (int)dRow["SoLuong", DataRowVersion.Original];

                                dalPhieuXuatThuoc.XoaChiTietPhieuXuat(maHoaDonXuat, maThuoc);
                                //Xoa thuoc thi SoLuongTon -= SoLuong vua nhap vao
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuXuatThuoc.MaThuoc, -SoLuong);
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
