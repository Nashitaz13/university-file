using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;
using QLDKINTERNET.Data;

namespace QLDKINTERNET.BLL
{
    public class TaiKhoanDangNhapBLL
    {
        TaiKhoanDangNhapData cls = new TaiKhoanDangNhapData();

        //Them Tai Khoan
        public int TaiKhoanDangNhap_Insert(TaiKhoanDangNhapPublic tk)
        {
            return cls.TaiKhoanDangNhap_Insert(tk);
        }
    }
}
