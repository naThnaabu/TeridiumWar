using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    public class Hero : Character
    {
        #region Variables
		public string weapon { get; set; }
		public string helmetname { get; set; }
		public string chestname { get; set; }
		public string armname { get; set; }
		public string legname { get; set; }
		public string shouename { get; set; }

		public int helmet { get; set; }
		public int chest { get; set; }
		public int arm { get; set; }
		public int leg { get; set; }
		public int shoue { get; set; }
		public int ArmorValue { get; set; }
		public int AnzW6 { get; set; }
		public int Level { get; set; }
		public int CurrentInv { get; set; }
		public int MaxInv { get; set; }

		public List<string> Inventar { get; set; }
		public List<string> WeaponInventar { get; set; }
		public List<string> ArmorInventar { get; set; }
        #endregion

        public Hero()
        {
			Inventar = new List<string>();
			WeaponInventar = new List<string>();
			ArmorInventar = new List<string>();
        }

        #region functions
        public void Initialize()
        {
            CurrentHealth = 18;
            MaxHealth = 18;
            CurrentMagic = 30;
            MaxMagic = 30;
            Attack = 9;
            Defense = 8;
            Experience = 0;
            Gold = 25;
            isAlive = true;
            AttackDamage = 1;
            AnzW6 = 1;
            weapon = "Sword";
            arm = 0;
            armname = "Nothing";
            chest = 0;
            chestname = "Shirt";
            leg = 0;
            legname = "Woolen trouser";
            helmet = 0;
            helmetname = "Nothing";
            shouename = "Cheap leather shoes";
            shoue = 0;
            AnzBigHPPotions = 0;
            AnzLittleHPPotions = 1;
            AnzMiddleHPPotions = 0;
            AnzBigMPPotions = 0;
            AnzLittleMPPotions = 0;
            AnzMiddleMPPotions = 0;
            Level = 1;
            CurrentInv = 15;
            MaxInv = 15;
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
