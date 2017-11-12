using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace BR.Model
{
    public class Game
    {
        #region attributes
        private int m_gameId;
        private string  m_gameName;
        private int m_turn;
        private int m_DynasticSequence;
        private int m_Creator;
        #endregion


        #region property
        public int gameId { get { return m_gameId; } }
        public string  gameName { get { return m_gameName; } }
        public int turn { get { return m_turn; } }
        public int dynasticSequence { get { return m_DynasticSequence; } }
        public int creator { get { return m_Creator; } }
        #endregion


        public Game(DataRow dr) 
        {
            try
            {
                CreateObjectFromDataRow(dr);
            }
            catch (Exception ex){
                throw; 
            }
        }


        private void CreateObjectFromDataRow(DataRow dr) {

            try {
                if (dr["GameId"] != DBNull.Value)
                    this.m_gameId = Convert.ToInt32(dr["GameId"]);
                if (dr["GameName"] != DBNull.Value)
                    this.m_gameName = (dr["GameName"].ToString());
                if (dr["Turn"] != DBNull.Value)
                    this.m_turn = Convert.ToInt32(dr["Turn"]);
                if (dr["DynasticSequence"] != DBNull.Value)
                    this.m_DynasticSequence = Convert.ToInt32(dr["DynasticSequence"]);
                if (dr["Creator"] != DBNull.Value)
                    this.m_Creator = Convert.ToInt32(dr["Creator"]);               
            }
            catch (Exception ex) {
                throw;
            }
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Game GetSpecificGame(int gameId)
        {
            Game g = null;
            


            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = ExtraLib.Sql.getGameFromGameId(gameId);
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
                         g = new Game(dr);
                    }
                }

                return g;
            }
        }
    }
}