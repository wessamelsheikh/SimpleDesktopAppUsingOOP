using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.IO;
namespace Try.DAL
{
    public abstract class DataAccessHelper
    {

        internal static DataAccessHelper GetDataAccessHelper()
        {
            string assemblyFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Try.DAL.DLL";
            string typeName = "Try.DAL.SqlDataAccessHelper";

            System.Runtime.Remoting.ObjectHandle obj = Activator.CreateInstanceFrom(assemblyFile, typeName);

            if (obj != null)
            {
                return (DataAccessHelper)obj.Unwrap();
            }
            else
            {
                throw new Exception("Cannot load the DB Helper");
            }
        }

        //#region Helper Methods

        public abstract DbDataReader ExecuteReader(string connectionsString, CommandType commandType, string commandText);
        public abstract DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText);
        public abstract DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText);

        public abstract DbDataReader ExecuteReader(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters);

        public abstract DataSet ExecuteDataSet(string connectionsString, CommandType commandType, string commandText);
        public abstract DataSet ExecuteDataSet(DbConnection connection, CommandType commandType, string commandText);
        public abstract DataSet ExecuteDataSet(DbTransaction transaction, CommandType commandType, string commandText);

        public abstract DataSet ExecuteDataSet(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract DataSet ExecuteDataSet(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract DataSet ExecuteDataSet(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters);

        public abstract void UpdateDataset(DbCommand insertCommand, DbCommand deleteCommand, DbCommand updateCommand, DataSet dataSet, string tableName);

        public abstract void ExecuteNonQuery(string connectionsString, CommandType commandType, string commandText);
        public abstract void ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText);
        public abstract void ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText);

        public abstract void ExecuteNonQuery(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract void ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract void ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters);

        public abstract object ExecuteScalar(string connectionsString, CommandType commandType, string commandText);
        public abstract object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText);
        public abstract object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText);

        public abstract object ExecuteScalar(string connectionsString, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] parameters);
        public abstract object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parameters);




        //#endregion
    }
}
