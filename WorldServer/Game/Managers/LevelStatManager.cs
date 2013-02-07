using System.Collections.Generic;
using System.Linq;
using System;
using Framework.Singleton;
using Framework.Constants;
using Framework;
using Framework.Database;
using Framework.Logging;

namespace WorldServer.Game.Managers
{
    public class LevelStatManager : SingletonBase<LevelStatManager>
    {
        LevelStatManager() { Initialize(); }

        public List<LevelStatInfo> CharacterLevelStats = new List<LevelStatInfo>();

        public void LoadCharacterLevelStats()
        {
            SQLResult result = DB.World.Select("SELECT *  FROM player_levelStats");

            for (int r = 0; r < result.Count; r++)
            {
        
                LevelStatInfo Stat = new LevelStatInfo
                {
                    Race = (RaceId)result.Read<Int32>(r, "Race"),
                    Class = (Class)result.Read<Int32>(r, "Class"),
                    Level = result.Read<Byte>(r, "Level"),

                    Strenght = result.Read<Int32>(r, "Str"),
                    Agility = result.Read<Int32>(r, "agi"),
                    Stamina = result.Read<Int32>(r, "sta"),
                    Intellect = result.Read<Int32>(r, "inte"),
                    Spirit = result.Read<Int32>(r, "Spi"),
                };
                SQLResult XpResult = DB.World.Select("SELECT * FROM player_xp_for_level WHERE lvl = ?", Stat.Level);

                if(XpResult.Count != 0)
                Stat.xpforLevel = XpResult.Read<UInt64>(0,"xp_for_next_level");

                CharacterLevelStats.Add(Stat);
            
            }
            Log.Message(LogType.DB, "Loaded {0} CharacterLevelStats.", CharacterLevelStats.Count);
        }

        public LevelStatInfo GetLevelStatInfo(RaceId Race, Class pClass, int level)
        {
            return CharacterLevelStats.Find(m => m.Level == level && m.Class == pClass && m.Race == Race);
        }

        public ulong GetXpForLevel(int level)
        {
            return CharacterLevelStats.Find(m => m.Level == level).xpforLevel;
        }

        public void Initialize()
        {
            LoadCharacterLevelStats();
        }
    }
}
