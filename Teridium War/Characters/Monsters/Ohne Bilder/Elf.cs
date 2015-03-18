using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Elf : Character
    {
        public Elf()
        {
            CurrentHealth = 17;
            MaxHealth = 17;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 9;
            Experience = 9;
            Gold = 13;
            Identifier = "Elf";
            isAlive = true;
            AttackDamage = 7;
            Print = (@"

");
        }
    }
}
