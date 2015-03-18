using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Harpye :Character
    {
        public Harpye()
        {
            CurrentHealth = 16;
            MaxHealth = 16;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 7;
            Experience = 33;
            Gold = 9;
            Identifier = "Harpy";
            isAlive = true;
            AttackDamage = 5;
            Print = @"
         ,                                      ,
        |\                                      /|
     ,   \'._ ,                           ,  _.'/   ,
     |\  {'. '-`\,      ,-._**_.-,      ,/`-' .'}  /|
      \`'-'-.  '.`\      \*____*/      /`.'  .-'-'`/
    ,'-'-._  '.  ) )     /`    `\     ( (  .'  _.-'-',
    |\'- _ '.   , /     /  /""\  \     \ ,  .'  _ -'/|
     \'-.   .  ; (      \_|^  ^|_/      ) ;   .  .-'/
      `'--, . ;  {`-.      \__/      .-'}  ; . ,--'`
      '--`_. ;  { ^  \    _|  |_    /  ^ }  ; ._`--'
      `,_.--  ;  { ^  `-'`      `'-`  ^ }  ;  --._,`
        ,_.-    ; {^    /        \    ^} ;    -._, 
         ,_.-`), /\{^,/\\_'_/\_'_//\,^}/\ ,(`-._,
           _.'.-` /.'   \        /   `.\ `-.'._
          `  _.' `       \      /       ` '._   `
                        .-'.  .'-.
                      .'    `` ^  '.
                     /  ^ ^   ^  ^  \
                     | ^    ^   ^   |
                    /^   ^/    \  ^  \
                    \,_^_/    ^ \_,^./
                     /=/  \^   /  \=\
                 __ /=/_   | ^|   _\=\ __
               <(=,'=(==,) |  | (,==)=',=)>
                 /_/|_\    /  \    /_|\_\
                 `V (=|  .'    '.  |=) V`
                     V  / _/  \_ \  V
                       `""` \  / `""`
                            \(
" + "\n";
        }
    }
}
