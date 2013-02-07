using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Constants.ItemSettings;
using WorldServer.Game.WorldEntities;

namespace WorldServer.Game.WorldEntities.Inventory
{
    public class PlayerInventory : ConcurrentDictionary<int,Bag>
    {
        public Character Owner { get; private set; }
       public int MaxInventorySlots { get { return GetMaxItemCount(); } }


        public PlayerInventory(Character pOwner)
        {
            this.Owner = pOwner;
            this.TryAdd(0, new Bag
                {
                   MaxitemCount = 16,//default inventory
                });
        }
        public InventoryResult TryAddBag(Bag BagContainer)
        {
            InventoryResult InterarctResult;
            CheckInteract(out InterarctResult);
            if (InterarctResult != InventoryResult.EQUIP_ERR_OK)
                return InterarctResult;

            byte newBagSlot;
            if (!GetFreeFreeBagSlot(out newBagSlot))
                return InventoryResult.EQUIP_ERR_INTERNAL_BAG_ERROR;//corectly erors code???

            if (!this.TryAdd(newBagSlot, BagContainer))
                return InventoryResult.EQUIP_ERR_INTERNAL_BAG_ERROR_2;//corectly??

            BagContainer.BagSlot = newBagSlot;
           
            return InventoryResult.EQUIP_ERR_OK;
        }

        private int GetMaxItemCount()
        {
            int Count = 0;
            foreach (Bag Value in this.Values)
            {
                Count += Value.MaxitemCount;
            }
            return Count;
        }

        public InventoryResult TryRemoveBag(Bag BagContainer)
        {
            InventoryResult InterarctResult;
            CheckInteract(out InterarctResult);
            if (InterarctResult != InventoryResult.EQUIP_ERR_OK)
                return InterarctResult;

            if (BagContainer.CurrItemCount != 0)
                return InventoryResult.EQUIP_ERR_BAG_FULL;

            Bag Remove;
            if (!this.TryRemove(BagContainer.BagSlot, out Remove))
                return InventoryResult.EQUIP_ERR_WRONG_BAG_TYPE; // todo find right eror code

            return InventoryResult.EQUIP_ERR_OK;
        }

        public bool GetBagContainer(byte pSlot, out Bag Container)
        {
            Container = null;
            if (!this.TryGetValue((int)pSlot, out Container))
                return false;

            return true;
        }

        public bool GetFreeFreeBagSlot(out byte pSlot)
        {
            pSlot = 0;
            IEnumerable<int> Range = Enumerable.Range(0, 4);
            var freeKeys = Range.Except(this.Keys);
            if (freeKeys.Count() == 0)
                return false;

            pSlot = (byte)freeKeys.First();
            return true;
        }
        public InventoryResult TrySwap(byte srcBagSlot, byte srcSlot, byte dstBagSlot, byte dstSlot)
        {
            Item SrcItem = null;
            Item dstItem = null;
            if(!GetItemFromInventory(srcSlot,srcBagSlot,out SrcItem))
            {
                return InventoryResult.EQUIP_ERR_ITEM_NOT_FOUND;
            }
            else if (!GetItemFromInventory(dstSlot, dstBagSlot, out dstItem))
            {
                return InventoryResult.EQUIP_ERR_ITEM_NOT_FOUND_2;
            }
            else
            {
                if (SrcItem == null)
                {
                   return InventoryResult.EQUIP_ERR_SLOT_EMPTY;
                }
                else if (dstItem == null)
                {
                    return InventoryResult.EQUIP_ERR_SLOT_EMPTY;
                }

                //cann not uses
                //Cant do right now
                //todo equip

            }
            return InventoryResult.EQUIP_ERR_OK;
        }
        public bool GetItemFromInventory(byte slot, byte BagSlot, out Item pItem)
        {
            pItem = null;

            if (this[BagSlot] == null)
                return false;

            pItem = this[BagSlot][slot];

            return true;
        }
        private void CheckInteract(out InventoryResult Result)
        {
            if (!this.Owner.IsAlive)
            {
                Result = InventoryResult.EQUIP_ERR_PLAYER_DEAD;
            }

            //todo EQUIP_ERR_NOT_WHILE_DISARMED
            //	YOU_ARE_DEAD
            //and more
            Result = InventoryResult.EQUIP_ERR_OK;
        }
    }
}
