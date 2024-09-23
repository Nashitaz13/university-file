using CommonLayer;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public static class SqlQuery
    {
        public static DataTable readSQL(string sql)
        {
            try
            {
                return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.Text, sql).Tables[0];

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable readSQL(string sql, SqlParameter[] listPara)
        {
            try
            {
                return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.Text,sql,listPara).Tables[0];

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static void writeSQL(string sql)
        {
           
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlHelper.ExecuteDataset(tran, CommandType.Text, sql);
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        public static void writeSQL(string sql, SqlParameter[] listPara)
        {
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                SqlHelper.ExecuteDataset(tran, CommandType.Text, sql, listPara);
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataTable readProcedure(string procedureName)
        {
            try
            {
                return SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.StoredProcedure, procedureName).Tables[0];

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public static DataTable readProcedure(string procedureName, SqlParameter[] listPara)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Constants.ConnectionString);
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                dt = SqlHelper.ExecuteDataset(tran, CommandType.StoredProcedure, procedureName,listPara).Tables[0];
                tran.Commit();
                con.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }
    }
}
