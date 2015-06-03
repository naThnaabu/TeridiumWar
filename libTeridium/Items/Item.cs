using System;
using System.Collections.Generic;
using System.Text;

namespace libTeridium.Items
{
    public class Item
    {
        private const String[] RarityColors = { "#606860", "#F0F0F0", "#00FF00", "#000080", "#8028E0", "#FF4500", "#F5F5DC", "#FFB6C1", "#FFC0CB" };

        public String description{ get; set; }

        public String name{ get; set; }

        public Rarity rarity{ get; set; }

        public int stackSize{ get; set; }

        public ItemType type{ get; set; }

        public int weigth{ get; set; }

        public String rarityColor()
        {
			
        }

        public bool stackAble()
        {
			
        }
    }
}
