using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class WolfDeamon : Character
    {
        public WolfDeamon()
        {
            CurrentHealth = 26;
            MaxHealth = 26;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 13;
            Defense = 13;
            Experience = 44;
            Gold = 13;
            Identifier = "Wolf Daemon";
            isAlive = true;
            AttackDamage = 9;
            Print = @"
                ,
        |\     ____
        \ \.-./ .-' T
         \ _  _( /| | |\
       ) | .)(./ |  |  |
         |   \(   \_|_/
     (   |     \    |
    )    |  \VvV    | (
         |  |\,,\   | 
       ) |  | ^^^   |    )
      (  |  |__     |   (
    )   /      `-. _|    )
   (   /          /  `\
      /          ///_ |
     /          (((-|'
                 ```|
" + "\n";
        }


    }
}
