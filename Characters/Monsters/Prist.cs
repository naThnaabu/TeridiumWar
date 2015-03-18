using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Prist : Character
    {
        public Prist()
        {
            CurrentHealth = 16;
            MaxHealth = 16;
            CurrentMagic = 35;
            MaxMagic = 35;
            Attack = 7;
            Defense = 7;
            Experience = 48;
            Gold = 12;
            Identifier = "Prist";
            isAlive = true;
            AttackDamage = 3;
            Print = @"          
       ,='""`````""'=,
      ;    .-=-.    ;
      ',  /=====\  ,'
        ""=|/""""""\|=""
           \^ ^/ 
          / '-' \
         /   _   \
        /   /|\   \
       | \_/ | \_/ |
       |   |/ \|   |
        \__|   |__/
         |       |
         |       |
         |       |
         |       |
         |       |
         |'.'.'.'|
         '.'.'.'.'
" + "\n";
        }
    }
}
