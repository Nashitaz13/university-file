using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class Gia
    {
        private string maMatHang;

        public string MaMatHang
        {
            get { return maMatHang; }
            set { maMatHang = value; }
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

        public Gia(string _maMatHang, float _giaNhap, float _giaBan)
        {
            maMatHang = _maMatHang;
            giaBan = _giaBan;
            giaNhap = _giaNhap;
        }

        public Gia(string _maMatHang)
        {
            maMatHang = _maMatHang;
        }
    }
}
