using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Tiger: Character
    {
        public Tiger()
        {
            CurrentHealth = 13;
            MaxHealth = 13;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 7;
            Defense = 6;
            Experience = 10;
            Gold = 2;
            Identifier = "Tiger";
            isAlive = true;
            AttackDamage = 3;
            Print = @"
                         __,,,,_
          _ __..-;''`--/'/ /.',-`-.
      (`/' ` |  \ \ \\ / / / / .-'/`,_
     /'`\ \   |  \ | \| // // / -.,/_,'-,
    /<7' ;  \ \  | ; ||/ /| | \/    |`-/,/-.,_,/')
   /  _.-, `,-\,__|  _-| / \ \/|_/  |    '-/.;.\'
   `-`  f/ ;      / __/ \__ `/ |__/ |
        `-'      |  -| =|\_  \  |-' |
              __/   /_..-' `  ),'  //
             ((__.-'((___..-'' \__.'
" + "\n";
        }
    }
}
