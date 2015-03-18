using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Fireball:Spell
    {
        public Fireball()
        {
            base.identifier = "Fireball";
            base.multipleHits = true;            
            base.power = 9;
            base.magicCost = 15;
            base.fire = true;
        }

        public override int SpellCast(Character Caster)
        {
            Console.WriteLine("{0} casts a Fireball...,", Caster.Identifier);
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
                Console.WriteLine("Fireball hits the target and does {0} HP of fire damage.", power);
            }
            return power;
        }
    }
}
