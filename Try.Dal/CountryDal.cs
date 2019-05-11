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
    public class CountryDal : DataComponent
    {
        public int Add(CountryData CountryData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(CountryData);
                ExecuteNonQuery(CommandType.StoredProcedure, "CountryAdd", Parameters);
                //ExecuteCommand("CountryAdd", Parameters);
                CountryData.ID = (int)Parameters[0].Value;
                return CountryData.ID;
            }
            catch (DbException ex)
            {
                throw ex;

            }
        }

        public int update(CountryData CountryData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(CountryData);
                ExecuteNonQuery(CommandType.StoredProcedure, "CountryUpdate", Parameters);
                //ExecuteCommand("CountryUpdate", Parameters);
                //CountryData.ID = (int)Parameters[0].Value;
                return CountryData.ID;

                //this.ExecuteNonQuery(CommandType.StoredProcedure, "CountryUpdate", CreateUpdateParameters(CountryData));
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int Delete(CountryData CountryData)
        {
            DbParameter[] Parameters = CreateAddParameters(CountryData);
            ExecuteNonQuery(CommandType.StoredProcedure, "CountryDelete", Parameters);
            //ExecuteCommand("CountryDelete", Parameters);
            return CountryData.ID;

            //List<DbParameter> Parameters = new List<DbParameter>();
            //Parameters.Add(CreateParameter("@ID", CountryData.ID));
            //this.ExecuteNonQuery(CommandType.StoredProcedure, "CountryDelete", Parameters.ToArray());

        }

        public CountryData GetCountryDataByID(string ID)
        {
            CountryData CountryData = new CountryData();
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From Country Where Code = {0}", ID), connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CountryData = (CountryData)GetFromReader(reader);
                    }
                }
                return CountryData;
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

        public List<CountryData> GetAll()
        {
            List<CountryData> Lvar = new List<CountryData>();
            CountryData CountryData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("CountryGetAll", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CountryData = (CountryData)GetFromReader(reader);
                        Lvar.Add(CountryData);
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
            CountryData CountryData = (CountryData)data;

            if (CountryData.DataStatus != DataStatus.New)
            {
                parameters.Add(CreateParameter("@ID", CountryData.ID));
            }

            if (CountryData.DataStatus != DataStatus.Deleted)
            {
                parameters.Add(CreateParameter("@Code", CountryData.Code));
                parameters.Add(CreateParameter("@ArabicName", CountryData.ArabicName));
                parameters.Add(CreateParameter("@EnglishName", CountryData.EnglishName));
            }
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            CountryData CountryData = new CountryData();
            CountryData.ID = this.ReadInt32(reader, "ID");
            CountryData.Code = this.ReadString(reader, "Code");
            CountryData.ArabicName = this.ReadString(reader, "ArabicName");
            CountryData.EnglishName = this.ReadString(reader, "EnglishName");

            return CountryData;
        }
    }
}
