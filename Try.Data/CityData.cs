using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Data
{
    public class CityData : BasicData
    {
        public string Code { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int CountryID { get; set; }
    }
}
