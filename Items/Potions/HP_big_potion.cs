﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class HP_big_potion : Item
    {
        public HP_big_potion()
        {
            Identifier = "Big HP Potion";
            Price = 19;
        }

        public bool drink(Hero hero)
        {
            bool PotionDrunk = true;
            if (hero.AnzMiddleHPPotions >= 1)
            {
                int heroHealthWithPoiton = 12;
                heroHealthWithPoiton += hero.CurrentHealth;
                if (heroHealthWithPoiton <= hero.MaxHealth)
                {
                    hero.CurrentHealth += 12;
                    Console.WriteLine("You drank " + " and recover 12 HP.\nYou have " + hero.CurrentHealth + " HP now.\n");
                }
                else
                {
                    hero.CurrentHealth = hero.MaxHealth;
                    Console.WriteLine("You drank " + " and recovered to your full strength.");
                }
            }
            else
            {
                PotionDrunk = false;
                Console.WriteLine("You have no Middle HP Potions left.\nPress any key to continue...");
                Console.ReadKey();
            }
            return PotionDrunk;
        }
    }
}