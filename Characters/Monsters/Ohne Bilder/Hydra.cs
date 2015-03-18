using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Hydra : Character
    {
        public Hydra()
        {
            CurrentHealth = 25;
            MaxHealth = 25;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 10;
            Defense = 10;
            Experience = 15;
            Gold = 16;
            Identifier = "Hyra";
            isAlive = true;
            AttackDamage = 9;
            Print = @"

" + "\n";
        }
    }
}
