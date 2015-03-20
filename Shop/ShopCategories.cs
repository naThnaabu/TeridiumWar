using System;
using System.IO;
using System.Collections.Generic;

namespace TeridiumRPG.Shop
{
    public class ShopCategory
    {
        public ShopCategory[] subcategories { get; set; }

        public string name { get; set; }

        public string picture { get; set; }

        public string[] collumns { get; set; }

        public ShopCategory (string name, string[] collumns, ShopCategory[] subcategories)
        {
            this.name = name;
            this.collumns = collumns;
            this.subcategories = subcategories;
        }

        public ShopCategory (string name, string[] collumns)
        {
            this.name = name;
            this.collumns = collumns;
        }

        public ShopCategory ()
        {

        }

        public void LoadCategory (string shopname)
        {
            if (this.subcategories != null) {
                foreach (ShopCategory category in this.subcategories) {
                    category.LoadCategory (shopname);
                }
            }
            try {
                this.picture = File.OpenText (Game.GameData + "/Shops/" + shopname + "/" + this.name.ToLower () + ".txt").ReadToEnd ();
            } catch (Exception ex) {
                this.picture = "";
            }
        }

        public string RenderMenu (string header, string footer)
        {
            if (subcategories != null) {
                List<string> menuoptions = new List<string> ();
                foreach (ShopCategory cat in this.subcategories) {
                    menuoptions.Add (cat.name);
                }
                menuoptions.Add ("Exit");
                int choice = GameOutput.printMenu (menuoptions.ToArray (), header, footer, picture);
                if (choice == menuoptions.Count) {
                    return "Exit";
                } else {
                    return this.subcategories [choice].RenderMenu (header, footer);
                }
            } else {
                return this.name;
            }
        }

        public ShopCategory GetCategoryByName (string name)
        {
            if (subcategories != null) {
                foreach (ShopCategory cat in this.subcategories) {
                    if (cat.name == name)
                        return cat;
                    return cat.GetCategoryByName (name);
                }
            }
            return null;
        }
    }
}

