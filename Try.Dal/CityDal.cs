using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try.DAL;
using Try.Data;

namespace Try.DAL
{
    public class CityDal : DataComponent
    {
        public int Add(CityData CityData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(CityData);
                ExecuteNonQuery(CommandType.StoredProcedure, "CityAdd", Parameters);
                //ExecuteCommand("CityAdd", Parameters);
                CityData.ID = (int)Parameters[0].Value;
                return CityData.ID;
            }
            catch (DbException ex)
            {
                throw ex;

            }
        }

        public int update(CityData CityData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(CityData);
                ExecuteNonQuery(CommandType.StoredProcedure, "CityUpdate", Parameters);
                //ExecuteCommand("CityUpdate", Parameters);
                //CityData.ID = (int)Parameters[0].Value;
                return CityData.ID;

                //this.ExecuteNonQuery(CommandType.StoredProcedure, "CityUpdate", CreateUpdateParameters(CityData));
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int Delete(CityData CityData)
        {
            DbParameter[] Parameters = CreateAddParameters(CityData);
            ExecuteNonQuery(CommandType.StoredProcedure, "CityDelete", Parameters);
            //ExecuteCommand("CityDelete", Parameters);
            return CityData.ID;

            //List<DbParameter> Parameters = new List<DbParameter>();
            //Parameters.Add(CreateParameter("@ID", CityData.ID));
            //this.ExecuteNonQuery(CommandType.StoredProcedure, "CityDelete", Parameters.ToArray());

        }

        public CityData GetCityDataByID(string ID)
        {
            CityData CityData = new CityData();
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From City Where Code = {0}", ID), connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CityData = (CityData)GetFromReader(reader);
                    }
                }
                return CityData;
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

        public List<CityData> GetAll()
        {
            List<CityData> Lvar = new List<CityData>();
            CityData CityData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("CityGetAll", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CityData = (CityData)GetFromReader(reader);
                        Lvar.Add(CityData);
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
            CityData CityData = (CityData)data;
            if (CityData.DataStatus != DataStatus.New)
            {
                parameters.Add(CreateParameter("@ID", CityData.ID));
            }

            if (CityData.DataStatus != DataStatus.Deleted)
            {
                parameters.Add(CreateParameter("@Code", CityData.Code));
                parameters.Add(CreateParameter("@ArabicName", CityData.ArabicName));
                parameters.Add(CreateParameter("@EnglishName", CityData.EnglishName));
                parameters.Add(CreateParameter("@CountryID", CityData.CountryID));
            }
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            CityData CityData = new CityData();
            CityData.ID = this.ReadInt32(reader, "ID");
            CityData.Code = this.ReadString(reader, "Code");
            CityData.ArabicName = this.ReadString(reader, "ArabicName");
            CityData.EnglishName = this.ReadString(reader, "EnglishName");
            CityData.CountryID = this.ReadInt32(reader, "CountryID");
            return CityData;
        }
    }
}
