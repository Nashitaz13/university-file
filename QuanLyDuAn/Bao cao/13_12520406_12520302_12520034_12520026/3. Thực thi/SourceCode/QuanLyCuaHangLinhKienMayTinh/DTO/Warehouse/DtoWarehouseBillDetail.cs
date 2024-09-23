using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Warehouse
{
    public class DtoWarehouseBillDetail
    {
        private string _maChiTietPhieuNhapKho;
        private string _MaPhieuNhapKho;
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

        public string MaPhieuNhapKho
        {
            get { return _MaPhieuNhapKho; }
            set { if (value.Length < 10) _MaPhieuNhapKho = value; }
        }

        public string MaChiTietPhieuNhapKho
        {
            get { return _maChiTietPhieuNhapKho; }
            set { if (value.Length < 10) _maChiTietPhieuNhapKho = value; }
        }
    }
}
