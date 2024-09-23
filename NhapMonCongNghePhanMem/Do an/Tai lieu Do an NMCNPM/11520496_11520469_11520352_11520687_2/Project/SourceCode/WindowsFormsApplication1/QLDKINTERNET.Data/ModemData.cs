using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class ModemData
    {
        clsConnect cn;

        public ModemData()
        {
            cn = new clsConnect();            
        }

        // Thêm
        public int ThemModem(ModemPublic md)
        {
            int param = 3;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaModem";
            name[1] = "@TenModem";
            name[2] = "@GiaModem";

            value[0] = md.MaModem;
            value[1] = md.TenModem;
            value[2] = md.GiaModem;

            return cn.ExcuteNonQuery("MODEM_Insert", name, value, param);
        }

        // Cap Nhat
        public int CapNhatModem(ModemPublic md)
        {
            int param = 3;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaModem";
            name[1] = "@TenModem";
            name[2] = "@GiaModem";

            value[0] = md.MaModem;
            value[1] = md.TenModem;
            value[2] = md.GiaModem;

            return cn.ExcuteNonQuery("MODEM_Update", name, value, param);
        }

        // Select
        public DataTable SelectModem(ModemPublic md)
        {
            int param = 2;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaModem";
            name[1] = "@TenModem";
            value[0] = md.MaModem;
            value[1] = md.TenModem;

            return cn.getData("MODEM_Select", name, value, param);
        }

        // Select All
        public DataTable Modem_SelectAll()
        {
            return cn.getData("MODEM_SelectAll");
        }
    }
}
