using NHeroes2.Serialize;
using NHeroes2.Utilities;
using static NHeroes2.Agg.Music.MiniLog;

namespace NHeroes2.Agg.Music
{
    internal class IFFChunkHeader
    {
        public uint ID; // 4 upper case ASCII chars, padded with 0x20 (space)
        public int length; // big-endian

        static IFFChunkHeader()
        {
            ByteVectorReflect.AddTypeReader<IFFChunkHeader>((sb, st) =>
            {
                st.ID = sb.getBE32();
                st.length = (int) sb.getBE32();

                addLine("IFFChunkHeader", st.length);
            });
            ByteVectorReflect.AddTypeWriter((ByteVectorWriter sb, IFFChunkHeader st) =>
            {
                sb.putBE32(st.ID);
                sb.putBE32((uint) st.length);
            });
        }

        public IFFChunkHeader()
        {
        }

        public IFFChunkHeader(uint id, int sz)
        {
            ID = id;
            length = sz;
        }

        public override string ToString()
        {
            return this.SerializeToJsonString();
        }
    }
}