using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class MatHang
    {
        private string maMatHang;

        public string MaMatHang
        {
            get { return maMatHang; }
            set { maMatHang = value; }
        }
        private string tenMatHang;

        public string TenMatHang
        {
            get { return tenMatHang; }
            set { tenMatHang = value; }
        }

        private string nhaSanXuat;

        public string NhaSanXuat
        {
            get { return nhaSanXuat; }
            set { nhaSanXuat = value; }
        }

        private byte[] hinh;

        public byte[] Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        public MatHang(string _maMatHang)
        {
            maMatHang = _maMatHang;
        }

        
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private int thoiGianBaoHanh;

        public int ThoiGianBaoHanh
        {
            get { return thoiGianBaoHanh; }
            set { thoiGianBaoHanh = value; }
        }

        private float giaNhap;

        public float GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        private float giaBan;

        public float GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        public MatHang(string _maMatHang, string _tenMatHang, string _nhaSanXuat, byte[] _hinh, int _soLuong, int _thoiGianBaoHanh, float _giaNhap, float _giaBan)
        {
            maMatHang = _maMatHang;
            tenMatHang = _tenMatHang;
            nhaSanXuat = _nhaSanXuat;
            hinh = _hinh;

            soLuong = _soLuong;
            thoiGianBaoHanh = _thoiGianBaoHanh;
            giaNhap = _giaNhap;
            giaBan = _giaBan;
        }
    }
}
