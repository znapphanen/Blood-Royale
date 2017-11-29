using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;


namespace BR.Model
{
    [DataObject(true)]  
    public class Character
    {
        #region Attributes
        private int m_CharacterId;
        private string m_firstName;
        private int m_str;
        private int m_cha;
        private int m_con;
        private char m_gender;
        private Boolean m_king;
        private int m_born;
        private string m_DynastyName;
        private int m_BirthRollsMade;
        private int m_DynastyId;
        private int m_SpouseId;
        private bool m_Dead;
        private bool m_Prisoner;
        private char m_Country;

        #endregion


        #region property
        public int characterId {get { return m_CharacterId; }}
        public string firstName { get { return m_firstName; } }
        public int str { get { return m_str; } }
        public int cha { get { return m_cha; } }
        public int con { get { return m_con; } }
        public char Gender { get { return m_gender; } }
        public Boolean King { get { return m_king; } }
        public int born { get { return m_born; } }
        public int age { get 
        {
            int turn=-1;
            if(HttpContext.Current.Session["Turn"]!= null){
                 turn = Convert.ToInt32( HttpContext.Current.Session["Turn"]);
            }
            

            return (turn -  m_born)*5;
        } }
        public string dynastyName { get { return m_DynastyName; } }
        public char country { get { return m_Country; } }
        public int BirthRollsMade { get { return m_BirthRollsMade; } }
        public int DynastyId { get { return m_DynastyId; } }
        public int SpouseId { get { return m_SpouseId; } }
        public Boolean Dead { get { return m_Dead; } }
        public Boolean Prisoner { get { return m_Prisoner; } }

        #endregion

        
        //constructor
        private Character() {
        
        }


        public Character(DataRow dr) :this()
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
                if (dr["CharacterId"] != DBNull.Value)
                    this.m_CharacterId = Convert.ToInt32(dr["CharacterId"]);
                if (dr["FirstName"] != DBNull.Value)
                    this.m_firstName = (dr["FirstName"].ToString());
                if (dr["Str"] != DBNull.Value)
                    this.m_str = Convert.ToInt32(dr["Str"]);
                if (dr["Cha"] != DBNull.Value)
                    this.m_cha = Convert.ToInt32(dr["Cha"]);
                if (dr["Con"] != DBNull.Value)
                    this.m_con = Convert.ToInt32(dr["Con"]);
                if (dr["Gender"] != DBNull.Value)
                    this.m_gender = Convert.ToChar(dr["Gender"]);
                if (dr["King"] != DBNull.Value)
                    this.m_king = Convert.ToBoolean(dr["King"]);
                if (dr["Born"] != DBNull.Value)
                    this.m_born = Convert.ToInt32(dr["Born"]);
                if (dr["DynastyName"] != DBNull.Value)
                    this.m_DynastyName = (dr["DynastyName"].ToString());
                if (dr["Country"] != DBNull.Value)
                    this.m_Country = Convert.ToChar(dr["Country"]);
                if (dr["BirthRollsMade"] != DBNull.Value)
                    this.m_BirthRollsMade = Convert.ToInt32(dr["BirthRollsMade"]);
                if (dr["DynastyId"] != DBNull.Value)
                    this.m_DynastyId = Convert.ToInt32(dr["DynastyId"]);
                if (dr["SpouseId"] != DBNull.Value)
                    this.m_SpouseId = Convert.ToInt32(dr["SpouseId"]);
                if (dr["Dead"] != DBNull.Value)
                    this.m_Dead = Convert.ToBoolean(dr["Dead"]);
                if (dr["Prisoner"] != DBNull.Value)
                    this.m_Prisoner = Convert.ToBoolean(dr["Prisoner"]);
            }
            catch (Exception ex) {
                throw;

            }


        }





    }
}