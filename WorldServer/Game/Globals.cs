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

using WorldServer.Game.Managers;

namespace WorldServer.Game
{
    public class Globals
    {
        public static AddonManager AddonMgr;
        public static DataManager DataMgr;
        public static ObjectManager ObjectMgr;
        public static SkillManager SkillMgr;
        public static SpawnManager SpawnMgr;
        public static SpellManager SpellMgr;
        public static WorldManager WorldMgr;

        public static void InitializeManager()
        {
            AddonMgr = AddonManager.GetInstance();
            DataMgr = DataManager.GetInstance();
            ObjectMgr = ObjectManager.GetInstance();
            SkillMgr = SkillManager.GetInstance();
            SpawnMgr = SpawnManager.GetInstance();
            SpellMgr = SpellManager.GetInstance();
            WorldMgr = WorldManager.GetInstance();
        }
    }
}
