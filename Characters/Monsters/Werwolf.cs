using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Werwolf : Character
    {
        public Werwolf()
        {
            CurrentHealth = 25;
            MaxHealth = 25;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 13;
            Defense = 12;
            Experience = 40;
            Gold = 9;
            Identifier = "Werewolf";
            isAlive = true;
            AttackDamage = 9;
            Print = @"
              ___
             ///~`     |\\_                   
            ,  |='  ,))\_| ~-_                   
           / ,' ,;((((((    ~ \           
         /' -~/~)))))))'\_   _/'       
        (       (((((( ~-/ ~-/                       
         ~~--|   ))''    ')  `                           
             :        (_  ~\           ,              
              \        \_   )--__  /(_/)              
    ___       |_     \__/~-__    ~~   ,'      
  //~~\`\    /' ~~~----|     ~~~~~~~~'       
((()   `\`\_(_     _-~~-\                    
 )))     ~----'   /      \                       
  (         ;`~--'        :                           
            |    `\       |                             
            |    /'`\     ;                         
           /~   /    |    )                        
          |    /     / | /                         
          /   /     |  \\|                        
        _/  /'       \  \_)               
       ( )|'         (~-_|                  
        ) `\_         |-_;;--__              
        `----'       (   `~--_ ~~~
                     `~~~~~~~~'~~~
" + "\n";
        }
    }
}
