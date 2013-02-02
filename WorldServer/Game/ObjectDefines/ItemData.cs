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

using System;
using System.Collections.Generic;

namespace WorldServer.Game.ObjectDefines
{
    public class ItemData
    {
        public Int32 Id;
        public Int32 Quality;
        public Int32 Class;
        public Int32 SubClass;
        public Int32 DisplayId;
        public List<Int32> Flags = new List<Int32>(2);
        //public Int32 Unk510_1;
        //public Single Unk510_2;
        //public Single Unk510_3;
        public Int32 BuyCount;
        public Int32 BuyPrice;
        public Int32 SellPrice;
        public Int32 InventoryType;
        public Int32 AllowableClass;
        public Int32 AllowableRace;
        public Int32 ItemLevel;
        public Int32 RequiredLevel;
        public Int32 RequiredSkill;
        public Int32 RequiredSkillRank;
        public Int32 RequiredSpell;
        public Int32 RequiredHonorRank;
        public Int32 RequiredCityRank;
        public Int32 RequiredReputationFaction;
        public Int32 RequiredReputationRank;
        public Int32 MaxCount;
        public Int32 Stackable;
        public Int32 ContainerSlots;
        public List<Int32> StatType = new List<Int32>(10);
        public List<Int32> StatValue = new List<Int32>(10);
        //public List<Int32> StatUnk1 = new List<Int32>(10);
        //public List<Int32> StatUnk2 = new List<Int32>(10);
        public Int32 ScalingStatDistribution;
        public Int32 DamageType;
        public Int32 Delay;
        public Single RangedModRange;
        public List<Int32> SpellId = new List<Int32>(5);
        public List<Int32> SpellTrigger = new List<Int32>(5);
        public List<Int32> SpellCharges = new List<Int32>(5);
        public List<Int32> SpellCooldown = new List<Int32>(5);
        public List<Int32> SpellCategory = new List<Int32>(5);
        public List<Int32> SpellCategoryCooldown = new List<Int32>(5);
        public Int32 Bonding;
        public String Name;
        public String Description;
        public Int32 PageText;
        public Int32 LanguageId;
        public Int32 PageMaterial;
        public Int32 StartQuest;
        public Int32 LockId;
        public Int32 Material;
        public Int32 Sheath;
        public Int32 RandomProperty;
        public Int32 RandomSuffix;
        public Int32 ItemSet;
        public Int32 Area;
        public Int32 Map;
        public Int32 BagFamily;
        public Int32 TotemCategory;
        public List<Int32> SocketColor = new List<Int32>(3);
        public List<Int32> SocketContent = new List<Int32>(3);
        public Int32 SocketBonus;
        public Int32 GemProperties;
        public Single ArmorDamageModifier;
        public Int32 Duration;
        public Int32 ItemLimitCategory;
        public Int32 HolidayId;
        public Single StatScalingFactor;
        public Int32 CurrencySubstitutionId;
        public Int32 CurrencySubstitutionCount;
        public Int32 SoundOverrideSubClassId;
    }
}
