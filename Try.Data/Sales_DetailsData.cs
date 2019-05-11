using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Data
{
    public class Sales_DetailsData : BasicData
    {
        private int _SalesDet_HeadID;

        public int SalesDet_HeadID
        {
            get { return _SalesDet_HeadID; }
            set { _SalesDet_HeadID = value; }
        }
        
        private DateTime _SalesDet_Date;

        public DateTime SalesDet_Date
        {
            get { return _SalesDet_Date; }
            set { _SalesDet_Date = value; }
        }
        private decimal _SalesDet_Amount;

        public decimal SalesDet_Amount
        {
            get { return _SalesDet_Amount; }
            set { _SalesDet_Amount = value; }
        }
    }
}
