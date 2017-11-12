using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace BR.Model
{
    public class User
    {

        #region attributes
        private int m_UserId;
        private String m_UserName;
        private String m_Email;


        #endregion


        #region property
        public int userId { get { return m_UserId; } }
        public String userName { get { return m_UserName; } }
        public String email { get { return m_Email; } }

        #endregion

         public User(DataRow dr) 
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
                if (dr["UserId"] != DBNull.Value)
                    this.m_UserId = Convert.ToInt32(dr["UserId"]);
                if (dr["UserName"] != DBNull.Value)
                    this.m_UserName = (dr["UserName"].ToString());
                if (dr["Email"] != DBNull.Value)
                    this.m_Email = (dr["Email"].ToString());

            }
            catch (Exception ex)
            {
                throw;

            }


        }
    }
}