using libTeridium.Items;
using libTeridium.Items.Weapon;
using System.Collections.Generic;


namespace libTeridium.Characters
{
    public class Hero
    {
        public Item head{ get; set; }

        public Item shoulders{ get; set; }

        public Item arms{ get; set; }

        public Item hands{ get; set; }

        public Item chest{ get; set; }

        public Item legs{ get; set; }

        public Item knees{ get; set; }

        public Item feet{ get; set; }

        public Weapon rightHand{ get; set; }

        public Weapon leftHand{ get; set; }

        public List<Item> inventory{ get; set; }

        public Money gold{ get; set; }
    }
}
