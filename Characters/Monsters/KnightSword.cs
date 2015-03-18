using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class KnightSword : Character
    {
        public KnightSword()
        {
            CurrentHealth = 20;
            MaxHealth = 20;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 11;
            Experience = 32;
            Gold = 8;
            Identifier = "Knight";
            isAlive = true;
            AttackDamage = 5;
            Print = @"
   |\             //
    \\           _!_
     \\         /___\
      \\        [+++] 
       \\    _ _\^^^/_ _
        \\/ (    '-'  ( )
        /( \/ | {&}   /\ \
          \  / \     / _> )
           ""`   >:::;-'`""""'-.
               /:::/         \
              /  /||   {&}   |
             (  / (\         /
             / /   \'-.___.-'
           _/ /     \ \
          /___|    /___|
" + "\n";
        }
    }
}
