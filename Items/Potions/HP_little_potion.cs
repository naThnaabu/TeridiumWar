using System;
using TeridiumRPG.Items;
using TeridiumRPG.Characters;

namespace TeridiumRPG.Items.Potions
{
    class HP_little_potion : Item
    {
        public HP_little_potion()
        {
            Name = "Little HP Potion";
            Price = 8;
            InvStaple = 10;
        }

        public bool Drink(Hero hero)
        {
            bool PotionDrunk = true;
            int heroHealthWithPoiton = 5;
            heroHealthWithPoiton += hero.CurrentHealth;
            if (hero.AnzLittleHPPotions >= 1)
            {
                if (heroHealthWithPoiton <= hero.MaxHealth)
                {
                    hero.CurrentHealth += 5;
                    Console.WriteLine("You drank " + Name + " and recover 5 HP.\nYou have " + hero.CurrentHealth + " HP now.\nPress any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    hero.CurrentHealth = hero.MaxHealth;
                    Console.WriteLine("You drank " + Name + " and recovered to your full strength.\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("You have no Little HP Potions left.\nPress any key to continue...");
                Console.ReadKey();
                PotionDrunk = false;
            }
            return PotionDrunk;
        }
    }
}
