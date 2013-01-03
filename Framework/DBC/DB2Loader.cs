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

using Framework.Logging;

namespace Framework.DBC
{
    public class DB2Loader
    {
        public static void Init()
        {
            Log.Message(LogType.NORMAL, "Loading DB2Storage...");
            DB2Storage.ItemEntryStorage = DB2Reader.ReadDB2<ItemEntry>(null, DB2Fmt.Itemfmt, "Item.db2");
            DB2Storage.ItemSparseStorage = DB2Reader.ReadDB2<ItemSparse>(DB2Storage.ItemSparseStrings, DB2Fmt.ItemSparsefmt, "Item-sparse.db2");
            DB2Storage.ItemExtendedCostStorage = DB2Reader.ReadDB2<ItemExtendedCost>(null, DB2Fmt.ItemExtendedCostfmt, "ItemExtendedCost.db2");

            Log.Message(LogType.NORMAL, "Loaded {0} db2 files.", DB2Storage.DB2FileCount);
            Log.Message();
        }
    }
}
