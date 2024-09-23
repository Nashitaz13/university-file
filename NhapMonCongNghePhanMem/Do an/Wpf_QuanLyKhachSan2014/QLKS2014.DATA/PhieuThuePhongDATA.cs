using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS2014.PUBLIC;
using System.Data;

namespace QLKS2014.DATA
{
    public class PhieuThuePhongData
    {
        DataConnecter connect;
        public PhieuThuePhongData()
        {
            connect = new DataConnecter();
        }

        //Thêm Phieu Thue Phong
        public string insert(PhieuThuePhongPublic phieuThuePhongPublic)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaPhieuThue";

            values[0] = phieuThuePhongPublic.MaPhong;

            return connect.getData("PhieuThuePhong_Insert", name, values, param).Columns[0].ToString();
        }

        
    }
}