using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Try.Data
{
    public static class BranchProfile
    {
        public static string _company = ConfigurationManager.AppSettings["Company"] == "1" ? "imcanat" : "usoft";

        public static DataTable HijriDates = new DataTable(); //m.ellisy

        // private static string _AttachmentDirectory = Application.StartupPath + "\\Attachments";

        //public static string AttachmentDirectory
        //{
        //    get { return BranchProfile._AttachmentDirectory; }
        //}

        public static string BranchName = string.Empty; //MFathy 04.10.2011 
        public static bool IsSP_Balancing = false;

        private static int _CurrentBranch;
        private static string _CurrentUser;
        private static LangEnum _CurrentLang;
        private static int _QtyRoundDigit;
        private static int _PriceRoundDigit;
        private static string _DateFormate;
        private static string _TimeFormate;
        private static bool _MainBranch;
        private static string _DLLPath = "";
        //private static BranchesData _Branches;
        //private static UsersData _CurrentUserData;
        //private static UserBranchsData _CurrentUserBranchData;
        //private static CompanyProfileData _CurrentCompanyProfile;
        private static int _ItemGroupDefault;


        public static bool Company_UseTransportationData { get; set; }


        //public static CompanyProfileData CurrentCompanyProfile
        //{
        //    get { return BranchProfile._CurrentCompanyProfile; }
        //    set { BranchProfile._CurrentCompanyProfile = value; }
        //}

        //public static UserBranchsData CurrentUserBranchData
        //{
        //    get { return BranchProfile._CurrentUserBranchData; }
        //    set { BranchProfile._CurrentUserBranchData = value; }
        //}
        //public static UsersData CurrentUserData
        //{
        //    get { return BranchProfile._CurrentUserData; }
        //    set { BranchProfile._CurrentUserData = value; }
        //}
        public static int ItemGroupDefault
        {
            get { return BranchProfile._ItemGroupDefault; }
            set { BranchProfile._ItemGroupDefault = value; }
        }
        //public static BranchesData Branches
        //{
        //    get { return BranchProfile._Branches; }
        //    set { BranchProfile._Branches = value; }
        //}
        public static string DLLPath
        {
            get { return BranchProfile._DLLPath; }
            set { BranchProfile._DLLPath = value; }
        }
        private static string _Keys = "GIGASoftInformationSystems";
        public static string Keys
        {
            get { return BranchProfile._Keys; }
        }
        private static string _fCheckDate = "01/01/2011";
        private static string _tCheckDate = "31/12/2012";

        public static bool CheckDate
        {
            get
            {
                return true;

            
                bool flag = (DateTime.Now.Date >= Convert.ToDateTime(_fCheckDate) && DateTime.Now.Date <= Convert.ToDateTime(_tCheckDate));

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    cn.Open();

                    bool isLocked = bool.Parse(SqlHelper.ExecuteScalar(cn, CommandType.Text, "SELECT ISNULL((SELECT TOP 1 Company_UseDefBranch FROM CompanyProfile),CAST(0 AS BIT))").ToString());

                    if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\boot.ini"))
                    {
                        isLocked = true;
                    }

                    if (isLocked)
                    {
                        flag = false;
                    }


                    if (!flag)
                    {
                        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Try.exe.config";

                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }

                        System.IO.File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\boot.ini");

                        SqlHelper.ExecuteNonQuery(cn, CommandType.Text, "UPDATE CompanyProfile SET Company_UseDefBranch = 1");
                    }

                    cn.Close();
                }

                return flag;
                //-----------------

                
                //return true;        // (DateTime.Now.Date >= Convert.ToDateTime(_fCheckDate) && DateTime.Now.Date <= Convert.ToDateTime(_tCheckDate));
                //-----------------
            }
        }
        public static LangEnum CurrentLang
        {
            get { return BranchProfile._CurrentLang; }
            set { BranchProfile._CurrentLang = value; }
        }
        public static int CurrentBranch
        {
            get { return BranchProfile._CurrentBranch; }
            set { BranchProfile._CurrentBranch = value; }
        }
        public static string CurrentUser
        {
            get { return BranchProfile._CurrentUser; }
            set { BranchProfile._CurrentUser = value; }
        }
        public static int QtyRoundDigit
        {
            get { return BranchProfile._QtyRoundDigit; }
            set { BranchProfile._QtyRoundDigit = value; }
        }
        public static int PriceRoundDigit
        {
            get { return BranchProfile._PriceRoundDigit; }
            set { BranchProfile._PriceRoundDigit = value; }
        }
        public static string QuantityFormat
        {
            get { return ("#0." + Space(QtyRoundDigit, "0")); }
        }
        public static string Format(int RoundDigit)
        {
            return ("#0." + Space(RoundDigit, "0"));
        }
        public static string PriceFormat
        {
            get { return ("#0." + Space(PriceRoundDigit, "0")); }
        }
        public static string Space(int Len, string Char)
        {
            string local = "";
            for (int i = 0; i < Len; i++)
                local += Char;
            return local;
        }
        public static string Format(string txt, int RoundDigit)
        {
            decimal number;
            if (txt == "")
                txt = "0";
            number = Convert.ToDecimal(txt);
            return number.ToString("#0." + Space(RoundDigit, "0"));
        }
        public static string DateFormate
        {
            get { return BranchProfile._DateFormate; }
            set { BranchProfile._DateFormate = value; }
        }
        public static string TimeFormate
        {
            get { return BranchProfile._TimeFormate; }
            set { BranchProfile._TimeFormate = value; }
        }
        public static bool MainBranch
        {
            get { return _MainBranch; }
            set { _MainBranch = value; }
        }
        public static bool IsNumber(string Char)
        {
            char[] local = Char.ToCharArray();
            for (int i = 0; i < local.Length; i++)
                if (!char.IsDigit(local[i]))
                    return false;
            return true;
        }
        //private static DefaultData _Default;
        //public static DefaultData Default
        //{
        //    get { return BranchProfile._Default; }
        //    set { BranchProfile._Default = value; }
        //}
        public static string Encrypt(string EncriptText)
        {
            byte[] Bites = Encoding.Unicode.GetBytes(EncriptText);
            byte[] key = Encoding.Unicode.GetBytes(BranchProfile.Keys);
            int currentKey = 0;
            for (int i = 0; i < Bites.Length; i++)
            {
                if (currentKey > key.Length)
                    currentKey = 0;
                Bites[i] += key[currentKey];

            }
            return Encoding.Unicode.GetString(Bites);
        }
        public static string Decrypt(string EncriptText)
        {
            byte[] Bites = Encoding.Unicode.GetBytes(EncriptText);
            byte[] key = Encoding.Unicode.GetBytes(BranchProfile.Keys);
            int currentKey = 0;
            for (int i = 0; i < Bites.Length; i++)
            {
                if (currentKey > key.Length)
                    currentKey = 0;
                Bites[i] -= key[currentKey];

            }
            return Encoding.Unicode.GetString(Bites);
        }
    }
}
