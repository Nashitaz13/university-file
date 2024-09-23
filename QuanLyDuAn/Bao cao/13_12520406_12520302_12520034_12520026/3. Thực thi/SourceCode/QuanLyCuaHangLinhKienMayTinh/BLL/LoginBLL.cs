using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LoginBLL
    {
        LoginDAL dan = new LoginDAL();
        public bool CheckDangNhap(string manv, string matkhau)
        {
            DataTable d= dan.LayMatKhauNhanVien(manv);
            if(d.Rows.Count==0)
            {
                return false;
            }
            else
            {
                if (d.Rows[0].ItemArray[0].ToString() == matkhau)
                {
 
                    return true;
                }
                else
                    return false;
            }
        }

   


    }
}
