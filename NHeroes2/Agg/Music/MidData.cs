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
        
        public MidData() 
        {
            mthd = new IFFChunkHeader(Xml2Mid.TAG_MTHD, 6);
        }

        public MidData(XMITracks t, int p) 
        {
            mthd = new IFFChunkHeader(Xml2Mid.TAG_MTHD, 6);
            ppqn = p;
            tracks = new MidTracks(t);
        }
        static MidData()
        {
        ByteVectorReflect.AddTypeWriter<MidData>(
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