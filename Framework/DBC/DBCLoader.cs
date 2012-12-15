/*
 * Copyright (C) 2012 Arctium <http://>
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
            DBCStorage.FactionStorage = DBCReader.ReadDBC<Faction>(DBCStorage.FactionStrings, DBCFmt.FactionEntryfmt, "Faction.dbc");
            DBCStorage.FactionTemplateStorage = DBCReader.ReadDBC<FactionTemplate>(null, DBCFmt.FactionTemplateEntryfmt, "FactionTemplate.dbc");
            DBCStorage.GameObjectDisplayInfoStorage = DBCReader.ReadDBC<GameObjectDisplayInfo>(DBCStorage.GameObjectDisplayInfoStrings, DBCFmt.GameObjectDisplayInfofmt, "GameObjectDisplayInfo.dbc");
            DBCStorage.GlyphPropertiesStorage = DBCReader.ReadDBC<GlyphProperties>(null, DBCFmt.GlyphPropertiesfmt, "GlyphProperties.dbc");
            DBCStorage.GlyphSlotStorage = DBCReader.ReadDBC<GlyphSlot>(null, DBCFmt.GlyphSlotEntryfmt, "GlyphSlot.dbc");
            DBCStorage.MapStorage = DBCReader.ReadDBC<Map>(DBCStorage.MapStrings, DBCFmt.MapEntryfmt, "Map.dbc");
            DBCStorage.MountCapabilityStorage = DBCReader.ReadDBC<MountCapability>(null, DBCFmt.MountCapabilityfmt, "MountCapability.dbc");
            DBCStorage.NameGenStorage = DBCReader.ReadDBC<NameGen>(DBCStorage.NameGenStrings, DBCFmt.NameGenfmt, "NameGen.dbc");

            Log.Message(LogType.NORMAL, "Loaded {0} dbc files.", DBCStorage.DBCFileCount);
            Log.Message();
        }
    }
}
