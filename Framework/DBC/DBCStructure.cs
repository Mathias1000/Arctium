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
using Framework.Constants;

namespace Framework.DBC
{
    public struct DbcHeader
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;

        public bool IsDBC
        {
            get { return Signature == 0x43424457; }
        }

        public long DataSize
        {
            get { return (long)(RecordsCount * RecordSize); }
        }

        public long StartStringPosition
        {
            get { return DataSize + (long)Marshal.SizeOf(typeof(DbcHeader)); }
        }
    };

    public struct AreaTable
    {

        public uint Id;                             // 0
        public uint MapId;                          // 1
        public uint ZoneId;                         // 2 if 0 then it's zone, else it's zone id of this area
        public uint ExploreFlag;                    // 3 main index
        public uint Flags;                          // 4
        //uint32                                    // 5
        public uint SoundProviderPref;              // 6
        public uint SoundProviderPrefUnderwater;    // 7
        public uint AmbienceId;                     // 8
        public uint ZoneMusic;                      // 9
        //uint32                                    // 10
        public uint IntroSound;                     // 11
        public uint ExplorationLevel;               // 12
        public uint _name;                          // 13
        public uint Team;                           // 14
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] LiquidType;                    // 15 - 18 liquid override by type
        public float MaxDepth;                      // 19
        public float AmbientMultiplier;             // 20
        //uint32                                    // 21
        //uint32                                    // 22
        //uint32                                    // 23
        //uint32                                    // 24
        //uint32                                    // 25
        //uint32                                    // 26
        //uint32                                    // 27
        //uint32                                    // 28
        //uint32                                    // 29

        /// <summary>
        /// Return current Area Name
        /// </summary>
        public string AreaName
        {
            get { return DBCStorage.AreaTableStrings.LookupByKey(_name); }
        }
    };

    public struct AreaGroup
    {
        public uint AreaGroupId;                    // 0
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public uint[] AreaId;                       // 1-6
        public uint NextGroup;                      // 7 index of next group
    };

    public struct AreaPOI
    {
        public uint Id;                             // 0
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public uint[] Icon;                         // 1-11
        public float X;                             // 12
        public float Y;                             // 13
        public uint MapId;                          // 14
        //uint32                                    // 15
        public int ZoneId;                          // 16
        public uint _name;                          // 17
        //string                                    // 18 pvp description
        public uint WorldState;                     // 19
        //uint32                                    // 20
        //uint32                                    // 21
        //uint32                                    // 22

        /// <summary>
        /// Return current AreaPOI Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.AreaPOIStrings.LookupByKey(_name); }
        }
    };

    public struct AreaTrigger
    {
        public uint Id;                                         // 0
        public uint MapId;                                      // 1
        public float PositionX;                                 // 2
        public float PositionY;                                 // 3
        public float PositionZ;                                 // 4
        //uint32                                                // 5
        //uint32                                                // 6
        //uint32                                                // 7
        public float Radius;                                    // 8
        public float BoxPositionX;                              // 9
        public float BoxPositionY;                              // 10
        public float BoxPositionZ;                              // 11
        public float BoxOrientation;                            // 12
        //uint32                                                // 13
        //uint32                                                // 14
        //uint32                                                // 15
    };

    public struct ChrClasses
    {
        public uint ClassID;                                    // 0        m_ID
        public uint DisplayPowerType;                           // 1        m_DisplayPower
        // 2        m_petNameToken
        public uint _name;                                      // 3        m_name_lang
        //char*       nameFemale;                               // 4        m_name_female_lang
        //char*       nameNeutralGender;                        // 5        m_name_male_lang
        //char*       capitalizedName                           // 6,       m_filename
        public uint spellfamily;                                // 7        m_spellClassSet
        //uint32 flags2;                                        // 8        m_flags (0x08 HasRelicSlot)
        public uint CinematicSequence;                          // 9        m_cinematicSequenceID
        public uint expansion;                                  // 10       m_required_expansion
        //uint32                                                // 11
        //uint32                                                // 12
        //uint32                                                // 13

        /// <summary>
        /// Return current Class Name
        /// </summary>
        public string ClassName
        {
            get { return DBCStorage.ClassStrings.LookupByKey(_name); }
        }
    };

    public struct ChrRaces
    {
        public uint RaceID;                                     // 0
        // 1 unused
        public uint FactionID;                                  // 2 faction template id
        // 3 unused
        public uint model_m;                                    // 4
        public uint model_f;                                    // 5
        // 6 unused
        public uint TeamID;                                     // 7 (7-Alliance 1-Horde)
        // 8-11 unused
        public uint CinematicSequence;                          // 12 id from CinematicSequences.dbc
        // 13 unused
        public uint _name;                                      // 14
        // 17
        // 16 
        // 17-18    m_facialHairCustomization[2]
        // 19       m_hairCustomization
        //uint32                                                // 20 (23 for worgens)
        //uint32                                                // 21 4.0.0
        //uint32                                                // 22 4.0.0

        /// <summary>
        /// Return current Race Name
        /// </summary>
        public string RaceName
        {
            get { return DBCStorage.RaceStrings.LookupByKey(_name); }
        }
    };

    public struct ChrSpecialization
    {
        public uint Id;                                         // 0
        //string  Icon                                          // 1
        public uint ClassId;                                    // 2    0 = Pet
        public uint MasterySpellId;                             // 3
        //uint32  unknown                                       // 4    all 0
        public uint TabId;                                      // 5    0 / 1 / 2 / 3
        //uint32  unknown                                       // 6    only for Pets values 0, 1, 2
        public uint RoleTypeId;                                 // 7    0 = Tank / 1 = Heal / 2 = Damage
        //uint32                                                // 8
        //uint32                                                // 9
        //uint32                                                // 10
        //string  Name;                                         // 11
        //string  Description;                                  // 12
        //uint32                                                // 13
    };

    public struct CharStartOutfit
    {
        public uint Mask;      // Race, Class, Gender, ?

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public uint[] ItemId;
    };

    public struct ChrPowerType
    {
        public uint Id;                                         // 0
        public uint Class;                                      // 1
        public uint PowerType;                                  // 2
    };

    public struct CreatureFamily
    {
        public uint Id;                                         // 0        m_ID
        public float MinScale;                                  // 1        m_minScale
        public uint MinScaleLevel;                              // 2        m_minScaleLevel
        public float MaxScale;                                  // 3        m_maxScale
        public uint MaxScaleLevel;                              // 4        m_maxScaleLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SkillLine;                                // 5-6      m_skillLine
        public uint PetFoodMask;                                // 7        m_petFoodMask
        public uint PetTalentType;                              // 8        m_petTalentType
        //uint32                                                // 9        m_categoryEnumID
        public uint _name;                                      // 10       m_name_lang
        //string                                                // 11       m_iconFile
    };

    public struct NameGen
    {
        public uint Id;
        public uint _name;
        public uint Race;
        public uint Gender;

        public string Name
        {
            get { return DBCStorage.NameGenStrings.LookupByKey(_name); }
        }
    };

    public struct SpecializationSpell
    {
        //uint32                                                // 0
        public uint SpecId;                                     // 1    value is taken from ChrSpecialization.Id
        public uint SpellId;                                    // 2
        public uint SwitchSpellId;                              // 3
        //uint                                                  // 4    all 0
    };

    public struct Spell
    {
        public uint Id;                                         // 0        m_ID
        //string SpellName;                                     // 1        m_name_lang
        //string SubText;                                       // 2        m_nameSubtext_lang
        //string Description;                                   // 3        m_description_lang not used
        //string AuraDescription;                               // 4        m_auraDescription_lang not used
        public uint RuneCostId;                                 // 5        m_runeCostID
        //public uint SpellMissileId;                           // 6        m_spellMissileID not used
        //public uint SpellDescriptionVariableId;               // 7        m_spellDescriptionVariableID, 3.2.0
        //float   unk_f1;                                       // 8
        public uint SpellScalingId;                             // 9        SpellScaling.dbc
        public uint SpellAuraOptionsId;                         // 10       SpellAuraOptions.dbc
        public uint SpellAuraRestrictionsId;                    // 11       SpellAuraRestrictions.dbc
        public uint SpellCastingRequirementsId;                 // 12       SpellCastingRequirements.dbc
        public uint SpellCategoriesId;                          // 13       SpellCategories.dbc
        public uint SpellClassOptionsId;                        // 14       SpellClassOptions.dbc
        public uint SpellCooldownsId;                           // 15       SpellCooldowns.dbc
        public uint SpellEquippedItemsId;                       // 16       SpellEquippedItems.dbc
        public uint SpellInterruptsId;                          // 17       SpellInterrupts.dbc
        public uint SpellLevelsId;                              // 18       SpellLevels.dbc
        public uint SpellReagentsId;                            // 19       SpellReagents.dbc
        public uint SpellShapeshiftId;                          // 20       SpellShapeshift.dbc
        public uint SpellTargetRestrictionsId;                  // 21       SpellTargetRestrictions.dbc
        public uint SpellTotemsId;                              // 22       SpellTotems.dbc
        public uint ResearchProjectId;                          // 23
        public uint SpellMiscId;                                // 24       SpellMisc.dbc
    };

    public struct SpellLevels
    {
        public uint Id;                                         // 0
        public uint SpellId;                                    // 1
        //uint32                                                // 2
        public uint BaseLevel;                                  // 3
        public uint MaxLevel;                                   // 4
        public uint SpellLevel;                                 // 5
    };

    public struct Talent
    {
        public uint Id;                                         // 0
        //uint32                                                // 1        (pet talent related)
        public uint Row;                                        // 2
        public uint Column;                                     // 3
        public uint SpellId;                                    // 4
        //uint32                                                // 5        (pet talent related)
        //uint32                                                // 6        (pet talent related)
        //int32                                                 // 7        (pet talent related)
        public uint ClassId;                                    // 8        (class id 0 are pets)
        public uint ReplaceSpellId;                             // 9
        //uint32                                                // 10       unknown
    };
    
    public struct ChatChannels
    {
        public uint Id;                                      // 0
        public uint Flags;                                   // 1
        // 2        m_factionGroup
        public uint _name;                                   // 3        m_name_lang
        // 4        m_shortcut_lang

        /// <summary>
        /// Return current Channel Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.ChatChannelStrings.LookupByKey(_name); }
        }
    };

    public struct Faction
    {
        public uint Id;                                     // 0        m_ID
        public int ReputationListId;                        // 1        m_reputationIndex
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] BaseRepRaceMask;                      // 2-5      m_reputationRaceMask
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] BaseRepClassMask;                     // 6-9      m_reputationClassMask
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] BaseRepValue;                          // 10-13    m_reputationBase
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] ReputationFlags;                      // 14-17    m_reputationFlags
        public uint Team;                                   // 18       m_parentFactionID
        public float SpilloverRateIn;                       // 19       Faction gains incoming rep * spilloverRateIn
        public float SpilloverRateOut;                      // 20       Faction outputs rep * spilloverRateOut as spillover reputation
        public uint SpilloverMaxRankIn;                     // 21       The highest rank the faction will profit from incoming spillover
        //uint32    SpilloverRankUnk;                       // 22       It does not seem to be the max standing at which a faction outputs spillover ...so no idea
        public uint _name;                                  // 23       m_name_lang
        //string    _description;                           // 24       m_description_lang
        //uint32                                            // 25

        /// <summary>
        /// Return current Faction Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.FactionStrings.LookupByKey(_name); }
        }

        public bool CanHaveReputation()
        {
            return ReputationListId >= 0;
        }
    };

    public struct FactionTemplate
    {
        public uint Id;                                     // 0        m_ID
        public uint Faction;                                // 1        m_faction
        public uint FactionFlags;                           // 2        m_flags
        public uint FactionGroup;                           // 3        m_factionGroup
        public uint FriendlyMask;                           // 4        m_friendGroup
        public uint HostileMask;                            // 5        m_enemyGroup
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] EnemyFaction;                         // 6-9      m_enemies

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] FriendFaction;                        // 10-13     m_friend

        public bool IsFriendlyTo(ref FactionTemplate entry)
        {
            if (Id == entry.Id)
                return true;

            if (entry.Faction != 0)
            {
                for (int i = 0; i < 4; ++i)
                    if (EnemyFaction[i] == entry.Faction)
                        return false;

                for (int i = 0; i < 4; ++i)
                    if (FriendFaction[i] == entry.Faction)
                        return true;
            }
            return ((FriendlyMask & entry.FactionGroup) == 0) || ((FactionGroup & entry.FriendlyMask) == 0);
        }

        public bool IsHostileTo(ref FactionTemplate entry)
        {
            if (Id == entry.Id)
                return false;

            if (entry.Faction != 0)
            {
                for (int i = 0; i < 4; ++i)
                    if (EnemyFaction[i] == entry.Faction)
                        return true;

                for (int i = 0; i < 4; ++i)
                    if (FriendFaction[i] == entry.Faction)
                        return false;
            }
            return (HostileMask & entry.FactionGroup) != 0;
        }

        public bool IsHostileToPlayers()
        {
            return ((HostileMask & (int)FactionMasks.Player) != 0);
        }

        public bool IsNeutralToAll()
        {
            for (int i = 0; i < 4; ++i)
                if (EnemyFaction[i] != 0)
                    return false;
            return HostileMask == 0 && FriendlyMask == 0;
        }
    };

    public struct GameObjectDisplayInfo
    {
        public uint DisplayId;                              // 0        m_ID
        public uint _fileName;                              // 1
        //uint32                                            // 2-11
        public float MinX;                                  // 12
        public float MinY;                                  // 13
        public float MinZ;                                  // 14
        public float MaxX;                                  // 15
        public float MaxY;                                  // 16
        public float MaxZ;                                  // 17
        public uint TransportMapId;                         // 18
        //float                                             // 19
        //float                                             // 20

        /// <summary>
        /// Return current File Name
        /// </summary>
        public string FileName
        {
            get { return DBCStorage.GameObjectDisplayInfoStrings.LookupByKey(_fileName); }
        }
    };

    public struct GlyphProperties
    {
        public uint Id;                                     // 0
        public uint SpellId;                                // 1
        public uint TypeFlags;                              // 2
        public uint GlyphIconId;                            // 3 (SpellIcon.dbc)
    };

    public struct GlyphSlot
    {
        public uint Id;                                     // 0
        public uint TypeFlags;                              // 1
        public uint Order;                                  // 2
    };

    public struct ItemClass
    {
        public uint Id;                                     // 0 item class id
        //uint32    IsWeapon;                               // 1 (1 for weapon, 0 for everything else)
        public float PriceFactor;                           // 2 used to calculate certain prices
        //string    Name;                                   // 3
    };

    public struct ItemPriceBase
    {
        public uint ItemLevel;                              // 1 Item level (1 - 1000)
        public float ArmorFactor;                           // 2 Price factor for armor
        public float WeaponFactor;                          // 3 Price factor for weapons
    };

    public struct ItemSet
    {
        public uint Id;                                     // 0        m_ID
        public uint _name;                                  // 1        m_name_lang
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] ItemId;                               // 2-18     m_itemID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] Spells;                               // 19-26    m_setSpellID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] ItemsToTriggerSpell;                  // 27-34    m_setThreshold
        public uint RequiredSkillId;                        // 35       m_requiredSkill
        public uint RequiredSkillValue;                     // 36       m_requiredSkillRank

        /// <summary>
        /// Return current ItemSet Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.ItemSetStrings.LookupByKey(_name); }
        }
    };

    public struct LiquidType
    {
        public uint Id;                                     // 0
        //string Name;                                      // 1
        //uint32 Flags;                                     // 2
        public uint Type;                                   // 3
        //uint32 SoundId;                                   // 4
        public uint SpellId;                                // 5
        //float MaxDarkenDepth;                             // 6
        //float FogDarkenIntensity;                         // 7
        //float AmbDarkenIntensity;                         // 8
        //float DirDarkenIntensity;                         // 9
        //uint32 LightID;                                   // 10
        //float ParticleScale;                              // 11
        //uint32 ParticleMovement;                          // 12
        //uint32 ParticleTexSlots;                          // 13
        //uint32 LiquidMaterialID;                          // 14
        //char* Texture[6];                                 // 15-20
        //uint32 Color[2];                                  // 21-22
        //float Unk1[18];                                   // 23-41
        //uint32 Unk2[4];                                   // 42-43
    };

    public struct Map
    {
        public uint Id;                                     // 0
        //string InternalName                               // 1
        public uint MapType;                                // 2
        public uint Flags;                                  // 3
        //uint32                                            // 4
        public uint _name;                                  // 5
        public uint LinkedZone;                             // 6        m_areaTableID
        //string HordeIntro                                 // 7
        //string AllianceIntro                              // 8
        public uint LoadingScreenId;                        // 9        m_LoadingScreenID (LoadingScreens.dbc)
        //float BattlefieldMapIconScale                     // 10       m_minimapIconScale
        public int CorpseEntranceMapId;                     // 11       m_corpseMapID map_id of entrance map in ghost mode (continent always and in most cases = normal entrance)
        public float CorpseEntranceX;                       // 12       m_corpseX entrance x coordinate in ghost mode  (in most cases = normal entrance)
        public float CorpseEntranceY;                       // 13       m_corpseY entrance y coordinate in ghost mode  (in most cases = normal entrance)
        //int32                                             // 14       m_timeOfDayOverride
        public uint ExpansionId;                            // 15       m_expansionID
        //uint32                                            // 16       m_raidOffset
        public uint MaxPlayers;                             // 17       m_maxPlayers
        public int RootPhaseMapId;                          // 18       added in 4.0.0, mapid, related to phasing

        /// <summary>
        /// Return current Map Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.MapStrings.LookupByKey(_name); }
        }

        public bool IsInstance() { return (MapType == (int)MapTypes.Instance) || (MapType == (int)MapTypes.Raid); }
        public bool IsDungeon() { return (MapType == (int)MapTypes.Instance); }
        public bool IsRaid() { return (MapType == (int)MapTypes.Raid); }
        public bool IsBattleground() { return (MapType == (int)MapTypes.Battleground); }
        public bool IsArena() { return (MapType == (int)MapTypes.Arena); }
        public bool IsWorldMap() { return (MapType == (int)MapTypes.Common); }
    };

    public struct MountCapability
    {
        public uint Id;                                     // 0
        public uint Flags;                                  // 1
        public uint RequiredRidingSkill;                    // 2
        public uint RequiredArea;                           // 3
        public uint RequiredAura;                           // 4
        public uint RequiredSpell;                          // 5
        public uint SpeedModSpell;                          // 6
        public int RequiredMap;                             // 7
    };

    public struct TaxiNodes
    {
        public uint Id;                                     // 0        m_ID
        public uint MapId;                                  // 1        m_ContinentID
        public float X;                                     // 2        m_x
        public float Y;                                     // 3        m_y
        public float Z;                                     // 4        m_z
        public uint _name;                                  // 5        m_Name_lang
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] MountCreatureId;                      // 6-7      m_MountCreatureID[2]
        //uint32                                            // 8
        //float                                             // 9
        //float                                             // 10

        /// <summary>
        /// Return current TaxiNode Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.TaxiNodesStrings.LookupByKey(_name); }
        }
    };

    public struct TaxiPath
    {
        public uint Id;                                     // 0
        public uint FromTaxiNode;                           // 1
        public uint DestTaxiNode;                           // 2
        public uint Price;                                  // 3
    };
    
    public struct TaxiPathNode
    {
        public uint Id;                                     // 0
        public uint PathId;                                 // 1
        public uint NodeId;                                 // 2
        public uint MapId;                                  // 3
        public float X;                                     // 4
        public float Y;                                     // 5
        public float Z;                                     // 6
        public uint ActionFlag;                             // 7
        public uint Delay;                                  // 8
        public uint ArrivalEventId;                         // 9
        public uint DepartureEventId;                       // 10
    };

    public struct WMOAreaTable
    {
        public uint Id;                                    // 0
        public int RootId;                                 // 1 used in root WMO
        public int AdtId;                                  // 2 used in adt file
        public int GroupId;                                // 3 used in group WMO
        //uint32                                           // 4
        //uint32                                           // 5
        //uint32                                           // 6
        //uint32                                           // 7
        //uint32                                           // 8
        public uint Flags;                                 // 9 used for indoor/outdoor determination
        public uint AreaId;                                // 10 link to AreaTableEntry.ID
        //string _name;                                    // 11       m_AreaName_lang
        //uint32                                           // 12
        //uint32                                           // 13
        //uint32                                           // 14
    };

    public struct WorldMapArea
    {
        public uint Id;                                     // 0
        public uint MapId;                                  // 1
        public uint AreaId;                                 // 2
        public uint _name;                                  // 3
        public float MinY;                                  // 4
        public float MaxY;                                  // 5
        public float MinX;                                  // 6
        public float MaxX;                                  // 7
        public int VirtualMapId;                            // 8        -1 (map_id have correct map) other: virtual map where zone show (map_id - where zone in fact internally)
        //int32   DungeonMapId;                             // 9        pointer to DungeonMap.dbc (override MinX, MaxX, MinY, MaxY coordinates)
        //uint32  ParentMapID;                              // 10
        //uint32  Unknown                                   // 11
        //uint32  MinRecommendedLevel;                      // 12       minimum recommended level displayed on world map
        //uint32  MaxRecommendedLevel;                      // 13       maximum recommended level displayed on world map

        /// <summary>
        /// Return current WorldMapArea Name
        /// </summary>
        public string Name
        {
            get { return DBCStorage.WorldMapAreaStrings.LookupByKey(_name); }
        }
    };

    public struct WorldSafeLocs
    {
        public uint Id;                                     // 0
        public uint MapId;                                  // 1
        public float X;                                     // 2
        public float Y;                                     // 3
        public float Z;                                     // 4
        //float                                             // 5        seems something like angle (values from 360 to -165)
        public uint _name;                                  // 6

        public string Name
        {
            get { return DBCStorage.WorldSafeLocsStrings.LookupByKey(_name); }
        }
    };

    public struct BaseHPByClass                             // gtOCTBaseMPByClass.dbc
    {
        public uint Id;                                     // 0
        public float HealthPoints;                          // 1
    };

    public struct BaseMPByClass                             // gtOCTBaseMPByClass.dbc
    {
        public uint Id;                                     // 0
        public float ManaPoints;                            // 1
    };

    public struct HpPerStamina
    {
        public uint Id;                                     // 0
        public float Ratio;                                 // 1
    };
}
