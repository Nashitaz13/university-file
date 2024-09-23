using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class KieuCaiDatPublic
    {
        private string _MaKieuCaiDat;

        public string MaKieuCaiDat
        {
            get { return _MaKieuCaiDat; }
            set { _MaKieuCaiDat = value; }
        }
        private string _TenKieuCaiDat;

        public string TenKieuCaiDat
        {
            get { return _TenKieuCaiDat; }
            set { _TenKieuCaiDat = value; }
        }

        private int _GiaKieuCaiDat;

        public int GiaKieuCaiDat
        {
            get { return _GiaKieuCaiDat; }
            set { _GiaKieuCaiDat = value; }
        }
    }
}
