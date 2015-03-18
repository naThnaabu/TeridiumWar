using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Wolf :Character
    {
        public Wolf()
        {
            CurrentHealth = 12;
            MaxHealth = 12;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 6;
            Defense = 6;
            Experience = 11;
            Gold = 3;
            Identifier = "Wolf";
            isAlive = true;
            AttackDamage = 2;
            Print = @"
                          ,     ,
                          |\---/|
                         /  , , |
                    __.-'|  / \ /
           __ ___.-'        ._O|
        .-'  '        :      _/
       / ,    .        .     |
      :  ;    :        :   _/
      |  |   .'     __:   /
      |  :   /'----'| \  |
      \  |\  |      | /| |
       '.'| /       || \ |
       | /|.'       '.l \\_
        || ||             '-'
       '-''-'
" + "\n";
        }
    }
}
