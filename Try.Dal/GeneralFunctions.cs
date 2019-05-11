using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Try.DAL
{
    public class GeneralFunctions
    {
        public DataTable GetDataTable(string strStatment, DateTime fromDate, DateTime toDate)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            command.Parameters.Add("@fromDate", SqlDbType.DateTime);
            command.Parameters["@fromDate"].Value = fromDate;
            command.Parameters.Add("@toDate", SqlDbType.DateTime);
            command.Parameters["@toDate"].Value = toDate;
           
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }
        //M.Samir 
        public DataTable GetDataTable(string strStatment, DateTime fromDate, DateTime toDate, string DetectionTypes)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            command.CommandType = CommandType.Text;
            //command.Parameters.Add("@fromDate", SqlDbType.DateTime);
            //command.Parameters["@fromDate"].Value = fromDate;
            //command.Parameters.Add("@toDate", SqlDbType.DateTime);
            //command.Parameters["@toDate"].Value = toDate;
            //command.Parameters.Add("@DetectionTypes", SqlDbType.NVarChar,50);
            //command.Parameters["@DetectionTypes"].Value = DetectionTypes;
           
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);
            
            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }
        //

        //M.Samir 28-11-2017 
        public DataTable GetDataTable(string strStatment, DateTime fromDate, DateTime toDate, string cliniccod, string procedurecode)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            command.CommandType = CommandType.Text ;


            command.Parameters.Add("@fromDate", SqlDbType.DateTime);
            command.Parameters["@fromDate"].Value = fromDate;
            command.Parameters.Add("@toDate", SqlDbType.DateTime);
            command.Parameters["@toDate"].Value = toDate;
            command.Parameters.Add("@cliniccod", SqlDbType.NVarChar, 50);
            command.Parameters["@cliniccod"].Value = cliniccod;
            command.Parameters.Add("@procedurecode", SqlDbType.NVarChar, 50);
            command.Parameters["@procedurecode"].Value = procedurecode;



            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }
        //

        public DataTable GetDataTable(string strStatment)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
             SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }

        // Wessam
        public DataTable GetDataTable(string strStatment, int ID)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            command.CommandType = CommandType.Text;


            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = ID;
            
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }
        // M.samir
        public DataTable GetDataTable(string strStatment, int ID, int cliniccod, int procedurecode)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            command.CommandType = CommandType.Text;


            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = ID;
            command.Parameters.Add("@cliniccod", SqlDbType.Int );
            command.Parameters["@cliniccod"].Value = cliniccod;
            command.Parameters.Add("@procedurecode", SqlDbType.Int );
            command.Parameters["@procedurecode"].Value = procedurecode;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }
        public DataTable GetDataTable(string strStatment, int ID, int cliniccod)
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            SqlConnection sqlcon = new SqlConnection(strCon);
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            command.CommandType = CommandType.Text;


            command.Parameters.Add("@ID", SqlDbType.Int);
            command.Parameters["@ID"].Value = ID;
            command.Parameters.Add("@cliniccod", SqlDbType.Int);
            command.Parameters["@cliniccod"].Value = cliniccod;
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            SqlDataAdapter.Fill(dt);
            return dt;
        }

        //

        public DateTime GetServerDate()
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            string strStatment = "select GetDate();";
            SqlConnection sqlcon = new SqlConnection(strCon);
            sqlcon.Open();
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            DateTime serverDate = DateTime.Parse(command.ExecuteScalar().ToString());
            sqlcon.Close();
            return serverDate;
        }

        public DateTime GetServerDateOnly()
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            string strStatment = "SELECT DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()));";
            SqlConnection sqlcon = new SqlConnection(strCon);
            sqlcon.Open();
            SqlCommand command = new SqlCommand(strStatment, sqlcon);
            DateTime serverDate = DateTime.Parse(command.ExecuteScalar().ToString());
            sqlcon.Close();
            return serverDate;
        }

        public string  BachupDataBase(string strStatment)
        {
            SqlConnection sqlcon=null;
            try 
            {
                string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            string CurrDB = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString.Replace("[", "").Replace("]", "");
            string strCommand= String.Format("BACKUP DATABASE [" + CurrDB + "] TO  DISK = '" + strStatment + "\\" + ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString.ToString() + "_Backup_" + DateTime.Now.ToString("dd-MM-yyyy@HH-mm-ss") + ".bak'");
           
             sqlcon = new SqlConnection(strCon);
            sqlcon.Open();
            SqlCommand command = new SqlCommand(strCommand, sqlcon);
              command.CommandTimeout = 500;
                    command.ExecuteNonQuery();
                    sqlcon.Close ();
            return string.Empty;
            }
            catch (Exception ex)
            {
                sqlcon.Close();
                return ex .InnerException.Message ;
            }
        }


        public string ExecuteNonQuery(string strStatment)
        {
            SqlConnection sqlcon = null;
            try
            {
                string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
              

                sqlcon = new SqlConnection(strCon);
                sqlcon.Open();
                SqlCommand command = new SqlCommand(strStatment, sqlcon);
                command.CommandTimeout = 500;
                command.ExecuteNonQuery();
                sqlcon.Close();
                return string.Empty;
            }
            catch (Exception ex)
            {
                sqlcon.Close();
                return ex.InnerException.Message;
            }
        }
    }
}
