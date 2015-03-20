using System;
using System.IO;
using System.Collections.Generic;

namespace TeridiumRPG.Shops
{
    public class ShopCategory
    {
        public ShopCategory[] Subcategories { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string[] Collumns { get; set; }

        public ShopCategory(string name, string[] collumns, ShopCategory[] subcategories)
        {
            this.Name = name;
            this.Collumns = collumns;
            this.Subcategories = subcategories;
        }

        public ShopCategory(string name, string[] collumns)
        {
            this.Name = name;
            this.Collumns = collumns;
        }

        public ShopCategory()
        {

        }

        public void LoadCategory(string shopname)
        {
            if (this.Subcategories != null)
            {
                foreach (ShopCategory category in this.Subcategories)
                {
                    category.LoadCategory(shopname);
                }
            }
            try
            {
                this.Picture = File.OpenText(Game.GameData + "/Shops/" + shopname + "/" + this.Name.ToLower() + ".txt").ReadToEnd();
            }
            catch (Exception ex)
            {
                this.Picture = "";
            }
        }

        public string RenderMenu(string header, string footer)
        {
            if (Subcategories != null)
            {
                List<string> menuoptions = new List<string>();
                foreach (ShopCategory cat in this.Subcategories)
                {
                    menuoptions.Add(cat.Name);
                }
                menuoptions.Add("Exit");
                int choice = GameOutput.PrintMenu(menuoptions.ToArray(), header, footer, Picture);
                if (choice == menuoptions.Count)
                {
                    return "Exit";
                }
                else
                {
                    return this.Subcategories[choice].RenderMenu(header, footer);
                }
            }
            else
            {
                return this.Name;
            }
        }

        public ShopCategory GetCategoryByName(string name)
        {
            if (Subcategories != null)
            {
                foreach (ShopCategory cat in this.Subcategories)
                {
                    if (cat.Name == name)
                        return cat;
                    return cat.GetCategoryByName(name);
                }
            }
            return null;
        }
    }
}

