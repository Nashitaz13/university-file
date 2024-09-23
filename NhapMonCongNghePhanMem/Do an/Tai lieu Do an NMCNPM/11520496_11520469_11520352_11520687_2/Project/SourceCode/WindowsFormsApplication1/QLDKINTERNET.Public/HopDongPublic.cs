using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
     public class HopDongPublic
    {
         public void init()
         {
             _MaHopDong = -1;
             _HoTen = "";
             _CMND = "";
             _NgheNghiep = "";
             _Email = "";
             _ChucVu = "";
             _DiaChi = "";
             _DienThoai = "";
         }


        private int _MaHopDong;

        public int MaHopDong
        {
            get { return _MaHopDong; }
            set { _MaHopDong = value; }
        }
        private DateTime _NgayDangKy;

        public DateTime NgayDangKy
        {
            get { return _NgayDangKy; }
            set { _NgayDangKy = value; }
        }
        private string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        private string _CMND;

        public string CMND
        {
            get { return _CMND; }
            set { _CMND = value; }
        }
        private string _NgheNghiep;

        public string NgheNghiep
        {
            get { return _NgheNghiep; }
            set { _NgheNghiep = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _ChucVu;

        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _DienThoai;

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

    }
}
