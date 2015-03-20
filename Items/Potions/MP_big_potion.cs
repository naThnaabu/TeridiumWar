using System;
using TeridiumRPG.Items;
using TeridiumRPG.Characters;

namespace TeridiumRPG.Items.Potions
{
    class MP_big_potion : Item
    {
        public MP_big_potion()
        {
            Name = "Big MP Potion";
            Price = 19;
        }

        public bool Drink(Hero hero)
        {
            bool PotionDrunk = true;
            if (hero.AnzMiddleMPPotions >= 1)
            {
                int heroMPWithPoiton = 12;
                heroMPWithPoiton += hero.CurrentMagic;
                if (heroMPWithPoiton <= hero.MaxMagic)
                {
                    hero.CurrentMagic += 12;
                    Console.WriteLine("You drank " + Name + " and recover 12 MP.\nYou have " + hero.CurrentMagic + " MP now.\n");
                }
                else
                {
                    hero.CurrentMagic = hero.MaxMagic;
                    Console.WriteLine("You drank " + Name + " and recovered to your full strength.");
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
