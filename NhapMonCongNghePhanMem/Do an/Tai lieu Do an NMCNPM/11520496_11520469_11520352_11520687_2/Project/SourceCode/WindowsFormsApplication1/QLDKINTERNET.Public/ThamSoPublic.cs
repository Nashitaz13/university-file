using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class ThamSoPublic
    {
        private string _MaThamSo;

        public string MaThamSo
        {
            get { return _MaThamSo; }
            set { _MaThamSo = value; }
        }
        private string _TenThamSo;

        public string TenThamSo
        {
            get { return _TenThamSo; }
            set { _TenThamSo = value; }
        }
        private int _GiaTri;

        public int GiaTri
        {
            get { return _GiaTri; }
            set { _GiaTri = value; }
        }
    }
}
