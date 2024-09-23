using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKS2014.PUBLIC;
using System.Windows.Forms;

namespace QLKS2014.DATA
{
    public class NguoiDungData
    {
        DataConnecter connect;
        public NguoiDungData()
        {
            connect = new DataConnecter();
        }
        //Update Password
        //public DataTable update(NguoiDungPUBLIC nguoiDungPublic)
        //{
        //    int param = 1;
        //    string[] name = new string[param];
        //    object[] values = new object[param];
        //    name[0] = "@MatKhau";
        //    values[0] = nguoiDungPublic.MatKhau;
        //    return connect.getData("NguoiDung_Update", name, values, param);
        //}
        public List<NguoiDungPublic> update(NguoiDungPublic nguoiDung)
        {
            try
            {
                DataTable dt = new DataTable();
                List<NguoiDungPublic> list = new List<NguoiDungPublic>();
                NguoiDungPublic nguoiDungPublic = new NguoiDungPublic();

                int param = 1;
                string[] name = new string[param];
                object[] values = new object[param];
                name[0] = "@MatKhau";
                values[0] = nguoiDung.MatKhau;

                int row;
                dt = connect.getData("NguoiDung_Update",name,values,param);
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    nguoiDungPublic.MaNguoiDung = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    nguoiDungPublic.TenNguoiDung = dt.Rows[i].ItemArray[1].ToString();
                    nguoiDungPublic.LoaiNguoiDung = dt.Rows[i].ItemArray[2].ToString();
                    nguoiDungPublic.MatKhau = dt.Rows[i].ItemArray[3].ToString();
                    list.Add(nguoiDungPublic);
                }
                return list;
            }
            catch (Exception ex)
            {
                //bao loi
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
