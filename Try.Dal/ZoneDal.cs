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
    public class ZoneDal : DataComponent
    {
        public int Add(ZoneData ZoneData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(ZoneData);
                ExecuteNonQuery(CommandType.StoredProcedure, "ZoneAdd", Parameters);
                //ExecuteCommand("ZoneAdd", Parameters);
                ZoneData.ID = (int)Parameters[0].Value;
                return ZoneData.ID;
            }
            catch (DbException ex)
            {
                throw ex;

            }
        }

        public int update(ZoneData ZoneData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(ZoneData);
                ExecuteNonQuery(CommandType.StoredProcedure, "ZoneUpdate", Parameters);
                //ExecuteCommand("ZoneUpdate", Parameters);
                //ZoneData.ID = (int)Parameters[0].Value;
                return ZoneData.ID;

                //this.ExecuteNonQuery(CommandType.StoredProcedure, "ZoneUpdate", CreateUpdateParameters(ZoneData));
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int Delete(ZoneData ZoneData)
        {
            DbParameter[] Parameters = CreateAddParameters(ZoneData);
            ExecuteNonQuery(CommandType.StoredProcedure, "ZoneDelete", Parameters);
            //ExecuteCommand("ZoneDelete", Parameters);
            return ZoneData.ID;

            //List<DbParameter> Parameters = new List<DbParameter>();
            //Parameters.Add(CreateParameter("@ID", ZoneData.ID));
            //this.ExecuteNonQuery(CommandType.StoredProcedure, "ZoneDelete", Parameters.ToArray());

        }

        public ZoneData GetZoneDataByID(string ID)
        {
            ZoneData ZoneData = new ZoneData();
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From Zone Where Code = {0}", ID), connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ZoneData = (ZoneData)GetFromReader(reader);
                    }
                }
                return ZoneData;
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

        public List<ZoneData> GetAll()
        {
            List<ZoneData> Lvar = new List<ZoneData>();
            ZoneData ZoneData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("ZoneGetAll", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ZoneData = (ZoneData)GetFromReader(reader);
                        Lvar.Add(ZoneData);
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
            ZoneData ZoneData = (ZoneData)data;

            if (ZoneData.DataStatus != DataStatus.New)
            {
                parameters.Add(CreateParameter("@ID", ZoneData.ID));
            }
            if (ZoneData.DataStatus != DataStatus.Deleted)
            {
                parameters.Add(CreateParameter("@Code", ZoneData.Code));
                parameters.Add(CreateParameter("@ArabicName", ZoneData.ArabicName));
                parameters.Add(CreateParameter("@EnglishName", ZoneData.EnglishName));
                parameters.Add(CreateParameter("@CountryID", ZoneData.CountryID));
                parameters.Add(CreateParameter("@CityID", ZoneData.CityID));
            }
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            ZoneData ZoneData = new ZoneData();
            ZoneData.ID = this.ReadInt32(reader, "ID");
            ZoneData.Code = this.ReadString(reader, "Code");
            ZoneData.ArabicName = this.ReadString(reader, "ArabicName");
            ZoneData.EnglishName = this.ReadString(reader, "EnglishName");
            ZoneData.CountryID = this.ReadInt32(reader, "CountryID");
            ZoneData.CityID = this.ReadInt32(reader, "CityID");

            return ZoneData;
        }
    }
}
