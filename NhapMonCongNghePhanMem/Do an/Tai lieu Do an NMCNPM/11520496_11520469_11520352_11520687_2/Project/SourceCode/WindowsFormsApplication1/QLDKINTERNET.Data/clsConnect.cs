using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace QLDKINTERNET.Data
{
    class clsConnect
    {
        SqlConnection con = new SqlConnection();

        string connectstring;// = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
        //string connectstring = "Server=FLASH;Database=QUANLYINTERNET;Trusted_Connection=True;";

       /* SqlConnection con = new SqlConnection();
        string connectstring = "Server=FLASH;Database=QUANLYINTERNET;Trusted_Connection=True;";*/

        public clsConnect()
        {
            connectstring = ConfigurationManager.ConnectionStrings["project"].ConnectionString;

            con.ConnectionString = connectstring;
            if (con.State == ConnectionState.Closed)
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            /*
            con.ConnectionString = connectstring;
            if (con.State == ConnectionState.Closed)
                try
                {
                    con.Open();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
             * */
        }

        //Select Toan Bo
        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(dt);
                return dt;
            }
            catch
            {
                MessageBox.Show("Không thể load dữ liệu");
                return dt;
            }
        }

        //Select Co Tham So
        public DataTable getData(string sql, string[] name, object[] value, int param)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < param; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], value[i]);
                }
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(dt);
                return dt;
            }
            catch
            {
                MessageBox.Show("Không thể load dữ liệu");
                return dt;
            }
        }

        //Insert , Update , Delete 
        public int ExcuteNonQuery(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Không tương tác được dữ liệu");
                return 0;
            }
        }

        //Insert , Update , Delete Co Tham So
        public int ExcuteNonQuery(string sql, string[] name, object[] value, int param)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < param; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], value[i]);
                }
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Không tương tác được dữ liệu");
                return 0;
            }
        }
    }
}
