using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Heal_little : Spell
    {
        public Heal_little()
        {
            base.identifier = "Heal";
            base.isOnSelf = true;
            base.power = 7;
            base.magicCost = 15;
            base.light = true;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts a little heal Spell,", Caster.Identifier);
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("and heals {0}HP", power);
            }
            return power;
        }
    }
}
