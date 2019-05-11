using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Logic
{
    /// <summary>
    /// A semi-permanent interactive information
    /// </summary>
    public static class Session
    {

        /// <summary>
        /// Represents the current user data who carried out the login
        /// </summary>
        public static User CurrentUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static CompanyInfo EnterpriseData { get; set; }
        /// <summary>
        /// Represents the current branch, which was signed in to by the user
        /// </summary>
        public static Branch CurrentBranch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static List<SystemSetting> ApplicationSetting { get; set; }
        /// <summary>
        /// Represents the name or network address of the instance of SQL Server to which to connect and the name of the database.
        /// </summary>
        public static String[] DbConnection { get; set; }
    }
}