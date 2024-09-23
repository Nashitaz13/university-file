using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DTO
{
    class NhaSanXuat
    {
        private string maNhaSanXuat;

        public string MaNhaSanXuat
        {
            get { return maNhaSanXuat; }
            set { maNhaSanXuat = value; }
        }
        private string tenNhaSanXuat;

        public string TenNhaSanXuat
        {
            get { return tenNhaSanXuat; }
            set { tenNhaSanXuat = value; }
        }

        public NhaSanXuat(string _maNhaSanXuat)
        {
            maNhaSanXuat = _maNhaSanXuat;
        }

        public NhaSanXuat(string _maNhaSanXuat, string _tenNhaSanXuat)
        {
            maNhaSanXuat = _maNhaSanXuat;
            tenNhaSanXuat = _tenNhaSanXuat;
        }
    }
}
