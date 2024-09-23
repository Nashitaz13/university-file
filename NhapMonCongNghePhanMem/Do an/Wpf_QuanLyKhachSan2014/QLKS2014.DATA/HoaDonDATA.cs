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
    public class HoaDonData
    {
        DataConnecter connect;
        public HoaDonData()
        {
            connect = new DataConnecter();
        }
        //Select All
        //public DataTable selectAll()
        //{
        //    return connect.getData("HoaDon_SelectAll");
        //}

        public List<HoaDonPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<HoaDonPublic> list = new List<HoaDonPublic>();
                HoaDonPublic hoaDonPublic = new HoaDonPublic();


                int row;
                dt = connect.getData("HoaDon_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    hoaDonPublic.MaHoaDon = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    hoaDonPublic.TenKhachHang = dt.Rows[i].ItemArray[1].ToString();
                    hoaDonPublic.NgayLap = DateTime.Parse(dt.Rows[i].ItemArray[2].ToString());
                    list.Add(hoaDonPublic);
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

        //insert hóa đơn, return về mã hóa đơn insert được, nếu k return về -1
        public int insert(HoaDonPublic hoaDonPublic)
        {
            int param = 4;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@MaHoaDon";
            name[1] = "@TenKhachHang";
            name[2] = "@NgayLap";
            name[3] = "@TriGia";
            values[0] = hoaDonPublic.MaHoaDon;
            values[1] = hoaDonPublic.TenKhachHang;
            values[2] = hoaDonPublic.NgayLap;
            values[3] = hoaDonPublic.TriGia;

            return connect.ExcuteNonQuery("HoaDon_Insert", name, values, param);
        }
    }
}