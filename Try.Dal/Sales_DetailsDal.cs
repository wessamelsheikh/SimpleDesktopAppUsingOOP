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
    public class Sales_DetailsDal : DataComponent
    {
        public int Add(Sales_DetailsData Sales_DetailsData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(Sales_DetailsData);
                ExecuteNonQuery(CommandType.StoredProcedure, "Sales_DetailsAdd", Parameters);
                //ExecuteCommand("Sales_DetailsAdd", Parameters);
                Sales_DetailsData.ID = (int)Parameters[0].Value;
                return Sales_DetailsData.ID;
            }
            catch (DbException ex)
            {
                throw ex;

            }
        }

        public int update(Sales_DetailsData Sales_DetailsData)
        {
            try
            {
                DbParameter[] Parameters = CreateAddParameters(Sales_DetailsData);
                ExecuteNonQuery(CommandType.StoredProcedure, "Sales_DetailsUpdate", Parameters);
                //ExecuteCommand("Sales_DetailsUpdate", Parameters);
                //Sales_DetailsData.ID = (int)Parameters[0].Value;
                return Sales_DetailsData.ID;

                //this.ExecuteNonQuery(CommandType.StoredProcedure, "Sales_DetailsUpdate", CreateUpdateParameters(Sales_DetailsData));
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public int Delete(Sales_DetailsData Sales_DetailsData)
        {
            DbParameter[] Parameters = CreateAddParameters(Sales_DetailsData);
            ExecuteNonQuery(CommandType.StoredProcedure, "Sales_DetailsDelete", Parameters);
            //ExecuteCommand("Sales_DetailsDelete", Parameters);
            return Sales_DetailsData.ID;

            //List<DbParameter> Parameters = new List<DbParameter>();
            //Parameters.Add(CreateParameter("@ID", Sales_DetailsData.ID));
            //this.ExecuteNonQuery(CommandType.StoredProcedure, "Sales_DetailsDelete", Parameters.ToArray());

        }

        public Sales_DetailsData GetSales_DetailsData(int ID)
        {
            Sales_DetailsData Sales_DetailsData = new Sales_DetailsData();
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From Sales_Details Where SalesDet_ID = {0}", ID), connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sales_DetailsData = (Sales_DetailsData)GetFromReader(reader);
                    }
                }
                return Sales_DetailsData;
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

        public List<Sales_DetailsData> GetAll()
        {
            List<Sales_DetailsData> Lvar = new List<Sales_DetailsData>();
            Sales_DetailsData Sales_DetailsData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("Sales_DetailsGetAll", connection);
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sales_DetailsData = (Sales_DetailsData)GetFromReader(reader);
                        Lvar.Add(Sales_DetailsData);
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

        public List<Sales_DetailsData> GetByID(int HeadID)
        {
            List<Sales_DetailsData> Lvar = new List<Sales_DetailsData>();
            Sales_DetailsData Sales_DetailsData = null;
            DbDataReader reader = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(String.Format("Select * From Sales_Details Where SalesDet_HeadID = {0}",HeadID), connection);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sales_DetailsData = (Sales_DetailsData)GetFromReader(reader);
                        Lvar.Add(Sales_DetailsData);
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
            Sales_DetailsData Sales_DetailsData = (Sales_DetailsData)data;

            if (Sales_DetailsData.DataStatus != DataStatus.New)
            {
                parameters.Add(CreateParameter("@ID", Sales_DetailsData.ID));
            }

            if (Sales_DetailsData.DataStatus != DataStatus.Deleted)
            {
                parameters.Add(CreateParameter("@SalesDet_HeadID", Sales_DetailsData.SalesDet_HeadID));
                parameters.Add(CreateParameter("@SalesDet_Date", Sales_DetailsData.SalesDet_Date));
                parameters.Add(CreateParameter("@SalesDet_Amount", Sales_DetailsData.SalesDet_Amount));
            }
        }

        public override BasicData GetFromReader(DbDataReader reader)
        {
            Sales_DetailsData Sales_DetailsData = new Sales_DetailsData();
            Sales_DetailsData.ID = this.ReadInt32(reader, "SalesDet_ID");
            Sales_DetailsData.SalesDet_HeadID = this.ReadInt32(reader, "SalesDet_HeadID");
            Sales_DetailsData.SalesDet_Date = this.ReadDate(reader, "SalesDet_Date");
            Sales_DetailsData.SalesDet_Amount = this.ReadDecimal(reader, "SalesDet_Amount");

            return Sales_DetailsData;
        }
    }
}
