using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace TeridiumRPG
{
    public class Item
    {
        public ItemTypes ItemType { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public int InvStaple { get; set; }

        public int InvCanHave { get; set; }

        public int ArmorValue { get; set; }

        public int AttackValue { get; set; }

        public int DamageValue { get; set; }

        public int DefenseValue { get; set; }

        public int Weight { get; set; }

        public int AnzW6 { get; set; }

        public Item (
            string Name = "Nothing", 
            ItemTypes ItemType = ItemTypes.Nothing,
            int Weight = 0,
            string Category = "",
            int Price = 0, 
            int AnzW6 = 0,
            int InvStaple = 0, 
            int InvCanHave = 0,
            int ArmorValue = 0,
            int DamageValue = 0,
            int AttackValue = 0,
            int DefenseValue = 0
        )
        {
            this.ItemType = ItemType;
            this.Name = Name;
            this.Price = Price;
            this.InvStaple = InvStaple;
            this.InvCanHave = InvCanHave;
            this.ArmorValue = ArmorValue;
            this.AttackValue = AttackValue;
            this.DefenseValue = DefenseValue;
            this.Weight = Weight;
            this.Category = Category;
            this.AnzW6 = AnzW6;
            this.DamageValue = DamageValue;
        }

        public Item ()
        {
        }
    }
}