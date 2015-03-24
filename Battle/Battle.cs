using System;
using System.Collections.Generic;
using TeridiumRPG.Characters;
using TeridiumRPG.Items.Potions;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Reflection.Emit;
using System.IO;
using System.Threading;

namespace TeridiumRPG
{
    class Battle
    {

        int round;
        List<string> BattleLog;
        readonly string[] attackoptions =
            {
                "Attack",
                "Spell",
                "Potions"
            };
        Hero hero;
        Character monster;
        const string stars = "********************************";

        public Battle()
        {
            BattleLog = new List<string>();
        }

        public Hero Fight(Hero hero, Character monster)
        {
            round = 0;
            this.hero = hero;
            this.monster = monster;
            while (this.hero.isAlive() && this.monster.isAlive())
            {
                round++;
                bool choose = true;
                while (choose)
                {
                    var choice = RenderBattleScreen();
                    BattleLog = new List<string>();
                    switch (choice)
                    {
                        case 0:
                            Roll2Hit();
                            choose = false;
                            break;
                    
                        case 1:
                            Roll2Hit(true);
                            choose = false;
                            break;

                        case 2:
                            DrinkPotion();
                            choose = false;
                            break;

                        default:
                            choose = true;
                            break;
                    }
                }
                CounterAttack();
            }
            if (!this.hero.isAlive())
            {
                RenderBattleScreen(false);
                RenderDeathScene();
            }
            else if (!this.monster.isAlive())
            {
                RenderBattleScreen(false);
                RolltoLoot();
            }
            Console.ReadKey();
            return this.hero;
        }

        public void ResetBattle()
        {
            BattleLog = new List<string>();
            monster = null;
            hero = null;
        }

        private int RenderBattleScreen(bool waitForInput = true)
        {
            Console.Clear();
            Console.WriteLine(monster.Print);
            Console.Write(@"
            Round {0}
**********************************            
{1}         {8}
HP: {2}/{3}      HP: {9}/{10}
MP: {4}/{5}      MP: {11}/{12}
AT: {6}          AT: {13}   
PT: {7}          PT: {14}     
**********************************", 
                round, 
                hero.Identifier, 
                hero.CurrentHealth, 
                hero.MaxHealth, 
                hero.CurrentMagic, 
                hero.MaxMagic, 
                hero.Attack, 
                hero.Defense,
                monster.Identifier, 
                monster.CurrentHealth, 
                monster.MaxHealth, 
                monster.CurrentMagic,
                monster.MaxMagic, 
                monster.Attack, 
                monster.Defense
            );
            Console.WriteLine(stars);
            foreach (string option in attackoptions)
            {
                string firstchar = option.Substring(0, 1);
                string lastpart = option.Substring(1, option.Length - 1);
                Console.WriteLine(@"({0}){1}", firstchar, lastpart);
            }
            Console.WriteLine(stars);
            RenderBattleLog();
            if (waitForInput)
            {
                ConsoleKeyInfo choiceKey = Console.ReadKey(true);
                string shopchoice = choiceKey.KeyChar.ToString().ToLower();
                for (int i = 0; i < attackoptions.Length; i++)
                {
                    string firstchar = attackoptions[i].Substring(0, 1).ToLower();
                    if (firstchar == shopchoice)
                        return i;
                }
                return 255;
            }
            return 255;
        }

