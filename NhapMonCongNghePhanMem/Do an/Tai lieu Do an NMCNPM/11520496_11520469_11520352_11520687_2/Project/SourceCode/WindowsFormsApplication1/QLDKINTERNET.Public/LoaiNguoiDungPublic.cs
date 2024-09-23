using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class LoaiNguoiDungPublic
    {
        private string _MaLoaiNguoiDung;

        public string MaLoaiNguoiDung
        {
            get { return _MaLoaiNguoiDung; }
            set { _MaLoaiNguoiDung = value; }
        }
        private string _TenLoaiNguoiDung;

        public string TenLoaiNguoiDung
        {
            get { return _TenLoaiNguoiDung; }
            set { _TenLoaiNguoiDung = value; }
        }
    }
}
