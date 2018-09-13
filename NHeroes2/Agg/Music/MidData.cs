using System;
using NHeroes2.Serialize;

namespace NHeroes2.Agg.Music
{
    internal class MidData
    {
        public IFFChunkHeader mthd;
        public int format;
        public int ppqn;
        public MidTracks tracks;
        public MidData(XMITracks xmiTracks, int i)
        {
            throw new NotImplementedException();
        }

        static MidData()
        {
        ByteVectorReaderReflect.AddTypeWriter<MidData>(
            (sb, st) =>
            {
                sb.Write(st.mthd); 
                sb.putBE16((ushort) st.format);
                sb.putBE16((ushort) st.tracks._items.Count);
                sb.putBE16((ushort) st.ppqn);
                sb.Write(st.tracks);
            }
            );
        }
    }
}