using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TeridiumRPG
{
    class Battle
    {
        #region Variables

        int round = 1;

        #endregion

        #region The Battle

        public Battle (Hero hero, Character monster)
        {
            bool spellcasted = false;
            Console.Write (monster.Print);
            Console.WriteLine (hero.Identifier + " is facing a " + monster.Identifier + "\nPress any key to continue...\n");
            Console.ReadKey ();
            FightPrintStatus (hero, monster, round);
            BattleLoop (hero, monster, spellcasted);
        }

        public void BattleLoop (Hero hero, Character monster, bool spellcasted)
        {
            round = 0;
            do {
                round++;
                if (spellcasted == true) {
                    FightPrintStatus (hero, monster, round);
                }
                spellcasted = true;
                Fight (hero, monster, spellcasted);
                Console.Clear ();
                monster.isAlive = CheckHealth (monster.CurrentHealth);
                hero.isAlive = CheckHealth (hero.CurrentHealth);

            } while (hero.isAlive == true && monster.isAlive == true);
            monster.CurrentHealth = monster.MaxHealth;
            monster.CurrentMagic = monster.MaxMagic;

            if (hero.isAlive == false) {
                Console.Write (@"
     _.--""""--._
    /  _    _  \
 _  ( (_\  /_) )  _
{ \._\   /\   /_./ }
/_""=-.}______{.-=""_\
 _  _.=("""""""")=._  _
(_'""_.-""`~~`""-._""'_)
 {_""            ""_}
You were killed and need to load your last Save-game or
drink some potions/rest in the Inn.


");
                /*(L)oad last save-game
(G)o back to the homescreen
                ConsoleKeyInfo deadchoiceKey;
                deadchoiceKey = Console.ReadKey(true);
                string deadchoice = deadchoiceKey.KeyChar.ToString();
                switch (deadchoice)
                {
                    case "l":
                    case "L":

                        break;

                    case "G":
                    case "g":
                        return;

                    default:
                        return;
                }*/
            }

        }

        #endregion

        #region Fight

        public void FightPrintStatus (Hero hero, Character monster, int Round)
        {
            Console.Clear ();
            Console.Write (@"
            Round {0}
**********************************            
{1}         {8}
HP: {2}/{3}      HP: {9}/{10}
MP: {4}/{5}      MP: {11}/{12}
AT: {6}          AT: {13}   
PT: {7}          PT: {14}     
**********************************", Round, hero.Identifier, hero.CurrentHealth, hero.MaxHealth, hero.CurrentMagic, hero.MaxMagic, hero.Attack, hero.Defense,
                monster.Identifier, monster.CurrentHealth, monster.MaxHealth, monster.CurrentMagic,
                monster.MaxMagic, monster.Attack, monster.Defense);
        }

        string AttackChoice ()
        {
            ConsoleKeyInfo ChoiceKey;
            string Choice = "";
            string FightChoice = "";
            Console.WriteLine ("\n\nYou can attack.\n");
            Console.WriteLine (@"
*****************************
Type in what you want to do:
(A)ttack
(S)pell
(P)otions
(H)ero Status
*****************************");
            ChoiceKey = Console.ReadKey (true);
            FightChoice = ChoiceKey.KeyChar.ToString ();
            switch (FightChoice) {
                case "s":
                case "S":
                    Choice = "Spell";
                    break;

                case "A":
                case "a":
                    Choice = "Attack";
                    break;

                case "P":
                case "p":
                    Choice = "Potions";
                    break;

                case "H":
                case "h":
                    Choice = "Status";
                    break;

                default:
                    Console.WriteLine ("Invalid Choice, please try again.\n");
                    Choice = AttackChoice ();
                    break;
            }
            return Choice;
        }

        void Fight (Hero hero, Character monster, bool spellcasted)
        {
            bool potionsprocess = false;
            string Fightchoice = "";
            string spellchoice = "";
            hero.isAlive = CheckHealth (hero.CurrentHealth);
            if (hero.isAlive == true) {
                Fightchoice = AttackChoice ();
                if (Fightchoice == "Attack") {
                    spellcasted = true;
                    AttackProcess (hero, monster);
                }
                if (Fightchoice == "Spell") {
                    spellcasted = true;
                    spellchoice = FightPrintSpells (hero.CurrentMagic);
                    ProcessTheSpellChoice (spellchoice, hero);
                    if (spellchoice != "e") {
                        spellcasted = CastASpell (hero, monster, spellchoice);
                    } else {
                        spellcasted = false;
                        round--;
                    }
                    if (spellchoice != "h" & spellchoice != "H") {
                        Console.WriteLine ("Your enemy has now " + monster.CurrentHealth + " HP.\nPress any key to continue...\n");
                        Console.ReadKey ();
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (Fightchoice == "Potions") {
                    bool PotionDrunk = false;
                    spellcasted = true;
                    string potionchoice = "";
                    potionchoice = FightPrintPotions (hero);
                    PotionDrunk = ProcessThePotionChoice (potionchoice, hero);
                    if (PotionDrunk == false) {
                        FightPrintStatus (hero, monster, round);
                        Fight (hero, monster, spellcasted);
                        potionsprocess = true;
                    } else {
                        potionsprocess = false;
                        spellcasted = true;
                    }
                }
                if (Fightchoice == "Status") {
                    hero.PrintCharacterStatus ();
                    potionsprocess = true;
                    round--;
                }
                if (potionsprocess == false) {
                    potionsprocess = true;
                    if (spellcasted == true) {
                        spellcasted = false;
                        monster.isAlive = CheckHealth (monster.CurrentHealth);
                        if (monster.isAlive == true) {
                            MonsterAttackProcess (hero, monster);
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine ("You have killed the " + monster.Identifier + "!");
                            hero.Experience += monster.Experience;
                            hero.Gold += monster.Gold;
                            Console.WriteLine ("You get " + monster.Gold + " Gold and " + monster.Experience + " EXP\nYou have now " + hero.Gold + " Gold.\n");
                            RandomDrop (monster.Experience, hero);
                            hero.LevelUpdate ();
                            Console.WriteLine ("Press any key to continue....\n");
                            Console.ReadKey ();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Clear ();
                            Game.SaveHero (hero);
                        }
                    }
                }
            }
        }

        void AttackProcess (Hero hero, Character monster)
        {
            int HeroAttack = hero.Attack;
            int MonsterDefens = monster.Defense;
            int W20 = 0;
            W20 = RollW20 ();
            if (W20 <= HeroAttack) {
                Console.WriteLine ("Your attack is heading towards your enemy...\n");
                System.Threading.Thread.Sleep (800);
                Console.WriteLine ("\nThe " + monster.Identifier + " tries to block your weapon...");
                W20 = RandomW20 ();
                if (W20 <= MonsterDefens) {
                    Console.WriteLine ("Without any harm he blocks your weapon before it reaches its target.\n");
                } else {
                    Console.WriteLine ("\nYour weapon hits the " + monster.Identifier + "\n");
                    int Demage = 0;
                    int AnzW6 = 0;
                    AnzW6 = hero.AnzW6;
                    for (; AnzW6 >= 1;) {
                        AnzW6--;
                        Demage += RollW6 ();
                    }
                    Demage += hero.AttackDamage;
                    monster.CurrentHealth -= Demage;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine ("The " + monster.Identifier + " lost " + Demage + " HP and has now " + monster.CurrentHealth + " HP left.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } else {
                Console.Write ("You missed....\n\n");
                System.Threading.Thread.Sleep (800);
            }
        }

        void MonsterAttackProcess (Hero hero, Character monster)
        {
            int HeroAttack = hero.Attack;
            int HeroDefens = hero.Defense;
            int MonsterAttack = monster.Attack;
            int MonsterDefens = monster.Defense;
            int W20 = 0;
            int HeroArmorValue = 0;
            Random rnd;
            rnd = new Random ();
            int KI = rnd.Next (0, 9);
            string spell = "";

            monster.isAlive = CheckHealth (monster.CurrentHealth);
            if (monster.isAlive == true) {
                System.Threading.Thread.Sleep (800);
                if (monster.CurrentMagic >= 10 && KI <= 5) {
                    Console.WriteLine ("The Mage begins to cast a Spell...");
                    KI = rnd.Next (1, 4);
                    if (monster.CurrentHealth <= monster.MaxHealth / 3) {
                        KI = 2;
                    }
                    switch (KI) {
                        case 1:
                            spell = "f";
                            break;

                        case 2:
                            spell = "h";
                            break;

                        case 3:
                            spell = "i";
                            break;

                        case 4:
                            spell = "w";
                            break;
                    }
                    CastASpell (monster, hero, spell);
                    Console.WriteLine ("Press any key to continue...\n");
                    Console.ReadKey ();
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else {
                    Console.WriteLine ("\nThe " + monster.Identifier + " attacks...");
                    W20 = RandomW20 ();
                    if (W20 <= MonsterAttack) {
                        Console.WriteLine ("His weapon is targeting your head....\nTry to defend yourself...\n");
                        W20 = RollW20 ();
                        if (W20 <= HeroDefens) {
                            Console.Write ("Without any problem you blocked his attack.\n");
                            Console.WriteLine ("Press any key to continue...\n");
                            Console.ReadKey ();
                        } else {
                            Console.WriteLine ("His Weapon hits you right on your shoulder.\n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            HeroArmorValue = hero.ArmorValue ();
                            int Damage = monster.AttackDamage - HeroArmorValue;
                            Console.WriteLine ("You take " + monster.AttackDamage + " Damage.\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            hero.CurrentHealth -= Damage;
                            Console.WriteLine ("Press any key to continue...\n");
                            Console.ReadKey ();
                        }
                    } else {
                        Console.WriteLine ("The " + monster.Identifier + " missed.\nPress any key to continue...\n");
                        Console.ReadKey ();
                    }
                }
            }
        }

        #endregion

        #region Spell

        public static bool CastASpell (Character attacker, Character defender, string spellchoice)
        {
            bool spellcasted = true;
            Spell spell;

            spell = ProcessTheSpellChoice (spellchoice, attacker);
            if (spell != null) {

                int spellpower = spell.SpellCast (attacker);
                if (spellpower != 0) {
                    if (spell.isOnSelf == true) {
                        attacker.CurrentHealth += spellpower;
                        if (attacker.CurrentHealth > attacker.MaxHealth) {
                            attacker.CurrentHealth = attacker.MaxHealth;
                        }
                    } else if (spell.multipleHits == true) {
                        defender.CurrentHealth -= spellpower;
                    } else if (spell.singleTarget == true) {
                        defender.CurrentHealth -= spellpower;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    spellcasted = true;

                } else {
                    spellcasted = false;
                }
            } else {
                spellcasted = false;
            }
            return spellcasted;
        }

        public static string FightPrintSpells (int MP)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear ();
            ConsoleKeyInfo spellchoicekey;
            string spellchoice;
            Console.Write (@"
Please choose a spell:
****************************
                Damage  MP
(H)eal            7     15
(F)ireball        9     15
(I)cebolt         8     12 
(W)aterStrike     7     10
(E)xit

You have {0} MP
****************************
", MP);
            spellchoicekey = Console.ReadKey (true);
            spellchoice = spellchoicekey.KeyChar.ToString ();
            return spellchoice;
        }

        public static Spell ProcessTheSpellChoice (string spellchoice, Character attacker)
        {
            Spell spell;
            switch (spellchoice) {
                case "H":
                case "h":
                    Heal_little heal = new Heal_little ();
                    return heal;
                case "F":
                case "f":
                    Fireball fireball = new Fireball ();
                    return fireball;
                case "I":
                case "i":
                    Icebolt icebolt = new Icebolt ();
                    return icebolt;

                case "W":
                case "w":
                    WaterStrike waterstrike = new WaterStrike ();
                    return waterstrike;

                case "E":
                case "e":
                    return null;

                default:
                    Console.WriteLine ("\nI'm sorry that wasn't a valid choice.\n");
                    spellchoice = FightPrintSpells (attacker.CurrentMagic);
                    spell = ProcessTheSpellChoice (spellchoice, attacker);
                    break;
            }
            return spell;
        }

        #endregion

        #region Potion

        public static string FightPrintPotions (Hero hero)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleKeyInfo potionchoicekey;
            string potionchoice = "";
            Console.Clear ();
            Console.Write (@"
Please choose a Potion:
*********************************
Name                   possesion
(L)ittle HP Potion        {0}
(M)iddle HP Potion        {1}
(B)ig HP Potion           {2}
(E)xit
*********************************", hero.AnzLittleHPPotions, hero.AnzMiddleHPPotions, hero.AnzBigHPPotions);
            Console.WriteLine ();
            potionchoicekey = Console.ReadKey (true);
            Console.ForegroundColor = ConsoleColor.Gray;
            potionchoice = potionchoicekey.KeyChar.ToString ();
            return potionchoice;
        }

        public bool ProcessThePotionChoice (string potionchoice, Hero hero)
        {
            bool PotionDrunk = false;
            switch (potionchoice) {
                case "L":
                case "l":
                    HP_little_potion littleHPpotion = new HP_little_potion ();
                    PotionDrunk = littleHPpotion.drink (hero);
                    break;

                case "M":
                case "m":
                    HP_middle_potion middleHPpotion = new HP_middle_potion ();
                    PotionDrunk = middleHPpotion.drink (hero);
                    break;

                case "B":
                case "b":
                    HP_big_potion bigHPpotion = new HP_big_potion ();
                    PotionDrunk = bigHPpotion.drink (hero);
                    break;

                case "E":
                case "e":

                    break;

                default:
                    Console.WriteLine ("\nI'm sorry that wasn't a valid choice.\n");
                    potionchoice = FightPrintPotions (hero);
                    ProcessThePotionChoice (potionchoice, hero);
                    break;
            }
            Console.Clear ();
            return PotionDrunk;
        }

        #endregion

        #region CheckHealth

        bool CheckHealth (int health)
        {
            bool alive;
            if (health > 0) {
                alive = true;
            } else {
                alive = false;
            }
            return alive;
        }

        #endregion

        #region Roll dices

        int RollW20 ()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine ("Press Enter to roll a 20 sided dice");
            Console.ReadKey (true);
            int W20 = 0;
            int max = 20;
            int min = 1;
            Random rand = new Random ();
            W20 = rand.Next (min, max);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("Your result is: " + W20);
            Console.ForegroundColor = ConsoleColor.Gray;
            return W20;
        }

        int RandomW20 ()
        {
            int max = 20;
            int min = 1;
            int W20 = 0;
            Random rand = new Random ();
            W20 = rand.Next (min, max);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("Your enemy has rolled the dices with the following result: " + W20);
            Console.ForegroundColor = ConsoleColor.Gray;
            return W20;
        }

        int RollW6 ()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine ("Press Enter to roll a 6 sided dice");
            Console.ReadKey (true);
            int W6 = 0;
            int max = 6;
            int min = 1;
            Random rand = new Random ();
            W6 = rand.Next (min, max);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("Your result is: " + W6);
            Console.ForegroundColor = ConsoleColor.Gray;
            return W6;
        }

        #endregion

        #region Monster Drop

        bool CheckInventar (string cItem, Hero hero)
        {
            bool toMuchInInv = false;

            return toMuchInInv;
        }

        void RandomDrop (int MonsterEXP, Hero hero)
        {
            #region Item Lists
            List<string> LowItemList = new List<string> ();
            List<string> MiddleItemList = new List<string> ();
            List<string> BigItemList = new List<string> ();

            #region Add LowListItems
            LowItemList.Add ("broken piece of gear;0.10;item");
            LowItemList.Add ("leather;0.50;item");
            LowItemList.Add ("A straight razor;0.20;item");
            LowItemList.Add ("A beaded headband;0.25;item");
            LowItemList.Add ("A six-sided dice;0.20;item");
            LowItemList.Add ("A hand drawn house plans;1.00;item");
            LowItemList.Add ("Speckled egg shells and sand;0.50;item");
            LowItemList.Add ("A chunk of sealing wax marked with an insignia ;1.20;item");
            LowItemList.Add ("A ball of soap;0.50;item");
            LowItemList.Add ("Handful of colorful stones;1.30;item");
            LowItemList.Add ("A wooden mask;1.60;item");
            LowItemList.Add ("A pouch of coffee beans;2.00;item");
            LowItemList.Add ("Well wrapped hard sugar candies;1.80;item");
            LowItemList.Add ("A hatchet handle;1.40;item");
            LowItemList.Add ("A bone whistle;2.00;item");
            LowItemList.Add ("A ball of yarn and knitting needles;2.10;item");
            LowItemList.Add ("Half eaten rye loaf;0.30;item");
            LowItemList.Add ("A ball fashoined of willow twigs ;0.50;item");
            LowItemList.Add ("20' Fishing line and hook;2.00;item");
            LowItemList.Add ("A pocketbook of pressed flowers;1.40;item");
            LowItemList.Add ("A rock;0.20;item");
            LowItemList.Add ("A Handful of local nuts;1.10;item");
            LowItemList.Add ("A pouch of seeds;1.00;item");
            LowItemList.Add ("Sketch of a bird;2.00;item");
            LowItemList.Add ("A pewter engagement ring;4.00;item");
            LowItemList.Add ("A dried, local flower;1.30;item");
            LowItemList.Add ("The torn out first page of a spellbook;2.55;item");
            LowItemList.Add ("A griffon feather;3.00;item");
            LowItemList.Add ("Small pouch of salt;1.30;item");
            LowItemList.Add ("Rough-carved wooden holy symbol;1.70;item");
            LowItemList.Add ("Iron signet ring;4.50;item");
            LowItemList.Add ("A broken clay bowl;0.80;item");
            LowItemList.Add ("Deck of worn playing cards;1.25;item");
            LowItemList.Add ("A tuft of dirty wool;1.40;item");
            LowItemList.Add ("Toothpicks;0.55;item");
            LowItemList.Add ("Braded leather bracelet;1.60;item");
            LowItemList.Add ("A mummified child's hand;2.65;item");
            LowItemList.Add ("Two small pulleys;2.40;item");
            LowItemList.Add ("Wedge of cheese;1.40;item");
            LowItemList.Add ("Forceps;1.00;item");
            LowItemList.Add ("Handful of nails;0.85;item");
            LowItemList.Add ("A finger bone;0.45;item");
            LowItemList.Add ("Iron filings;2.00;item");
            LowItemList.Add ("Tempered glass pipe and a tobacco pouch;4.50;item");
            LowItemList.Add ("A handkerchief;0.25;item");
            LowItemList.Add ("A large tooth;0.15;item");
            LowItemList.Add ("A military medal;2.40;item");
            LowItemList.Add ("Necklace of shells;1.60;item");
            LowItemList.Add ("A worn religious text;0.65;item");
            LowItemList.Add ("Dried fruit;0.70;item");
            LowItemList.Add ("Owlfeathers;0.25;item");
            LowItemList.Add ("A twin-sided, lucky coin;1.20;item");

            #endregion

            #region Add MiddleListItems
            MiddleItemList.Add ("azurite;1.50;item");
            MiddleItemList.Add ("jade;2.00;item");
            MiddleItemList.Add ("carnelian;1.60;item");
            MiddleItemList.Add ("citrine;1.65;item");
            MiddleItemList.Add ("red spinel;1.10;item");
            MiddleItemList.Add ("aquamarine;1.30;item");
            MiddleItemList.Add ("sard;1.30;item");
            MiddleItemList.Add ("malachite;1.60;item");
            MiddleItemList.Add ("violet garnet;1.40;item");
            MiddleItemList.Add ("red-brown spinel;1.20;item");
            MiddleItemList.Add ("obsidian;2.00;item");
            MiddleItemList.Add ("pink pearl;2.60;item");
            MiddleItemList.Add ("fire opal;2.10;item");
            MiddleItemList.Add ("black star sapphire;2.40;item");
            MiddleItemList.Add ("jasper;1.50;item");
            MiddleItemList.Add ("blue sapphire;2.30;item");
            MiddleItemList.Add ("bloodstone;3.00;item");
            MiddleItemList.Add ("brass mug with jade inlays;2.60;item");
            MiddleItemList.Add ("embroidered and bejeweled glove;4.00;item");
            MiddleItemList.Add ("silver ewer;3.50;item");
            MiddleItemList.Add ("brass mug with jade inlays;4.60;item");
            MiddleItemList.Add ("carved bone statuette;3.00;item");
            MiddleItemList.Add ("large well-done wool tapestry;3.20;item");
            MiddleItemList.Add ("a string of small pink pearls;5.00;item");
            MiddleItemList.Add ("jeweled anklet;4.60;item");
            MiddleItemList.Add ("jeweled electrum ring;4.80;item");

            #endregion

            #region Add BigListItems
            BigItemList.Add ("Mage Sword;8.00;weapon;2;4");
            BigItemList.Add ("2 Handed Axe;6.00;weapon;1;5");
            BigItemList.Add ("Long Sword;4.00;weapon;1;4");
            BigItemList.Add ("Dagger;4.00;weapon;1;4");
            BigItemList.Add ("Long Bow;7.00;weapon;1;6");
            #endregion
            #endregion

            int MonsterClass = MonsterEXP / 5;
            var ChoosenItem = "";

            #region Choose RandomItem
            Random rnd = new Random ();
            switch (MonsterClass) {
                case 1:
                    ChoosenItem = LowItemList [rnd.Next (LowItemList.Count)];
                    break;

                case 2:
                    ChoosenItem = LowItemList [rnd.Next (LowItemList.Count)];
                    break;

                case 3:
                    ChoosenItem = LowItemList [rnd.Next (LowItemList.Count)];
                    break;

                case 4:
                    ChoosenItem = MiddleItemList [rnd.Next (MiddleItemList.Count)];
                    break;

                case 5:
                    ChoosenItem = MiddleItemList [rnd.Next (MiddleItemList.Count)];
                    break;

                case 6:
                    ChoosenItem = MiddleItemList [rnd.Next (MiddleItemList.Count)];
                    break;

                case 7:
                    ChoosenItem = MiddleItemList [rnd.Next (MiddleItemList.Count)];
                    break;

                case 8:
                    ChoosenItem = MiddleItemList [rnd.Next (MiddleItemList.Count)];
                    break;

                case 9:
                    ChoosenItem = BigItemList [rnd.Next (BigItemList.Count)];
                    break;

                case 10:
                    ChoosenItem = BigItemList [rnd.Next (BigItemList.Count)];
                    break;

                case 11:
                    ChoosenItem = BigItemList [rnd.Next (BigItemList.Count)];
                    break;

                case 12:
                    ChoosenItem = BigItemList [rnd.Next (BigItemList.Count)];
                    break;
            }
            #endregion

            string[] OutputItem = ChoosenItem.Split (';');

            Console.WriteLine ("You found the following Item: " + OutputItem [0]);

            bool isInInv = CheckInventar (ChoosenItem, hero);

            if (isInInv == false) {
            } else {
                Console.WriteLine ("You can't carry more of those Items.");
            }
        }

        #endregion
    }
}



