using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Hero : Character
    {
        #region Variables
        public string weapon;
        public string helmetname;
        public string chestname;
        public string armname;
        public string legname;
        public string shouename;

        public int helmet;
        public int chest;
        public int arm;
        public int leg;
        public int shoue;
        public int ArmorValue;
        public int AnzW6;
        public int Level;
        public int CurrentInv;
        public int MaxInv;

        public List<string> Inventar = new List<string>();
        public List<string> WeaponInventar = new List<string>();
        public List<string> ArmorInventar = new List<string>();
        #endregion

        public Hero()
        {

        }

        #region functions
        public void Initialize(Hero hero)
        {
            hero.CurrentHealth = 18;
            hero.MaxHealth = 18;
            hero.CurrentMagic = 30;
            hero.MaxMagic = 30;
            hero.Attack = 9;
            hero.Defense = 8;
            hero.Experience = 0;
            hero.Gold = 25;
            hero.isAlive = true;
            hero.AttackDamage = 1;
            hero.AnzW6 = 1;
            hero.weapon = "Sword";
            hero.arm = 0;
            hero.armname = "Nothing";
            hero.chest = 0;
            hero.chestname = "Shirt";
            hero.leg = 0;
            hero.legname = "Woolen trouser";
            hero.helmet = 0;
            hero.helmetname = "Nothing";
            hero.shouename = "Cheap leather shoes";
            hero.shoue = 0;
            hero.AnzBigHPPotions = 0;
            hero.AnzLittleHPPotions = 1;
            hero.AnzMiddleHPPotions = 0;
            hero.AnzBigMPPotions = 0;
            hero.AnzLittleMPPotions = 0;
            hero.AnzMiddleMPPotions = 0;
            hero.Level = 1;
            hero.CurrentInv = 15;
            hero.MaxInv = 15;
        }

        public int CalculateArmorValue()
        {
            ArmorValue = arm + chest + leg + helmet + shoue;
            return ArmorValue;
        }

        public void LevelUpdate()
        {
            if (Experience >= 200 && Experience <= 400)
            {
                if (Level < 2)
                {
                    Level = 2;
                    Attack++;
                    Defense++;
                    CurrentHealth += 2;
                    MaxHealth += 2;
                    CurrentMagic += 2;
                    MaxMagic += 2;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 2.", Level);
                }
            }
            if (Experience >= 401 && Experience <= 700)
            {
                if (Level < 3)
                {
                    Level = 3;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 701 && Experience <= 1000)
            {
                if (Level < 4)
                {
                    Level = 4;
                    Attack++;
                    Defense++;
                    CurrentHealth += 4;
                    MaxHealth += 4;
                    CurrentMagic += 4;
                    MaxMagic += 4;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 4.", Level);
                }
            }
            if (Experience >= 1001 && Experience <= 1400)
            {
                if (Level < 5)
                {
                    Level = 5;
                    Attack++;
                    Defense++;
                    CurrentHealth += 5;
                    MaxHealth += 5;
                    CurrentMagic += 5;
                    MaxMagic += 5;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 5.", Level);
                }
            }
            if (Experience >= 1401 && Experience <= 1900)
            {
                if (Level < 6)
                {
                    Level = 6;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 1901 && Experience <= 2500)
            {
                if (Level < 7)
                {
                    Level = 7;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 2501 && Experience <= 3500)
            {
                if (Level < 8)
                {
                    Level = 8;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 3501 && Experience <= 5000)
            {
                if (Level < 9)
                {
                    Level = 9;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine("You are now Level {0} your defense is increased by 1 and your Helat and Mana each by 3.", Level);
                }
            }
            if (Experience >= 5001 && Experience <= 8000)
            {
                if (Level < 10)
                {
                    Level = 10;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine("You are now Level {0}. And your Health and Mana increased each by 3.", Level);
                }
            }
        }

        public void PrintHeroStatus()
        {
            Console.Clear();
            CalculateArmorValue();
            Console.Write(@"
**************************************
Name:   {0}Armor:   {6}
HP:     {1}/{2}Attack:  {7}
MP:     {3}/{4}Defense:  {8}
Level:  {5}Gold:    {9}
**************************************

Press any Key to continue...", Identifier.PadRight(15, ' '), CurrentHealth.ToString().PadRight(3, ' '), MaxHealth.ToString().PadRight(11, ' '), CurrentMagic.ToString().PadRight(3, ' '), MaxMagic.ToString().PadRight(11, ' '), Level.ToString().PadRight(15, ' '), ArmorValue, Attack, Defense, Gold);
        }
        #endregion
    }
}
