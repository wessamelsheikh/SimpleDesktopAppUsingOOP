using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Try.Data
{
    public enum DataStatus
    {
        New, Ignored, Saved, Modified, Deleted
    }

    public class BasicData
    {
        private Int32 _ID;
        private string _UserID;
        private int _BranchID;
        private DateTime _CreateDate;
        private DateTime _UpdateDate;
        private DataStatus _DataStatus;
        private Int32 _ID1;
        private string _Code1;
        private string _Name1;
        private Int32 _ID2;
        private string _Name2;
        private string _Code;
        private string _Name;
        private string _Code3;
        private string _Name3;
        private string _Code4;
        private string _Name4;
        private string _Code5;
        private string _Name5;
        private DateTime _Date2;
        private string _Notes2;


        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public int BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        public DataStatus DataStatus
        {
            get { return _DataStatus; }
            set { _DataStatus = value; }
        }
        public Int32 ID1
        {
            get { return _ID1; }
            set { _ID1 = value; }
        }
        public string Code1
        {
            get { return _Code1; }
            set { _Code1 = value; }
        }
        public Int32 ID2
        {
            get { return _ID2; }
            set { _ID2 = value; }
        }
        public string Name1
        {
            get { return _Name1; }
            set { _Name1 = value; }
        }
        public string Name2
        {
            get { return _Name2; }
            set { _Name2 = value; }
        }
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Code3
        {
            get { return _Code3; }
            set { _Code3 = value; }
        }
        public string Name3
        {
            get { return _Name3; }
            set { _Name3 = value; }
        }
        public string Code4
        {
            get { return _Code4; }
            set { _Code4 = value; }
        }
        public string Name4
        {
            get { return _Name4; }
            set { _Name4 = value; }
        }

        public string Code5
        {
            get { return _Code5; }
            set { _Code5 = value; }
        }
        public string Name5
        {
            get { return _Name5; }
            set { _Name5 = value; }
        }

        public DateTime Date2
        {
            get { return _Date2; }
            set { _Date2 = value; }
        }
        public string Notes2
        {
            get { return _Notes2; }
            set { _Notes2 = value; }
        }
    }
}
