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

using Framework.Logging;

namespace Framework.DBC
{
    public class DBCLoader
    {
        public static void Init()
        {
            Log.Message(LogType.NORMAL, "Loading DBCStorage...");
            DBCStorage.AreaGroupStorage = DBCReader.ReadDBC<AreaGroup>(null, DBCFmt.AreaGroupEntryfmt, "AreaGroup.dbc");
            DBCStorage.AreaPOIStorage = DBCReader.ReadDBC<AreaPOI>(DBCStorage.AreaPOIStrings, DBCFmt.AreaPOIEntryfmt, "AreaPOI.dbc");
            DBCStorage.AreaTableStorage = DBCReader.ReadDBC<AreaTable>(DBCStorage.AreaTableStrings, DBCFmt.AreaTableEntryfmt, "AreaTable.dbc");
            DBCStorage.AreaTriggerStorage = DBCReader.ReadDBC<AreaTrigger>(null, DBCFmt.AreaTriggerfmt, "AreaTrigger.dbc");
            DBCStorage.ClassStorage = DBCReader.ReadDBC<ChrClasses>(null, DBCFmt.ChrClassesEntryfmt, "ChrClasses.dbc");
            DBCStorage.ChrPowerTypeStorage = DBCReader.ReadDBC<ChrPowerType>(null, DBCFmt.ChrPowerTypesfmt, "ChrClassesXPowerTypes.dbc");
            DBCStorage.RaceStorage = DBCReader.ReadDBC<ChrRaces>(DBCStorage.RaceStrings, DBCFmt.ChrRacesEntryfmt, "ChrRaces.dbc");
            DBCStorage.CharStartOutfitStorage = DBCReader.ReadDBC<CharStartOutfit>(null, DBCFmt.CharStartOutfitfmt, "CharStartOutfit.dbc");
            DBCStorage.ChatChannelStorage = DBCReader.ReadDBC<ChatChannels>(DBCStorage.ChatChannelStrings, DBCFmt.ChatChannelsEntryfmt, "ChatChannels.dbc");
            DBCStorage.ItemClassStorage = DBCReader.ReadDBC<ItemClass>(null, DBCFmt.ItemClassEntryfmt, "ItemClass.dbc");
            DBCStorage.ItemPriceBaseStorage = DBCReader.ReadDBC<ItemPriceBase>(null, DBCFmt.ItemPriceBaseEntryfmt, "ItemPriceBase.dbc");
            DBCStorage.ItemSetStorage = DBCReader.ReadDBC<ItemSet>(DBCStorage.ItemSetStrings, DBCFmt.ItemSetEntryfmt, "ItemSet.dbc");
            DBCStorage.FactionStorage = DBCReader.ReadDBC<Faction>(DBCStorage.FactionStrings, DBCFmt.FactionEntryfmt, "Faction.dbc");
            DBCStorage.FactionTemplateStorage = DBCReader.ReadDBC<FactionTemplate>(null, DBCFmt.FactionTemplateEntryfmt, "FactionTemplate.dbc");
            DBCStorage.GameObjectDisplayInfoStorage = DBCReader.ReadDBC<GameObjectDisplayInfo>(DBCStorage.GameObjectDisplayInfoStrings, DBCFmt.GameObjectDisplayInfofmt, "GameObjectDisplayInfo.dbc");
            DBCStorage.GlyphPropertiesStorage = DBCReader.ReadDBC<GlyphProperties>(null, DBCFmt.GlyphPropertiesfmt, "GlyphProperties.dbc");
            DBCStorage.GlyphSlotStorage = DBCReader.ReadDBC<GlyphSlot>(null, DBCFmt.GlyphSlotEntryfmt, "GlyphSlot.dbc");
            DBCStorage.LiquidTypeStorage = DBCReader.ReadDBC<LiquidType>(null, DBCFmt.LiquidTypefmt, "LiquidType.dbc");
            DBCStorage.MapStorage = DBCReader.ReadDBC<Map>(DBCStorage.MapStrings, DBCFmt.MapEntryfmt, "Map.dbc");
            DBCStorage.MountCapabilityStorage = DBCReader.ReadDBC<MountCapability>(null, DBCFmt.MountCapabilityfmt, "MountCapability.dbc");
            DBCStorage.NameGenStorage = DBCReader.ReadDBC<NameGen>(DBCStorage.NameGenStrings, DBCFmt.NameGenfmt, "NameGen.dbc");
            DBCStorage.TalentStorage = DBCReader.ReadDBC<Talent>(null, DBCFmt.TalentEntryfmt, "Talent.dbc");
            DBCStorage.TaxiNodesStorage = DBCReader.ReadDBC<TaxiNodes>(DBCStorage.TaxiNodesStrings, DBCFmt.TaxiNodesfmt, "TaxiNodes.dbc");
            DBCStorage.TaxiPathStorage = DBCReader.ReadDBC<TaxiPath>(null, DBCFmt.TaxiPathEntryfmt, "TaxiPath.dbc");
            DBCStorage.TaxiPathNodeStorage = DBCReader.ReadDBC<TaxiPathNode>(null, DBCFmt.TaxiPathNodeEntryfmt, "TaxiPathNode.dbc");
            DBCStorage.WMOAreaTableStorage = DBCReader.ReadDBC<WMOAreaTable>(null, DBCFmt.WMOAreaTablefmt, "WMOAreaTable.dbc");
            DBCStorage.WorldMapAreaStorage = DBCReader.ReadDBC<WorldMapArea>(DBCStorage.WorldMapAreaStrings, DBCFmt.WorldMapAreafmt, "WorldMapArea.dbc");
            DBCStorage.WorldSafeLocsStorage = DBCReader.ReadDBC<WorldSafeLocs>(DBCStorage.WorldSafeLocsStrings, DBCFmt.WorldSafeLocsfmt, "WorldSafeLocs.dbc");
            DBCStorage.BaseHPByClassStorage = DBCReader.ReadDBC<BaseHPByClass>(null, DBCFmt.gtOCTBaseHPByClassfmt, "gtOCTBaseHPByClass.dbc");
            DBCStorage.BaseMPByClassStorage = DBCReader.ReadDBC<BaseMPByClass>(null, DBCFmt.gtOCTBaseMPByClassfmt, "gtOCTBaseMPByClass.dbc");
            DBCStorage.HpPerStaminaStorage = DBCReader.ReadDBC<HpPerStamina>(null, DBCFmt.gtOCTHpPerStaminafmt, "gtOCTHpPerStamina.dbc");

            Log.Message(LogType.NORMAL, "Loaded {0} dbc files.", DBCStorage.DBCFileCount);
            Log.Message();
        }
    }
}
