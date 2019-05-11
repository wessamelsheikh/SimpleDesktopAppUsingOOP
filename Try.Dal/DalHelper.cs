using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Try.DAL
{
    public static class DalHelper
    {
        public static SqlTransaction _transaction;

        public static void OpenTransaction()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            con.Open();
            _transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public static void CommitTransaction()
        {
            _transaction.Commit();
        }

        public static void RollbackTransaction()
        {
            if (_transaction != null && _transaction.Connection != null)
                _transaction.Rollback();

        }

        public static void ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] parameters)
        {

            if (_transaction != null && _transaction.Connection != null)
                SqlHelper.ExecuteNonQuery(_transaction, commandType, commandText, parameters);
            else
                SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString, commandType, commandText, parameters);

        }

        public static SqlDataReader ExecuteReader(CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            if (_transaction != null && _transaction.Connection != null)
                return SqlHelper.ExecuteReader(_transaction, commandType, commandText, parameters);
            else
                return SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString, commandType, commandText, parameters);
        }

        public static object ExecuteScalar(CommandType commandType, string commandText)
        {
            if (_transaction != null && _transaction.Connection != null)
                return SqlHelper.ExecuteScalar(_transaction, commandType, commandText);
            else
                return SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString, commandType, commandText);
        }



        public static DataTable ReadTable(string commandText, SqlConnection nCN, SqlTransaction nSQLTrans = null)
        {

            SqlCommand cmd = new SqlCommand(commandText, nCN, nSQLTrans);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable ReadTable(string commandText)
        {
            try
            {
                string ConnectionString = "";
                ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                DataTable result = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = string.Format(commandText);
                        sqlCommand.CommandType = CommandType.Text;

                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        sqlAdapter.Fill(result);
                    }
                }
                return result;
            }
            catch
            {
                return new DataTable();
            }

            //SqlDataAdapter da = new SqlDataAdapter(commandText, ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            //DataTable dt = new DataTable();
            //if (commandText != "")
            //{
            //    da.Fill(dt);
            //}

            //return dt;
        }
       public static DataTable ReadTable1(string commandText)
        {
            DataTable dt = new DataTable();
            string connection = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            OleDbConnection con = new OleDbConnection(connection);
            using (OleDbCommand cmd = new OleDbCommand(commandText, con))
            {
                dt.Rows.Clear();
                dt.Load(cmd.ExecuteReader(CommandBehavior.SingleResult));
            }

            //SqlDataAdapter da = new SqlDataAdapter(commandText, iCore.iMain.connection.ConnectionString);
            
            //if (commandText != "")
            //{
            //    da.Fill(dt);
            //}

            return dt;
        }
        





        public static DataTable ReadTableEX(string commandText)
        {



            SqlCommand cmd = new SqlCommand(commandText, DalHelper._transaction.Connection, DalHelper._transaction);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            return dt;
        }




        public static SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            
            if (_transaction != null && _transaction.Connection != null)
                return SqlHelper.ExecuteReader(_transaction, commandType, commandText);
            else
                return SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString, commandType, commandText);

        }

        public static DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            if (_transaction != null && _transaction.Connection != null)
                return SqlHelper.ExecuteDataset(_transaction, commandType, commandText);
            else
                return SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString, commandType, commandText);

        }



    }
}
