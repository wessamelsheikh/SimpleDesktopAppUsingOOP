using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try.DAL;
using Try.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Try.DAL
{
    public class WindowsFormDal : DataComponent
    {
        public DataTable GetAll(string TableName)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT * FROM {0}", TableName);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            return dt;
        }

        public DataTable GetID(string TableName, string CodeField, int ID)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT * FROM {0} where {1} = {2}", TableName, CodeField,ID);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            return dt;
        }

        public WindowsFormData GetByID(string TableName)
        {
            WindowsFormData data = null;
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qury = string .Format("SELECT * FROM WindowsForm WHERE TableName = '{0}'" , TableName);
            SqlCommand command = new SqlCommand(qury, sqlconn);
            sqlconn.Open();

            SqlDataReader reader = command.ExecuteReader();
            //DataTable dt = reader.GetSchemaTable();

            //DbDataReader reader = ExecuteReader(CommandType.Text, string.Format("SELECT * FROM WindowsForm WHERE ID = {0}", id.ToString()));

            if (reader.Read())
            {
                data = (WindowsFormData)GetFromReader(reader);
            }

            return data;
        }

        public object GetNextCode(string Table, string Code)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT Count({0}) + 1 as NextCode FROM {1}", Code, Table);
            SqlCommand command = new SqlCommand(qry, sqlconn);
            
            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        public object GetNextID(string Table, string ID)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT (MAX({0}) + 1) as ID FROM {1}", ID, Table);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            SqlDataAdapter sqlda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            return dt.Rows[0][0].ToString();
        }

        public string GetFirst(string Table, string Code)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT Top(1){0} FROM {1}", Code, Table);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            if (sqlconn.State == ConnectionState.Closed)
            {sqlconn.Open();}
            
            string code = command.ExecuteScalar().ToString();
            
            if (sqlconn.State == ConnectionState.Open)
            { sqlconn.Close(); }

            return code;
        }

        public string GetLast(string Table, string Code)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT Top(1){0} FROM {1} Order By {0} Desc", Code, Table);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            if (sqlconn.State == ConnectionState.Closed)
            { sqlconn.Open(); }

            string code = command.ExecuteScalar().ToString();

            if (sqlconn.State == ConnectionState.Open)
            { sqlconn.Close(); }

            return code;
        }

        public string GetNext(string Table, string CodeField, string Code)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT Top(1){0} FROM {1} Where {0} > {2}", CodeField, Table, Code);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            if (sqlconn.State == ConnectionState.Closed)
            { sqlconn.Open(); }

            string code = command.ExecuteScalar().ToString();

            if (sqlconn.State == ConnectionState.Open)
            { sqlconn.Close(); }

            return code;
        }

        public string GetPrevious(string Table, string CodeField, string Code)
        {
            SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            string qry = string.Format("SELECT Top(1){0} FROM {1} Where {0} < {2} Order By {0} Desc", CodeField, Table, Code);
            SqlCommand command = new SqlCommand(qry, sqlconn);

            if (sqlconn.State == ConnectionState.Closed)
            { sqlconn.Open(); }

            string code = command.ExecuteScalar().ToString();

            if (sqlconn.State == ConnectionState.Open)
            { sqlconn.Close(); }

            return code;
        }

        public List<WindowsFormData> GetAll()
        {
            List<WindowsFormData> lvar = new List<WindowsFormData>();
            WindowsFormData data = null;
            DbDataReader reader = null;
            try
            {
                reader = ExecuteReader(CommandType.StoredProcedure, "WindowsFormGetAll");
                while (reader.Read())
                {
                    data = (WindowsFormData)GetFromReader(reader);
                    lvar.Add(data);
                }
                return lvar;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseReader(reader);
            }
        }
        //public int Add(WindowsFormData WindowsFormDataData)
        //{
        //    try
        //    {
        //        DbParameter[] Parameters = CreateAddParameters(WindowsFormDataData);
        //        ExecuteNonQuery(CommandType.StoredProcedure, "CityAdd", Parameters);
        //        WindowsFormDataData.ID = (int)Parameters[0].Value;
        //        return WindowsFormDataData.ID;
        //    }
        //    catch (DbException ex)
        //    {
        //        throw ex;

        //    }
        //}

        //public void update(WindowsFormData WindowsFormDataData)
        //{
        //    try
        //    {
        //        this.ExecuteNonQuery(CommandType.StoredProcedure, "CityUpdate", CreateUpdateParameters(WindowsFormDataData));
        //    }
        //    catch (DbException ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(WindowsFormData WindowsFormDataData)
        //{
        //    List<DbParameter> Parameters = new List<DbParameter>();
        //    Parameters.Add(CreateParameter("@ID", WindowsFormDataData.ID));
        //    this.ExecuteNonQuery(CommandType.StoredProcedure, "CityDELETE", Parameters.ToArray());

        //}

        protected override void CreateParameters(BasicData data, List<DbParameter> parameters)
        {
            WindowsFormData WindowsFormData = (WindowsFormData)data;
            parameters.Add(CreateParameter("@ID", WindowsFormData.ID));
            parameters.Add(CreateParameter("@TableName", WindowsFormData.TableName));
            parameters.Add(CreateParameter("@DalClass", WindowsFormData.DalClass));
            parameters.Add(CreateParameter("@DataClass", WindowsFormData.DataClass));
            parameters.Add(CreateParameter("@LogicClass", WindowsFormData.LogicClass));
            parameters.Add(CreateParameter("@IDField", WindowsFormData.IDField));
            parameters.Add(CreateParameter("@CodeField", WindowsFormData.CodeField));
            parameters.Add(CreateParameter("@ArabicField", WindowsFormData.ArabicField));
            parameters.Add(CreateParameter("@EnglishField", WindowsFormData.EnglishField));
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            WindowsFormData WindowsFormData = new WindowsFormData();
            WindowsFormData.ID = this.ReadInt32(reader, "ID");
            WindowsFormData.TableName = this.ReadString(reader, "TableName");
            WindowsFormData.DalClass = this.ReadString(reader, "DalClass");
            WindowsFormData.DataClass = this.ReadString(reader, "DataClass");
            WindowsFormData.LogicClass = this.ReadString(reader, "LogicClass");
            WindowsFormData.IDField = this.ReadString(reader, "IDField");
            WindowsFormData.CodeField = this.ReadString(reader, "CodeField");
            WindowsFormData.ArabicField = this.ReadString(reader, "ArabicField");
            WindowsFormData.EnglishField = this.ReadString(reader, "EnglishField");
            return WindowsFormData;
        }
    }
}
