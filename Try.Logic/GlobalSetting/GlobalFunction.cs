using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Try.DAL;

namespace Try.Logic
{
    public static class GlobalFunction
    {
        public enum StatusUser
        {
            _Created, _Modified, _Cancelled
        }

        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


        public static List<string> PrepareCodList(List<string> CodeList)
        {
            for (int i = 0; i < CodeList.Count; i++)
            {
                if (!String.IsNullOrEmpty(CodeList[i]) && Char.IsLetter(CodeList[i].ToString()[0]))
                { CodeList[i] = CodeList[i].PadRight(50); }
                else
                { CodeList[i] = CodeList[i].PadLeft(50, '0'); }
            }

            return CodeList;
        }

        public static string PrepareCode(string theString, int totalWidth = 50, char paddingChar = '0')
        {
            try
            {
                if (!String.IsNullOrEmpty(theString) && !Char.IsDigit(theString[theString.Length - 1]))
                {
                    theString = theString.PadRight(totalWidth);
                } // end if
                else
                {
                    theString = theString.PadLeft(totalWidth, paddingChar);
                } // end else

                return theString;
            } // end try
            catch
            {
                System.Windows.Forms.MessageBox.Show("There is a problem. Please try later!");
                return null;
            } // end catch
        }

        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }
        public static DateTime GetServerDate()
        {
            GeneralFunctions _GeneralFunctions = new GeneralFunctions();
            return _GeneralFunctions.GetServerDate();
        }

        public static DateTime GetServerDateOnly()
        {
            GeneralFunctions _GeneralFunctions = new GeneralFunctions();
            return _GeneralFunctions.GetServerDateOnly();
        }

        public static string BachupDataBase(string strBackupPath)
        {
            GeneralFunctions _GeneralFunctions = new GeneralFunctions();
            return _GeneralFunctions.BachupDataBase(strBackupPath);
        }
        public static string UserInStatusBar(string _UserID, DateTime _Date, StatusUser _Status)
        {
            string Statement = string.Empty;
            if (_UserID != "")
            {
                if (true/*GlobalSetting.LoginLanguage == FormsLogic.InputLanguages.Arabic*/)
                {
                    if (_Status == StatusUser._Created)
                        Statement = string.Format("الانشاء بواسطة  : " + "{0}" + " --  بتاريخ : " + "{1}", (_UserID != "" ? _UserID : ""), _Date.ToString("yyyy/MM/dd") + " " + _Date.ToShortTimeString());
                    else if (_Status == StatusUser._Modified)
                        Statement = string.Format("التعديل بواسطة : " + "{0}" + " --  بتاريخ : " + "{1}", (_UserID != "" ? _UserID : ""), _Date.ToString("yyyy/MM/dd") + " " + _Date.ToShortTimeString());
                    else if (_Status == StatusUser._Cancelled)
                        Statement = string.Format("الإلغاء بواسطة : " + "{0}" + " --  بتاريخ : " + "{1}", (_UserID != "" ? _UserID : ""), _Date.ToString("yyyy/MM/dd") + " " + _Date.ToShortTimeString());
                    else
                        Statement = "";
                }
                else
                {
                    if (_Status == StatusUser._Created)
                        Statement = string.Format("Create By User : {0}  --  Create Date : {1}", (_UserID != "" ? _UserID : ""), _Date.ToString("dd/MM/yyyy") + " " + _Date.ToShortTimeString());
                    else if (_Status == StatusUser._Modified)
                        Statement = string.Format("Modified By User : {0}  --  Modified Date : {1}", (_UserID != "" ? _UserID : ""), _Date.ToString("dd/MM/yyyy") + " " + _Date.ToShortTimeString());
                    else if (_Status == StatusUser._Cancelled)
                        Statement = string.Format("Cancelled By User : {0}  --  Modified Date : {1}", (_UserID != "" ? _UserID : ""), _Date.ToString("dd/MM/yyyy") + " " + _Date.ToShortTimeString());
                    else
                        Statement = "";
                }
            }
            return Statement;
        }

    }
}
