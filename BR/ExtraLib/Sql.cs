using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using BR.Model;
using System.Data.SqlClient;

namespace BR.ExtraLib
{
    public class Sql 
    {
        #region Characters
        public static List<int> getAliveCharacterIds(int gameId)
        {
           List<int> aci = new List<int>();

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = @"SELECT CharacterId 
                                FROM vCharacters 
                                WHERE GameId=" + gameId + 
                             @" AND Dead = 'FALSE' 
                                ORDER BY CharacterId DESC;";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    for (int i =0; i < dt.Rows.Count;i++)
                    {

                        aci.Add ( Convert.ToInt32(dt.Rows[i]["CharacterId"]));
                    }
                }
            }
            return aci;
        
        }



        public static Character getCharacter(int id)
        {
            

            Character c = null;

            

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "SELECT * FROM vCharacters where CharacterId=" + id.ToString() + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        c = new Character(dt.Rows[0]);

                    }
                }
            }
            return c;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="str"></param>
        /// <param name="cha"></param>
        /// <param name="con"></param>
        /// <param name="gender"></param>
        /// <param name="turn"></param>
        /// <param name="gameId"></param>
        /// <param name="fatherId"></param>
        /// <param name="motherId"></param>
        /// <param name="DynastyId"></param>
        /// <returns>Id</returns>
        public static int CreateCharacter(string FirstName, int str, int cha, int con, char gender, int turn, int gameId, int fatherId, int motherId, int DynastyId)
        {

            if (FirstName.Length > 15) 
            {
                FirstName = FirstName.Substring(0, 15);
            
            }

            int returnvalue = -1;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
              //  int m = Convert.ToInt16(male);


                SqlCommand cmd = new SqlCommand("CreateCharacter", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                cmd.Parameters.Add(new SqlParameter("@Str", str));
                cmd.Parameters.Add(new SqlParameter("@Cha", cha));
                cmd.Parameters.Add(new SqlParameter("@Con", con));
                cmd.Parameters.Add(new SqlParameter("@Gender",  gender));
                cmd.Parameters.Add(new SqlParameter("@Born", turn));
                cmd.Parameters.Add(new SqlParameter("@GameId", gameId));
                cmd.Parameters.Add(new SqlParameter("@FatherId", fatherId));
                cmd.Parameters.Add(new SqlParameter("@MotherId", motherId));
                cmd.Parameters.Add(new SqlParameter("@DynastyId", DynastyId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Last Insert"] != DBNull.Value)
                        {
                            returnvalue = Convert.ToInt32(dt.Rows[0]["Last Insert"]);
                        }
                    }
                }

            }
            return returnvalue;
        }

        public static void crownKing(int characterId)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET King = 'TRUE' WHERE CharacterId= " + characterId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }
      /// <summary>
      /// Changes a characters first name. Max length is 15 letters
      /// 
      /// </summary>
      /// <param name="characterId"></param>
      /// <param name="name"></param>
      /// <returns></returns>
        public static bool changeName(int characterId, string name)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                if (name.Length <= 15)
                {
                    string query = "Update Characters SET FirstName = '" + name + "' WHERE CharacterId= " + characterId + ";";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader(); 
                    return true;
                }
                else 
                {
                    return false;
                }
                

                
            }
        }

        /// <summary>
        /// Marry 2 ppl.
        /// It dosnt matter if husband and wife is in the correct parameter. (ie. sex dosn't matter)
        /// </summary>
        /// <param name="husbandId"></param>
        /// <param name="wifeId"></param>
        public static void marriage(int husbandId, int wifeId)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                SqlCommand cmd = new SqlCommand("Marriage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Husband", husbandId));
                cmd.Parameters.Add(new SqlParameter("@Wife", wifeId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void makeContract(string contractText, int characterOne, int characterTwo, int gameId) 
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "INSERT INTO Contracts ( ContractText,PartOne,PartTwo,GameId) VALUES ('" + contractText + "'," + characterOne + "," + characterTwo +  "," + gameId + ");";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void unMarry(int characterId)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET SpouseId = null WHERE CharacterId= " + characterId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                reader.Close();

                query = "DELETE FROM Contracts WHERE PartOne = " + characterId + " OR PartTwo = " + characterId +  ";";
                cmd = new SqlCommand(query, cn);
                
                
                reader = cmd.ExecuteReader();

            }
        }

       




        public static Character getSpouse(int id)
        {
            Character c = null;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select * FROM vCharacters WHERE SpouseId= " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        c = new Character(dt.Rows[0]);

                    }
                }
            }
            return c;
        }

        /// <summary>
        /// Used for proposal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getCountryFromCharacterId(int id) //this methode could be useless, I could just refresh all gv's
        {
            string returnvalue = "";

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "SELECT d.Country FROM Dynasties d inner join Characters c ON d.DynastyId= c.DynastyId where c.CharacterId = " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        returnvalue = (string)dt.Rows[0]["Country"];

                    }
                }
            }
            return returnvalue;
        }

        public static void kill(int id)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET Dead = 'TRUE' WHERE CharacterId= " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void imprison(int id)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET Prisoner = 'TRUE' WHERE CharacterId= " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void release(int id)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET Prisoner = 'FALSE' WHERE CharacterId= " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static int getGameIdForCharacter(int id) 
        {
            int returnvalue =0 ;
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                
                string query = "Select GameId FROM Characters WHERE CharacterId = " + id ;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        returnvalue = (int)dt.Rows[0]["GameId"];

                    }
                }
            }
            return returnvalue;
        }
        

