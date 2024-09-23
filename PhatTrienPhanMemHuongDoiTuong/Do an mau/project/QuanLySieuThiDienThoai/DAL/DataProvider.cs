using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DataProvider
    {
        protected static string _connectionString;

        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;


        public string ConnectionString = @"Data Source=(local);Initial Catalog=QLSTDT;Integrated Security=True";
        
        public void connect()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

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
