using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BR.Model;

namespace BR.ExtraLib
{
    public class DynasticSequence
    {
        public static void Breed(int motherId, int turn, int gameId)
        {
            if ((Dice.d6() + Dice.d6()) > 6)
            {
                char gender = Dice.male();
                string name = "";
                Character father = Sql.getSpouse(motherId);
                Model.Dynasty fd = Sql.getDynasty(father.DynastyId);

                switch (fd.country)
                {
                    case 'E':
                        if (gender=='M')
                        {
                            //name = Names.EnglandMale[ExtraLib.Dice.d23()];
                            name = Names.getName('E', gender);
                            
                        }
                        else
                        {
                            //name = Names.EnglandFemale[ExtraLib.Dice.d23()];
                            name = Names.getName('E', gender);
                        }
                        break;
                    case 'F':
                        if (gender == 'M')
                        {
                            //name = Names.FranceMale[ExtraLib.Dice.d23()];
                            name = Names.getName('F', gender);
                        }
                        else
                        {
                          //  name = Names.FranceFemale[ExtraLib.Dice.d23()];
                            name = Names.getName('F', gender);
                        }
                        break;
                    case 'G':
                        if (gender == 'M')
                        {
                           // name = Names.GermanyMale[ExtraLib.Dice.d23()];
                            name = Names.getName('G', gender);
                        }
                        else
                        {
                           // name = Names.GermanyFemale[ExtraLib.Dice.d23()]; 
                            name = Names.getName('G', gender);
                        }
                        break;
                    case 'I':
                        if (gender == 'M')
                        {
                            //name = Names.ItalyMale[ExtraLib.Dice.d23()];
                            name = Names.getName('I', gender);
                        }
                        else
                        {
                            //name = Names.ItalyFemale[ExtraLib.Dice.d23()];
                            name = Names.getName('I', gender);
                        }
                        break;
                    case 'S':
                        if (gender == 'M')
                        {
                           // name = Names.SpainMale[ExtraLib.Dice.d23()];
                            name = Names.getName('S', gender);
                        }
                        else
                        {
                           // name = Names.SpainFemale[ExtraLib.Dice.d23()];
                            name = Names.getName('S', gender);
                        }
                        break;


                }




                ExtraLib.Sql.CreateCharacter(name, Dice.createStat(), Dice.createStat(), Dice.createStat(), gender, turn, gameId, father.characterId, motherId, father.DynastyId);
            }
            ExtraLib.Sql.increaseBirthRolles(motherId);

        }

        public static void BreedAll(int gameId, int turn)
        {
            Model.CharacterCollection cc = Model.CharacterCollection.getBreedingCharacters(gameId, -1);

            foreach (Character c in cc)
            {
                Breed(c.characterId, turn, gameId);

            }

        }

        /// <summary>
        /// Returns true if it survives
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        private static bool Survive(int characterId, ref List<List<Character>> theListOfLists)
        {
            Character c = ExtraLib.Sql.getCharacter(characterId);
            int survNbr = 0;
            List<Character> possibleHeirs = new List<Character>();

            if (c.age < 15)
            {
                survNbr = -20; // auto success
            }
            if (c.age == 15)
            {
                survNbr = 3;
            }

            if (c.age > 15 && c.age < 45)
            {
                survNbr = 4;
            }
            if (c.age == 45)
            {
                survNbr = 5;
            }
            if (c.age == 50)
            {
                survNbr = 6;
            }
            if (c.age == 55)
            {
                survNbr = 7;
            }
            if (c.age == 60)
            {
                survNbr = 8;
            }
            if (c.age == 65)
            {
                survNbr = 9;
            }
            if (c.age > 65 && c.age < 85)
            {
                survNbr = 10;
            }
            if (c.age > 80)
            {
                survNbr = 11;
            }

            if (c.BirthRollesMade > 1)
            {
                survNbr = survNbr + c.BirthRollesMade - 1;
            }

            survNbr = survNbr - c.con;

            if ((Dice.d6() + Dice.d6()) < survNbr)
            {
                possibleHeirs = Death(c);
                if (possibleHeirs != null)
                {
                    //it was a king and it is a possible passover
                    theListOfLists.Add(possibleHeirs);
                }
                return false;
            }
            else
            {
                if (c.BirthRollesMade > 0)
                {

                    Sql.resetBirthRolles(characterId);
                }
                return true;
            }

        }

        /// <summary>
        /// 
        /// When a character fails surviveroll or get killed in battle
        /// </summary>
        /// <param name="c"></param>
        /// <returns>A characterList if more than one heir, returns null if only one heir or no heir</returns>
        public static List<Character> Death(Character c)
        {
            if (c != null) 
            {
                
                
                if (c.King)
                {

                    // heirList.Clear();
                    List<Character> HeirList = FindHeir(c.characterId);
                    List<Character> PossibleHeirList = new List<Character>();
                    int x = -1;

                    if (HeirList.Count > 0)
                    {
                        do
                        {
                            x++;
                            PossibleHeirList.Add(HeirList[x]);

                        } while (x < HeirList.Count - 1 && (HeirList[x].Prisoner == true || (HeirList[x].Gender == 'F' && HeirList[x].SpouseId > 0))); //add anotherheir to list if the heir is in prison or a married woman

                        Sql.kill(c.SpouseId);  //The queen cant remarry and is out of the game
                        Sql.kill(c.characterId);

                        if (PossibleHeirList.Count > 1) //passover possible
                        {

                            return PossibleHeirList;

                        }
                        else
                        {
                            Sql.crownKing(PossibleHeirList.ElementAt(0).characterId);

                        }

                    }
                    else
                    {
                        Sql.kill(c.SpouseId);  //The queen cant remarry and is out of the game
                        Sql.kill(c.characterId);

                    }



                }
                else
                {
                    Sql.kill(c.characterId);
                    Sql.unMarry(c.SpouseId); // so she or he can marry again 
                }
            
            }

            return null;

        }


        public static Model.CharacterCollection SurviveAll(int gameId,ref List<List<Character>> theListOfLists)
        {
            //roll surv youngest first , (highest charId)
            Model.CharacterCollection cc = new Model.CharacterCollection();

            List<int> allCharacters = Sql.getAliveCharacterIds(gameId);
            foreach (int element in allCharacters)
            {
                if (!Survive(element, ref theListOfLists))
                { 
                    //It died
                    
                    cc.Add(Sql.getCharacter(element));
                }
            }
            return cc;
        }


        
    //    public static bool passoverPossible = false;
        //dont mix in passover here, take care of it later just return a heir list
        //make it return void




        public static List<Character> FindHeir(int CharacterId)
        {
            List<Character> heirList = new List<Character>();
            List<Character> kidsList = new List<Character>();

            // all heirs dead or alive and ordered after male and then by Id
            BR.Model.CharacterCollection heirs = BR.Model.CharacterCollection.getAllHeirs(CharacterId);

            foreach (Character element in heirs)
            {

                if (!element.Dead) //alive
                {
                   
                    heirList.Add(element);
                    
                }

                
                kidsList = FindHeir(element.characterId);
                foreach (Character kid in kidsList)
                {
                    heirList.Add(kid);

                }
               


            }
            return heirList;
        }


        public static Boolean IdBelongsToThisGame(int id, int gameId)
        {
            int charactersGameId = ExtraLib.Sql.getGameIdForCharacter(id);

            if ( charactersGameId == gameId)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }


}