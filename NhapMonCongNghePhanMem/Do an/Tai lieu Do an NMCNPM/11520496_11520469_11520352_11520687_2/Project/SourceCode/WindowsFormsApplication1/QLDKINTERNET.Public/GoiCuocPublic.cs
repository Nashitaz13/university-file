using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class GoiCuocPublic
    {
        private string _MaGoiCuoc;

        public string MaGoiCuoc
        {
            get { return _MaGoiCuoc; }
            set { _MaGoiCuoc = value; }
        }
        private string _TenGoiCuoc;

        public string TenGoiCuoc
        {
            get { return _TenGoiCuoc; }
            set { _TenGoiCuoc = value; }
        }
        private int _GiaTronGoi;

        public int GiaTronGoi
        {
            get { return _GiaTronGoi; }
            set { _GiaTronGoi = value; }
        }

    }
}
