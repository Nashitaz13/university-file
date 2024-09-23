using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class KieuCaiDatData
    {
        clsConnect cn ;
        
        public KieuCaiDatData()
        {
            cn = new clsConnect();
        }

        // Insert
        public int ThemKieuCaiDat(KieuCaiDatPublic kcd)
        {
             int param = 3;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@MaKieuCaiDat";
            name[1] = "@TenKieuCaiDat";
            name[2] = "@GiaKieuCaiDat";
               
            value[0] = kcd.MaKieuCaiDat;
            value[1] = kcd.TenKieuCaiDat;
            value[2] = kcd.GiaKieuCaiDat;

            return cn.ExcuteNonQuery("KIEUCAIDAT_Insert",name,value,param);
        }

        // Select 
        public DataTable SelectKieuCaiDat()
        {
            return cn.getData("KIEUCAIDAT_Select");
        }
    }
}
