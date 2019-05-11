using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Data
{
    public class WindowsFormData : BasicData
    {
        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private string _DataClass;
        public string DataClass
        {
            get { return _DataClass; }
            set { _DataClass = value; }
        }


        private string _DalClass;
        public string DalClass
        {
            get { return _DalClass; }
            set { _DalClass = value; }
        }

        private string _LogicClass;
        public string LogicClass
        {
            get { return _LogicClass; }
            set { _LogicClass = value; }
        }
        
        private string _IDField;
        public string IDField
        {
            get { return _IDField; }
            set { _IDField = value; }
        }
        private string _CodeField;
        public string CodeField
        {
            get { return _CodeField; }
            set { _CodeField = value; }
        }
        private string _ArabicField;
        public string ArabicField
        {
            get { return _ArabicField; }
            set { _ArabicField = value; }
        }
        private string _EnglishField;
        public string EnglishField
        {
            get { return _EnglishField; }
            set { _EnglishField = value; }
        }
    }
}
