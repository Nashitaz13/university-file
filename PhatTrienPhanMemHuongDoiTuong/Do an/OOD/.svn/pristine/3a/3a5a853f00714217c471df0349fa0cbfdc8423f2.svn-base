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


        public string ConnectionString = QLCHMT.Properties.Settings.Default.QLCHMTConnectionString;

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
                Application.Exit();
            }
            return connection;
        }

        public void disconnect()
        {
            connection.Close();
        }


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


        #region "executeQuery"
        public IDataReader executeQuery(string sqlString)
        {

            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }
        #endregion

        #region "executeNonQuery"
        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();
        }
        #endregion

    }
}
