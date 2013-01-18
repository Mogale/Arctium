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

using Framework.Console;
using WorldServer.Game.Packets.PacketHandler;
using Framework.ObjectDefines;
using Framework.Database;
using System;
using WorldServer.Network;

namespace WorldServer.Game.Chat.Commands
{
    public class MovementCommands : Globals
    {
        [ChatCommand("fly", "Usage: !fly #state (Turns the fly mode 'on' or 'off')")]
        public static void Fly(string[] args, ref WorldClass session)
        {
            string state = CommandParser.Read<string>(args, 1);

            if (state == "on")
            {
                MoveHandler.HandleMoveSetCanFly(ref session);
                ChatHandler.SendMessageByType(ref session, 0, 0, "Fly mode enabled.");
            }
            else if (state == "off")
            {
                MoveHandler.HandleMoveUnsetCanFly(ref session);
                ChatHandler.SendMessageByType(ref session, 0, 0, "Fly mode disabled.");
            }
        }

        [ChatCommand("walkspeed", "Usage: !walkspeed #speed (Set the current walk speed)")]
        public static void WalkSpeed(string[] args, ref WorldClass session)
        {
            if (args.Length == 1)
                MoveHandler.HandleMoveSetWalkSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);

                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetWalkSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Walk speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Walk speed set to default.");
        }

