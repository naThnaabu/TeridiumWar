using System;
using System.Collections.Generic;
using System.Text;

namespace libTeridium.Items.Weapon
{
    public class Weapon
    {
        public WeaponType weaponType{ get; set; }

        public HoldingType holdingType{ get; set; }

        public int attack{ get; set; }

        public int defense{ get; set; }

        public int damage{ get; set; }

        public bool armorPiercing{ get; set; }
    }
}
