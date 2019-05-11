using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Try.Data;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;

namespace Try.DAL
{
    public class DataComponent
    {
        enum OverloadVersion
        {
            ConnectionString
            ,
            Connection
                , Transaction
        }
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        private DbProviderFactory _DBFactory;
        private DataAccessHelper _DbHelper;
        protected string _connectionString = "";

        public DataComponent()
        {
            _DbHelper = DataAccessHelper.GetDataAccessHelper();

            _DBFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            string coo = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            _connectionString = coo;
        }

        #region Methods

        #region Execute Methods

        protected DbDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            try
            {
                return DbHelper.ExecuteReader(_connectionString, commandType, commandText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            try
            {
                return DbHelper.ExecuteReader(_connectionString, commandType, commandText, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            try
            {
                return DbHelper.ExecuteDataSet(_connectionString, commandType, commandText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DataSet ExecuteDataSet(CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            try
            {
                return DbHelper.ExecuteDataSet(_connectionString, commandType, commandText, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ExecuteNonQuery(CommandType commandType, string commandText)
        {
            try
            {
                DbHelper.ExecuteNonQuery(_connectionString, commandType, commandText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            try
            {
                DbHelper.ExecuteNonQuery(_connectionString, commandType, commandText, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void GetSchemaInfo(string commandText, SqlConnection connection)
        //{
        //    using (connection)
        //    {
        //        SqlCommand command = new SqlCommand(commandText, connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        DataTable schemaTable = reader.GetSchemaTable();

        //        //foreach (DataRow row in schemaTable.Rows)
        //        //{
        //        //    foreach (DataColumn column in schemaTable.Columns)
        //        //    {

        //        //    }
        //        //}
        //    }
        //}

        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }
        }

        // Method to Select Data from Database
        public DataTable Select(string Stored, SqlParameter[] Param)
        {
            SqlCommand sqlcmd = new SqlCommand(Stored, sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored;
            sqlcmd.Connection = sqlcon;

            if (Param != null)
            {
                for (int i = 0; i < Param.Length; i++)
                {
                    sqlcmd.Parameters.Add(Param[i]);
                }
            }

            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            return dt;
        }

        private static void ReadOrderData(string connectionString)
        {
            string queryString =
                "SELECT OrderID, CustomerID FROM dbo.Orders;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                }

                reader.Close();
            }
        }

        // Method to Insert, Update, and Delete Data from Database
        protected void ExecuteCommand(string Stored, DbParameter[] Param)
        {
            SqlCommand sqlcmd = new SqlCommand(Stored, sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored;
            sqlcmd.Connection = sqlcon;
            Open();
            if (Param != null)
            {
                for (int i = 0; i < Param.Length; i++)
                {
                    sqlcmd.Parameters.Add(Param[i]);
                }
            }

            sqlcmd.ExecuteNonQuery();
            Close();
        }

        public void Open()
        {
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
        }

        public void Close()
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
        }

        protected object ExecuteScalar(CommandType commandType, string commandText)
        {
            try
            {
                return DbHelper.ExecuteScalar(_connectionString, commandType, commandText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] parameters)
        {
            try
            {

                return DbHelper.ExecuteScalar(_connectionString, commandType, commandText, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region DataSet
        protected void UpdateDataSet(DbCommand insertCommand, DbCommand deleteCommand, DbCommand updateCommand, DataSet dataSet, string tableName)
        {
            DbHelper.UpdateDataset(insertCommand, deleteCommand, updateCommand, dataSet, tableName);
        }

        #endregion

        #region Parameter Creation

        protected DbParameter CreateParameter(string name, object value)
        {

            //string conStr  = "";
            //conStr = ConfigurationManager.ConnectionStrings["INsConnectionString"].ConnectionString;

            //DbProviderFactory dbFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            //DbConnection dbConnection = dbFactory.CreateConnection();
            ////dbConnection.ConnectionString = conStr;
            //DbCommand dbCommand = 
                //dbFactory.CreateCommand();
           

            DbParameter param = DBFactory.CreateParameter()
                //dbCommand.CreateParameter();
                ;
            param.ParameterName = name;
            if (value is DateTime)
            {

                if (((DateTime)value).Year.ToString() == "1")
                    param.Value = null;
                else
                    param.Value = value;

            }
            else
                param.Value = value;

            return param;
        }
        protected DbParameter CreateParameter(string name, object value, ParameterDirection direction)
        {
            DbParameter param = CreateParameter(name, value);
            param.Direction = direction;
            return param;
        }
        protected DbParameter CreateParameter(string name, object value, DbType type)
        {
            DbParameter param = CreateParameter(name, value);
            param.DbType = type;

            return param;
        }
        protected DbParameter CreateParameter(string name, object value, DbType type, int size)
        {
            DbParameter param = CreateParameter(name, value);
            param.DbType = type;
            param.Size = size;

            return param;
        }
        protected DbParameter CreateParameter(string name, object value, DbType type, int size, ParameterDirection direction)
        {
            DbParameter param = CreateParameter(name, value);
            param.Direction = direction;
            param.DbType = type;
            param.Size = size;

            return param;
        }
        protected DbParameter CreateParameter(string name, object value, DbType type, ParameterDirection direction)
        {
            DbParameter param = CreateParameter(name, value);
            param.Direction = direction;
            param.DbType = type;

            return param;
        }

        protected DbParameter CreateIDParameter(int ID)
        {
            return CreateParameter("@ID", ID);
        }
        protected DbParameter[] CreateAddParameters(BasicData data)
        {
            return CreateAddParameters(data, 0);
        }
        protected DbParameter[] CreateAddParameters(BasicData data, int expectedParameterCount)
        {
            List<DbParameter> parameters = new List<DbParameter>(expectedParameterCount);
            parameters.Add(CreateParameter("@ID", null, DbType.Int32, ParameterDirection.ReturnValue));
            CreateParameters(data, parameters);
            CreateAddLogParameters(data, parameters);

            return parameters.ToArray();
        }
        protected DbParameter[] CreateUpdateParameters(BasicData data)
        {
            return CreateUpdateParameters(data, 0);
        }
        protected DbParameter[] CreateUpdateParameters(BasicData data, int expectedParameterCount)
        {
            List<DbParameter> parameters = new List<DbParameter>(expectedParameterCount);
            parameters.Add(CreateIDParameter(data.ID));
            CreateParameters(data, parameters);
            CreateUpdateLogParameters(data, parameters);

            return parameters.ToArray();
        }

        protected virtual void CreateParameters(BasicData data, List<DbParameter> parameters)
        {

        }

        //override with empty code in case no LOG parameters are needed
        protected virtual void CreateAddLogParameters(BasicData data, List<DbParameter> parameters)
        {
            //parameters.Add(CreateParameter("@UserID", BranchProfile.CurrentUserData.ID, DbType.String));
        }
        //override with empty code in case no LOG parameters are needed
        protected virtual void CreateUpdateLogParameters(BasicData data, List<DbParameter> parameters)
        {
            //if (data.GetType().GetProperty("ModifiedUserID") == null)
            //{
            //    parameters.Add(CreateParameter("@UserID", BranchProfile.CurrentUserData.ID, DbType.String));
            //}
            //else
            //{
            //    parameters.Add(CreateParameter("@ModifiedUserID", BranchProfile.CurrentUserData.ID, DbType.String));
            //}
        }
        #endregion

        #region DataReader

        protected int ReadInt32(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? 0 : reader.GetInt32(i);
        }

        protected int ReadInt32(DbDataReader reader, int i)
        {
            return reader.IsDBNull(i) ? 0 : reader.GetInt32(i);
        }

        protected int ReadTinyint(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? 0 : (int)reader.GetByte(i);
        }

        protected short ReadInt16(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? (short)0 : reader.GetInt16(i);
        }

        protected Int64 ReadInt64(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? (Int64)0 : reader.GetInt64(i);
        }

        protected bool ReadBoolean(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? false : reader.GetBoolean(i);
        }

        protected byte ReadByte(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? (byte)0 : reader.GetByte(i);
        }

        protected decimal ReadDecimal(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? 0 : reader.GetDecimal(i);
        }

        protected string ReadString(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? "" : reader.GetString(i).Trim();
        }

        //protected Image ReadImage(DbDataReader reader, string name)
        //{
        //    int i = reader.GetOrdinal(name);

        //    return reader.IsDBNull(i) ? default(Image) : Image.FromStream(new MemoryStream((byte[])reader.GetValue(i)));
        //}

        protected string ReadString(DbDataReader reader, int i)
        {
            return reader.IsDBNull(i) ? "" : reader.GetString(i).Trim();
        }

        protected object Readobject(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? "" : reader.GetValue(i);
        }

        protected DateTime ReadDate(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? Convert.ToDateTime("01/01/1900 12:00:00") : reader.GetDateTime(i);
        }

        protected TimeSpan ReadTimeSpan(DbDataReader reader, string name)
        {
            int i = reader.GetOrdinal(name);
            return reader.IsDBNull(i) ? TimeSpan.Parse("00:00:00") : TimeSpan.Parse(reader.GetDateTime(i).ToString());
        }

        protected DateTime ReadDate(DbDataReader reader, int i)
        {
            return reader.IsDBNull(i) ? Convert.ToDateTime("01/01/1900 12:00:00") : reader.GetDateTime(i);
        }

        protected void CloseReader(DbDataReader reader)
        {
            if (reader == null || reader.IsClosed)
                return;
            else
            {
                try
                {
                    reader.Close();
                }
                catch
                {; }

            }
        }

        public virtual BasicData GetFromReader(DbDataReader reader)
        {
            return null;
        }

        public virtual void SetSubDetails(BasicData basicdata)
        {
            return;
        }

        protected List<T> ReadList<T>(DbDataReader reader) where T : BasicData
        {
            List<T> list = new List<T>();
            T data;
            try
            {

                while (reader.Read())
                {
                    data = (T)GetFromReader(reader);
                    data.DataStatus = DataStatus.Saved;
                    list.Add(data);
                }

                return list;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            finally
            {
                CloseReader(reader);
            }
        }

        #endregion

        #region GetMethods
        protected T GetByID<T>(int ID, string procedureName) where T : BasicData
        {
            DbDataReader red = null;
            try
            {
                red = this.ExecuteReader(CommandType.StoredProcedure, procedureName, CreateIDParameter(ID));

                if (red.Read())
                {
                    T data = (T)GetFromReader(red);
                    data.DataStatus = DataStatus.Saved;
                    return data;
                }
                else
                    return null;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            finally
            {
                CloseReader(red);
            }
        }

        protected List<T> GetListByID<T>(int parentID, string parentIDName, string procedureName) where T : BasicData
        {
            DbDataReader red = null;

            try
            {
                red = this.ExecuteReader(CommandType.StoredProcedure, procedureName, CreateParameter(parentIDName, parentID));
                return ReadList<T>(red);
            }
            catch (DbException ex)
            {
                throw ex;
            }

        }

        protected List<T> GetAll<T>(string procedureName) where T : BasicData
        {
            DbDataReader reader = null;
            List<T> list = null;
            try
            {
                reader = this.ExecuteReader(CommandType.StoredProcedure, procedureName);
                list = ReadList<T>(reader);
                return list;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Properties

        private DataAccessHelper DbHelper
        {
            get
            { return _DbHelper; }
        }

        protected DbProviderFactory DBFactory
        {
            get { return _DBFactory; }
        }

        #endregion

    }
}
