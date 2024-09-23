using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNT.CommonLayer
{
    public class Constants
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public class HinhThucThanhToan
        {
            public string TenHinhThucThanhToan { get; set; }
            public int MaHinhThucThanhToan { get; set; }            
        }

        public static List<HinhThucThanhToan> DanhMucHinhThucThanhToan()
        {
            List<HinhThucThanhToan> lstHTTT = new List<HinhThucThanhToan>();
            lstHTTT.Add(new HinhThucThanhToan() { MaHinhThucThanhToan=0,TenHinhThucThanhToan="Tiền mặt" });
            lstHTTT.Add(new HinhThucThanhToan() { MaHinhThucThanhToan = 1, TenHinhThucThanhToan = "Chuyển khoản" });
            return lstHTTT;
        }

        public class DonViTinh
        {
            public string TenDonViTinh { get; set; }
            public int MaDonViTinh { get; set; }
        }

        public static List<DonViTinh> DanhMucDonViTinh()
        {
            List<DonViTinh> lstDonViTinh = new List<DonViTinh>();
            lstDonViTinh.Add(new DonViTinh() { MaDonViTinh = 0, TenDonViTinh = "Chai" });
            lstDonViTinh.Add(new DonViTinh() { MaDonViTinh = 1, TenDonViTinh = "Lọ" });
            lstDonViTinh.Add(new DonViTinh() { MaDonViTinh = 2, TenDonViTinh = "Viên" });
            lstDonViTinh.Add(new DonViTinh() { MaDonViTinh = 3, TenDonViTinh = "Hộp" });
            lstDonViTinh.Add(new DonViTinh() { MaDonViTinh = 4, TenDonViTinh = "Thùng" });
          
            return lstDonViTinh;
        }

        public class ChucVu
        {
            public string TenChucVu { get; set; }
            public int MaChucVu { get; set; }
        }

        public static List<ChucVu> DanhMucChucVu()
        {
            List<ChucVu> lstChucVu = new List<ChucVu>();
            lstChucVu.Add(new ChucVu() { MaChucVu = 0, TenChucVu = "Dược sĩ kho" });
            lstChucVu.Add(new ChucVu() { MaChucVu = 1, TenChucVu = "Dược tá" });
            lstChucVu.Add(new ChucVu() { MaChucVu = 2, TenChucVu = "Giám đốc" });
            lstChucVu.Add(new ChucVu() { MaChucVu = 3, TenChucVu = "Kế toán" });

            return lstChucVu;
        }

        public enum LoaiNhanVien
        {
            NhanVienNhaThuoc = 0,
            BacSi = 1
        }

        #region Thong bao
        public const string GridExceptionLoiChung = "Có lỗi dữ liệu. Vùi lòng kiểm tra lại!";
        public const string GridExceptionLoiNull = "Vui lòng nhập thông tin vào cột {0}";
        
        public const string MsgExceptionTonTaiMauTin = "Mẫu tin này đã tồn tại trong hệ thống.\n Đề nghị nhập lại mẫu tin mới.";
        public const string MsgExceptionTruyCapLoi = "Đã xảy ra lỗi trong quá trình truy cập tập tin dữ liệu";
        public const string MsgExceptionLuuLoi = "Đã xảy ra lỗi trong quá trình thực hiện giao tác lưu các mẩu tin dữ liệu.";
        public const string MsgExceptionLoiChung = "Đã xảy ra một lỗi trong chương trình.";

        public const string MsgFormLuuXong = "Lưu thành công!";
        #endregion Thong bao
    }
}
