using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Gryphon : Character
    {
        public Gryphon()
        {
            CurrentHealth = 23;
            MaxHealth = 23;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 13;
            Defense = 10;
            Experience = 41;
            Gold = 11;
            Identifier = "Gryphon";
            isAlive = true;
            AttackDamage = 9;
            Print = @"
           _____,    _..-=-=-=-=-====--,
        _.'a   /  .-',___,..=--=--==-'`
       ( _     \ /  //___/-=---=----'
        ` `\    /  //---/--==----=-'
     ,-.    | / \_//-_.'==-==---='
    (.-.`\  | |'../-'=-=-=-=--'
     (' `\`\| //_|-\.`;-~````~,        _ 
          \ | \_,_,_\.'        \     .'_`\
           `\            ,    , \    || `\\
             \    /   _.--\    \ '._.'/  / |
             /  /`---'   \ \   |`'---'   \/
            / /'          \ ;-. \
         __/ /           __) \ ) `|
       ((='--;)         (,___/(,_/
" + "\n";
        }
    }
}
