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
        public Character Owner { get; set; }
       
        public PlayerInventory(Character pOwner)
        {
            this.Owner = pOwner;
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
