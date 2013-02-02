using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Level = result.Read<Int32>(r, "Level"),

                    Strenght = result.Read<Int32>(r, "Str"),
                    Agility = result.Read<Int32>(r, "agi"),
                    Stamina = result.Read<Int32>(r, "sta"),
                    Intellect = result.Read<Int32>(r, "inte"),
                    Spirit = result.Read<Int32>(r, "Spi"),
                };
                CharacterLevelStats.Add(Stat);
            
            }
            Log.Message(LogType.DB, "Loaded {0} CharacterLevelStats.", CharacterLevelStats.Count);
        }

        public void Initialize()
        {
            LoadCharacterLevelStats();
        }
    }
}
