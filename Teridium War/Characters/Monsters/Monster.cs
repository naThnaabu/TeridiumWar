using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Monster : Character
    {
        public Monster()
        {
            CurrentHealth = 10;
            MaxHealth = 10;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 5;
            Defense = 3;
            Experience = 5;
            Gold = 2;
            Identifier = "Monster";
            isAlive = true;
            AttackDamage = 5;
        }
    }
}
