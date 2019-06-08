using NHeroes2.Serialize;
using NHeroes2.Utilities;

namespace NHeroes2.Agg.Music
{
    internal class GroupChunkHeader
    {
        public uint ID; // 4 byte ASCII string, either 'FORM', 'CAT ' or 'LIST'
        public uint length;
        public uint type; // 4 byte ASCII string

        static GroupChunkHeader()
        {
            ByteVectorReflect.AddTypeReader<GroupChunkHeader>((sb, st) =>
            {
                st.ID = sb.getBE32();
                st.length = sb.getBE32();
                st.type = sb.getBE32();
            });
        }

        public override string ToString()
        {
            return this.SerializeToJsonString();
        }
    }
}