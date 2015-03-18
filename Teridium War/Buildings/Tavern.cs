using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Tavern
    {
        public Tavern(Hero hero)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string tavernchoice = "";
            string tavernanswer = "";
            ConsoleKeyInfo tavernanswerKey;
            do
            {
                tavernchoice = PrintTavernChoice(hero);
                ProcessTavernChoice(tavernchoice, hero);
                Console.WriteLine("Are you finished with your business here?\n(Y)es\n(N)o\n");
                tavernanswerKey = Console.ReadKey(true);
                tavernanswer = tavernanswerKey.KeyChar.ToString();
            }
            while (tavernanswer == "n" || tavernanswer == "N");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #region Tavern Process
        public static string PrintTavernChoice(Hero hero)
        {
            Console.Clear();
            ConsoleKeyInfo tavernchoiceKey;
            Console.Write(@"Welcome to the Iron Pony {0}.
              
             .::::.            
         @\\/W\/\/W\//@         
          \\/^\/\/^\//         
      ____________________ 
     |                   |    
     |   |V\_   __       |     
     |   )  o`-(..)      |     
     |   >L  (_\__/      |     
     |   / \ \  ___      |     
     |   /  ( \//(n)     |     
     |     | //\\        |     
     |   /(  /   )(n)    |    
     |    /\(   /        |    
     :     /`) /\        :
      \<>    // \\_   <>/      
       \<>  (_)  (_) <>/      
        \<>         <>/        
        `\<>       <>/'         
           `-......-`", hero.Identifier);
            Console.WriteLine("\n\n");
            Console.Write(@"What would you like to do?                                
*************************************
                   Price   HP Restore
(R)est               4        1/4  
(D)rink and Eat      2        1/8  
(E)xit

Your HP: {1}/{2}
YOur MP: {3}/{4}
Your Gold: {0}
***********************************", hero.Gold, hero.CurrentHealth, hero.MaxHealth, hero.CurrentMagic, hero.MaxMagic);
            Console.WriteLine();
            tavernchoiceKey = Console.ReadKey(true);
            string tavernchoice = tavernchoiceKey.KeyChar.ToString();
            return tavernchoice;
        }

        public void ProcessTavernChoice(string tavernchoice, Hero hero)
        {
            switch (tavernchoice)
            {
                case "R":
                case "r":
                    TavernRestore(hero, 4, 4, "rested");
                    break;

                case "D":
                case "d":
                    TavernRestore(hero, 8, 2, "drink");
                    break;

                case "E":
                case "e":
                    Console.WriteLine("Exit");
                    return;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    tavernchoice = PrintTavernChoice(hero);
                    ProcessTavernChoice(tavernchoice, hero);
                    break;
            }
        }
        #endregion

        #region functions
        public bool CheckHeroGold(int Gold, Hero hero)
        {
            bool HeroGold = false;

            if (hero.Gold >= Gold)
            {
                HeroGold = true;
            }
            return HeroGold;
        }

        public void TavernRestore(Hero hero, int zahl, int gold, string choice)
        {
            bool HeroGold = CheckHeroGold(gold, hero);
            if (HeroGold == true)
            {
                hero.Gold -= gold;
                int restorHP;
                int restorMP;
                int heroMaxHP = hero.MaxHealth;
                int heroMaxMP = hero.MaxMagic;
                restorHP = heroMaxHP / zahl;
                restorMP = heroMaxMP / zahl;
                int newHP = hero.CurrentHealth + restorHP;
                int newMP = hero.CurrentMagic + restorMP;
                if (newHP <= heroMaxHP)
                {
                    hero.CurrentHealth += restorHP;
                    if (choice == "rested")
                    {
                        Console.WriteLine("You have rested for a few hours and restored {0} HP. You have now {1} HP", restorHP, hero.CurrentHealth);
                    }
                    else
                    {
                        Console.WriteLine("You have eaten a delicious Meal and restored {0} HP. You have now {1} HP", restorHP, hero.CurrentHealth);
                    }
                }
                else
                {
                    hero.CurrentHealth = hero.MaxHealth;
                    if (choice == "rested")
                    {
                        Console.WriteLine("You have rested for a few hours and have fully recovered your HP.");
                    }
                    else
                    {

                        Console.WriteLine("You have eaten a delicious Meal and have fully restored your HP.");
                    }
                }
                if (newMP <= heroMaxMP)
                {
                    hero.CurrentMagic += restorMP;
                    if (choice == "rested")
                    {
                        Console.WriteLine("You have rested for a few hours and restored {0} MP. You have now {1} MP\n", restorMP, hero.CurrentMagic);
                    }
                    else
                    {
                        Console.WriteLine("You have have eaten a delicious Meal and restored {0} MP. You have now {1} MP\n", restorMP, hero.CurrentMagic);
                    }
                }
                else
                {
                    hero.CurrentMagic = hero.MaxMagic;
                    if (choice == "rested")
                    {
                        Console.WriteLine("You have rested for a few hours and have fully recovered you MP.\n");
                    }
                    else
                    {
                        Console.WriteLine("You have eaten a delicious Meal and have fully restored your MP.");
                    }
                }
            }
            else
            {
                Console.WriteLine("You have not enough Gold to do that.\n");
            }
        }
        #endregion
    }
}
