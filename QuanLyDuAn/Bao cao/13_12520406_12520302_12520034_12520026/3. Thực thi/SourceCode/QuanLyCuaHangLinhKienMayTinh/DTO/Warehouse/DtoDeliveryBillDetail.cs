using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Warehouse
{
    public class DtoDeliveryBillDetail
    {
        private string _maChiTietPhieuXuatKho;
        private string _MaPhieuXuatKho;
        private string _maSanPham;
        private int _soLuong;
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set
            {
                if (value.Length < 100)
                    _ghiChu = value;
            }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set
            {
                if (value > 0)
                    _soLuong = value;
            }
        }

        public string MaSanPham
        {
            get { return _maSanPham; }
            set
            {
                if (value.Length < 10)
                    _maSanPham = value;
            }
        }

        public string MaPhieuXuatKho
        {
            get { return _MaPhieuXuatKho; }
            set { if (value.Length < 10) _MaPhieuXuatKho = value; }
        }

        public string MaChiTietPhieuXuatKho
        {
            get { return _maChiTietPhieuXuatKho; }
            set { if (value.Length < 10) _maChiTietPhieuXuatKho = value; }
        }
    }
}
