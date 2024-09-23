using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class CT_LoaiLuuLuong
    {
        private string _MaGoiCuoc;

        public string MaGoiCuoc
        {
            get { return _MaGoiCuoc; }
            set { _MaGoiCuoc = value; }
        }
        private string _MaLLL;

        public string MaLLL
        {
            get { return _MaLLL; }
            set { _MaLLL = value; }
        }
        private int _GiaCuocTrenMB;

        public int GiaCuocTrenMB
        {
            get { return _GiaCuocTrenMB; }
            set { _GiaCuocTrenMB = value; }
        }
    }
}
