using System;
using TeridiumRPG.Characters;

namespace TeridiumRPG.Buildings
{
    public class Tavern : Building
    {
        public const string BuildingType = "Taverns";

        public const ConsoleColor Color = ConsoleColor.Magenta;

        public int RestRestoreHP { get; set; }

        public int RestRestoreMP { get; set; }

        public int RestCost{ get; set; }

        public int FeastRestoreHP{ get; set; }

        public int FeastRestoreMP{ get; set; }

        public int FeastCost{ get; set; }

        public Tavern()
        {

        }

        public override void Load()
        {
            base.Load();
            Menuoptions.AddRange(new string[]{ "Rest", "Feast", "Exit" });
        }

        public override string Render()
        {
            Console.ForegroundColor = Color;
            string prepictext = String.Format("Welcome to the {0} {1}", Name, Hero.Identifier);
            string postoptiontext = String.Format("Your HP: {1}/{2}\nYour MP: {3}/{4}\nYour Gold: {0}", Hero.Gold, Hero.CurrentHealth, Hero.MaxHealth, Hero.CurrentMagic, Hero.MaxMagic);
            int choice = GameOutput.PrintMenu(Menuoptions.ToArray(), Header, Footer, Picture, true, posttext, "", prepictext, postoptiontext);
            return choice == 255 ? "Invalid" : Menuoptions.ToArray()[choice];
        }

        public Hero Rest(Hero hero)
        {

            return Restore(hero, RestRestoreHP, RestRestoreMP, RestCost, "Rest");
        }

        public Hero Feast(Hero hero)
        {
            return Restore(hero, FeastRestoreHP, FeastRestoreMP, FeastCost, "Feast");
        }

        private Hero Restore(Hero hero, int restoreHP, int restoreMP, int cost, string action)
        {
            if (hero.Gold >= cost)
            {
                bool ismaxMP = hero.CurrentMagic >= hero.MaxMagic;
                bool ismaxHP = hero.CurrentHealth >= hero.MaxHealth;

                hero.Gold -= cost;
                int realrestoreHP = hero.MaxHealth / restoreHP;
                int realrestoreMP = hero.MaxMagic / restoreMP;
                bool wouldoverRestoreHP = hero.CurrentHealth + restoreHP >= hero.MaxHealth;
                bool wouldoverRestoreMP = hero.CurrentMagic + restoreMP >= hero.MaxMagic;
                posttext = String.Format("You {0} in the {1}. You feel good about that.\n", action, Name);
                if (!ismaxHP)
                {
                    if (wouldoverRestoreHP)
                    {
                        hero.CurrentHealth = hero.MaxHealth;
                        posttext += "You are now back to full health\n";
                    }
                    else
                    {
                        hero.CurrentHealth += realrestoreHP;
                        posttext += String.Format("You regain {0} HP\n", realrestoreHP);
                    }
                }
                if (!ismaxMP)
                {
                    if (wouldoverRestoreMP)
                    {
                        hero.CurrentMagic = hero.MaxMagic;
                        posttext += "Your Magic Points are now fully restored\n";
                    }
                    else
                    {
                        hero.CurrentMagic += realrestoreMP;
                        posttext += String.Format("You regain {0} MP\n", realrestoreMP);
                    }
                }
            }
            else
            {
                posttext = String.Format("You have not enough Gold to do that.\n");
            }
            return hero;
        }
    }
}
