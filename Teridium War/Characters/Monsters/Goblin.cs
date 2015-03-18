using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Goblin : Character
    {
        public Goblin()
        {
            CurrentHealth = 12;
            MaxHealth = 12;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 6;
            Defense = 6;
            Experience = 32;
            Gold = 8;
            Identifier = "Goblin";
            isAlive = true;
            AttackDamage = 3;
            Print = @"
       __ __
    .-',,^,,'.
   / \(0)(0)/ \
   )/( ,_""_,)\(
   `  >-`~(   '
 _N\ |(`\ |___
 \' |/ \ \/_-,)
  '.(  \`\_<
     \ _\|
      | |_\_
      \_,_>-
" + "\n";
        }
    }
}
