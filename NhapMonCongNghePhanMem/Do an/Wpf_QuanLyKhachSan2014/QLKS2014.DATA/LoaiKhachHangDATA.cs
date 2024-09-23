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
    public class LoaiKhachHangData
    {
        DataConnecter connect;
        public LoaiKhachHangData()
        {
            connect = new DataConnecter();
        }

        //SelectAll
        //public DataTable selectByName(LoaiKhachHangPUBLIC loaiKhachHangPublic)
        //{
        //    int param = 1;
        //    string[] name = new string[param];
        //    object[] values = new object[param];
        //    name [0] = "@TenLoaiKhachHang";
        //    values[0] = loaiKhachHangPublic.TenLoaiKhachHang;
        //    return connect.getData("LoaiKhachHang_SelectAll", name, values, param);
        //    //return connect.getData("LoaiKhachHang_SelectAll");
        //}

        public List<LoaiKhachHangPublic> selectByName(LoaiKhachHangPublic loaiKhachHang)
        {
            try
            {
                DataTable dt = new DataTable();
                List<LoaiKhachHangPublic> list = new List<LoaiKhachHangPublic>();
                LoaiKhachHangPublic loaiKhachHangPublic = new LoaiKhachHangPublic();
                int param = 1;
                string[] name = new string[param];
                object[] values = new object[param];
                name [0] = "@TenLoaiKhachHang";
                values[0] = loaiKhachHang.TenLoaiKhachHang;

                int row;
                dt = connect.getData("LoaiKhachHang_SelectByName");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    loaiKhachHangPublic.MaLoaiKhachHang = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    loaiKhachHangPublic.TenLoaiKhachHang = dt.Rows[i].ItemArray[1].ToString();
                    list.Add(loaiKhachHangPublic);
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


        //Thêm vào loại khách hàng mới
        public void insert(LoaiKhachHangPublic loaiKhachHangPublic)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaLoaiKhachHang";

            values[0] = loaiKhachHangPublic.MaLoaiKhachHang;

            connect.ExcuteNonQuery("LoaiKhachHang_Insert", name, values, param);
        }

        //select by name
        //public DataTable selectAll(LoaiKhachHangPUBLIC loaiKhachHangPublic)
        //{
        //    return connect.getData("LoaiKhachHang_SelectByName");
        //}

        public List<LoaiKhachHangPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<LoaiKhachHangPublic> list = new List<LoaiKhachHangPublic>();
                LoaiKhachHangPublic loaiKhachHangPublic = new LoaiKhachHangPublic();
                

                int row;
                dt = connect.getData("LoaiKhachHang_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    loaiKhachHangPublic.MaLoaiKhachHang = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    loaiKhachHangPublic.TenLoaiKhachHang = dt.Rows[i].ItemArray[1].ToString();
                    list.Add(loaiKhachHangPublic);
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

        //Delete
        public void delete(LoaiKhachHangPublic loaiKhachHangPublic)
        {
            String procedureName = "LoaiKhachHang_Delete";
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@TenLoaiKhachHang";

            values[0] = loaiKhachHangPublic.TenLoaiKhachHang;

            connect.getData(procedureName,name,values,param);
        }

        //public List<LoaiKhachHangPUBLIC> delete(LoaiKhachHangPUBLIC loaiKhachHang)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        List<LoaiKhachHangPUBLIC> list = new List<LoaiKhachHangPUBLIC>();
        //        LoaiKhachHangPUBLIC loaiKhachHangPublic = new LoaiKhachHangPUBLIC();
        //        int param = 1;
        //        string[] name = new string[param];
        //        object[] values = new object[param];

        //        name[0] = "@TenLoaiKhachHang";

        //        values[0] = loaiKhachHangPublic.TenLoaiKhachHang;

        //        int row;
        //        dt = connect.getData("LoaiKhachHang_Delete",name,values,param);
        //        row = dt.Rows.Count;
        //        //for (int i = 0; i < row; i++)
        //        //{
        //            //loaiKhachHangPublic.MaLoaiKhachHang = int.Parse(dt.Rows[i].ItemArray[0].ToString());
        //            //loaiKhachHangPublic.TenLoaiKhachHang = dt.Rows[i].ItemArray[1].ToString();
        //            list.Add(loaiKhachHangPublic);
        //        //}
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