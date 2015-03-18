using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Minotauer :Character
    {
        public Minotauer()
        {
            CurrentHealth = 23;
            MaxHealth = 23;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 12;
            Defense = 11;
            Experience = 31;
            Gold = 9;
            Identifier = "Minotaur";
            isAlive = true;
            AttackDamage = 8;
            Print = @"
       -""""\
    .-""  .`)     (
   j   .'_+     :[                )      .^--..
  i    -""       |l                ].    /      i
 ,"" .:j         `8o  _,,+.,.--,   d|   `:::;    b
 i  :'|          ""88p;.  (-.""_""-.oP        \.   :
 ; .  (            >,%%%   f),):8""          \:'  i
i  :: j          ,;%%%:; ; ; i:%%%.,        i.   `.
i  `: ( ____  ,-::::::' ::j  [:```          [8:   )
<  ..``'::::8888oooooo.  :(jj(,;,,,         [8::  <
`. ``:.      oo.8888888888:;%%%8o.::.+888+o.:`:'  |
 `.   `        `o`88888888b`%%%%%88< Y888P""'-    ;
   ""`---`.       Y`888888888;;.,""888b.""""..::::'-'
          ""-....  b`8888888:::::.`8888._::-""
             `:::. `:::::O:::::::.`%%'|
              `.      ""``::::::''    .'
                `.                   <
                  +:         `:   -';
                   `:         : .::/
                    ;+_  :::. :..;;;       
                    ;;;;,;;;;;;;;,;;
" + "\n";
        }
    }
}
