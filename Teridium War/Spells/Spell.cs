using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Spell
    {
        public int power;
        public int magicCost;
        public bool multipleHits, singleTarget, isOnSelf;
        public bool fire, ice, lightning, light, water;
        public string identifier;

        public Spell()
        {
            multipleHits = false;
            singleTarget = false;
            isOnSelf = false;
            fire = false;
            ice = false;
            water = false;
            lightning = false;
            light = false;
        }
        public virtual int SpellCast(Character caster)
        {
            return power;
        }


    }
}
