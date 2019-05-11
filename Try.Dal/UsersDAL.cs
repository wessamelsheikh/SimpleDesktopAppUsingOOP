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
    [Serializable]
    public class UsersDAL : DataComponent
    {
        public int Add(UsersData UsersData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(UsersData);
                ExecuteNonQuery(CommandType.StoredProcedure, "UsersAdd", Parameters);
                //ExecuteCommand("UsersAdd", Parameters);
                UsersData.ID = (int)Parameters[0].Value;
                return UsersData.ID;
            }
            catch (DbException ex)
            {
                throw ex;

            }
        }

        public int update(UsersData UsersData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(UsersData);
                ExecuteNonQuery(CommandType.StoredProcedure, "UsersUpdate", Parameters);
                //ExecuteCommand("UsersUpdate", Parameters);
                //UsersData.ID = (int)Parameters[0].Value;
                return UsersData.ID;

                //this.ExecuteNonQuery(CommandType.StoredProcedure, "UsersUpdate", CreateUpdateParameters(UsersData));
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int Delete(UsersData UsersData)
        {
            DbParameter[] Parameters = CreateAddParameters(UsersData);
            ExecuteNonQuery(CommandType.StoredProcedure, "UsersDelete", Parameters);
            //ExecuteCommand("UsersDelete", Parameters);
            return UsersData.ID;

            //List<DbParameter> Parameters = new List<DbParameter>();
            //Parameters.Add(CreateParameter("@ID", UsersData.ID));
            //this.ExecuteNonQuery(CommandType.StoredProcedure, "UsersDelete", Parameters.ToArray());

        }

        public UsersData GetUsersDataByID(string ID)
        {
            UsersData UsersData = new UsersData();
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From Users Where Users_Code = {0}", ID), connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersData = (UsersData)GetFromReader(reader);
                    }
                }
                return UsersData;
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

        public List<UsersData> GetAll()
        {
            List<UsersData> Lvar = new List<UsersData>();
            UsersData UsersData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("UsersGetAll", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersData = (UsersData)GetFromReader(reader);
                        Lvar.Add(UsersData);
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
            UsersData UsersData = (UsersData)data;

            if (UsersData.DataStatus != DataStatus.New)
            {
                parameters.Add(CreateParameter("@ID", UsersData.ID));
            }
            if (UsersData.DataStatus != DataStatus.Deleted)
            {
                parameters.Add(CreateParameter("@Users_Code", UsersData.Users_Code));
                parameters.Add(CreateParameter("@Users_ArabicName", UsersData.Users_ArabicName));
                parameters.Add(CreateParameter("@Users_EnglishName", UsersData.Users_EnglishName));
                parameters.Add(CreateParameter("@Users_Password", UsersData.Users_Password));
            }
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            UsersData UsersData = new UsersData();
            UsersData.ID = this.ReadInt32(reader, "Users_ID");

            UsersData.Users_Code = this.ReadString(reader, "Users_Code");
            UsersData.Users_ArabicName = this.ReadString(reader, "Users_ArabicName");
            UsersData.Users_EnglishName = this.ReadString(reader, "Users_EnglishName");
            UsersData.Users_Password = this.ReadString(reader, "Users_Password");

            return UsersData;
        }
    }
}
