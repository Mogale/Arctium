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

using Framework.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Framework.DBC
{
    static class DBCReader
    {        
        public static Dictionary<uint, T> ReadDBC<T>(Dictionary<uint, string> strDict, string _fmt, string FileName) where T : struct
        {
            Dictionary<uint, T> dict = new Dictionary<uint, T>();
            try
            {
                string path = WorldConfig.DataPath + "/dbc/" + FileName;
                using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read), Encoding.UTF8))
                {
                    // read dbc header
                    DbcHeader header = reader.ReadHeader<DbcHeader>();
                    int size = Marshal.SizeOf(typeof(T));

                    if (!header.IsDBC)
                    {
                        Logging.Log.Message(Logging.LogType.ERROR, "{0} is not DBC File", FileName);
                        return null;
                    }

                    if (header.RecordSize != _fmt.Length * 4)
                    {
                        Logging.Log.Message(Logging.LogType.ERROR, "Size of '{0}' setted by format string ({1}) not equal size of DBC structure ({2}).", FileName, _fmt.Length * 4, header.RecordSize);
                        return null;
                    }

                    int structsize = Marshal.SizeOf(typeof(T));
                    if (structsize != _fmt.GetFMTCount())
                    {
                        Logging.Log.Message(Logging.LogType.ERROR, "Size of '{0}' setted by format string ({1}) not equal size of C# Structure ({2}).", FileName, _fmt.GetFMTCount(), structsize);
                        return null;
                    }

                    // read dbc data
                    for (int r = 0; r < header.RecordsCount; ++r)
                    {
                        uint key = reader.ReadUInt32();
                        reader.BaseStream.Position -= 4;

                        T T_entry = reader.ReadStruct<T>(_fmt);

                        dict.Add(key, T_entry);
                    }

                    // read dbc strings
                    if (strDict != null)
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            var offset = (uint)(reader.BaseStream.Position - header.StartStringPosition);
                            var str = reader.ReadCString();
                            strDict.Add(offset, str);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Logging.Log.Message(Logging.LogType.ERROR, "Cant Find File {0}", FileName);
                return null;
            }
            DBCStorage.DBCFileCount += 1;
            return dict;
        }
    }
}
