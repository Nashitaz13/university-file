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
using QLNT.DataTransferObject.TraThuoc;

namespace QLNT.BusinessLogicLayer
{
    public class BllPhieuTraThuoc
    {
        DalPhieuTraThuoc dalPhieuTraThuoc;
        DtoPhieuTraThuoc dtoPhieuTraThuoc;
        DalThuoc dalTonKho;

        public BllPhieuTraThuoc()
        {
            dalPhieuTraThuoc = new DalPhieuTraThuoc();
            dtoPhieuTraThuoc = new DtoPhieuTraThuoc();
            dalTonKho = new DalThuoc();
        }

        public void DocPhieuTraThuocTheoMaHD(DataTable dtPhieuTraThuoc, int maHoaDon)
        {
            dalPhieuTraThuoc.DocPhieuTraThuocTheoMaHD(dtPhieuTraThuoc, maHoaDon);
        }

        public DtoPhieuTraThuoc DocPhieuTraThuocTheoMaHD(int maHoaDon)
        {
            DataTable dtPhieuTraThuoc = new DataTable();

            dalPhieuTraThuoc.DocPhieuTraThuocTheoMaHD(dtPhieuTraThuoc, maHoaDon);
            if (dtPhieuTraThuoc.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPhieuTraThuoc.Rows)
                {
                    dtoPhieuTraThuoc.MaPhieuTraThuoc = int.Parse(dr["MaPhieuTraThuoc"].ToString());
                    dtoPhieuTraThuoc.MaHoaDonXuat = int.Parse(dr["MaHoaDonXuat"].ToString());
                    dtoPhieuTraThuoc.SeriHoaDonTra = dr["SeriHoaDonTra"].ToString();
                    dtoPhieuTraThuoc.MaNguoiGhiPhieu = int.Parse(dr["MaNguoiGhiPhieu"].ToString());
                    dtoPhieuTraThuoc.MaNguoiNhanThuoc = int.Parse(dr["MaNguoiNhanThuoc"].ToString());
                    dtoPhieuTraThuoc.NgayTraThuoc = DateTime.Parse(dr["NgayTraThuoc"].ToString());
                    dtoPhieuTraThuoc.LyDo = dr["LyDo"].ToString();
                    dtoPhieuTraThuoc.TongTienPhaiTra = long.Parse(dr["TongTienPhaiTra"].ToString());

                }
            }
            return dtoPhieuTraThuoc;
        }

        public void DocChiTietPhieuTraThuocTheoMaHD(DataTable dtChiTietPhieuTraThuoc, int maHoaDon)
        {
            dalPhieuTraThuoc.DocChiTietPhieuTraThuocTheoMaHD(dtChiTietPhieuTraThuoc, maHoaDon);
        }

        public int LuuPhieuTraThuoc(DtoPhieuTraThuoc dtoPhieuTraThuoc)
        {
            return dalPhieuTraThuoc.LuuPhieuTraThuoc(dtoPhieuTraThuoc);
        }

        private void CapNhatLaiSoLuongDuocPhepXuat(int soLuong)
        {
            //TO DO

            //Ham nay se cap nhat lai so luong duoc phep xuat cua thuoc trong hoa don nhap. 
            //Co the cung mot loai thuoc duoc nhap nhieu lan trong thang. Luc do, ham nay se cap nhat lai so luong duoc phep xuat cua 
            //thuoc nao co ngay het han su dung truoc se xuat truoc.
            //Field SoLuongDuocPhep xuat trong phieu nhap giu phai tro nhu so luong ton kho cua tung thuoc. 
            //Thong tin nay dung lam gia tri lap cac bao cao ton kho.
        }

        public void LuuChiTietPhieuTraThuoc(DataTable dt)
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
                        DtoChiTietPhieuTraThuoc dtoChiTietPhieuTraThuoc = new DtoChiTietPhieuTraThuoc()
                        {
                            MaPhieuTraThuoc = (dRow["MaPhieuTraThuoc"] == DBNull.Value) ? 0 : (int)dRow["MaPhieuTraThuoc"],
                            MaThuoc = (dRow["MaThuoc"] == DBNull.Value) ? 0 : (int)dRow["MaThuoc"],
                            SoLuongXuatBanDau = (int)dRow["SoLuongXuatBanDau"],
                            SoLuongTra = (int)dRow["SoLuongTra"],
                            DonGiaXuat = (int)dRow["DonGiaXuat"],
                            ThanhTien = (long)dRow["ThanhTien"],
                            SoLuongBanDau = (int)dRow["SoLuongBanDau"]
                        };

                        switch (dRow.RowState)
                        {
                            case DataRowState.Added:
                                SoMauTin += dalPhieuTraThuoc.ThemChiTietPhieuTra(dtoChiTietPhieuTraThuoc);
                                //Them moi thuoc thi SoLuongTon += SoLuong vua nhap vao
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuTraThuoc.MaThuoc, dtoChiTietPhieuTraThuoc.SoLuongTra);
                                break;

                            case DataRowState.Modified:
                                SoMauTin += dalPhieuTraThuoc.SuaChiTietPhieuTra(dtoChiTietPhieuTraThuoc);
                                //Cap nhat ton kho thuoc tang hoac giam so voi ban dau.
                                int soLuongBanDau = dtoChiTietPhieuTraThuoc.SoLuongBanDau;
                                int soLuongMoi = dtoChiTietPhieuTraThuoc.SoLuongTra;
                                int soLuongCanCapNhat = soLuongMoi - soLuongBanDau;
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuTraThuoc.MaThuoc, soLuongCanCapNhat);
                                break;

                            case DataRowState.Deleted:
                                int maHoaDonTra = (int)dRow["MaPhieuTraThuoc", DataRowVersion.Original];
                                int maThuoc = (int)dRow["MaThuoc", DataRowVersion.Original];
                                int SoLuong = (int)dRow["SoLuongTra", DataRowVersion.Original];
                                dalPhieuTraThuoc.XoaChiTietPhieuTra(maHoaDonTra, maThuoc);
                                //Xoa thuoc thi SoLuongTon -= SoLuong vua nhap vao
                                dalTonKho.CapNhatTonKho(dtoChiTietPhieuTraThuoc.MaThuoc, -SoLuong);
                                break;
                        }

                        CapNhatLaiSoLuongDuocPhepXuat(dtoChiTietPhieuTraThuoc.SoLuongTra);
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

        public decimal TinhTienThuoc(DataRow dr)
        {
            int soLuongTra = 0;
            decimal donGia = 0;
            decimal tienThuoc = 0;
            TypedDSPhieuTraThuoc.tbChiTietPhieuTraThuocRow drHienTai = (TypedDSPhieuTraThuoc.tbChiTietPhieuTraThuocRow)dr;

            soLuongTra = (drHienTai.IsSoLuongTraNull()) ? 0 : Convert.ToInt32(drHienTai.SoLuongTra);
            donGia = (drHienTai.IsDonGiaXuatNull()) ? 0 : Convert.ToDecimal(drHienTai.DonGiaXuat);
            tienThuoc = soLuongTra * donGia;

            return tienThuoc;
        }

        public void TinhTongTienThuoc(DataTable dt)
        {
            long tongTienThuoc = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (TypedDSPhieuTraThuoc.tbChiTietPhieuTraThuocRow dr in (TypedDSPhieuTraThuoc.tbChiTietPhieuTraThuocDataTable)dt)
                {
                    tongTienThuoc += dr.IsThanhTienNull() ? 0 : (long)dr.ThanhTien;
                }
            }
            dtoPhieuTraThuoc.TongTienPhaiTra = tongTienThuoc;
        }

    }
}
