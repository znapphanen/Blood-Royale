using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BR.Model
{
    public class Dynasty
    {
        #region attributes
        private int m_DynastyId;
        private string m_DynastyName;
        private char m_Country;
        private int m_UserId;
        private int m_GameId;
        #endregion


        #region property
        public int dynastyId { get { return m_DynastyId; } }
        public string dynastyName{ get { return m_DynastyName; } }
        public char country { get { return m_Country; } }
        public int userId { get { return m_UserId; } }
        public int gameId { get { return m_GameId; } }
        #endregion

         //constructor
        private Dynasty() {
        
        }


        public Dynasty(DataRow dr)
            : this()
        {
            try
            {
                CreateObjectFromDataRow(dr);

            }
            catch (Exception ex){
                throw; 
            }

        }


        private void CreateObjectFromDataRow(DataRow dr)
        {

            try
            {
                if (dr["DynastyId"] != DBNull.Value)
                    this.m_DynastyId = Convert.ToInt32(dr["DynastyId"]);
                if (dr["DynastyName"] != DBNull.Value)
                    this.m_DynastyName = (dr["DynastyName"].ToString());
                if (dr["Country"] != DBNull.Value)
                    this.m_Country = Convert.ToChar(dr["Country"]);

                if (dr["UserId"] != DBNull.Value)
                    this.m_UserId = Convert.ToInt32(dr["UserId"]);
                if (dr["GameId"] != DBNull.Value)
                    this.m_GameId = Convert.ToInt32(dr["GameId"]);
            }
            catch (Exception ex)
            {
                throw;

            }


        }
    }
}