using System;
using System.Collections.Generic;
using System.Text;

namespace libTeridium.Characters
{
    public class Character
    {
        public int currentHealth { get; set; }

        public int maxHealth{ get; set; }

        public int maxMana{ get; set; }

        public int currentMana{ get; set; }

        public int attack{ get; set; }

        public int defense{ get; set; }

        public int experience{ get; set; }

        public int damage{ get; set; }

        public String id{ get; set; }
    }
}
