using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class WindowsFormLogic
    {
        public object GetAllByID(string TableName)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();

                return WindowsFormDal.GetByID(TableName);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetAll(string TableName)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();

                return WindowsFormDal.GetAll(TableName);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetID(string TableName, string CodeField, int ID)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();

                return WindowsFormDal.GetID(TableName, CodeField,ID);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetNextCode(string Table, string Code)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();

                return WindowsFormDal.GetNextCode(Table,Code);

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public object GetNextID(string Table, string ID)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();

                return WindowsFormDal.GetNextID(Table, ID);

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string GetFirst(string Table, string Code)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new DAL.WindowsFormDal();
                return WindowsFormDal.GetFirst(Table, Code);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetLast(string Table, string Code)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();
                return WindowsFormDal.GetLast(Table, Code);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetNext(string Table, string CodeField, string Code)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();
                return WindowsFormDal.GetNext(Table, CodeField, Code);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetPrevious(string Table, string CodeField, string Code)
        {
            try
            {
                WindowsFormDal WindowsFormDal = new WindowsFormDal();

                return WindowsFormDal.GetPrevious(Table, CodeField, Code);

            }
            catch (Exception)
            {
                return "";
            }
        }

        //public DataSet GetModuleLookups(int ModuleID)
        //{
        //    try
        //    {
        //        Try.DAL.LookupsDal lookupDal = new LookupsDal();
        //        return lookupDal.GetModuleLookups(ModuleID);

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public DataSet GetDataSet(string sql)
        //{
        //    try
        //    {
        //        LookupsDal lookupDal = new LookupsDal();
        //        return lookupDal.GetDataSet(sql);

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public DataSet GetDataSet(int LookupID)
        //{
        //    try
        //    {
        //        LookupsDal lookupDal = new LookupsDal();
        //        return lookupDal.GetDataSet(LookupID);

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public DataSet GetDataSet(string SQL, string[] ParameterName, List<object> ParameterValue)
        //{
        //    try
        //    {
        //        LookupsDal lookupDal = new LookupsDal();
        //        return lookupDal.GetDataSet(SQL, ParameterName, ParameterValue);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public DbDataReader DataReader(string SQL)
        //{
        //    try
        //    {
        //        LookupsDal lookupDal = new LookupsDal();
        //        return lookupDal.DataReader(SQL);

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public DbDataReader DataReader(string SQL, string[] ParameterName, List<object> ParameterValue)
        //{
        //    try
        //    {
        //        LookupsDal lookupDal = new LookupsDal();
        //        return lookupDal.DataReader(SQL, ParameterName, ParameterValue);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public string GetTranslate(string Caption)
        //{
        //    LookupsDal lookupDal = new LookupsDal();
        //    return lookupDal.GetTranslate(Caption);
        //}
        //public List<BasicData> GetFields(string TableName)
        //{
        //    LookupsDal lookupDal = new LookupsDal();
        //    return lookupDal.GetFields(TableName);
        //}
        //public int SubmitLookups(LookupsData Lookups)
        //{
        //    LookupsDal LookupsDal = new LookupsDal();
        //    //using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
        //    try
        //    {
        //        switch (Lookups.DataStatus)
        //        {
        //            case DataStatus.New:
        //                LookupsDal.Add(Lookups);
        //                break;
        //            case DataStatus.Modified:
        //                LookupsDal.Update(Lookups);
        //                break;
        //            case DataStatus.Deleted:
        //                LookupsDal.Delete(Lookups);
        //                //ts.Complete();
        //                return 0;
        //            default:
        //                break;
        //        }
        //        //ts.Complete();
        //        return Lookups.ID;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ts.Dispose();
        //        throw ex;
        //    }
        //}
    }
}
