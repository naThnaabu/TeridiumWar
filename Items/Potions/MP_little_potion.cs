using System;
using TeridiumRPG.Items;
using TeridiumRPG.Characters;

namespace TeridiumRPG.Items.Potions
{
    class MP_little_potion : Item
    {
        public MP_little_potion()
        {
            Name = "Little MP Potion";
            Price = 8;
        }

        public bool Drink(Hero hero)
        {
            bool PotionDrunk = true;
            int heroMPWithPoiton = 5;
            heroMPWithPoiton += hero.CurrentMagic;
            if (hero.AnzLittleMPPotions >= 1)
            {
                if (heroMPWithPoiton <= hero.MaxMagic)
                {
                    hero.CurrentMagic += 5;
                    Console.WriteLine("You drank " + Name + " and recover 5 MP.\nYou have " + hero.CurrentMagic + " MP now.\n");
                }
                else
                {
                    hero.CurrentMagic = hero.MaxMagic;
                    Console.WriteLine("You drank " + Name + " and recovered to your full strength.");
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
