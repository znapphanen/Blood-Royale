using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BR.ExtraLib;
using BR.Model;
using System.Collections.Generic;
//test

namespace UnitTestBr
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChangeName()
        {
            //this changes the name in the actual database
            Sql.changeName(3, "Testname");
            Sql.changeName(3, "TestnameIsToLong?");
            
        }

        [TestMethod]
        public void TestFindHeir() 
        {
            
            Game gajm =  Sql.createGame("TestGame", "1");
            int dynastyId = Sql.createDynasty("York","Per",gajm.gameId,'E');
            int kingId = Sql.CreateCharacter("King George",2,-1,0,'M',-5,gajm.gameId,-1,-1,dynastyId);
            int queenId = Sql.CreateCharacter("Queen Hanna", 2, -1, 0, 'F', -4, gajm.gameId, -1, -1, dynastyId);
            Sql.CreateCharacter("Princes Oldest", 2, -1, 0, 'F', -1, gajm.gameId, kingId, queenId, dynastyId);

            int deadId = Sql.CreateCharacter("Prince Dead", 2, -1, 0, 'M', 0, gajm.gameId, kingId, queenId, dynastyId);
            Sql.kill(deadId);
            int luke = Sql.CreateCharacter("Prince Luke1", 2, -1, 0, 'M', 0, gajm.gameId, kingId, queenId, dynastyId);
            int fredric = Sql.CreateCharacter("Prince Fredric2", 2, -1, 0, 'M', 0, gajm.gameId, kingId, queenId, dynastyId);
            int sonOfFredic = Sql.CreateCharacter("son of Fredric2", 2, -1, 0, 'M', 5, gajm.gameId, fredric, -1, dynastyId);

            
            int dod = Sql.CreateCharacter("Daugther of Dead", 2, -1, 0, 'F', 5, gajm.gameId, deadId, -1, dynastyId);
            int sod = Sql.CreateCharacter("Son of Dead", 2, -1, 0, 'M', 6, gajm.gameId, deadId, -1, dynastyId);
            

            List<Character> heirList = DynasticSequence.FindHeir(kingId);
            Assert.AreEqual(heirList[0].characterId, sod,"The heir should be Son of dead");
            Assert.AreEqual(heirList[4].characterId, sonOfFredic, "Son of freric should be 5th in line");
            Sql.DeleteGame(gajm.gameId);
        }

        [TestMethod]
        public void TestGetBreeding()
        {

            Game gajm = Sql.createGame("TestGame", "1");
            int dynastyId = Sql.createDynasty("York", "Per", gajm.gameId, 'E');
            int kingId = Sql.CreateCharacter("King George", 2, -1, 0, 'M', -15, gajm.gameId, -1, -1, dynastyId);
            int queenId = Sql.CreateCharacter("Queen Hanna", 2, -1, 0, 'F', -14, gajm.gameId, -1, -1, dynastyId);
            BR.ExtraLib.Sql.marriage(kingId, queenId);

            int luke = Sql.CreateCharacter("Prince Luke1", 2, -1, 0, 'M', -5, gajm.gameId, kingId, queenId, dynastyId);
           
            int wife = Sql.CreateCharacter("wife", 2, -1, 0, 'F', -10, gajm.gameId, kingId, -1, dynastyId);
            BR.ExtraLib.Sql.marriage(luke, wife);

            CharacterCollection.getBreedingCharacters(gajm.gameId,dynastyId,0);

            Sql.DeleteGame(gajm.gameId);
        }


        [TestMethod]
        public void TestPassoverHeir() 
        {

            Game gajm = Sql.createGame("TestGamePassOverHeir", "1");
            int dynastyId = Sql.createDynasty("York", "Per", gajm.gameId, 'E');
            int dynastyId2 = Sql.createDynasty("other", "Per", gajm.gameId, 'S');
            int kingId =  Sql.CreateCharacter("King George", 2, -1, 0, 'M', -25, gajm.gameId, -1, -1, dynastyId);
            BR.ExtraLib.Sql.crownKing(kingId);
            

            int queenId = Sql.CreateCharacter("Queen Hanna", 2, -1, 0, 'F', -4, gajm.gameId, -1, -1, dynastyId);

            int Princess = Sql.CreateCharacter("Princes Married", 2, -1, 0, 'F', -1, gajm.gameId, kingId, queenId, dynastyId);
            int spouse = Sql.CreateCharacter("Spouse", 2, -1, 0, 'M', 5, gajm.gameId, -1, -1, dynastyId2);

            BR.ExtraLib.Sql.marriage(spouse,Princess);

            int prison = Sql.CreateCharacter("Prince Prison", 2, -1, 0, 'M', 0, gajm.gameId, kingId, queenId, dynastyId);
            BR.ExtraLib.Sql.imprison(prison);

            Sql.CreateCharacter("Princes Young", 2, -1, 0, 'F', 0, gajm.gameId, kingId, queenId, dynastyId);
            Sql.CreateCharacter("Princes Youngest", 2, -1, 0, 'F', 1, gajm.gameId, kingId, queenId, dynastyId);
           
            //spain
            int sKingId = Sql.CreateCharacter("King SGeorge", 2, -1, 0, 'M', -25, gajm.gameId, -1, -1, dynastyId2);
            BR.ExtraLib.Sql.crownKing(sKingId);


            int sQueenId = Sql.CreateCharacter("Queen sHanna", 2, -1, 0, 'F', -4, gajm.gameId, -1, -1, dynastyId2);

            int sPrincess = Sql.CreateCharacter("sPrinces Married", 2, -1, 0, 'F', -1, gajm.gameId, sKingId, sQueenId, dynastyId2);
            int sSpouse = Sql.CreateCharacter("sSpouse", 2, -1, 0, 'M', 5, gajm.gameId, -1, -1, dynastyId);

            BR.ExtraLib.Sql.marriage(sSpouse, sPrincess);

            int sPrison = Sql.CreateCharacter("Prince sPrison", 2, -1, 0, 'M', 0, gajm.gameId, sKingId, sQueenId, dynastyId2);
            BR.ExtraLib.Sql.imprison(sPrison);

            Sql.CreateCharacter("Princes sYoung", 2, -1, 0, 'F', 0, gajm.gameId, sKingId, sQueenId, dynastyId2);
            Sql.CreateCharacter("Princes sYoungest", 2, -1, 0, 'F', 1, gajm.gameId, sKingId, sQueenId, dynastyId2);
           


         /*   Character theKing = Sql.getCharacter(kingId);
            DynasticSequence.Death(theKing);
            Assert.AreEqual(heirList[0].characterId, sod, "The heir should be Son of dead");
            Assert.AreEqual(heirList[4].characterId, sonOfFredic, "Son of fredric should be 5th in line"); */
          //  Sql.DeleteGame(gajm.gameId);
        }


        [TestMethod]
        public void TestMarry()
        {

            Game gajm = Sql.createGame("TestGame", "1");
            int dynastyId = Sql.createDynasty("York", "per", gajm.gameId, 'E');
            int kingId = Sql.CreateCharacter("King George", 2, -1, 0, 'M', -5, gajm.gameId, -1, -1, dynastyId);
            int queenId = Sql.CreateCharacter("Queen Hanna", 2, -1, 0, 'F', -4, gajm.gameId, -1, -1, dynastyId);

            Sql.marriage(kingId,queenId);
            Sql.makeContract("test", kingId, queenId, gajm.gameId);
            Sql.unMarry (kingId);
            Sql.DeleteGame(gajm.gameId);
        }

        [TestMethod]
        public void TestSecurity()
        {
            
            string psw = "Test";
          
            string encrypted =   BR.ExtraLib.Security.EncryptPassword(psw);

            string decrypted = BR.ExtraLib.Security.decryptPassword(encrypted);
            Assert.AreEqual(decrypted, psw);
           
        }


        [TestMethod]
        public void TestAliveKing()
        {

           List<int> dynastyList =  BR.ExtraLib.Sql.getDynastyIdsFromGame(16);

            foreach (int id in dynastyList)
            {
               int test= BR.ExtraLib.Sql.getKingForDynasty(id);
            }

            
        }

    }
}
