using System;
using System.Collections.Generic;

namespace TeridiumRPG.Shop
{
	public class Shop
	{
		const string header = "***********************";
		const string footer = "***********************";
		public string name {get; set;}
		public string description {get; set;}
		public string picture {get; set;}
		public ShopCategory[] categories {get; set;}
		public string[] sells {get; set;}
		public List<Item> Items {get; set;}

		private void LoadShop()
		{
			foreach(ShopCategory category in this.categories)
			{
				category.LoadCategory(this.name);
			}
			Items = new List<Item>();
			foreach(string item in this.sells)
			{
				if(item == "all") {
					Items.AddRange(Game.LoadAllItems());
				} else {
					Items.Add(Game.LoadItem(item));
				}
			}
			try{
				this.picture = File.OpenText(Game.GameData+"/Shops/"+shopname+"/banner.txt").ReadToEnd();
			} catch(Exception ex) {
				this.picture="";
			}
		}

		private string RenderCategories()
		{
			List<string> menuoptions = new List<string>();
			foreach(ShopCategory cat in this.categories)
			{
				menuoptions.Add(cat.name);
			}
			menuoptions.Add("Sell");
			menuoptions.Add("Exit");
			int choice = GameOutput.printMenu(menuoptions.ToArray(), header, footer, picture);
			if(choice == menuoptions.Count) {
				return "Exit";
			} else if(choice == menuoptions.IndexOf("Sell")) {
				return "Sell";
			} else {
				return this.categories[choice].RenderMenu(header,footer);
			}
		}

		private ShopCategory GetCategoryByName(string name)
		{
			foreach(ShopCategory cat in this.categories)
			{
				if(cat.name == name)
					return cat;
				return cat.GetCategoryByName(name);
			}
			return null;
		}
			
		public Hero Visit(Hero hero)
		{
			this.LoadShop();
			bool leave = false;
			do
			{
				string categoryName = this.RenderCategories();
				if (categoryName == "Exit"){
					leave = true;
				} else if (categoryName == "Sell"){
					hero = this.Sell(hero);
				} else {
					hero = this.Buy(hero, this.GetCategoryByName(categoryName));
				}
			} 
			while(!leave);
			Game.SaveHero(hero);
			return hero;
		}

		private Hero Sell(Hero hero)
		{
			return hero;
		}

		private Hero Buy(Hero hero, ShopCategory category)
		{
			var items = this.Items.FindAll(
				delegate(Item item)
				{
					return item.Category == category.name;
				}
			);
			List<string> rows = new List<string>();
			foreach(Item item in items)
			{
				string row = "";
				foreach(string col in category.collumns)
				{
					Type itemType = item.GetType();
					System.Reflection.PropertyInfo itemproperty = itemType.GetProperty (col);
					row+itemproperty.GetValue();
					row+";";
				}
				row = row.Substring(0, row.LastIndexOf(";"));
				rows.Add(row);
			}
			string decideText = "Please choose a "+category.name+" to buy:";
			string additionalInfo = "Your Gold: "+hero.Gold;
			int selection = GameOutput.printTable(rows.ToArray(), category.collumns, decideText, additionalInfo, category.picture);
			if(selection==255)
				return hero;
			Item selecteditem = Items.ToArray()[selection];
			if(hero.Gold >= selecteditem.Price){
				hero.Inventory.Add(selecteditem);
				GameOutput.printWait("Bought "+selecteditem.Name);
				return hero;
			} else {
				GameOutput.printWait("Not Enough Money to Buy " + selecteditem.Name);
				return hero;
			}
		}
	}
}

