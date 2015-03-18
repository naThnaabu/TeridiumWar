using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class HoelenBaer : Character
    {
        public HoelenBaer()
        {
            CurrentHealth = 16;
            MaxHealth = 16;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 7;
            Experience = 10;
            Gold = 2;
            Identifier = "Cave Bear";
            isAlive = true;
            AttackDamage = 5;
            Print = @"
     :""'._..---.._.'"";
     `.             .'
     .'             `.
    :      0   0      :                 __....._
    :     _.-0-._     :---'""""'""-....--'""        '.
     :  .'   :   `.  :                          `,`.
      `.: 'vv'vv' :.'                             ; ;
       : `.A`-'A.'                                ;.'
       `.   '""'                                   ;
        `.               '                        ;
         `.     `        :           `            ;
          .`.    ;       ;           :           ;
        .'    `-.'      ;            :          ;`.
    __.'      .'      .'              :        ;   `.
  .'      __.'      .'`--..__      _._.'      ;      ;
  `......'        .'         `'""""'`.'        ;......-'
        `.......-'                 `........'

" + "\n";
        }
    }
}
