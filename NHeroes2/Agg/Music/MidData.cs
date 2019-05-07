using NHeroes2.Serialize;
using NHeroes2.Utilities;
using static NHeroes2.Agg.Music.MiniLog;

namespace NHeroes2.Agg.Music
{
    internal class MidData
    {
        public IFFChunkHeader mthd;
        public int format;
        public int ppqn;
        public MidTracks tracks;

        public override string ToString()
        {
            return this.SerializeToJsonString();
        }

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
                
                
                flushLog();
            }
            );
        }
    }
}