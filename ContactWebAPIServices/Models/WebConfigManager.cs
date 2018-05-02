using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ContactWebAPIServices.Models
{
    /// <summary>
    /// Config - This provide configuration details of application we.config file.
    /// </summary>
    public static class WebConfigManager
    {
        /// <summary>
        /// WebConfigManager - This static method provide connection string from application web.config file.
        /// </summary>
        /// <param name="astrConnectionStringName">Connection string name</param>
        /// <returns>Connection string given in we.config file</returns>
        public static string GetConnectionString(string astrConnectionStringName)
        {
            return WebConfigurationManager.ConnectionStrings[astrConnectionStringName].ConnectionString;
        }

    }
}