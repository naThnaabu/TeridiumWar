using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Mace : Item
    {
        public int Damage = 0;
        public int AnzW6 = 0;

        public Mace()
        {
            Type = "Mace";
            InvStaple = 1;
        }
    }
}
