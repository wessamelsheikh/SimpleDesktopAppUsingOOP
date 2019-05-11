using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Try.Data;
using Try.Logic;
using Try.DAL;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace Try.Logic
{
    public class CodeLogic

    {
        public enum StatusUser
        {
            _Created, _Modified
        }

        protected void PerformAfterApplyActions(BasicData data)
        {
            if (data.DataStatus == DataStatus.Modified || data.DataStatus == DataStatus.New)
                data.DataStatus = DataStatus.Saved;
            else if (data.DataStatus == DataStatus.Deleted)
                data.DataStatus = DataStatus.Ignored;
        }

        public static void SetAppValue(string key, string value)
        {
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Config.AppSettings.Settings[key].Value = value;
            Config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public int UsersCode(UsersData ItemCode)
        {
            UsersDAL UsersDAL = new UsersDAL();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        UsersDAL.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        UsersDAL.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        UsersDAL.Delete(ItemCode);
                        return 0;
                }
                return ItemCode.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountryCode(CountryData ItemCode)
        {
            CountryDal CountryDal = new CountryDal();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        CountryDal.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        CountryDal.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        CountryDal.Delete(ItemCode);
                        return 0;
                }
                return ItemCode.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CityCode(CityData ItemCode)
        {
            CityDal CityDal = new CityDal();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        CityDal.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        CityDal.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        CityDal.Delete(ItemCode);
                        return 0;
                }
                return ItemCode.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ZoneCode(ZoneData ItemCode)
        {
            ZoneDal ZoneDal = new ZoneDal();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        ZoneDal.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        ZoneDal.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        ZoneDal.Delete(ItemCode);
                        return 0;
                }
                return ItemCode.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SalesHeadTransaction(Sales_HeadData ItemCode)
        {
            Sales_HeadDal Sales_HeadDal = new Sales_HeadDal();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        Sales_HeadDal.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        Sales_HeadDal.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        Sales_HeadDal.Delete(ItemCode);
                        return 0;
                }

                SalesDetails(ItemCode);
                return ItemCode.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SalesDetails(Sales_HeadData ItemCode)
        {
            if (ItemCode.Sales_DetailsData == null)
                return;
            foreach (Sales_DetailsData Sales_DetailsData in ItemCode.Sales_DetailsData)
            {
                Sales_DetailsDal Sales_DetailsDal = new Sales_DetailsDal();

                Sales_DetailsData.SalesDet_HeadID = ItemCode.ID;
                Sales_DetailsData.DataStatus = ItemCode.DataStatus;
                SalesDetailsTransaction(Sales_DetailsData);
            }
        }

        public int SalesDetailsTransaction(Sales_DetailsData ItemCode)
        {
            Sales_DetailsDal Sales_DetailsDal = new Sales_DetailsDal();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        Sales_DetailsDal.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        Sales_DetailsDal.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        Sales_DetailsDal.Delete(ItemCode);
                        return 0;
                }
                return ItemCode.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sales_DetailsData> Sales_DetailsData(int HeadID)
        {
            Sales_DetailsDal Sales_DetailsDal = new Sales_DetailsDal();
            return Sales_DetailsDal.GetByID(HeadID);
        }

        public Sales_HeadData GetSalesHeadByID(string ID)
        {
            Sales_HeadData data = new Sales_HeadData();
            Sales_HeadDal dal = new Sales_HeadDal();
            data = dal.GetSales_HeadData(ID);
            data.Sales_DetailsData = GetSalesDetailsByID(data.ID);
            return data;
        }

        public List<Sales_DetailsData> GetSalesDetailsByID(int HeadID)
        {
            Sales_DetailsDal Sales_DetailsDal = new Sales_DetailsDal();
            return Sales_DetailsDal.GetByID(HeadID);
        }

        public CityData GetCityDataByID(string ID)
        {
            CityDal CityDal = new CityDal();
            return CityDal.GetCityDataByID(ID);
        }

        public CountryData GetCountryDataByID(string ID)
        {
            CountryDal CountryDal = new CountryDal();
            return CountryDal.GetCountryDataByID(ID);
        }

        public ZoneData GetZoneDataByID(string ID)
        {
            ZoneDal ZoneDal = new ZoneDal();
            return ZoneDal.GetZoneDataByID(ID);
        }

        public UsersData GetUsersDataByID(string ID)
        {
            UsersDAL UsersDAL = new UsersDAL();
            return UsersDAL.GetUsersDataByID(ID);
        }

    }
}
