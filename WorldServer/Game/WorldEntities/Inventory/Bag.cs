using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldServer.Game.WorldEntities;
namespace WorldServer.Game.WorldEntities.Inventory
{
    public class Bag : List<Item>
    {
        public int CurrItemCount { get { return this.Count; } }
        public byte BagSlot { get; set; }
    }
}