        [ChatCommand("runspeed", "Usage: !runspeed #speed (Set the current run speed)")]
        public static void RunSpeed(string[] args, ref WorldClass session)
        {
            if (args.Length == 1)
                MoveHandler.HandleMoveSetRunSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);
                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetRunSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Run speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Run speed set to default.");
        }

        [ChatCommand("swimspeed", "Usage: !swimspeed #speed (Set the current swim speed)")]
        public static void SwimSpeed(string[] args, ref WorldClass session)
        {
            if (args.Length == 1)
                MoveHandler.HandleMoveSetSwimSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);
                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetSwimSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Swim speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Swim speed set to default.");
        }

        [ChatCommand("flightspeed", "Usage: !flightspeed #speed (Set the current flight speed)")]
        public static void FlightSpeed(string[] args, ref WorldClass session)
        {
            if (args.Length == 1)
                MoveHandler.HandleMoveSetFlightSpeed(ref session);
            else
            {
                var speed = CommandParser.Read<float>(args, 1);

                if (speed <= 50 && speed > 0)
                {
                    MoveHandler.HandleMoveSetFlightSpeed(ref session, speed);
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Flight speed set to " + speed + "!");
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Please enter a value between 0.0 and 50.0!");

                return;
            }

            ChatHandler.SendMessageByType(ref session, 0, 0, "Flight speed set to default.");
        }

        [ChatCommand("tele", "Usage: !tele [#x #y #z #o #map] or [#location] (Force teleport to a new location by coordinates or location)")]
        public static void Teleport(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;
            Vector4 vector;
            uint mapId;

            if (args.Length > 2)
            {
                vector = new Vector4()
                {
                    X = CommandParser.Read<float>(args, 1),
                    Y = CommandParser.Read<float>(args, 2),
                    Z = CommandParser.Read<float>(args, 3),
                    O = CommandParser.Read<float>(args, 4)
                };

                mapId = CommandParser.Read<uint>(args, 5);
            }
            else
            {
                string location = CommandParser.Read<string>(args, 1);
                SQLResult result = DB.World.Select("SELECT * FROM teleport_locations WHERE location = ?", location);

                if (result.Count == 0)
                {
                    ChatHandler.SendMessageByType(ref session, 0, 0, "Teleport location '" + location + "' does not exist.");
                    return;
                }

                vector = new Vector4()
                {
                    X = result.Read<float>(0, "X"),
                    Y = result.Read<float>(0, "Y"),
                    Z = result.Read<float>(0, "Z"),
                    O = result.Read<float>(0, "O")
                };

                mapId = result.Read<uint>(0, "Map");
            }

            pChar.TeleportTo(vector, mapId);

            ObjectHandler.HandleUpdateObjectCreate(ref session);
        }

        [ChatCommand("start", "Usage: !start (Teleports yourself to your start position)")]
        public static void Start(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;

            SQLResult result = DB.Characters.Select("SELECT map, posX, posY, posZ, posO FROM character_creation_data WHERE race = ? AND class = ?", pChar.Race, pChar.Class);

            Vector4 vector = new Vector4()
            {
                X = result.Read<float>(0, "PosX"),
                Y = result.Read<float>(0, "PosY"),
                Z = result.Read<float>(0, "PosZ"),
                O = result.Read<float>(0, "PosO")
            };

            uint mapId = result.Read<uint>(0, "Map");

            pChar.TeleportTo(vector, mapId);
        }

        [ChatCommand("appear", "Usage: !appear #playerName (Teleports yourself to Players position)")]
        public static void Appear(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;
            var appearName = CommandParser.Read<string>(args, 1);

            var appearSession = WorldMgr.GetSession(appearName);
            if (appearSession != null)
                pChar.TeleportTo(appearSession.Character.Position, appearSession.Character.Map);
            else
                ChatHandler.SendMessageByType(ref session, 0, 0, String.Format("Appear failed. Player {0} not found.", appearName));
        }

        [ChatCommand("summon", "Usage: !summon #playerName (Teleports the Player to your current position)")]
        public static void Summon(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;
            var summonName = CommandParser.Read<string>(args, 1);

            var summonSession = WorldMgr.GetSession(summonName);
            if (summonSession != null)
                summonSession.Character.TeleportTo(pChar.Position, pChar.Map);
            else
            {
                SQLResult result = DB.Characters.Select("SELECT guid FROM characters WHERE name = ?", summonName);
                if (result.Count > 0)
                {
                    DB.Characters.Execute("UPDATE characters SET x = ?, y = ?, z = ?, o = ?, map = ? WHERE guid = ?", pChar.Position.X, pChar.Position.Y, pChar.Position.Z, pChar.Position.O, pChar.Map, result.Read<uint>(0, "guid"));
                    ChatHandler.SendMessageByType(ref session, 0, 0, String.Format("Offline Summon for {0} Success!", summonName));
                }
                else
                    ChatHandler.SendMessageByType(ref session, 0, 0, String.Format("Summon failed. Player {0} not found!", summonName));
            }
        }

        [ChatCommand("gps", "Usage: !gps (Show your current location)")]
        public static void GPS(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;

            var message = String.Format("Your position is X: {0}, Y: {1}, Z: {2}, W(O): {3}, Map: {4}, Zone: {5}", pChar.Position.X, pChar.Position.Y, pChar.Position.Z, pChar.Position.O, pChar.Map, pChar.Zone);
            ChatHandler.SendMessageByType(ref session, 0, 0, message);
        }

        [ChatCommand("addtele", "Usage: !addtele #name (Adds a new teleport location to the world database with the given name)")]
        public static void AddTele(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;

            string location = CommandParser.Read<string>(args, 1);
            SQLResult result = DB.World.Select("SELECT * FROM teleport_locations WHERE location = ?", location);

            if (result.Count == 0)
            {
                if (DB.World.Execute("INSERT INTO teleport_locations (location, x, y, z, o, map) " +
                    "VALUES (?, ?, ?, ?, ?, ?)", location, pChar.Position.X, pChar.Position.Y, pChar.Position.Z, pChar.Position.O, pChar.Map))
                {
                    ChatHandler.SendMessageByType(ref session, 0, 0, String.Format("Teleport location '{0}' successfully added.", location));
                }
            }
            else
                ChatHandler.SendMessageByType(ref session, 0, 0, String.Format("Teleport location '{0}' already exist.", location));
        }

        [ChatCommand("deltele", "Usage: !deltele #name (Delete the given teleport location from the world database)")]
        public static void DelTele(string[] args, ref WorldClass session)
        {
            var pChar = session.Character;

            string location = CommandParser.Read<string>(args, 1);
            if (DB.World.Execute("DELETE FROM teleport_locations WHERE location = ?", location))
                ChatHandler.SendMessageByType(ref session, 0, 0, String.Format("Teleport location '{0}' successfully deleted.", location));
        }
    }
}
