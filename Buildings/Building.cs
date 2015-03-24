//
//  Building.cs
//
//  Author:
//       Till Wegmüller <toasterson@gmail.com>
//
//  Copyright (c) 2015 Till Wegmüller
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
using System;
using TeridiumRPG.Characters;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace TeridiumRPG.Buildings
{
    public class Building
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public Hero Hero { get; set; }

        public bool Leave { get; set; }

        public List<string> Menuoptions { get; set; }

        public const string Header = "***********************";
        public const string Footer = "***********************";

        public const ConsoleColor Color = ConsoleColor.White;

        public const string BuildingType = "Buildings";

        public string posttext;

        public Building()
        {

        }

        public virtual void Load()
        {
            Leave = false;
            Menuoptions = new List<string>();
            posttext = "";
            try
            {
                Picture = File.OpenText(Game.GameData + "/" + BuildingType + "/" + Name + "/banner.txt").ReadToEnd();
            }
            catch
            {
                Picture = "";
            }
        }

        public virtual string Render()
        {
            Console.ForegroundColor = Color;
            int choice = GameOutput.PrintMenu(Menuoptions.ToArray(), Header, Footer, Picture, true, posttext);
            return choice == 255 ? "Invalid" : Menuoptions.ToArray()[choice];
        }

        public virtual Hero Exit(Hero hero)
        {
            Leave = true;
            Game.SaveHero(hero);
            Console.ForegroundColor = ConsoleColor.White;
            return Hero;
        }

        public virtual Hero Visit(Hero hero)
        {
            Load();
            do
            {
                Hero = hero;
                string choice = Render();
                posttext = "";
                Type thisType = GetType();
                try
                {
                    MethodInfo method = thisType.GetMethod(choice);
                    hero = (Hero)method.Invoke(this, new object[]{ hero });
                }
                catch
                {
                    posttext = "I'm sorry that wasn't a valid choice.";
                }
            } while(!Leave);
            Game.SaveHero(hero);
            return hero;
        }
    }
}

