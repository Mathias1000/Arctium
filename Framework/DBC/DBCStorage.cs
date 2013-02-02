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

using System.Collections.Generic;

namespace Framework.DBC
{
    public static class DBCStorage
    {
        internal static int DBCFileCount = 0;

        public static Dictionary<uint, AreaGroup> AreaGroupStorage;
        public static Dictionary<uint, AreaPOI> AreaPOIStorage;
        public static Dictionary<uint, AreaTable> AreaTableStorage;
        public static Dictionary<uint, AreaTrigger> AreaTriggerStorage;
        public static Dictionary<uint, ChrClasses> ClassStorage;
        public static Dictionary<uint, ChrRaces> RaceStorage;
        public static Dictionary<uint, ChrPowerType> ChrPowerTypeStorage;
        public static Dictionary<uint, CharStartOutfit> CharStartOutfitStorage;
        public static Dictionary<uint, ItemClass> ItemClassStorage;
        public static Dictionary<uint, ItemPriceBase> ItemPriceBaseStorage;
        public static Dictionary<uint, ItemSet> ItemSetStorage;
        public static Dictionary<uint, NameGen> NameGenStorage;
        public static Dictionary<uint, ChatChannels> ChatChannelStorage;
        public static Dictionary<uint, Faction> FactionStorage;
        public static Dictionary<uint, FactionTemplate> FactionTemplateStorage;
        public static Dictionary<uint, GameObjectDisplayInfo> GameObjectDisplayInfoStorage;
        public static Dictionary<uint, GlyphProperties> GlyphPropertiesStorage;
        public static Dictionary<uint, ChrSpecialization> SpecializationStorage;
        public static Dictionary<uint, SpecializationSpell> SpecializationSpellStorage;
        public static Dictionary<uint, Spell> SpellStorage;
        public static Dictionary<uint, SpellLevels> SpellLevelStorage;
        public static Dictionary<uint, Talent> TalentStorage;
        public static Dictionary<uint, GlyphSlot> GlyphSlotStorage;
        public static Dictionary<uint, LiquidType> LiquidTypeStorage;
        public static Dictionary<uint, Map> MapStorage;
        public static Dictionary<uint, MountCapability> MountCapabilityStorage;
        public static Dictionary<uint, TaxiNodes> TaxiNodesStorage;
        public static Dictionary<uint, TaxiPath> TaxiPathStorage;
        public static Dictionary<uint, TaxiPathNode> TaxiPathNodeStorage;
        public static Dictionary<uint, WMOAreaTable> WMOAreaTableStorage;
        public static Dictionary<uint, WorldMapArea> WorldMapAreaStorage;
        public static Dictionary<uint, WorldSafeLocs> WorldSafeLocsStorage;
        public static Dictionary<uint, BaseHPByClass> BaseHPByClassStorage;
        public static Dictionary<uint, BaseMPByClass> BaseMPByClassStorage;
        public static Dictionary<uint, HpPerStamina> HpPerStaminaStorage;

        //Strings
        internal static Dictionary<uint, string> AreaTableStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> AreaPOIStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> ClassStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> RaceStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> ItemSetStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> NameGenStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> ChatChannelStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> FactionStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> GameObjectDisplayInfoStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> MapStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> TaxiNodesStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> WorldMapAreaStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> WorldSafeLocsStrings = new Dictionary<uint, string>();
    }
}
