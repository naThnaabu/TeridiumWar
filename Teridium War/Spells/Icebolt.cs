using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Icebolt : Spell
    {
        public Icebolt()
        {
            base.identifier = "Icebolt";
            base.power = 8;
            base.singleTarget = true;
            base.magicCost = 12;
            base.ice = true;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts an Icebolt,", Caster.Identifier);
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
                Console.WriteLine("Icebolt hits the target and does {0} HP of ice damage.", power);
            }
            return power;
        }
    }
}
