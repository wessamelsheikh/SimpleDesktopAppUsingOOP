using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try.DAL;

namespace Try.Logic
{
    public class ReportsLogic
    {
        GeneralFunctions _GeneralFunctions = new GeneralFunctions();

        //public DataTable GetReportClinicReservationDataTable(int nClinicReservationId)
        //{
        //    GeneralFunctions gn = new GeneralFunctions();
        //    return gn.GetDataTable(" Select * from vwClinicReserv Where ClinicReservationId  =" + nClinicReservationId);
        //}

        public DataTable GetZoneDetail(int CityID)
        {
            string StrSQlStatment = @"SELECT Zone.ID as ZoneID,Zone.Code as ZoneCode,Zone.ArabicName as ZoneArabicName,CityID,City.Code as CityCode,City.ArabicName as CityArabicName,Zone.CountryID,Country.Code as CountryCode,Country.ArabicName as CountryArabicName ";
            StrSQlStatment += "FROM [dbo].[Zone] inner join City on City.ID = Zone.CityID inner join Country on Country.ID = Zone.CountryID";
            StrSQlStatment += " Where Zone.CityID = " + CityID;

            return _GeneralFunctions.GetDataTable(StrSQlStatment);
        }

        public DataTable GetCityDetail()
        {
            string StrSQlStatment = "SELECT City.ID as CityID,City.Code as CityCode,City.ArabicName as CityName,Country.ID as CountryID,Country.Code as CountryCode,Country.ArabicName as CountryName ";
            StrSQlStatment += "FROM City inner join Country on Country.ID = City.CountryID";

            return _GeneralFunctions.GetDataTable(StrSQlStatment);
        }
    }
}
