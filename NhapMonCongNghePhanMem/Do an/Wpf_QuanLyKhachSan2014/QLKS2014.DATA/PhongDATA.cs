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
    public class PhongData
    {
        DataConnecter connect;
        public PhongData()
        {
            connect = new DataConnecter();
        }

        public List<PhongPublic> selectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                List<PhongPublic> list = new List<PhongPublic>();
                PhongPublic phongPublic = new PhongPublic();
                int row;
                dt = connect.getData("Phong_SelectAll");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    phongPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    phongPublic.TenPhong = dt.Rows[i].ItemArray[1].ToString();
                    phongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    phongPublic.TinhTrang = dt.Rows[i].ItemArray[3].ToString();
                    list.Add(phongPublic);
                }
                return list;
            }
            catch(Exception ex)
            {
                //bao loi
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //public DataTable selectAll()
        //{
        //    String procedureName = "Phong_SelectAll";
        //    return connect.getData(procedureName);
        //}

        public void deleteById(PhongPublic phongPublic)
        {
            String procedureName = "Phong_DeleteById";
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaPhong";

            values[0] = phongPublic.MaPhong;

            connect.getData(procedureName,name,values,param);
        }

        //public List<PhongPUBLIC> deleteById(PhongPUBLIC phong)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        List<PhongPUBLIC> list = new List<PhongPUBLIC>();
        //        PhongPUBLIC phongPublic = new PhongPUBLIC();

        //        int param = 1;
        //        string[] name = new string[param];
        //        object[] values = new object[param];
        //        name[0] = "@MaPhong";
        //        values[0] = phong.MaPhong;

        //        //int row;
        //        dt = connect.getData("Phong_DeleteById",name,values,param);
        //        //row = dt.Rows.Count;
        //        //for (int i = 0; i < row; i++)
        //        //{
        //            //phongPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
        //            //phongPublic.TenPhong = dt.Rows[i].ItemArray[1].ToString();
        //            //phongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
        //            //phongPublic.TinhTrang = dt.Rows[i].ItemArray[3].ToString();
        //            list.Add(phongPublic);
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

        //public DataTable selectByTenLoaiPhong(LoaiPhongPUBLIC loaiphongPublic)
        //{
        //    String procedureName = "Phong_SelectByTenLoaiPhong";
        //    int param = 2;
        //    string[] name = new string[param];
        //    object[] values = new object[param];

        //    name[0] = "@TenLoaiPhong";

        //    values[0] = loaiphongPublic.TenLoaiPhong;

        //    return connect.getData(procedureName);
        //}

        public List<PhongPublic> selectByTenLoaiPhong(LoaiPhongPublic loaiPhong)
        {
            try
            {
                DataTable dt = new DataTable();
                List<PhongPublic> list = new List<PhongPublic>();
                PhongPublic phongPublic = new PhongPublic();

                int param = 1;
                string[] name = new string[param];
                object[] values = new object[param];

                name[0] = "@TenLoaiPhong";

                values[0] = loaiPhong.TenLoaiPhong;

                int row;
                dt = connect.getData("Phong_SelectByTenLoaiPhong",name,values,param);
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    phongPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    phongPublic.TenPhong = dt.Rows[i].ItemArray[1].ToString();
                    phongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    phongPublic.TinhTrang = dt.Rows[i].ItemArray[3].ToString();
                    list.Add(phongPublic);
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

        public void insert(PhongPublic phongPublic)
        {
            int param = 1;
            string[] name = new string[param];
            object[] values = new object[param];

            name[0] = "@MaPhong";

            values[0] = phongPublic.MaPhong;

            connect.ExcuteNonQuery("Phong_Insert", name, values, param);
        }

        //public DataTable selectByRentTime(DateTime ngayDau, DateTime ngayCuoi)
        //{
        //    string procedureSelectByRentTime = "Phong_SelectByRentTime";
        //    return connect.getData(procedureSelectByRentTime);
        //}

        public List<PhongPublic> selectByRentTime(DateTime ngayDau, DateTime ngayCuoi)
        {
            try
            {
                DataTable dt = new DataTable();
                List<PhongPublic> list = new List<PhongPublic>();
                PhongPublic phongPublic = new PhongPublic();
                int row;
                dt = connect.getData("Phong_SelectByRentTime");
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    phongPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    phongPublic.TenPhong = dt.Rows[i].ItemArray[1].ToString();
                    phongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    phongPublic.TinhTrang = dt.Rows[i].ItemArray[3].ToString();
                    list.Add(phongPublic);
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


        public int update(PhongPublic phongPublic)
        {
            int param = 4;
            string[] name = new string[param];
            object[] values = new object[param];
            name[0] = "@MaPhong";
            name[1] = "@TenPhong";
            name[2] = "@MaLoaiPhong";
            name[3] = "@GhiChu";

            values[0] = phongPublic.MaPhong;
            values[1] = phongPublic.TenPhong;
            values[2] = phongPublic.MaLoaiPhong;
            values[3] = phongPublic.GhiChu;

            String procedureName = "Phong_Update";
            return connect.ExcuteNonQuery(procedureName,name,values,param);
        }

        //Tìm Phòng Trống
        //public DataTable selectPhongEmpty(PhongPUBLIC phongPublic)
        //{
        //    String procedureName = "Phong_SelectPhongEmpty";
        //    int param = 1;
        //    string[] name = new string[param];
        //    object[] values = new object[param];

        //    name[0] = "@TenPhong";

        //    values[0] = phongPublic.TenPhong;

        //    return connect.getData(procedureName);
        //}

        public List<PhongPublic> selectPhongEmpty(PhongPublic phong)
        {
            try
            {
                DataTable dt = new DataTable();
                List<PhongPublic> list = new List<PhongPublic>();
                PhongPublic phongPublic = new PhongPublic();

                int param = 1;
                string[] name = new string[param];
                object[] values = new object[param];

                name[0] = "@TenPhong";

                values[0] = phong.TenPhong;

                int row;
                dt = connect.getData("Phong_SelectPhongEmpty",name,values,param);
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    phongPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    phongPublic.TenPhong = dt.Rows[i].ItemArray[1].ToString();
                    phongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    phongPublic.TinhTrang = dt.Rows[i].ItemArray[3].ToString();
                    list.Add(phongPublic);
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


        //Tìm Phòng Đã Thuê
        //public DataTable selectPhongNotEmpty(PhongPUBLIC phongPublic)
        //{
        //    String procedureName = "Phong_SelectPhongNotEmpty";
        //    int param = 1;
        //    string[] name = new string[param];
        //    object[] values = new object[param];

        //    name[0] = "@TenPhong";

        //    values[0] = phongPublic.TenPhong;

        //    return connect.getData(procedureName);
        //}

        public List<PhongPublic> selectPhongNotEmpty(PhongPublic phong)
        {
            try
            {
                DataTable dt = new DataTable();
                List<PhongPublic> list = new List<PhongPublic>();
                PhongPublic phongPublic = new PhongPublic();

                int param = 1;
                string[] name = new string[param];
                object[] values = new object[param];

                name[0] = "@TenPhong";

                values[0] = phong.TenPhong;

                int row;
                dt = connect.getData("Phong_SelectPhongNotEmpty",name,values,param);
                row = dt.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    phongPublic.MaPhong = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    phongPublic.TenPhong = dt.Rows[i].ItemArray[1].ToString();
                    phongPublic.MaLoaiPhong = int.Parse(dt.Rows[i].ItemArray[2].ToString());
                    phongPublic.TinhTrang = dt.Rows[i].ItemArray[3].ToString();
                    list.Add(phongPublic);
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