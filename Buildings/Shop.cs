using System;
using System.Collections.Generic;
using System.IO;
using TeridiumRPG.Shops;
using TeridiumRPG.Items;
using TeridiumRPG.Characters;

namespace TeridiumRPG.Buildings
{
    public class Shop : Building
    {
        public ShopCategory[] Categories { get; set; }

        public string[] Sells { get; set; }

        public List<Item> Items { get; set; }

        public const string BuildingType = "Shops";

        public const ConsoleColor Color = ConsoleColor.Green;

        public override void Load()
        {
            base.Load();
            foreach (ShopCategory category in this.Categories)
            {
                category.LoadCategory(this.Name);
            }
            Items = new List<Item>();
            foreach (string item in this.Sells)
            {
                if (item == "all")
                {
                    Items.AddRange(Game.LoadAllItems());
                }
                else
                {
                    Items.Add(Game.LoadItem(item));
                }
            }
            Menuoptions = new List<string>();
            foreach (ShopCategory cat in this.Categories)
            {
                Menuoptions.Add(cat.Name);
            }
            Menuoptions.Add("Sell");
            Menuoptions.Add("Exit");
        }

        public override string Render()
        {
            foreach (ShopCategory cat in this.Categories)
            {
                Menuoptions.Add(cat.Name);
            }
            Menuoptions.Add("Sell");
            Menuoptions.Add("Exit");
            int choice = GameOutput.PrintMenu(Menuoptions.ToArray(), Header, Footer, Picture);
            if (choice == Menuoptions.IndexOf("Exit"))
            {
                return "Exit";
            }
            else if (choice == Menuoptions.IndexOf("Sell"))
            {
                return "Sell";
            }
            else
            {
                return this.Categories[choice].RenderMenu(Header, Footer);
            }
        }

        private ShopCategory GetCategoryByName(string catname)
        {
            foreach (ShopCategory cat in this.Categories)
            {
                if (cat.Name == catname)
                {
                    return cat;
                }
                var catcat = cat.GetCategoryByName(catname);
                if (catcat != null)
                {
                    if (catcat.Name == catname)
                    {
                        return catcat;
                    }
                }
            }
            return null;
        }

        public override Hero Visit(Hero hero)
        {
            this.Load();
            do
            {
                string choice = this.Render();
                if (choice == "Exit")
                {
                    hero = Exit(hero);
                }
                else if (choice == "Sell")
                {
                    hero = this.Sell(hero);
                }
                else
                {
                    hero = this.Buy(hero, this.GetCategoryByName(choice));
                }
            } while(!Leave);
            return hero;
        }

        private Hero Sell(Hero hero)
        {
            return hero;
        }

        private Hero Buy(Hero hero, ShopCategory category)
        {
            var items = this.Items.FindAll(
                            (Item item) => item.Category == category.Name
                        );
            List<string> rows = new List<string>();
            foreach (Item item in items)
            {
                rows.Add(item.ToItemString(category.Collumns));
            }
            string decideText = "Please choose a " + category.Name + " to buy:";
            string additionalInfo = "Your Gold: " + hero.Gold;
            Console.Clear();
            int selection = GameOutput.PrintTable(rows.ToArray(), category.Collumns, true, decideText, additionalInfo, category.Picture);
            if (selection == 255)
                return hero;
            Item selecteditem = Items.ToArray()[selection];
            if (hero.Gold >= selecteditem.Price)
            {
                hero.Inventory.Add(selecteditem);
                hero.Gold -= selecteditem.Price;
                GameOutput.PrintWait("Bought " + selecteditem.Name);
                return hero;
            }
            else
            {
                GameOutput.PrintWait("Not Enough Money to Buy " + selecteditem.Name);
                return hero;
            }
        }
    }
}

