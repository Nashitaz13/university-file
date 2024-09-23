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
    public class NguoiDungBLL
    {
        NguoiDungData cls = new NguoiDungData();

        public bool DangNhap(NguoiDungPublic nd)
        {
            if (cls.Login(nd).Rows.Count == 1)
            {
                nd.MaNguoiDung = cls.Login(nd).Rows[0].ItemArray[0].ToString();
                nd.MaLoaiNguoiDung = cls.Login(nd).Rows[0].ItemArray[1].ToString();               
                return true;
            }
            else
                return false;
        }
    }
}
