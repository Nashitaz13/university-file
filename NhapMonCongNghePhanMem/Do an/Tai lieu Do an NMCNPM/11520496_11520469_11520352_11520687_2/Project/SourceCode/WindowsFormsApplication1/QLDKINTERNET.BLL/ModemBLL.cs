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
    public class ModemBLL
    {
        ModemData cls = new ModemData();

        public int ThemModem(ModemPublic md)
        {
            return cls.ThemModem(md);
        }

        public int CapNhatModem(ModemPublic md)
        {
            return cls.CapNhatModem(md);
        }

        public DataTable SelectModem(ModemPublic md)
        {
            return cls.SelectModem(md);
        }

        public DataTable Modem_SelectAll()
        {
            return cls.Modem_SelectAll();
        }
    }
}
