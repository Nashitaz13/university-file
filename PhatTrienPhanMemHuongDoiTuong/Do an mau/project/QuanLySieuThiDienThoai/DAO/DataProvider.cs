using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAO
{
    public class DataProvider
    {
        protected static string _connectionString;

        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;


        public string ConnectionString = QuanLySieuThiDienThoai.Properties.Settings.Default.QLSTDTConnectionString;

        public SqlConnection connect()
        {
            connection = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nỗi cơ sở dữ liệu\n Liên hệ admin để được giúp đỡ", "Lỗi kết nối cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return connection;
        }

        public void disconnect()
        {
            connection.Close();
        }


        // Sử dụng procedure có Parameter
        #region "executeQueryParameter"
        public IDataReader executeQueryParameter(string sqlString, List<SqlParameter> List_para)
        {

            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter para in List_para)
            {
                command.Parameters.Add(para);
            }

            return command.ExecuteReader();
        }
        #endregion


        // Sử dụng procedure KHÔNG có Parameter
        #region "executeQuery"
        public IDataReader executeQuery(string sqlString)
        {

            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }
        #endregion

        // Sử dụng trực tiếp câu lệnh SQL
        #region "executeNonQuery"
        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            //command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }
        #endregion

    }
}
