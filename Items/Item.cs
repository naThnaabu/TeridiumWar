using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace TeridiumRPG.Items
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

		public Item(
			string name = "Nothing", 
			ItemTypes itemType = ItemTypes.Nothing,
			int weight = 0,
			string category = "",
			int price = 0, 
			int anzW6 = 0,
			int invStaple = 0, 
			int invCanHave = 0,
			int armorValue = 0,
			int damageValue = 0,
			int attackValue = 0,
			int defenseValue = 0
		)
		{
			this.ItemType = itemType;
			this.Name = name;
			this.Price = price;
			this.InvStaple = invStaple;
			this.InvCanHave = invCanHave;
			this.ArmorValue = armorValue;
			this.AttackValue = attackValue;
			this.DefenseValue = defenseValue;
			this.Weight = weight;
			this.Category = category;
			this.AnzW6 = anzW6;
			this.DamageValue = damageValue;
		}

		public Item()
		{
		}

		public string ToItemString(string[] fields)
		{
			string itemString = "";
			foreach (string col in fields)
			{
				Type itemType = this.GetType();
				System.Reflection.PropertyInfo itemproperty = itemType.GetProperty(col);
				itemString += itemproperty.GetValue(this, null);
				itemString += ";";
			}
			itemString = itemString.Substring(0, itemString.LastIndexOf(";"));
			return itemString;
		}
	}
}