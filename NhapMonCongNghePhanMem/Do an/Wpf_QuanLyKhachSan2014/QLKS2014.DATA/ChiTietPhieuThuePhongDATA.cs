using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS2014.PUBLIC;
using System.Data;
using System.Windows.Forms;

namespace QLKS2014.DATA
{
    public class ChiTietPhieuThuePhongData
    {
        DataConnecter connect;
        
        public ChiTietPhieuThuePhongData()
        {
            connect = new DataConnecter();
        }

        //Select all ChiTietPhieuThuePhong
        //public DataTable selectAll()
        //{
        //    return connect.getData("ChiTietPhieuThuePhong_SelectAll");
        //}

        public List<ChiTietPhieuThuePhongPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<ChiTietPhieuThuePhongPublic> list = new List<ChiTietPhieuThuePhongPublic>();
                ChiTietPhieuThuePhongPublic chiTietPhieuThuePhong = new ChiTietPhieuThuePhongPublic();

                int row;
                dt = connect.getData("ChiTietPhieuThuePhong_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    chiTietPhieuThuePhong.MaChiTietPhieuThuePhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    chiTietPhieuThuePhong.MaPhieuThue = int.Parse(dt.Rows[i].ItemArray[1].ToString());
                    chiTietPhieuThuePhong.TenKhachHang = dt.Rows[i].ItemArray[2].ToString();
                    chiTietPhieuThuePhong.CMND = dt.Rows[i].ItemArray[3].ToString();
                    chiTietPhieuThuePhong.DiaChi = dt.Rows[i].ItemArray[4].ToString();
                    chiTietPhieuThuePhong.MaLoaiKhachHang = int.Parse(dt.Rows[i].ItemArray[5].ToString());
                    list.Add(chiTietPhieuThuePhong);
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

        //Thêm ChiTietPhieuThuePhong
        public void insert(ChiTietPhieuThuePhongPublic chiTietPhieuThuePhongPublic)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaChiTietPhieuThuePhong";

            values[0] = chiTietPhieuThuePhongPublic.MaChiTietPhieuThuePhong;

            connect.ExcuteNonQuery("ChiTietPhieuThuePhong_Insert", name, values, param);
        
        }
    }
}