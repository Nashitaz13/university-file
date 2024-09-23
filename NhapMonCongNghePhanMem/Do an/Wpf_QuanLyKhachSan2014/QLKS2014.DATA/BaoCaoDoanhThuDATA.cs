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
    public class BaoCaoDoanhThuData
    {
        DataConnecter connect;
        public BaoCaoDoanhThuData()
        {
            connect = new DataConnecter();
        }

        //select all 
        //public DataTable selectAll()
        //{
        //    return connect.getData("BaoCaoDoanhThu_SelectAll");
        //}

        public List<BaoCaoDoanhThuPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<BaoCaoDoanhThuPublic> list = new List<BaoCaoDoanhThuPublic>();
                BaoCaoDoanhThuPublic baoCaoDoanhThuPublic = new BaoCaoDoanhThuPublic();

                int row;
                dt = connect.getData("BaoCaoDoanhThu_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    baoCaoDoanhThuPublic.MaBaoCao = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    baoCaoDoanhThuPublic.TenBaoCao = (dt.Rows[i].ItemArray[1].ToString());
                    baoCaoDoanhThuPublic.NgayLap = DateTime.Parse(dt.Rows[i].ItemArray[2].ToString());
                    baoCaoDoanhThuPublic.ThangBaoCao = int.Parse(dt.Rows[i].ItemArray[3].ToString());

                    list.Add(baoCaoDoanhThuPublic);
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

        //insert tra ve MaBaoCaoDanhThu
        public int insert(BaoCaoDoanhThuPublic baoCaoDoanhThuPublic)
        {
            int param = 4;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@MaBaoCao";
            name[1] = "@TenBaoCao";
            name[2] = "@NgayLap";
            name[3] = "@ThangBaoCao";

            values[0] = baoCaoDoanhThuPublic.MaBaoCao;
            values[1] = baoCaoDoanhThuPublic.TenBaoCao;
            values[2] = baoCaoDoanhThuPublic.NgayLap;
            values[3] = baoCaoDoanhThuPublic.ThangBaoCao;
            return connect.ExcuteNonQuery("BaoCaoDoanhThu_Insert", name, values, param);
        }
    }
}