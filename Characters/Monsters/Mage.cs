using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Mage : Character
    {
         public Mage()
        {
            CurrentHealth = 18;
            MaxHealth = 18;
            CurrentMagic = 30;
            MaxMagic = 30;
            Attack = 8;
            Defense = 8;
            Experience = 63;
            Gold = 16;
            Identifier = "Mage";
            isAlive = true;
            AttackDamage = 4;
            Print = @"          
                        /\
                       /  \
                      |    |
                    --:'''':--
                      :'_' :
                      _:"":\___
       ' '      ____.' :::     '._
      . *=====<<=)           \    :
      .  '      '-'-'\_      /'._.'
                      \====:_ ""
                     .'     \\
                     :       :
                    /   :    \
                   :   .      '.
                   :  : :      :
                   :__:-:__.;--'
                   '-'   '-'
" + "\n";
        }
    }
}
