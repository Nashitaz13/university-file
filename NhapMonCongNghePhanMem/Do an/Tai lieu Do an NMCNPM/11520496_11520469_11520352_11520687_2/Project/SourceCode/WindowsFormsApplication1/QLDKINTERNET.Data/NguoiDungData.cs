using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class NguoiDungData
    {
        clsConnect cn;

        public NguoiDungData()
        {
            cn = new clsConnect();
        }
        public DataTable Login(NguoiDungPublic nd)
        {
            int param = 2;
            string[] name = new string[param];
            object[] value = new object[param];

            name[0] = "@Username";
            name[1] = "@Pass";
            value[0] = nd.Username;
            value[1] = nd.Pass;

            return cn.getData("NGUOIDUNG_SelectDangNhap", name, value, param);            
        }
    }
}
