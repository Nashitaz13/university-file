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
    public class GoiCuocBLL
    {
        GoiCuocData cls = new GoiCuocData();

        //Them Goi Cuoc
        public int ThemGoiCuoc(GoiCuocPublic gc)
        {
            return cls.ThemGoiCuoc(gc);
        }

        //Cap Nhat
        public int CapNhatGoiCuoc(GoiCuocPublic gc)
        {
            return cls.CapNhatGoiCuoc(gc);
        }

        //Select
        public DataTable SelectGoiCuoc(GoiCuocPublic gc)
        {
            return cls.SelectGoiCuoc(gc);
        }

        public DataTable GoiCuoc_SelectAll()
        {
            return cls.GoiCuoc_SelectAll();
        }
    }
}