#endregion



        public static void increaseBirthRolles(int id)
        {

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET BirthRollesMade = BirthRollesMade+1 WHERE CharacterId= " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void resetBirthRolles(int id) 
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Characters SET BirthRollesMade = 0 WHERE CharacterId= " + id + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

      
        #region games


        public static void DeleteGame(int id)
        {
             
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
               

                SqlCommand cmd = new SqlCommand("DeleteGame", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@GameId", id));               
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
            }
            
        }

        public static Game createGame(string gameName, string loggedInUserId) 
        {

            BR.Model.Game gc = null; //the created game

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {

                SqlCommand cmd = new SqlCommand("CreateGame", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@GameName", gameName));
                cmd.Parameters.AddWithValue("@Creator", loggedInUserId);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            gc = new BR.Model.Game(dr);
                        }
                    }
                }
            }
            return gc;

        }

        public static void increaseTurn(int gameId)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "UPDATE Games SET Turn = Turn + 1  WHERE GameId = " + gameId + " ;";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }


        }
       
       

      
        public static String getGamesFromUserId2(int userId)
        { //verbatim string literal:
            return @"SELECT * FROM Games WHERE GameId IN
                    (SELECT GameId FROM Dynasties WHERE UserId= "  + userId + ");";
        }

        public static String getGamesFromUserId3(int userId)  //adding creator to the gamelist
        { //verbatim string literal:
            return @"SELECT * FROM Games WHERE GameId IN
                    (SELECT GameId FROM Dynasties WHERE UserId= " + userId + ") OR Creator = " + userId + ";";
        }

        public static String getGameFromGameId(int gameId) 
        {
            return "SELECT * FROM Games WHERE GameId= "+ gameId + ";";
        }

        #endregion


        #region users

        public static int getUserIdFromName(string userName)
        {
            int userId = -1;
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select UserId FROM Users WHERE UserName= '" + userName + "';";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UserId"] != DBNull.Value)
                        {
                            userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                        }
                    }
                }
            }
            return userId;

        }


        public static User getUserFromId(int userId)
        {
            User u = null;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select * FROM Users WHERE UserId= " + userId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        u = new User(dt.Rows[0]);
                    }
                }
            }
            return u;

        }


        public static List<BR.Model.User> getAllUsers() {
            List<Model.User> userlist = new List<Model.User>(); 
            
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "SELECT * FROM Users";
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
                        userlist.Add(new BR.Model.User(dr));
                    }
                }

                return userlist;
            }
        }

        public static void createUser(String userName, String password, String email)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "INSERT INTO Users ( UserName,Password,Email) VALUES ('" + userName + "','"+ password + "','" + email+"');";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>The Userid if login is succesfull, -1 if unsuccesfull</returns>
        public static int login(string userName, string password)
        {

            int returnvalue = -1;
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {



                SqlCommand cmd = new SqlCommand("Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserName", userName.ToLower())); //Makes username lowercase so it isnt case sensitive. 
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["@UserId"] != DBNull.Value)
                        {
                            returnvalue = Convert.ToInt32(dt.Rows[0]["@UserId"]);
                        }
                    }


                }

            }
            return returnvalue;
        }



        #endregion


        #region Dynasty
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dynastyName"></param>
        /// <param name="userName"></param>
        /// <param name="gameId"></param>
        /// <param name="country"></param>
        /// <returns>DynastyId</returns>
        public static int createDynasty(String dynastyName, string userName, int gameId, char country) 
        {
            int returnvalue=-1;

            int userId = getUserIdFromName(userName);

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {


                SqlCommand cmd = new SqlCommand("CreateDynasty", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@DynastyName", dynastyName));
                cmd.Parameters.Add(new SqlParameter("@Country", country));
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));  //The player of the dynasty
                cmd.Parameters.Add(new SqlParameter("@GameId", gameId));
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows[0]["Last Insert"] != DBNull.Value)
                    {
                        returnvalue = Convert.ToInt32(dt.Rows[0]["Last Insert"]);
                    }
                }
            }
            return returnvalue;
        }

    
    
        //TODO: make enum for country
        public static int getDynastyId(int gameId, char country) {
            int returnvalue = -1;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select DynastyId FROM Dynasties WHERE GameId= '" + gameId + "' AND Country= '" + country + "';";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["DynastyId"] != DBNull.Value)
                        {
                            returnvalue = Convert.ToInt32(dt.Rows[0]["DynastyId"]);
                        }
                    }
                }
            }

            return returnvalue;
        
        }

        
        public static Dynasty getDynasty(int dynastyId)
        {
            Dynasty d = null;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select * FROM Dynasties WHERE DynastyId= " + dynastyId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        d = new Dynasty(dt.Rows[0]);

                    }
                }
            }
            return d;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public static Dynasty getDynasty(int userId, int gameId)
        {
            Dynasty d = null;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select * FROM Dynasties WHERE UserId= " + userId + " AND GameId= "+ gameId +";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        d = new Dynasty(dt.Rows[0]);

                    }
                }
            }
            return d;

        }

        #endregion

        public static void increaseDynasticSequence(int gameId, int newNumber)
        {

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Update Games SET DynasticSequence = "+ newNumber +" WHERE GameId= " + gameId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static int getDynasticSequence(int gameId)
        {
            int returnvalue = 0;
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "Select DynasticSequence FROM Games WHERE GameId = " + gameId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["DynasticSequence"] != DBNull.Value)
                        {
                            returnvalue = Convert.ToInt32(dt.Rows[0]["DynasticSequence"]);
                        }
                    }
                }
                return returnvalue;
            }
        }

        #region marriageOffers

        public static void createMarriageOffer(int offererId, int targetId, String contract, int gameId)
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "INSERT INTO MarriageOffers ( OffererId,TargetId,ContractText,GameId) VALUES (" + offererId + "," + targetId + ",'" + contract + "'," + gameId +");";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void emptyMarriageOffers(int gameId) //delete all offers when changing phase
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "DELETE FROM MarriageOffers where GameId = " + gameId + ";";  
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        
        }
        /// <summary>
        /// Delete all marriageOffers thats connected to the characters ID. 
        /// </summary>
        /// <param name="characterId"></param>
        public static void deleteMarriageOffer(int characterId) 
        {
            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "DELETE FROM MarriageOffers where OffererId = " + characterId +" or TargetId= " + characterId + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
            }

        }

        public static MarriageOffer getMarriageOffer(int id)
        {


            MarriageOffer mo = null;

            using (SqlConnection cn = DataAccess.DataAccessFactory.GetDataAccess())
            {
                string query = "SELECT * FROM vMarriageOffers where MarriageOfferId=" + id.ToString() + ";";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {

                        mo = new MarriageOffer(dt.Rows[0]);

                    }
                }
            }
            return mo;
        }
        #endregion
    }
}