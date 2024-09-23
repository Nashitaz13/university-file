using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class ModemPublic
    {
        private string _MaModem;

        public string MaModem
        {
            get { return _MaModem; }
            set { _MaModem = value; }
        }
        private string _TenModem;

        public string TenModem
        {
            get { return _TenModem; }
            set { _TenModem = value; }
        }

        private int _GiaModem;

        public int GiaModem
        {
            get { return _GiaModem; }
            set { _GiaModem = value; }
        }
    }
}
