using System;
using System.IO;
using System.Collections.Generic;

namespace TeridiumRPG.Shop
{
	public class ShopCategory
	{
		public ShopCategories[] subcategories {get; set;}
		public string name {get; set;}
		public string picture {get; set;}
		public string[] collumns {get; set;}

		public void LoadCategory(string shopname)
		{
			foreach(ShopCategory category in this.subcategories)
			{
				category.LoadCategory(shopname);
			}
			try{
				this.picture = File.OpenText(Game.GameData+"/Shops/"+shopname+"/"+this.name.ToLower()+".txt").ReadToEnd();
			} catch(Exception ex) {
				this.picture="";
			}
		}

		public string RenderMenu(string header, string footer)
		{
			if(subcategories.Length>0){
				List<string> menuoptions = new List<string>();
				foreach(ShopCategory cat in this.subcategories)
				{
					menuoptions.Add(cat.name);
				}
				menuoptions.Add("Exit");
				int choice = GameOutput.printMenu(menuoptions.ToArray(), header, footer, picture);
				if(choice == menuoptions.Count) {
					return "Exit";
				} else {
					return this.subcategories[choice].RenderMenu(header,footer);
				}
			} else {
				return this.name;
			}
		}

		public ShopCategory GetCategoryByName(string name)
		{
			foreach(ShopCategory cat in this.subcategories)
			{
				if(cat.name == name)
					return cat;
				return cat.GetCategoryByName(name);
			}
			return null;
		}
	}
}

