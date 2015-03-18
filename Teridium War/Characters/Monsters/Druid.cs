using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Druid : Character
    {
        public Druid()
        {
            CurrentHealth = 13;
            MaxHealth = 13;
            CurrentMagic = 25;
            MaxMagic = 25;
            Attack = 7;
            Defense = 6;
            Experience = 46;
            Gold = 13;
            Identifier = "Druid";
            isAlive = true;
            AttackDamage = 3;
            Print = @"          
              _,._      
  .||,       /_ _\\     
 \.`',/      |'L'| |    
 = ,. =      | -,| L    
 / || \    ,-'\""/,'`.   
   ||     ,'   `,,. `.  
   ,|____,' , ,;' \| |  
  (3|\    _/|/'   _| |  
   ||/,-''  | >-'' _,\\ 
   ||'      ==\ ,-'  ,' 
   ||       |  V \ ,|   
   ||       |    |` |   
   ||       |    |   \  
   ||       |    \    \ 
   ||       |     |    \
   ||       |      \_,-'
   ||       |___,,--"")_\
   ||         |_|   ccc/
   ||        ccc/   
" + "\n";
        }
    }
}
