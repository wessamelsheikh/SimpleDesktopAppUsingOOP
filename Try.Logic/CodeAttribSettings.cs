using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Windows.Forms;
using USoft.Data;
using USoft_SQL_CLR;
namespace USoft.Logic
{
    class CodeAttribSettings
    {

        public static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public static string GetNextCode(string currentCode)
        {
            if (currentCode == "") return currentCode;
            currentCode = currentCode.Trim();

        strt:

            for (int i = currentCode.Length - 1; i >= 0; i--)
            {
                if (IsNumeric(currentCode.Substring(i)))
                {
                    if (!currentCode.Substring(i).Contains('-')) continue;
                }

                string Sub1 = currentCode.Substring(0, i + 1);
                string Sub2 = currentCode.Substring(i + 1);
                if (Sub2 == "")
                {
                    return "";
                }
                else if (Sub2 == new string('9', Sub2.Length + 1))
                {

                    currentCode = Sub1;
                    goto strt;

                }

                double val = Convert.ToInt64(Sub2);
                if (val < 0)
                    val = val - 1;
                else
                    val = val + 1;

                return (Sub1 + Convert.ToString(Sub2 == "" ? 1 : val).Trim().PadLeft(Sub2.Length, '0'));

            }

            string g = Convert.ToString((Convert.ToInt64(currentCode) + 1));
            if (g.Length != currentCode.Length) g = g.PadLeft(currentCode.Length, '0');

            return g;
        }


    }
}
