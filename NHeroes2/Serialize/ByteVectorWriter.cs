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

        public ByteVectorWriter put8(int val)
        {
            _data.Add((byte) val);
            return this;
        }


        public void putLE16(ushort v)
        {
            put8(v);
            put8(v >> 8);
        }

        public void putBE16(ushort v)
        {
            put8(v >> 8);
            put8(v);
        }

        public void putBE32(uint v)
        {
            putBE16((ushort) (v >> 16));
            putBE16((ushort) v);
        }
    }
}