        private void RenderBattleLog()
        {
            foreach (string logentry in BattleLog)
            {
                string[] logarr = logentry.Split(new char[] { ';' });
                string color = logarr[0];
                string Message = logarr[1];
                switch (color)
                {
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "magenta":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(Message);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void AddLogEntry(string color, string message)
        {
            BattleLog.Add(color + ";" + message);
        }

        private void Roll2Hit(bool isMagicAttack = false)
        {
            string logentry = "";
            if (!isMagicAttack)
            {
                logentry = String.Format("You attack the {0},", monster.Identifier);
                AddLogEntry("magenta", "Roll to Hit");
                if (RollW20() > hero.Attack)
                {
                    AddLogEntry("magenta", "Rolling against Monsters Defence");
                    if (RollW20() > monster.Defense)
                    {
                        int Damage = hero.AttackDamage;
                        for (int i = 0; i <= hero.AnzW6; i++)
                        {
                            AddLogEntry("magenta", "Roll for Damage");
                            Damage += RollW6();
                        }
                        monster.CurrentHealth -= Damage;
                        logentry += String.Format("it does {0} damage. The {1} is now at {2} health.", Damage, monster.Identifier, monster.CurrentHealth);
                    }
                    else
                    {
                        logentry += String.Format("but the {0} has sucsessfully blocked the attack.", monster.Identifier);
                    }
                }
                else
                {
                    logentry += "but you missed.";
                }
            }
            else
            {

            }
            AddLogEntry("white", logentry);
        }

        private void DrinkPotion()
        {

        }

        private void CounterAttack()
        {
            //Random rnd = new Random();
            //int KI = rnd.Next(0, 9);
            //string spell = "";
            /*if (monster.CurrentMagic >= 10 && KI <= 5)
            {
                //Console.WriteLine("The Mage begins to cast a Spell...");
                KI = rnd.Next(1, 4);
                if (monster.CurrentHealth <= monster.MaxHealth / 3)
                {
                    KI = 2;
                }
                switch (KI)
                {
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
                CastASpell(monster, hero, spell);
            }*/
            string logentry;
            logentry = String.Format("The {0} attacks you,", monster.Identifier);
            AddLogEntry("magenta", "Monser Rolls to Hit");
            if (RollW20() <= monster.Attack)
            {
                AddLogEntry("magenta", "Rolling against Heros Defence");
                if (RollW20() > hero.Defense)
                {
                    int Damage = monster.AttackDamage - hero.ArmorValue();
                    hero.CurrentHealth -= Damage;
                    logentry += String.Format("it does {0} damage. You have now {1} health.", Damage, hero.CurrentHealth);
                }
                else
                {
                    logentry += "but you have sucsessfully blocked the attack.";
                }
            }
            else
            {
                logentry += "but it missed.";
            }
            AddLogEntry("red", logentry);
        }

        private void RenderDeathScene()
        {
            Console.WriteLine(Game.LoadGameAsset("Battle/death.txt").ReadToEnd());
        }

        private void RenderVictoryScene()
        {
            Console.WriteLine(Game.LoadGameAsset("Battle/victory.txt").ReadToEnd());
        }

        private void RolltoLoot()
        {
            Console.WriteLine("You receive {0} Gold from killing the {1}", monster.Gold, monster.Identifier);
            hero.Gold += monster.Gold;
        }

        /* public static bool CastASpell(Character attacker, Character defender, string spellchoice)
        {
            bool spellcasted = true;
            Spell spell;

            //spell = ProcessTheSpellChoice(spellchoice, attacker);
            if (spell != null)
            {

                int spellpower = spell.SpellCast(attacker);
                if (spellpower != 0)
                {
                    if (spell.isOnSelf == true)
                    {
                        attacker.CurrentHealth += spellpower;
                        if (attacker.CurrentHealth > attacker.MaxHealth)
                        {
                            attacker.CurrentHealth = attacker.MaxHealth;
                        }
                    }
                    else if (spell.multipleHits == true)
                    {
                        defender.CurrentHealth -= spellpower;
                    }
                    else if (spell.singleTarget == true)
                    {
                        defender.CurrentHealth -= spellpower;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    spellcasted = true;

                }
                else
                {
                    spellcasted = false;
                }
            }
            else
            {
                spellcasted = false;
            }
            return spellcasted;
        }*/

        int RollW20()
        {
            int W20 = 0;
            int max = 20;
            int min = 1;
            W20 = Game.rand.Next(min, max);
            AddLogEntry("yellow", String.Format("Result is: {0}", W20));
            return W20;
        }

        int RollW6()
        {
            int W6 = 0;
            int max = 6;
            int min = 1;
            W6 = Game.rand.Next(min, max);
            AddLogEntry("yellow", String.Format("Result is: {0}", W6));
            return W6;
        }
    }
}



