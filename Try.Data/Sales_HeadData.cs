using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Data
{
    public class Sales_HeadData : BasicData
    {
        private string _Sales_Code;

        public string Sales_Code
        {
            get { return _Sales_Code; }
            set { _Sales_Code = value; }
        }
        private string _Sales_ArabicName;

        public string Sales_ArabicName
        {
            get { return _Sales_ArabicName; }
            set { _Sales_ArabicName = value; }
        }
        private string _Sales_EnglishName;

        public string Sales_EnglishName
        {
            get { return _Sales_EnglishName; }
            set { _Sales_EnglishName = value; }
        }
        private List<Sales_DetailsData> _Sales_DetailsData;

        public List<Sales_DetailsData> Sales_DetailsData
        {
            get { return _Sales_DetailsData; }
            set { _Sales_DetailsData = value; }
        }
    }
}
