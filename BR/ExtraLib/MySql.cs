using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using BR.Model;
using System.Data.SqlClient;

/* NOT USED */

namespace BR.ExtraLib
{
    public class MySql
    {
        #region Characters
        public static List<int> getAliveCharacterIds(int gameId)
        {
            List<int> aci = new List<int>();

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = @"SELECT CharacterId 
                                FROM vCharacters 
                                WHERE GameId=" + gameId +
                             @" AND Dead = false 
                                ORDER BY CharacterId DESC;";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        aci.Add(Convert.ToInt32(dt.Rows[i]["CharacterId"]));
                    }
                }
            }
            return aci;

        }



        public static Character getCharacter(int id)
        {


            Character c = null;



            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "SELECT * FROM vCharacters where CharacterId=" + id.ToString() + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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
        /// <param name="male"></param>
        /// <param name="turn"></param>
        /// <param name="gameId"></param>
        /// <param name="fatherId"></param>
        /// <param name="motherId"></param>
        /// <param name="DynastyId"></param>
        /// <returns>Id</returns>
        public static int CreateCharacter(string FirstName, int str, int cha, int con, Boolean male, int turn, int gameId, int fatherId, int motherId, int DynastyId)
        {

            if (FirstName.Length > 15)
            {
                FirstName = FirstName.Substring(0, 15);

            }

            int returnvalue = -1;

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {



                MySqlCommand cmd = new MySqlCommand("CreateCharacter", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_FirstName", FirstName));
                cmd.Parameters.Add(new MySqlParameter("_Str", str));
                cmd.Parameters.Add(new MySqlParameter("_Cha", cha));
                cmd.Parameters.Add(new MySqlParameter("_Con", con));
                cmd.Parameters.Add(new MySqlParameter("_Male", male));
                cmd.Parameters.Add(new MySqlParameter("_Born", turn));
                cmd.Parameters.Add(new MySqlParameter("_GameId", gameId));
                cmd.Parameters.Add(new MySqlParameter("_FatherId", fatherId));
                cmd.Parameters.Add(new MySqlParameter("_MotherId", motherId));
                cmd.Parameters.Add(new MySqlParameter("_DynastyId", DynastyId));
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);


                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["last_insert_id()"] != DBNull.Value)
                        {
                            returnvalue = Convert.ToInt32(dt.Rows[0]["last_insert_id()"]);
                        }
                    }
                }

            }
            return returnvalue;
        }

        public static void crownKing(int characterId)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Update Characters SET King = true WHERE CharacterId= " + characterId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                if (name.Length <= 15)
                {
                    string query = "Update Characters SET FirstName = '" + name + "' WHERE CharacterId= " + characterId + ";";
                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cn.Open();
                    MySqlDataReader reader;
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
        /// It dosnt matter if husband and wife is in the correct parameter. (ie. sex dosnt matter)
        /// </summary>
        /// <param name="husbandId"></param>
        /// <param name="wifeId"></param>
        public static void marriage(int husbandId, int wifeId)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                MySqlCommand cmd = new MySqlCommand("Marriage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_Husband", husbandId));
                cmd.Parameters.Add(new MySqlParameter("_Wife", wifeId));
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void makeContract(string contractText, int characterOne, int characterTwo, int gameId)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "INSERT INTO Contracts ( ContractText,PartOne,PartTwo,GameId) VALUES ('" + contractText + "'," + characterOne + "," + characterTwo + "," + gameId + ");";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void unMarry(int characterId)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Update Characters SET SpouseId = null WHERE CharacterId= " + characterId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                reader.Close();

                query = "DELETE FROM Contracts WHERE PartOne = " + characterId + " OR PartTwo = " + characterId + ";";
                cmd = new MySqlCommand(query, cn);


                reader = cmd.ExecuteReader();

            }
        }






        public static Character getSpouse(int id)
        {
            Character c = null;

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select * FROM vCharacters WHERE SpouseId= " + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "SELECT d.Country FROM Dynasties d inner join Characters c ON d.DynastyId= c.DynastyId where c.CharacterId = " + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Update Characters SET Dead = true WHERE CharacterId= " + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }


        #endregion



        public static void increaseBirthRolles(int id)
        {

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Update Characters SET BirthRollesMade = BirthRollesMade+1 WHERE CharacterId= " + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void resetBirthRolles(int id)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Update Characters SET BirthRollesMade = 0 WHERE CharacterId= " + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }


        #region games


        public static void DeleteGame(int id)
        {

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {

                MySqlCommand cmd = new MySqlCommand("DeleteGame", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_GameId", id));
                cn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

            }

        }

        public static Game createGame(string gameName, string loggedInUserId)
        {

            BR.Model.Game gc = null; //the created game

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {

                MySqlCommand cmd = new MySqlCommand("CreateGame", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_GameName", gameName));
                cmd.Parameters.AddWithValue("_Creator", loggedInUserId);
                cn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
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
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "UPDATE Games SET Turn = Turn + 1  WHERE GameId = " + gameId + " ;";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }


        }

        public static String getGamesFromUserId(int userId)
        { //verbatim string literal:
            return @"SELECT * FROM Games g 
                     INNER JOIN UserPlayingGames upg 
                     ON upg.GameId = g.GameId 
                     WHERE upg.UserId = " + userId + ";";
        }


        public static String getGamesFromUserId2(int userId)
        { //verbatim string literal:
            return @"SELECT * FROM Games WHERE GameId IN
                    (SELECT GameId FROM Dynasties WHERE UserId= " + userId + ");";
        }

        public static String getGameFromGameId(int gameId)
        {
            return "SELECT * FROM Games WHERE GameId= " + gameId + ";";
        }

        #endregion


        #region users

        public static int getUserIdFromName(string userName)
        {
            int userId = -1;
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select UserId FROM Users WHERE UserName= '" + userName + "';";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select * FROM Users WHERE UserId= " + userId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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


        public static List<BR.Model.User> getAllUsers()
        {
            List<Model.User> userlist = new List<Model.User>();

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "SELECT * FROM Users";
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
                        userlist.Add(new BR.Model.User(dr));
                    }
                }

                return userlist;
            }
        }

        public static void createUser(String userName, String password, String email)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "INSERT INTO Users ( UserName,Password,Email) VALUES ('" + userName + "','" + password + "','" + email + "');";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {



                MySqlCommand cmd = new MySqlCommand("Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_UserName", userName.ToLower())); //Makes username lowercase so it isnt case sensitive. 
                cmd.Parameters.Add(new MySqlParameter("_Password", password));
                cn.Open();
                MySqlDataReader reader;
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
            int returnvalue = -1;

            int userId = getUserIdFromName(userName);

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {


                MySqlCommand cmd = new MySqlCommand("CreateDynasty", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_DynastyName", dynastyName));
                cmd.Parameters.Add(new MySqlParameter("_Country", country));
                cmd.Parameters.Add(new MySqlParameter("_UserId", userId));  //The player of the dynasty
                cmd.Parameters.Add(new MySqlParameter("_GameId", gameId));
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                if (dt != null)
                {
                    if (dt.Rows[0]["last_insert_id()"] != DBNull.Value)
                    {
                        returnvalue = Convert.ToInt32(dt.Rows[0]["last_insert_id()"]);
                    }
                }
            }
            return returnvalue;
        }



     
        public static int getDynastyId(int gameId, char country)
        {
            int returnvalue = -1;

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select DynastyId FROM Dynasties WHERE GameId= '" + gameId + "' AND Country= '" + country + "';";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select * FROM Dynasties WHERE DynastyId= " + dynastyId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select * FROM Dynasties WHERE UserId= " + userId + " AND GameId= " + gameId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Update Games SET DynasticSequence = " + newNumber + " WHERE GameId= " + gameId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static int getDynasticSequence(int gameId)
        {
            int returnvalue = 0;
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "Select DynasticSequence FROM Games WHERE GameId = " + gameId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "INSERT INTO MarriageOffers ( OffererId,TargetId,ContractText,GameId) VALUES (" + offererId + "," + targetId + ",'" + contract + "'," + gameId + ");";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }
        }

        public static void emptyMarriageOffers(int gameId) //delete all offers when changing phase
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "DELETE FROM MarriageOffers where GameId = " + gameId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }

        }
        /// <summary>
        /// Delete all marriageOffers thats connected to the characters ID. 
        /// </summary>
        /// <param name="characterId"></param>
        public static void deleteMarriageOffer(int characterId)
        {
            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "DELETE FROM MarriageOffers where OffererId = " + characterId + " or TargetId= " + characterId + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
            }

        }

        public static MarriageOffer getMarriageOffer(int id)
        {


            MarriageOffer mo = null;

            using (MySqlConnection cn = DataAccess.DataAccessFactory.GetDataAccessMySql())
            {
                string query = "SELECT * FROM vMarriageOffers where MarriageOfferId=" + id.ToString() + ";";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cn.Open();
                MySqlDataReader reader;
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