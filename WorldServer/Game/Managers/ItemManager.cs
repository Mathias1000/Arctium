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
using Framework.DBC;
using Framework.Logging;
using Framework.Singleton;
using WorldServer.Game.ObjectDefines;
using WorldServer.Game.WorldEntities;

namespace WorldServer.Game.Managers
{
    public class ItemManager : SingletonBase<ItemManager>
    {
        Dictionary<Int32, Item> Items;

        ItemManager()
        {
            Items = new Dictionary<Int32, Item>();

            Initialize();
        }

        public void Add(Item item)
        {
            Items.Add(item.Data.Id, item);
        }

        public Dictionary<Int32, Item> GetItems()
        {
            return Items;
        }

        public Item FindData(int id)
        {
            foreach (var i in Items)
                if (i.Key == id)
                    return i.Value;

            return null;
        }

        public void LoadItemData()
        {
            var storage = DB2Storage.ItemSparseStorage;
            foreach (var itemSparse in storage)
            {
                ItemData Data = new ItemData();

                Data.Id = (Int32)itemSparse.Value.Id;
                Data.Quality = (Int32)itemSparse.Value.Quality;

                for (int i = 0; i < Data.Flags.Capacity; i++)
                    Data.Flags.Add((int)itemSparse.Value.Flags[i]);

                Data.BuyCount = (Int32)itemSparse.Value.BuyCount;
                Data.BuyPrice = (Int32)itemSparse.Value.BuyPrice;
                Data.SellPrice = (Int32)itemSparse.Value.SellPrice;
                Data.InventoryType = (Int32)itemSparse.Value.InventoryType;
                Data.AllowableClass = (Int32)itemSparse.Value.AllowableClass;
                Data.AllowableRace = (Int32)itemSparse.Value.AllowableRace;
                Data.ItemLevel = (Int32)itemSparse.Value.ItemLevel;
                Data.RequiredLevel = (Int32)itemSparse.Value.RequiredLevel;
                Data.RequiredSkill = (Int32)itemSparse.Value.RequiredSkill;
                Data.RequiredSkillRank = (Int32)itemSparse.Value.RequiredSkillRank;
                Data.RequiredSpell = (Int32)itemSparse.Value.RequiredSpell;
                Data.RequiredHonorRank = (Int32)itemSparse.Value.RequiredHonorRank;
                Data.RequiredCityRank = (Int32)itemSparse.Value.RequiredCityRank;
                Data.RequiredReputationFaction = (Int32)itemSparse.Value.RequiredReputationFaction;
                Data.RequiredReputationRank = (Int32)itemSparse.Value.RequiredReputationRank;
                Data.MaxCount = (Int32)itemSparse.Value.MaxCount;
                Data.Stackable = (Int32)itemSparse.Value.Stackable;
                Data.ContainerSlots = (Int32)itemSparse.Value.ContainerSlots;

                for (int i = 0; i < Data.StatType.Capacity; i++)
                    Data.StatType.Add((Int32)itemSparse.Value.StatType[i]);

                for (int i = 0; i < Data.StatValue.Capacity; i++)
                    Data.StatValue.Add((Int32)itemSparse.Value.StatValue[i]);

                Data.ScalingStatDistribution = itemSparse.Value.ScalingStatDistribution;
                Data.DamageType = (Int32)itemSparse.Value.DamageType;
                Data.Delay = itemSparse.Value.Delay;
                Data.RangedModRange = itemSparse.Value.RangedModRange;

                for (int i = 0; i < Data.SpellId.Capacity; i++)
                    Data.SpellId.Add((Int32)itemSparse.Value.SpellId[i]);

                for (int i = 0; i < Data.SpellTrigger.Capacity; i++)
                    Data.SpellTrigger.Add((Int32)itemSparse.Value.SpellTrigger[i]);

                for (int i = 0; i < Data.SpellCharges.Capacity; i++)
                    Data.SpellCharges.Add((Int32)itemSparse.Value.SpellCharges[i]);

                for (int i = 0; i < Data.SpellCooldown.Capacity; i++)
                    Data.SpellCooldown.Add((Int32)itemSparse.Value.SpellCooldown[i]);

                for (int i = 0; i < Data.SpellCategory.Capacity; i++)
                    Data.SpellCategory.Add((Int32)itemSparse.Value.SpellCategory[i]);

                for (int i = 0; i < Data.SpellCategoryCooldown.Capacity; i++)
                    Data.SpellCategoryCooldown.Add((Int32)itemSparse.Value.SpellCategoryCooldown[i]);

                Data.Bonding = (Int32)itemSparse.Value.Bonding;

                Data.Name = itemSparse.Value.Name;
                Data.Description = itemSparse.Value.Description;
                Data.PageText = (Int32)itemSparse.Value.PageText;
                Data.LanguageId = (Int32)itemSparse.Value.LanguageId;
                Data.PageMaterial = (Int32)itemSparse.Value.PageMaterial;
                Data.StartQuest = (Int32)itemSparse.Value.StartQuest;
                Data.Material = (Int32)itemSparse.Value.Material;
                Data.Sheath = (Int32)itemSparse.Value.Sheath;
                Data.RandomProperty = (Int32)itemSparse.Value.RandomProperty;
                Data.RandomSuffix = (Int32)itemSparse.Value.RandomSuffix;
                Data.ItemSet = (Int32)itemSparse.Value.ItemSet;
                Data.Area = (Int32)itemSparse.Value.Area;
                Data.Map = (Int32)itemSparse.Value.Map;
                Data.BagFamily = (Int32)itemSparse.Value.BagFamily;
                Data.TotemCategory = (Int32)itemSparse.Value.TotemCategory;

                for (int i = 0; i < Data.SocketColor.Capacity; i++)
                    Data.SocketColor.Add((Int32)itemSparse.Value.SocketColor[i]);

                for (int i = 0; i < Data.SocketContent.Capacity; i++)
                    Data.SocketContent.Add((Int32)itemSparse.Value.SocketContent[i]);

                Data.SocketBonus = (Int32)itemSparse.Value.SocketBonus;
                Data.GemProperties = (Int32)itemSparse.Value.GemProperties;
                Data.ArmorDamageModifier = itemSparse.Value.ArmorDamageModifier;
                Data.Duration = (Int32)itemSparse.Value.Duration;
                Data.ItemLimitCategory = (Int32)itemSparse.Value.ItemLimitCategory;
                Data.HolidayId = (Int32)itemSparse.Value.HolidayId;
                Data.StatScalingFactor = itemSparse.Value.StatScalingFactor;
                Data.CurrencySubstitutionId = (Int32)itemSparse.Value.CurrencySubstitutionId;
                Data.CurrencySubstitutionCount = (Int32)itemSparse.Value.CurrencySubstitutionCount;

                Item item = new Item()
                {
                    Data = Data
                };

                Add(item);
            }

            Log.Message(LogType.NORMAL, "Loaded {0} items.", Items.Count);
        }

        public void Initialize()
        {
            LoadItemData();
        }
    }
}
