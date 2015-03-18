using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Character
    {
        #region Variables
        public int CurrentHealth, MaxHealth, CurrentMagic;
        public int MaxMagic, Attack, Defense;
        public int Experience, AttackDamage;
        public int AnzLittleHPPotions, AnzMiddleHPPotions, AnzBigHPPotions, AnzLittleMPPotions, AnzMiddleMPPotions, AnzBigMPPotions;
        public string Identifier, Print;
        public bool isAlive;
        public double Gold;
        #endregion

        public Character()
        {

        }

        #region functions
        public void PrintMonster()
        {

        }
        #endregion
    }
    

}
