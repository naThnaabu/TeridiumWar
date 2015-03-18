using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Riesenratte : Character
    {
        public Riesenratte()
        {
            CurrentHealth = 10;
            MaxHealth = 10;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 6;
            Defense = 5;
            Experience = 21;
            Gold = 5;
            Identifier = "Giant Rat";
            isAlive = true;
            AttackDamage = 2;
            Print = @"
        (\,/)
         oo   '''//,        _
       ,/_;~,        \,    / '
       ""'   \    (    \    !
             ',|  \    |__.'
              '~  '~----''
" + "\n";
        }
    }
}
