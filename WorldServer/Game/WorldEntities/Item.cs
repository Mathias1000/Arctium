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
using Framework.DBC;
using WorldServer.Game.ObjectDefines;

namespace WorldServer.Game.WorldEntities
{
    public class Item
    {
        public ItemData Data;

        public Item() { }
        public Item(int id)
        {
            var itemEntry                   = DB2Storage.ItemEntryStorage[(uint)id];
            var itemSparse                  = DB2Storage.ItemSparseStorage[(uint)id];

            if (itemEntry.Id == 0 || itemSparse.Id == 0)
                return;

            Data.Id                         = (Int32)itemSparse.Id;
            Data.DisplayId                  = (Int32)itemEntry.DisplayId;
            Data.Class                      = (Int32)itemEntry.Class;
            Data.SubClass                   = (Int32)itemEntry.SubClass;
            Data.DisplayId                  = (Int32)itemEntry.DisplayId;

            Data.Quality                    = (Int32)itemSparse.Quality;

            for (int i = 0; i < Data.Flags.Capacity; i++)
                Data.Flags.Add((int)itemSparse.Flags[i]);

            Data.BuyCount                   = (Int32)itemSparse.BuyCount;
            Data.BuyPrice                   = (Int32)itemSparse.BuyPrice;
            Data.SellPrice                  = (Int32)itemSparse.SellPrice;
            Data.InventoryType              = (Int32)itemSparse.InventoryType;
            Data.AllowableClass             = (Int32)itemSparse.AllowableClass;
            Data.AllowableRace              = (Int32)itemSparse.AllowableRace;
            Data.ItemLevel                  = (Int32)itemSparse.ItemLevel;
            Data.RequiredLevel              = (Int32)itemSparse.RequiredLevel;
            Data.RequiredSkill              = (Int32)itemSparse.RequiredSkill;
            Data.RequiredSkillRank          = (Int32)itemSparse.RequiredSkillRank;
            Data.RequiredSpell              = (Int32)itemSparse.RequiredSpell;
            Data.RequiredHonorRank          = (Int32)itemSparse.RequiredHonorRank;
            Data.RequiredCityRank           = (Int32)itemSparse.RequiredCityRank;
            Data.RequiredReputationFaction  = (Int32)itemSparse.RequiredReputationFaction;
            Data.RequiredReputationRank     = (Int32)itemSparse.RequiredReputationRank;
            Data.MaxCount                   = (Int32)itemSparse.MaxCount;
            Data.Stackable                  = (Int32)itemSparse.Stackable;
            Data.ContainerSlots             = (Int32)itemSparse.ContainerSlots;

            for (int i = 0; i < Data.StatType.Capacity; i++)
                Data.StatType.Add((Int32)itemSparse.StatType[i]);

            for (int i = 0; i < Data.StatValue.Capacity; i++)
                Data.StatValue.Add((Int32)itemSparse.StatValue[i]);

            Data.ScalingStatDistribution    = itemSparse.ScalingStatDistribution;
            Data.DamageType                 = (Int32)itemSparse.DamageType;
            Data.Delay                      = itemSparse.Delay;
            Data.RangedModRange             = itemSparse.RangedModRange;

            for (int i = 0; i < Data.SpellId.Capacity; i++)
                Data.SpellId.Add((Int32)itemSparse.SpellId[i]);

            for (int i = 0; i < Data.SpellTrigger.Capacity; i++)
                Data.SpellTrigger.Add((Int32)itemSparse.SpellTrigger[i]);

            for (int i = 0; i < Data.SpellCharges.Capacity; i++)
                Data.SpellCharges.Add((Int32)itemSparse.SpellCharges[i]);

            for (int i = 0; i < Data.SpellCooldown.Capacity; i++)
                Data.SpellCooldown.Add((Int32)itemSparse.SpellCooldown[i]);

            for (int i = 0; i < Data.SpellCategory.Capacity; i++)
                Data.SpellCategory.Add((Int32)itemSparse.SpellCategory[i]);

            for (int i = 0; i < Data.SpellCategoryCooldown.Capacity; i++)
                Data.SpellCategoryCooldown.Add((Int32)itemSparse.SpellCategoryCooldown[i]);

            Data.Bonding                    = (Int32)itemSparse.Bonding;

            Data.Name                       = itemSparse.Name;
            Data.Description                = itemSparse.Description;
            Data.PageText                   = (Int32)itemSparse.PageText;
            Data.LanguageId                 = (Int32)itemSparse.LanguageId;
            Data.PageMaterial               = (Int32)itemSparse.PageMaterial;
            Data.StartQuest                 = (Int32)itemSparse.StartQuest;
            Data.Material                   = (Int32)itemSparse.Material;
            Data.Sheath                     = (Int32)itemSparse.Sheath;
            Data.RandomProperty             = (Int32)itemSparse.RandomProperty;
            Data.RandomSuffix               = (Int32)itemSparse.RandomSuffix;
            Data.ItemSet                    = (Int32)itemSparse.ItemSet;
            Data.Area                       = (Int32)itemSparse.Area;
            Data.Map                        = (Int32)itemSparse.Map;
            Data.BagFamily                  = (Int32)itemSparse.BagFamily;
            Data.TotemCategory              = (Int32)itemSparse.TotemCategory;

            for (int i = 0; i < Data.SocketColor.Capacity; i++)
                Data.SocketColor.Add((Int32)itemSparse.SocketColor[i]);

            for (int i = 0; i < Data.SocketContent.Capacity; i++)
                Data.SocketContent.Add((Int32)itemSparse.SocketContent[i]);

            Data.SocketBonus                = (Int32)itemSparse.SocketBonus;
            Data.GemProperties              = (Int32)itemSparse.GemProperties;
            Data.ArmorDamageModifier        = itemSparse.ArmorDamageModifier;
            Data.Duration                   = (Int32)itemSparse.Duration;
            Data.ItemLimitCategory          = (Int32)itemSparse.ItemLimitCategory;
            Data.HolidayId                  = (Int32)itemSparse.HolidayId;
            Data.StatScalingFactor          = itemSparse.StatScalingFactor;
            Data.CurrencySubstitutionId     = (Int32)itemSparse.CurrencySubstitutionId;
            Data.CurrencySubstitutionCount  = (Int32)itemSparse.CurrencySubstitutionCount;
            Data.SoundOverrideSubClassId    = (Int32)itemEntry.SoundOverrideSubClassId;
        }
    }
}
