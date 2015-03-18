using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Mummy : Character
    {
        public Mummy()
        {
            CurrentHealth = 20;
            MaxHealth = 20;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 11;
            Experience = 44;
            Gold = 12;
            Identifier = "Mummy";
            isAlive = true;
            AttackDamage = 5;
            Print = @"
          .--.       
         |_\/_\   _  
         |___=(  ( /)
        / \___/   \'.  
     ___\/_|_|_____)_\       
    (__\__\ \/ /_\_\_/        
     \_| \ \/ // | |            
     _\|  | \/ | |/            
    (_\/  |\/ /\                 
          / \/ /\               
         / \/_/ /\               
        / \/   \ /\            
       | \/     './)             
      /_|        |_|             
      |_|        \_|         
    __/__''._____/__''.__
" + "\n";
        }
    }
}
