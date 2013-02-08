/*
 * Copyright (C) 2012-2013 Arctium <http://arctium.org>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Console;
using WorldServer.Game.Packets.PacketHandler;
using WorldServer.Game.Spawns;
using WorldServer.Game.WorldEntities;
using WorldServer.Network;
using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;

namespace WorldServer.Game.Chat.Commands
{
    public class CreatureCommands : Globals
    {
        
        [ChatCommand("Item")]
        public static void Test2(string[] args, ref WorldClass session)
        {
            Item main = Globals.ItemMgr.FindData(32974);
            
        PacketWriter itemPushResult = new PacketWriter(JAMCMessage.ItemPushResult);
            BitPack BitPack = new BitPack(itemPushResult, session.Character.Guid);
 
            BitPack.Write(0);//loot
            BitPack.WriteGuidMask(7, 5, 4, 1, 3, 2, 6, 0);
            BitPack.Write(1);//is from creature
            BitPack.Write(0); // maybe... is created
 
            BitPack.Flush();
 
            itemPushResult.WriteInt32(0); // Unknown
            BitPack.WriteGuidBytes(0, 1);
            itemPushResult.WriteInt32(0); // Unknown
            BitPack.WriteGuidBytes(4);
            itemPushResult.WriteInt32(main.Data.RandomProperty); // Maybe...
            itemPushResult.WriteUInt8(1);
            itemPushResult.WriteInt32(0); // Unknown
            itemPushResult.WriteInt32(0); // Unknown
            itemPushResult.WriteInt32(0); // Unknown
            itemPushResult.WriteInt32(1); // Unknown
            BitPack.WriteGuidBytes(5, 7);
            itemPushResult.WriteInt32(main.Data.Id); // Unknown
            BitPack.WriteGuidBytes(2);
            itemPushResult.WriteInt32(1); // Unknown
            itemPushResult.WriteInt32((int)ContainerFields.Slots +2* 2); // -1 when added to stack
            BitPack.WriteGuidBytes(6, 3);
            session.Send(ref itemPushResult);
            
        }
        [ChatCommand("addnpc")]
        public static void AddNpc(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;

            int creatureId = CommandParser.Read<int>(args, 1);

            Creature creature = DataMgr.FindCreature(creatureId);
            if (creature != null)
            {
                CreatureSpawn spawn = new CreatureSpawn()
                {
                    Guid     = CreatureSpawn.GetLastGuid() + 1,
                    Id       = creatureId,
                    Creature = creature,
                    Position = pChar.Position,
                    Map      = pChar.Map
                };

                if (spawn.AddToDB())
                {
                    spawn.AddToWorld();
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Spawn successfully added.");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Spawn can't be added.");
            }
        }

        [ChatCommand("delnpc")]
        public static void DeleteNpc(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;
            var spawn = SpawnMgr.FindSpawn(pChar.TargetGuid);

            if (spawn != null)
            {
                SpawnMgr.RemoveSpawn(spawn);

                WorldMgr.SendToInRangeCharacter(pChar, ObjectHandler.HandleObjectDestroy(ref session, pChar.TargetGuid));
                ChatHandler.SendMessageByType(ref session, 0, 0, "Selected Spawn successfully removed.");
            }
            else
                ChatHandler.SendMessageByType(ref session, 0, 0, "Not a creature.");
        }
    }
}
