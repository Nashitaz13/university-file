using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Warehouse
{
    public class DtoProduct
    {
        private string _maSanPham;
        private string _tenSanPham;
        private string _loaiSanPham;
        private int _thoiGianBaoHanh;
        private double _donGiaNhap;
        private double _donGiaBan;
        private int _soLuong;
        private string _donViTinh;
        private string _ghiChu;


        public DtoProduct()
        {
            
        }


        public DtoProduct(string maSanPham,
            string tenSanPham, 
            string loaiSanPham, 
            int thoiGianBaoHanh,
            double donGiaNhap,
            double donGiaBan,
            int soLuong,
            string donViTinh, 
            string ghiChu)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            LoaiSanPham = loaiSanPham;
            ThoiGianBaoHanh = thoiGianBaoHanh;
            DonGiaNhap = donGiaNhap;
            DonGiaBan = donGiaBan;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
            GhiChu = ghiChu;
        }

        public string MaSanPham
        {
            get { return _maSanPham; }
            set
            {
                if (value.Length <= 10)
                {
                    _maSanPham = value;
                }
            }
        }

        public string TenSanPham
        {
            get { return _tenSanPham; }
            set
            {
                if (value.Length <= 50)
                {
                    _tenSanPham = value;
                }
            }
        }

        public double DonGiaNhap
        {
            get { return _donGiaNhap; }
            set
            {
                if (value > 0)
                {
                    _donGiaNhap = value;
                }
            }
        }

        public double DonGiaBan
        {
            get { return _donGiaBan; }
            set
            {
                if (value > 0)
                {
                    _donGiaBan = value;
                }
            }
        }

        public string DonViTinh
        {
            get { return _donViTinh; }
            set
            {
                if (value.Length < 50)
                {
                    _donViTinh = value;
                }
            }
        }

        public string GhiChu
        {
            get { return _ghiChu; }
            set
            {
                if (value.Length < 100)
                {
                    _ghiChu = value;
                }
            }
        }

        public string LoaiSanPham
        {
            get { return _loaiSanPham; }
            set
            {
                if (value.Length < 50)
                {
                    _loaiSanPham = value;
                }
            }
        }

        public int SoLuong
        {
            get
            {
                return _soLuong;
            }

            set
            {
                if (value > 0)
                {
                    _soLuong = value;
                }
            }
        }

        public int ThoiGianBaoHanh
        {
            get { return _thoiGianBaoHanh; }
            set
            {
                if (value >= 0)
                {
                    _thoiGianBaoHanh = value;
                }
            }
        }

        public override string ToString()
        {
            return $"ThoiGianBaoHanh: {ThoiGianBaoHanh}, SoLuong: {SoLuong}, LoaiSanPham: {LoaiSanPham}, GhiChu: {GhiChu}, DonViTinh: {DonViTinh}, DonGiaBan: {DonGiaBan}, DonGiaNhap: {DonGiaNhap}, TenSanPham: {TenSanPham}, MaSanPham: {MaSanPham}";
        }
    }
}
