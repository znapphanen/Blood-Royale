using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace BR.Model
{
    [DataObject(true)]
    public class CharacterCollection :List<Character>
    {


        public CharacterCollection() {


        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CharacterCollection getAllCharacters(int dynastyId) {
           
            CharacterCollection cc = new CharacterCollection();


            using (SqlConnection cn =  DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select * from vCharacters WHERE DynastyId = " + dynastyId + " AND Dead = 'FALSE'; ";
                SqlCommand cmd = new SqlCommand(query,cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {  
                        foreach (DataRow dr in dt.Rows)
                        {
                            cc.Add(new Character(dr));
                        }
                }

                return cc;
            }           
        }



        public static CharacterCollection getAllHeirs(int id)
        {
            CharacterCollection cc = new CharacterCollection();

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())  
            {
                string query = "Select * FROM vCharacters WHERE (FatherId= " + id + " OR MotherId = " + id + ") ORDER BY Gender Desc, CharacterId Asc ;";
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
                        cc.Add(new Character(dr));
                    }
                }

                return cc;
            }

        }

        

        /// <summary>
        /// If dynastyId is 0 or less it gets from all Dynasties
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="dynastyId"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CharacterCollection getBreedingCharacters(int gameId, int dynastyId, int turn) {
            CharacterCollection cc = new CharacterCollection();

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                SqlCommand cmd = new SqlCommand("GetBreedingCharacters", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@GameId", gameId));
                cmd.Parameters.Add(new SqlParameter("@DynastyId", dynastyId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //Could be in the procedure but its simpler to add it here.  So I  do the filtering here for "age 50 yrs and younger"  
                        if (Convert.ToInt32(dr["Born"])  > turn - 11)
                        {
                            
                                cc.Add(new Character(dr));
                            
                            
                        }
                       
                    }
                }

                return cc;
            }
        
        
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CharacterCollection getNewlyBorns(int gameId, int dynastyId) {

            CharacterCollection cc = new CharacterCollection();

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                SqlCommand cmd = new SqlCommand("GetNewlyBorns", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@GameId", gameId));
                cmd.Parameters.Add(new SqlParameter("@DynastyId", dynastyId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cc.Add(new Character(dr));
                    }
                }

                return cc;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CharacterCollection getAvailable( int dynastyId) //gets marriagable characters for a dynasty
        {

            CharacterCollection cc = new CharacterCollection();

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                SqlCommand cmd = new SqlCommand("GetAvailable", cn);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.Add(new SqlParameter("@DynastyId", dynastyId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cc.Add(new Character(dr));
                    }
                }

                return cc;
            }
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CharacterCollection getAllAvailable(int gameId) //for all dynasties
        {

            CharacterCollection cc = new CharacterCollection();

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                SqlCommand cmd = new SqlCommand("GetAllAvailable", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@GameId", gameId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cc.Add(new Character(dr));
                    }
                }

                return cc;
            }
        }
    }
}