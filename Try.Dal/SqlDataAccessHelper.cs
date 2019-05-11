using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Try.DAL
{
    public class SqlDataAccessHelper : DataAccessHelper
    {

        public override DbDataReader ExecuteReader(string connectionsString, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteReader(connectionsString, commandType, commandText);
        }

        public override DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteReader((SqlConnection)connection, commandType, commandText);
        }

        public override DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteReader((SqlTransaction)transaction, commandType, commandText);
        }

        public override DbDataReader ExecuteReader(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteReader(connectionsString, commandType, commandText, Array.ConvertAll<DbParameter, SqlParameter>(parameters, new Converter<DbParameter, SqlParameter>(DBParameterToSqlParameter)));
        }

        public override DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteReader((SqlConnection)connection, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteReader((SqlTransaction)transaction, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override DataSet ExecuteDataSet(string connectionsString, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteDataset(connectionsString, commandType, commandText);
        }

        public override DataSet ExecuteDataSet(DbConnection connection, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteDataset((SqlConnection)connection, commandType, commandText);
        }

        public override DataSet ExecuteDataSet(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteDataset((SqlTransaction)transaction, commandType, commandText);
        }

        public override DataSet ExecuteDataSet(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset(connectionsString, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override DataSet ExecuteDataSet(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset((SqlConnection)connection, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override DataSet ExecuteDataSet(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteDataset((SqlTransaction)transaction, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override void UpdateDataset(DbCommand insertCommand, DbCommand deleteCommand, DbCommand updateCommand, DataSet dataSet, string tableName)
        {
            SqlHelper.UpdateDataset((SqlCommand)insertCommand, (SqlCommand)deleteCommand, (SqlCommand)updateCommand,dataSet,tableName);
        }

        public override void ExecuteNonQuery(string connectionsString, CommandType commandType, string commandText)
        {
            SqlHelper.ExecuteNonQuery(connectionsString, commandType, commandText);
        }

        public override void ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText)
        {
            SqlHelper.ExecuteNonQuery((SqlConnection)connection, commandType, commandText);
        }

        public override void ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText)
        {
            SqlHelper.ExecuteNonQuery((SqlTransaction)transaction, commandType, commandText);
        }

        public override void ExecuteNonQuery(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            SqlHelper.ExecuteNonQuery(connectionsString, commandType, commandText,Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override void ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            SqlHelper.ExecuteNonQuery((SqlConnection)connection, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override void ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            SqlHelper.ExecuteNonQuery((SqlTransaction)transaction, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override object ExecuteScalar(string connectionsString, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteScalar(connectionsString, commandType, commandText);
        }

        public override object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteScalar((SqlConnection)connection, commandType, commandText);
        }

        public override object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteScalar((SqlTransaction)transaction, commandType, commandText);
        }

        public override object ExecuteScalar(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteScalar(connectionsString, commandType, commandText,Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteScalar((SqlConnection)connection, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        public override object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            return SqlHelper.ExecuteScalar((SqlTransaction)transaction, commandType, commandText, Array.ConvertAll<DbParameter,SqlParameter>(parameters,new Converter<DbParameter,SqlParameter>(DBParameterToSqlParameter)));
        }

        private SqlParameter DBParameterToSqlParameter(DbParameter param)
        {
            return (SqlParameter)param;
        }


    }
}
