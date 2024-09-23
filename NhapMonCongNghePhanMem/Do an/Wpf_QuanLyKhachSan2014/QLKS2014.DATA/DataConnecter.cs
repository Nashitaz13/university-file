using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace QLKS2014.DATA
{
    public class DataConnecter
    {
        SqlConnection connect = new SqlConnection();
        string connectstr;

        public DataConnecter()
        {
            connectstr = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            connect.ConnectionString = connectstr;
            if (connect.State == ConnectionState.Closed)
                try
                {
                    connect.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
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
        public DataTable getData(string sql, string[] name, object[] value, int param)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
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

        public int ExcuteNonQuery(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Không tương tác được dữ liệu");
                return 0;
            }
        }
        public int ExcuteNonQuery(string sql, string[] name, object[] value, int param)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
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
