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

using Framework.Database;
using Framework.Logging;
using Framework.ObjectDefines;
using Framework.Singleton;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WorldServer.Game.Spawns;
using WorldServer.Game.WorldEntities;
using System.Collections.Concurrent;

namespace WorldServer.Game.Managers
{
    public sealed class SpawnManager : SingletonBase<SpawnManager>
    {
<<<<<<< HEAD
        public ConcurrentDictionary<ulong, CreatureSpawn> CreatureSpawns;
        public ConcurrentDictionary<ulong, GameObjectSpawn> GameObjectSpawns;

        SpawnManager()
        {
            CreatureSpawns = new ConcurrentDictionary<ulong, CreatureSpawn>();
            GameObjectSpawns = new ConcurrentDictionary<ulong, GameObjectSpawn>();
=======
        public ConcurrentDictionary<CreatureSpawn, Creature> CreatureSpawns;
        public ConcurrentDictionary<GameObjectSpawn, GameObject> GameObjectSpawns;

        SpawnManager()
        {
            CreatureSpawns = new ConcurrentDictionary<CreatureSpawn, Creature>();
            GameObjectSpawns = new ConcurrentDictionary<GameObjectSpawn, GameObject>();
>>>>>>> 7d3525d847b762c4ba307be028d1559bd4a8b05d

            Initialize();
        }

        public void Initialize()
        {
            LoadCreatureSpawns();
            LoadGameObjectSpawns();
        }

<<<<<<< HEAD
        public bool AddSpawn(CreatureSpawn spawn)
        {
            return CreatureSpawns.TryAdd(spawn.Guid, spawn);
=======
        public bool AddSpawn(CreatureSpawn spawn, ref Creature data)
        {
            return CreatureSpawns.TryAdd(spawn, data);
>>>>>>> 7d3525d847b762c4ba307be028d1559bd4a8b05d
        }

        public void RemoveSpawn(CreatureSpawn spawn)
        {
<<<<<<< HEAD
            CreatureSpawn removedSpawn;
            CreatureSpawns.TryRemove(spawn.Guid, out removedSpawn);
=======
            Creature removedSpawn;
            CreatureSpawns.TryRemove(spawn, out removedSpawn);
>>>>>>> 7d3525d847b762c4ba307be028d1559bd4a8b05d

            DB.World.Execute("DELETE FROM creature_spawns WHERE Guid = ?", ObjectGuid.GetGuid(spawn.Guid));
        }

        public CreatureSpawn FindSpawn(ulong guid)
        {
            CreatureSpawn spawn;
            CreatureSpawns.TryGetValue(guid, out spawn);

            return spawn;
        }

        public IEnumerable<CreatureSpawn> GetInRangeCreatures(WorldObject obj)
        {
            foreach (var c in CreatureSpawns)
                if (!obj.ToCharacter().InRangeObjects.ContainsKey(c.Key))
                    if (obj.CheckUpdateDistance(c.Value))
                        yield return c.Value;
        }

        public IEnumerable<GameObjectSpawn> GetInRangeGameObjects(WorldObject obj)
        {
            foreach (var g in GameObjectSpawns)
                if (!obj.ToCharacter().InRangeObjects.ContainsKey(g.Key))
                    if (obj.CheckUpdateDistance(g.Value))
                        yield return g.Value;
        }

        public IEnumerable<CreatureSpawn> GetOutOfRangeCreatures(WorldObject obj)
        {
            foreach (var c in CreatureSpawns)
                if (obj.ToCharacter().InRangeObjects.ContainsKey(c.Key))
                    if (!obj.CheckUpdateDistance(c.Value))
                        yield return c.Value;
        }

        public IEnumerable<GameObjectSpawn> GetOutOfRangeGameObjects(WorldObject obj)
        {
            foreach (var g in GameObjectSpawns)
                if (obj.ToCharacter().InRangeObjects.ContainsKey(g.Key))
                    if (!obj.CheckUpdateDistance(g.Value))
                        yield return g.Value;
        }

        public void LoadCreatureSpawns()
        {
            SQLResult result = DB.World.Select("SELECT * FROM creature_spawns");

            for (int i = 0; i < result.Count; i++)
            {
                var guid = result.Read<UInt64>(i, "Guid");
                var id   = result.Read<Int32>(i, "Id");

                Creature data = Globals.DataMgr.FindCreature(id);
                if (data == null)
                {
                    Log.Message(LogType.ERROR, "Loading a creature spawn (Guid: {0}) with non-existing stats (Id: {1}) skipped.", guid, id);
                    continue;
                }

                CreatureSpawn spawn = new CreatureSpawn
                {
                    Guid = guid,
                    Id   = id,    
                    Map  = result.Read<UInt32>(i, "Map"),

                    Position = new Vector4()
                    {
                        X = result.Read<Single>(i, "X"),
                        Y = result.Read<Single>(i, "Y"),
                        Z = result.Read<Single>(i, "Z"),
                        O = result.Read<Single>(i, "O")
                    }
                };

                spawn.CreateFullGuid();
                spawn.CreateData(data);

                AddSpawn(spawn);
            }

            Log.Message(LogType.DB, "Loaded {0} creature spawns.", CreatureSpawns.Count);
        }

        public bool AddSpawn(GameObjectSpawn spawn, ref GameObject data)
        {
<<<<<<< HEAD
            return GameObjectSpawns.TryAdd(spawn.Guid, spawn);
=======
            return GameObjectSpawns.TryAdd(spawn, data);
>>>>>>> 7d3525d847b762c4ba307be028d1559bd4a8b05d
        }

        public void RemoveSpawn(GameObjectSpawn spawn)
        {
<<<<<<< HEAD
            GameObjectSpawn removedGameObject;
            GameObjectSpawns.TryRemove(spawn.Guid, out removedGameObject);
=======
            GameObject removedGameObject;
            GameObjectSpawns.TryRemove(spawn, out removedGameObject);

            DB.World.Execute("DELETE FROM creature_spawns WHERE Guid = ?", ObjectGuid.GetGuid(spawn.Guid));
        }
>>>>>>> 7d3525d847b762c4ba307be028d1559bd4a8b05d

            DB.World.Execute("DELETE FROM creature_spawns WHERE Guid = ?", ObjectGuid.GetGuid(spawn.Guid));
        }

        public void LoadGameObjectSpawns()
        {
            SQLResult result = DB.World.Select("SELECT * FROM gameobject_spawns");

            for (int i = 0; i < result.Count; i++)
            {
                var guid = result.Read<UInt64>(i, "Guid");
                var id = result.Read<Int32>(i, "Id");

                GameObject data = Globals.DataMgr.FindGameObject(id);
                if (data == null)
                {
                    Log.Message(LogType.ERROR, "Loading a gameobject spawn (Guid: {0}) with non-existing stats (Id: {1}) skipped.", guid, id);
                    continue;
                }

                GameObjectSpawn spawn = new GameObjectSpawn()
                {
                    Guid = guid,
                    Id   = id,
                    Map  = result.Read<UInt32>(i, "Map"),

                    Position = new Vector4()
                    {
                        X = result.Read<Single>(i, "X"),
                        Y = result.Read<Single>(i, "Y"),
                        Z = result.Read<Single>(i, "Z"),
                        O = result.Read<Single>(i, "O")
                    },

                    FactionTemplate = result.Read<UInt32>(i, "FactionTemplate"),
                    AnimProgress    = result.Read<Byte>(i, "AnimProgress"),
                    Activated       = result.Read<bool>(i, "Activated"),
                };

                spawn.CreateFullGuid();
                spawn.CreateData(data);

                AddSpawn(spawn, ref data);
            }

            Log.Message(LogType.DB, "Loaded {0} gameobject spawns.", GameObjectSpawns.Count);
        }
    }
}
