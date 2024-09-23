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
    public class ChiTietBaoCaoDoanhThuData
    {
        DataConnecter connect;
        public ChiTietBaoCaoDoanhThuData()
        {
            connect = new DataConnecter();
        }

        //select all
        //public DataTable selectAll()
        //{
        //    return connect.getData("ChiTietBaoCaoDoanhThu_SelectAll");
        //}

        public List<ChiTietBaoCaoDoanhThuPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<ChiTietBaoCaoDoanhThuPublic> list = new List<ChiTietBaoCaoDoanhThuPublic>();
                ChiTietBaoCaoDoanhThuPublic chiTietBaoCaoDoanhThuPublic = new ChiTietBaoCaoDoanhThuPublic();

                int row;
                dt = connect.getData("ChiTietBaoCaoDoanhThu_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    chiTietBaoCaoDoanhThuPublic.MaChiTietBaoCaoDoanhThu = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    chiTietBaoCaoDoanhThuPublic.MaBaoCao = int.Parse(dt.Rows[i].ItemArray[1].ToString());
                    chiTietBaoCaoDoanhThuPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    chiTietBaoCaoDoanhThuPublic.DoanhThu = decimal.Parse(dt.Rows[i].ItemArray[3].ToString());
                    chiTietBaoCaoDoanhThuPublic.TyLe = float.Parse(dt.Rows[i].ItemArray[4].ToString());
                    list.Add(chiTietBaoCaoDoanhThuPublic);
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

        //select theo MaBaoCao
        //public DataTable selectAllByMaBaoCao(ChiTietBaoCaoDoanhThuPUBLIC chiTietHoaDonPublic)
        //{
        //    int param = 1;
        //    string[] name = new string[param];
        //    object[] values = new object[param];
        //    name[0] = "@MaBaoCao";
        //    values[0] = chiTietHoaDonPublic.MaBaoCao;
        //    return connect.getData("ChiTietBaoCaoDoanhThu_SelectByMaBaoCao", name, values, param);
        //}

        public List<ChiTietBaoCaoDoanhThuPublic> selectAllByMaBaoCao(ChiTietBaoCaoDoanhThuPublic chiTietBaoCaoDoanhThu)
        {
            try
            {
                DataTable dt = new DataTable();
                List<ChiTietBaoCaoDoanhThuPublic> list = new List<ChiTietBaoCaoDoanhThuPublic>();
                ChiTietBaoCaoDoanhThuPublic chiTietBaoCaoDoanhThuPublic = new ChiTietBaoCaoDoanhThuPublic();
                int param = 1;
                string[] name = new string[param];
                object[] values = new object[param];
                name[0] = "@MaBaoCao";
                values[0] = chiTietBaoCaoDoanhThu.MaBaoCao;
                int row;
                dt = connect.getData("ChiTietBaoCaoDoanhThu_SelectByMaBaoCao", name, values, param);
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    chiTietBaoCaoDoanhThuPublic.MaChiTietBaoCaoDoanhThu = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    chiTietBaoCaoDoanhThuPublic.MaBaoCao = int.Parse(dt.Rows[i].ItemArray[1].ToString());
                    chiTietBaoCaoDoanhThuPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    chiTietBaoCaoDoanhThuPublic.DoanhThu = decimal.Parse(dt.Rows[i].ItemArray[3].ToString());
                    chiTietBaoCaoDoanhThuPublic.TyLe = float.Parse(dt.Rows[i].ItemArray[4].ToString());
                    list.Add(chiTietBaoCaoDoanhThuPublic);
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
        public int insert(ChiTietBaoCaoDoanhThuPublic chiTietBaoCaoDoanhThuPublic)
        {
            int param = 5;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@MaChiTietBaoCaoDoanhThu";
            name[1] = "@MaBaoCao";
            name[2] = "@MaLoaiPhong";
            name[3] = "@DoanhThu";
            name[4] = "@TyLe";
            values[0] = chiTietBaoCaoDoanhThuPublic.MaChiTietBaoCaoDoanhThu;
            values[1] = chiTietBaoCaoDoanhThuPublic.MaBaoCao;
            values[2] = chiTietBaoCaoDoanhThuPublic.MaLoaiPhong;
            values[3] = chiTietBaoCaoDoanhThuPublic.DoanhThu;
            values[4] = chiTietBaoCaoDoanhThuPublic.TyLe;
            return connect.ExcuteNonQuery("ChiTietBaoCaoDoanhThu_Insert", name, values, param);
        }
    }
}