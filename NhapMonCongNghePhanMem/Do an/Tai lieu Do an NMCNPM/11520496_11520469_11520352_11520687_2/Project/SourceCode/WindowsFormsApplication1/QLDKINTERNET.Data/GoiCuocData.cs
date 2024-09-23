using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class GoiCuocData
    {
        clsConnect cn;

        public GoiCuocData()
        {
            cn = new clsConnect();
        }

        //Them Goi Cuoc
        public int ThemGoiCuoc(GoiCuocPublic gc)
        {
            int param = 3;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaGoiCuoc";
            name[1] = "@TenGoiCuoc";
            name[2] = "@GiaTronGoi";

            value[0] = gc.MaGoiCuoc;
            value[1] = gc.TenGoiCuoc;
            value[2] = gc.GiaTronGoi;

            return cn.ExcuteNonQuery("GOICUOC_Insert", name, value, param);
        }

        //Cap Nhap Goi Cuoc
        public int CapNhatGoiCuoc(GoiCuocPublic gc)
        {
            int param = 3;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaGoiCuoc";
            name[1] = "@TenGoiCuoc";
            name[3] = "@GiaTronGoi";

            value[0] = gc.MaGoiCuoc;
            value[1] = gc.TenGoiCuoc;
            value[3] = gc.GiaTronGoi;

            return cn.ExcuteNonQuery("GOICUOC_Update", name, value, param);
        }

        // Select Goi Cuoc
        public DataTable SelectGoiCuoc(GoiCuocPublic gc)
        {
            int param = 2;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaGoiCuoc";
            name[1] = "@TenGoiCuoc";

            value[0] = gc.MaGoiCuoc;
            value[1] = gc.TenGoiCuoc;

            return cn.getData("GOICUOC_Select", name, value, param);
        }
        
        // select all Goi Cuoc
        public DataTable GoiCuoc_SelectAll()
        {
            return cn.getData("GOICUOC_SelectAll");
        }
    }
}
