using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;

namespace BR.Model
{
    public class UserCollection : List<User>
    {
        //not used
        /*
        //[DataObjectMethod(DataObjectMethodType.Select)]
        public static UserCollection GetUsers()
        {
            // String connStr = ConfigurationManager.ConnectionStrings["DataAccess.ConnectionString"].ToString();
            UserCollection uc = new UserCollection();


            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = ExtraLib.Sql.getAllUsers();
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        uc.Add(new User(dr));
                    }
                }

                return uc;
            }
        }      */
    }
}