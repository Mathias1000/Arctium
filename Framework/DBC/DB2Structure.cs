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

using System.Runtime.InteropServices;

namespace Framework.DBC
{
    public struct Db2Header
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;

        public bool IsDB2
        {
            get { return Signature == 0x32424457; }
        }

        public long DataSize
        {
            get { return (long)(RecordsCount * RecordSize); }
        }

        public long StartStringPosition
        {
            get { return DataSize + (long)Marshal.SizeOf(typeof(Db2Header)); }
        }
    }

    public struct ItemEntry
    {
        public uint Id;                                             // 0
        public uint Class;                                          // 1
        public uint SubClass;                                       // 2
        public int  SoundOverrideSubClassId;                        // 3
        public int  Material;                                       // 4
        public uint DisplayId;                                      // 5
        public uint InventoryType;                                  // 6
        public uint Sheath;                                         // 7
    };

    public struct ItemSparse
    {
        public uint Id;                                             // 0
        public uint Quality;                                        // 1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Flags;                                        // 2 - 3
        //public int Unk510_1;                                      // 4
        //public float Unk510_2;                                    // 5
        //public float Unk510_3;                                    // 6
        public uint BuyCount;                                       // 7
        public uint BuyPrice;                                       // 8
        public uint SellPrice;                                      // 9
        public uint InventoryType;                                  // 10
        public int AllowableClass;                                  // 11
        public int AllowableRace;                                   // 12
        public uint ItemLevel;                                      // 13
        public int RequiredLevel;                                   // 14
        public uint RequiredSkill;                                  // 15
        public uint RequiredSkillRank;                              // 16
        public uint RequiredSpell;                                  // 17
        public uint RequiredHonorRank;                              // 18
        public uint RequiredCityRank;                               // 19
        public int RequiredReputationFaction;                       // 20
        public int RequiredReputationRank;                          // 21
        public int MaxCount;                                        // 22
        public int Stackable;                                       // 23
        public int ContainerSlots;                                  // 24
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] StatType;                                      // 25 - 34
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] StatValue;                                     // 35 - 44
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] StatUnk1;                                      // 45 - 54
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] StatUnk2;                                      // 55 - 64
        public int ScalingStatDistribution;                         // 65
        public uint DamageType;                                     // 66
        public int Delay;                                           // 67
        public float RangedModRange;                                // 68
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] SpellId;                                      // 69 - 73
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] SpellTrigger;                                  // 74 - 78
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] SpellCharges;                                  // 79 - 83
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] SpellCooldown;                                 // 84 - 88
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] SpellCategory;                                 // 89 - 93
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] SpellCategoryCooldown;                         // 94 - 98
        public uint Bonding;                                        // 99
        public uint _name;                                          // 100
        //public uint _name2-4;                                     // 101-103      all empty in 5.1.0
        public uint _description;                                   // 104
        public uint PageText;                                       // 105
        public uint LanguageId;                                     // 106
        public uint PageMaterial;                                   // 107
        public uint StartQuest;                                     // 108
        public uint LockId;                                         // 109
        public uint Material;                                       // 110
        public uint Sheath;                                         // 111
        public uint RandomProperty;                                 // 112
        public uint RandomSuffix;                                   // 113
        public uint ItemSet;                                        // 114
        public uint Area;                                           // 115
        public uint Map;                                            // 116
        public uint BagFamily;                                      // 117
        public uint TotemCategory;                                  // 118
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] SocketColor;                                  // 119 - 121
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] SocketContent;                                // 122 - 124
        public uint SocketBonus;                                    // 125
        public uint GemProperties;                                  // 126
        public float ArmorDamageModifier;                           // 127
        public uint Duration;                                       // 128
        public uint ItemLimitCategory;                              // 129
        public uint HolidayId;                                      // 130
        public float StatScalingFactor;                             // 131
        public uint CurrencySubstitutionId;                         // 132
        public uint CurrencySubstitutionCount;                      // 133

        /// <summary>
        /// Return current Item Name
        /// </summary>
        public string Name
        {
            get { return DB2Storage.ItemSparseStrings.LookupByKey(_name); }
        }

        /// <summary>
        /// Return current Item Description
        /// </summary>
        public string Description
        {
            get { return DB2Storage.ItemSparseStrings.LookupByKey(_description); }
        }
    };

    public struct ItemExtendedCost
    {
        public uint Id;                                             // 0
        public uint RequiredArenaSlot;                              // 3
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] RequiredItemId;                               // 4 - 8
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] RequiredItemCount;                            // 9 - 13
        public uint RequiredArena;                                  // 14
        public uint ItemPurchaseGroup;                              // 15
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] RequiredCurrencyId;                           // 16 - 20
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] RequiredCurrencyCount;                        // 21 - 25
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        //public uint[] Unknown;                                    // 26 - 30
    };
}
