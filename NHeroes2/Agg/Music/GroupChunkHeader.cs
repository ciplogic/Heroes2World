using System;
using NHeroes2.Utilities;

namespace NHeroes2.Agg.Music
{
    class GroupChunkHeader
    {
        public UInt32 ID = 0; // 4 byte ASCII string, either 'FORM', 'CAT ' or 'LIST'
        public UInt32 length = 0;
        public UInt32 type = 0; // 4 byte ASCII string

        static GroupChunkHeader()
        {
            Serialize.ByteVectorReflect.AddTypeReader<GroupChunkHeader>((sb,st) =>
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