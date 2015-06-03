using System;
using System.Collections.Generic;
using System.Text;

namespace libTeridium.Magic
{
    public class Spell
    {
        public String name{ get; set; }

        public MagicType aspect{ get; set; }

        public int strength{ get; set; }

        public double areaOfEffect{ get; set; }

        public SpellType spellType{ get; set; }

        public CastType castType{ get; set; }

        public int range{ get; set; }
    }
}
