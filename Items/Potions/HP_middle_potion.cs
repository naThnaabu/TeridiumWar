using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class HP_middle_potion : Item
    {
        public HP_middle_potion ()
        {
            Name = "Middle HP Potion";
            Price = 15;
        }

        public bool drink (Hero hero)
        {
            bool PotionDrunk = true;
            if (hero.AnzMiddleHPPotions >= 1) {
                int heroHealthWithPoiton = 8;
                heroHealthWithPoiton += hero.CurrentHealth;
                if (heroHealthWithPoiton <= hero.MaxHealth) {
                    hero.CurrentHealth += 8;
                    Console.WriteLine ("You drank " + " and recover 8 HP.\nYou have " + hero.CurrentHealth + " HP now.\n");
                } else {
                    hero.CurrentHealth = hero.MaxHealth;
                    Console.WriteLine ("You drank " + " and recovered to your full strength.");
                }
            } else {
                Console.WriteLine ("You have no Middle HP Potions left.\nPress any key to continue...");
                Console.ReadKey ();
                PotionDrunk = false;
            }
            return PotionDrunk;
        }
    }
}
