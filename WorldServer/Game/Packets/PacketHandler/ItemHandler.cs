using System;
using Framework.Constants;
using Framework.Logging;
using Framework.Network.Packets;
using WorldServer.Game.WorldEntities;
using WorldServer.Network;
using WorldServer.Game.Spawns;
using Framework.ObjectDefines;

namespace WorldServer.Game.Packets.PacketHandler
{
    public class ItemHandler
    {
        #region unhandelt handler
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
        #endregion
        #region Vendors

        [Opcode(ClientMessage.BuyItem, "16357")]
        public static void HandleByItem(ref PacketReader packet, ref WorldClass session)
        {
        
    
        }
        [Opcode(ClientMessage.VendorTabeList, "16357")]
        public static void HandleVendorTabeList(ref PacketReader packet, ref WorldClass session)
        {
            ulong targetGuid = packet.ReadUInt64();
            if (targetGuid == session.Character.TargetGuid)
            {
        HighGuidType  lol = Framework.ObjectDefines.ObjectGuid.GetGuidType(targetGuid);
          ulong odd =      ObjectGuid.GetGuid(targetGuid);
              CreatureSpawn spawn =  Globals.SpawnMgr.FindSpawn(targetGuid);
              Creature  npc = spawn.Creature;
            
                  PacketWriter Inventory = new PacketWriter(JAMCMessage.VendorInventory);
                  BitPack ss = new BitPack(Inventory);
                  Inventory.WriteInt8(0x01);//client expects counting to start at 1??
                byte[] count = {00,10,00};//count dat bitstream fortmat unkown
                Inventory.WriteBytes(count, 3);
         /*Item1*/
                Inventory.WriteInt8(11);//slot
                Inventory.WriteInt32(0xFFF010);//left ub stock?
                  ss.Flush(); 
                 string ssss = "00 00 0C 34 00 00 0C 10 00 00 00 10 00 00 05 30 00 00 03 C0 00 00 00 10 00 00 0C 74 00 00 00 B0 E0 00 0F FF FF FF F0 00 00 00 00 20 00 00 00 10 00 00 02 80 00 00 01 40 00 00 00 10 00 00 0C 44 00 00 0C 20 00 00 0F FF FF FF F0 00 00 00 00 30 00 00 00 10 00 00 05 30 00 00 02 D0 00 00 00 10 00 00 0C 64 00 00 0C 30 00 00 0F FF FF FF F0 00 00 00 00 40 00 00 00 10 00 00 03 E0 00 00 01 E0 00 00 00 10 00 00 0C 84 00 00 00 C0 E0 00 0F FF FF FF F0 00 00 00 00 50 00 00 00 10 00 00 02 80 00 00 01 40 00 00 00 10 00 00 0C 54 00 00 0C 70 20 00 0F FF FF FF F0 00 00 00 00 60 00 00 00 10 00 00 02 C0 00 00 01 40 00 00 00 10 00 00 0F 34 10 00 05 50 00 00 0F FF FF FF F0 00 00 00 00 70 00 00 00 10 00 00 05 50 00 00 03 C0 00 00 00 10 00 00 06 B3 80 00 02 B0 70 00 0F FF FF FF F0 00 00 00 00 80 00 00 00 10 00 00 02 B0 00 00 01 40 00 00 00 10 00 00 0F 44 20 00 0D 10 00 00 0F FF FF FF F0 00 00 00 00 90 00 00 00 10 00 00 05 20 00 00 02 D0 00 00 00 10 00 00 06 C3 80 00 0D 20 00 00 0F FF FF FF F0 00 00 00 00 A0 00 00 00 10 00 00 03 D0 00 00 01 E0 00 00 00 10 00 00 0A 93 70 00 02 C0 70 00 0F FF FF FF F0 00 00 00 00 B0 00 00 00 10 00 00 02 B0 00 00 01 40 00 00 00 10 00 00 06 D3 80 00 0C A0 20 00 0F FF FF FF F0 00 00 00 00 C0 00 00 00 10 00 00 02 C0 00 00 01 40 00 00 05 99 CF 03 10 D9 C0";
                  string[] all = ssss.Split(' ');
            
                //  int gu = int.Parse(all[0] + " " + all[1] + " " + all[2] + " " + all[3], System.Globalization.NumberStyles.HexNumber);
                  foreach (string a in all)
                  {
                      byte test = byte.Parse(a, System.Globalization.NumberStyles.HexNumber);
                      Inventory.WriteUInt8(test);
                  }
                  
                 /* Inventory.WriteGuid(121332123);
                   Item ii = npc.Data.VendorItems[0];

                   Inventory.WriteUInt32(1);       // client expects counting to start at 1
                   Inventory.WriteUInt32(1); // unk 4.0.1 always 1
                   Inventory.WriteUInt32((uint)71634);
                   Inventory.WriteUInt32((uint)69314);
                   Inventory.WriteUInt32(0xFFFFFFFF);//left in stcok
                   Inventory.WriteUInt32(1);
                   Inventory.WriteUInt32(0);
                   Inventory.WriteUInt32(1);
                   Inventory.WriteUInt32(0);
                   Inventory.WriteInt8(0); ;*/
                  // unk 4.0.1
                 session.Send(ref Inventory);
              
              Console.WriteLine(npc.Data.NpcFlags);
            }
          //  Globals.WorldMgr.
        }
        public static byte[] StringtoByteArray(string arr)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetBytes(arr);
        }
        #endregion
    }
}
