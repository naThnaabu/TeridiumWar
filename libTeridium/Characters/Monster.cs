using System.Collections.Generic;
using libTeridium.Items;
using libTeridium;

namespace libTeridium.Characters;
{
    public class Monster
    {
        public List<Item> loot{ get; set; }

        public Money gold{ get; set; }
    }
}
