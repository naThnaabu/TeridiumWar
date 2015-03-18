using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Troll: Character
    {
        public Troll()
        {            
            CurrentHealth = 25;
            MaxHealth = 25;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 14;
            Defense = 11;
            Experience = 44;
            Gold = 12;
            Identifier = "Troll";
            isAlive = true;
            AttackDamage = 10;
            Print = @"
                   (    )
                  ((((()))
                  |o\ /o)|
                  ( (  _')
                   (._.  /\__
                  ,\___,/ '  ')
    '.,_,,       (  .- .   .    )
     \   \\     ( '        )(    )
      \   \\    \.  _.__ ____( .  |
       \  /\\   .(   .'  /\  '.  )
        \(  \\.-' ( /    \/    \)
         '  ()) _'.-|/\/\/\/\/\|
             '\\ .( |\/\/\/\/\/|
               '((  \    /\    /
               ((((  '.__\/__.')
                ((,) /   ((()   )
                 ""..-,  (()(""   /
                  _//.   ((() .""
          _____ //,/"" ___ ((( ', ___
                           ((  )
                            / /
                          _/,/'
                        /,/,""
" + "\n";
        }
    }
}
