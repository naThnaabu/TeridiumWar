using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class EchsenMensch : Character
    {
        public EchsenMensch()
        {
            CurrentHealth = 17;
            MaxHealth = 17;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 8;
            Experience = 43;
            Gold = 11;
            Identifier = "Lizardman";
            isAlive = true;
            AttackDamage = 5;
            Print = @"
                    ,
                -===>)))o
        /\      .   '| \
        ||     /(__  /~ )
      |_/\_|  ,~~  ~~-._|
       \()/  /~   /     \
        ||   >/-/~       |
        ||   "" (   .     |
        ||     (=-/      |
       (||\___/' /\_,  __(
        `--...__/  |-\\\\\\
        ||        /~~\||||;
        ||       /   |///|
        ||      /   /\   |
        ||     |__/'  \__\
        ||     ((((   (((((
        ||     )))))   )))))
        ||     (((((   (((((
        ||      | /     | /
        ||  __./' \_ _./' \_
        \/ ////~~~\_)/~~~~\_)
" + "\n";
        }
    }
}
