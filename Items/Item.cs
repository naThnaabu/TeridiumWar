using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    public class Item
    {
        #region Variables
		public string Type { get; set; }
		public string Identifier { get; set; }
		public int Price { get; set; }
		public int InvStaple { get; set; }
		public int InvCanHave { get; set; }
        #endregion

        public Item()
        {

        }
    }
}
