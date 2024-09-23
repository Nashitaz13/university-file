using QLDKINTERNET.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDKINTERNET.GUI
{
    class GoiCuocGui: GoiCuocPublic
    {
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}
