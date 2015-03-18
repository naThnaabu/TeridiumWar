using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Lindworm : Character
    {
        public Lindworm()
        {
            CurrentHealth = 28;
            MaxHealth = 28;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 10;
            Defense = 10;
            Experience = 6;
            Gold = 8;
            Identifier = "Lindworm";
            isAlive = true;
            AttackDamage = 9;
            Print = @"

" + "\n";
        }
    }
}
