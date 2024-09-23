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
    public class ChiTietHoaDonData
    {
        DataConnecter connect;
        public ChiTietHoaDonData()
        {
            connect = new DataConnecter();
        }

        //select all
        //public DataTable selectAll()
        //{
        //    return connect.getData("ChiTietHoaDon_SelectAll");
        //}
        public List<ChiTietHoaDonPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<ChiTietHoaDonPublic> list = new List<ChiTietHoaDonPublic>();
                ChiTietHoaDonPublic chiTietHoaDonPublic = new ChiTietHoaDonPublic();

                int row;
                dt = connect.getData("ChiTietHoaDon_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    chiTietHoaDonPublic.MaChiTietHoaDon = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    chiTietHoaDonPublic.MaHoaDon = int.Parse(dt.Rows[i].ItemArray[1].ToString());
                    chiTietHoaDonPublic.SoNgayThue = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    chiTietHoaDonPublic.MaPhieuThue = int.Parse(dt.Rows[i].ItemArray[3].ToString());
                    list.Add(chiTietHoaDonPublic);
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
        
        //insert
        public void insert(ChiTietHoaDonPublic chiTietHoaDonPublic)
        {
            int param = 4;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@MaChiTietHoaDon";
            name[1] = "@MaHoaDon";
            name[2] = "@SoNgayThue";
            name[3] = "@MaPhieuThue";
            values[0] = chiTietHoaDonPublic.MaChiTietHoaDon;
            values[1] = chiTietHoaDonPublic.MaHoaDon;
            values[2] = chiTietHoaDonPublic.SoNgayThue;
            values[3] = chiTietHoaDonPublic.MaPhieuThue;
            connect.ExcuteNonQuery("ChiTietHoaDon_Insert", name, values, param);
        }
    }
}