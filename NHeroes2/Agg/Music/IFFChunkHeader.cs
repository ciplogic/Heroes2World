using System;
using NHeroes2.Serialize;

namespace NHeroes2.Agg.Music
{
    class IFFChunkHeader
    {
        public UInt32 ID = 0; // 4 upper case ASCII chars, padded with 0x20 (space)
        public int length = 0; // big-endian

        static IFFChunkHeader()
        {
            ByteVectorReflect.AddTypeReader<IFFChunkHeader>((sb,st) =>
            {
                st.ID = sb.getBE32();
                st.length = (int) sb.getBE32();
            });
            ByteVectorReflect.AddTypeWriter((ByteVectorWriter sb, IFFChunkHeader st) =>
            {
                sb.putBE32(st.ID);
                sb.putBE32((uint) st.length);
            });
        }

        public IFFChunkHeader(){}
        public IFFChunkHeader(uint id, int sz)
        {
            ID =id;
            length = sz;

        }
    }
}