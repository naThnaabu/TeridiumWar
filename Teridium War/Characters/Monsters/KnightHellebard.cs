using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class KnightHellebard : Character
    {
        public KnightHellebard()
        {
            CurrentHealth = 20;
            MaxHealth = 20;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 12;
            Defense = 8;
            Experience = 30;
            Gold = 7;
            Identifier = "Knight";
            isAlive = true;
            AttackDamage = 8;
            Print = @"
   ,   A           {}
  / \, | ,        .--.
 |    =|= >      /.--.\
  \ /` | `       |====|
   `   |         |`::`|
       |     .-;`\..../`;-.
      /\\/  /  |...::...|  \
      |:'\ |   /'''::'''\   |
       \ /\;-,/\   ::   /\--;
       |\ <` >  >._::_.<,<__>
       | `""`  /   ^^   \|  |
       |       |        |\::/
       |       |        |/|||
       |       |___/\___| '''
       |        \_ || _/
       |        <_ >< _>
       |        |  ||  |
       |        |  ||  |
       |       _\.:||:./_
       |      /____/\____\

" + "\n";
    }
    }
}
