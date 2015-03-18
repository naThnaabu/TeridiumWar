using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TeridiumRPG
{
    class MainGame
    {
        #region creation of all the objects
        Hero myhero;
        Troll troll;
        Tiger tiger;
        Goblin goblin;
        Ork ork;
        FeuerDrache feuerdrache;
        EchsenMensch echsenmensch;
        Riesenratte riesenratte;
        HoelenBaer hoelenbaer;
        Battle battle;
        Shop shop;
        Tavern tavern;
        Spider spider;
        Wolf wolf;
        Werwolf werwolf;
        Gargoyl gargoyl;
        Gryphon gryphon;
        Harpye harpye;
        Hydra hydra;
        Minotauer minotauer;
        Mummy mummy;
        Wyvern wyvern;
        Zentaur zentaur;
        Jason jason;
        KnightHellebard knighth;
        KnightSword knights;
        WolfDeamon wolfdeamon;
        Mage mage;
        Warlock warlock;
        Druid druid;
        Prist prist;

        DataHandler datahandler;
        #endregion

        public MainGame()
        {
            if (File.Exists(@"C:\Program Files\TeridiumRPG\Teridium War\Itemlist.txt") == false)
            {
                Directory.CreateDirectory(@"C:\Program Files\TeridiumRPG\Teridium War");
                string[] line = new string[] { "Shoes of Might;3", "Shoes of the King;6", "Shoes of the truth;7", "Trousers of Might;3", "Trousers of the King;6", "Trousers of the truth;7", "Chest of Might;3", "Chest of the King;6", "Chest of the truth;7", "Arm guard of Might;3", "Arm guard of the King;6", "Arm guard of the truth;7", "Helmet of Might;3", "Helmet of the King;6", "Helmet of the truth;7" };
                File.WriteAllLines(@"C:\Program Files\TeridiumRPG\Teridium War\Itemlist.txt", line);
            }

            #region Variables
            bool banotherround;
            #endregion

            #region Console attributes
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    Console.SetWindowSize(78, 45);
                    Console.SetBufferSize(78, 45);
                    Console.Title = "Teridium RPG";
                    break;
                case PlatformID.Unix:
                    break;
                default:
                    break;
            }
            #endregion

            #region Creations
            datahandler = new DataHandler();

            #region Monster creation
            troll = new Troll();
            tiger = new Tiger();
            goblin = new Goblin();
            ork = new Ork();
            feuerdrache = new FeuerDrache();
            echsenmensch = new EchsenMensch();
            riesenratte = new Riesenratte();
            hoelenbaer = new HoelenBaer();
            spider = new Spider();
            wolf = new Wolf();
            werwolf = new Werwolf();
            gargoyl = new Gargoyl();
            gryphon = new Gryphon();
            harpye = new Harpye();
            //hydra = new Hydra();
            minotauer = new Minotauer();
            mummy = new Mummy();
            wyvern = new Wyvern();
            zentaur = new Zentaur();
            //jason = new Jason();
            knighth = new KnightHellebard();
            knights = new KnightSword();
            wolfdeamon = new WolfDeamon();
            mage = new Mage();
            warlock = new Warlock();
            druid = new Druid();
            prist = new Prist();

            #region MonsterList
            List<Character> MonsterList = new List<Character> { };
            MonsterList.Add(troll);
            MonsterList.Add(tiger);
            MonsterList.Add(goblin);
            MonsterList.Add(ork);
            MonsterList.Add(feuerdrache);
            MonsterList.Add(riesenratte);
            MonsterList.Add(hoelenbaer);
            MonsterList.Add(wolf);
            MonsterList.Add(spider);
            MonsterList.Add(werwolf);
            MonsterList.Add(gargoyl);
            MonsterList.Add(gryphon);
            MonsterList.Add(harpye);
            //MonsterList.Add(hydra);
            MonsterList.Add(minotauer);
            MonsterList.Add(mummy);
            MonsterList.Add(wyvern);
            MonsterList.Add(zentaur);
            //MonsterList.Add(jason);
            MonsterList.Add(knighth);
            MonsterList.Add(knights);
            MonsterList.Add(wolfdeamon);
            MonsterList.Add(mage);
            MonsterList.Add(warlock);
            MonsterList.Add(druid);
            MonsterList.Add(prist);
            //Add all monsters to a List
            #endregion
            #endregion

            #region Hero creation
            myhero = new Hero();
            //create the hero
            #endregion

            #endregion

            #region Check Hero stuff
            if (myhero.CurrentHealth <= 0)
            {
                myhero.CurrentHealth = myhero.MaxHealth;
            }
            #endregion

            #region The Game

            datahandler.Load(myhero);
            RPGStart();
            do
            {
                Random rnd = new Random();
                var ChoosenMonster = MonsterList[rnd.Next(MonsterList.Count)];
                banotherround = Decide(ChoosenMonster, myhero);
            }
            while (banotherround == true);
            //Choose one monster from the list and start the Battle Class
            datahandler.Save(myhero, "n");
            #endregion
        }

        #region functions
        void BasicGameLoop(Character monster, Hero hero)
        {

            battle = new Battle(myhero, monster); //copy of Battle called
        }

        #region Display Player choice
        bool Decide(Character monster, Hero hero)
        {
            bool banotherround = true;
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            Console.Write(@"Please choose what you want to do:
**********************************
(O)pen Player Stats
(I)nventory
(V)isit the Shop
(G)o to the Tavern
(F)ight against a Monster
(S)ave Game
(E)xit the Game
**********************************");
            Console.WriteLine();
            ConsoleKeyInfo foghtOrShopKey;
            string figthOrShop = "";
            foghtOrShopKey = Console.ReadKey(true);
            figthOrShop = foghtOrShopKey.KeyChar.ToString();
            switch (figthOrShop)
            {
                case "o":
                case "O":
                    hero.PrintHeroStatus();
                    Console.ReadKey();
                    banotherround = true;
                    break;

                case "v":
                case "V":
                    shop = new Shop(hero);
                    banotherround = true;
                    break;

                case "f":
                case "F":
                    BasicGameLoop(monster, hero);
                    banotherround = true;
                    break;

                case "g":
                case "G":
                    tavern = new Tavern(hero);
                    banotherround = true;
                    break;

                case "s":
                case "S":
                    datahandler.Save(hero, "n");
                    banotherround = true;
                    break;

                case "e":
                case "E":
                    banotherround = false;

                    break;

                case "i":
                case "I":
                    banotherround = true;
                    #region Sell from Inventory
                    Console.Clear();
                    Console.Write(@"******************************
(W)eapons
(A)rmor
(I)tems
(E)xit
******************************
");
                    Console.WriteLine();
                    ConsoleKeyInfo invchoiceKey;
                    invchoiceKey = Console.ReadKey(true);
                    string invchoice = invchoiceKey.KeyChar.ToString();
                    switch (invchoice)
                    {
                        case "W":
                        case "w":
                            EquipFromInventory(hero, hero.WeaponInventar);
                            break;

                        case "A":
                        case "a":
                            EquipFromInventory(hero, hero.ArmorInventar);
                            break;

                        case "I":
                        case "i":
                            PrintInventory(hero, hero.Inventar);
                            break;

                        case "E":
                        case "e":
                            break;

                        default:
                            Decide(monster, hero);
                            break;
                    }
                    #endregion
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    Decide(monster, hero);
                    break;
            }
            return banotherround;
        }
        #endregion

        #region Startscreen
        void RPGStart()
        {
            Console.Clear();
            Console.Write(@"
  _____         _     _ _                   ____  ____   ____ 
 |_   _|__ _ __(_) __| (_)_   _ _ __ ___   |  _ \|  _ \ / ___|
   | |/ _ \ '__| |/ _` | | | | | '_ ` _ \  | |_) | |_) | |  _ 
   | |  __/ |  | | (_| | | |_| | | | | | | |  _ <|  __/| |_| |
   |_|\___|_|  |_|\__,_|_|\__,_|_| |_| |_| |_| \_\_|    \____|
                                    
                        ^     \    /      ^                        
                       / \    \\__//     / \                   
                      /   \  ('\  /')   /   \                  
    _________________/_____\__\@  @/___/_____\________________ 
   |                          ¦\,,/¦                          |
   |                           \VV/                           |
   |               Welcome to <<Teridium RPG>>                |
   |                      (T)utorial                          |
   |                      (P)lay                              |       
   |                   Developed by Tehral                    |
   |__________________________________________________________|
                   | ./\/\ /            \ /\/\. |
                   |/     V              V     \|
                   ""                           ""
	                         
		  
");

            Console.WriteLine();
            ConsoleKeyInfo choiceKey;
            choiceKey = Console.ReadKey(true);
            string choice = choiceKey.KeyChar.ToString();
            switch (choice)
            {
                case "t":
                case "T":
                    Console.Clear();
                    Console.Write(@"Welcome to the tutorial. 
Teridium RPG is a textbased RPG. Your Character starts with nearly 
nothing but during the game you will get stronger and stronger.

There are 3 different things you can do:

Shop   -> Here you can buy Weapons, Armor parts and Potions.
Tavern -> The Tavern allows you to rest or drink & eat to restore 
your HP and MP
Fight against a Monster -> You will face one of my handmade Monsters. 
If you win you get EXP and Gold as a reward. But if you fail, you
will be dead and you need to load your last Save Game.

The Battle System:

You can choose between Attack, Spell and Potions.
If you Attack you have to roll a 20 sided Dice. The value needs 
to be less or equal to your Attack value. If this is the case you 
can attack and your enemy has to block your Attack by rolling a 20 
sided Dice. The value needs to be less or equal to his Defend value. 
If he can't block your attack you can roll as many 6 sided dices as
your Weapon allows. (Every Weapon has it own Profile). 
After your Attack is finished, the monster can do the same to you ;)


Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write(@"Here is a Sample of a fight:
Hero                        Monster
Attack: 9                   Attack: 12
Defense: 8                  Defense: 12
Weapon: Sword               Damage: 5
Weapon Damage: 1        
6 Sided Dices: 1
ArmorValue: 2      

You can attack....
Attack
Spell
Potions

Option 1 Attack:
To roll a 20 sided dices type in w20
(You rolled a dice)
Your result is: 4 (needs to be less or equal to your attack (9).
Your enemy tries to block your weapon.
(enemy rolls a dice)
His result is 9 (needs to be less or equal to his defense value (12)
He blocks...
Enemy attacks
(enemy rolls a dice)
His result is 13 (needs to be less or equal to his attack value (12)
He miss....


Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();

                    Console.Write(@"Option 2 Spell:
Hero                        Monster
HP: 18                      HP: 19
MP: 30                      MP: 0
Attack: 9                   Attack: 12
Defense: 8                   Defense: 12
Weapon: Sword               Damage: 5
Weapon Damage: 1        
6 Sided Dices: 1
ArmorValue: 2      

You can attack....
Attack
Spell
Potions

Which Spell would you like to cast:
(F)ireball
(H)eal
(W)aterstrike
(you press f)
enemy lost 9 HP and has now 10 HP left.
Enemy attacks
(enemy rolls a dice)
His result is 13 (needs to be less or equal to his attack value (12)
He miss....


Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();

                    Console.Write(@"Option 3 Potions:
Which Potion would you like to drink:
(1)Little HP Potion      
(2)Middle HP Potion
(3)Little MP Potion
(4)Middle MP Potion
(you press 3 and drink a Little MP Potion)
You drank Little MP Potions and restored 5 MP.
Enemy attacks
(enemy rolls a dice)
His result is 13 (needs to be less or equal to his attack value (12)
He miss....


Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();

                    Console.Write(@"Damage Dealing you:
Hero                        Monster
HP: 18                      HP: 19
MP: 30                      MP: 0
Attack: 9                   Attack: 12
Defense: 8                   Defense: 12
Weapon: Sword               Damage: 5
Weapon Damage: 1        
6 Sided Dices: 1
ArmorValue: 2  

If you hit the Monster and it can't block your attack it will be like this:
Type in W6 to roll a 6 sided dice...
(you type in w6)
your result is 3
(Damage = W6 (3) + Weapon Damage (1) = 4)
Your enemy lost 4 HP and has now 15 left.


Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write(@"Damage Dealing enemy:
Hero                        Monster
HP: 18                      HP: 19
MP: 30                      MP: 0
Attack: 9                   Attack: 12
Defense: 8                   Defense: 12
Weapon: Sword               Damage: 5
Weapon Damage: 1        
6 Sided Dices: 1
ArmorValue: 2  

If the Monster hits you and you can't block his attack it will be like this:
Damage(5) - your armor value(2) = 3
Your lost 3 HP and you have now 15 left.


");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to go back to the game.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    Console.Clear();
                    System.Threading.Thread.Sleep(800);
                    break;

                case "P":
                case "p":
                    return;

                default:
                    Console.Clear();
                    RPGStart();
                    break;
            }
        }
        #endregion

        #region ShowInventory
        void PrintInventory(Hero hero, List<string> list)
        {
            Console.Clear();
            Console.Write(@"**************************************************************
Nr.                    Name                 Own       Price
--------------------------------------------------------------
");
            int i = 0;

            string[] aHero = list.ToArray();
            var counts = aHero
                .GroupBy(w => w)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .ToList();
            foreach (var p in counts)
            {
                string[] output = p.Word.Split(';');
                Console.Write(@"{0}{1}{2}{3}", i.ToString().PadRight(5, ' '), output[0].PadRight(40, ' '), p.Count.ToString().PadRight(10, ' '), output[1] + "\n");
                i++;
            }
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("**************************************************************\nPress any key to continue...\n");
            Console.ReadKey();
        }
        #endregion

        #region equip functions
        void EquipFromInventory(Hero hero, List<string> list)
        {
            Console.Clear();
            #region PrintHeader
            if (list == hero.WeaponInventar)
            {
                Console.Write(@"Equipped: {0} {1}W6 {2}DMG
**************************************************************
Which Item would you like to equip?
Nr.         Name                 Own           W6       DMG
--------------------------------------------------------------
", hero.weapon, hero.AnzW6, hero.AttackDamage);
            }
            else
            {
                Console.Write(@"**************************************************************
Which Item would you like to equip?
Nr.         Name                 Own          Armor      Place
--------------------------------------------------------------
");
            #endregion
            }
            DataHandler datahandler = new DataHandler();
            datahandler.Save(hero, "y");
            int i = 0;

            #region Write Items
            string[] aHero = list.ToArray();
            var counts = aHero
                .GroupBy(w => w)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .ToList();

            foreach (var p in counts)
            {
                string[] output = p.Word.Split(';');
                Console.Write(@"{0}{1}{2}{3}{4}", i.ToString().PadRight(12, ' '), output[0].PadRight(22, ' '), p.Count.ToString().PadRight(14, ' '), output[2].ToString().PadRight(9, ' '), output[3].ToString() + "\n");
                i++;
            }
            Console.WriteLine("--------------------------------------------------------------\n(E)xit");
            Console.WriteLine("**************************************************************\n");
            #endregion
            ConsoleKeyInfo sellchoiceKey;
            string sellchoice = "";
            sellchoiceKey = Console.ReadKey(true);
            sellchoice = sellchoiceKey.KeyChar.ToString();
            if (sellchoice == "E" | sellchoice == "e")
            {
                return;
            }
            int isellchoice = Convert.ToInt32(sellchoice);

            string[] soutput;
            char[] cdelim = { ';' };
            string choice = list.ElementAt(isellchoice);
            soutput = choice.Split(cdelim);
            Console.Write(@"Are you sure that you want to equip {0}?
(Y)es
(N)o
", soutput[0]);
            sellchoiceKey = Console.ReadKey(true);
            sellchoice = sellchoiceKey.KeyChar.ToString();
            switch (sellchoice)
            {
                case "Y":
                case "y":

                    string name;
                    int Itemcost = 0;

                    string[] lines = System.IO.File.ReadAllLines(@"c:\Program Files\TeridiumRPG\Teridium War\Itemlist.txt");

                    foreach (string line in lines)
                    {
                        string[] itemline;
                        itemline = line.Split(';');
                        name = itemline[0];
                        if (name == soutput[0])
                        {
                            Itemcost = Convert.ToInt32(itemline[1]);
                        }
                    }

                    #region Add Item to Inventory and equip Item
                    if (list == hero.WeaponInventar)
                    {
                        list.Add(hero.weapon + ";" + Itemcost + ";" + hero.AnzW6 + ";" + hero.AttackDamage);
                        hero.weapon = soutput[0];
                        hero.AnzW6 = int.Parse(soutput[2]);
                        hero.AttackDamage = int.Parse(soutput[3]);
                    }
                    if (soutput[3] == "head")
                    {
                        list.Add(hero.helmetname + ";" + Itemcost + ";" + hero.helmet + ";helmet");
                        hero.helmetname = soutput[0];
                        hero.helmet = int.Parse(soutput[2]);
                    }
                    if (soutput[3] == "chest")
                    {
                        list.Add(hero.chestname + ";" + Itemcost + ";" + hero.chest + ";chest");
                        hero.chestname = soutput[0];
                        hero.chest = int.Parse(soutput[2]);
                    }
                    if (soutput[3] == "leg")
                    {
                        list.Add(hero.legname + ";" + Itemcost + ";" + hero.leg + ";leg");
                        hero.legname = soutput[0];
                        hero.leg = int.Parse(soutput[2]);
                    }
                    if (soutput[3] == "foot")
                    {
                        list.Add(hero.shouename + ";" + Itemcost + ";" + hero.shoue + ";foot");
                        hero.shouename = soutput[0];
                        hero.shoue = int.Parse(soutput[2]);
                    }
                    if (soutput[3] == "arm")
                    {
                        list.Add(hero.armname + ";" + Itemcost + ";" + hero.arm + ";foot");
                        hero.armname = soutput[0];
                        hero.arm = int.Parse(soutput[2]);
                    }
                    #endregion
                    list.RemoveAt(isellchoice);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                default:
                    EquipFromInventory(hero, list);
                    break;
            }
        }
        #endregion


        #endregion
    }
}


