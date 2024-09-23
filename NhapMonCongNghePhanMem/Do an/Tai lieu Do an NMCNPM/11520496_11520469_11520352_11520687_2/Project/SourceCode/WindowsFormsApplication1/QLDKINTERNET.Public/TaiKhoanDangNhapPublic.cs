using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class TaiKhoanDangNhapPublic
    {
        private string _MaTaiKhoan;

        public string MaTaiKhoan
        {
            get { return _MaTaiKhoan; }
            set { _MaTaiKhoan = value; }
        }
        private int _MaDV;

        public int MaDV
        {
            get { return _MaDV; }
            set { _MaDV = value; }
        }
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

    }
}
