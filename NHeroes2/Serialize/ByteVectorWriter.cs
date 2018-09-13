using System;
using System.Collections.Generic;

namespace NHeroes2.Serialize
{
    public class ByteVectorWriter
    {
        private readonly List<byte> _data;
        public ByteVectorWriter(int length)
        {
            _data = new List<byte>(length);
        }

        public byte[] data()
        {
            return _data.ToArray();
        }

        public void put8(int val)
        {
            _data.Add((byte) val);
        }
        
        

        public void putLE16(UInt16 v)
        {
            put8(v);
            put8(v >> 8);
        }

        public void putBE16(UInt16 v)
        {
            put8(v >> 8);
            put8(v);
        }

    }
}