using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Warlock : Character
    {
        public Warlock()
        {
            CurrentHealth = 12;
            MaxHealth = 12;
            CurrentMagic = 40;
            MaxMagic = 40;
            Attack = 6;
            Defense = 6;
            Experience = 49;
            Gold = 13;
            Identifier = "Warlock";
            isAlive = true;
            AttackDamage = 2;
            Print = @"          

            ,    _
           /|   | |
         _/_\_  >_<
        .-\-/.   |
       /  | | \_ |
       \ \| |\__(/
       /(`---')  |
      / /     \  |
   _.'  \'-'  /  |
   `----'`=-='   '      
   
" + "\n";
        }
    }
}
