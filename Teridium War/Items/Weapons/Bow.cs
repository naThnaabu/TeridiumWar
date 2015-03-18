using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Bow : Item
    {
        public int Damage = 0;
        public int AnzW6 = 0;

        public Bow()
        {
            Type = "Bow";
            InvStaple = 1;
        }
    }
}
