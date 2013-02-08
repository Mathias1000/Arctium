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
using Framework.Constants;
using Framework.Singleton;
using System;
using WorldServer.Game.ObjectDefines;
using WorldServer.Game.WorldEntities;
using System.Collections.Concurrent;

namespace WorldServer.Game.Managers
{
    public class DataManager : SingletonBase<DataManager>
    {
        ConcurrentDictionary<Int32, Creature> Creatures;
        ConcurrentDictionary<Int32, GameObject> GameObjects;
        ConcurrentDictionary<Int32, Areatrigger_Teleport> Areatrigger_Teleports;
        ConcurrentDictionary<Int32, ClassBasesStats> creature_classlevelstats;
        DataManager()
        {
            Creatures = new ConcurrentDictionary<Int32, Creature>();
            GameObjects = new ConcurrentDictionary<Int32, GameObject>();
            Areatrigger_Teleports = new ConcurrentDictionary<Int32, Areatrigger_Teleport>();
            creature_classlevelstats = new ConcurrentDictionary<Int32, ClassBasesStats>();

            Initialize();
        }

        public bool Add(Creature creature)
        {
            return Creatures.TryAdd(creature.Stats.Id, creature);
        }

        public Creature Remove(Creature creature)
        {
            Creature removedCreature;
            Creatures.TryRemove(creature.Stats.Id, out removedCreature);

            return removedCreature;
        }

        public ConcurrentDictionary<Int32, Creature> GetCreatures()
        {
            return Creatures;
        }

        public Creature FindCreature(int id)
        {
            Creature creature;
            Creatures.TryGetValue(id, out creature);

            return creature;
        }
        public ClassBasesStats FindCreatureBaseStats(Byte Level)
        {
            ClassBasesStats Stats;
            creature_classlevelstats.TryGetValue((int)Level, out Stats);

            return Stats;
        }
        public void LoadCreatureData()
        {
            SQLResult result = DB.World.Select("SELECT cs.Id FROM creature_stats cs LEFT JOIN creature_data cd ON cs.Id = cd.Id WHERE cd.Id IS NULL");

            if (result.Count != 0)
            {
                var missingIds = result.ReadAllValuesFromField("Id");
                DB.World.ExecuteBigQuery("creature_data", "Id", 1, result.Count, missingIds);

                Log.Message(LogType.DB, "Added {0} default data definition for creatures.", missingIds.Length);
            }

            result = DB.World.Select("SELECT * FROM creature_stats cs RIGHT JOIN creature_data cd ON cs.Id = cd.Id WHERE cs.id IS NOT NULL");

            for (int r = 0; r < result.Count; r++)
            {
                CreatureStats Stats = new CreatureStats
                {
                    Id                = result.Read<Int32>(r, "Id"),
                    Name              = result.Read<String>(r, "Name"),
                    SubName           = result.Read<String>(r, "SubName"),
                    IconName          = result.Read<String>(r, "IconName"),
                    Type              = result.Read<Int32>(r, "Type"),
                    Family            = result.Read<Int32>(r, "Family"),
                    Rank              = result.Read<Int32>(r, "Rank"),
                    HealthModifier    = result.Read<Single>(r, "HealthModifier"),
                    PowerModifier     = result.Read<Single>(r, "PowerModifier"),
                    RacialLeader      = result.Read<Byte>(r, "RacialLeader"),
                    MovementInfoId    = result.Read<Int32>(r, "MovementInfoId"),
                    ExpansionRequired = result.Read<Int32>(r, "ExpansionRequired")
                };

                for (int i = 0; i < Stats.Flag.Capacity; i++)
                    Stats.Flag.Add(result.Read<Int32>(r, "Flag", i));

                for (int i = 0; i < Stats.QuestKillNpcId.Capacity; i++)
                    Stats.QuestKillNpcId.Add(result.Read<Int32>(r, "QuestKillNpcId", i));

                for (int i = 0; i < Stats.DisplayInfoId.Capacity; i++)
                    Stats.DisplayInfoId.Add(result.Read<Int32>(r, "DisplayInfoId", i));

                for (int i = 0; i < Stats.QuestItemId.Capacity; i++)
                    Stats.QuestItemId.Add(result.Read<Int32>(r, "QuestItemId", i));

                byte Min_Level = result.Read<byte>(r, "Min_Level");
                byte Max_Level = result.Read<byte>(r, "Max_Level");
                if(Max_Level < Min_Level)
                    Min_Level = Max_Level;

                Add(new Creature
                {
                    Data = new CreatureData
                    {
                        Health = result.Read<Int32>(r, "Health"),
                        MaxLevel = Max_Level,
                        MinLevel = Min_Level,
                        Class = result.Read<Byte>(r, "Class"),
                        Faction = result.Read<Int32>(r, "Faction"),
                        Scale = result.Read<Int32>(r, "Scale"),
                        UnitFlags = result.Read<Int32>(r, "UnitFlags"),
                        UnitFlags2 = result.Read<Int32>(r, "UnitFlags2"),
                        NpcFlags = result.Read<Int32>(r, "NpcFlags")
                    },
                    Stats = Stats,
                });
              
            }

            Log.Message(LogType.DB, "Loaded {0} creatures.", Creatures.Count);
        }

