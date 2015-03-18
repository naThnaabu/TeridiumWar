using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class MP_big_potion : Item
    {
        public MP_big_potion()
        {
            Identifier = "Big MP Potion";
            Price = 19;
        }

        public bool drink(Hero hero)
        {
            bool PotionDrunk = true;
            if (hero.AnzMiddleMPPotions >= 1)
            {
                int heroMPWithPoiton = 12;
                heroMPWithPoiton += hero.CurrentMagic;
                if (heroMPWithPoiton <= hero.MaxMagic)
                {
                    hero.CurrentMagic += 12;
                    Console.WriteLine("You drank " + Identifier +" and recover 12 MP.\nYou have " + hero.CurrentMagic + " MP now.\n");
                }
                else
                {
                    hero.CurrentMagic = hero.MaxMagic;
                    Console.WriteLine("You drank " + Identifier + " and recovered to your full strength.");
                }
            }
            else
            {
                Console.WriteLine("You have no Middle MP Potions left.\nPress any key to continue...");
                Console.ReadKey();
                PotionDrunk = false;
            }
            return PotionDrunk;
        }
    }
}
