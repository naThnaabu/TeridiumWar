using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace TeridiumRPG
{
    class Shop
    {
        #region Variables
        public bool EnoughGold = false;
        #endregion

        public Shop(Hero hero)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string shopchoice = "";
            string shopanswer = "";
            ConsoleKeyInfo shopanswerKey;
            do
            {

                shopchoice = PrintShopChoice(hero);
                ProcessShopChoice(shopchoice, hero);
                hero.CalculateArmorValue();
                Console.Clear();
                Console.Write(@"Your Profile
*******************************************************
Name: {0}
Weapon: {1}Damage: {12}     W6: {13}
Helmetvalue: {3}Helmet: {2}         
Armvalue: {5}Arm: {4}            
Chestvalue: {7}Chest: {6}          
Legvalue: {9}Leg: {8}            
Shoesvlaue: {11}Shoes: {10}         
Armor: {14}


*******************************************************
", hero.Identifier, hero.weapon.PadRight(20, ' '), hero.helmetname, hero.helmet.ToString().PadRight(15, ' '), hero.armname, hero.arm.ToString().PadRight(18, ' '), hero.chestname, hero.chest.ToString().PadRight(16, ' '), hero.legname, hero.leg.ToString().PadRight(18, ' '), hero.shouename, hero.shoue.ToString().PadRight(16, ' '), hero.AttackDamage.ToString().PadRight(3, ' '), hero.AnzW6, hero.ArmorValue);
                Console.WriteLine("Are you finished with your purchase?\n(Y)es\n(N)o\n");
                shopanswerKey = Console.ReadKey(true);
                shopanswer = shopanswerKey.KeyChar.ToString();
            }
            while (shopanswer == "n" || shopanswer == "N");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #region Display and process shopcontent
        public static string PrintShopChoice(Hero hero)
        {
            Console.Clear();
            Console.Write(@"Welcome to our Shop {0}.
 
   |\                     /)
 /\_\\__               (_//
|   `>\-`     _._       //`)
 \ /` \\  _.-`:::`-._  //
  `    \|`    :::    `|/
        |     :::     |
        |.....:::.....|
        |:::::::::::::|
        |     :::     |
        \     :::     /
         \    :::    /
          `-. ::: .-'
           //`:::`\\
          //   '   \\
         |/         \\
", hero.Identifier);
            Console.WriteLine("\n\n");
            Console.Write(@"What would you like to buy?:
***********************
(A)rmor
(W)eapon
(D)rinks
(S)ell
(E)xit


Your Money: {0}
***********************", hero.Gold);
            Console.WriteLine();
            ConsoleKeyInfo shopchoiceKey;
            shopchoiceKey = Console.ReadKey(true);
            string shopchoice = shopchoiceKey.KeyChar.ToString();
            return shopchoice;
        }

        public void ProcessShopChoice(string shopchoice, Hero hero)
        {
            switch (shopchoice)
            {
                case "A":
                case "a":
                    PrintArmor(hero);
                    break;

                case "W":
                case "w":
                    PrintWeapon(hero);
                    break;

                case "D":
                case "d":
                    PrintPotion(hero);
                    break;

                case "S":
                case "s":
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
                            PrintSellFromInventory(hero, hero.WeaponInventar);
                            break;

                        case "A":
                        case "a":
                            PrintSellFromInventory(hero, hero.ArmorInventar);
                            break;

                        case "I":
                        case "i":
                            PrintSellFromInventory(hero, hero.Inventar);
                            break;

                        case "E":
                        case "e":
                            return;

                        default:
                            PrintShopChoice(hero);
                            break;
                    }
                    #endregion
                    break;

                case "E":
                case "e":
                    Console.WriteLine("Exit");
                    return;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    shopchoice = PrintShopChoice(hero);
                    ProcessShopChoice(shopchoice, hero);
                    break;
            }
        }
        #endregion

        #region Print shop content
        public void PrintArmor(Hero hero)
        {
            Console.Clear();
            ConsoleKeyInfo armorcatchoice;
            Console.Write(@"From which category would you like to buy?
                   {}
                  .--.
                 /.--.\
                 |====|
                 |`::`|
             .-;`\..../`;_.-^-._
      /\\   /  |...::..|`   :   `|
      |:'\ |   /'''::''|   .:.   |
     @|\ /\;-,/\   ::  |..:::::..|
     `||\ <` >  >._::_.| ':::::' |
      || `""`   /   ^^ |   ':'   |
      ||       |       \    :    /
      ||       |        \   :   / 
      ||       |___/\___|`-.:.-`
      ||        \_ || _/    `
      ||        <_ >< _>
      ||        |  ||  |
      ||        |  ||  |
      ||       _\.:||:./_
      \/      /____/\____\
**************************************
(H)elmets
(C)hest
(L)eg
(S)hoes
(A)rms
(E)xit
**************************************");
            Console.WriteLine();

            armorcatchoice = Console.ReadKey(true);

            switch (armorcatchoice.KeyChar)
            {
                case 'A':
                case 'a':
                    Console.Clear();
                    PrintArmGuards(hero);
                    break;

                case 'C':
                case 'c':
                    Console.Clear();
                    PrintChestArmor(hero);
                    break;

                case 'H':
                case 'h':
                    Console.Clear();
                    PrintHelmets(hero);
                    break;

                case 'L':
                case 'l':
                    Console.Clear();
                    PrintLegArmor(hero);
                    break;

                case 'S':
                case 's':
                    Console.Clear();
                    PrintShoes(hero);
                    break;

                case 'E':
                case 'e':
                    Console.WriteLine("Exit");
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintArmor(hero);
                    break;
            }
        }

        public void PrintWeapon(Hero hero)
        {
            Console.Clear();
            ConsoleKeyInfo weaponcatchoice;
            Console.Write(@"What would you like to buy?:
***********************
(S)words
(M)aces
(B)ows
(E)xit


Your Money: {0}
***********************", hero.Gold);
            weaponcatchoice = Console.ReadKey(true);

            switch (weaponcatchoice.KeyChar)
            {
                case 'S':
                case 's':
                    Console.Clear();
                    PrintSwords(hero);
                    break;

                case 'B':
                case 'b':
                    Console.Clear();
                    PrintBows(hero);
                    break;

                case 'M':
                case 'm':
                    Console.Clear();
                    PrintMaces(hero);
                    break;

                case 'E':
                case 'e':
                    Console.Clear();
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintWeapon(hero);
                    break;
            }
        }
        #endregion

        #region ShopItems

        #region Potions
        public void PrintPotion(Hero hero)
        {
            Console.Clear();
            ConsoleKeyInfo potionchoiceKey;
            string potionchoice = "";
            Console.Write(@"Which Potion would you like to buy?

  :~:      :~:      :~:
 .'~`.     | |      | |
:     :   .' `.    .' `.   .-.
|     | .'     `. ;     ; .'~`.
|     | |       | |     | |   |
`.....'  `.._..'  `.___.' |___|

*********************************************
        Name           HP/MP-restor   Price
(1)Little HP Potion          5         10
(2)Middle HP Potion          8         15
(3)Big HP Potion             12        19
(4)Little MP Potion          7         8
(5)Middle MP Potion          10        12
(6)Big MP Potion             14        15
(E)xit

Your Gold: {0}
*********************************************", hero.Gold);
            Console.WriteLine();
            potionchoiceKey = Console.ReadKey(true);
            potionchoice = potionchoiceKey.KeyChar.ToString();
            ProcesPotionBuy(potionchoice, hero);
        }

        public void ProcesPotionBuy(string potionchoice, Hero hero)
        {
            #region Creation of all potions
            HP_little_potion litteHP = new HP_little_potion();
            HP_middle_potion middleHP = new HP_middle_potion();
            HP_big_potion bigHP = new HP_big_potion();
            MP_little_potion litteMP = new MP_little_potion();
            MP_middle_potion middleMP = new MP_middle_potion();
            MP_big_potion bigMP = new MP_big_potion();
            #endregion

            switch (potionchoice)
            {
                case "1":
                    #region little HP potion
                    EnoughGold = CheckHeroGold(litteHP.Price, hero);
                    if (EnoughGold == true)
                    {
                        if (hero.AnzLittleHPPotions < 10)
                        {
                            hero.AnzLittleHPPotions += 1;
                            hero.Gold -= litteHP.Price;
                            Console.WriteLine("You bought: " + litteHP.Identifier + " for " + litteHP.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                            hero.Inventar.Add("Little HP potion;3.50");
                        }
                        else
                        {
                            Console.WriteLine("You can't have more than 10 of those\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    #endregion
                    break;

                case "2":
                    #region Middle HP potion
                    EnoughGold = CheckHeroGold(middleHP.Price, hero);
                    if (EnoughGold == true)
                    {
                        if (hero.AnzMiddleHPPotions < 10)
                        {
                            hero.AnzMiddleHPPotions += 1;
                            hero.Gold -= middleHP.Price;
                            Console.WriteLine("You bought: " + middleHP.Identifier + " for " + middleHP.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                            hero.Inventar.Add("Middle HP potion;5.00");
                        }
                        else
                        {
                            Console.WriteLine("You can't have more than 10 of those\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    #endregion
                    break;

                case "3":
                    #region Big HP potion
                    EnoughGold = CheckHeroGold(bigHP.Price, hero);
                    if (EnoughGold == true)
                    {
                        if (hero.AnzBigHPPotions < 10)
                        {
                            hero.AnzBigHPPotions += 1;
                            hero.Gold -= litteMP.Price;
                            Console.WriteLine("You bought: " + bigHP.Identifier + " for " + bigHP.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                            hero.Inventar.Add("Big HP potion;6.50");
                        }
                        else
                        {
                            Console.WriteLine("You can't have more than 10 of those\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    #endregion
                    break;

                case "4":
                    #region little MP potion
                    EnoughGold = CheckHeroGold(litteMP.Price, hero);
                    if (EnoughGold == true)
                    {
                        if (hero.AnzLittleMPPotions < 10)
                        {
                            hero.AnzLittleMPPotions += 1;
                            hero.Gold -= litteMP.Price;
                            Console.WriteLine("You bought: " + litteMP.Identifier + " for " + litteMP.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                            hero.Inventar.Add("Little MP potion;3.50");
                        }
                        else
                        {
                            Console.WriteLine("You can't have more than 10 of those\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    #endregion
                    break;

                case "5":
                    #region middle MP potion
                    EnoughGold = CheckHeroGold(middleMP.Price, hero);
                    if (EnoughGold == true)
                    {
                        if (hero.AnzMiddleMPPotions < 10)
                        {
                            hero.AnzMiddleMPPotions += 1;
                            hero.Gold -= middleMP.Price;
                            Console.WriteLine("You bought: " + middleMP.Identifier + " for " + middleMP.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                            hero.Inventar.Add("Middle MP potion;5.00");
                        }
                        else
                        {
                            Console.WriteLine("You can't have more than 10 of those\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    #endregion
                    break;


                case "6":
                    #region Big MP potion
                    EnoughGold = CheckHeroGold(bigMP.Price, hero);
                    if (EnoughGold == true)
                    {
                        if (hero.AnzBigMPPotions < 10)
                        {
                            hero.AnzBigMPPotions += 1;
                            hero.Gold -= bigMP.Price;
                            Console.WriteLine("You bought: " + bigMP.Identifier + " for " + bigMP.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                            hero.Inventar.Add("Big MP potion;6.50");
                        }
                        else
                        {
                            Console.WriteLine("You can't have more than 10 of those\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    #endregion
                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintShoes(hero);
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        #endregion

        #region Armor
        #region Schoes
        public void PrintShoes(Hero hero)
        {
            Console.Clear();
            ArmorShoe schoes = new ArmorShoe();
            ConsoleKeyInfo shoechoiceKey;
            string shoechoice = "";
            Console.Write(@"Please choose a pair of Shoes:
                     _    _
                    (_\__/(,_
                    | \ `_////-._
                    L_/__ ""=> __/`\
      (_\__/(,_     |=====;__/___./
      | \ `_////-._ '-'-'-""""""""""""`
      J_/___""=> __/`\
      |=====;__/___./
      '-'-'-""""""""""""""`
***************************************
        Name            Armor   Price
(1)Shoes of might         1       10
(2)Shoes of the King      2       15
(3)Shoes of truth         4       19
(E)xit

Your Gold: {0}
***************************************", hero.Gold);
            Console.WriteLine();
            shoechoiceKey = Console.ReadKey(true);
            shoechoice = shoechoiceKey.KeyChar.ToString();
            ProcesShoeBuy(shoechoice, schoes, hero);
        }

        public void ProcesShoeBuy(string shoechoice, ArmorShoe shoes, Hero hero)
        {
            switch (shoechoice)
            {
                case "1":
                    shoes.Identifier = "Shoes of Might";
                    shoes.Price = 10;
                    EnoughGold = CheckHeroGold(shoes.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(shoes.Identifier + ";" + "3;0" + ";foot");
                        hero.Gold -= shoes.Price;
                        Console.WriteLine("You bought: " + shoes.Identifier + " for " + shoes.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "2":
                    shoes.Identifier = "Shoes of the King";
                    shoes.Price = 15;
                    EnoughGold = CheckHeroGold(shoes.Price, hero);
                    if (EnoughGold == true)
                    {

                        hero.ArmorInventar.Add(shoes.Identifier + ";" + "5;2" + ";foot");
                        hero.Gold -= shoes.Price;
                        Console.WriteLine("You bought: " + shoes.Identifier + " for " + shoes.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "3":
                    shoes.Identifier = "Shoes of the truth";
                    shoes.Price = 19;
                    EnoughGold = CheckHeroGold(shoes.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(shoes.Identifier + ";" + "7;4" + ";foot");
                        hero.Gold -= shoes.Price;
                        Console.WriteLine("You bought: " + shoes.Identifier + " for " + shoes.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintShoes(hero);
                    break;
            }
        }
        #endregion

        #region LegArmor
        public void PrintLegArmor(Hero hero)
        {
            Console.Clear();
            ArmorLeg armorleg = new ArmorLeg();
            ConsoleKeyInfo legchoiceKey;
            string legchoice = "";
            Console.Write(@"Please choose a pair of Trouser:

                 ,==c==.
                 |_/|\_|
                 | '|` |
                 |  |  |
                 |  |  |
                 |__|__|

***************************************
        Name            Armor   Price
(1)Trouser of might       1       10
(2)Trouser of the King    2       15
(3)Trouser of truth       4       19
(E)xit

Your Gold: {0}
***************************************", hero.Gold);
            Console.WriteLine();
            legchoiceKey = Console.ReadKey(true);
            legchoice = legchoiceKey.KeyChar.ToString();
            ProcesLegArmorBuy(legchoice, armorleg, hero);
        }

        public void ProcesLegArmorBuy(string legchoice, ArmorLeg armorleg, Hero hero)
        {
            switch (legchoice)
            {
                case "1":
                    armorleg.Identifier = "Trousers of Might";
                    armorleg.Price = 10;
                    EnoughGold = CheckHeroGold(armorleg.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorleg.Identifier + ";" + "3;1" + ";leg");
                        hero.Gold -= armorleg.Price;
                        Console.WriteLine("You bought: " + armorleg.Identifier + " for " + armorleg.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "2":
                    armorleg.Identifier = "Trousers of the King";
                    armorleg.Price = 15;
                    EnoughGold = CheckHeroGold(armorleg.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorleg.Identifier + ";" + "5;2" + ";leg");
                        hero.Gold -= armorleg.Price;
                        Console.WriteLine("You bought: " + armorleg.Identifier + " for " + armorleg.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "3":
                    armorleg.Identifier = "Trousers of the truth";
                    armorleg.Price = 19;
                    EnoughGold = CheckHeroGold(armorleg.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorleg.Identifier + ";" + "7;4" + ";leg");
                        hero.Gold -= armorleg.Price;
                        Console.WriteLine("You bought: " + armorleg.Identifier + " for " + armorleg.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintLegArmor(hero);
                    break;
            }
        }
        #endregion

        #region ChestArmor
        public void PrintChestArmor(Hero hero)
        {
            Console.Clear();
            ArmorChest armorchest = new ArmorChest();
            ConsoleKeyInfo chestchoiceKey;
            string chestchoice = "";
            Console.Write(@"Please choose a Chest armor to buy:

                 __,-=-.__
               .'  \   /  `.
              /__|  `-'  |__\
                  )     (
                  |     |   
                  |_____|

****************************************
        Name              Armor  Price
(1)Chest armor of might      1       10
(2)Chest armor of the King   2       15
(3)Chest armor of truth      4       19
(E)xit

Your Gold: {0}
****************************************", hero.Gold);
            Console.WriteLine();
            chestchoiceKey = Console.ReadKey(true);
            chestchoice = chestchoiceKey.KeyChar.ToString();
            ProcesChestArmorBuy(chestchoice, armorchest, hero);
        }

        public void ProcesChestArmorBuy(string chestchoice, ArmorChest armorchest, Hero hero)
        {
            switch (chestchoice)
            {
                case "1":
                    armorchest.Identifier = "Chest of Might";
                    armorchest.Price = 10;
                    EnoughGold = CheckHeroGold(armorchest.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorchest.Identifier + ";" + "3;0" + ";chest");
                        hero.Gold -= armorchest.Price;
                        Console.WriteLine("You bought: " + armorchest.Identifier + " for " + armorchest.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");

                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "2":
                    armorchest.Identifier = "Chest of the King";

                    armorchest.Price = 15;
                    EnoughGold = CheckHeroGold(armorchest.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorchest.Identifier + ";" + "5;2" + ";chest");
                        hero.Gold -= armorchest.Price;
                        Console.WriteLine("You bought: " + armorchest.Identifier + " for " + armorchest.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "3":
                    armorchest.Identifier = "Chest of the truth";

                    armorchest.Price = 19;
                    EnoughGold = CheckHeroGold(armorchest.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorchest.Identifier + ";" + "7;4" + ";chest");
                        hero.Gold -= armorchest.Price;
                        Console.WriteLine("You bought: " + armorchest.Identifier + " for " + armorchest.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintChestArmor(hero);
                    break;
            }
        }
        #endregion

        #region arm guards
        public void PrintArmGuards(Hero hero)
        {
            Console.Clear();
            ArmorArm armorarm = new ArmorArm();
            ConsoleKeyInfo armchoiceKey;
            string armchoice = "";
            Console.Write(@"Please choose a Arm guard to buy:
****************************************
        Name              Armor   Price
(1)Arm guard of might        1       10
(2)Arm guard of the King     2       15
(3)Arm guard of truth        4       19
(E)xit

Your Gold: {0}
****************************************", hero.Gold);
            Console.WriteLine();
            armchoiceKey = Console.ReadKey(true);
            armchoice = armchoiceKey.KeyChar.ToString();
            ProcessArmGuardsBuy(armchoice, armorarm, hero);
        }

        public void ProcessArmGuardsBuy(string armchoice, ArmorArm armorarm, Hero hero)
        {
            switch (armchoice)
            {
                case "1":
                    armorarm.Identifier = "Arm guard of Might";
                    armorarm.Price = 10;
                    EnoughGold = CheckHeroGold(armorarm.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorarm.Identifier + ";" + "3;1" + ";arm");
                        hero.Gold -= armorarm.Price;
                        Console.WriteLine("You bought: " + armorarm.Identifier + " for " + armorarm.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "2":
                    armorarm.Identifier = "Arm guard of the King";

                    armorarm.Price = 15;
                    EnoughGold = CheckHeroGold(armorarm.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorarm.Identifier + ";" + "6;2" + ";arm");
                        hero.Gold -= armorarm.Price;
                        Console.WriteLine("You bought: " + armorarm.Identifier + " for " + armorarm.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "3":
                    armorarm.Identifier = "Arm guard of the truth";

                    armorarm.Price = 19;
                    EnoughGold = CheckHeroGold(armorarm.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorarm.Identifier + ";" + "7;4" + ";arm");
                        hero.Gold -= armorarm.Price;
                        Console.WriteLine("You bought: " + armorarm.Identifier + " for " + armorarm.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintArmGuards(hero);
                    break;
            }
        }
        #endregion

        #region helmets
        public void PrintHelmets(Hero hero)
        {
            Console.Clear();
            ArmorHelmet armorhelmet = new ArmorHelmet();

            ConsoleKeyInfo helmetchoiceKey;
            string helmetchoice = "";
            Console.Write(@"Please choose ea Helmet to buy:
                   _
                ,''/., _
        `.-._\`/. ( //'/'`.
      _.-`-. ``' ` `(   -. \
    ,'  ,    ,-:._ _..-.. \/
   / ,'/ ,`.( _.'-'.     )/
   `.\ '(   ,'      `.
      `._\ /'       \ \
          /:         \ \-.
        ,;':._______...-'_)
        \:/-.._______..-_|
         : :\   `----'|'-;
          \ :\    : : ;:/
           \ ``.   ; /;/
            )   `.  /,'
          ,'      `-' \
         /  .--.       )
        /_.---._`._   /
                `.__.'
*************************************
        Name           Armor   Price
(1)Helmet of might       1       10
(2)Helmet of the King    2       15
(3)Helmet of truth       4       19
(E)xit

Your Gold: {0}
*************************************", hero.Gold);
            Console.WriteLine();
            helmetchoiceKey = Console.ReadKey(true);
            helmetchoice = helmetchoiceKey.KeyChar.ToString();
            ProcessHelmetBuy(helmetchoice, armorhelmet, hero);
        }
        public void ProcessHelmetBuy(string helmethoice, ArmorHelmet armorhelmet, Hero hero)
        {
            switch (helmethoice)
            {
                case "1":
                    armorhelmet.Identifier = "Helmet of Might";
                    armorhelmet.Price = 10;
                    EnoughGold = CheckHeroGold(armorhelmet.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorhelmet.Identifier + ";" + "3;1" + ";helmet");
                        hero.Gold -= armorhelmet.Price;
                        Console.WriteLine("You bought: " + armorhelmet.Identifier + " for " + armorhelmet.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "2":
                    armorhelmet.Identifier = "Helmet of the King";

                    armorhelmet.Price = 15;
                    EnoughGold = CheckHeroGold(armorhelmet.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.ArmorInventar.Add(armorhelmet.Identifier + ";" + "6;2" + ";helmet");
                        hero.Gold -= armorhelmet.Price;
                        Console.WriteLine("You bought: " + armorhelmet.Identifier + " for " + armorhelmet.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "3":
                    armorhelmet.Identifier = "Helmet of the truth";
                    armorhelmet.Price = 19;
                    EnoughGold = CheckHeroGold(armorhelmet.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.helmetname = armorhelmet.Identifier;
                        hero.ArmorInventar.Add(armorhelmet.Identifier + ";" + "7;4" + ";chest");
                        hero.Gold -= armorhelmet.Price;
                        Console.WriteLine("You bought: " + armorhelmet.Identifier + " for " + armorhelmet.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintHelmets(hero);
                    break;
            }
        }
        #endregion
        #endregion

        #region weapons
        #region swords
        public void PrintSwords(Hero hero)
        {
            Console.Clear();
            Sword sword = new Sword();
            ConsoleKeyInfo swordchoiceKey;
            string swordchoice = "";
            Console.Write(@"Please choose a Sword to buy:

              (@|
 ,,           ,)|_____________________________________
//\\8@8@8@8@8@8 / _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ \
\\//8@8@8@8@8@8 \_____________________________________/
 ``           `)|
              (@| 

***************************************************
        Name           W6Damage    Damage   Price
(1)Sword of might          1          3       10
(2)Sword of the King       1          4       15
(3)Sword of truth          2          0       19
(E)xit

Your Gold: {0}
***************************************************", hero.Gold);
            Console.WriteLine();
            swordchoiceKey = Console.ReadKey(true);
            swordchoice = swordchoiceKey.KeyChar.ToString();
            ProcessSwordBuy(swordchoice, sword, hero);
        }

        public void ProcessSwordBuy(string swordchoice, Sword sword, Hero hero)
        {
            switch (swordchoice)
            {
                case "1":
                    sword.Identifier = "Sword of Might";
                    sword.Price = 10;
                    EnoughGold = CheckHeroGold(sword.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(sword.Identifier + ";" + "3;1;1");
                        hero.Gold -= sword.Price;
                        Console.WriteLine("You bought: " + sword.Identifier + " for " + sword.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }
                    break;

                case "2":
                    sword.Identifier = "Sword of the King";
                    sword.Price = 15;
                    EnoughGold = CheckHeroGold(sword.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(sword.Identifier + ";" + "6;1;4");
                        hero.Gold -= sword.Price;
                        Console.WriteLine("You bought: " + sword.Identifier + " for " + sword.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "3":
                    sword.Identifier = "Sword of the truth";
                    sword.Price = 19;
                    EnoughGold = CheckHeroGold(sword.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(sword.Identifier + ";" + "7;2;0");
                        hero.Gold -= sword.Price;
                        Console.WriteLine("You bought: " + sword.Identifier + " for " + sword.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintSwords(hero);
                    break;
            }
        }
        #endregion

        #region maces
        public void PrintMaces(Hero hero)
        {
            Console.Clear();
            Mace mace = new Mace();
            ConsoleKeyInfo macechoiceKey;
            string macechoice = "";
            Console.Write(@"Please choose a Mace to buy:

               <<()>>
                )__(
                )__(
                )__(
                )__(
                )__(
                )__(
                )__(
                )__(
                )__(
               _)__(_
             .'      `.
             | <   >  |>
            <|   <   >|
              `.____.'
                V  V

***************************************************
        Name           W6Damage    Damage   Price
(1)Mace of might          1          3       10
(2)Mace of the King       1          4       15
(3)Mace of truth          2          0       19
(E)xit

Your Gold: {0}
***************************************************", hero.Gold);
            Console.WriteLine();
            macechoiceKey = Console.ReadKey(true);
            macechoice = macechoiceKey.KeyChar.ToString();
            ProcessMaceBuy(macechoice, mace, hero);
        }

        public void ProcessMaceBuy(string macechoice, Mace mace, Hero hero)
        {
            switch (macechoice)
            {
                case "1":
                    mace.Identifier = "Mace of Might";
                    mace.Price = 10;
                    EnoughGold = CheckHeroGold(mace.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(mace.Identifier + ";" + "3;1;1");
                        hero.Gold -= mace.Price;
                        Console.WriteLine("You bought: " + mace.Identifier + " for " + mace.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "2":
                    mace.Identifier = "Mace of the King";

                    mace.Price = 10;
                    mace.Price = 15;
                    EnoughGold = CheckHeroGold(mace.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(mace.Identifier + ";" + "3;1;4");
                        hero.Gold -= mace.Price;
                        Console.WriteLine("You bought: " + mace.Identifier + " for " + mace.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "3":
                    mace.Identifier = "Mace of the truth";
                    mace.Price = 19;
                    EnoughGold = CheckHeroGold(mace.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(mace.Identifier + ";" + "3;2;0");
                        hero.Gold -= mace.Price;
                        Console.WriteLine("You bought: " + mace.Identifier + " for " + mace.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;

                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintMaces(hero);
                    break;
            }
        }
        #endregion

        #region bows
        public void PrintBows(Hero hero)
        {
            Console.Clear();
            Bow bow = new Bow();
            ConsoleKeyInfo bowchocieKey;
            string bowchoice = "";
            Console.Write(@"Please choose a Bow:

             '$$-.                              
              4   "".                                        
              4    ^.                                       
              4     $                                       
              4     'b                                      
              4      ""b.                                    
              4        $                                    
              4        $r                                   
              4        $F                                   
   -$b========4========$b====*P=-                           
              4       *$$F                                  
              4        $$""                                  
              4       .$F                                   
              4       dP                                    
              4      F                                       
              4     @                                       
              4    .                                        
              J  .""                                           
              $$'  
***************************************************
        Name           W6Damage    Damage   Price
(1)Bow of might          1          3       10
(2)Bow of the King       1          4       15
(3)Bow of truth          2          0       19
(E)xit

Your Gold: {0}
***************************************************", hero.Gold);
            Console.WriteLine();
            bowchocieKey = Console.ReadKey(true);
            bowchoice = bowchocieKey.KeyChar.ToString();
            ProcessBowBuy(bowchoice, bow, hero);
        }

        public void ProcessBowBuy(string bowchoice, Bow bow, Hero hero)
        {
            switch (bowchoice)
            {
                case "1":
                    bow.Identifier = "Bow of Might";

                    bow.Price = 10;
                    EnoughGold = CheckHeroGold(bow.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(bow.Identifier + ";" + "3;1;1");
                        hero.Gold -= bow.Price;
                        Console.WriteLine("You bought: " + bow.Identifier + " for " + bow.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "2":
                    bow.Identifier = "Bow of the King";

                    bow.Price = 15;
                    EnoughGold = CheckHeroGold(bow.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(bow.Identifier + ";" + "3;1;4");
                        hero.Gold -= bow.Price;
                        Console.WriteLine("You bought: " + bow.Identifier + " for " + bow.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "3":
                    bow.Identifier = "Bow of the truth";

                    bow.Price = 19;
                    EnoughGold = CheckHeroGold(bow.Price, hero);
                    if (EnoughGold == true)
                    {
                        hero.WeaponInventar.Add(bow.Identifier + ";" + "3;2;0");
                        hero.Gold -= bow.Price;
                        Console.WriteLine("You bought: " + bow.Identifier + " for " + bow.Price + " Gold.\nYou have now " + hero.Gold + " Gold left.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough Gold.\n");
                    }

                    break;

                case "e":
                case "E":
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("\nI'm sorry that wasn't a valid choice.\n");
                    PrintBows(hero);
                    break;
            }
        }
        #endregion
        #endregion

        #endregion

        #region HeroInventar and HeroGold
        public bool CheckHeroGold(int Gold, Hero hero)
        {
            bool HeroGold = false;

            if (hero.Gold >= Gold)
            {
                HeroGold = true;
            }
            return HeroGold;
        }

        void PrintSellFromInventory(Hero hero, List<string> list)
        {
            Console.Clear();
            Console.Write(@"**************************************************************
What would you like to sell?
Nr.                    Name                 Own       Price
--------------------------------------------------------------
");
            HeroDataHandler datahandler = new HeroDataHandler();
            datahandler.Save(hero, true);
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
            Console.WriteLine("--------------------------------------------------------------\n(E)xit");
            Console.WriteLine("**************************************************************\n");
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
            Console.Write(@"Are you sure that you want to sell {0}?
(Y)es
(N)o
", soutput[0]);
            sellchoiceKey = Console.ReadKey(true);
            sellchoice = sellchoiceKey.KeyChar.ToString();
            switch (sellchoice)
            {
                case "Y":
                case "y":
                    list.RemoveAt(isellchoice);
                    double subGold = Convert.ToDouble(soutput[1]);
                    hero.Gold += subGold;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                default:
                    PrintShopChoice(hero);
                    break;
            }
        }
        #endregion
    }
}