        public bool Add(GameObject gameobject)
        {
            return GameObjects.TryAdd(gameobject.Stats.Id, gameobject);
        }
        public bool Add(ClassBasesStats BaseStats)
        {
            return creature_classlevelstats.TryAdd(BaseStats.level, BaseStats);
        }
        public void LoadBaseStats()
        {
            SQLResult result = DB.World.Select("SELECT * FROM creature_classlevelstats");

                for (int r = 0; r < result.Count; r++)
                {
                    Add(new ClassBasesStats
                    {
                        level = result.Read<Byte>(r, "level"),
                        Class = result.Read<Byte>(r, "Class"),
                        BaseHP0 = result.Read<Int32>(r, "basehp0"),
                        BaseHP1 = result.Read<Int32>(r, "basehp1"),
                        BaseHP2 = result.Read<Int32>(r, "basehp2"),
                        BaseHP3 = result.Read<Int32>(r, "basehp3"),
                        BaseMana = result.Read<Int32>(r, "basemana"),
                        BaseArmor = result.Read<Int32>(r, "basearmor"),
                    });
                }
                Log.Message(LogType.DB, "Loaded {0} creatures levelstats.", creature_classlevelstats.Count);
        }
        public GameObject Remove(GameObject gameobject)
        {
            GameObject removedGameObject;
            GameObjects.TryRemove(gameobject.Stats.Id, out removedGameObject);

            return removedGameObject;
        }

        public ConcurrentDictionary<Int32, GameObject> GetGameObjects()
        {
            return GameObjects;
        }

        public GameObject FindGameObject(int id)
        {
            GameObject gameObject;
            GameObjects.TryGetValue(id, out gameObject);

            return gameObject;
        }

        public void LoadGameObject()
        {
            SQLResult result = DB.World.Select("SELECT * FROM gameobject_stats");

            for (int r = 0; r < result.Count; r++)
            {
                GameObjectStats Stats = new GameObjectStats
                {
                    Id                = result.Read<Int32>(r, "Id"),
                    Type              = result.Read<Int32>(r, "Type"),
                    DisplayInfoId     = result.Read<Int32>(r, "DisplayInfoId"),
                    Name              = result.Read<String>(r, "Name"),
                    IconName          = result.Read<String>(r, "IconName"),
                    CastBarCaption    = result.Read<String>(r, "CastBarCaption"),
                    Size              = result.Read<Single>(r, "Size"),
                    ExpansionRequired = result.Read<Int32>(r, "ExpansionRequired")
                };

                for (int i = 0; i < Stats.Data.Capacity; i++)
                    Stats.Data.Add(result.Read<Int32>(r, "Data", i));

                for (int i = 0; i < Stats.QuestItemId.Capacity; i++)
                    Stats.QuestItemId.Add(result.Read<Int32>(r, "QuestItemId", i));

                Add(new GameObject
                {
                    Stats = Stats
                });
            }

            Log.Message(LogType.DB, "Loaded {0} gameobjects.", GameObjects.Count);
        }

        public void LoadAreaTriggerTeleports()
        {
            SQLResult result = DB.World.Select("SELECT * FROM areatrigger_teleport");

                 for (int r = 0; r < result.Count; r++)
                 {
                     Areatrigger_Teleport tele = new Areatrigger_Teleport
                     {
                         AreatriggerID = result.Read<Int32>(r, "Id"),
                         TargetMap = result.Read<UInt32>(r, "target_map"),
                         Target_Pos = new Framework.ObjectDefines.Vector4
                         {
                             X = result.Read<Single>(r, "target_position_x"),
                             Y = result.Read<Single>(r, "target_position_Y"),
                             Z = result.Read<Single>(r, "target_position_Z"),
                             O = result.Read<Single>(r, "target_orientation"), 
                         }
                     };
                     if (!this.Areatrigger_Teleports.ContainsKey(tele.AreatriggerID))
                     {
                         this.Areatrigger_Teleports.TryAdd(tele.AreatriggerID, tele);
                     }
                     else
                         Log.Message(LogType.DEFAULT, "Warning Duplicate Areatrigger Teleport found {0}", tele.AreatriggerID);
                 }
                 Log.Message(LogType.DB, "Loaded {0} Areatrigger Teleports", this.Areatrigger_Teleports.Count);
        }

        public Areatrigger_Teleport FindAreatrigger_Tele(int id)
        {
            Areatrigger_Teleport tele = null;
            if (this.Areatrigger_Teleports.TryGetValue(id, out tele))
                return tele;

            return null;
        }

        public void Initialize()
        {
            LoadAreaTriggerTeleports();
            LoadCreatureData();
            LoadGameObject();
            LoadBaseStats();
        }
    }
}
