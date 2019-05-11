using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USoft.Data;
using USoft.DAL;

namespace USoft.Logic
{
    public class CodeLogic
    {
        public int ClassificationOfMedicalServiceCode(Classification_medical_serviceaData ItemCode)
        {
            Classification_medical_serviceaDAL Classification_medical_serviceaDAL = new Classification_medical_serviceaDAL();
            try
            {
                switch (ItemCode.DataStatus)
                {
                    case DataStatus.New:
                        Classification_medical_serviceaDAL.Add(ItemCode);
                        break;
                    case DataStatus.Modified:
                        Classification_medical_serviceaDAL.update(ItemCode);
                        break;
                    case DataStatus.Deleted:
                        Classification_medical_serviceaDAL.Delete(ItemCode);
                        return 0;
                }
                return ItemCode._ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
