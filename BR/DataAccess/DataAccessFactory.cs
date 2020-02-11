using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using System.Data.SqlClient;

namespace BR.DataAccess
{
    public class DataAccessFactory
    {
        
        #region Attributes
        private const string connectionStringSettingName = "ConnectionString";

        #endregion


        /// <summary>
        /// Since this is a factoryclass, the constructor is set to private so that no instance can be created
        /// </summary>
        private DataAccessFactory() { }


     /*   public static  MySqlConnection GetDataAccessMySql()  //not used
        {
             MySqlConnection connection;
             if (ConfigurationManager.AppSettings[connectionStringSettingName] == null)
            {
                throw new Exception("The default constructor has been called, but this assumes that a connection string '" + connectionStringSettingName + "' is available in the .config file for the current application. ");
            }

            //Initialize mysql connection
             return connection = new MySqlConnection(ConfigurationManager.AppSettings[connectionStringSettingName]);
           
        } */

        public static SqlConnection GetDataAccess()
        {
            SqlConnection connection;
            if (ConfigurationManager.AppSettings[connectionStringSettingName] == null)
            {
                throw new Exception("The default constructor has been called, but this assumes that a connection string '" + connectionStringSettingName + "' is available in the .config file for the current application. ");
            }

            //Initialize sql connection
            return connection = new SqlConnection(ConfigurationManager.AppSettings[connectionStringSettingName]);

        }

    }
}