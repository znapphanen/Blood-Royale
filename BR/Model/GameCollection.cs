using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace BR.Model
{
    [DataObject(true)]
    public class GameCollection : List<Game>  //Inherit from List
    {


        private GameCollection()
        {


        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static GameCollection GetGames(int userId)
        {
            // String connStr = ConfigurationManager.ConnectionStrings["DataAccess.ConnectionString"].ToString();
            GameCollection gc = new GameCollection();


            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = ExtraLib.Sql.getGamesFromUserId3(userId);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        gc.Add(new Game(dr));
                    }
                }

                return gc;
            }
        }

       
    }
}