using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldServer.Game.WorldEntities;
using Framework.Constants.ItemSettings;

namespace WorldServer.Game.WorldEntities.Inventory
{
    public class Bag : List<Item>
    {
        public int CurrItemCount { get { return this.Count; } }
        public byte BagSlot { get; set; }
        public byte MaxitemCount { get; set; }//todo read from Item

        public InventoryResult Split(byte srcSlot, byte dstSlot, byte Amount)
        {
            Item srcItem = null;
            Item dstItem = null;

            GetItem(srcSlot,out srcItem);
            GetItem(dstSlot, out dstItem);
            if (srcItem == null)
            {
                return InventoryResult.EQUIP_ERR_ITEM_NOT_FOUND;
            }
            else if(dstItem == null)
            {
                return InventoryResult.EQUIP_ERR_ITEM_NOT_FOUND_2;
            }
      // Here was last rest shit later
            return InventoryResult.EQUIP_ERR_OK;

        }
     
        public InventoryResult GetItem(int Slot,out Item pItem,bool incklBank = false)
        {
            //todo Check with Bank
            pItem = null;
            if (this[Slot] == null)
                return InventoryResult.EQUIP_ERR_ITEM_NOT_FOUND;

            pItem = this[Slot];

            return InventoryResult.EQUIP_ERR_OK;

        }

    }
}
