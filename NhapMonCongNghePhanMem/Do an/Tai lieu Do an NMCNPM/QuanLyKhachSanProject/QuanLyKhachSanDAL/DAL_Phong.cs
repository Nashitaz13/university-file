using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSanEntity;

namespace QuanLyKhachSanDAL
{
    public class DAL_Phong
    {
        static SqlConnection connect;
        public static DataTable LoadDuLieuPhong(){
            string sTruyVan = "Select * From Phong";
            //Mở Kết Nối
            connect = DataProvider.OpenConnect();
            //Truy vấn vào CSDL để lấy dữ liệu về kết quả đổ vào đối tượng datatable
            DataTable dt = DataProvider.GetDataTable(sTruyVan, connect);
            //đóng kết nối
            DataProvider.CloseConnect(connect);
            return dt;
        }
    }
}
