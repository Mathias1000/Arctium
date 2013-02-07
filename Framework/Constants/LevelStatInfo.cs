using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Constants
{
    public class LevelStatInfo
    {
        public Class Class;
        public RaceId Race;
        public byte Level;
        public UInt64 xpforLevel;

        public int[] Stats = new int[(int)StatType.End];

        public int Strenght
        {
            get { return Stats[(int)StatType.Strenght]; }
            set { Stats[(int)StatType.Strenght] = value; }
        }

        public int Agility
        {
            get { return Stats[(int)StatType.Agility]; }
            set { Stats[(int)StatType.Agility] = value; }
        }

        public int Stamina
        {
            get { return Stats[(int)StatType.Stamina]; }
            set { Stats[(int)StatType.Stamina] = value; }
        }

        public int Intellect
        {
            get { return Stats[(int)StatType.Intellect]; }
            set { Stats[(int)StatType.Intellect] = value; }
        }

        public int Spirit
        {
            get { return Stats[(int)StatType.Spirit]; }
            set { Stats[(int)StatType.Spirit] = value; }
        }

    }
}
