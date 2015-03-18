using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Zentaur : Character
    {
        public Zentaur()
        {
            CurrentHealth = 19;
            MaxHealth = 19;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 10;
            Defense = 9;
            Experience = 29;
            Gold = 7;
            Identifier = "Zentaur";
            isAlive = true;
            AttackDamage = 6;
            Print = @"
                 __
                / _\ #
                \c /  #
                / \___ #
                \`----`#==>  
                |  \  #
     ,%.-""""""---'`--'\#_
    %%/             |__`\
   .%'\     |   \   /  //
   ,%' >   .'----\ |  [/
      < <<`       ||
       `\\\       ||
         )\\      )\
 ^^^^^^^^""""""^^^^^^""""^^^^^
" + "\n";
        }
    }
}
