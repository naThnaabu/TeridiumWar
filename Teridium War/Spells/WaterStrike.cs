using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class WaterStrike : Spell
    {
        public WaterStrike()
        {
            base.identifier = "Waterstrike";
            base.power = 7;
            base.singleTarget = true;
            base.magicCost = 10;
            base.water = true;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts a Waterstrike,", Caster.Identifier);
            System.Threading.Thread.Sleep(500);
            Caster.CurrentMagic -= magicCost;
            if (Caster.CurrentMagic < 0)
            {
                Caster.CurrentMagic += magicCost;
                Console.WriteLine("Not enough Magic Points"); 
                power = 0;
            }
            else if (Caster.CurrentMagic >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Waterstrike hits the target and does {0} HP of water damage.", power);
            }
            return power;
        }
    }
}
