using System;
using Framework.Constants;
using Framework.Logging;
using Framework.Network.Packets;
using WorldServer.Game.WorldEntities;
using WorldServer.Network;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class ItemHandler
    {
        [Opcode(ClientMessage.ItemNameQuery, "16357")]
        public static void HandleItemItemNameQuery(ref PacketReader packet, ref WorldClass session)
        {
            uint itemID = packet.ReadUInt32();//this from old structure

            Item pItem = Globals.ItemMgr.FindData(itemID);

            if (pItem != null)
            {
                SendItemNameQueryResponse(session,pItem);
            }
        }

        public static void SendItemNameQueryResponse(WorldClass session, Item pItem)
        {
            // todo get find data & opcodes
        }

        [Opcode(ClientMessage.AutoEquipItem, "16357")]
        public static void HandleAutoEquip(ref PacketReader packet, ref WorldClass session)
        {
           //todo
        }
        [Opcode(ClientMessage.DestroyItem, "16357")]
        public static void HandleDestroyItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.UseItem, "16357")]
        public static void HandleUseItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }


        [Opcode(ClientMessage.OpenItem, "16357")]
        public static void HandleOpenItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.SwapInvItem, "16357")]
        public static void HandleSwapInvItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.SwapItem, "16357")]
        public static void HandleSwapItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.AutoStoreBagItem, "16357")]
        public static void HandleAutoStoreBagItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.SetAmmo, "16357")]
        public static void HandleSetAmmo(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.SplitItem, "16357")]
        public static void HandleSplitItem(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.SocketGems, "16357")]
        public static void HandleSocketGems(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.ItemQuerySingle, "16357")]
        public static void HandleItemQuerySingle(ref PacketReader packet, ref WorldClass session)
        {
       //   uint ItemID =  packet.ReadUInt32();
            //todo
        }

        [Opcode(ClientMessage.SetEquiptmentSet, "16357")]
        public static void HandleSetEquiptmentSet(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }

        [Opcode(ClientMessage.UseEquiptmentSet,"16357")]
        public static void HandleUseEquiptmentSet(ref PacketReader packet, ref WorldClass session)
        {
            //todo
        }


    }
}
