using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;

namespace QLDKINTERNET.Data
{
    public class TaiKhoanDangNhapData
    {
         clsConnect cn;

        public TaiKhoanDangNhapData()
        {
            cn = new clsConnect();           
        }

        //Them Tai Khoan
        public int TaiKhoanDangNhap_Insert(TaiKhoanDangNhapPublic tk)
        {
            int param = 3;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaDV";
            name[1] = "@UserName";
            name[2] = "@Password";

            values[0] = tk.MaDV;
            values[1] = tk.Username;
            values[2] = tk.Password;

            return cn.ExcuteNonQuery("TAIKHOANDANGNHAP_Insert", name, values, param);
        }
    }
}
