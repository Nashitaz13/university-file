using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class NguoiDungPublic
    {
        private string _MaNguoiDung;

        public string MaNguoiDung
        {
            get { return _MaNguoiDung; }
            set { _MaNguoiDung = value; }
        }
        private string _MaLoaiNguoiDung;

        public string MaLoaiNguoiDung
        {
            get { return _MaLoaiNguoiDung; }
            set { _MaLoaiNguoiDung = value; }
        }
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        private string _Pass;

        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }
    }
}
