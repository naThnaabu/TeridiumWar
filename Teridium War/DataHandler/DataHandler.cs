using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TeridiumRPG
{
    class DataHandler
    {
        public DataHandler()
        {

        }

        public void Save(Hero hero, string quiet)
        {
            #region Directory check/creation
            if (Directory.Exists(@"C:\Program Files\Teridium RPG\Teridium War\PlayerData") == false)
            {
                Directory.CreateDirectory(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerData");
            }
            if (Directory.Exists(@"C:\Program Files\Teridium RPG\Teridium War\PlayerInventory") == false)
            {
                Directory.CreateDirectory(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory");
            }
            #endregion

            #region PlayerData.txt
            using (StreamWriter herofile = new StreamWriter(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerData\" + hero.Identifier + "Data.txt"))
            {
                herofile.WriteLine(hero.CurrentHealth);
                herofile.WriteLine(hero.MaxHealth);
                herofile.WriteLine(hero.CurrentMagic);
                herofile.WriteLine(hero.MaxMagic);
                herofile.WriteLine(hero.Attack);
                herofile.WriteLine(hero.Defense);
                herofile.WriteLine(hero.Experience);
                herofile.WriteLine(hero.Gold);
                herofile.WriteLine(hero.AttackDamage);
                herofile.WriteLine(hero.Identifier);
                herofile.WriteLine(hero.weapon);
                herofile.WriteLine(hero.helmet);
                herofile.WriteLine(hero.helmetname);
                herofile.WriteLine(hero.chest);
                herofile.WriteLine(hero.chestname);
                herofile.WriteLine(hero.arm);
                herofile.WriteLine(hero.armname);
                herofile.WriteLine(hero.leg);
                herofile.WriteLine(hero.legname);
                herofile.WriteLine(hero.shoue);
                herofile.WriteLine(hero.shouename);
                herofile.WriteLine(hero.ArmorValue);
                herofile.WriteLine(hero.AnzW6);
                herofile.WriteLine(hero.AnzLittleHPPotions);
                herofile.WriteLine(hero.AnzMiddleHPPotions);
                herofile.WriteLine(hero.AnzBigHPPotions);
                herofile.WriteLine(hero.AnzLittleMPPotions);
                herofile.WriteLine(hero.AnzMiddleMPPotions);
                herofile.WriteLine(hero.AnzBigMPPotions);
                herofile.WriteLine(hero.Level);
            }

            #endregion

            #region close file stream
            using (FileStream fs = new FileStream(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerData\" + hero.Identifier + "Data.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {

            }
            //The file stream will close here
            #endregion

            #region PlayerInventory.txt
            File.Delete(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + hero.Identifier + "ItemInventory.txt");
            File.WriteAllLines(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + hero.Identifier + "ItemInventory.txt", hero.Inventar);

            File.Delete(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + hero.Identifier + "WeaponInventory.txt");
            File.WriteAllLines(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + hero.Identifier + "WeaponInventory.txt", hero.WeaponInventar);

            File.Delete(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + hero.Identifier + "ArmorInventory.txt");
            File.WriteAllLines(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + hero.Identifier + "ArmorInventory.txt", hero.ArmorInventar);

            #endregion

            #region quiet save
            if (quiet == "n")
            {
                Console.WriteLine("Game Save successful");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            #endregion
        }

        public void Load(Hero hero)
        {
            #region look for characters
            if (Directory.Exists(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerData") == false)
            {
                Directory.CreateDirectory(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerData");
                Directory.CreateDirectory(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerInventory");
                Console.WriteLine("Whats you name?\n");
                hero.Identifier = Console.ReadLine();
                hero.Initialize(hero);
            }
            else
            {
                string[] files = Directory.GetFiles(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerData");
                if (files.Length != 0)
                {
                    Console.Write(@"Which character would you like to play?
**************************************
");
                    for (int x = 0; x < files.Length; x++)
                    {
                        files[x] = files[x].Substring(53);
                        files[x] = files[x].Substring(0, files[x].Length - 8);
                        int y = x + 1;
                        Console.WriteLine("(" + y + ") " + files[x]);
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
                        iCharKey--;
                        string heroname = "";

                        heroname = files[iCharKey];
            #endregion

            #region Load Hero stats
                        if (File.Exists(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerData\" + heroname + "Data.txt"))
                        {
                            #region PlayerStats
                            using (StreamReader file = new StreamReader(@"C:\Program Files\TeridiumRPG\Teridium War\PlayerData\" + heroname + "Data.txt"))
                            {
                                hero.CurrentHealth = int.Parse(file.ReadLine());
                                hero.MaxHealth = int.Parse(file.ReadLine());
                                hero.CurrentMagic = int.Parse(file.ReadLine());
                                hero.MaxMagic = int.Parse(file.ReadLine());
                                hero.Attack = int.Parse(file.ReadLine());
                                hero.Defense = int.Parse(file.ReadLine());
                                hero.Experience = int.Parse(file.ReadLine());
                                hero.Gold = double.Parse(file.ReadLine());
                                hero.AttackDamage = int.Parse(file.ReadLine());
                                hero.Identifier = file.ReadLine();
                                hero.weapon = file.ReadLine();
                                hero.helmet = int.Parse(file.ReadLine());
                                hero.helmetname = file.ReadLine();
                                hero.chest = int.Parse(file.ReadLine());
                                hero.chestname = file.ReadLine();
                                hero.arm = int.Parse(file.ReadLine());
                                hero.armname = file.ReadLine();
                                hero.leg = int.Parse(file.ReadLine());
                                hero.legname = file.ReadLine();
                                hero.shoue = int.Parse(file.ReadLine());
                                hero.shouename = file.ReadLine();
                                hero.ArmorValue = int.Parse(file.ReadLine());
                                hero.AnzW6 = int.Parse(file.ReadLine());
                                hero.AnzLittleHPPotions = int.Parse(file.ReadLine());
                                hero.AnzMiddleHPPotions = int.Parse(file.ReadLine());
                                hero.AnzBigHPPotions = int.Parse(file.ReadLine());
                                hero.AnzLittleMPPotions = int.Parse(file.ReadLine());
                                hero.AnzMiddleMPPotions = int.Parse(file.ReadLine());
                                hero.AnzBigMPPotions = int.Parse(file.ReadLine());
                                hero.Level = int.Parse(file.ReadLine());
                            }
                            #endregion

                            #region ItemInventory
                            using (StreamReader InventoryReader = new StreamReader(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + heroname + "ItemInventory.txt"))
                            {
                                string line;
                                while ((line = InventoryReader.ReadLine()) != null)
                                {
                                    hero.Inventar.Add(line);
                                }
                            }
                            #endregion

                            #region WeaponInventory
                            using (StreamReader InventoryReader = new StreamReader(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + heroname + "WeaponInventory.txt"))
                            {
                                string line;
                                while ((line = InventoryReader.ReadLine()) != null)
                                {
                                    hero.WeaponInventar.Add(line);
                                }
                            }
                            #endregion

                            #region ArmorInventory
                            using (StreamReader InventoryReader = new StreamReader(@"c:\Program Files\TeridiumRPG\Teridium War\PlayerInventory\" + heroname + "ArmorInventory.txt"))
                            {
                                string line;
                                while ((line = InventoryReader.ReadLine()) != null)
                                {
                                    hero.ArmorInventar.Add(line);
                                }
                            }
                            #endregion

                            Console.WriteLine("Load Successful {0}.", heroname);
                            Console.WriteLine("Press enter to continue...");
                            Console.ReadLine();
                        }
                    }

                    else
                    {
                        Console.WriteLine("Whats you name?");
                        hero.Identifier = Console.ReadLine();
                        hero.Initialize(hero);
                    }
                }
                else
                {
                    Console.WriteLine("Whats you name?");
                    hero.Identifier = Console.ReadLine();
                }
                       
            } 
                        #endregion
        }
    }
}

