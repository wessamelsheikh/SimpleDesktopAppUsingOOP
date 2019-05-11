using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using USoft.Data;
using USoft.DAL;
using System.Data.Common;

namespace USoft.Logic
{
    public class LookupsLogic
    {
        public DataSet GetModuleLookups(int ModuleID)
        {
            try
            {
              USoft.DAL.  LookupsDal lookupDal = new LookupsDal();
                return lookupDal.GetModuleLookups(ModuleID);

            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataSet GetDataSet(string sql)
        {
            try
            {
                LookupsDal lookupDal = new LookupsDal();
                return lookupDal.GetDataSet(sql);

            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataSet GetDataSet(int LookupID)
        {
            try
            {
                LookupsDal lookupDal = new LookupsDal();
                return lookupDal.GetDataSet(LookupID);

            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataSet GetDataSet(string SQL, string[] ParameterName, List<object> ParameterValue)
        {
            try
            {
                LookupsDal lookupDal = new LookupsDal();
                return lookupDal.GetDataSet(SQL, ParameterName, ParameterValue);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DbDataReader DataReader(string SQL)
        {
            try
            {
                LookupsDal lookupDal = new LookupsDal();
                return lookupDal.DataReader(SQL);

            }
            catch (Exception)
            {
                return null;
            }
        }
        public DbDataReader DataReader(string SQL, string[] ParameterName, List<object> ParameterValue)
        {
            try
            {
                LookupsDal lookupDal = new LookupsDal();
                return lookupDal.DataReader(SQL, ParameterName, ParameterValue);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string GetTranslate(string Caption)
        {
            LookupsDal lookupDal = new LookupsDal();
            return lookupDal.GetTranslate(Caption);
        }
        public List<BasicData> GetFields(string TableName)
        {
            LookupsDal lookupDal = new LookupsDal();
            return lookupDal.GetFields(TableName);
        }
        public int SubmitLookups(LookupsData Lookups)
        {
            LookupsDal LookupsDal = new LookupsDal();
            //using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
            try
            {
                switch (Lookups.DataStatus)
                {
                    case DataStatus.New:
                        LookupsDal.Add(Lookups);
                        break;
                    case DataStatus.Modified:
                        LookupsDal.Update(Lookups);
                        break;
                    case DataStatus.Deleted:
                        LookupsDal.Delete(Lookups);
                        //ts.Complete();
                        return 0;
                    default:
                        break;
                }
                //ts.Complete();
                return Lookups._ID;
            }
            catch (Exception ex)
            {
                //ts.Dispose();
                throw ex;
            }
        }
    }
}
