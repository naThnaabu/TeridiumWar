using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class StoneGolem : Character
    {
        public StoneGolem()
        {
            CurrentHealth = 20;
            MaxHealth = 20;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 9;
            Experience = 10;
            Gold = 13;
            Identifier = "Stone Golem";
            isAlive = true;
            AttackDamage = 8;
            Print = @"

" + "\n";
        }
    }
}
