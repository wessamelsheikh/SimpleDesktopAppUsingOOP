using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try.Data;

namespace Try.DAL
{
    public class Sales_HeadDal : DataComponent
    {
        public int Add(Sales_HeadData Sales_HeadData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(Sales_HeadData);
                ExecuteNonQuery(CommandType.StoredProcedure, "Sales_HeadAdd", Parameters);
                //ExecuteCommand("Sales_HeadAdd", Parameters);
                Sales_HeadData.ID = (int)Parameters[0].Value;
                return Sales_HeadData.ID;
            }
            catch (DbException ex)
            {
                throw ex;

            }
        }

        public int update(Sales_HeadData Sales_HeadData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(Sales_HeadData);
                ExecuteNonQuery(CommandType.StoredProcedure, "Sales_HeadUpdate", Parameters);
                //ExecuteCommand("Sales_HeadUpdate", Parameters);
                //Sales_HeadData.ID = (int)Parameters[0].Value;
                return Sales_HeadData.ID;

                //this.ExecuteNonQuery(CommandType.StoredProcedure, "Sales_HeadUpdate", CreateUpdateParameters(Sales_HeadData));
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int Delete(Sales_HeadData Sales_HeadData)
        {
            DbParameter[] Parameters = CreateAddParameters(Sales_HeadData);
            ExecuteNonQuery(CommandType.StoredProcedure, "Sales_HeadDelete", Parameters);
            //ExecuteCommand("Sales_HeadDelete", Parameters);
            return Sales_HeadData.ID;

            //List<DbParameter> Parameters = new List<DbParameter>();
            //Parameters.Add(CreateParameter("@ID", Sales_HeadData.ID));
            //this.ExecuteNonQuery(CommandType.StoredProcedure, "Sales_HeadDelete", Parameters.ToArray());

        }

        public Sales_HeadData GetSales_HeadData(string ID)
        {
            Sales_HeadData Sales_HeadData = new Sales_HeadData();
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From Sales_Head Where Sales_Code = {0}", ID), connection);
                    if (command.Connection.State == ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }
                    
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sales_HeadData = (Sales_HeadData)GetFromReader(reader);
                    }
                }
                return Sales_HeadData;
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

        public List<Sales_HeadData> GetAll()
        {
            List<Sales_HeadData> Lvar = new List<Sales_HeadData>();
            Sales_HeadData Sales_HeadData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("Sales_HeadGetAll", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sales_HeadData = (Sales_HeadData)GetFromReader(reader);
                        Lvar.Add(Sales_HeadData);
                    }
                }
                return Lvar;
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

        protected override void CreateParameters(BasicData data, List<DbParameter> parameters)
        {
            Sales_HeadData Sales_HeadData = (Sales_HeadData)data;

            if (Sales_HeadData.DataStatus != DataStatus.New)
            {
                parameters.Add(CreateParameter("@ID", Sales_HeadData.ID));
            }

            if (Sales_HeadData.DataStatus != DataStatus.Deleted)
            {
                parameters.Add(CreateParameter("@Sales_Code", Sales_HeadData.Sales_Code));
                parameters.Add(CreateParameter("@Sales_ArabicName", Sales_HeadData.Sales_ArabicName));
                parameters.Add(CreateParameter("@Sales_EnglishName", Sales_HeadData.Sales_EnglishName));
            }
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            Sales_HeadData Sales_HeadData = new Sales_HeadData();
            Sales_HeadData.ID = this.ReadInt32(reader, "Sales_ID");
            Sales_HeadData.Sales_Code = this.ReadString(reader, "Sales_Code");
            Sales_HeadData.Sales_ArabicName = this.ReadString(reader, "Sales_ArabicName");
            Sales_HeadData.Sales_EnglishName = this.ReadString(reader, "Sales_EnglishName");

            return Sales_HeadData;
        }
    }
}
