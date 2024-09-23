using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNT.DataTransferObject
{
    public class DtoNhanVien
    {
        private int _MaNhanVien; 
        public int MaNhanVien { get { return _MaNhanVien; } set { _MaNhanVien = value; } }
      
        private int _MaChucVu; 
        public int MaChucVu { get { return _MaChucVu; } set { _MaChucVu = value; } }
       
        private string _TenNhanVien; 
        public string TenNhanVien { get { return _TenNhanVien; } set { _TenNhanVien = value; } }
        private DateTime? _NgaySinh; 
        public DateTime? NgaySinh { get { if (_NgaySinh == SqlDateTime.MinValue.Value) { _NgaySinh = null; } return _NgaySinh; } set { _NgaySinh = value; } }
        private int _GioiTinh; 
        public int GioiTinh { get { return _GioiTinh; } set { _GioiTinh = value; } }
        private string _DiaChi; 
        public string DiaChi { get { return _DiaChi; } set { _DiaChi = value; } }
        private string _TaiKhoan; 
        public string TaiKhoan { get { return _TaiKhoan; } set { _TaiKhoan = value; } }
        private string _MatKhau; 
        public string MatKhau { get { return _MatKhau; } set { _MatKhau = value; } }
        private string _TrinhDoVanHoa; 
        public string TrinhDoVanHoa { get { return _TrinhDoVanHoa; } set { _TrinhDoVanHoa = value; } }
        private string _CMND; 
        public string CMND { get { return _CMND; } set { _CMND = value; } }
        private string _ChuyenMon; 
        public string ChuyenMon { get { return _ChuyenMon; } set { _ChuyenMon = value; } }
       
    }
}
