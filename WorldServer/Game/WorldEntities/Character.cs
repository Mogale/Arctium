﻿/*
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
using System.Linq;
using System.Collections.Generic;
using Framework.Constants.ItemSettings;
using Framework.ObjectDefines;
using Framework.Constants;
using Framework.Database;
using Framework.DBC;
using WorldServer.Game.Managers;
using WorldServer.Game.PacketHandler;
using WorldServer.Game.Packets.PacketHandler;

namespace WorldServer.Game.WorldEntities
{
    public class Character : WorldObject
    {
        public UInt32 AccountId;
        public String Name;
        public Byte Race;
        public Byte Class;
        public Byte Gender;
        public Byte Skin;
        public Byte Face;
        public Byte HairStyle;
        public Byte HairColor;
        public Byte FacialHair;
        public Byte Level;
        public UInt64 Money;
        public UInt32 Zone;
        public UInt64 GuildGuid;
        public UInt32 PetDisplayInfo;
        public UInt32 PetLevel;
        public UInt32 PetFamily;
        public UInt32 CharacterFlags;
        public UInt32 CustomizeFlags;
        public Boolean LoginCinematic;

        public Dictionary<ulong, WorldObject> InRangeObjects = new Dictionary<ulong, WorldObject>();

        public List<Skill> Skills = new List<Skill>();
        public List<PlayerSpell> SpellList = new List<PlayerSpell>();
        public List<PowerTypes> Powers;

        public Character(UInt64 guid, int updateLength = (int)PlayerFields.End) : base(updateLength)
        {
            SQLResult result = DB.Characters.Select("SELECT * FROM characters WHERE guid = ?", guid);

            Guid           = result.Read<UInt64>(0, "Guid");
            AccountId      = result.Read<UInt32>(0, "AccountId");
            Name           = result.Read<String>(0, "Name");
            Race           = result.Read<Byte>(0, "Race");
            Class          = result.Read<Byte>(0, "Class");
            Gender         = result.Read<Byte>(0, "Gender");
            Skin           = result.Read<Byte>(0, "Skin");
            Face           = result.Read<Byte>(0, "Face");
            HairStyle      = result.Read<Byte>(0, "HairStyle");
            HairColor      = result.Read<Byte>(0, "HairColor");
            FacialHair     = result.Read<Byte>(0, "FacialHair");
            Level          = result.Read<Byte>(0, "Level");
            Money          = result.Read<UInt64>(0, "Money");
            Zone           = result.Read<UInt32>(0, "Zone");
            Map            = result.Read<UInt32>(0, "Map");
            Position.X     = result.Read<Single>(0, "X");
            Position.Y     = result.Read<Single>(0, "Y");
            Position.Z     = result.Read<Single>(0, "Z");
            Position.O     = result.Read<Single>(0, "O");
            GuildGuid      = result.Read<UInt64>(0, "GuildGuid");
            PetDisplayInfo = result.Read<UInt32>(0, "PetDisplayId");
            PetLevel       = result.Read<UInt32>(0, "PetLevel");
            PetFamily      = result.Read<UInt32>(0, "PetFamily");
            CharacterFlags = result.Read<UInt32>(0, "CharacterFlags");
            CustomizeFlags = result.Read<UInt32>(0, "CustomizeFlags");
            LoginCinematic = result.Read<Boolean>(0, "LoginCinematic");

            Globals.SpellMgr.LoadSpells(this);
            Globals.SkillMgr.LoadSkills(this);

            SetCharacterFields();
        }

        public void SetCharacterFields()
        {
            // ObjectFields
            SetUpdateField<UInt64>((int)ObjectFields.Guid, Guid);
            SetUpdateField<UInt64>((int)ObjectFields.Data, 0);
            SetUpdateField<Int32>((int)ObjectFields.Type, 0x19);
            SetUpdateField<Single>((int)ObjectFields.Scale, 1.0f);

            // UnitFields
            SetUpdateField<UInt64>((int)UnitFields.Charm, 0);
            SetUpdateField<UInt64>((int)UnitFields.Summon, 0);
            SetUpdateField<UInt64>((int)UnitFields.Critter, 0);
            SetUpdateField<UInt64>((int)UnitFields.CharmedBy, 0);
            SetUpdateField<UInt64>((int)UnitFields.SummonedBy, 0);
            SetUpdateField<UInt64>((int)UnitFields.CreatedBy, 0);
            SetUpdateField<UInt64>((int)UnitFields.Target, 0);
            SetUpdateField<UInt64>((int)UnitFields.ChannelObject, 0);

            SetUpdateField<Int32>((int)UnitFields.Health, GetBaseHealth());
            SetUpdateField<Int32>((int)UnitFields.MaxHealth, GetBaseHealth());

            SetInitialPower();

            SetUpdateField<Int32>((int)UnitFields.PowerRegenFlatModifier, 0);
            SetUpdateField<Int32>((int)UnitFields.PowerRegenInterruptedFlatModifier, 0);

            SetUpdateField<Int32>((int)UnitFields.BaseHealth, GetBaseHealth());
            SetUpdateField<Int32>((int)UnitFields.BaseMana, GetBaseMana());
            SetUpdateField<Int32>((int)UnitFields.Level, Level);
            SetUpdateField<Int32>((int)UnitFields.FactionTemplate, (int)DBCStorage.RaceStorage[Race].FactionID);
            SetUpdateField<Int32>((int)UnitFields.Flags, 0);
            SetUpdateField<Int32>((int)UnitFields.Flags2, 0);

            for (int i = 0; i < 5; i++)
            {
                SetUpdateField<Int32>((int)UnitFields.Stats + i, 20);
                SetUpdateField<Int32>((int)UnitFields.StatPosBuff + i, 0);
                SetUpdateField<Int32>((int)UnitFields.StatNegBuff + i, 0);
            }

            SetUpdateField<Byte>((int)UnitFields.DisplayPower, Race, 0);
            SetUpdateField<Byte>((int)UnitFields.DisplayPower, Class, 1);
            SetUpdateField<Byte>((int)UnitFields.DisplayPower, Gender, 2);
            SetUpdateField<Byte>((int)UnitFields.DisplayPower, (byte)DBCStorage.ClassStorage[Class].DisplayPowerType, 3);

            uint displayId = Gender == 0 ? DBCStorage.RaceStorage[Race].model_m : DBCStorage.RaceStorage[Race].model_f;
            SetUpdateField<Int32>((int)UnitFields.DisplayID, (int)displayId);
            SetUpdateField<Int32>((int)UnitFields.NativeDisplayID, (int)displayId);
            SetUpdateField<Int32>((int)UnitFields.MountDisplayID, 0);
            SetUpdateField<Int32>((int)UnitFields.DynamicFlags, 0);

            SetUpdateField<Single>((int)UnitFields.BoundingRadius, 0.389F);
            SetUpdateField<Single>((int)UnitFields.CombatReach, 1.5F);
            SetUpdateField<Single>((int)UnitFields.MinDamage, 0);
            SetUpdateField<Single>((int)UnitFields.MaxDamage, 0);
            SetUpdateField<Single>((int)UnitFields.ModCastingSpeed, 1);
            SetUpdateField<Int32>((int)UnitFields.AttackPower, 0);
            SetUpdateField<Int32>((int)UnitFields.RangedAttackPower, 0);

            for (int i = 0; i < 7; i++)
            {
                SetUpdateField<Int32>((int)UnitFields.Resistances + i, 0);
                SetUpdateField<Int32>((int)UnitFields.ResistanceBuffModsPositive + i, 0);
                SetUpdateField<Int32>((int)UnitFields.ResistanceBuffModsNegative + i, 0);
            }

            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 0);
            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 1);
            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 2);
            SetUpdateField<Byte>((int)UnitFields.AnimTier, 0, 3);

            SetUpdateField<Int16>((int)UnitFields.RangedAttackRoundBaseTime, 0);
            SetUpdateField<Int16>((int)UnitFields.RangedAttackRoundBaseTime, 0, 1);
            SetUpdateField<Single>((int)UnitFields.MinOffHandDamage, 0);
            SetUpdateField<Single>((int)UnitFields.MaxOffHandDamage, 0);
            SetUpdateField<Int32>((int)UnitFields.AttackPowerModPos, 0);
            SetUpdateField<Int32>((int)UnitFields.RangedAttackPowerModPos, 0);
            SetUpdateField<Single>((int)UnitFields.MinRangedDamage, 0);
            SetUpdateField<Single>((int)UnitFields.MaxRangedDamage, 0);
            SetUpdateField<Single>((int)UnitFields.AttackPowerMultiplier, 0);
            SetUpdateField<Single>((int)UnitFields.RangedAttackPowerMultiplier, 0);
            SetUpdateField<Single>((int)UnitFields.MaxHealthModifier, 1);
            
            // PlayerFields
            SetUpdateField<Int32>((int)PlayerFields.MaxLevel, 90);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, Skin, 0);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, Face, 1);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, HairStyle, 2);
            SetUpdateField<Byte>((int)PlayerFields.HairColorID, HairColor, 3);
            SetUpdateField<Byte>((int)PlayerFields.RestState, FacialHair, 0);
            SetUpdateField<Byte>((int)PlayerFields.RestState, 0, 1);
            SetUpdateField<Byte>((int)PlayerFields.RestState, 0, 2);
            SetUpdateField<Byte>((int)PlayerFields.RestState, 2, 3);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, Gender, 0);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, 0, 1);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, 0, 2);
            SetUpdateField<Byte>((int)PlayerFields.ArenaFaction, 0, 3);
            SetUpdateField<Int32>((int)PlayerFields.WatchedFactionIndex, -1);
            SetUpdateField<Int32>((int)PlayerFields.XP, 0);
            SetUpdateField<Int32>((int)PlayerFields.NextLevelXP, 400);
            SetUpdateField<Int32>((int)PlayerFields.PlayerFlags, 0);
            SetUpdateField<Int32>((int)PlayerFields.CharacterPoints, 0);
            SetUpdateField<Int32>((int)PlayerFields.GuildRankID, 0);
            SetUpdateField<Single>((int)PlayerFields.CritPercentage, 0);
            SetUpdateField<Single>((int)PlayerFields.RangedCritPercentage, 0);
            SetUpdateField<Int32>((int)PlayerFields.ModHealingDonePos, 0);

            for (int i = 0; i < 7; i++)
            {
                SetUpdateField<Single>((int)PlayerFields.SpellCritPercentage + i, 0);
                SetUpdateField<Int32>((int)PlayerFields.ModDamageDonePos + i, 0);
                SetUpdateField<Int32>((int)PlayerFields.ModDamageDoneNeg + i, 0);
                SetUpdateField<Single>((int)PlayerFields.ModDamageDonePercent + i, 0);
            }

            SetUpdateField<UInt64>((int)PlayerFields.Coinage, Money);

            for (int i = 0; i < 448; i++)
                if (i < Skills.Count)
                    SetUpdateField<UInt32>((int)PlayerFields.Skill + i, Skills[i].Id);
                else
                    SetUpdateField<UInt32>((int)PlayerFields.Skill + i, 0);

            for (int i = 0; i < 750; i++)
                SetUpdateField<Int32>((int)PlayerFields.QuestLog + i, 0);

            SetUpdateField<UInt32>((int)PlayerFields.HomePlayerRealm, 1);
            SetUpdateField<Single>((int)PlayerFields.BlockPercentage, 0);

            for (int i = 0; i < 200; i++)
                SetUpdateField<UInt32>((int)PlayerFields.ExploredZones + i, 0);
        }

        public static string NormalizeName(string name)
        {
            return name[0].ToString().ToUpper() + name.Remove(0, 1).ToLower();
        }

        public void TeleportTo(Vector4 vector, uint mapId)
        {
            var session = Globals.WorldMgr.GetSession(Guid);
            var pChar = this;

            if (Map == mapId)
            {
                MoveHandler.HandleMoveTeleport(ref session, vector);
                Globals.ObjectMgr.SetPosition(ref pChar, vector);
            }
            else
            {
                MoveHandler.HandleTransferPending(ref session, mapId);
                MoveHandler.HandleNewWorld(ref session, vector, mapId);

                Globals.ObjectMgr.SetPosition(ref pChar, vector);
                Globals.ObjectMgr.SetMap(ref pChar, mapId);

                ObjectHandler.HandleUpdateObjectCreate(ref session);
            }
        }

        private void SetInitialPower()
        {
            Powers = DBCStorage.ChrPowerTypeStorage.Where(p => p.Value.Class == Class).Select(n => (PowerTypes)n.Value.PowerType).ToList();
            for (int i = 0; i < 5; i++)
            {
                if (Powers.Count > i)
                {
                    SetUpdateField<Int32>((int)UnitFields.Power + i, GetInitialPowerValue(Powers[i]));
                    SetUpdateField<Int32>((int)UnitFields.MaxPower + i, GetMaxPowerValue(Powers[i]));
                }
                else
                {
                    SetUpdateField<Int32>((int)UnitFields.Power + i, 0);
                    SetUpdateField<Int32>((int)UnitFields.MaxPower + i, 0);
                }
            }
        }

        // Temp disabled
        /*
        public void ModifyMoney(UInt64 value)
        {
            var session = Globals.WorldMgr.GetSession(Guid);
            const long goldLimit = 9999999999;
            var newValue = Money + value;
            if (newValue < goldLimit)
            {
                Money = newValue;
                SetUpdateField<UInt64>((int)PlayerFields.Coinage, newValue);
            }
            else
            {
                Money = goldLimit;
                CharacterHandler.HandleEquipError(ref session, InventoryResult.EQUIP_ERR_TOO_MUCH_GOLD);
                SetUpdateField<UInt64>((int)PlayerFields.Coinage, goldLimit);
            }
            DB.Characters.Execute("UPDATE characters SET money = ? WHERE guid = ?", Money, Guid);
            ObjectHandler.HandleUpdateObject(ref session);
        }*/

        public int GetBaseHealth() { return (int)DBCStorage.BaseHPByClassStorage[(uint)((Class-1)*100 + Level-1)].HealthPoints; }
        public int GetBaseMana() { return (int)DBCStorage.BaseMPByClassStorage[(uint)((Class-1)*100 + Level-1)].ManaPoints; }

        public int GetInitialPowerValue(PowerTypes powerType)
        {
            switch (powerType)
            {
                case PowerTypes.Mana:
                    return GetBaseMana();
                case PowerTypes.Rage:
                case PowerTypes.RunicPower:
                    return 1000;
                case PowerTypes.Focus:
                case PowerTypes.Energy:
                    return 100;
                case PowerTypes.SoulShards:
                    return 3;
                case PowerTypes.Runes:
                    return 8;
                case PowerTypes.Eclipse:
                case PowerTypes.HolyPower:
                case PowerTypes.AlternatePower:
                case PowerTypes.ElusiveBrew:
                case PowerTypes.Chi:
                case PowerTypes.DemonicFury:
                case PowerTypes.BurningEmbers:
                case PowerTypes.ArcaneCharge:
                    return 0;
                default:
                    return 0;
            }
        }

        public int GetMaxPowerValue(PowerTypes powerType)
        {
            switch (powerType)
            {
                case PowerTypes.Mana:
                    return GetBaseMana();
                case PowerTypes.Rage:
                case PowerTypes.RunicPower:
                case PowerTypes.DemonicFury:
                    return 1000;
                case PowerTypes.Focus:
                case PowerTypes.Energy:
                case PowerTypes.Eclipse:
                case PowerTypes.AlternatePower:
                    return 100;
                case PowerTypes.SoulShards:
                case PowerTypes.BurningEmbers:
                case PowerTypes.HolyPower:
                    return 3;
                case PowerTypes.Runes:
                    return 8;
                case PowerTypes.ArcaneCharge:
                    return 6;
                case PowerTypes.Chi:
                    return 5;
                case PowerTypes.ElusiveBrew:
                    return 15;
                default:
                    return 0;
            }
        }
    }
}
