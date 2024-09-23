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
    public class LoaiPhongData
    {
        DataConnecter connect;
        public LoaiPhongData()
        {
            connect = new DataConnecter();
        }
        //selectAll
        //public DataTable selectAll()
        //{
        //    return connect.getData("LoaiPhong_SelectAll");
        //}

        public List<LoaiPhongPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<LoaiPhongPublic> list = new List<LoaiPhongPublic>();
                LoaiPhongPublic loaiPhongPublic = new LoaiPhongPublic();
                int row;
                dt = connect.getData("LoaiPhong_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    loaiPhongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    loaiPhongPublic.TenLoaiPhong = dt.Rows[i].ItemArray[1].ToString();
                    loaiPhongPublic.DonGia = float.Parse(dt.Rows[i].ItemArray[2].ToString());
                    loaiPhongPublic.SoKhachToiDa = int.Parse(dt.Rows[i].ItemArray[3].ToString());
                    list.Add(loaiPhongPublic);
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

        //update
        public int update(LoaiPhongPublic loaiPhongPublic)
        {
            int param = 4;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@MaLoaiPhong";
            name[1] = "@TenLoaiPhong";
            name[2] = "@DonGia";
            name[3] = "@SoKhachToiDa";
            values[0] = loaiPhongPublic.MaLoaiPhong;
            values[1] = loaiPhongPublic.TenLoaiPhong;
            values[2] = loaiPhongPublic.DonGia;
            values[3] = loaiPhongPublic.SoKhachToiDa;
            return connect.ExcuteNonQuery("LoaiPhong_Update", name, values, param);
        }
        //delete
        public void delete(LoaiPhongPublic loaiPhongPublic)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@TenLoaiPhong";
            values[0] = loaiPhongPublic.TenLoaiPhong;
            connect.getData("LoaiPhong_Delete", name, values, param);
        }

        //public List<LoaiPhongPUBLIC> delete(LoaiPhongPUBLIC loaiPhong)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        List<LoaiPhongPUBLIC> list = new List<LoaiPhongPUBLIC>();
        //        LoaiPhongPUBLIC loaiPhongPublic = new LoaiPhongPUBLIC();
        //        int param = 1;
        //        string[] name = new string[param];
        //        object[] values = new object[param];
        //        name[0] = "@TenLoaiPhong";
        //        values[0] = loaiPhong.TenLoaiPhong;

        //        //int row;
        //        dt = connect.getData("LoaiPhong_Delete",name,values,param);
        //        //row = dt.Rows.Count;
        //        //for (int i = 0; i < row; i++)
        //        //{
        //        //    loaiPhongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
        //        //    loaiPhongPublic.TenLoaiPhong = dt.Rows[i].ItemArray[1].ToString();
        //        //    loaiPhongPublic.DonGia = float.Parse(dt.Rows[i].ItemArray[2].ToString());
        //        //    loaiPhongPublic.SoKhachToiDa = int.Parse(dt.Rows[i].ItemArray[3].ToString());
        //        //    list.Add(loaiPhongPublic);
        //        //}
        //        list.Add(loaiPhongPublic);
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        //bao loi
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}

    }
}