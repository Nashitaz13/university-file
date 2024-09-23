using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class NhaCungCap
    {
        private string maNhaCungCap;

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }

        private string tenNhaCungCap;

        public string TenNhaCungCap
        {
            get { return tenNhaCungCap; }
            set { tenNhaCungCap = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string soDienThoai;

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public NhaCungCap(string _maNhaCungCap)
        {
            maNhaCungCap = _maNhaCungCap;
        }

        public NhaCungCap(string _maNhaCungCap, string _tenNhaCungCap, string _diaChi, string _soDienThoai)
        {
            maNhaCungCap = _maNhaCungCap;
            tenNhaCungCap = _tenNhaCungCap;
            diaChi = _diaChi;
            soDienThoai = _soDienThoai;
        }
    }
}
