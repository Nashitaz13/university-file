using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachSanDAL
{
    public class DataProvider
    {
        //MoKetNoi
        public static SqlConnection OpenConnect()
        {
            string sChuoiKetNoi = @"Data Source=PHANYBIEN;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
            SqlConnection connect;
            connect = new SqlConnection(sChuoiKetNoi);
            connect.Open();
            return connect;
        }
        //Dong ket noi
        public static void CloseConnect(SqlConnection connect)
        {
            connect.Close();
        }

        //Lay Data Table
        public static DataTable GetDataTable(string sTruyVan,SqlConnection connect)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, connect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Thuc Thi Truy Van 
        public static bool ThucThiTruyVanNonQuery(string sTruyVan, SqlConnection connect)
        {
            try
            {
                SqlCommand cm = new SqlCommand(sTruyVan, connect);
                cm.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
