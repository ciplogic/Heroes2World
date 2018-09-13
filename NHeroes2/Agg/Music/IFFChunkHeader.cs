using System;

namespace NHeroes2.Agg.Music
{
    class IFFChunkHeader
    {
        public UInt32 ID = 0; // 4 upper case ASCII chars, padded with 0x20 (space)
        public int length = 0; // big-endian
    }
}