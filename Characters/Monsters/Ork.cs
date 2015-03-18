using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Ork : Character
    {
        public Ork()
        {
            CurrentHealth = 20;
            MaxHealth = 20;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 10;
            Defense = 10;
            Experience = 30;
            Gold = 7;
            Identifier = "Ork";
            isAlive = true;
            AttackDamage = 6;
            Print = @"
             ,      ,   
            /(.-""-.)\
        |\  \/      \/  /|
        | \ / =.  .= \ / |
        \( \   o\/o   / )/
         \_, '-/  \-' ,_/
           /   \__/   \
           \,___/\___,/
         ___\ \|uu|/ /___
       /`    \ .--. /    `\
      /       '----'       \
" + "\n";
        }
    }
}
