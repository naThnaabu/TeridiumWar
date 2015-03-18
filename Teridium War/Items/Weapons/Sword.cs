using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Sword : Item
    {
        public int Damage = 0;
        public int AnzW6 = 0;

        public Sword()
        {
            Type = "Sword";
            InvStaple = 1;
        }
    }
}
