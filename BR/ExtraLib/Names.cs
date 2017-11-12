using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BR.ExtraLib
{
    public  class Names
    {
        public static String getName(char country , char gender)
        { 
            string returnvalue ="";


            if (gender=='M')
            {
                switch (country)
                { 
                    case 'E':
                        returnvalue = EnglandMale[ExtraLib.Dice.d23()];
                        break;
                    case 'F':
                        returnvalue = FranceMale[ExtraLib.Dice.d23()];
                        break;
                    case 'G':
                        returnvalue = GermanyMale[ExtraLib.Dice.d23()];
                        break;
                    case 'I':
                        returnvalue = ItalyMale[ExtraLib.Dice.d23()];
                        break;
                    case 'S':
                        returnvalue = SpainMale[ExtraLib.Dice.d23()];
                        break;
                
                }
 
            }
            else
            {
                switch (country)
                {
                    case 'E':
                        returnvalue = EnglandFemale[ExtraLib.Dice.d23()];
                        break;
                    case 'F':
                        returnvalue = FranceFemale[ExtraLib.Dice.d23()];
                        break;
                    case 'G':
                        returnvalue = GermanyFemale[ExtraLib.Dice.d23()];
                        break;
                    case 'I':
                        returnvalue = ItalyFemale[ExtraLib.Dice.d23()];
                        break;
                    case 'S':
                        returnvalue = SpainFemale[ExtraLib.Dice.d23()];
                        break;

                }
               
            }
            return returnvalue;
        }
     
        public static string[] EnglandDynastic = {"Acton", "Essex", "Griffith", "Halifax", "Lancaster",
"Landon", "Morgan", "Newbury", "Percy", "Plantagenet",
"Stuart", "Tudor", "Windsor", "York" }; 
        private static string[] EnglandMale = {"Albert", "Alfred", "Allen", "Canute", "Cenwulf", "Charles",
"Edgar", "Edmund", "Edward", "Eldred", "Ethelbert", "Geoffrey",
"George", "Harold","Henry", "Hugh", "James", "John", "Oliver",
"Richard", "Stephen", "Thomas", "William" };
        private static string[] EnglandFemale = { "Abigail", "Agatha","Anne", "Beverly", "Bonnie",
"Carolyn", "Edith", "Eleanor","Elizabeth", "Faith", "Grace",
"Hayley", "Heather", "Jane", "Lynn", "Mary", "Maud", "Megan",
"Piper", "Raven", "Twyla", "Victoria", "Wendy" };

        public static string[] FranceDynastic = { "Angevin", "Anjou", "Bourbon", "Capet", "Dubois", "Durand", "Guise", "Laurent", "Lyon", "Martel", "Nevers", "Orleans", "Rousseau", "Valois" };
        private static string[] FranceMale = { "Armand", "Carloman", "Charles", "Claude","Francois", "Gaston", "Guillaume", "Henri","Hugh", "Jacque", "Jean", "Leon", "Lothaire", "Louis", "Odo", "Pascal", "Peppin", "Philip", "Pierre", "Remy", "Rene", "Robert", "Yves" };
        private static string[] FranceFemale = { "Aimee", "Alaine", "Annette", "Babette", "Chantel", "Charlotte", "Claire", "Claudette", "Darcy", "Dominique", "Fayette", "Heloise", "Isabelle", "Jeanette", "Josephine", "Louise", "Marie","Michelle", "Monique", "Odette", "Roxanne", "Simone", "Suzette" };

        public static string[] GermanyDynastic = { "Adler", "Baden", "Bayern", "Brunswick", "Faust", "Hanover", "Hapsburg", "Hohenzollern", "Loewe", "Luxemburg", "Welf", "Wettin", "Wittelsbach", "Wurttemberg" };
        private static string[] GermanyMale = { "Adolf","Arnell", "Baldric", "Deitrich", "Einhard", "Erich", "Ferdinand", "Franz", "Friedrich", "Heinrich", "Johan", "Jurgen", "Karl", "Konrad", "Lothar", "Ludwig", "Manfred", "Maximilian", "Otto", "Rudolf", "Sigmund", "Wilhelm", "Wolfgang" };
        private static string[] GermanyFemale = { "Anna", "Armina", "Bertha", "Brunhilda", "Cecilia", "Erma", "Elsa","Frieda", "Gertrude", "Griselda", "Hedda", "Hilda", "Helga", "Heidi", "Ingeborg", "Johanna", "Karla", "Katharina", "Liesel", "Magda", "Mathilda", "Rikka", "Trude" };

        public static string[] ItalyDynastic = {"Ianchi", "Conti", "De Luca","Gallo", "Leone", "Lombardi", "Medici","Moretti", "Nicola", "Ordelaffi", "Orsini", "Rossi", "Savoy", "Visconti" }; 
        private static string[] ItalyMale = { "Alberto", "Aldo", "Angelo", "Bartolomeo", "Bernardino", "Carlo", "Eduardo", "Emmanuel", "Enrico", "Felicio", "Francis", "Giovanni", "Giuseppe", "Lorenzo", "Luigi", "Matteo", "Orlando", "Paolo", "Rinaldo", "Romano", "Salvatore", "Tito", "Vito"  };
        private static string[] ItalyFemale = {"Adriana", "Angela", "Benedetta", "Berengaria", "Blanche", "Carlotta", "Cira", "Donna", "Fiorenza", "Gabriella", "Gemma", "Isabella", "Liliana", "Lunetta", "Maria", "Mona", "Oriana", "Rosalia", "Rosetta", "Sancia", "Serena", "Trista", "Viviana" };

        public static string[] SpainDynastic = {"Castillo", "Delgado", "Flores", "Guzman", "Mendoza", "Ortega", "Ortiz", "Perez", "Rios", "Romero", "Salazar", "Santiago", "Toledo", "Vargas"  }; 
        private static string[] SpainMale = { "Alfonso", "Bernardo", "Carlos", "Diego", "Ernesto", "Esteban", "Fernando", "Fidel", "Francisco", "Galeno", "Indigo", "Jose", "Juan", "Manuel","Marcos", "Miguel", "Naldo", "Pedro", "Ramon", "Ricardo", "Rodrigo", "Sebastian", "Tulio"  };
        private static string[] SpainFemale = { "Alita", "Alona", "Angelina", "Belinda", "Benita", "Brigida", "Candida", "Eldora", "Esperanza", "Hermosa", "Isabella", "Juanita", "Linda", "Loretta", "Maria", "Olivia", "Paloma", "Ramona", "Rita", "Sofia", "Teressa", "Vittoria", "Yolanda"  };
    }
}