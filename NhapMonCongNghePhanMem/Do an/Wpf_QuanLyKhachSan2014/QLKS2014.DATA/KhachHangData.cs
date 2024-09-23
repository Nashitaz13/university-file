using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS2014.PUBLIC;
using System.Windows.Forms;
using System.Data;

namespace QLKS2014.DATA
{
    public class KhachHangData
    {
        DataConnecter connect;
        public KhachHangData()
        {
            connect = new DataConnecter();
        }

        //selectAll
        public List<KhachHangPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<KhachHangPublic> list = new List<KhachHangPublic>();
                KhachHangPublic khachHangPublic = new KhachHangPublic();

                int row;
                dt = connect.getData("KhachHang_SelectAll");
                row = dt.Rows.Count;
                for(int i = 0; i < row; i++)
                {
                    khachHangPublic.MaKhachHang = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    khachHangPublic.TenKhachHang = dt.Rows[i].ItemArray[1].ToString();
                    khachHangPublic.CMND = dt.Rows[i].ItemArray[2].ToString();
                    khachHangPublic.DiaChi = dt.Rows[i].ItemArray[3].ToString();
                    khachHangPublic.MaLoaiKhach = int.Parse(dt.Rows[i].ItemArray[4].ToString());
                    khachHangPublic.MaPhieuThue = int.Parse(dt.Rows[i].ItemArray[5].ToString());
                    khachHangPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[6].ToString());
                    list.Add(khachHangPublic);
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
