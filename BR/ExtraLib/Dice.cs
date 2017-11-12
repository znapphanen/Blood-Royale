using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BR.ExtraLib
{
    public class Dice
    {
        private static  Random d = new Random();

       public static int d6() {
           int dice = d.Next(1, 7);
           return dice;
        }

       public static int d23() 
       {
           int dice = d.Next(0, 23);
           return dice;
       }

       public static char male(){
            char gender ;

            if (d.Next(0, 2) == 0)
            {
                gender = 'F';
            } else
            {
                gender = 'M';

            }

           return gender;
        }

       public static int createStat() {
           int roll = d6() + d6() + d6();
           int score=-3;

           if (roll < 6){score= -2;}
           if (roll > 5 && roll < 9){score= -1;}
           if (roll >8 && roll < 13) { score = 0;}
           if (roll > 12 && roll <16){score= 1;}
           if (roll > 15 ){score= 2;}


           return score;
       }
/* to be removed
     public static void  diceTest(int x){
          
            int one=0;
            int two=0;
            int three=0;
            int four=0;
            int five=0;
            int six=0;

            for(int i=0;i < x ;i++)
            {
                switch (d6())
                { 
                    case 1:
                       one++;
                       break;
                    case 2:
                        two++;
                        break;
                    case 3:
                        three++;
                        break;
                    case 4:
                        four++;
                        break;
                    case 5:
                        five++;
                        break;
                    case 6:
                        six++;
                        break;


                }
            
            }

        }

        */
    }
}