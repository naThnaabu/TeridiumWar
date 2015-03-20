using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    public class Hero : Character
    {
        #region Variables

        public Item weapon { get; set; }

        public Item helmet { get; set; }

        public Item chest { get; set; }

        public Item arm { get; set; }

        public Item leg { get; set; }

        public Item shoe { get; set; }

        public int AnzW6 { get; set; }

        public int Level { get; set; }

        public int MaxInventory { get; set; }

        public List<Item> Inventory { get; set; }

        string[] weaponfields = null;

        #endregion

        public Hero ()
        {
            Inventory = new List<Item> ();
            weaponfields = new string[] {
                "Name",
                "AttackValue",
                "DamageValue",
                "Weight",
                "AnzW6"
            };
        }

        #region functions

        public void Initialize ()
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
            weapon = new Item ("Sword", ItemTypes.Weapon, 4);
            arm = new Item ();
            chest = new Item ("Shirt", ItemTypes.Cosmetic, 4);
            leg = new Item ("Woolen trousers", ItemTypes.Cosmetic, 4);
            helmet = new Item ();
            shoe = new Item ("Cheap Leather shoes", ItemTypes.Cosmetic, 3);
            AnzBigHPPotions = 0;
            AnzLittleHPPotions = 1;
            AnzMiddleHPPotions = 0;
            AnzBigMPPotions = 0;
            AnzLittleMPPotions = 0;
            AnzMiddleMPPotions = 0;
            Level = 1;
            MaxInventory = 15;
        }

        public int ArmorValue ()
        {
            return arm.ArmorValue + chest.ArmorValue + leg.ArmorValue + helmet.ArmorValue + shoe.ArmorValue;
        }

        public int CurrentInventory ()
        {
            int retval = 0;
            foreach (Item item in this.Inventory) {
                retval += item.Weight;
            }
            return retval;
        }

        public void LevelUpdate ()
        {
            if (Experience >= 200 && Experience <= 400) {
                if (Level < 2) {
                    Level = 2;
                    Attack++;
                    Defense++;
                    CurrentHealth += 2;
                    MaxHealth += 2;
                    CurrentMagic += 2;
                    MaxMagic += 2;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 2.", Level);
                }
            }
            if (Experience >= 401 && Experience <= 700) {
                if (Level < 3) {
                    Level = 3;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 701 && Experience <= 1000) {
                if (Level < 4) {
                    Level = 4;
                    Attack++;
                    Defense++;
                    CurrentHealth += 4;
                    MaxHealth += 4;
                    CurrentMagic += 4;
                    MaxMagic += 4;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 4.", Level);
                }
            }
            if (Experience >= 1001 && Experience <= 1400) {
                if (Level < 5) {
                    Level = 5;
                    Attack++;
                    Defense++;
                    CurrentHealth += 5;
                    MaxHealth += 5;
                    CurrentMagic += 5;
                    MaxMagic += 5;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 5.", Level);
                }
            }
            if (Experience >= 1401 && Experience <= 1900) {
                if (Level < 6) {
                    Level = 6;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 1901 && Experience <= 2500) {
                if (Level < 7) {
                    Level = 7;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 2501 && Experience <= 3500) {
                if (Level < 8) {
                    Level = 8;
                    Attack++;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine ("You are now Level {0} your Attack and Defense value is increased by 1 and your Healt and Mana each by 3.", Level);
                }
            }
            if (Experience >= 3501 && Experience <= 5000) {
                if (Level < 9) {
                    Level = 9;
                    Defense++;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine ("You are now Level {0} your defense is increased by 1 and your Helat and Mana each by 3.", Level);
                }
            }
            if (Experience >= 5001 && Experience <= 8000) {
                if (Level < 10) {
                    Level = 10;
                    CurrentHealth += 3;
                    MaxHealth += 3;
                    CurrentMagic += 3;
                    MaxMagic += 3;
                    Console.WriteLine ("You are now Level {0}. And your Health and Mana increased each by 3.", Level);
                }
            }
        }

        public void EquipItem (Item item, string slot)
        {
            Type thisType = this.GetType ();
            System.Reflection.PropertyInfo property = thisType.GetProperty (slot);
            this.UnEquip (slot);
            property.SetValue (this, item, null);
            this.Inventory.Remove (item);
        }

        public void UnEquip (string slot)
        {
            Type thisType = this.GetType ();
            System.Reflection.PropertyInfo property = thisType.GetProperty (slot);
            Item equipedItem = (Item)property.GetValue (this, null);
            if (equipedItem.ItemType != ItemTypes.Nothing)
                this.Inventory.Add (equipedItem);
            property.SetValue (this, new Item (), null);
        }

        public void PrintCharacterSheet ()
        {
            PrintCharacterStatus ();
            PrintInventory ();
        }

        public void PrintCharacterStatus ()
        {
            Console.Write (@"
**************************************
Name:   {0}Armor:   {6}
HP:     {1}/{2}Attack:  {7}
MP:     {3}/{4}Defense:  {8}
Level:  {5}Gold:    {9}
**************************************", 
                Identifier.PadRight (15, ' '), 
                CurrentHealth.ToString ().PadRight (3, ' '), 
                MaxHealth.ToString ().PadRight (11, ' '), 
                CurrentMagic.ToString ().PadRight (3, ' '), 
                MaxMagic.ToString ().PadRight (11, ' '), 
                Level.ToString ().PadRight (15, ' '), 
                ArmorValue (), 
                Attack, 
                Defense, 
                Gold
            );
            Console.WriteLine ();
        }

        public void PrintInventory ()
        {
            PrintWeapons ();
            Console.WriteLine ();
        }

        public void PrintWeapons ()
        {
            List<string> weapons = new List<string> ();
            foreach (Item item in this.Inventory.FindAll((Item delegitem) => delegitem.ItemType == ItemTypes.Weapon)) {
                weapons.Add (item.ToItemString (weaponfields));
            }
            GameOutput.printTable (weapons.ToArray (), weaponfields, false);
            Console.WriteLine ();
        }

        #endregion
    }
}
