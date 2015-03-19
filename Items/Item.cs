using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    public class Item
    {
		public int ItemType { get; set; }
		public string Identifier { get; set; }
		public int Price { get; set; }
		public int InvStaple { get; set; }
		public int InvCanHave { get; set; }
		public int ArmorValue { get; set; }
		public int AttackValue { get; set; }
		public int DefenseValue { get; set; }
		public int Weight { get; set; }

		public Item(
			string Identifier = "Nothing", 
			int ItemType = ItemTypes.Nothing,
			int Weight = 0,
			int Price = 0, 
			int InvStaple = 0, 
			int InvCanHave = 0,
			int ArmorValue = 0,
			int AttackValue = 0,
			int DefenseValue = 0
		)
		{
			this.ItemType = ItemType;
			this.Identifier = Identifier;
			this.Price = Price;
			this.InvStaple = InvStaple;
			this.InvCanHave = InvCanHave;
			this.ArmorValue = ArmorValue;
			this.AttackValue = AttackValue;
			this.DefenseValue = DefenseValue;
			this.Weight = Weight;
		}
    }
}