using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class MP_little_potion : Item
    {
        public MP_little_potion()
        {
            Identifier = "Little MP Potion";
            Price = 8;
        }

        public bool drink(Hero hero)
        {
            bool PotionDrunk = true;
            int heroMPWithPoiton = 5;
            heroMPWithPoiton += hero.CurrentMagic;
            if (hero.AnzLittleMPPotions >= 1)
            {
                if (heroMPWithPoiton <= hero.MaxMagic)
                {
                    hero.CurrentMagic += 5;
                    Console.WriteLine("You drank " + Identifier + " and recover 5 MP.\nYou have " + hero.CurrentMagic + " MP now.\n");
                }
                else
                {
                    hero.CurrentMagic = hero.MaxMagic;
                    Console.WriteLine("You drank " + Identifier + " and recovered to your full strength.");
                }
            }
            else
            {
                Console.WriteLine("You have no Little MP Potions left.\nPress any key to continue...");
                Console.ReadKey();
                PotionDrunk = false;
            }
            return PotionDrunk;
        }
    }
}
