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

using Framework.Constants;
using System;
using System.Collections.Generic;
using System.Reflection;
using Framework.Network.Packets;
using WorldServer.Network;

namespace WorldServer.Game.Packets
{
    public class PacketManager : Globals
    {
        static Dictionary<ClientMessage, HandlePacket> OpcodeHandlers = new Dictionary<ClientMessage, HandlePacket>();
        delegate void HandlePacket(ref PacketReader packet, ref WorldClass session);

        public static void DefineOpcodeHandler()
        {
            Assembly currentAsm = Assembly.GetExecutingAssembly();
            foreach (var type in currentAsm.GetTypes())
            {
                foreach (var methodInfo in type.GetMethods())
                {
                    var opcodeAttr = methodInfo.GetCustomAttribute<OpcodeAttribute>();

                    if (opcodeAttr != null)
                        OpcodeHandlers[opcodeAttr.Opcode] = (HandlePacket)Delegate.CreateDelegate(typeof(HandlePacket), methodInfo);
                }
            }
        }

        public static bool InvokeHandler(ref PacketReader reader, WorldClass session, ClientMessage opcode)
        {
            if (session.Character != null)
            {
                ulong charGuid = session.Character.Guid;

                if (WorldMgr.Sessions.ContainsKey(charGuid))
                    WorldMgr.Sessions[charGuid] = session;
            }

            if (OpcodeHandlers.ContainsKey(opcode))
            {
                OpcodeHandlers[opcode].Invoke(ref reader, ref session);
                return true;
            }
            else
                return false;
        }
    }
}
