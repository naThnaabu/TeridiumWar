using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class FeuerDrache : Character
    {
        public FeuerDrache()
        {
            CurrentHealth = 30;
            MaxHealth = 30;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 15;
            Defense = 12;
            Experience = 55;
            Gold = 13;
            Identifier = "Fire Dragon";
            isAlive = true;
            AttackDamage = 11;

            Print = @"
       \(______     ______)/
       /`.----.\   /.----.`\
      } /      :} {:      \ {
     / {        } {        } \ 
     } }      ) } { (      { {
    / {      /|\}!{/|\      } \
    } }     ( (.""^"".) )     { {
   / {       (d\   /b)       } \
   } }       |\~   ~/|       { {
  / /        | )   ( |        \ \
 { {        _)(,   ,)(_        } }
 } }      //  `"";""`  \\      { {
 / /      //     (     \\      \ \
{ {      {(     -=)     )}      } }
 \ \     /)    -=(=-     (\    / /
  `\\  /'/    /-=|\-\    \`\  //'
   `\{  |   ( -===- )   |  }/'
     `  _\   \-===-/   /_  '
        (_(_(_)'-=-'(_)_)_)
       `""`""`""       ""`""`""`" + "\n";
        }

/*
        void PrintMonster()
        {
            Console.Write(@"
             \(______     ______)/
             /`.----.\   /.----.`\
            } /      :} {:      \ {
           / {        } {        } \ 
           } }      ) } { (      { {
          / {      /|\}!{/|\      } \
          } }     ( (.""^"".) )     { {
         / {       (d\   /b)       } \
         } }       |\~   ~/|       { {
        / /        | )   ( |        \ \
       { {        _)(,   ,)(_        } }
        } }      //  `"";""`  \\      { {
       / /      //     (     \\      \ \
      { {      {(     -=)     )}      } }
       \ \     /)    -=(=-     (\    / /
        `\\  /'/    /-=|\-\    \`\  //'
          `\{  |   ( -===- )   |  }/'
            `  _\   \-===-/   /_  '
              (_(_(_)'-=-'(_)_)_)
              `""`""`""       ""`""`""`
    ");"*/
    }
}
