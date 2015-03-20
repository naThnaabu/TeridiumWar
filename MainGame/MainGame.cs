using System;
using System.Collections.Generic;

namespace TeridiumRPG
{
    class MainGame
    {
        TeridiumRPG.Shop.Shop shop;
        Hero myhero;
        Tavern tavern;
        Battle battle;
        List<Character> MonsterList;
        const string stars = "********************************";
        string posttext;
        bool playGame;
        string[] mainmenu;

        public MainGame ()
        {
            shop = Game.LoadShop ("default");
            MonsterList = new List<Character> (Game.LoadAllCharacters ());
            posttext = "";
            playGame = true;
            mainmenu = new string[] {
                "Open Player Stats",
                "Inventory",
                "Visit the Shop",
                "Go to the Tavern",
                "Fight against a Monster",
                "Save Game",
                "Exit the Game",
            };
        }

        public int Play ()
        {

            string[] line = new string[] {
                "Shoes of Might;3",
                "Shoes of the King;6",
                "Shoes of the truth;7",
                "Trousers of Might;3",
                "Trousers of the King;6",
                "Trousers of the truth;7",
                "Chest of Might;3",
                "Chest of the King;6",
                "Chest of the truth;7",
                "Arm guard of Might;3",
                "Arm guard of the King;6",
                "Arm guard of the truth;7",
                "Helmet of Might;3",
                "Helmet of the King;6",
                "Helmet of the truth;7"
            };

            //Loading of Hero and selection
            var heroes = Game.ListHeros ();
            if (heroes.Length < 1) {
                myhero = new Hero ();
                Console.WriteLine ("Whats you name?");
                myhero.Identifier = Console.ReadLine ();
                myhero.Initialize ();
                Game.SaveHero (myhero);
            } else if (heroes.Length == 1) {
                myhero = Game.LoadHero ((string)heroes.GetValue (0));
            } else {
                Console.Write ("Which character would you like to play?\n**************************************\n");
                for (int x = 0; x < heroes.Length; x++) {
                    int y = x + 1;
                    Console.WriteLine ("(" + y + ") " + (string)heroes.GetValue (x));
                }
                Console.WriteLine ("(N)ew Character?");
                Console.WriteLine ("**************************************");
                ConsoleKeyInfo CharKey;
                CharKey = Console.ReadKey (true);
                string sCharKey;
                sCharKey = CharKey.KeyChar.ToString ();
                if (sCharKey != "N" & sCharKey != "n") {
                    int iCharKey = Convert.ToInt32 (sCharKey);
                    iCharKey--;
                    myhero = Game.LoadHero ((string)heroes.GetValue (iCharKey));
                } else {
                    myhero = new Hero ();
                    Console.WriteLine ("Whats you name?");
                    myhero.Identifier = Console.ReadLine ();
                    myhero.Initialize ();
                    Game.SaveHero (myhero);
                }
            }

            //Print Start Banner
            RPGStart ();

            //Main Game Loop
            while (playGame == true) {
                Random rnd = new Random ();
                var ChoosenMonster = MonsterList [rnd.Next (MonsterList.Count)];
                int choice = GameOutput.printMenu (mainmenu, stars, stars, "", posttext);
                switch (choice) {
                    case 0:
                        myhero.PrintHeroStatus ();
                        Console.ReadKey ();
                        playGame = true;
                        break;

                    case 1:
                        playGame = true;
                        PrintInventory (myhero);
                        break;

                    case 2:
                        myhero = shop.Visit (myhero);
                        playGame = true;
                        break;

                    case 3:
                        battle = new Battle (myhero, ChoosenMonster);
                        playGame = true;
                        break;

                    case 4:
                        tavern = new Tavern (myhero);
                        playGame = true;
                        break;

                    case 5:
                        Game.SaveHero (myhero);
                        posttext = "Hero Saved";
                        playGame = true;
                        break;

                    case 6:
                        playGame = false;
                        Console.WriteLine ("Good Bye");
                        break;

                    default:
                        posttext = "I'm sorry that wasn't a valid choice.";
                        break;
                }
                Game.SaveHero (myhero);
            }
            return 0;
        }

        #region functions

        #region Startscreen

        void RPGStart ()
        {
            Console.Clear ();
            Console.Write (@"
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
   |               Developed by Tehral and Toast              |
   |__________________________________________________________|
                   | ./\/\ /            \ /\/\. |
                   |/     V              V     \|
                   ""                           ""
	                         
		  
");

            Console.WriteLine ();
            ConsoleKeyInfo choiceKey;
            choiceKey = Console.ReadKey (true);
            string choice = choiceKey.KeyChar.ToString ();
            switch (choice) {
                case "t":
                case "T":
                    Console.Clear ();
                    Console.Write (@"Welcome to the tutorial. 
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
                    Console.ReadKey ();
                    Console.Clear ();
                    Console.Write (@"Here is a Sample of a fight:
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
                    Console.ReadKey ();
                    Console.Clear ();

                    Console.Write (@"Option 2 Spell:
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
                    Console.ReadKey ();
                    Console.Clear ();

                    Console.Write (@"Option 3 Potions:
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
                    Console.ReadKey ();
                    Console.Clear ();

                    Console.Write (@"Damage Dealing you:
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
                    Console.ReadKey ();
                    Console.Clear ();
                    Console.Write (@"Damage Dealing enemy:
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
                    Console.WriteLine ("Press any key to go back to the game.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey ();
                    Console.Clear ();
                    System.Threading.Thread.Sleep (800);
                    break;

                case "P":
                case "p":
                    return;

                default:
                    Console.Clear ();
                    RPGStart ();
                    break;
            }
        }

        #endregion

        #region ShowInventory

        void PrintInventory (Hero hero)
        {
            Console.Clear ();
            Console.Write (@"**************************************************************
Nr.                    Name                 Weight      Price
--------------------------------------------------------------
");
            int i = 1;
            foreach (Item item in hero.Inventory) {
                Console.WriteLine ("{0}                    {1}                  {2}       {3}", i, item.Name, item.Weight, item.Price);
                i++;
            }
            Console.WriteLine ("--------------------------------------------------------------");
            Console.WriteLine ("**************************************************************");
            Console.WriteLine ("Press any key to continue...");
            Console.ReadKey ();
        }

        #endregion


        #endregion
    }
}


