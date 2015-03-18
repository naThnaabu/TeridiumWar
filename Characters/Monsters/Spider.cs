using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Spider : Character
    {
        public Spider()
        {
            CurrentHealth = 15;
            MaxHealth = 15;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 8;
            Defense = 7;
            Experience = 18;
            Gold = 6;
            Identifier = "Spider";
            isAlive = true;
            AttackDamage = 4;
            Print = @"
             ||
             ||
             ||
             ||
             ||
             ||
       _ /\  ||  /\ _
      / X  \.--./  X \
     /_/ \/`    `\/ \_\
    /|(`-/\_/)(\_/\-`)|\
   ( |` (_(.oOOo.)_) `| )
   ` |  `//\(  )/\\`  | `
     (  // ()\/() \\  )
      ` (   \   /   ) `
         \         /        
          `       `
" + "\n";
        }
    }
}
