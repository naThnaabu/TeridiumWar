using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using YamlDotNet.Serialization;

namespace TeridiumRPG
{
    class HeroDataHandler
    {
		string[] dirs = {"PlayerData"};

		private void CheckCreateDirectories()
		{
			foreach(string dir in dirs)
			{
				if (Directory.Exists(dir) == false)
				{
					Directory.CreateDirectory(dir);
				}
			}
		}

		public void Save(Hero hero, bool quiet)
        {
			CheckCreateDirectories();
			Serializer ser = new Serializer(SerializationOptions.Roundtrip);
			StreamWriter herofile = new StreamWriter(@"PlayerData/"+hero.Identifier+".yml");
			ser.Serialize(herofile, hero);
			herofile.Close();

            if (!quiet)
            {
                Console.WriteLine("Game Save successful");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

		public bool hasHero()
		{
			int files = Directory.EnumerateFiles("PlayerData").Count();
			if (files <= 1)
				return false;
			else
				return true;
		}

		public Hero makeHero()
		{
			Hero hero = new Hero();
			Console.WriteLine("Whats you name?");
			hero.Identifier = Console.ReadLine();
			hero.Initialize();
			Save(hero, true);
			return hero;
		}

		public Hero selectHero()
		{
			string[] files = Directory.GetFiles("PlayerData");
			Console.Write("Which character would you like to play?\n**************************************\n");
			for (int x = 1; x < files.Length; x++)
			{
				string heroname = files[x].Substring(11);
				heroname = heroname.Substring(0, heroname.IndexOf("."));
				Console.WriteLine("(" + x + ") " + heroname);
			}
			Console.WriteLine("(N)ew Character?");
			Console.WriteLine("**************************************");
			ConsoleKeyInfo CharKey;
			CharKey = Console.ReadKey(true);
			string sCharKey;
			sCharKey = CharKey.KeyChar.ToString();
			if (sCharKey != "N" & sCharKey != "n")
			{
				int iCharKey = Convert.ToInt32(sCharKey);
				string heropath = "";

				heropath = files[iCharKey];
				Deserializer deser = new Deserializer();
				return (Hero) deser.Deserialize(File.OpenText(heropath), typeof(Hero));
			} 
			else 
			{
				return makeHero();
			}
		}

        public Hero Load()
        {
			CheckCreateDirectories();
			if (hasHero())
            {
				return selectHero();
            }
            else
            {
				return makeHero();
            }
                   
        } 
    }
}

